/* Title:           Purchase Request Documentation Class
 * Date:            1-23-20
 * Author:          Terry Holmes
 * 
 * Description:     This is used for Purchase Request Documentation*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace PurchaseRequestDocumentationDLL
{
    public class PurchaseRequestDocumentationClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        PurchaseRequestDocumentationDataSet aPurchaseRequestDocumentationDataSet;
        PurchaseRequestDocumentationDataSetTableAdapters.purchaserequestdocumentationTableAdapter aPurchaseRequestDocumentationTableAdapter;

        InsertPurchaseRequestDocumentationEntryTableAdapters.QueriesTableAdapter aInsertPurchaseRequestDocumentationTableAdapter;

        FindPurchaseDocumentationByPONumberDataSet aFindPurchaseDocumentationByPONumberDataSet;
        FindPurchaseDocumentationByPONumberDataSetTableAdapters.FindPurchaseDocumentationByPONumberTableAdapter aFindPurchaseDocumentationByPONumberTableAdapter;

        public FindPurchaseDocumentationByPONumberDataSet FindPurchaseDocumentationByPONumber(int intPONumber)
        {
            try
            {
                aFindPurchaseDocumentationByPONumberDataSet = new FindPurchaseDocumentationByPONumberDataSet();
                aFindPurchaseDocumentationByPONumberTableAdapter = new FindPurchaseDocumentationByPONumberDataSetTableAdapters.FindPurchaseDocumentationByPONumberTableAdapter();
                aFindPurchaseDocumentationByPONumberTableAdapter.Fill(aFindPurchaseDocumentationByPONumberDataSet.FindPurchaseDocumentationByPONumber, intPONumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Documentation Class // Find Purchase Documentation By PO Number " + Ex.Message);
            }

            return aFindPurchaseDocumentationByPONumberDataSet;
        }
        public bool InsertPurchaseRequestDocumentation(int intPONumber, DateTime datTransactionDate, int intEmployeeID, string strDocumentPath)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPurchaseRequestDocumentationTableAdapter = new InsertPurchaseRequestDocumentationEntryTableAdapters.QueriesTableAdapter();
                aInsertPurchaseRequestDocumentationTableAdapter.InsertPurchaseRequestDocumentation(intPONumber, datTransactionDate, intEmployeeID, strDocumentPath);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Documentation Class // Insert Purchase Request Doucment " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public PurchaseRequestDocumentationDataSet GetPurchaseRequestionDocumentationInfo()
        {
            try
            {
                aPurchaseRequestDocumentationDataSet = new PurchaseRequestDocumentationDataSet();
                aPurchaseRequestDocumentationTableAdapter = new PurchaseRequestDocumentationDataSetTableAdapters.purchaserequestdocumentationTableAdapter();
                aPurchaseRequestDocumentationTableAdapter.Fill(aPurchaseRequestDocumentationDataSet.purchaserequestdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Documentation Class // Get Purchase Request Documentation Info " + Ex.Message);
            }

            return aPurchaseRequestDocumentationDataSet;
        }
        public void UpdatePurchaseRequestDocumentationDB(PurchaseRequestDocumentationDataSet aPurchaseRequestDocumentationDataSet)
        {
            try
            {
                aPurchaseRequestDocumentationTableAdapter = new PurchaseRequestDocumentationDataSetTableAdapters.purchaserequestdocumentationTableAdapter();
                aPurchaseRequestDocumentationTableAdapter.Update(aPurchaseRequestDocumentationDataSet.purchaserequestdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Documentation Class // Update Purchase Request Documentation Info " + Ex.Message);
            }
        }
    }
}
