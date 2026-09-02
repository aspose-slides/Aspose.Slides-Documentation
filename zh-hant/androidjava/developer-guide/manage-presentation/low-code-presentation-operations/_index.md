---
title: 在 Android 上的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/androidjava/low-code-presentation-operations/
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
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集形狀，並縮減簡報檔案大小。"
---
## **概觀**

[com.aspose.slides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/) 套件提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您可以以更少的程式碼完成檔案轉換或合併、處理簡報元素、收集形狀，以及移除未使用的內容。

低程式碼輔助類別在操作適用於整個檔案或簡報且預設工作流程符合需求時最為有用。當您需要對個別投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行細緻控制時，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/)。

以下表格概述了可用的輔助類別：

| 輔助工具 | 使用情境 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/) | 以直接的檔案對檔案呼叫將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/) | 為每個投影片、形狀、段落或文字區段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/) | 從整個簡報取得形狀，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) | 移除未使用的母片與版面配置，並縮減嵌入字型資料。 |

## **轉換簡報**

當輸出檔案的副檔名足以決定匯出格式時，請使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。此方法會開啟來源簡報、根據輸出路徑判斷所需格式，並寫入結果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/) 類別亦提供針對 PDF、SVG、JPEG、PNG、TIFF 的專屬匯出方法。當您需要在匯出前檢查或修改簡報，或設定未由此輔助類別公開的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/androidjava/convert-presentation/) 了解各格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 可一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

當所有投影片都需直接附加至單一結果且不需個別選取或重新映射時，此輔助類別最為合適。當您需要合併特定投影片、套用目標母片或版面配置、明確保留章節，或調整不同投影片尺寸時，請使用完整的物件模型。相關情境請參閱 [Merge Presentations](/slides/zh-hant/androidjava/merge-presentation/)。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/) 類別會為每個請求類型的簡報元素呼叫回呼函式。它避免了巢狀集合迴圈，且在整個簡報的檢查或格式變更上相當方便。

以下範例同時使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、以及 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 來檢查對應的元素：

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

預設情況下，遍歷會包含正常投影片、母片與版面配置投影片。具備 `includeNotes` 參數的多載亦可處理備註投影片。當遍歷順序、提前退出、在回呼前過濾，或需精細的父子關係控制很重要時，請改用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而非對每個形狀即時呼叫回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。此方式在需要對同一組形狀進行多次過濾、計數或處理時特別有用。

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

若每個形狀都能立即處理且不需要保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 類別可以移除未使用的結構元素並縮減嵌入字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 會移除沒有正常投影片參照的版面配置投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 會移除不再使用的母片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 會從嵌入字型中移除未使用的字元。

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

請先移除未使用的版面配置，之後再移除未使用的母片，這樣在版面配置清理後變成未被參照的母片亦能被移除。若您之後可能仍需保留原始母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報儲存為新檔案。更多細節請參閱 [Slide Master](/slides/zh-hant/androidjava/slide-master/) 與 [Embedded Font](/slides/zh-hant/androidjava/embedded-font/)。

## **常見問題**

**何時應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需對個別元素進行細部控制時，使用低程式碼輔助類別。需要選取特定投影片、控制母片與版面配置關係、檢查中間狀態，或設定輔助類別未公開的行為時，請使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 必須使用相同格式的輸入簡報。請先使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) 將檔案轉換成相同格式，之後再進行合併。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach.slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) 只遍歷正常的簡報投影片。整個簡報的 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、以及 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 預設會包含正常、母片與版面配置投影片。使用帶有 `includeNotes` 並設定為 `true` 的多載即可包含備註投影片。

**ForEach.shape 與 Collect.shapes 有何差異？**

[ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) 會在回呼中立即處理每個形狀。當您需要保留可迭代的結果以進行後續過濾、計數或多次遍歷時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。

**Compress 是否一定能讓簡報檔案變小？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片或含有未使用字元的嵌入字型。如果上述項目皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 操作可能不會減少檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助類別在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 物件上執行操作。變更完元素後，請呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 將結果寫入檔案。

## **相關文章**

- [Convert Presentation](/slides/zh-hant/androidjava/convert-presentation/)
- [Merge Presentations](/slides/zh-hant/androidjava/merge-presentation/)
- [Slide Master](/slides/zh-hant/androidjava/slide-master/)
- [Manage Text Box](/slides/zh-hant/androidjava/manage-textbox/)
- [Embedded Font](/slides/zh-hant/androidjava/embedded-font/)