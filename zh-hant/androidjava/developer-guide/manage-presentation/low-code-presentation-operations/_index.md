---
title: Android 上的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/androidjava/low-code-presentation-operations/
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
- 移除未使用的版面投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並縮減簡報大小。"
---
## **概觀**

此 [com.aspose.slides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/) 套件提供用於一般簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼轉換或合併檔案、處理簡報元素、收集圖形，並移除未使用的內容。

低程式碼輔助類別在操作適用於整個檔案或簡報且預設工作流程符合需求時最為有用。當您需要對單一投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行細緻控制時，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/)。

下表彙總了可用的輔助類別：

| 輔助類別 | 用於 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/) | 將簡報直接以檔案對檔案的方式轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/) | 對每一張投影片、圖形、段落或文字區段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/) | 從整個簡報中取得圖形，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，請使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/) 類別亦提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專用方法。當您需要在匯出前檢查或修改簡報，或設定輔助類別未提供的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/androidjava/convert-presentation/) 以取得特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 以一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

當所有投影片都應直接附加至單一結果且不需逐一選取或重新對映時，此輔助類別適用。若您需要合併特定投影片、套用目標母片或版面配置、明確保留分節，或調整不同投影片尺寸，請使用完整的物件模型。相關情境請參閱 [Merge Presentations](/androidjava/merge-presentation/)。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/) 類別會對每種請求的簡報元素類型呼叫回呼函式。它避免了巢狀集合迴圈，對於簡報全域的檢查或格式變更相當便利。

以下示例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、[ForEach.portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 來檢查對應的元素：

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

預設情況下，簡報全域的圖形與文字遍歷會包含普通投影片、母片與版面投影片。具備 `includeNotes` 參數的重載可同時處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前過濾，或需要細緻的父子層級控制很重要，請使用直接的集合迴圈。

## **收集圖形**

當您需要一次取得簡報中所有圖形的集合，而不是對每個圖形使用回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。若要對同一組圖形進行多次過濾、計數或處理，這會很有幫助。

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

如果每個圖形都能立即處理且不需要保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 類別可以移除未使用的結構元素並減少嵌入字型資料：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 移除所有普通投影片未參照的版面投影片。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 移除不再使用的母片。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 從嵌入字型中移除未使用的字元。

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

在移除未使用的母片之前先移除未使用的版面，這樣在版面清理後變成未參照的母片也能被移除。如果之後可能需要原始的母片、版面或完整的嵌入字型資料，請將最佳化後的簡報另存為新檔案。更多細節請參閱 [Slide Master](/androidjava/slide-master/) 與 [Embedded Font](/androidjava/embedded-font/)。

## **FAQ**

**何時應該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整的檔案或簡報且不需要對單一元素進行細部控制時，請使用低程式碼輔助類別。若需要選取特定投影片、控制母片與版面關係、檢查中間狀態，或設定輔助類別未提供的行為，則應使用完整的物件模型。

**Merger 可以合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) 需要輸入的簡報具有相同格式。請先將輸入檔案轉換為共通格式，例如使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)，然後再合併已轉換的檔案。

**ForEach 會處理母片、版面與備註投影片嗎？**

[ForEach.slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) 只遍歷普通簡報投影片。全域的 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、[ForEach.portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 預設會包含普通、母片與版面投影片。若要包含備註投影片，請使用其帶有 `includeNotes` 參數且設為 `true` 的重載。

**ForEach.shape 與 Collect.shapes 有何差異？**

使用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) 於回呼中立即處理每個圖形。當您需要可保留、過濾、計數或多次遍歷的可迭代結果時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)。

**Compress 總是會使簡報檔案變小嗎？**

不一定。結果取決於簡報是否包含未使用的版面、未使用的母片，或嵌入字型中有未使用的字元。若皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 操作可能不會降低檔案大小。

**ForEach 或 Compress 所做的變更會自動保存嗎？**

不會。這些輔助類別在記憶體中操作已載入的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 物件。於 [ForEach](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/foreach/) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 後，必須呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 以寫入結果。

## **相關文章**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)