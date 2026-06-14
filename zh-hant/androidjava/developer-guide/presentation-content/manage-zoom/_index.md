---
title: 管理 Android 上的簡報縮放
linktitle: 管理縮放
type: docs
weight: 60
url: /zh-hant/androidjava/manage-zoom/
keywords:
- 縮放
- 縮放框格
- 投影片縮放
- 章節縮放
- 摘要縮放
- 新增縮放
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 建立並自訂縮放 — 在 PPT、PPTX 與 ODP 簡報中於章節間跳轉、加入縮圖與過渡效果。"
---
## **簡介**

PowerPoint 中的縮放功能允許您在簡報的特定投影片、章節和區段之間跳轉。當您正在演示時，這種快速瀏覽內容的能力可能非常有用。 

![overview_image](overview.png)

* 若要在單一投影片上概括整個簡報，請使用 [Summary Zoom](#Summary-Zoom)。
* 若僅顯示選取的投影片，請使用 [Slide Zoom](#Slide-Zoom)。
* 若僅顯示單一章節，請使用 [Section Zoom](#Section-Zoom)。

## **投影片縮放**
投影片縮放可以使您的簡報更具動態性，讓您能自由地以任意順序在投影片之間切換，且不會中斷簡報的流程。投影片縮放非常適合沒有太多章節的簡短簡報，但您仍可在各種簡報情境中使用它們。

投影片縮放可協助您深入多項資訊，同時彷彿仍位於同一畫布上。 

![overview_image](slidezoomsel.png)

對於投影片縮放物件，Aspose.Slides 提供 [ZoomImageType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ZoomImageType) 列舉、[IZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IZoomFrame) 介面，以及位於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面下的某些方法。

### **建立縮放框格**

您可以透過以下方式在投影片上新增縮放框格：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立您打算連結縮放框格的新投影片。 
3.	為已建立的投影片加入辨識文字與背景。
4.	將縮放框格（包含對已建立投影片的參照）加入第一張投影片。
5.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //新增投影片至簡報
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 為第二張投影片建立背景
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 為第二張投影片建立文字方塊
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 為第三張投影片建立背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 為第三張投影片建立文字方塊
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //新增 ZoomFrame 物件
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自訂圖像建立縮放框格**
With Aspose.Slides for Android via Java, you can create a zoom frame with a different slide preview image this way:
1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立您打算連結縮放框格的新投影片。 
3.	為該投影片加入辨識文字與背景。
4.	透過將圖像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件相關的 Images 集合，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，以填滿框格。
5.	將縮放框格（包含對已建立投影片的參照）加入第一張投影片。
6.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //新增投影片至簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 為第二張投影片建立背景
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 為第三張投影片建立文字方塊
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 為縮放物件建立新圖像
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //新增 ZoomFrame 物件
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化縮放框格**
In the previous sections, we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a zoom frame. 

您可以透過以下方式控制投影片上縮放框格的格式：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立您打算連結縮放框格的新投影片。 
3.	為已建立的投影片加入一些辨識文字與背景。
4.	將縮放框格（包含對已建立投影片的參照）加入第一張投影片。
5.	透過將圖像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件相關的 Images 集合，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，以填滿框格。
6.	為第一個縮放框格物件設定自訂圖像。
7.	變更第二個縮放框格物件的線條格式。
8.	移除第二個縮放框格物件圖像的背景。
5.	將修改後的簡報寫入為 PPTX 檔案。

``` java 
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 為第二張投影片建立背景
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 為第二張投影片建立文字方塊
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 為第三張投影片建立背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 為第三張投影片建立文字方塊
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //新增 ZoomFrame 物件
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // 為縮放物件建立新圖像
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // 設定 zoomFrame1 物件的自訂圖像
    zoomFrame1.setImage(picture);

    // 為 zoomFrame2 物件設定縮放框格格式
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // 設定 zoomFrame2 物件不顯示背景
    zoomFrame2.setShowBackground(false);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **章節縮放**

章節縮放是連結到簡報中章節的功能。您可以使用章節縮放返回您想特別強調的章節，或是用來凸顯簡報中不同部分之間的關聯。 

![overview_image](seczoomsel.png)

對於章節縮放物件，Aspose.Slides 提供 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISectionZoomFrame) 介面以及位於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面下的某些方法。

### **建立章節縮放框格**

您可以透過以下方式在投影片上新增章節縮放框格：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立新投影片。 
3.	為已建立的投影片加入辨識背景。
4.	建立您打算連結縮放框格的新章節。 
5.	將章節縮放框格（包含對已建立章節的參照）加入第一張投影片。
6.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增一個新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自訂圖像建立章節縮放框格**

Using Aspose.Slides for Android via Java, you can create a section zoom frame with a different slide preview image this way:

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立新投影片。
3.	為已建立的投影片加入辨識背景。
4.	建立您打算連結縮放框格的新章節。 
5.	透過將圖像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件相關的 Images 集合，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，以填滿框格。
5.	將章節縮放框格（包含對已建立章節的參照）加入第一張投影片。
6.	將修改後的簡報寫入為 PPTX 檔案。

``` java 
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增一個新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    // 為縮放物件建立新圖像
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化章節縮放框格**

要建立更為複雜的章節縮放框格，您必須變更簡單框格的格式。您可以對章節縮放框格套用多種格式設定。 

您可以透過以下方式控制投影片上章節縮放框格的格式：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	建立新投影片。
3.	為已建立的投影片加入辨識背景。
4.	建立您打算連結縮放框格的新章節。 
5.	將章節縮放框格（包含對已建立章節的參照）加入第一張投影片。
6.	變更已建立章節縮放物件的大小與位置。
7.	透過將圖像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件相關的 Images 集合，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，以填滿框格。
8.	為已建立的章節縮放框格物件設定自訂圖像。
9.	設定「從連結的章節返回原始投影片」的功能。 
10.	移除章節縮放框格物件圖像的背景。
11.	變更第二個縮放框格物件的線條格式。
12.	變更過渡持續時間。
13.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    // 新增 SectionZoomFrame 物件
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // SectionZoomFrame 的格式設定
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **摘要縮放**

摘要縮放類似於登陸頁面，將簡報的所有部分一次性顯示。演示時，您可以使用縮放在簡報的任意位置之間任意順序跳轉。您可以自由創意、提前跳過或重新查看投影片的片段，而不會打斷簡報的流程。

![overview_image](sumzoomsel.png)

對於摘要縮放物件，Aspose.Slides 提供 [ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomSection) 與 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) 介面，以及位於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面下的某些方法。

### **建立摘要縮放**

您可以透過以下方式將摘要縮放框格加入投影片：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	為已建立的投影片建立帶有辨識背景與新章節的投影片。
3.	將摘要縮放框格加入第一張投影片。
4.	將修改後的簡報寫入為 PPTX 檔案。

``` java 
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 2", slide);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 3", slide);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 4", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **新增與移除摘要縮放章節**

All sections in a summary zoom frame are represented by [ISummaryZoomSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomSection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interface this way:

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	為已建立的投影片建立帶有辨識背景與新章節的投影片。
3.	將摘要縮放框格加入第一張投影片。
4.	為簡報新增投影片與章節。
5.	將已建立的章節加入摘要縮放框格。
6.	從摘要縮放框格中移除第一個章節。
7.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 2", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // 將章節加入 Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // 從 Summary Zoom 中移除章節
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **格式化摘要縮放章節**

要建立更為複雜的摘要縮放章節物件，您必須變更簡單框格的格式。您可以對摘要縮放章節物件套用多種格式設定。 

您可以透過以下方式控制摘要縮放框格中章節物件的格式：

1.	建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2.	為已建立的投影片建立帶有辨識背景與新章節的投影片。
3.	將摘要縮放框格加入第一張投影片。
4.	從 `ISummaryZoomSectionCollection` 取得第一個物件的摘要縮放章節物件。
7.	透過將圖像加入與 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件相關的 images 集合，建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，以填滿框格。
8.	為已建立的章節縮放框格物件設定自訂圖像。
9.	設定「從連結的章節返回原始投影片」的功能。 
11.	變更第二個縮放框格物件的線條格式。
12.	變更過渡持續時間。
13.	將修改後的簡報寫入為 PPTX 檔案。

``` java
Presentation pres = new Presentation();
try {
    //將新投影片加入簡報
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 1", slide);

    //將新投影片加入簡報
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 新增新章節至簡報
    pres.getSections().addSection("Section 2", slide);

    // 新增 SummaryZoomFrame 物件
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 取得第一個 SummaryZoomSection 物件
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // SummaryZoomSection 物件的格式設定
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // 儲存簡報
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以控制在顯示目標後返回「父」投影片嗎？**

是的。[Zoom frame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sectionzoomframe/) 具備返回父層的行為，啟用後，觀眾在瀏覽目標內容後會返回原始投影片。

**我可以調整縮放過渡的「速度」或持續時間嗎？**

是的。縮放支援設定過渡持續時間，讓您可以控制跳轉動畫的長度。

**簡報能包含多少個縮放物件有上限嗎？**

文件中未記載嚴格的 API 限制。實際上限取決於簡報的整體複雜度與觀眾端的效能。您可以新增許多縮放框格，但需考慮檔案大小與渲染時間。