---
title: 在 JavaScript 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/nodejs-java/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷形狀
- 遍歷文字
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮內嵌字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集形狀，並減少簡報檔案大小。"
---
## **概述**

`aspose.slides` 命名空間提供了用於常見簡報操作的靜態輔助類別。這些輔助程式將常用的物件模型工作流程封裝成聚焦的方法，讓您能以更少的程式碼執行轉換或合併檔案、處理簡報元素、收集形狀，以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助程式最為有用。若需要對單一投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行細緻控制，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/)。

以下表格概述了可用的輔助程式：

| 輔助程式 | 適用情況 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/) | 以直接檔案對檔案的呼叫將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/) | 為每個投影片、形狀、段落或文字片段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/collect/) | 從整個簡報中擷取形狀，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) | 移除未使用的母片與版面配置並減少內嵌字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/#autoByExtension)。此方法會開啟來源簡報、從輸出路徑判斷所需格式，然後寫入結果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/) 類別也提供了針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專屬方法。若需要在匯出前檢查或修改簡報，或是設定未在所選輔助程式中公開的匯出選項，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/nodejs-java/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/#process) 只需一次呼叫即可合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

此輔助程式適用於所有投影片皆應直接附加至單一結果的情況，而無需個別選取或重新對映。若需要合併特定投影片、套用目標母片或版面配置、明確保留區段，或調整不同投影片尺寸，請使用完整的物件模型。請參閱 [Merge Presentations](/slides/zh-hant/nodejs-java/merge-presentation/) 了解相關情境。

## **迭代簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/) 類別會對每種請求的簡報元素類型呼叫回呼函式。它避免了巢狀集合迴圈，對於全簡報的檢查或格式變更相當方便。於 Node.js 中，可使用 `java.newProxy` 建立回呼介面的實作。

以下範例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#paragraph) 以及 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#portion) 來檢查對應的元素：

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

預設情況下，全簡報的形狀與文字遍歷會包括一般、母片與版面配置投影片。帶有 `includeNotes` 參數的重載可同時處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前的過濾，或需要精細的父子關係控制很重要，請改用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而不是對每個形狀立即執行回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/collect/#shapes)。這在需要多次篩選、計數或重複處理同一組形狀時特別有用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

若每個形狀都能立即處理且不需保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 類別可移除未使用的結構元素並減少內嵌字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 會移除沒有一般投影片參照的版面配置投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) 會移除不再使用的母片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) 會從內嵌字型中移除未使用的字元。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變成未被參照的母片也能被移除。若日後可能仍需原始的母片、版面配置或完整的內嵌字型資料，請將最佳化後的簡報另存為新檔。更多細節請參閱 [Slide Master](/slides/zh-hant/nodejs-java/slide-master/) 與 [Embedded Font](/slides/zh-hant/nodejs-java/embedded-font/)。

## **常見問題**

**何時應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需對個別元素進行細部控制時，可使用低程式碼輔助程式。若需要選取特定投影片、控制母片與版面配置的關係、檢查中間狀態，或設定輔助程式未公開的行為，則使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/#process) 要求輸入的簡報必須具相同格式。請先使用例如 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/#autoByExtension) 將輸入檔案轉換為相同格式，再進行合併。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach.slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#slide) 只會遍歷一般的簡報投影片。全簡報的 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#paragraph) 與 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#portion) 預設會包括一般、母片與版面配置投影片。使用其帶有 `includeNotes` 並設為 `true` 的重載即可納入備註投影片。

**ForEach.shape 與 Collect.shapes 有何不同？**

使用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape) 會在回呼中立即處理每個形狀。使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/collect/#shapes) 則會取得可保留、篩選、計數或多次遍歷的可列舉結果。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片或內嵌字型中有未使用的字元。若這些都不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 操作可能不會減少檔案大小。

**ForEach 或 Compress 的變更會自動保存嗎？**

不會。這些輔助程式會在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 物件上執行變更。變更完成後，必須呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 才會寫入結果。

## **相關文章**

- [Convert Presentation](/slides/zh-hant/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/zh-hant/nodejs-java/merge-presentation/)
- [Slide Master](/slides/zh-hant/nodejs-java/slide-master/)
- [Manage Text Box](/slides/zh-hant/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/zh-hant/nodejs-java/embedded-font/)