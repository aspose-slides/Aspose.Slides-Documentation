---
title: Εύκολη και Ελαφριά Ανάπτυξη
type: docs
weight: 50
url: /el/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Το Aspose.Slides for Reporting Services είναι μια [rendering extension](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) για το Microsoft SQL Server Reporting Services. 
Το Aspose.Slides for Reporting Services παρέχεται ως ένας μοναδικός εγκαταστάτης MSI που μπορεί να εγκατασταθεί σε υπολογιστές που λειτουργούν με μία από τις παρακάτω: 

- Microsoft SQL Server 2005 Reporting Services (32-bit και 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit και 64-bit)

Είναι επίσης εύκολο να αναπτυχθεί και να διαχειριστεί το Aspose.Slides for Reporting Services χειροκίνητα, καθώς αποτελείται μόνο από μία .NET συναρμολόγηση *Aspose.Slides* *.ReportingServices.dll* , γραμμένη πλήρως σε C#, συμβατή με το CLS και που περιέχει μόνο ασφαλή διαχειριζόμενο κώδικα. 

{{% /alert %}} 

Ο εγκαταστάτης MSI και η λήψη ZIP περιλαμβάνουν το Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – δημιουργημένο για Microsoft SQL Server 2005 και .NET Framework 2.0 (χρησιμοποιήστε για x86 και x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – δημιουργημένο για Microsoft SQL Server 2008 και .NET Framework 2.0 (χρησιμοποιήστε για x86 και x64)

Κατά την εγκατάσταση, το Aspose.Slides.ReportingServices.dll αντιγράφεται στον φάκελο ReportServer\bin και το αρχείο ρυθμίσεων ενημερώνεται ώστε το Reporting Services να είναι ενήμερο για τη νέα επέκταση απόδοσης. Αυτά τα βήματα εκτελείται από τον εγκαταστάτη Aspose.Slides for Reporting Services, αλλά μπορείτε επίσης να τα εκτελέσετε χειροκίνητα όπως περιγράφεται παρακάτω σε αυτό το εγχειρίδιο. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Σχήμα**: Το Aspose.Slides.ReportingServices.dll αντιγράφεται στον φάκελο **ReportServer\bin**.