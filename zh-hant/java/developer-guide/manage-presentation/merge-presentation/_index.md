---
title: 高效合併 Java 簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/java/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併簡報
- 合併投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合簡報
- 結合投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- Java
- Aspose.Slides
description: "輕鬆合併 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報，使用 Aspose.Slides for Java，提升工作流程效率。"
---
## **概述**

合併 PowerPoint 和 OpenDocument 簡報在許多 Java 應用程式中是一項常見任務，尤其是在產生報告、彙編來自不同來源的投影片，或自動化簡報工作流程時。Aspose.Slides for Java 提供強大且易於使用的 API，能在不安裝 Microsoft PowerPoint、LibreOffice 或 OpenOffice 的情況下，將多個 PPT、PPTX 或 ODP 檔案合併為單一簡報。

在本指南中，您將學會如何僅使用幾行 Java 程式碼合併 PowerPoint 和 OpenDocument 簡報。我們會提供即用範例，並說明如何在合併過程中保留投影片格式、版面配置與其他簡報元素。

無論您是構建企業級應用程式或是簡單的自動化工具，Aspose.Slides 都能讓 Java 中的簡報合併快速、可靠且具可擴充性。Aspose.Slides for Java 允許您以多種方式合併簡報。您可以將簡報的所有形狀、樣式、文字、格式、評論、動畫等全部合併——無需擔心品質或資料遺失。

{{% alert color="primary" %}}
另請參閱：[Clone Slides](https://docs.aspose.com/slides/zh-hant/java/clone-slides/)
{{% /alert %}}

### **可以合併什麼？**

**完整簡報** – 來自多個簡報的所有投影片合併為一個。  

**特定投影片** – 僅選取的投影片合併為單一簡報。  

**相同格式的簡報**（例如 PPT 轉 PPT、PPTX 轉 PPTX）以及 **不同格式的簡報**（例如 PPT 轉 PPTX、PPTX 轉 ODP）。

### **合併選項**

您可以套用選項，以決定：

- 輸出簡報中的每張投影片保留原始樣式  
- 為輸出簡報的所有投影片套用特定樣式  

若要合併簡報，Aspose.Slides 透過 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 介面提供 `AddClone` 方法。此介面有多個 `AddClone` 方法的重載，可定義合併行為。每個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 物件都有 Slides 集合。因此，您可以在目標簡報上呼叫 `AddClone` 方法以合併投影片。

`AddClone` 方法會傳回一個 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件，該物件是來源投影片的複本。輸出簡報中的結果投影片僅是原始投影片的拷貝。這表示您可以安全地修改這些複製的投影片──例如套用樣式、格式選項或版面配置──而不會影響來源簡報。

## **合併簡報**

Aspose.Slides 提供 [AddClone(ISlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-) 方法，允許在保留原始版面與樣式（預設行為）的情況下合併投影片。

以下 Java 程式碼示範如何合併簡報：

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **使用投影片母片合併簡報**

Aspose.Slides 提供 [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允許在合併投影片時套用來自簡報範本的投影片母片。如此一來，您可以根據需要變更輸出簡報中投影片的樣式。

以下 Java 程式碼示範此操作：

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
投影片的版面配置會自動決定。當找不到合適的版面且 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設定為 `true` 時，會使用來源投影片的版面。否則，會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **合併簡報中的特定投影片**

從多個簡報中合併特定投影片，可用於建立自訂投影片組。Aspose.Slides for Java 允許您只選取並匯入所需的投影片。API 會保留原始投影片的格式、版面與設計。

以下 Java 程式碼建立新簡報，從兩個其他簡報中加入標題投影片，並將結果保存為檔案：

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **使用投影片版面配置合併簡報**

若要在合併期間為輸出投影片套用不同的版面配置，可改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) 方法。

以下 Java 程式碼示範如何在合併多個簡報的投影片時套用您偏好的版面配置，最終產生單一輸出簡報：

```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **使用不同投影片大小合併簡報**

若要合併兩個投影片大小不同的簡報，您應將其中一個的大小調整至與另一個簡報的投影片大小相同。

以下 Java 程式碼示範此操作：

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **合併投影片至簡報分節**

將投影片合併至特定簡報分節有助於組織內容並提升投影片導覽效率。Aspose.Slides 允許您將投影片合併至現有分節，確保結構清晰，同時保留每張投影片的原始格式。

以下 Java 程式碼示範如何將特定投影片合併至簡報的某個分節：

```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

該投影片會被加入至分節的最後。

## **另請參閱**

Aspose 提供一個 [FREE Online Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 圖片，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，以及更多功能。

請參考 [Aspose FREE Online Merger](https://products.aspose.app/slides/zh-hant/merger)。它允許您合併相同格式的 PowerPoint 簡報（例如 PPT 轉 PPT、PPTX 轉 PPTX）或跨不同格式（例如 PPT 轉 PPTX、PPTX 轉 ODP）。

[![Aspose 免費線上合併工具](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)

除了簡報，Aspose.Slides 亦允許合併其他類型檔案：

- **影像**，例如 [JPG to JPG](https://products.aspose.com/slides/zh-hant/java/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/zh-hant/java/merger/png-to-png/)  
- **文件**，例如 [PDF to PDF](https://products.aspose.com/slides/zh-hant/java/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/zh-hant/java/merger/html-to-html/)  
- **混合檔案類型**，例如 [image to PDF](https://products.aspose.com/slides/zh-hant/java/merger/image-to-pdf/)、[JPG to PDF](https://products.aspose.com/slides/zh-hant/java/merger/jpg-to-pdf/)、[TIFF to PDF](https://products.aspose.com/slides/zh-hant/java/merger/tiff-to-pdf/)

## **常見問題**

**合併簡報時對投影片數量有任何限制嗎？**

沒有嚴格的限制。Aspose.Slides 能處理大型檔案，但效能取決於檔案大小與系統資源。對於非常大的簡報，建議使用 64 位元 JVM 並分配足夠的堆記憶體。

**我可以合併包含嵌入式影片或音訊的簡報嗎？**

可以，Aspose.Slides 會保留投影片中嵌入的多媒體內容，但最終簡報的檔案大小可能會顯著增加。

**合併簡報時字型會被保留嗎？**

會。來源簡報使用的字型會在輸出檔案中保留，前提是這些字型已安裝在系統上或已[embedded](/slides/zh-hant/java/embedded-font/)。