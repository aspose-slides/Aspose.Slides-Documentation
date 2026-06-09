---
title: OLE Nesnesi
type: docs
weight: 210
url: /tr/net/examples/elements/ole-object/
keywords:
- OLE nesnesi
- OLE nesnesi ekle
- OLE nesnesine eriş
- OLE nesnesini kaldır
- OLE nesnesini güncelle
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te OLE nesnelerini yönetin: C# ile PPT, PPTX ve ODP sunumlarında gömülü içeriği ekleyin, bağlayın, güncelleyin ve çıkarın."
---
Bu makale, bir dosyayı OLE nesnesi olarak gömmeyi ve **Aspose.Slides for .NET** kullanarak verilerini güncellemeyi göstermektedir.

## **OLE Nesnesi Ekle**
Bir PDF dosyasını sunuma göm.

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

## **OLE Nesnesine Erişim**
Bir slayttaki ilk OLE nesne çerçevesini alın.

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

## **OLE Nesnesini Kaldır**
Gömülü OLE nesnesini slayttan sil.

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

## **OLE Nesnesi Verilerini Güncelle**
Mevcut bir OLE nesnesine gömülmüş verileri değiştir.

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