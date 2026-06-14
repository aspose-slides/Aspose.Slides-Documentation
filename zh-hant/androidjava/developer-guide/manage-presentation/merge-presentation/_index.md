---
title: 在 Android 上高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，輕鬆合併 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報，簡化您的工作流程。"
---
## **概述**

在許多 Android 應用程式中，合併 PowerPoint 與 OpenDocument 簡報是一項常見任務，尤其在產生報告、彙編來自不同來源的投影片，或自動化簡報工作流程時。Aspose.Slides 提供功能強大且易於使用的 API，能將多個 PPT、PPTX 或 ODP 檔案合併為單一簡報，且無需安裝 Microsoft PowerPoint、LibreOffice 或 OpenOffice。

在本指南中，您將學習如何僅透過幾行程式碼合併 PowerPoint 與 OpenDocument 簡報。我們會提供即用範例，並示範在合併過程中如何保留投影片的格式、版面配置及其他簡報元素。

無論您是開發企業級應用程式還是簡易自動化工具，Aspose.Slides 都能讓簡報合併快速、可靠且具擴充性。Aspose.Slides 提供多種合併方式。您可以將簡報的所有圖形、樣式、文字、格式、註解、動畫等全部結合，而不必擔心品質或資料的遺失。

{{% alert color="primary" %}}
另請參閱: [Clone Slides](https://docs.aspose.com/slides/zh-hant/androidjava/clone-slides/)
{{% /alert %}}

### **可合併的項目**

使用 Aspose.Slides，您可以合併

* 整個簡報。所有簡報的投影片都會合併至同一個簡報中
* 指定投影片。選取的投影片會合併至同一個簡報中
* 同一格式的簡報（PPT 轉 PPT、PPTX 轉 PPTX 等）以及不同格式的簡報（PPT 轉 PPTX、PPTX 轉 ODP 等）之間的簡報。

### **合併選項**

您可以套用選項以決定

* 輸出簡報中的每張投影片是否保留唯一樣式
* 是否對輸出簡報的所有投影片使用相同樣式。

要合併簡報，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 介面）。`AddClone` 方法有多種實作，可定義簡報合併過程的參數。每個 Presentation 物件都有一個 [Slides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以從欲合併投影片的簡報呼叫 `AddClone` 方法。

`AddClone` 方法會回傳一個 `ISlide` 物件，即來源投影片的克隆。輸出簡報中的投影片僅是來源投影片的複製。因此，您可以修改產生的投影片（例如套用樣式、格式選項或版面配置），而無需擔心來源簡報受到影響。

## **合併簡報**

Aspose.Slides 提供 [**AddClone(ISlide)**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允許您在保留投影片版面配置與樣式（預設參數）的情況下合併投影片。

以下 Java 程式碼示範如何合併簡報：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **使用投影片母片合併簡報**

Aspose.Slides 提供 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允許您在套用投影片母片簡報範本的情況下合併投影片。如此一來，必要時您可以變更輸出簡報中投影片的樣式。

以下 Java 程式碼示範上述操作：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
母片的投影片版面配置會自動決定。若無法判斷適當的版面，且 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，則會使用來源投影片的版面。否則，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PptxEditException)。
{{% /alert %}}

如果您希望輸出簡報中的投影片使用不同的投影片版面配置，合併時請改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **合併簡報中的特定投影片**

從多個簡報中合併特定投影片可用於建立自訂投影片組合。Aspose.Slides for Android via Java 允許您選取並匯入所需的投影片。此 API 會保留原始投影片的格式、版面與設計。

以下 Java 程式碼會建立新簡報，從另外兩個簡報加入標題投影片，並將結果保存為檔案：

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

## **使用投影片版面合併簡報**

以下 Java 程式碼示範如何將簡報的投影片合併，並套用您偏好的投影片版面配置，以產生單一輸出簡報：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **合併不同投影片尺寸的簡報**

{{% alert title="Note" color="warning" %}}
無法合併投影片尺寸不同的簡報。
{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，必須調整其中一個簡報的尺寸，使其與另一個簡報的尺寸相同。

以下範例程式碼示範上述操作：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **將投影片合併至簡報章節**

以下 Java 程式碼示範如何將特定投影片合併至簡報的章節中：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

該投影片會被添加至章節的末端。

{{% alert title="Tip" color="primary" %}}
Aspose 提供免費的 [Collage 網路應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 至 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 至 PNG 圖片、建立 [照片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等功能。
{{% /alert %}}

## **常見問題**

**合併簡報時投影片的數量有任何限制嗎？**

沒有嚴格的限制。Aspose.Slides 能處理大型檔案，但效能取決於檔案大小與系統資源。對於極大的簡報，建議使用 64 位元 JVM 並分配足夠的堆積記憶體。

**能否合併內嵌影片或音訊的簡報？**

可以，Aspose.Slides 會保留投影片中嵌入的多媒體內容，但最終簡報的檔案大小可能會顯著增加。

**合併簡報時字型會被保留嗎？**

會。只要系統已安裝或[嵌入](/slides/zh-hant/androidjava/embedded-font/)來源簡報使用的字型，這些字型會在輸出檔案中保留。