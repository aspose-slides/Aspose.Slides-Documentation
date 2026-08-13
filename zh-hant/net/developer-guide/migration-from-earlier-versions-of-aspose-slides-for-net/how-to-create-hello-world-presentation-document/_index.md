---
title: 如何在 .NET 中建立 Hello World 簡報
linktitle: Hello World 簡報
type: docs
weight: 10
url: /zh-hant/net/how-to-create-hello-world-presentation-document/
keywords:
- 遷移
- Hello World
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
- description: "在 .NET 中使用 Aspose.Slides，透過舊版與新版 API，以簡單指南一次建立 Hello World PowerPoint PPT、PPTX 與 ODP 簡報。"
---
{{% alert color="info" %}} 
一個全新的 [Aspose.Slides for .NET API](/slides/zh-hant/net/) 已發布，現在此單一產品支援從頭產生 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}} 
## **支援舊版程式碼**
為了使用在 13.x 之前的 Aspose.Slides for .NET 版本所開發的舊版程式碼，您需要對程式碼做少量變更，程式碼即可如往常般運作。舊版 Aspose.Slides for .NET 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別現在已合併至單一的 Aspose.Slides 命名空間。請參閱以下簡單程式碼片段，了解如何在舊版 Aspose.Slides API 中建立 Hello World 簡報文件，並依照說明步驟遷移至新合併的 API。
## **舊版 Aspose.Slides for .NET 方法**
```c#
using System.Drawing;
using Aspose.Slides;

//實例化一個代表 PPT 檔案的 Presentation 物件
Presentation pres = new Presentation();

//建立 License 物件
License license = new License();

//設定 Aspose.Slides for .NET 的授權，以避免評估限制
license.SetLicense("Aspose.Slides.lic");

//向簡報加入空白投影片，並取得其參考
//該空白投影片
Slide slide = pres.AddEmptySlide();

//在投影片上加入一個矩形 (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隱藏矩形的線條
rect.LineFormat.ShowLines = false;

//在矩形上加入文字框，預設文字為 "Hello World"
rect.AddTextFrame("Hello World");

//移除簡報的第一張投影片，該投影片是由
//Aspose.Slides for .NET 在建立簡報時預設加入的
pres.Slides.RemoveAt(0);

//將簡報寫入為 PPT 檔案
pres.Write("C:\\hello.ppt");
```



## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```