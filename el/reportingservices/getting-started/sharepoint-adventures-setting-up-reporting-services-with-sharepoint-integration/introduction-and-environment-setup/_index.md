---
title: Εισαγωγή και Ρύθμιση Περιβάλλοντος
type: docs
weight: 10
url: /el/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

Στο παρελθόν υπήρχαν ερωτήματα σχετικά με την ενσωμάτωση του Aspose.Slides για Reporting Services με το SharePoint. Σε αυτό το άρθρο, θα εστιάσουμε στο SharePoint 2010. Θεωρείται ότι υπάρχει ήδη ένα περιβάλλον SharePoint Farm. Τα παραδείγματα που θα ακολουθήσουμε σε αυτό το άρθρο θα είναι μια πλήρης SharePoint Cloud, αλλά τα βήματα θα είναι παρόμοια για έναν SharePoint Foundation Server. Πριν προχωρήσουμε, ας ξεκινήσουμε με κάποιους βασικούς οδηγούς τεκμηρίωσης που μπορείτε να χρησιμοποιήσετε ως αναφορά:

- [Επισκόπηση των Reporting Services και της Ενσωμάτωσης Τεχνολογίας SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Διαμόρφωση των Reporting Services για Ενσωμάτωση με SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Ρύθμιση Περιβάλλοντος**
Η διαμόρφωση που θα έχουμε αποτελείται από **4 διακομιστές**. Αυτό περιλαμβάνει έναν **Domain Controller**, έναν **SQL Server**, έναν **SharePoint Server** και έναν διακομιστή για τις **Reporting Services**. Μπορείτε να επιλέξετε να έχετε το SharePoint και τις Reporting Services στο ίδιο κουτί.