---
title: 低程式碼簡報操作（Java）
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/java/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 逐一遍歷投影片
- 逐一遍歷形狀
- 逐一遍歷文字
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 低程式碼 API 進行簡報的轉換與合併、遍歷內容、收集形狀，並減少簡報大小。"
---
## **概覽**

[com.aspose.slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/) 套件提供用於常見簡報操作的靜態輔助類別。這些輔助程式將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼轉換或合併檔案、處理簡報元素、收集形狀，並移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助最為有用。當您需要對個別投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行細部控制時，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/)。

下表彙總了可用的輔助程式：

| 輔助程式 | 用於 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/) | 直接以檔案對檔案方式將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/) | 為每張投影片、形狀、段落或文字部分執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/collect/) | 從整個簡報取得形狀，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。此方法會開啟來源簡報，根據輸出路徑判斷所需格式，並寫入結果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert] 類別亦提供針對 PDF、SVG、JPEG、PNG 及 TIFF 輸出的專屬方法。當您需要在匯出前檢查或修改簡報，或設定選擇的輔助程式未公開的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/java/convert-presentation/) 以了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 以一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

當所有投影片應直接追加至單一結果且不需逐一選取或重新映射時，該輔助程式適用。若需要合併特定投影片、套用目標母片或版面配置、明確保留章節，或調整不同投影片尺寸，請使用完整的物件模型。請參閱 [Merge Presentations](/java/merge-presentation/) 了解相關情境。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/) 類別會為每種請求的簡報元素類型呼叫回呼函式。它避免了巢狀集合迴圈，適合用於整個簡報的檢查或格式變更。

以下範例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、以及 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 來檢查相對應的元素：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

預設情況下，整個簡報的形狀與文字遍歷會包含一般、母片與版面配置投影片。具備 `includeNotes` 參數的重載可同時處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前過濾，或需要詳細的父子控制很重要，請使用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而非對每個形狀使用回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。如果同一組形狀將被多次過濾、計數或處理，這會很有幫助。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

如果每個形狀可以立即處理且不需保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別可移除未使用的結構元素並減少嵌入字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 移除沒有一般投影片參照的版面配置投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 移除不再使用的母片投影片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 從嵌入字型中移除未使用的字元。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

請先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變為未參照的母片也能被移除。如果稍後可能需要原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報儲存為新檔案。更多細節請參閱 [Slide Master](/java/slide-master/) 與 [Embedded Font](/java/embedded-font/)。

## **常見問答**

**何時應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整檔案或簡報且不需要對個別元素進行詳細控制時，使用低程式碼輔助。若需要選取特定投影片、控制母片與版面配置的關係、檢查中間狀態，或設定輔助程式未公開的行為，請使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process] 需要輸入的簡報具有相同格式。請先將輸入檔案轉換為相同格式，例如使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)，然後再合併已轉換的檔案。

**ForEach 會處理母片、版面配置和備註投影片嗎？**

[ForEach.slide] 只會遍歷一般的簡報投影片。整個簡報的 [ForEach.shape]、[ForEach.paragraph] 與 [ForEach.portion] 預設會包含一般、母片與版面配置投影片。若要包含備註投影片，請使用其帶有 `includeNotes` 設為 `true` 的重載。

**ForEach.shape 與 Collect.shapes 有何不同？**

使用 [ForEach.shape] 透過回呼立即處理每個形狀。若需要可保留、過濾、計數或多次遍歷的可列舉結果，請使用 [Collect.shapes]。

**Compress 總是能讓簡報檔案變小嗎？**

不一定。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或含有未使用字元的嵌入字型。如果都不存在，相關的 [Compress] 操作可能不會減少檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助程式在記憶體中作用於已載入的 [Presentation] 物件。於 [ForEach] 回呼中變更元素或執行 [Compress] 後，需呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 以寫入結果。

## **相關文章**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)