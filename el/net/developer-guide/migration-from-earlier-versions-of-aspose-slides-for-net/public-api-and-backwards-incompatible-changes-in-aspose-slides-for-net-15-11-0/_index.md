---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές στην Aspose.Slides για .NET 15.11.0
linktitle: Aspose.Slides για .NET 15.11.0
type: docs
weight: 210
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξετάστε τις ενημερώσεις του δημόσιου API και τις διασπαστικές αλλαγές στην Aspose.Slides για .NET ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα παραθέτει όλα τα [added](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) ή [removed](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.11.0 API.
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

#### **Η νέα ιδιότητα FirstSlideNumber έχει προστεθεί στην κλάση Presentation**
Η νέα ιδιότητα FirstSlideNumber που προστέθηκε στην Presentation επιτρέπει την ανάκτηση ή τον ορισμό του αριθμού της πρώτης διαφάνειας σε μια παρουσίαση.

Όταν οριστεί μια νέα τιμή για το FirstSlideNumber, όλοι οι αριθμοί των διαφανειών επανυπολογίζονται.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```