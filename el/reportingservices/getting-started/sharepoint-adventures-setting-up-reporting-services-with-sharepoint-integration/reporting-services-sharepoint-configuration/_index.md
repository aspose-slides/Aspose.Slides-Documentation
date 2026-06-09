---
title: Διαμόρφωση Reporting Services στο SharePoint
type: docs
weight: 50
url: /el/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Τώρα που το SharePoint έχει εγκατασταθεί και ρυθμιστεί στον διακομιστή RS και το RS έχει ρυθμιστεί μέσω του Reporting Services Configuration Manager, μπορούμε να προχωρήσουμε στη διαμόρφωση εντός του Central Admin. Το RS 2008 R2 έχει απλοποιήσει πραγματικά αυτή τη διαδικασία. Πριν απαιτούνταν μια διαδικασία τριών βημάτων για να λειτουργήσει. Τώρα έχουμε μόνο ένα βήμα. 

Θέλουμε να μεταβούμε στον ιστότοπο Central Administrator και, στη συνέχεια, στις Γενικές Ρυθμίσεις Εφαρμογών. Στο κάτω μέρος θα δούμε το Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Σχήμα 17**: Διαμόρφωση SharePoint 

{{% alert color="primary" %}} 

Κάντε κλικ στο **Reporting Services Integration**. 

{{% /alert %}} 
## **Διεύθυνση URL Υπηρεσίας Web**
Θα παρέχουμε τη διεύθυνση URL για το Report Server που βρήκαμε στο Reporting Services Configuration Manager. 
## **Λειτουργία Ταυτοποίησης**
Θα επιλέξουμε επίσης μια Λειτουργία Ταυτοποίησης. Ο παρακάτω σύνδεσμος MSDN περιγράφει λεπτομερώς τι είναι αυτά. 
[Security Overview for Reporting Services in SharePoint Integrated Mode](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Συνοπτικά, εάν ο ιστότοπός σας χρησιμοποιεί **Claims Authentication**, θα χρησιμοποιείτε πάντα Trusted Authentication ανεξαρτήτως της επιλογής σας εδώ. Εάν θέλετε να περάσετε διαπιστευτήρια Windows, θα πρέπει να επιλέξετε Windows Authentication. Για Trusted Authentication, θα μεταφέρουμε το token SPUser και δεν θα βασιστούμε στα διαπιστευτήρια Windows. 

Θα θέλετε επίσης να χρησιμοποιήσετε Trusted Authentication εάν έχετε ρυθμίσει τους ιστότοπους Classic Mode για NTLM και το RS είναι ρυθμισμένο για NTLM. Το Kerberos θα ήταν απαραίτητο για τη χρήση Windows Authentication και τη μεταφορά του για την πηγή δεδομένων σας. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Σχήμα 18**: Ρύθμιση διαπιστευτηρίων ενσωμάτωσης Reporting Services
## **Ενεργοποίηση λειτουργίας**
Αυτό σας δίνει τη δυνατότητα να ενεργοποιήσετε το Reporting Services σε όλες τις Συλλογές Τοποθεσιών ή να επιλέξετε ποιες θέλετε να το ενεργοποιήσετε. Αυτό ουσιαστικά σημαίνει ποιες τοποθεσίες θα μπορούν να χρησιμοποιούν το Reporting Services. 
Όταν ολοκληρωθεί, θα πρέπει να δείτε το παρακάτω σχήμα. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Σχήμα 19**: Επιτυχής Ενσωμάτωση του Reporting Services με το περιβάλλον SharePoint 

Επιστρέφοντας στη Διεύθυνση URL του Report Server όπως φαίνεται στο Σχήμα 14, θα πρέπει να δείτε κάτι παρόμοιο με το παρακάτω σχήμα. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Σχήμα 20**: Επιτυχής Επαλήθευση του Reporting Services με το περιβάλλον SharePoint 

{{% alert color="primary" %}} 

Εάν ο ιστότοπός σας SharePoint είναι ρυθμισμένος για SSL, δεν θα εμφανίζεται σε αυτή τη λίστα. Είναι γνωστό ζήτημα και δεν σημαίνει ότι υπάρχει πρόβλημα. Οι εκθέσεις σας πρέπει να λειτουργούν ακόμη. 

{{% /alert %}} 

Τώρα, είμαστε έτοιμοι να χρησιμοποιήσουμε το Reporting Services στο SharePoint 2010. Όπως στην προηγούμενη έκδοση, έχουμε μια λειτουργία (ενεργοποιείται όταν διαμορφώνουμε την ενσωμάτωση Reporting Services) στο “Site Collection Feature”. Επίσης η εγκατάσταση πρόσθεσε 3 τύπους περιεχομένου στο site μας. Στο Σχήμα 21 μπορούμε να δούμε 2 από αυτούς τους τύπους περιεχομένου που προστέθηκαν σε μια βιβλιοθήκη εγγράφων για τη δημιουργία προσαρμοσμένης έκθεσης, όπως φαίνεται στο Σχήμα 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Σχήμα 21**: Report Builder 

Το “**Reporter Builder**” είναι ένα ActiveX που πρέπει να κατεβάσουμε στον διακομιστή, όπως φαίνεται στο Σχήμα 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Σχήμα 22**: Λήψη και Εγκατάσταση του Report Builder 

Όταν ολοκληρωθεί η λήψη, εκτελέστε το **“Report Builder”**. Τώρα, είμαστε έτοιμοι να σχεδιάσουμε την πρώτη μας έκθεση, όπως φαίνεται στο Σχήμα 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Σχήμα 23**: Οδηγός Δημιουργίας Νέας Έκθεσης του Report Builder 

Αφού δημιουργήσουμε την έκθεσή μας, μπορούμε να την αποθηκεύσουμε στη βιβλιοθήκη εγγράφων που δημιουργήθηκε για να τοποθετήσουμε τις εκθέσεις στο SharePoint 2010. 

Ο άλλος τύπος περιεχομένου πρέπει να χρησιμοποιηθεί για τη δημιουργία κοινής σύνδεσης ως πηγή δεδομένων και να αποθηκευτεί σε μια βιβλιοθήκη εγγράφων στο SharePoint. Μπορούμε να δημιουργήσουμε μια βιβλιοθήκη εγγράφων, να προσθέσουμε αυτόν τον τύπο περιεχομένου και στη συνέχεια να έχουμε τις συνδέσεις διαθέσιμες για να αλλάξουμε την πηγή δεδομένων των εκθέσεων. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Σχήμα 24**: Επιτυχής εξαγωγή της έκθεσης στον Report Server