---
title: Εύκολη και Ελαφριά Ανάπτυξη
type: docs
weight: 50
url: /el/reportingservices/easy-and-lightweight-deployment/
description: "Μάθετε πώς γίνεται η ανάπτυξη του Aspose.Slides για Reporting Services: μια συναρμολόγηση στον φάκελο bin του διακομιστή αναφορών, καταχωρημένη στη διαμόρφωση του διακομιστή αναφορών."
---
{{% alert color="info" title="Σημείωση" %}}

Aspose.Slides for Reporting Services είναι μια [επέκταση απόδοσης](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) για το Microsoft SQL Server Reporting Services και το Power BI Report Server.
Το Aspose.Slides for Reporting Services παρέχεται ως ένας ενιαίος εγκαταστάτης MSI που μπορεί να εγκατασταθεί σε υπολογιστές που εκτελούν έναν υποστηριζόμενο διακομιστή αναφορών, 32‑bit ή 64‑bit· δείτε [Απαιτήσεις Συστήματος](/slides/el/reportingservices/system-requirements/).

Είναι επίσης εύκολο να αναπτυχθεί και να διαχειριστεί το Aspose.Slides for Reporting Services χειροκίνητα, καθώς αποτελείται μόνο από μία .NET συναρμολόγηση *Aspose.Slides* *.ReportingServices.dll* , γραμμένη εξ ολοκλήρου σε C#, σύμφωνη με το CLS και περιέχει μόνο ασφαλή διαχειριζόμενη κώδικα.

{{% /alert %}}

Η λήψη ZIP περιλαμβάνει δύο εκδόσεις του Aspose.Slides.ReportingServices.dll για διακομιστές αναφορών:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – δημιουργήθηκε για το Microsoft SQL Server 2005 και .NET Framework 2.0 (χρησιμοποιείται για x86 και x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – δημιουργήθηκε για το Microsoft SQL Server 2008 και μεταγενέστερες εκδόσεις, Power BI Report Server και .NET Framework 2.0 (χρησιμοποιείται για x86 και x64)

Ο εγκαταστάτης MSI εγκαθιστά τις ίδιες δύο εκδόσεις και επιλέγει τη σωστή για κάθε παράδειγμα διακομιστή αναφορών. [Εγκατάσταση Χειροκίνητη](/slides/el/reportingservices/install-manually/) παραθέτει κάθε αρχείο στη λήψη ZIP.

Κατά την εγκατάσταση, το Aspose.Slides.ReportingServices.dll αντιγράφεται στον φάκελο ReportServer\bin και το αρχείο ρυθμίσεων ενημερώνεται ώστε το Reporting Services να γνωρίζει τη νέα επέκταση απόδοσης. Αυτά τα βήματα εκτελείται από τον εγκαταστάτη Aspose.Slides for Reporting Services, αλλά μπορείτε επίσης να τα εκτελέσετε χειροκίνητα όπως περιγράφεται παρακάτω σε αυτήν την τεκμηρίωση.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Σχήμα**: Το Aspose.Slides.ReportingServices.dll αντιγράφεται στον **ReportServer\bin** φάκελο.