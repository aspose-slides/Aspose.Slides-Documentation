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
- 吸附垂直分割条
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
description: "了解 Aspose.Slides for PHP via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片——调整布局、缩放等级和显示设置。"
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。与不同内容区域位置相关的属性。这些信息使应用程序能够将视图状态保存到文件中，以便重新打开时视图保持在上次保存演示文稿时的相同状态。

已添加方法[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)，用于访问演示文稿的普通视图属性。

[NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties)，[NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties) 类及其派生类，以及[SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) 枚举已添加。

{{% /alert %}} 

## **关于 INormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons)和[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons)指定在普通视图模式下的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter)指定当侧边区域足够小时，垂直分割条是否应自动吸附到最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView)和[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView)指定用户是否更倾向于在全窗口单内容区域中查看，而不是标准的包含三个内容区域的普通视图。启用后，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)和[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值有[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized)和[SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)和[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop)指定在普通视图中，当对[getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)和[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)分别应用[SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored)值时，顶部或侧边幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（当作为[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)的子项时为高度），当区域处于可变的恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize)指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust)指定在应用程序中调整包含视图的窗口大小时，侧边内容区域的尺寸是否应随之自动调整以补偿新的大小。

下面的示例展示了如何访问演示文稿的[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)属性。

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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 现在支持为演示文稿设置默认缩放值，这样在打开演示文稿时缩放已被设定。可以通过设置演示文稿的[ViewProperties]来实现。[getSlideViewProperties]和[getNotesViewProperties]均可通过编程方式进行设置。在本主题中，我们将通过示例演示如何在[Aspose.Slides](/slides/zh/)中为[Presentation]设置[View Properties]。

{{% /alert %}} 

为了设置视图属性，请按以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类的实例。
1. 设置[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties)。
1. 将演示文稿写入为[PPTX ](https://docs.fileformat.com/presentation/pptx/) 文件。

在下面的示例中，我们已经为幻灯片视图和备注视图设置了缩放值。

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


## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

视图设置在演示文稿级别定义（普通视图/幻灯片视图），而不是针对每个章节，因此在打开文档时，整份文稿使用同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看器应用程序可能会尊重用户偏好，但文件本身仅包含一套视图属性。

**我可以准备一个预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。由于视图属性存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。