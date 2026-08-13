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
- 垂直分割条捕捉
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
description: "了解 Aspose.Slides for Android via Java 的视图属性，定制 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。涉及不同内容区域位置的属性。这些信息允许应用程序将视图状态保存到文件，以便在重新打开时视图保持与上次保存演示文稿时相同的状态。

已经添加了方法 [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)，用于访问演示文稿的普通视图属性。

已添加 [INormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties) 接口及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定在普通视图模式下的任意内容区域中显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定当侧边区域足够小时时，垂直分割条是否应自动贴合到最小化状态。

属性 [getPreferSingleView](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定用户是否更喜欢在全窗口单内容区域中查看，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值包括： [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、 [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定普通视图中顶部或侧边幻灯片区域的大小，当对 [getVerticalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 应用了 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 值时。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的大小（当它是 [getRestoredTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子项时为宽度，当它是 [getRestoredLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在应用程序中调整包含视图的窗口大小时，侧边内容区域的大小是否应自动适应新的尺寸。

下面的示例展示了如何访问演示文稿的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 属性。

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Aspose.Slides for Android via Java 现在支持为演示文稿设置默认缩放值，以便打开演示文稿时已经设置好缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties) 来实现。可以以编程方式设置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)。本章节将通过示例演示如何在 [Aspose.Slides](/slides/zh/) 中为 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties)。 

{{% /alert %}} 

要设置视图属性，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
2. 设置 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties)。
3. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。以下示例中，我们已经为幻灯片视图和备注视图设置了缩放值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 设置演示文稿的视图属性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 幻灯片视图的缩放百分比值
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 幻灯片备注视图的缩放百分比值 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **常见问题**

### 我可以为演示文稿的不同章节设置不同的视图设置吗？

[View settings](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getViewProperties--) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [Slide View](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而不是针对每个章节，因此在打开文档时会对整个文档应用同一套参数。

### 我可以为不同的用户预定义不同的视图状态吗？

不能。设置存储在文件中并且是共享的。查看器应用程序可以遵循用户偏好，但文件本身只包含一套视图属性。

### 我可以准备一个预定义 View Properties 的模板，使新演示文稿以相同方式打开吗？

可以。因为 [view properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getViewProperties--) 存储在演示文稿级别，你可以将它们嵌入模板中，从而使用相同的初始视图配置创建新文档。