---
title: Obiekt OLE
type: docs
weight: 210
url: /pl/net/examples/elements/ole-object/
keywords:
- Obiekt OLE
- dodaj obiekt OLE
- uzyskaj dostęp do obiektu OLE
- usuń obiekt OLE
- zaktualizuj obiekt OLE
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Obsługuj obiekty OLE w Aspose.Slides dla .NET: wstawiaj, linkuj, aktualizuj i wyodrębniaj osadzoną zawartość przy użyciu C# w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł demonstruje osadzanie pliku jako obiektu OLE oraz aktualizowanie jego danych przy użyciu **Aspose.Slides for .NET**.

## **Dodaj obiekt OLE**

Osadź plik PDF w prezentacji.

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

## **Uzyskaj dostęp do obiektu OLE**

Pobierz pierwszą ramkę obiektu OLE na slajdzie.

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

## **Usuń obiekt OLE**

Usuń osadzony obiekt OLE ze slajdu.

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

## **Zaktualizuj dane obiektu OLE**

Zastąp dane osadzone w istniejącym obiekcie OLE.

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