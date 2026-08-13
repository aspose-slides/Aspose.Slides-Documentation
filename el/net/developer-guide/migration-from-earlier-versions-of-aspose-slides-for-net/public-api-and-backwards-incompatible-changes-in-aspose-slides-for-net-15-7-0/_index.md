---
title: Δημόσιο API και Μη Συμβατές Πίσω Αλλαγές στο Aspose.Slides για .NET 15.7.0
linktitle: Aspose.Slides για .NET 15.7.0
type: docs
weight: 180
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- μετάβαση
- παραδοσιακό κώδικα
- σύγχρονο κώδικα
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κρίσιμων αλλαγών στο Aspose.Slides για .NET, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα εμφανίζει όλες τις προστιθέμενες ή αφαιρεθείσες κλάσεις, μεθόδους, ιδιότητες κλπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **Αλλαγές Δημοσίου API**
#### **Enum ImagePixelFormat Προστέθηκε**
Η Enum Aspose.Slides.Export.ImagePixelFormat προστέθηκε για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες.
#### **Μέθοδος IChartDataPoint.GetAutomaticDataPointColor() Προστέθηκε**
Επιστρέφει ένα αυτόματο χρώμα του σημείου δεδομένων με βάση το δείκτη σειράς, το δείκτη σημείου δεδομένων, το ParentSeriesGroup, την ιδιότητα IsColorVaried και το στυλ διαγράμματος.
Αυτό το χρώμα χρησιμοποιείται εξ ορισμού εάν το FillType ισούται με NotDefined.
#### **Μέθοδος RenderToGraphics Προστέθηκε στην Slide**
Η μέθοδος RenderToGraphics (και οι υπερφορτώσεις της) προστέθηκε στην Aspose.Slides.Slide για την απόδοση μιας διαφάνειας σε αντικείμενο Graphics.
#### **Ιδιότητα PixelFormat Προστέθηκε στο ITiffOptions και στο TiffOptions**
Η ιδιότητα PixelFormat προστέθηκε στην Aspose.Slides.Export.ITiffOptions και στην Aspose.Slides.Export.TiffOptions για τον καθορισμό της μορφής pixel για τις παραγόμενες εικόνες TIFF.