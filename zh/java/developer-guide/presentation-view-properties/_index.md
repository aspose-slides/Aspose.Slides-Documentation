---
title: 在 Java 中检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/java/presentation-view-properties/
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
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的视图属性，以自定义 PPT、PPTX 和 ODP 格式的幻灯片——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。属性涉及不同内容区域的位置。这些信息使应用程序能够将视图状态保存到文件中，从而在重新打开时视图保持在上次保存时的相同状态。

方法 [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) 已添加，以提供对演示文稿普通视图属性的访问。

已添加 [INormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties) 接口及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定当侧边区域足够小时，垂直分割条是否应自动收缩至最小状态。

属性 [getPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定用户是否更倾向于在单窗口显示单一内容区域，而不是标准的包含三个内容区域的普通视图。启用后，应用程序可以选择在整个窗口中显示其中的一个内容区域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与其下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值为 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定在对 [getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 均应用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored) 时，普通视图的侧边或上方幻灯片区域的尺寸。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（当是 [getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子项时为高度），当该区域处于可变的恢复尺寸（既非最小化也非最大化）时。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应随之自动补偿。

下面的示例展示了如何访问演示文稿的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) 属性。

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

Aspose.Slides for Java 现已支持为演示文稿设置默认缩放值，使得打开演示文稿时已预先设定缩放比例。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties) 实现。[getSlideViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) 都可以通过代码进行设置。在本节中，我们将通过示例演示如何在 Aspose.Slides 中为 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

要设置视图属性，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类的实例。
1. 为 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。
1. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。以下示例中，我们已为幻灯片视图和备注视图设置了缩放值。

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

## **设置网格间距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--) 访问整个演示文稿的视图设置。通过 [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#getGridSpacing--) 和 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 方法读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印当前的网格间距，将间隔设为四分之一英寸，然后保存结果。

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

网格不同于 [drawing guides](/slides/zh/java/drawing-guides/)。网格间距控制的是规则的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间距。

网格和绘图参考线都是编辑辅助工具。它们不会以幻灯片内容的形式渲染到 PDF、图像、SVG 或幻灯片放映中。存储网格间距并不保证编辑器一定会显示网格：其可见性同样取决于查看器或编辑器的偏好设置。

## **常见问题**

**为什么重新打开演示文稿后网格不显示？**

文件会保存网格间距，但是否显示网格由编辑器控制。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**

不会。绘图参考线和网格间距是相互独立的设置。清除参考线不会影响已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[View settings](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--) 在演示文稿层级定义（[Normal View](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而不是按章节划分。因此，打开文档时整个文件使用的是同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并且是共享的。查看器应用程序可以尊重用户偏好，但文件本身只包含一套视图属性。

**我能否创建包含预定义视图属性的模板，以便新演示文稿以相同方式打开？**

可以。由于 [view properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--) 存储在演示文稿层级，你可以将它们嵌入模板中，随后基于该模板创建的新文档会继承相同的初始视图配置。