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
- 遍歷形狀
- 遍歷文字
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集形狀，並縮小簡報大小。"
---
## **概觀**

[aspose.slides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/) 命名空間提供靜態輔助類別，用於常見的簡報操作。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您可以更少程式碼地轉換或合併檔案、處理簡報元素、收集形狀，以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合您的需求時，低程式碼輔助類別最為有用。當您需要對個別投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行細緻控制時，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/)。

下表概述了可用的輔助類別：

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/) | 將簡報轉換為其他格式的直接檔案對檔案呼叫。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach_](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/) | 對每張投影片、形狀、段落或文字片段執行回呼。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/) | 從整個簡報中擷取形狀，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以決定匯出格式時，使用 [Convert::autoByExtension](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/#autoByExtension)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/) 類別亦提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專屬方法。當您需要在匯出前檢查或修改簡報，或設定選定輔助類別未公開的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/php-java/convert-presentation/) 以了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger::process](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/#process) 以一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

當所有投影片都應直接附加至單一結果，而不需要逐一選取或重新映射時，此輔助類別適用。若需合併特定投影片、套用目標母片或版面配置、明確保留章節，或調整不同投影片尺寸，請使用完整的物件模型。請參閱 [Merge Presentations](/php-java/merge-presentation/) 以了解相關情境。

## **遍歷簡報元素**

[ForEach_] 類別會為每種請求的簡報元素類型呼叫回呼。它避免了巢狀集合迴圈，且方便用於整個簡報的檢查或格式變更。

以下範例使用 [ForEach_::slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#slide)、[ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#paragraph) 與 [ForEach_::portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#portion) 來檢查相應的元素：

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

預設情況下，簡報範圍的形狀與文字遍歷會包含普通、母片與版面投影片。具備 `includeNotes` 參數的重載亦可處理註解投影片。當遍歷順序、提前退出、在回呼前過濾，或需要細緻的父子控制很重要時，請使用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而非對每個形狀使用回呼時，請使用 [Collect::shapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/#shapes)。當相同的集合需要多次過濾、計數或處理時，這非常有用。

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

若每個形狀都能立即處理且不需要保留收集結果，請改用 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 類別可以移除未使用的結構元素並減少嵌入字型資料：

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) 移除沒有普通投影片引用的版面投影片。
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedMasterSlides) 移除不再被使用的母片投影片。
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#compressEmbeddedFonts) 從嵌入字型中移除未使用的字元。

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

先移除未使用的版面配置，再移除未使用的母片，這樣在版面清理後成為未被引用的母片也能被移除。如果日後可能需要原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報另存為新檔案。更多細節請參閱 [Slide Master](/php-java/slide-master/) 與 [Embedded Font](/php-java/embedded-font/)。

## **常見問題**

**什麼時候應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整檔案或簡報且不需要對個別元素進行細部控制時，請使用低程式碼輔助類別。若需要選取特定投影片、控制母片與版面關係、檢查中間狀態，或設定輔助類別未公開的行為，則使用完整物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger::process](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/merger/#process) 必須使用相同格式的輸入簡報。請先將輸入檔案轉換為共同格式，例如使用 [Convert::autoByExtension](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/convert/#autoByExtension)，再合併已轉換的檔案。

**ForEach_ 會處理母片、版面與註解投影片嗎？**

[ForEach_::slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#slide) 只遍歷普通的簡報投影片。整個簡報範圍的 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#paragraph) 與 [ForEach_::portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#portion) 作業預設會包含普通、母片與版面投影片。若要包含註解投影片，請使用其帶有 `includeNotes` 設為 `true` 的重載。

**ForEach_::shape 與 Collect::shapes 有何不同？**

若要透過回呼立即處理每個形狀，請使用 [ForEach_::shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/#shape)。當需要可保留、過濾、計數或多次遍歷的可疊代結果時，請使用 [Collect::shapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/collect/#shapes)。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面、未使用的母片，或含有未使用字元的嵌入字型。如果這些皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 操作可能不會減少檔案大小。

**ForEach_ 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助類別在記憶體中作用於已載入的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 物件。於 [ForEach_](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/foreach_/) 回呼中變更元素或執行 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 後，請呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 以寫入結果。

## **相關文章**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)