---
title: 在 Android 上检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/androidjava/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 自动折叠垂直分割条
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。用于定位不同内容区域的属性。此信息使应用程序能够将视图状态保存到文件中，以便重新打开时视图保持在上次保存演示文稿时的相同状态。

已添加方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties)接口及其子接口，以及[SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType)枚举。

{{% /alert %}} 

## **关于 INormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)和[setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定当侧边区域足够小时，垂直分割条是否应自动折叠至最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--)和[setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定用户是否偏好在整个窗口中只显示单个内容区域，而不是标准的三区域普通视图。启用后，应用程序可能会在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割条应呈现的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)和[SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)和[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)在[getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)分别返回[SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored)状态时，侧边或顶部幻灯片区域的尺寸。

## **关于 Restoring INormalViewProperties**

指定普通视图中幻灯片区域（当作为[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子项时表示宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子项时表示高度）的尺寸，当该区域处于可变的恢复大小（即既未最小化也未最大化）时的尺寸。

方法[getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应自动补偿新的大小。

下面的示例展示了如何访问[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)以获取演示文稿的属性。
```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // 恢复演示文稿的视图属性
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **设置默认缩放值**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 现已支持为演示文稿设置默认缩放值，以便在打开演示文稿时已设置缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)来实现。可以以编程方式设置[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)和[getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)。在本章节中，我们将通过示例演示如何在[Aspose.Slides](/slides/zh/)中为[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

设置视图属性的步骤如下：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 为[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)。
1. 将演示文稿写入[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。下面的示例中，我们已为幻灯片视图和备注视图分别设置了缩放值。
```java
Presentation presentation = new Presentation();
try {
    // 设置演示文稿的视图属性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 幻灯片视图的缩放值（百分比）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 备注视图的缩放值（百分比）

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--)在演示文稿层级（[普通视图](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[幻灯片视图](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)）定义，而不是按章节定义，因此单套参数适用于整个文档的打开。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并对所有用户共享。查看器应用程序可以尊重用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个带有预定义视图属性的模板，使新建演示文稿以相同方式打开吗？**

可以。因为[视图属性](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--)存储在演示文稿层级，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。