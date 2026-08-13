---
title: 在 Java 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/java/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併 簡報
- 合併 投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合 簡報
- 結合 投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- Java
- Aspose.Slides
description: "輕鬆合併 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報，使用 Aspose.Slides for Java，簡化您的工作流程。"
---
## **概觀**

合併 PowerPoint 與 OpenDocument 簡報在許多 Java 應用程式中是一項常見任務，尤其在產生報告、彙整來自不同來源的投影片，或自動化簡報工作流程時。Aspose.Slides for Java 提供功能強大且易於使用的 API，讓您在不安裝 Microsoft PowerPoint、LibreOffice 或 OpenOffice 的情況下，將多個 PPT、PPTX 或 ODP 檔案合併為單一簡報。

在本指南中，您將學習如何僅透過幾行 Java 程式碼合併 PowerPoint 與 OpenDocument 簡報。我們將提供即用範例，並說明如何在合併過程中保留投影片的格式、版面配置及其他簡報元素。

無論您是開發企業級應用程式還是簡易的自動化工具，Aspose.Slides 都能在 Java 中快速、可靠且具擴充性地合併簡報。Aspose.Slides for Java 允許以多種方式合併簡報。您可以結合簡報的所有形狀、樣式、文字、格式、註解、動畫等——不必擔心品質或資料遺失。

{{% alert color="info" %}}
另請參閱：[複製投影片](https://docs.aspose.com/slides/zh-hant/java/clone-slides/)
{{% /alert %}}

### **可以合併什麼？**

使用 Aspose.Slides，您可以合併：

**完整簡報** – 來自多個簡報的所有投影片將合併為一個。

**特定投影片** – 只有選取的投影片會合併成單一簡報。

**相同格式的簡報**（例如 PPT 轉 PPT、PPTX 轉 PPTX）以及 **不同格式的簡報**（例如 PPT 轉 PPTX、PPTX 轉 ODP）。

### **合併選項**

您可以套用選項，以決定是否：

- 輸出簡報中的每張投影片保留其原始樣式
- 將特定樣式套用於輸出簡報的所有投影片

要合併簡報，Aspose.Slides 透過 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 介面提供 `AddClone` 方法。此方法有多個重載，可定義合併過程的行為。每個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 物件都具有 Slides 集合。因此，您可以在目標簡報上呼叫 `AddClone` 方法，以將投影片合併進去。

`AddClone` 方法會回傳一個 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件，即來源投影片的複製品。輸出簡報中的投影片僅是原始投影片的複本。這表示您可以安全地修改這些複製的投影片，例如套用樣式、格式或版面配置，而不會影響來源簡報。

## **合併簡報**

Aspose.Slides 提供 [AddClone(ISlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) 方法，讓您在保留投影片原始版面與樣式（預設行為）的同時合併它們。

以下 Java 程式碼示範如何合併簡報：

```java
import com.aspose.slides.*;

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

Aspose.Slides 提供 [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，讓您在結合投影片的同時套用來自簡報範本的投影片母片。如此一來，若有需要，您即可變更輸出簡報中投影片的樣式。

以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
投影片的版面配置會自動決定。當找不到合適的版面，且 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設為 `true` 時，將使用來源投影片的版面。否則，會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **合併特定投影片（來自簡報）**

從多個簡報中合併特定投影片可用於建立自訂投影片套件。Aspose.Slides for Java 允許您僅選取並匯入所需的投影片。API 會保留原始投影片的格式、版面與設計。

以下 Java 程式碼會建立新簡報，從另外兩個簡報中加入標題投影片，並將結果儲存為檔案：

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **使用投影片版面合併簡報**

若要在合併過程中為輸出投影片套用不同的投影片版面，請改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

以下 Java 程式碼示範如何從多個簡報中合併投影片，同時套用您偏好的投影片版面，產生單一的輸出簡報：

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **合併不同投影片尺寸的簡報**

要合併兩個投影片尺寸不同的簡報，您需要將其中一個的尺寸調整為與另一個簡報的投影片尺寸相同。

以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **合併投影片至簡報章節**

將投影片合併到特定的簡報章節有助於組織內容並提升投影片導覽。Aspose.Slides 允許您將投影片合併到現有章節，確保結構清晰，同時保留每張投影片的原始格式。

以下 Java 程式碼示範如何將特定投影片合併至簡報的章節中：

```java
import com.aspose.slides.*;

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

投影片會被加入至該章節的末端。

## **相關資訊**

Aspose 提供 [免費線上拼貼製作工具](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 到 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖片，建立 [相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

請查看 [Aspose 免費線上合併工具](https://products.aspose.app/slides/zh-hant/merger)。它允許您合併相同格式的 PowerPoint 簡報（例如 PPT 轉 PPT、PPTX 轉 PPTX）或不同格式的簡報（例如 PPT 轉 PPTX、PPTX 轉 ODP）。

[![Aspose 免費線上合併工具](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)

除了簡報之外，Aspose.Slides 也允許您合併其他檔案：

- [**影像**](https://products.aspose.com/slides/zh-hant/java/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/zh-hant/java/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/zh-hant/java/merger/png-to-png/)
- **文件**，例如 [PDF 到 PDF](https://products.aspose.com/slides/zh-hant/java/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/zh-hant/java/merger/html-to-html/)
- **混合檔案類型**，例如 [影像轉 PDF](https://products.aspose.com/slides/zh-hant/java/merger/image-to-pdf/)、[JPG 轉 PDF](https://products.aspose.com/slides/zh-hant/java/merger/jpg-to-pdf/)，或 [TIFF 轉 PDF](https://products.aspose.com/slides/zh-hant/java/merger/tiff-to-pdf/)

## **常見問題**

### 合併簡報時投影片數量有限制嗎？

沒有嚴格的限制。Aspose.Slides 能處理大型檔案，但效能取決於檔案大小與系統資源。對於非常大的簡報，建議使用 64 位元 JVM 並配置足夠的堆記憶體。

### 我可以合併包含嵌入式影片或音訊的簡報嗎？

可以，Aspose.Slides 會保留投影片中嵌入的多媒體內容，但最終簡報的檔案大小可能會顯著增加。

### 合併簡報時字型會被保留嗎？

會。只要系統已安裝或 [嵌入](/slides/zh-hant/java/embedded-font/) 相應字型，來源簡報使用的字型就會在輸出檔案中保留。