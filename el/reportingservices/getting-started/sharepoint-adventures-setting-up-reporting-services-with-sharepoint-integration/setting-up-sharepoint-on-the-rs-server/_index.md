---
title: Ρύθμιση του SharePoint στον RS Server
type: docs
weight: 40
url: /el/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Έτσι, πρέπει να κάνουμε αυτό που κάναμε για το SharePoint WFE. Πρώτο βήμα είναι η ολοκλήρωση της εγκατάστασης των προαπαιτήσεων και στη συνέχεια η εκκίνηση της εγκατάστασης του SharePoint. 

Για την εγκατάσταση, επιλέγουμε Server Farm και πλήρη εγκατάσταση ώστε να ταιριάζει με το SharePoint Box μου, καθώς δεν θέλουμε μια αυτόνομη εγκατάσταση για το SharePoint. 

{{% /alert %}} 
### **Διαμόρφωση SharePoint**
Στον Μάγο Διαμόρφωσης SharePoint, θέλουμε να συνδεθούμε σε υπάρχουσα φάρμα. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Σχήμα 13**: Μάγος Διαμόρφωσης SharePoint 

Κατόπιν θα το κατευθύνουμε στη βάση δεδομένων **SharePoint_Config** που χρησιμοποιεί η φάρμα μας. Αν δεν ξέρετε πού βρίσκεται, μπορείτε να το μάθετε μέσω του Central Admin στην ενότητα **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Σχήμα 14**: Μάγος Διαμόρφωσης SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Σχήμα 15**: Μάγος Διαμόρφωσης SharePoint 

Μόλις ολοκληρωθεί ο μάγος, αυτό είναι ό,τι χρειάζεται να κάνουμε στο Report Server Box προς το παρόν. Επιστρέφοντας στη διεύθυνση URL του ReportServer, θα δούμε άλλο σφάλμα, αλλά αυτό συμβαίνει επειδή δεν το έχουμε ρυθμίσει μέσω του Central Administrator. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Σχήμα 16**: Σφάλμα Report Server