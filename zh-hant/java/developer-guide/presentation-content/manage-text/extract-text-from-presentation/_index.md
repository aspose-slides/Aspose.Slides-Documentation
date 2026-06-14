---
title: 使用 Java 從簡報中進階文字擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 快速從 PowerPoint 和 OpenDocument 簡報中擷取文字。遵循我們簡單的逐步指南，節省時間。"
---
## **概述**

從簡報中擷取文字是一項常見且重要的工作，對於處理投影片內容的開發人員而言皆是必要的。無論您處理的是 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，或是 OpenDocument 簡報 (ODP)，存取與取得文字資料對於分析、自動化、索引或內容遷移等用途都相當關鍵。

本文提供了一份完整指南，說明如何使用 Aspose.Slides for Java 有效地從各種簡報格式（包括 PPT、PPTX 和 ODP）中擷取文字。您將學習如何系統性地遍歷簡報元素，準確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/) 類別。此類別公開了多個重載的靜態方法，用於從簡報或投影片中擷取所有文字。若要從簡報中的投影片擷取文字，請使用 [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 方法。此方法接受一個類型為 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/) 的物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 類型的物件陣列，保留所有文字格式。

以下程式碼片段會擷取簡報第一張投影片的所有文字：

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **從簡報擷取文字**

若要掃描整份簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/) 類別提供的靜態方法 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)。它接受兩個參數：

1. 第一個參數為一個 [IPresentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/) 物件，代表要從中擷取文字的 PowerPoint 或 OpenDocument 簡報。
1. 第二個參數為 `boolean` 值，指示在掃描簡報文字時是否應包含母片投影片。

該方法回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 類型的物件陣列，內含文字格式資訊。以下程式碼會掃描簡報（包括母片投影片）的文字與格式細節。

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **分類與快速文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/) 類別同樣提供了從簡報中擷取所有文字的方法：

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textextractionarrangingmode/) 列舉參數指示文字擷取結果的組織模式，可設定為以下值：

- `Unarranged` - 未經排版的原始文字，未考慮其在投影片上的位置。
- `Arranged` - 文字依投影片上的順序排列。

當速度至關重要時，可使用未排版模式；其速度快於已排版模式。

[IPresentationText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationtext/) 代表從簡報中擷取的原始文字。其 `getSlidesText` 方法回傳一個 [ISlideText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidetext/) 類型的物件陣列。每個物件代表對應投影片的文字。類型為 [ISlideText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidetext/) 的物件具備以下方法：

- `getText` - 投影片形狀內的文字。
- `getMasterText` - 與此投影片相關的母片形狀內的文字。
- `getLayoutText` - 與此投影片相關的版面配置投影片形狀內的文字。
- `getNotesText` - 與此投影片相關的備註投影片形狀內的文字。
- `getCommentsText` - 與此投影片相關的註解內的文字。

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **常見問題**

**Aspose.Slides 在文字擷取時處理大型簡報的速度怎樣？**

Aspose.Slides 針對高效能進行了最佳化，甚至能處理[大型簡報](/slides/zh-hant/java/open-presentation/)，因此適用於即時或批次處理情境。

**Aspose.Slides 能夠從簡報中的表格與圖表擷取文字嗎？**

可以。Aspose.Slides 能從多種投影片元素（包括表格與圖表相關物件）擷取文字，讓您得以存取與分析常見簡報結構中的文字內容。

**擷取簡報文字是否需要特別的 Aspose.Slides 授權？**

您可以使用 Aspose.Slides 的免費試用版進行文字擷取，但它會有[某些限制](/slides/zh-hant/java/licensing/)，例如只能處理有限張數的投影片。若需無限制使用且處理更大型的簡報，建議購買完整授權。