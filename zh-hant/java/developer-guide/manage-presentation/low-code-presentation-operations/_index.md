---
title: Java 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/java/low-code-presentation-operations/
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
- 壓縮內嵌字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並減少簡報大小。"
---
## **概觀**

[com.aspose.slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/) 套件提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝於專注的方法中，讓您能以更少的程式碼執行檔案轉換或合併、處理簡報元素、收集圖形以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合您的需求時，低程式碼輔助工具最為有用。當您需要對個別投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行細緻控制時，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/)。

下表總結了可用的輔助工具：

| 輔助工具 | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/) | 直接以檔案對檔案的方式將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/) | 為每個投影片、圖形、段落或文字區塊執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/collect/) | 取得整個簡報的圖形以供重覆處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少內嵌字型資料。 |

## **轉換簡報**

當僅依靠輸出檔案的副檔名即可選擇匯出格式時，請使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/) 類別還提供針對 PDF、SVG、JPEG、PNG 以及 TIFF 輸出的專屬方法。當您需要在匯出前檢查或修改簡報，或設定選定輔助工具未提供的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/java/convert-presentation/) 以了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 可一次呼叫即合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

當所有投影片都應直接附加至單一結果且不需個別選取或重新對應時，此輔助工具非常適合。若需要合併特定投影片、套用目標母片或版面配置、明確保留分節，或調整不同投影片尺寸，則請使用完整的物件模型。請參閱 [Merge Presentations](/slides/zh-hant/java/merge-presentation/) 以了解相關情境。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/) 類別會對每種請求的簡報元素類型呼叫回呼函式。它避免了多層集合迴圈，對於全簡報的檢查或格式變更相當便利。

以下範例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、[ForEach.portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 來檢查相應的元素：

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

預設情況下，跨整個簡報的圖形與文字遍歷會包括普通投影片、母片與版面配置投影片。帶有 `includeNotes` 參數的重載版本亦可處理註解投影片。若遍歷順序、提前退出、在呼叫回呼之前的過濾，或需要詳細的父子關係控制等因素重要，請使用直接的集合迴圈。

## **收集圖形**

當您需要取得簡報中所有圖形的集合，而不是為每個圖形提供回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。如果同一組圖形將被多次過濾、計數或處理，這會非常有用。

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

若每個圖形都能立即處理且不需要保留收集的結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別可以移除未使用的結構元素並減少內嵌字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 移除沒有被任何普通投影片引用的版面配置投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 移除不再使用的母片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 從內嵌字型中移除未使用的字元。

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

先移除未使用的版面配置，再移除未使用的母片，這樣在清理版面配置後變為未被引用的母片也能被移除。若日後可能需要原始的母片、版面配置或完整的內嵌字型資料，請將最佳化後的簡報另存為新檔案。欲了解更多細節，請參閱 [Slide Master](/slides/zh-hant/java/slide-master/) 與 [Embedded Font](/slides/zh-hant/java/embedded-font/)。

## **常見問題**

**什麼時候應該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需要對個別元素進行細緻控制時，請使用低程式碼輔助工具。若需要選取特定投影片、控制母片與版面配置之關係、檢查中間狀態，或設定輔助工具未提供的行為，則應使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 需要輸入的簡報具有相同的格式。請先將輸入檔案轉換為同一格式，例如使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)，然後再合併已轉換的檔案。

**ForEach 會處理母片、版面配置與註解投影片嗎？**

`[ForEach.slide]` 只遍歷普通的簡報投影片。全簡報的 `[ForEach.shape]`、`[ForEach.paragraph]` 與 `[ForEach.portion]` 預設會包括普通、母片與版面配置投影片。若要包含註解投影片，請使用其帶有 `includeNotes` 參數且設為 `true` 的重載版本。

**ForEach.shape 與 Collect.shapes 有何不同？**

若要即時透過回呼處理每個圖形，請使用 `[ForEach.shape]`。當您需要可保留、過濾、計數或多次遍歷的可疊代結果時，請使用 `[Collect.shapes]`。

**Compress 總是會讓簡報檔案變小嗎？**

不一定。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或內嵌字型中含有未使用的字元。若皆不存在，對應的 `[Compress]` 操作可能不會降低檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助工具在記憶體中的已載入 `[Presentation]` 物件上運作。於 `[ForEach]` 回呼或執行 `[Compress]` 後，請呼叫 `[Presentation.save]` 以寫入結果。

## **相關文章**

- [轉換簡報](/slides/zh-hant/java/convert-presentation/)
- [合併簡報](/slides/zh-hant/java/merge-presentation/)
- [投影片母片](/slides/zh-hant/java/slide-master/)
- [管理文字方塊](/slides/zh-hant/java/manage-textbox/)
- [內嵌字型](/slides/zh-hant/java/embedded-font/)