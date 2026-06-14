---
title: 使用 PHP 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面配置類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習使用 Aspose.Slides for PHP via Java 以清晰的程式碼範例，快速建立與編輯 PowerPoint SmartArt，提升投影片設計與自動化效率。"
---
## **概述**

SmartArt 是由節點、節點圖形與版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for PHP via Java，您可以建立 SmartArt、從其節點讀取文字、變更版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個圖形。若要讀取可見的文字，請遍歷[SmartArt::getAllNodes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/#getAllNodes)，然後讀取由[SmartArtShape::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartshape/#getTextFrame)回傳的[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 建立 SmartArt 物件，將其變更為 `BasicProcess`，並儲存簡報。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **檢查 SmartArt 節點是否已隱藏**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/ishidden/) 表示該節點在 SmartArt 資料模型中是否被隱藏。即使所選版面配置未將其顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例在使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` 的 SmartArt 物件中加入一個節點，並檢查該節點的隱藏狀態。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 與 [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/organizationchartlayouttype/)，將子節點設定為從左側、右側或兩側懸掛。

以下範例建立一個組織圖，並將第一個節點的版面配置設為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **建立圖片組織圖**

圖片組織圖是為包含影像佔位符的層級圖表設計的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**SmartArt 是否支援針對 RTL 語言的鏡像或反轉？**

是。當所選 SmartArt 版面配置支援反轉時，[SmartArt::setReversed](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/setreversed/) 方法可將圖表方向從由左至右切換為由右至左，或反向切換。

**我該如何在同一投影片或其他簡報中複製 SmartArt 並保留格式？**

您可以使用 [ShapeCollection::addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addclone/) 複製 SmartArt 圖形，或使用 [clone the whole slide](/slides/zh-hant/php-java/clone-slides/) 複製包含 SmartArt 的整張投影片。兩種方式皆會保留大小、位置與格式。

**如何將 SmartArt 渲染為點陣圖像以供預覽或網站匯出？**

[Render the slide](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 或將整個簡報匯出為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片上有多個 SmartArt，該如何找出特定的 SmartArt 物件？**

在 SmartArt 圖形上設定唯一的 [Shape::getAlternativeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getalternativetext/) 或 [Shape::getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getname/) 值，於 [BaseSlide::getShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後確認匹配的圖形為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。