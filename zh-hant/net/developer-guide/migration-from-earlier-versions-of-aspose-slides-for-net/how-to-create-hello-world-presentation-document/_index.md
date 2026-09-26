---
title: 如何在 .NET 中建立 Hello World 簡報
linktitle: Hello World 簡報
type: docs
weight: 10
url: /zh-hant/net/how-to-create-hello-world-presentation-document/
keywords:
- 移植
- hello world
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
description: "在 .NET 中使用 Aspose.Slides，透過舊版與現代 API，一步驟建立 Hello World PowerPoint PPT、PPTX 與 ODP 簡報的簡易指南。"
---
{{% alert color="info" %}} 
已發布全新的 [Aspose.Slides for .NET API](/slides/zh-hant/net/)，現在此單一產品支援從頭建立 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}} 
## **支援舊版程式碼**
為了使用在 Aspose.Slides for .NET 13.x 之前版本開發的舊版程式碼，您需要對程式碼做少量修改，即可如同以前般正常運作。舊版 Aspose.Slides for .NET 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別，現在已合併至單一的 Aspose.Slides 命名空間。請檢視以下簡單程式碼片段，了解如何在舊版 Aspose.Slides API 中建立 Hello World 簡報文件，並依照說明步驟遷移至新的合併 API。
## **舊版 Aspose.Slides for .NET 方法**
```c#
using System.Drawing;
using Aspose.Slides;

//實例化代表 PPT 檔案的 Presentation 物件
Presentation pres = new Presentation();

//建立 License 物件
License license = new License();

//設定 Aspose.Slides for .NET 的授權以避免評估限制
license.SetLicense("Aspose.Slides.lic");

//向簡報新增空白投影片並取得其參考
//該空白投影片
Slide slide = pres.AddEmptySlide();

//在投影片上加入矩形 (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隱藏矩形的線條
rect.LineFormat.ShowLines = false;

//在矩形內加入文字框，預設文字為 "Hello World"
rect.AddTextFrame("Hello World");

//移除簡報的第一張投影片，該投影片總是由
//Aspose.Slides for .NET 在建立簡報時預設加入
pres.Slides.RemoveAt(0);

//將簡報寫入為 PPT 檔案
pres.Write("C:\\hello.ppt");
```

## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide sld = (ISlide)pres.Slides[0];

// 新增矩形類型的 AutoShape
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 向矩形新增 ITextFrame
ashp.AddTextFrame("Hello World");

// 將文字顏色更改為黑色（預設為白色）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 將矩形的線條顏色更改為白色
ashp.ShapeStyle.LineColor.Color = Color.White;

// 移除圖形的任何填滿格式
ashp.FillFormat.FillType = FillType.NoFill;

// 將簡報儲存至磁碟
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```