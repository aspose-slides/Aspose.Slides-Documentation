---
title: Δημόσιο API και Αλλαγές που Δεν Συμβαδίζουν με Παλαιότερες Εκδόσεις στο Aspose.Slides για Java 15.7.0
linktitle: Aspose.Slides για Java 15.7.0
type: docs
weight: 150
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγχιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σπαστικών αλλαγών στο Aspose.Slides για Java, ώστε να μετεγκαταστήσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλα τα [προστέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ή [αφαιρέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) κλάσεις, μεθόδους, ιδιότητες κτλ, καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **Αλλαγές δημόσιου API**
#### **Το enum com.aspose.slides.ImagePixelFormat προστέθηκε**
Το enum com.aspose.slides.ImagePixelFormat προστέθηκε για τον καθορισμό του μορφότυπου εικονοστοιχείου για τις παραγόμενες εικόνες.
#### **Η μέθοδος com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() προστέθηκε**
Αυτή η μέθοδος επιστρέφει ένα αυτόματο χρώμα του σημείου δεδομένων με βάση το δείκτη σειράς, το δείκτη του σημείου δεδομένων, το parentSeriesGroup, τις τιμές isColorVaried και το στυλ διαγράμματος. Το χρώμα αυτό χρησιμοποιείται από προεπιλογή εάν το fillType ισούται με NotDefined.
#### **Οι μέθοδοι getPixelFormat(), setPixelFormat(int) προστέθηκαν στο com.aspose.slides.ITiffOptions**
Οι μέθοδοι getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) προστέθηκαν στο com.aspose.slides.ITiffOptions και στο com.aspose.slides.TiffOptions για τον καθορισμό του μορφότυπου εικονοστοιχείου για τις παραγόμενες εικόνες TIFF.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```