---
title: 在 .NET 中管理簡報縮放
linktitle: 管理縮放
type: docs
weight: 60
url: /zh-hant/net/manage-zoom/
keywords:
- 縮放
- 縮放框格
- 投影片縮放
- 章節縮放
- 摘要縮放
- 新增縮放
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 建立與自訂縮放 — 在章節之間跳轉，為 PPT、PPTX 和 ODP 簡報新增縮圖與過場效果。"
---
## **簡介**

PowerPoint 中的縮放功能讓您可以在簡報的特定投影片、章節和區段之間跳轉。當您在演示時，這種快速導覽內容的能力可能非常有用。

![overview_image](overview.png)

* 若要在單一投影片上概述整個簡報，請使用[Summary Zoom](#Summary-Zoom)。
* 若只想顯示選取的投影片，請使用[Slide Zoom](#Slide-Zoom)。
* 若只想顯示單一章節，請使用[Section Zoom](#Section-Zoom)。

## **Slide Zoom**
Slide Zoom 能讓您的簡報更加動態，讓您可以自由在任意順序的投影片之間導覽，而不會中斷簡報的流程。Slide Zoom 非常適合章節不多的簡短簡報，但在其他簡報情境中仍可使用。

Slide Zoom 協助您在單一畫布上深入多筆資訊。

![overview_image](slidezoomsel.png)

對於 Slide Zoom 物件，Aspose.Slides 提供 [ZoomImageType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/zoomimagetype) 列舉、[IZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/izoomframe) 介面，以及 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面下的若干方法。

### **建立縮放框格**

您可以這樣在投影片上加入縮放框格：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立您打算連結縮放框格的新增投影片。
3. 為建立的投影片加入辨識文字與背景。
4. 在第一張投影片加入縮放框格（內含對已建立投影片的參照）。
5. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何在投影片上建立縮放框格：

``` csharp 
using (Presentation pres = new Presentation())
{
    // 新增投影片至簡報
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 為第二張投影片建立背景
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 為第二張投影片建立文字方塊
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 為第三張投影片建立背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 為第三張投影片建立文字方塊
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // 新增 ZoomFrame 物件
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **使用自訂影像建立縮放框格**
使用 Aspose.Slides for .NET，您可以這樣建立具有不同投影片預覽影像的縮放框格：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立您打算連結縮放框格的新增投影片。
3. 為投影片加入辨識文字與背景。
4. 透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件相關聯的 Images 集合，建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填滿框格。
5. 在第一張投影片加入縮放框格（內含對已建立投影片的參照）。
6. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何建立具有不同影像的縮放框格：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 為第二張投影片建立背景
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 為第三張投影片建立文字方塊
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 為縮放物件建立新影像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //新增 ZoomFrame 物件
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **格式化縮放框格**
在前面的章節中，我們示範了如何建立簡單的縮放框格。若要建立更複雜的縮放框格，必須變更簡單框格的格式。您可以對縮放框格套用多種格式化選項。

您可以這樣在投影片上控制縮放框格的格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立您打算連結縮放框格的新增投影片。
3. 為建立的投影片加入辨識文字與背景。
4. 在第一張投影片加入縮放框格（內含對已建立投影片的參照）。
5. 透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件相關聯的 Images 集合，建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填滿框格。
6. 為第一個縮放框格物件設定自訂影像。
7. 為第二個縮放框格物件變更線條格式。
8. 移除第二個縮放框格物件影像的背景。
5. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何在投影片上變更縮放框格的格式：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增投影片至簡報
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 為第二張投影片建立背景
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 為第二張投影片建立文字方塊
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 為第三張投影片建立背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 為第三張投影片建立文字方塊
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //新增 ZoomFrame 物件
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 為縮放物件建立新影像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 為 zoomFrame1 物件設定自訂影像
    zoomFrame1.ZoomImage = ppImage;

    // 為 zoomFrame2 物件設定縮放框格格式
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // 設定 zoomFrame2 物件不顯示背景
    zoomFrame2.ShowBackground = false;

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Section Zoom 是連結至簡報中某個章節的縮放。您可以使用 Section Zoom 返回需要強調的章節，或用來突顯簡報中各部分之間的關聯。

![overview_image](seczoomsel.png)

對於 Section Zoom 物件，Aspose.Slides 提供 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectionzoomframe) 介面，以及 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面下的若干方法。

### **建立章節縮放框格**

您可以這樣在投影片上加入章節縮放框格：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立一張新投影片。
3. 為建立的投影片加入辨識背景。
4. 建立您打算連結縮放框格的新章節。
5. 在第一張投影片加入章節縮放框格（內含對已建立章節的參照）。
6. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何在投影片上建立縮放框格：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **使用自訂影像建立章節縮放框格**

使用 Aspose.Slides for .NET，您可以這樣建立具有不同投影片預覽影像的章節縮放框格：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立一張新投影片。
3. 為建立的投影片加入辨識背景。
4. 建立您打算連結縮放框格的新章節。
5. 透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件相關聯的 Images 集合，建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填滿框格。
5. 在第一張投影片加入章節縮放框格（內含對已建立章節的參照）。
6. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何建立具有不同影像的縮放框格：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    // 為縮放物件建立新影像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **格式化章節縮放框格**

若要建立更複雜的章節縮放框格，必須變更簡單框格的格式。您可以對章節縮放框格套用多種格式化選項。

您可以這樣在投影片上控制章節縮放框格的格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 建立一張新投影片。
3. 為建立的投影片加入辨識背景。
4. 建立您打算連結縮放框格的新章節。
5. 在第一張投影片加入章節縮放框格（內含對已建立章節的參照）。
6. 變更已建立章節縮放物件的大小與位置。
7. 透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件相關聯的 Images 集合，建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填滿框格。
8. 為已建立的章節縮放框格物件設定自訂影像。
9. 設定 *從連結章節返回原始投影片* 的功能。
10. 移除章節縮放框格物件影像的背景。
11. 為第二個縮放框格物件變更線條格式。
12. 變更過場動畫的持續時間。
13. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何變更章節縮放框格的格式：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // SectionZoomFrame 的格式設定
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Summary Zoom**

Summary Zoom 如同登陸頁，將簡報的所有片段一次顯示。演示時，您可以使用縮放從簡報的任意位置跳至其他位置，順序任意。您可以創意發揮、提前跳過或回顧投影片的片段，而不會中斷簡報的流程。

![overview_image](sumzoomsel.png)

對於 Summary Zoom 物件，Aspose.Slides 提供 [ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomsection) 以及 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomsectioncollection) 介面，並在 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面下提供若干方法。

### **建立 Summary Zoom**

您可以這樣在投影片上加入 Summary Zoom 框格：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 為建立的投影片加入辨識背景並建立新章節。
3. 將 Summary Zoom 框格加入第一張投影片。
4. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何在投影片上建立 Summary Zoom 框格：

``` csharp 
using (Presentation pres = new Presentation())
{
    // 新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    // 新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 2", slide);

    // 新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 3", slide);

    // 新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 4", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **新增與移除 Summary Zoom 章節**

Summary Zoom 框格中的所有章節皆由 [ISummaryZoomFrameSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomsection) 物件表示，這些物件存放於 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomsectioncollection) 物件中。您可以透過 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomsectioncollection) 介面這樣新增或移除 Summary Zoom 章節物件：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 為建立的投影片加入辨識背景並建立新章節。
3. 將 Summary Zoom 框格加入第一張投影片。
4. 為簡報新增一張投影片和章節。
5. 將新建立的章節加入 Summary Zoom 框格。
6. 從 Summary Zoom 框格中移除第一個章節。
7. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何在 Summary Zoom 框格中新增與移除章節：

``` csharp 
using (Presentation pres = new Presentation())
{
    // 新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    // 新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 2", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // 新增章節至 Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // 從 Summary Zoom 移除章節
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **格式化 Summary Zoom 章節**

若要建立更複雜的 Summary Zoom 章節物件，必須變更簡單框格的格式。您可以對 Summary Zoom 章節物件套用多種格式化選項。

您可以這樣在 Summary Zoom 框格中控制章節物件的格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
2. 為建立的投影片加入辨識背景並建立新章節。
3. 將 Summary Zoom 框格加入第一張投影片。
4. 從 `ISummaryZoomSectionCollection` 中取得第一個章節物件。
7. 透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件相關聯的 images 集合，建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage) 物件，以填滿框格。
8. 為已建立的章節縮放框格物件設定自訂影像。
9. 設定 *從連結章節返回原始投影片* 的功能。
11. 為第二個縮放框格物件變更線條格式。
12. 變更過場動畫的持續時間。
13. 將修改後的簡報寫入 PPTX 檔案。

此 C# 程式碼示範如何變更 Summary Zoom 章節物件的格式：

``` csharp 
using (Presentation pres = new Presentation())
{
    //新增一張投影片至簡報
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 1", slide);

    //新增一張投影片至簡報
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 新增一個章節至簡報
    pres.Sections.AddSection("Section 2", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 取得第一個 SummaryZoomSection 物件
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection 物件的格式設定
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // 儲存簡報
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以控制在顯示目標後返回「父」投影片嗎？**

可以。`Zoom frame` 或 `section` 具備 `ReturnToParent` 行為，啟用後會在觀眾瀏覽完目標內容後返回原始投影片。

**我可以調整 Zoom 轉場的「速度」或持續時間嗎？**

可以。Zoom 支援設定 `TransitionDuration`，讓您控制跳躍動畫的長短。

**簡報中可以包含多少個 Zoom 物件？有沒有上限？**

官方文件未列出硬性 API 限制。實際上限取決於簡報的整體複雜度與觀賞者的效能。您可以加入許多 Zoom 框格，但需考量檔案大小與渲染時間。