---
title: 進階 Android 簡報文字提取
linktitle: 提取文字
type: docs
weight: 90
url: /zh-hant/androidjava/extract-text-from-presentation/
keywords:
- 提取文字
- 從投影片提取文字
- 從簡報提取文字
- 從 PowerPoint 提取文字
- 從 OpenDocument 提取文字
- 從 PPT 提取文字
- 從 PPTX 提取文字
- 從 ODP 提取文字
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 快速從 PowerPoint 與 OpenDocument 簡報中提取文字。遵循我們簡單的分步指南，為您節省時間。"
---
## **概觀**

從簡報中提取文字是一項常見且重要的工作，適用於處理投影片內容的開發人員。無論您是使用 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，還是 OpenDocument 簡報 (ODP)，存取與擷取文字資料對於分析、自動化、索引或內容遷移等目的都可能相當關鍵。

本文提供了一份完整指南，說明如何使用 Aspose.Slides for Android via Java，有效地從各種簡報格式（包括 PPT、PPTX 與 ODP）中提取文字。您將學會系統性地遍歷簡報元素，以精確取得所需的文字內容。

## **從投影片提取文字**

Aspose.Slides for Android via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/) 類別。此類別公開了多個重載的靜態方法，用於從簡報或投影片中提取全部文字。若要從簡報中的投影片提取文字，請使用 [getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 方法。此方法接受一個 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/) 型別的物件作為參數。執行時，該方法會掃描整個投影片以取得文字，並回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 型別物件的陣列，保留任何文字格式。

以下程式碼片段會從簡報的第一張投影片中提取所有文字：

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

## **從簡報提取文字**

若要掃描整個簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/) 類別提供的靜態方法 [getAllTextFrames](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)。它接受兩個參數：

1. 第一個參數為一個 [IPresentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/) 物件，代表要從中提取文字的 PowerPoint 或 OpenDocument 簡報。  
1. 第二個參數為 `boolean` 值，指示在掃描簡報文字時是否應包含母版投影片。

該方法回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 型別物件的陣列，內含文字格式資訊。下方程式碼會掃描簡報（包括母版投影片）的文字與格式細節。

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

## **分類與快速文字提取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/) 類別亦提供了從簡報中提取全部文字的方法：

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textextractionarrangingmode/) 列舉參數指示文字提取結果的組織模式，可設定為以下值：
- `Unarranged` - 未依投影片位置排列的原始文字。  
- `Arranged` - 文字依投影片上的順序排列。

當速度為關鍵時，可使用未排列模式；其速度快於排列模式。

[IPresentationText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationtext/) 代表從簡報中提取的原始文字。其 `getSlidesText` 方法會回傳一個 [ISlideText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidetext/) 型別物件的陣列。每個物件代表對應投影片上的文字。型別為 [ISlideText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidetext/) 的物件具備以下方法：

- `getText` - 投影片形狀內的文字。  
- `getMasterText` - 與此投影片相關聯的母版投影片形狀內的文字。  
- `getLayoutText` - 與此投影片相關聯的版面配置投影片形狀內的文字。  
- `getNotesText` - 與此投影片相關聯的備註投影片形狀內的文字。  
- `getCommentsText` - 與此投影片相關聯的批註文字。

```java
String presentationPath = "presentation.pptx";
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

**Aspose.Slides 在文字提取時處理大型簡報的速度如何？**

Aspose.Slides 已針對高效能進行最佳化，甚至可處理[大型簡報](/slides/zh-hant/androidjava/open-presentation/)，因此適用於即時或大量處理的情境。

**Aspose.Slides 能從簡報中的表格和圖表提取文字嗎？**

可以。Aspose.Slides 能夠從多種投影片元素提取文字，包括表格與圖表相關的物件，讓您能存取與分析常見簡報結構中的文字內容。

**提取簡報文字是否需要特殊的 Aspose.Slides 授權？**

您可以使用 Aspose.Slides 的免費試用版進行文字提取，然而它會有[某些限制](/slides/zh-hant/androidjava/licensing/)，例如只能處理有限張數的投影片。若需無限制使用並處理更大的簡報，建議購買完整授權。