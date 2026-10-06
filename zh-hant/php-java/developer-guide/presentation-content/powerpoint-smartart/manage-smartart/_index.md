---
title: 使用 PHP 在 PowerPoint 簡報中管理 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習使用 Aspose.Slides for PHP via Java，透過清晰的程式碼範例快速建立與編輯 PowerPoint SmartArt，以加速投影片設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和版面組成的 PowerPoint 圖表。使用 Aspose.Slides for PHP via Java，您可以建立 SmartArt、從其節點讀取文字、變更版面、檢查隱藏節點、設定組織圖版面，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。要從節點形狀讀取文字，請遍歷 [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/)，然後讀取由 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) 回傳的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。

此範例需要一個至少包含一張投影片且在該投影片上第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框列印到主控台。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **變更 SmartArt 物件的版面類型**

SmartArt 版面決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，然後儲存簡報。傳遞給 [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) 的位置與大小以點為單位。使用 [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) 可變更版面。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) 表示節點在 SmartArt 資料模型中是否被隱藏。即使所選版面不將其顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查該新增節點的隱藏狀態。如果節點為隱藏，會列印訊息，並儲存圖表。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **取得或設定組織圖版面**

對於使用組織圖版面的 SmartArt 圖表，[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 與 [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的版面設為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 代表第一個最高層節點；其子節點會使用所選的排列方式。最後儲存已修改的簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **建立圖片組織圖**

圖片組織圖是一種為包含影像佔位元的階層圖而設計的 SmartArt 版面。在將 SmartArt 物件加入投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。此範例儲存包含影像佔位元的圖表；不會將影像填入佔位元。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將舊版圖表轉換為形狀群組**

在現代化現有簡報時，您可能需要更新最初於 PowerPoint 97–2003 建立的組織圖。Aspose.Slides 將這些舊版圖表表示為 [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) 物件。使用 [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) 可將圖表轉換為形狀群組，以便編輯個別視覺元素。詳細資訊請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/)。

轉換會在形狀集合中新增一個群組，而不會移除原始圖表。轉換成功後，請使用 [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) 移除原始圖表，以避免重複內容。在轉換之前，先將舊版圖表收集到清單中，避免在加入與移除形狀時中斷迭代。

以下範例開啟簡報，搜尋每張投影片，將圖表轉換為形狀群組，並將更新後的簡報儲存為 PPTX。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

儲存的簡報會以可編輯的形狀群組取代轉換後的舊版圖表，且不會保留原始圖表。於 PowerPoint 開啟 PPTX，即可編輯每個群組內的個別元素，例如文字、填充或位置。

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反向？**

是。當所選 SmartArt 版面支援反轉時，[SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) 方法會將圖表方向從左至右切換為右至左，或反向回切換。

**如何在同一投影片或其他簡報中複製 SmartArt 同時保留格式？**

您可以使用 [複製 SmartArt 形狀](/slides/zh-hant/php-java/shape-manipulations/) 搭配 [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) 或 [複製整張投影片](/slides/zh-hant/php-java/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方式皆可保留大小、位置與格式。

**如何將 SmartArt 渲染為點陣圖以供預覽或網路匯出？**

您可以 [渲染投影片](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 或將整個簡報渲染為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片上有多個 SmartArt，如何找出特定的 SmartArt 物件？**

使用 [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) 或 [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) 為 SmartArt 形狀設定獨特的替代文字或名稱，於 [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後確認匹配的形狀是 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。