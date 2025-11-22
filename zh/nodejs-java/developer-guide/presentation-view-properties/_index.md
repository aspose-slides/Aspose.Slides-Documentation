---
title: 演示文稿视图属性
type: docs
weight: 80
url: /zh/nodejs-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- 演示文稿
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "在 JavaScript 中管理 PowerPoint 演示文稿视图属性"
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。属性涉及不同内容区域的位置。此信息使应用程序能够将视图状态保存到文件中，从而在重新打开时视图保持与上次保存演示文稿时相同的状态。

已添加方法[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)，用于访问演示文稿的普通视图属性。

已添加[NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) 类及其子类，以及[SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType) 枚举。

{{% /alert %}} 

## **关于 NormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--)和[setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-)指定在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-)指定当侧边区域足够小时，垂直分割条是否应自动折叠至最小状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--)和[setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-)指定用户是否更倾向于在单窗口中仅显示一个内容区域，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值有[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)和[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)和[getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)在[getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)的状态为[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored)时，指定普通视图中顶部或侧边幻灯片区域的尺寸。

## **关于恢复 NormalViewProperties** 

指定普通视图中幻灯片区域的尺寸（当作为[getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--)指定幻灯片区域的尺寸（当作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--)指定在应用程序内调整包含视图的窗口大小时，侧边内容区域的尺寸是否应自动补偿新的大小。

下面的示例演示了如何访问演示文稿的[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)属性。

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // 恢复演示文稿的视图属性
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **设置默认缩放值**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 现已支持为演示文稿设置默认缩放值，以便打开演示文稿时已应用该缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties)来实现。[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--)和[getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--)均可通过代码进行设置。本节将通过示例演示如何在[Aspose.Slides](/slides/zh/)中为[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

要设置视图属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 设置 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 的[View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties)。
1. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。下面的示例中，我们已经为幻灯片视图和备注视图设置了缩放值。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 设置演示文稿的视图属性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 幻灯片视图的缩放值（百分比）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 备注视图的缩放值（百分比）
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/)在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[幻灯片视图](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)），而不是针对每个章节。因此，在打开文档时，所有章节都使用同一组参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并会被共享。查看器应用程序可能会遵循用户偏好，但文件本身仅包含一套视图属性。

**我能准备一个带有预定义视图属性的模板，以便新建演示文稿时以相同方式打开吗？**

可以。由于[视图属性](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/)存储在演示文稿级别，您可以将其嵌入模板中，后续基于该模板创建的新文档将拥有相同的初始视图配置。