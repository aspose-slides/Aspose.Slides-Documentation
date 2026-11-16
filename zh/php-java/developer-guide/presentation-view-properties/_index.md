---
title: 检索并更新 PHP 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/php-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 垂直分割条捕捉
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 配置 PowerPoint 演示文稿的普通视图布局、幻灯片和备注的缩放、网格间距以及评论可见性。"
---
## **介绍**

在 PowerPoint 的普通视图中，幻灯片位于缩略图或大纲的侧窗格和下面的备注窗格之间。Aspose.Slides for PHP via Java 通过 [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/)公开了演示文稿保存的编辑首选项。它们包括窗格布局、缩放级别、网格间距和评论可见性。

## **关于 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) 访问 [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) 类。[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) 控制是否在大纲中的幻灯片标题旁显示图标。[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) 允许当用户收窄侧窗格时将其自动缩至最小状态。[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) 表示在完整窗口中显示单个窗格的首选项。

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) 控制侧窗格与幻灯片之间的分隔条。[setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) 控制备注窗格上方的分隔条。两者均接受 [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **关于 恢复 NormalViewProperties**

当分隔条被恢复时，[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) 提供侧窗格的保存大小，而 [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) 提供上部幻灯片区域的保存大小。两者都暴露 [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) 控制编辑器在窗口大小改变时是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分隔条，将 [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) 返回的大小设置为 80% 并启用自动调整，并将垂直分隔条最大化。同时调用 [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) 在大纲视图中显示图标。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置默认缩放值**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) 和 [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) 为编辑器存储独立的缩放设置。这些设置不会影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开现有演示文稿并调用 [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) 将幻灯片适配到编辑窗口。对于备注页，它禁用自动缩放并调用 [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) 将缩放固定为 80%。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置网格间距**

`setGridSpacing` 方法来自 [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) 用于设置整个演示文稿中编辑网格线之间的距离。它接受正数（单位为点），每英寸 72 点。此示例打印现有演示文稿中的当前间距，并通过将间隔设置为 18 点来保存四分英寸的网格。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

网格以固定间隔重复。[Drawing guides](/slides/zh/php-java/drawing-guides/) 标记单独的水平或垂直位置。两者都是编辑辅助，仅在支持显示的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏评论**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) 存储兼容编辑器在打开演示文稿时使用的首选项。对于包含评论的现有演示文稿，此示例打印当前设置并保存一个隐藏评论的副本。它还调用 [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) 并传入 [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView)，使副本以幻灯片视图打开。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

隐藏评论会保留其文本、作者、位置、回复和状态。若要更改评论本身，请参阅 [Presentation Comments](/slides/zh/php-java/presentation-comments/)。导出设置决定评论是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格会隐藏？**

演示文稿保存了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**

不会。添加、移动或清除指南都不会改变网格间隔。

**演示文稿的不同章节可以有不同的视图设置吗？**

不能。[Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**

文件仅为所有人存储一套视图属性。编辑器还可能应用用户的本地首选项。

**我可以在模板中保存视图设置吗？**

可以。使用该模板创建的演示文稿会继承其保存的视图设置。