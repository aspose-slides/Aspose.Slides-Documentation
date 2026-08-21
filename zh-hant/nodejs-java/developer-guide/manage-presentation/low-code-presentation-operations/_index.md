---
title: JavaScript 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/nodejs-java/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷圖形
- 遍歷文字
- 收集圖形
- 壓縮簡報
- 移除未使用的母片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 低程式碼 API 轉換與合併簡報、遍歷內容、收集圖形，並減少簡報大小。"
---
## **概觀**

`aspose.slides` 命名空間提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在聚焦的方法中，讓您能以更少的程式碼轉換或合併檔案、處理簡報元素、收集圖形，並移除未使用的內容。

低程式碼輔助工具在操作適用於整個檔案或簡報且預設工作流程符合您的需求時最為有用。當您需要對單一投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行精細控制時，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/)。

下表總結了可用的輔助工具：

| 輔助工具 | 使用情境 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/) | 將簡報直接以檔案對檔案的方式轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/) | 對每一張投影片、圖形、段落或文字片段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/collect/) | 從整個簡報中取得圖形，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，請使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/#autoByExtension)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert] 類別亦提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專屬方法。當您需要在匯出前檢查或修改簡報，或設定輔助工具未提供的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/nodejs-java/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/#process) 以一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

當所有投影片皆需直接附加至單一結果且不需個別選取或重新映射時，這個輔助工具適用。若需要合併指定的投影片、套用目的母片或版面配置、明確保留分節，或調整不同的投影片尺寸，請使用完整的物件模型。請參閱 [Merge Presentations](/nodejs-java/merge-presentation/) 了解相關情境。

## **遍歷簡報元素**

[ForEach] 類別會為每種請求的簡報元素類型呼叫回呼函式。它避免了巢狀的集合迴圈，且方便於全簡報的檢查或格式變更。在 Node.js 中，可使用 `java.newProxy` 建立回呼介面的實作。

以下範例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#paragraph) 與 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#portion) 來檢查相對應的元素：

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

預設情況下，全簡報的圖形與文字遍歷會包含普通、母片與版面配置投影片。具備 `includeNotes` 參數的重載亦可處理備註投影片。當遍歷順序、提前退出、在呼叫回呼前過濾，或需要詳細的父子控制時，請改用直接的集合迴圈。

## **收集圖形**

當您需要取得簡報中所有圖形的集合，而不是對每個圖形進行回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/collect/#shapes)。若相同的集合需要被多次過濾、計數或處理，這會很有幫助。

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

若每個圖形可以立即處理且不需要保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/foreach/#shape)。

## **壓縮簡報內容**

[Compress] 類別可以移除未使用的結構元素並減少嵌入字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 移除未被普通投影片參考的版面配置投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) 移除不再使用的母片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) 從嵌入字型中移除未使用的字元。

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

先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變成未被參考的母片也能被移除。如果您可能需要保留原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報儲存為新檔案。更多細節請參閱 [Slide Master](/nodejs-java/slide-master/) 與 [Embedded Font](/nodejs-java/embedded-font/)。

## **常見問題**

**何時應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整的檔案或簡報且不需要對單一元素進行詳細控制時，請使用低程式碼輔助工具。若需要選取特定投影片、控制母片與版面配置的關係、檢查中間狀態，或設定輔助工具未提供的行為，則使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/merger/#process) 需要輸入的簡報具有相同的格式。請先將輸入檔案轉換為共同格式，例如使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/convert/#autoByExtension)，再合併已轉換的檔案。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach.slide] 會遍歷普通的簡報投影片。全簡報的 [ForEach.shape]、[ForEach.paragraph] 與 [ForEach.portion] 預設會包含普通、母片與版面配置投影片。若要包含備註投影片，請使用其帶有 `includeNotes` 參數且設為 `true` 的重載。

**ForEach.shape 與 Collect.shapes 有何不同？**

使用 [ForEach.shape] 可透過回呼立即處理每個圖形。當您需要可保留、過濾、計數或多次遍歷的可迭代結果時，請使用 [Collect.shapes]。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或含有未使用字元的嵌入字型。如果這些都不存在，對應的 [Compress] 操作可能不會減少檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助工具在記憶體中操作已載入的 [Presentation] 物件。於 [ForEach] 回呼中變更元素或執行 [Compress] 後，請呼叫 [Presentation.save] 以寫入結果。

## **相關文章**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)