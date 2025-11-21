---
title: Ole对象
type: docs
weight: 210
url: /zh/net/examples/elements/ole-object/
keywords:
- OLE 对象示例
- 添加 OLE 对象
- 访问 OLE 对象
- 删除 OLE 对象
- 更新 OLE 对象
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理 OLE 对象：插入或更新嵌入的文件，设置图标或链接，提取内容，控制 PPT、PPTX 和 ODP 的行为。"
---

演示如何将文件嵌入为 OLE 对象并使用 **Aspose.Slides for .NET** 更新其数据。

## Add an OLE Object
将 PDF 文件嵌入到演示文稿中。
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## Access an OLE Object
检索幻灯片上的第一个 OLE 对象框架。
```csharp
static void Access_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOle = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```


## Remove an OLE Object
删除幻灯片中嵌入的 OLE 对象。
```csharp
static void Remove_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(ole);
}
```


## Update OLE Object Data
替换已存在 OLE 对象中嵌入的数据。
```csharp
static void Update_Ole_Object_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    ole.SetEmbeddedData(newData);
}
```
