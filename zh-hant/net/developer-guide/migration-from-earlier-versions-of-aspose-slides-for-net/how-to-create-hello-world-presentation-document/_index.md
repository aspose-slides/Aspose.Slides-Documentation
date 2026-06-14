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
- description: "使用 Aspose.Slides 在 .NET 中建立 Hello World PowerPoint PPT、PPTX 與 ODP 簡報，並透過舊版與現代 API 完成的簡易指南。"
---
{{% alert color="primary" %}}
全新推出了 [Aspose.Slides for .NET API](/slides/zh-hant/net/)，現在此單一產品支援從頭建立 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}}
## **支援舊版程式碼**
為了使用在 Aspose.Slides for .NET 13.x 之前版本開發的舊版程式碼，您需要對程式碼做少量修改，之後程式碼即可如同先前般運作。舊版 Aspose.Slides for .NET 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別，現已合併至單一的 Aspose.Slides 命名空間。請參考以下簡單的程式碼片段，以在舊版 Aspose.Slides API 中建立 Hello World 簡報文件，並依照說明步驟將其遷移至新的合併 API。
## **舊版 Aspose.Slides for .NET 方法**
```c#
//實例化表示 PPT 檔案的 Presentation 物件
Presentation pres = new Presentation();

//建立 License 物件
License license = new License();

//設定 Aspose.Slides for .NET 的授權，以避免評估限制
license.SetLicense("Aspose.Slides.lic");

//在簡報中新增一個空白投影片並取得其參考
//該空白投影片
Slide slide = pres.AddEmptySlide();

//在投影片上加入矩形 (X=2400, Y=1800, Width=1000 & Height=500) 到投影片
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隱藏矩形的線條
rect.LineFormat.ShowLines = false;

//在矩形中加入文字框，預設文字為 "Hello World"
rect.AddTextFrame("Hello World");

//移除簡報的第一張投影片，該投影片通常是由
//Aspose.Slides for .NET 在建立簡報時預設加入的
pres.Slides.RemoveAt(0);

//將簡報寫入為 PPT 檔案
pres.Write("C:\\hello.ppt");
```



## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
// 實例化簡報
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide sld = (ISlide)pres.Slides[0];

// 新增矩形類型的 AutoShape
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 為矩形新增 ITextFrame
ashp.AddTextFrame("Hello World");

// 將文字顏色變更為黑色（預設為白色）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 將矩形的線條顏色變更為白色
ashp.ShapeStyle.LineColor.Color = Color.White;

// 移除圖形的所有填充格式
ashp.FillFormat.FillType = FillType.NoFill;

// 將簡報儲存至磁碟
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```