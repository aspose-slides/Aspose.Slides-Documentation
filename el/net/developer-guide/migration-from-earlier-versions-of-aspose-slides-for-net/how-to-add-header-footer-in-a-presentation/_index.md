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
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint PPT, PPTX και ODP στο .NET χρησιμοποιώντας τόσο την κληρονομική όσο και τη σύγχρονη API του Aspose.Slides."
---
{{% alert color="primary" %}} 

Ένα νέο [Aspose.Slides for .NET API](/slides/el/net/) έχει κυκλοφορήσει και τώρα αυτό το μοναδικό προϊόν υποστηρίζει τη δυνατότητα δημιουργίας εγγράφων PowerPoint από το μηδέν και την επεξεργασία των υπάρχοντων.

{{% /alert %}} 
## **Υποστήριξη παλαιού κώδικα**
Για να χρησιμοποιήσετε τον κώδικα κληρονομιάς που αναπτύχθηκε με εκδόσεις του Aspose.Slides για .NET παλαιότερες από την 13.x, πρέπει να κάνετε ορισμένες μικρές αλλαγές στον κώδικά σας και ο κώδικας θα λειτουργεί όπως πριν. Όλες οι κλάσεις που υπήρχαν στην παλαιά έκδοση του Aspose.Slides για .NET στους χώρους ονομάτων Aspose.Slide και Aspose.Slides.Pptx έχουν πλέον ενωθεί σε έναν ενιαίο χώρο ονομάτων Aspose.Slides. Παρακαλούμε ρίξτε μια ματιά στο παρακάτω απλό απόσπασμα κώδικα για την προσθήκη κεφαλίδας/υποσέλιδου στην παρουσίαση στην κλασική Aspose.Slides API και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στο νέο ενοποιημένο API.
## **Παλιά προσέγγιση Aspose.Slides για .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Δημιουργία της παρουσίασης
Presentation pres = new Presentation();

//Λήψη της πρώτης διαφάνειας
Slide sld = pres.GetSlideByPosition(1);

//Πρόσβαση στην Κεφαλίδα / Υποσέλιδο της διαφάνειας
HeaderFooter hf = sld.HeaderFooter;

//Ορισμός ορατότητας αριθμού σελίδας
hf.PageNumberVisible = true;

//Ορισμός ορατότητας υποσέλιδου
hf.FooterVisible = true;

//Ορισμός ορατότητας κεφαλίδας
hf.HeaderVisible = true;

//Ορισμός ορατότητας ημερομηνίας/ώρας
hf.DateTimeVisible = true;

//Ορισμός μορφής ημερομηνίας/ώρας
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Ορισμός κειμένου κεφαλίδας
hf.HeaderText = "Header Text";

//Ορισμός κειμένου υποσέλιδου
hf.FooterText = "Footer Text";

//Αποθήκευση της παρουσίασης στο δίσκο
pres.Write("HeadFoot.ppt");
```



## **Νέα προσέγγιση Aspose.Slides για .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Ορισμός ιδιοτήτων ορατότητας Κεφαλίδα & Υποσέλιδο
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Ενημέρωση πεδίων Ημερομηνίας/Ώρας
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Εμφάνιση υπόδειξης ημερομηνίας/ώρας
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Εμφάνιση υποσέλιδου
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ορισμός ορατότητας κεφαλίδα & υποσέλιδο στη διαφάνεια τίτλου
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Αποθήκευση της παρουσίασης στο δίσκο
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```