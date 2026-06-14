---
title: 在 JavaScript 中的簡報文字進階擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/nodejs-java/extract-text-from-presentation/
keywords:
- 擷取文字
- 從投影片擷取文字
- 從簡報擷取文字
- 從 PowerPoint 擷取文字
- 從 OpenDocument 擷取文字
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
- 取得文字
- 從投影片取得文字
- 從簡報取得文字
- 從 PowerPoint 取得文字
- 從 OpenDocument 取得文字
- 從 PPT 取得文字
- 從 PPTX 取得文字
- 從 ODP 取得文字
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，快速從 PowerPoint 與 OpenDocument 簡報中擷取文字。遵循我們簡單的逐步指南，節省時間。"
---
## **概觀**

從簡報中擷取文字是開發人員處理投影片內容時常見且重要的工作。無論您是在處理 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，亦或是 OpenDocument 簡報（ODP），取得文字資料對於分析、自動化、索引或內容遷移都可能是關鍵。

本文提供一套完整指南，說明如何使用 Aspose.Slides for Node.js via Java，有效從 PPT、PPTX 以及 ODP 等多種簡報格式中擷取文字。您將學會如何系統性地遍歷簡報元素，以精確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for Node.js via Java 提供 [SlideUtil](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/) 類別。此類別提供多個重載的靜態方法，用於從簡報或投影片中擷取全部文字。若要從簡報中的投影片擷取文字，請使用 [getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) 方法。該方法接受一個投影片物件作為參數。執行時，方法會掃描整個投影片的文字，並回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 陣列，保留所有文字格式資訊。

以下程式碼片段會擷取簡報第一張投影片的全部文字：

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **從簡報擷取文字**

若要掃描整個簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/) 類別所提供的 [getAllTextFrames](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 靜態方法。它接受兩個參數：

1. 第一個參數是代表將要擷取文字之 PowerPoint 或 OpenDocument 簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 物件。
1. 第二個參數是布林值，指示在掃描簡報文字時是否應包含母版投影片。

此方法會回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 陣列，並包含文字格式資訊。下列程式碼會從簡報（包括母版投影片）中掃描文字與格式細節：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **分類且快速的文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/) 類別亦提供用於從簡報擷取全部文字的方法：

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textextractionarrangingmode/) 列舉參數表示組織文字擷取結果的模式，可設定為以下值：
- `Unarranged` — 不考慮文字在投影片上的位置的原始文字。
- `Arranged` — 文字以投影片上的相同順序排列。

在速度至關重要的情況下，可使用未排列模式（Unarranged），其速度比排列模式（Arranged）更快。

[PresentationText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationtext/) 代表從簡報中擷取的原始文字。其 `getSlidesText` 方法回傳一個物件陣列，每個物件對應相應投影片的文字。每個投影片文字物件具有以下方法：

- `getText` 方法回傳投影片形狀內的文字。
- `getMasterText` 方法回傳與此投影片相關的母版投影片形狀內的文字。
- `getLayoutText` 方法回傳與此投影片相關的版面配置投影片形狀內的文字。
- `getNotesText` 方法回傳與此投影片相關的備註投影片形狀內的文字。
- `getCommentsText` 方法回傳與此投影片相關的評論文字。

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **常見問題集**

**Aspose.Slides 在大量簡報的文字擷取過程中速度如何？**

Aspose.Slides 已針對高效能進行最佳化，即使是 [大型簡報](/slides/zh-hant/nodejs-java/open-presentation/)，也能快速處理，適用於即時或批次處理情境。

**Aspose.Slides 能否從簡報中的表格與圖表擷取文字？**

可以。Aspose.Slides 能從許多投影片元素擷取文字，包括表格與圖表相關的物件，讓您得以存取與分析常見簡報結構中的文字內容。

**擷取簡報文字是否需要特殊的 Aspose.Slides 授權？**

您可以使用 Aspose.Slides 的免費試用版進行文字擷取，但會有 [特定限制](/slides/zh-hant/nodejs-java/licensing/)，例如只能處理有限張投影片。若需無限制使用並處理較大簡報，建議購買完整授權。