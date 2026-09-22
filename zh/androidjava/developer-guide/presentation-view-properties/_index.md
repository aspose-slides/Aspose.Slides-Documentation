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
- 捕捉垂直分割条
- 单视图
- 栏状态
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
## **Introduction**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关这些不同内容区域定位的属性信息使应用程序能够将视图状态保存到文件中，从而在重新打开时视图保持与上次保存演示文稿时相同的状态。

已添加方法 [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供对演示文稿普通视图属性的访问。

已添加接口 [INormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties)，[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties) 以及它们的派生类，枚举 [SplitterBarStateType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType)。

## **About INormalViewProperties**

表示普通视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定当侧边区域足够小时，垂直分割条是否应捕捉到最小化状态。

属性 [getPreferSingleView](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定用户是否更倾向于在整个窗口中只显示单个内容区域，而不是标准的三内容区域普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与其下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的值包括 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定在对 [getVerticalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 应用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 值时，普通视图的侧边或顶部幻灯片区域的大小。

## **About Restoring INormalViewProperties**

指定普通视图中幻灯片区域的大小（作为 [getRestoredTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子项时为高度），当该区域处于可变的恢复大小（既不是最小化也不是最大化）时。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定幻灯片区域的尺寸（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应补偿新的尺寸。

下面的示例演示如何访问演示文稿的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 属性。

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

## **Set the Default Zoom Value**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java 现在支持为演示文稿设置默认缩放值，从而在打开演示文稿时已自动设定缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties) 实现。可以以编程方式设置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中为 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

设置视图属性的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
1. 为 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ViewProperties)。
1. 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。下面的示例中我们同时设置了幻灯片视图和备注视图的缩放值。

```java
import com.aspose.slides.*;

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

## **Set the Grid Spacing**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getViewProperties--) 访问全局视图设置。方法 [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) 和 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 用于读取或更改底层编辑网格的间隔。此设置作用于整个演示文稿，而不是单个幻灯片。网格间隔以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印当前网格间隔，将其设置为四分之一英寸的间隔，并保存结果。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

网格不同于 [drawing guides](/slides/zh/androidjava/drawing-guides/)。网格间隔控制规则的间距，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间隔。

网格和绘图参考线都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容呈现。存储网格间隔并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**

文件会存储网格间隔，但编辑器决定是否显示网格。请检查编辑器的网格可见性设置。

**Does clearing drawing guides change the grid spacing?**

不会。绘图参考线和网格间隔是相互独立的设置。清除参考线不会改变已存储的网格间隔。

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getViewProperties--) 在演示文稿层级定义（[Normal View](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而不是按章节划分，因此在打开文档时整个文档只使用一套参数。

**Can I predefine different view states for different users?**

不能。设置存储在文件中并共享。查看器应用程序可能会遵循用户偏好，但文件本身只包含一套视图属性。

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

可以。因为 [view properties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getViewProperties--) 存储在演示文稿层级，您可以将其嵌入模板中，以便从该模板创建的新文档拥有相同的初始视图配置。