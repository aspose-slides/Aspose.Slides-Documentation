---
title: 在 PHP 中检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/php-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单一视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 格式的幻灯片——调整布局、缩放级别和显示设置。"
---
## **简介**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。涉及不同内容区域定位的属性。这些信息允许应用程序将其视图状态保存到文件中，以便在重新打开时，视图保持与上次保存演示文稿时相同的状态。

已添加方法 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 以提供对演示文稿普通视图属性的访问。

已添加[NormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties)类及其后代，[SplitterBarStateType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType)枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons)和[setShowOutlineIcons](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons)指定在普通视图模式下的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter)指定当侧边区域足够小时时，垂直分割条是否应自动捕捉到最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView)和[setPreferSingleView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView)指定用户是否更倾向于在整个窗口中查看单一内容区域，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值有：[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Maximized)和[SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)和[getRestoredTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties#getRestoredTop)指定在对[getVerticalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)分别应用[SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Restored)值时，普通视图的顶部或侧边幻灯片区域的尺寸。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的大小（当作为[getRestoredTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize)指定幻灯片区域的大小（作为restoredTop的子项时为宽度，作为restoredLeft的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust)指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应自动补偿新的尺寸。

下面的示例展示了如何访问演示文稿的[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)属性。

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # 恢复演示文稿的视图属性
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **设置默认缩放值**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java 现在支持为演示文稿设置默认缩放值，这样在打开演示文稿时缩放已预设。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties)来实现。可以以编程方式设置[getSlideViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中为[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties)。 

{{% /alert %}} 

要设置视图属性，请按以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation)类的实例。
1. 设置[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties)。
1. 将演示文稿写入为 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 文件。

   在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

```php
  $presentation = new Presentation();
  try {
    # 设置演示文稿的视图属性
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 幻灯片视图的缩放值（百分比）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 备注视图的缩放值（百分比）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **设置网格间距**

使用[Presentation::getViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getViewProperties)可访问整个演示文稿的视图设置。[ViewProperties::getGridSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#getGridSpacing)和[ViewProperties::setGridSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#setGridSpacing)方法读取或修改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以点为单位指定，72 点等于一英寸。请使用正值，符合 API 文档的要求。

以下示例打开现有的 `demo.pptx`，打印其当前网格间距，设置四分之一英寸的间隔，并保存结果。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

网格不同于[绘图参考线](/slides/zh/php-java/drawing-guides/)。网格间距控制规则的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间距。

网格和绘图参考线都是编辑辅助工具。它们在 PDF、图像、SVG 或幻灯片放映中不会作为幻灯片内容渲染。保存网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**

文件保存了网格间距，但是否显示网格由编辑器决定。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**

不会。绘图参考线和网格间距是独立的设置。清除参考线不会改变已存储的网格间隔。

**我能为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getviewproperties/)在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[幻灯片视图](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/getslideviewproperties/)），而不是按章节划分，因此在打开文档时，整个文档使用同一套参数。

**我能为不同用户预定义不同的视图状态吗？**

不能。设置保存在文件中且是共享的。查看器应用程序可能会遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个带预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。由于[视图属性](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getviewproperties/)存储在演示文稿级别，您可以将其嵌入模板，在此基础上创建新文档，保持相同的初始视图配置。