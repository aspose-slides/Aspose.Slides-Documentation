---
title: Δημόσιο API και Ασυμβατές Αλλαγές Πίσω Συμβατότητας στο Aspose.Slides για .NET 15.11.0
linktitle: Aspose.Slides για .NET 15.11.0
type: docs
weight: 210
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- μεταφορά
- πρωτόγονος κώδικας
- σύγχρονος κώδικας
- πρωτόγονη προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των καταστροφικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλα τα [προστέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **Δημόσιες Αλλαγές API**

#### **Οι παρωχημένες ιδιότητες στην κλάση DataLabelCollection έχουν διαγραφεί**
Οι παρωχημένες ιδιότητες στην κλάση DataLabelCollection έχουν διαγραφεί:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Η νέα ιδιότητα FirstSlideNumber προστέθηκε στην κλάση Presentation**
Η νέα ιδιότητα FirstSlideNumber που προστέθηκε στην Presentation επιτρέπει την ανάκτηση ή ορισμό του αριθμού της πρώτης διαφάνειας σε μια παρουσίαση.

Όταν οριστεί μια νέα τιμή για το FirstSlideNumber, όλοι οι αριθμοί των διαφανειών επαναϋπολογίζονται.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```