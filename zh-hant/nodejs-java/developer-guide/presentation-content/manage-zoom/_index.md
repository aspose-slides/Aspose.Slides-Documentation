---
title: 管理 JavaScript 中的簡報縮放
linktitle: 管理縮放
type: docs
weight: 60
url: /zh-hant/nodejs-java/manage-zoom/
keywords:
- 縮放
- 縮放框架
- 投影片縮放
- 章節縮放
- 摘要縮放
- 新增縮放
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 建立並自訂縮放——在 PPT、PPTX 及 ODP 簡報中於章節間跳轉、加入縮圖與轉場效果。"
---
## **簡介**

PowerPoint 中的縮放功能允許您在簡報的特定投影片、章節和區段之間跳轉。當您在簡報時，快速在內容間導航的能力可能非常有用。 

![overview_image](overview.png)

* 若要在單一投影片上概括整個簡報，請使用 [Summary Zoom](#Summary-Zoom)。
* 若只想顯示選取的投影片，請使用 [Slide Zoom](#Slide-Zoom)。
* 若只想顯示單一章節，請使用 [Section Zoom](#Section-Zoom)。

## **投影片縮放**

投影片縮放可以讓您的簡報更加動態，允許您以任意順序在投影片之間自由導航，而不會中斷簡報的流程。投影片縮放非常適合沒有許多章節的短篇簡報，但您仍然可以在不同的簡報情境中使用它們。  

投影片縮放協助您深入多個資訊片段，同時讓您感覺彷彿在同一個畫布上。 

![overview_image](slidezoomsel.png)

對於投影片縮放物件，Aspose.Slides 提供 [ZoomImageType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ZoomImageType) 列舉、[ZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ZoomFrame) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別中的一些方法。

### **建立縮放框架**

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立您打算連結縮放框架的新投影片。  
3.	為已建立的投影片加入識別文字與背景。  
4.	將縮放框架（包含對已建立投影片的參考）加入第一張投影片。  
5.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 為第二張投影片建立背景
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 為第二張投影片建立文字方塊
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 為第三張投影片建立背景
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 為第三張投影片建立文字方塊
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // 加入 ZoomFrame 物件
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **使用自訂影像建立縮放框架**

使用 Aspose.Slides for Node.js via Java，您可以透過以下方式建立具有不同投影片預覽影像的縮放框架：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立您打算連結縮放框架的新投影片。  
3.	為該投影片加入識別文字與背景。  
4.	透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件相關聯的 Images 集合，建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以填滿框架。  
5.	將縮放框架（包含對已建立投影片的參考）加入第一張投影片。  
6.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 為第二張投影片建立背景
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 為第三張投影片建立文字方塊
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 為縮放物件建立新影像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 加入 ZoomFrame 物件
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **格式化縮放框架**

在前面的章節中，我們示範了如何建立簡單的縮放框架。若要建立更複雜的縮放框架，您必須修改簡單框架的格式。您可以對縮放框架套用多種格式設定。  

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立您打算連結縮放框架的新投影片。  
3.	為已建立的投影片加入一些識別文字與背景。  
4.	將縮放框架（包含對已建立投影片的參考）加入第一張投影片。  
5.	透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件相關聯的 Images 集合，建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以填滿框架。  
6.	為第一個縮放框架物件設定自訂影像。  
7.	變更第二個縮放框架物件的線條格式。  
8.	移除第二個縮放框架物件影像的背景。  
5.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 為第二張投影片建立背景
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 為第二張投影片建立文字方塊
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 為第三張投影片建立背景
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 為第三張投影片建立文字方塊
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // 加入 ZoomFrame 物件
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 為縮放物件建立新影像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 為 zoomFrame1 物件設定自訂影像
    zoomFrame1.setImage(picture);
    // 為 zoomFrame2 物件設定縮放框架格式
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // 設定 zoomFrame2 物件不顯示背景
    zoomFrame2.setShowBackground(false);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **章節縮放**

章節縮放是指向簡報中某個章節的連結。您可以使用章節縮放返回您想特別強調的章節，或用來突顯簡報中不同部分之間的關聯。 

![overview_image](seczoomsel.png)

對於章節縮放物件，Aspose.Slides 提供 [SectionZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SectionZoomFrame) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別中的一些方法。

### **建立章節縮放框架**

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立新投影片。  
3.	為已建立的投影片加入識別背景。  
4.	建立您打算連結縮放框架的新章節。  
5.	將章節縮放框架（包含對已建立章節的參考）加入第一張投影片。  
6.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 加入 SectionZoomFrame 物件
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **使用自訂影像建立章節縮放框架**

使用 Aspose.Slides for Node.js via Java，您可以透過以下方式建立具有不同投影片預覽影像的章節縮放框架：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立新投影片。  
3.	為已建立的投影片加入識別背景。  
4.	建立您打算連結縮放框架的新章節。  
5.	透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件相關聯的 Images 集合，建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以填滿框架。  
5.	將章節縮放框架（包含對已建立章節的參考）加入第一張投影片。  
6.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 為縮放物件建立新影像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 加入 SectionZoomFrame 物件
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **格式化章節縮放框架**

您可以透過以下方式控制章節縮放框架在投影片上的格式：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立新投影片。  
3.	為已建立的投影片加入識別背景。  
4.	建立您打算連結縮放框架的新章節。  
5.	將章節縮放框架（包含對已建立章節的參考）加入第一張投影片。  
6.	變更已建立的章節縮放物件的大小與位置。  
7.	透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件相關聯的 Images 集合，建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以填滿框架。  
8.	為已建立的章節縮放框架物件設定自訂影像。  
9.	設定 *從連結的章節返回原始投影片* 的能力。  
10.	移除章節縮放框架物件影像的背景。  
11.	變更第二個縮放框架物件的線條格式。  
12.	變更過渡持續時間。  
13.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 加入 SectionZoomFrame 物件
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame 的格式設定
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **摘要縮放**

摘要縮放就像是登陸頁面，所有簡報的片段一次顯示。當您在簡報時，您可以使用縮放從簡報的任意位置跳轉到另一個位置，順序任意。您可以發揮創意，跳過或重新檢視投影片的部分，而不會中斷簡報流程。 

![overview_image](sumzoomsel.png)

對於摘要縮放物件，Aspose.Slides 提供 [SummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SummaryZoomFrame)、[SummaryZoomSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SummaryZoomSection) 與 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 類別，並在 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 類別中提供一些方法。

### **建立摘要縮放**

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立具有識別背景以及新章節的投影片。  
3.	將摘要縮放框架加入第一張投影片。  
4.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 2", slide);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 3", slide);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 4", slide);
    // 加入 SummaryZoomFrame 物件
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **新增與移除摘要縮放章節**

摘要縮放框架中的所有章節皆由 [SummaryZoomSection] 物件表示，並儲存在 [SummaryZoomSectionCollection] 物件中。您可以透過以下方式使用 [SummaryZoomSectionCollection] 類別新增或移除摘要縮放章節物件：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立具有識別背景以及新章節的投影片。  
3.	將摘要縮放框架加入第一張投影片。  
4.	在簡報中新增投影片與章節。  
5.	將已建立的章節加入摘要縮放框架。  
6.	從摘要縮放框架中移除第一個章節。  
7.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 2", slide);
    // 加入 SummaryZoomFrame 物件
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    var section3 = pres.getSections().addSection("Section 3", slide);
    // 將章節加入摘要縮放
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // 從摘要縮放中移除章節
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **格式化摘要縮放章節**

您可以透過以下方式控制摘要縮放框架中摘要縮放章節物件的格式：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2.	建立具有識別背景以及新章節的投影片。  
3.	將摘要縮放框架加入第一張投影片。  
4.	從 `ISummaryZoomSectionCollection` 取得第一個摘要縮放章節物件。  
7.	透過將影像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件相關聯的 images 集合，建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PPImage) 物件，以填滿框架。  
8.	為已建立的章節縮放框架物件設定自訂影像。  
9.	設定 *從連結的章節返回原始投影片* 的能力。  
11.	變更第二個縮放框架物件的線條格式。  
12.	變更過渡持續時間。  
13.	將修改後的簡報寫入為 PPTX 檔案。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 將新投影片加入簡報
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 1", slide);
    // 將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 將新章節加入簡報
    pres.getSections().addSection("Section 2", slide);
    // 加入 SummaryZoomFrame 物件
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 取得第一個 SummaryZoomSection 物件
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // SummaryZoomSection 物件的格式設定
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // 儲存簡報
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以控制在顯示目標後返回「父」投影片嗎？**

是的。 [Zoom frame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectionzoomframe/) 具備 `setReturnToParent` 方法，啟用後會在觀看者瀏覽目標內容後返回原始投影片。  

**我可以調整縮放過渡的「速度」或持續時間嗎？**

是的。Zoom 提供 `setTransitionDuration` 方法，讓您控制跳躍動畫的持續時間。  

**簡報中可包含的 Zoom 物件數量有任何限制嗎？**

沒有文件化的硬性 API 限制。實際限制取決於簡報的整體複雜度以及檢視器的效能。您可以加入許多 Zoom 框架，但需考慮檔案大小與渲染時間。