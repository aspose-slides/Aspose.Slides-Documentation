---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές στο Aspose.Slides για Java 15.7.0
linktitle: Aspose.Slides για Java 15.7.0
type: docs
weight: 150
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- μετάβαση
- παρωχημένος κώδικας
- σύγχρονος κώδικας
- παρωχημένη προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των ασυμβίβαστων αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλα τα [προστέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ή [αφαιρεμένα](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for Java 15.7.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Το Enum com.aspose.slides.ImagePixelFormat προστέθηκε**
Το Enum com.aspose.slides.ImagePixelFormat προστέθηκε για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες.
#### **Η μέθοδος com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() προστέθηκε**
Αυτή η μέθοδος επιστρέφει ένα αυτόματο χρώμα σημείου δεδομένων βάσει του δείκτη σειράς, του δείκτη σημείου δεδομένων, του parentSeriesGroup, των τιμών isColorVaried και του στυλ γραφήματος. Αυτό το χρώμα χρησιμοποιείται εξ ορισμού εάν το fillType ισούται με NotDefined.
#### **Οι μέθοδοι getPixelFormat(), setPixelFormat(int) προστέθηκαν στο com.aspose.slides.ITiffOptions**
Οι μέθοδοι getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) προστέθηκαν στα com.aspose.slides.ITiffOptions και com.aspose.slides.TiffOptions για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες TIFF.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```