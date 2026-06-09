---
title: "Δημόσιο API και Αλλαγές που δεν είναι συμβατές με παλαιότερες εκδόσεις στο Aspose.Slides για .NET 15.7.0"
linktitle: "Aspose.Slides για .NET 15.7.0"
type: docs
weight: 180
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- μεταφορά
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακόπτουν τη λειτουργία στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [added](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ή [removed](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Η Enum ImagePixelFormat Προστέθηκε**
Η Enum Aspose.Slides.Export.ImagePixelFormat προστέθηκε για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες.
#### **Η Μέθοδος IChartDataPoint.GetAutomaticDataPointColor() Προστέθηκε**
Επιστρέφει ένα αυτόματο χρώμα σημείου δεδομένων βάσει του δείκτη σειράς, δείκτη σημείου δεδομένων, ParentSeriesGroup, της ιδιότητας IsColorVaried και του στυλ διαγράμματος.
Αυτό το χρώμα χρησιμοποιείται ως προεπιλογή εάν το FillType ισούται με NotDefined.
#### **Η Μέθοδος RenderToGraphics Προστέθηκε στο Slide**
Η Μέθοδος RenderToGraphics (και οι υπερφορτώσεις της) προστέθηκε στην Aspose.Slides.Slide για την απόδοση μιας διαφάνειας σε αντικείμενο Graphics.
#### **Η Ιδιότητα PixelFormat Προστέθηκε στα ITiffOptions και TiffOptions**
Η Ιδιότητα PixelFormat προστέθηκε στην Aspose.Slides.Export.ITiffOptions και στην Aspose.Slides.Export.TiffOptions για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες TIFF.