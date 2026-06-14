---
title: 在 JavaScript 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆在 JavaScript 中使用 Aspose.Slides for Node.js 合併 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報，簡化您的工作流程。"
---
## **概述**

Aspose.Slides 允許您透過從一個簡報中複製投影片到另一個簡報來合併簡報。本文說明如何合併整個簡報或選取的投影片、在合併過程中使用投影片母片或特定版面配置、處理不同投影片尺寸的簡報，以及將合併的投影片加入簡報章節。還涵蓋了與合併內容相關的實用說明，包括演講者備註、評論、受密碼保護的來源檔案以及執行緒使用等。

## **簡報合併**

將一個簡報合併至另一個簡報時，實際上是將它們的投影片結合在同一個簡報中，產生單一檔案。

{{% alert title="Info" color="info" %}}
大多數簡報程式（PowerPoint 或 OpenOffice）都缺乏讓使用者以此方式合併簡報的功能。
{{% /alert %}}

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/zh-hant/nodejs-java/)，卻允許您以多種方式合併簡報。您可以合併所有形狀、樣式、文字、格式、評論、動畫等，且不必擔心品質或資料遺失。

**另請參閱**

[Clone Slides](https://docs.aspose.com/slides/zh-hant/nodejs-java/clone-slides/).

## **可以合併的項目**

使用 Aspose.Slides，您可以合併

* 整個簡報。所有簡報的投影片最終會匯入同一個簡報
* 特定投影片。選取的投影片最終會匯入同一個簡報
* 相同格式的簡報（PPT 轉 PPT、PPTX 轉 PPTX 等）以及不同格式的簡報（PPT 轉 PPTX、PPTX 轉 ODP 等）相互合併。

## **合併選項**

您可以套用以下選項，以決定是否

* 輸出簡報中的每張投影片保留唯一的樣式
* 輸出簡報中的所有投影片使用相同的樣式

要合併簡報，Aspose.Slides 提供了來自 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection) 類別的 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法。`addClone` 方法有多種實作，讓您可以自訂合併流程的參數。每個 Presentation 物件都有一個 [Slides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 集合，因此您可以從目標簡報呼叫 `addClone` 方法以合併投影片。

`addClone` 方法會回傳一個 `Slide` 物件，該物件是來源投影片的克隆。輸出簡報中的投影片僅是來源投影片的複製品。因此，您可以對產生的投影片進行變更（例如套用樣式、格式或版面配置），而不會影響來源簡報。

## **合併簡報**

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，允許您在保留投影片版面與樣式的情況下（預設參數）將投影片合併。

以下 JavaScript 程式碼示範如何合併簡報：

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **使用投影片母片合併簡報**

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 方法，允許您在套用投影片母片樣板的同時合併投影片。如此一來，若有需要，您可以變更輸出簡報中投影片的樣式。

以下 JavaScript 程式碼示範上述操作：

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}}
投影片母片的版面會自動決定。若無法自動判斷適當的版面，且 `addClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，系統會使用來源投影片的版面。否則，會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PptxEditException)。
{{% /alert %}}

如果您希望輸出簡報的投影片使用不同的版面配置，合併時請改為使用 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) 方法。

## **從簡報合併特定投影片**

從多個簡報中挑選特定投影片合併，可用於建立自訂的投影片組合。Aspose.Slides for Node.js via Java 允許您只匯入所需的投影片，且 API 會保留原始投影片的格式、版面與設計。

以下 JavaScript 程式碼建立新簡報，從兩個其他簡報中加入標題投影片，並將結果儲存為檔案：

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **使用投影片版面配置合併簡報**

以下 JavaScript 程式碼示範如何在合併投影片時套用您偏好的版面配置，進而產生單一輸出簡報：

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **合併不同投影片尺寸的簡報**

{{% alert title="Note" color="warning" %}}
無法合併尺寸不同的簡報。
{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，必須先調整其中一個簡報的尺寸，使其與另一個簡報的尺寸相匹配。

以下範例程式碼示範上述操作：

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **合併投影片至簡報節**

以下 JavaScript 程式碼示範如何將特定投影片合併至簡報中的某個節：

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

該投影片會被加入至該節的末端。

## **常見問題**

**合併時是否會保留演講者備註？**

會。當複製投影片時，Aspose.Slides 會一起帶入所有投影片元素，包括備註、格式與動畫。

**評論及其作者會被轉移嗎？**

評論作為投影片內容的一部份，會與投影片一同被複製。評論作者的標籤會以評論物件的形式保留在產生的簡報中。

**如果來源簡報受密碼保護怎麼辦？**

必須使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/setpassword/) 以密碼開啟（請參考 [/slides/zh-hant/nodejs-java/password-protected-presentation/](/slides/zh-hant/nodejs-java/password-protected-presentation/)），載入後即可安全地將這些投影片克隆至未受保護的目標檔案（或同樣受保護的檔案）。

**合併操作的執行緒安全性如何？**

不要在 [多執行緒](/slides/zh-hant/nodejs-java/multithreading/) 中使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例。建議的原則是「一個文件 — 一個執行緒」；不同檔案可在各自的執行緒中平行處理。

## **另請參閱**

Aspose 提供 [FREE Online Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 圖片、建立 [照片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

請試用 [Aspose FREE Online Merger](https://products.aspose.app/slides/zh-hant/merger)。它允許您在相同格式（例如 PPT 轉 PPT、PPTX 轉 PPTX）或不同格式（例如 PPT 轉 PPTX、PPTX 轉 ODP）之間合併 PowerPoint 簡報。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)