---
title: 管理 Java 中的簡報可存取性
linktitle: 簡報可存取性
type: docs
weight: 30
url: /zh-hant/java/presentation-accessibility/
keywords:
- 簡報可存取性
- 替代文字
- 替代文字標題
- 替代文字說明
- 標示為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何協助自動化 PPT、PPTX 與 ODP 檔案的簡報可存取性檢查—提升螢幕閱讀器體驗並增強合規性。"
---
## **簡介**

替代文字可協助使用輔助技術的人士了解圖像、圖表和其他資訊圖形的含義。本文說明如何使用 Aspose.Slides for Java 讀取與更新替代文字標題與說明，如何將可存取說明與程式碼中使用的形狀名稱區分，並檢查形狀是否被標示為裝飾性。

這些功能支援簡報的可存取性，但並不保證完整可存取。仍需檢查閱讀順序、色彩對比、文字可讀性以及其他可存取性需求。

## **管理替代文字標題與說明**

使用替代文字向無法看到圖像的人解釋圖像、圖表和其他資訊圖形的含義。下列方法與內容各有不同用途：

| 方法或內容 | 目的 |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | 替代說明的簡短標題。 |
| [getAlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getAlternativeText--) | 在投影片情境中，說明形狀內容或目的的有意義描述。 |
| [getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) | 形狀的名稱，程式碼可用於在簡報中找到特定形狀。 |
| Visible text | 投影片上顯示的內容，例如形狀文字或圖表的標題與標籤。更新替代文字不會改變此內容。 |

當簡報作為範本重複使用時，程式碼可能會先透過 [getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 取得的名稱找到形狀，再進行更新。此名稱的用途不同於說明視覺內容傳遞給讀者的替代文字。以名稱搜尋允許作者在不改變程式碼尋找方式的前提下，改善或翻譯說明。名稱可以編輯且不保證唯一，因此請確認名稱與目標形狀相符；詳情請參閱 [Identify and Find Shapes](/slides/zh-hant/java/shape-manipulations/#identify-and-find-shapes)。

以下範例需要 `input.pptx`，其中第一張投影片的第一個形狀是一張辦公室入口的圖片，且該圖片未被標示為裝飾性。範例會讀取並列印其目前的替代文字標題與說明，更新兩個值，然後將簡報儲存為 `output.pptx`。請依實際圖片與其傳遞的資訊調整文字內容。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

僅加入替代文字並不保證簡報可存取或符合可存取性標準。請檢查說明的正確性與相關性，同時審視閱讀順序、色彩對比、可讀文字以及其他可存取性需求。資訊性視覺不應被標示為裝飾性；下一節將說明如何檢查 [isDecorative](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#isDecorative--)。

## **標示為裝飾性**

將純裝飾性的視覺標示為裝飾性，可讓螢幕閱讀器略過它們，減少噪音並將焦點保留在有意義的內容上。此標記適用於背景、裝飾圖樣與間距物件——絕不適用於傳遞資訊的圖表、圖示或圖像。Aspose.Slides 為此旗標提供偵測與驗證功能，支援自動化的可存取性檢查與清理。

![標示為裝飾性](mark_as_decorative.png)

以下程式碼範例示範如何判斷形狀是否被標示為裝飾性。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **常見問題**

**應在替代文字標題與說明中填寫什麼內容？**

使用簡短的標題辨識主題，並以說明文字闡述視覺在投影片情境中傳遞的資訊。對於圖表，描述相關的趨勢或比較，而非僅寫「圖表」。

**我應該使用替代文字來定位範本中的形狀嗎？**

建議以 [getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 回傳的名稱尋找形狀，並確認其為預期的形狀。替代文字可能會被編輯或翻譯，若以精確說明搜尋可能會導致程式碼失效；請參閱 [Identify and Find Shapes](/slides/zh-hant/java/shape-manipulations/)。

**什麼時候應將形狀標示為裝飾性？**

對於不提供資訊、僅具裝飾性的視覺使用裝飾性旗標。傳遞意義的圖像與圖表則需要適當的說明文字。

**加入替代文字就能使簡報完全可存取嗎？**

不能。替代文字只解決可存取性的一部份。仍需檢查閱讀順序、色彩對比、文字可讀性以及其他相關需求；僅設定這些屬性並不代表符合規範。