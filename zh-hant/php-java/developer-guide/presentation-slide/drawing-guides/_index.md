---
title: 在 PHP 中管理簡報的繪圖指引
linktitle: 繪圖指引
type: docs
weight: 85
url: /zh-hant/php-java/drawing-guides/
keywords:
- 繪圖指引
- 水平指引
- 垂直指引
- 對齊指引
- 投影片檢視
- 母片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中新增、存取與清除水平與垂直繪圖指引。"
---
## **概述**

繪圖指引是可調整的水平與垂直線條，可協助使用者在 PowerPoint 中編輯簡報時一致地對齊圖形。當應用程式產生簡報且之後需要手動微調時，它們尤其有用：應用程式可以儲存相同的對齊輔助，讓作者在新增或移動內容時遵循。

繪圖指引是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染的輸出中。Aspose.Slides for PHP via Java 透過 [DrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/) 類別公開它們。指引以 [DrawingGuide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguide/) 表示，並具有方向、位置和顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直指引使用水平座標，通常介於 0 與投影片寬度之間。水平指引使用垂直座標，通常介於 0 與投影片高度之間。

## **將指引新增至投影片檢視**

使用 [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 來管理在編輯普通投影片時顯示的指引。呼叫 [DrawingGuidesCollection::add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/#add)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/orientation/) 值以及以點為單位的位置。

以下範例會在投影片中心右側新增一條垂直指引，並在其下方新增一條水平指引：

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **存取繪圖指引**

使用 [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/#getCount) 與 [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/#get_Item) 方法可取得現有指引。[DrawingGuide::getOrientation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide::getPosition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguide/#getPosition) 與 [DrawingGuide::getColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguide/#getColor) 方法會回傳值，這些值也可以透過相應的設定子方法進行變更。

以下範例會從上述建立的簡報中讀取投影片檢視指引：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **將指引新增至母片與版面投影片**

投影片母片及其各個版面投影片皆可擁有自己的繪圖指引集合。對於母片使用 [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/#getDrawingGuides)，對於版面投影片使用 [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getDrawingGuides)。

以下範例會在第一張母片上新增一條垂直指引，並在第一張版面投影片上新增一條水平指引：

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將指引新增至備註與講義母片**

備註母片與講義母片也支援繪圖指引。使用 [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masternotesslide/#getDrawingGuides) 與 [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 取得它們的集合。如果簡報未包含其中任一母片，可使用 [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) 或 [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) 取得相應的管理器，然後使用 `setDefaultMasterNotesSlide` 或 `setDefaultMasterHandoutSlide` 建立預設母片。

以下範例會在備註母片上新增一條水平指引，並在講義母片上新增一條垂直指引：

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **清除繪圖指引**

呼叫 [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/#clear) 以移除特定集合中的所有指引。清除單一集合不會影響其他範圍內儲存的指引。

以下範例會在不建立缺少母片的情況下，清除投影片檢視指引以及投影片母片、版面投影片、備註母片與講義母片上的所有指引：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問答**

**繪圖指引會出現在投影片放映或匯出之影像中嗎？**

不會。繪圖指引是用於編輯的對齊輔助工具，不會以簡報內容的形式呈現。

**可以直接將繪圖指引新增至單一普通投影片嗎？**

普通投影片的編輯指引儲存在簡報的投影片檢視屬性中。投影片母片、版面投影片、備註母片與講義母片各有獨立的指引集合。

**指引位置使用何種單位？**

位置以點 (points) 為單位，1 英吋等於 72 點。垂直位置從左邊緣測量，水平位置則從上邊緣測量。

**清除繪圖指引會移除圖形或變更投影片內容嗎？**

不會。 [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/drawingguidescollection/#clear) 方法僅會移除所選集合中的指引。圖形與其他投影片內容保持不變。