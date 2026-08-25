---
title: PHP 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/php-java/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷圖形
- 遍歷文字
- 收集圖形
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮內嵌字型
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並縮小簡報大小。"
---
## **概觀**

aspose.slides 命名空間提供用於一般簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼轉換或合併檔案、處理簡報元素、收集圖形，並移除未使用的內容。

當操作針對整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助工具最為有用。若需對個別投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行精細控制，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/)。

下表總結了可用的輔助工具：

| 輔助工具 | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/) | 將簡報直接以檔案對檔案的方式轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach_](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/) | 對每張投影片、圖形、段落或文字片段執行回呼函式。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/) | 從整個簡報中取得圖形，以供重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少內嵌字型資料。 |

## **轉換簡報**

當輸出檔案的副檔名足以決定匯出格式時，請使用 [Convert::autoByExtension](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/#autoByExtension)。此方法會開啟來源簡報，依輸出路徑判斷所需格式，然後寫入結果。

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/) 類別亦提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專用方法。若您需要在匯出前檢查或修改簡報，或設定輔助工具未提供的匯出選項，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/php-java/convert-presentation/) 了解格式特定的工作流程與選項。

## **合併簡報**

使用 [Merger::process](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/#process) 只需一次呼叫即可合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

當所有投影片都應直接追加至單一結果且不需個別挑選或重新對映時，此輔助工具非常適合。若需合併指定的投影片、套用目的地母片或版面配置、明確保留章節，或調整不同投影片尺寸，請使用完整的物件模型。請參閱 [Merge Presentations](/slides/zh-hant/php-java/merge-presentation/) 以了解相關情境。

## **遍歷簡報元素**

[ForEach_](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/) 類別會為每種所請求的簡報元素類型呼叫回呼函式。它可避免巢狀集合迴圈，且在整個簡報的檢查或格式變更上相當便利。

以下範例使用 [ForEach_::slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#slide)、[ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#paragraph) 與 [ForEach_::portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#portion) 來檢查相對應的元素：

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

預設情況下，整個簡報的圖形與文字遍歷會包含一般、母片與版面配置投影片。具備 `includeNotes` 參數的多載版本亦可處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前過濾，或需要詳細的父子關係控制很重要，請改用直接的集合迴圈。

## **收集圖形**

當您需要取得簡報中所有圖形的集合，而非對每個圖形使用回呼函式時，請使用 [Collect::shapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/#shapes)。若同一組圖形會被多次篩選、計數或處理，這會非常有用。

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若每個圖形都能立即處理且不需保留收集結果，請改用 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 類別可以移除未使用的結構元素並減少內嵌字型資料：

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 移除沒有一般投影片參照的版面配置投影片。
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedMasterSlides) 移除不再被使用的母片投影片。
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#compressEmbeddedFonts) 從內嵌字型中移除未使用的字元。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變成無參照的母片也能被移除。若日後可能需要原始的母片、版面配置或完整的內嵌字型資料，請將最佳化後的簡報儲存為新檔案。更多細節請參閱 [Slide Master](/slides/zh-hant/php-java/slide-master/) 與 [Embedded Font](/slides/zh-hant/php-java/embedded-font/)。

## **常見問題**

**什麼時候應該使用低程式碼 API 而非完整物件模型？**

當標準操作針對整個檔案或簡報且不需要對個別元素進行詳細控制時，請使用低程式碼輔助工具。若需要挑選特定投影片、控制母片與版面配置之關係、檢查中間狀態，或設定輔助工具未提供的行為，則使用完整的物件模型。

**Merger 能否合併不同檔案格式的簡報？**

不能。[Merger::process](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/#process) 需要輸入的簡報具有相同格式。請先將輸入檔案轉換為共同格式，例如使用 [Convert::autoByExtension](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/#autoByExtension)，再合併已轉換的檔案。

**ForEach_ 會處理母片、版面配置與備註投影片嗎？**

[ForEach_::slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#slide) 只遍歷一般的簡報投影片。整個簡報的 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#paragraph) 與 [ForEach_::portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#portion) 操作預設會包含一般、母片與版面配置投影片。若要包含備註投影片，請使用其帶有 `includeNotes` 並設定為 `true` 的多載版本。

**ForEach_::shape 與 Collect::shapes 有何差異？**

若要立即透過回呼函式處理每個圖形，請使用 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)。若需要可保留、篩選、計數或多次遍歷的可迭代結果，請使用 [Collect::shapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/#shapes)。

**Compress 總是會讓簡報檔案變小嗎？**

不一定。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或內嵌字型中有未使用的字元。若皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 操作可能不會減少檔案大小。

**ForEach_ 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助工具在記憶體中作用於已載入的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 物件。於 [ForEach_](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 後，請呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 以寫入結果。

## **相關文章**

- [轉換簡報](/slides/zh-hant/php-java/convert-presentation/)
- [合併簡報](/slides/zh-hant/php-java/merge-presentation/)
- [投影片母片](/slides/zh-hant/php-java/slide-master/)
- [管理文字方塊](/slides/zh-hant/php-java/manage-textbox/)
- [內嵌字型](/slides/zh-hant/php-java/embedded-font/)