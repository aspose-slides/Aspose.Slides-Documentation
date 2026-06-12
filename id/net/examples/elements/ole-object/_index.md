---
title: Objek OLE
type: docs
weight: 210
url: /id/net/examples/elements/ole-object/
keywords:
- objek OLE
- menambah objek OLE
- akses objek OLE
- menghapus objek OLE
- memperbarui objek OLE
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola objek OLE di Aspose.Slides for .NET: sisipkan, tautkan, perbarui, dan ekstrak konten tersemat dengan C# dalam presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyematkan file sebagai objek OLE dan memperbarui datanya menggunakan **Aspose.Slides for .NET**.

## **Tambah OLE Object**

Menyematkan file PDF ke dalam presentasi.

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

## **Akses OLE Object**

Mengambil frame objek OLE pertama pada slide.

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

## **Hapus OLE Object**

Menghapus objek OLE yang disematkan dari slide.

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

## **Perbarui Data OLE Object**

Mengganti data yang disematkan dalam objek OLE yang ada.

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