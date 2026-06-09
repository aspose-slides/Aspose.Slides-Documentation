---
title: Εισαγωγή &amp; Ρύθμιση Περιβάλλοντος
type: docs
weight: 10
url: /el/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 
Υπήρξαν ερωτήματα στο παρελθόν σχετικά με την ενσωμάτωση Aspose.Slides για Reporting Services με το SharePoint. Σε αυτό το άρθρο, θα επικεντρωθούμε στο SharePoint 2010. Υποθέτουμε ότι έχετε ήδη ρυθμίσει ένα περιβάλλον SharePoint Farm. Τα παραδείγματα που θα ακολουθήσουμε σε αυτό το άρθρο θα είναι μια πλήρης SharePoint Cloud, αλλά τα βήματα θα είναι παρόμοια για έναν SharePoint Foundation Server. Πριν προχωρήσουμε, ας ξεκινήσουμε με μερική βασική τεκμηρίωση που μπορείτε να χρησιμοποιήσετε ως αναφορά όταν το κάνετε: 

- [Επισκόπηση των Reporting Services και της Ενσωμάτωσης Τεχνολογίας SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Διαμόρφωση των Reporting Services για Ενσωμάτωση με SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Ρύθμιση Περιβάλλοντος**
Η διαμόρφωση που θα χρησιμοποιήσουμε αποτελείται από **4 διακομιστές**. Περιλαμβάνει έναν **Domain Controller**, έναν **SQL Server**, έναν **SharePoint Server** και έναν διακομιστή για **Reporting Services**. Μπορείτε να επιλέξετε να έχετε το SharePoint και τα Reporting Services στον ίδιο υπολογιστή.