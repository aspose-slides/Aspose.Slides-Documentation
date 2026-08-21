---
title: 在 PHP 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/php-java/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 布局幻灯片
- 备注母版
- 讲义母版
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **Overview**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终保持形状对齐。当应用程序生成演示文稿后需要手动细化时，它们尤其有用：应用程序可以保存相同的对齐辅助，供作者在添加或移动内容时遵循。

绘图参考线是编辑辅助工具，而不是幻灯片内容。它们不会出现在幻灯片放映或渲染输出中。Aspose.Slides for PHP via Java 通过 [DrawingGuidesCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/) 类公开这些参考线。每个参考线由 [DrawingGuide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguide/) 表示，具有方向、位置和颜色。

位置以点（points）为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在 0 到幻灯片宽度之间。水平参考线使用垂直坐标，通常在 0 到幻灯片高度之间。

## **Add Guides to the Slide View**

使用 [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 来管理在编辑普通幻灯片时显示的参考线。调用 [DrawingGuidesCollection::add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/#add)，并提供一个 [Orientation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/orientation/) 值和以点为单位的位置。

下面的示例在幻灯片中心右侧添加一条垂直参考线，在其下方添加一条水平参考线：
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

## **Access Drawing Guides**

[DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/#getCount) 和 [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/#get_Item) 方法可访问现有参考线。[DrawingGuide::getOrientation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide::getPosition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguide/#getPosition) 和 [DrawingGuide::getColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguide/#getColor) 方法返回的值也可以通过对应的 setter 方法进行更改。

下面的示例读取上述创建的演示文稿中的幻灯片视图参考线：
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

## **Add Guides to Master and Layout Slides**

幻灯片母版及其每个布局幻灯片都可以拥有自己的绘图参考线集合。对母版幻灯片使用 [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/#getDrawingGuides)，对布局幻灯片使用 [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#getDrawingGuides)。

下面的示例在第一张母版幻灯片上添加一条垂直参考线，在第一张布局幻灯片上添加一条水平参考线：
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

## **Add Guides to Notes and Handout Masters**

备注母版和讲义母版也支持绘图参考线。使用 [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslide/#getDrawingGuides) 和 [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 访问它们的集合。如果演示文稿不包含这些母版，可通过 [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) 或 [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) 获取相应管理器，然后使用 `setDefaultMasterNotesSlide` 或 `setDefaultMasterHandoutSlide` 创建默认母版。

下面的示例在备注母版上添加一条水平参考线，在讲义母版上添加一条垂直参考线：
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

## **Clear Drawing Guides**

调用 [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/#clear) 可移除特定集合中的所有参考线。清除一个集合不会影响存储在其他范围中的参考线。

下面的示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及幻灯片母版、布局幻灯片、备注母版和讲义母版上的全部参考线：
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

## **FAQ**

**绘图参考线会出现在幻灯片放映或导出的图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助，不会作为演示内容渲染。

**可以直接向单个普通幻灯片添加绘图参考线吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。幻灯片母版、布局幻灯片、备注母版和讲义母版各自拥有独立的参考线集合。

**参考线位置使用什么单位？**

位置以点为单位，72 点等于一英寸。垂直位置相对于左边缘测量，水平位置相对于顶部测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。[DrawingGuidesCollection::clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/drawingguidescollection/#clear) 方法仅移除选定集合中的参考线，形状和其他幻灯片内容保持不变。