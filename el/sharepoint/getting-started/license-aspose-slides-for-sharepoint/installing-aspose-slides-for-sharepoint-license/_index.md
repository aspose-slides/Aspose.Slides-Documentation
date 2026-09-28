---
title: Εγκατάσταση της άδειας Aspose.Slides για SharePoint
type: docs
weight: 10
url: /el/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Εγκαταστήστε την άδεια Aspose.Slides για SharePoint σε ένα farm SharePoint: προσθέστε τη λύση άδειας στο κατάστημα λύσεων, αναπτύξτε τη και ελέγξτε ότι τα μετατρεπόμενα αρχεία δεν φέρουν πλέον υδατογράφημα αξιολόγησης."
---
{{% alert color="info" title="Note" %}}

Μόλις είστε ευχαριστημένοι με την αξιολόγησή σας, μπορείτε να [αγοράσετε μια άδεια](https://purchase.aspose.com/pricing/slides/sharepoint/). Πριν κάνετε την αγορά, βεβαιωθείτε ότι καταλαβαίνετε και συμφωνείτε με τους όρους συνδρομής της άδειας. Η άδεια αποστέλλεται σε εσάς μέσω email όταν η παραγγελία έχει πληρωθεί.

Η άδεια είναι ένα αρχείο ZIP που περιέχει ένα κανονικό πακέτο λύσης SharePoint. Το αρχείο περιέχει:

- Aspose.Slides.SharePoint.License.wsp – το αρχείο πακέτου λύσης SharePoint. Η άδεια συσκευάζεται ως λύση SharePoint για να διευκολύνει την ανάπτυξη και την ανάκληση σε ολόκληρο το farm διακομιστών.
- readme.txt – Οδηγίες εγκατάστασης της άδειας.

{{% /alert %}}

## **Ανάπτυξη της Άδειας**

Η εγκατάσταση της άδειας εκτελείται από την κονσόλα του διακομιστή μέσω του **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Οι διαδρομές παραλείπονται στην επόμενη ενότητα για σαφήνεια.

{{% /alert %}}

Εκτελέστε τα παρακάτω βήματα για την ανάπτυξη της άδειας Aspose.Slides για SharePoint:

1. Εκτελέστε το stsadm για να προσθέσετε τη λύση στο κατάστημα λύσεων του SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Αναπτύξτε τη λύση σε όλους τους διακομιστές του farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Εκτελέστε τις εργασίες χρονοδιακόπτη διαχείρισης για να ολοκληρώσετε αμέσως την ανάπτυξη:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Η ενέργεια `addsolution` δέχεται τη διαδρομή του αρχείου λύσης στο `-filename`; η ενέργεια `deploysolution` δέχεται το όνομα της λύσης που είναι ήδη στο κατάστημα λύσεων στο `-name`.

{{% alert color="info" title="Note" %}}

Λαμβάνετε μια προειδοποίηση κατά την εκτέλεση του βήματος ανάπτυξης εάν η υπηρεσία SharePoint Administration δεν εκτελείται. Το **stsadm.exe** εξαρτάται από αυτήν την υπηρεσία και από την υπηρεσία SharePoint Timer για την αντιγραφή των δεδομένων λύσης σε όλο το farm. Εάν αυτές οι υπηρεσίες δεν εκτελούνται στο farm των διακομιστών σας, ίσως χρειαστεί να εγκαταστήσετε την άδεια σε κάθε διακομιστή.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Στο SharePoint 2010 και μετά, οι cmdlet του SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` και `Start-SPAdminJob` αντιστοιχούν στις ενέργειες `addsolution`, `deploysolution` και `execadmsvcjobs`. Δείτε το [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Δοκιμή της Άδειας**

Για να ελέγξετε ότι η άδεια έχει εγκατασταθεί σωστά, μετατρέψτε οποιαδήποτε παρουσίαση σε νέο μορφότυπο. Εάν δεν υπάρχει υδατογράφημα αξιολόγησης στο μετατρεπόμενο αρχείο, η άδεια είναι ενεργή.