---
title: Πώς να Προσθέσετε Κεφαλίδες & Υποσέλιδα σε Παρουσιάσεις στο .NET
linktitle: Προσθήκη Κεφαλίδας & Υποσέλιδου
type: docs
weight: 20
url: /el/net/how-to-add-header-footer-in-a-presentation/
keywords:
- μεταφορά
- προσθήκη κεφαλίδας
- προσθήκη υποσέλιδου
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint PPT, PPTX και ODP στο .NET χρησιμοποιώντας τόσο τη κληρονομική όσο και τη σύγχρονη API του Aspose.Slides."
---
{{% alert color="info" %}}

Ένα νέο [Aspose.Slides for .NET API](/slides/el/net/) έχει κυκλοφορήσει και τώρα αυτό το ενιαίο προϊόν υποστηρίζει τη δυνατότητα δημιουργίας εγγράφων PowerPoint από το μηδέν και επεξεργασίας των υπαρχόντων.

{{% /alert %}}
## **Υποστήριξη Κώδικα Κληρονομίας**
Για να χρησιμοποιήσετε τον κώδικα κληρονομίας που αναπτύχθηκε με εκδόσεις του Aspose.Slides για .NET παλαιότερες από την 13.x, πρέπει να κάνετε μερικές μικρές αλλαγές στον κώδικά σας ώστε να λειτουργεί όπως παλιότερα. Όλες οι κλάσεις που ήταν παρούσες στην παλιά έκδοση του Aspose.Slides για .NET στα namespaces Aspose.Slide και Aspose.Slides.Pptx έχουν συγχωνευθεί πλέον σε ένα ενιαίο namespace Aspose.Slides. Παρακαλούμε ρίξτε μια ματιά στο παρακάτω απλό απόσπασμα κώδικα για την προσθήκη κεφαλίδας/υποσέλιδου στην παρουσίαση στην κληρονομική API του Aspose.Slides και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στη νέα συγχωνευμένη API.
## **Προσέγγιση Κληρονομικού Aspose.Slides για .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Ορισμός ιδιοτήτων ορατότητας κεφαλίδας & υποσέλιδου
sourcePres.UpdateSlideNumberFields = true;

//Ενημέρωση πεδίων ημερομηνίας & ώρας
sourcePres.UpdateDateTimeFields = true;

//Εμφάνιση δείκτη κράτησης θέσης ημερομηνίας & ώρας
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Εμφάνιση δείκτη κράτησης θέσης υποσέλιδου
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Εμφάνιση αριθμού διαφάνειας
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Ορισμός  ορατότητας κεφαλίδας & υποσέλιδου στη διαφάνεια τίτλου
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Γράψτε την παρουσίαση στο δίσκο
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Δημιουργία της παρουσίασης
Presentation pres = new Presentation();

//Λήψη της πρώτης διαφάνειας
Slide sld = pres.GetSlideByPosition(1);

//Πρόσβαση στην κεφαλίδα / υποσέλιδο της διαφάνειας
HeaderFooter hf = sld.HeaderFooter;

//Ορισμός ορατότητας αριθμού σελίδας
hf.PageNumberVisible = true;

//Ορισμός ορατότητας υποσέλιδου
hf.FooterVisible = true;

//Ορισμός ορατότητας κεφαλίδας
hf.HeaderVisible = true;

//Ορισμός ορατότητας ημερομηνίας & ώρας
hf.DateTimeVisible = true;

//Ορισμός μορφής ημερομηνίας & ώρας
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Ορισμός κειμένου κεφαλίδας
hf.HeaderText = "Header Text";

//Ορισμός κειμένου υποσέλιδου
hf.FooterText = "Footer Text";

//Εγγραφή της παρουσίασης στο δίσκο
pres.Write("HeadFoot.ppt");
```



## **Νέα Προσέγγιση Aspose.Slides για .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Ορισμός ιδιοτήτων ορατότητας κεφαλίδας & υποσέλιδου
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Ενημέρωση πεδίων ημερομηνίας & ώρας
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Εμφάνιση δείκτη κράτησης θέσης ημερομηνίας & ώρας
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Εμφάνιση δείκτη κράτησης θέσης υποσέλιδου
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ορισμός  ορατότητας κεφαλίδας & υποσέλιδου στη διαφάνεια τίτλου
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Γράψτε την παρουσίαση στο δίσκο
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```