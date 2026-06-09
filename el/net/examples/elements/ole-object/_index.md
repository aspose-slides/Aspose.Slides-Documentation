---
title: Αντικείμενο OLE
type: docs
weight: 210
url: /el/net/examples/elements/ole-object/
keywords:
  - αντικείμενο OLE
  - προσθήκη αντικειμένου OLE
  - πρόσβαση σε αντικείμενο OLE
  - αφαίρεση αντικειμένου OLE
  - ενημέρωση αντικειμένου OLE
  - παράδειγμα κώδικα
  - PowerPoint
  - OpenDocument
  - παρουσίαση
  - .NET
  - C#
  - Aspose.Slides
description: "Διαχείριση αντικειμένων OLE στο Aspose.Slides για .NET: εισαγωγή, σύνδεση, ενημέρωση και εξαγωγή ενσωματωμένου περιεχομένου με C# σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο επιδεικνύει την ενσωμάτωση ενός αρχείου ως αντικείμενο OLE και την ενημέρωση των δεδομένων του χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF στην παρουσίαση.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Αφαίρεση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που έχουν ενσωματωθεί σε ένα υπάρχον αντικείμενο OLE.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```