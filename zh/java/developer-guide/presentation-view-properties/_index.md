---
title: 检索并更新 Java 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/java/presentation-view-properties/
keywords: 
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 条状态
- 维度大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **简介**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。与不同内容区域定位相关的属性。此信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持在上一次保存演示文稿时的相同状态。

方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)已添加，用于提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties)接口及其派生类，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType)枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)和[setShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定当侧边区域足够小时，竖向分割条是否应捕捉到最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--)和[setPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定用户是否更倾向于在整个窗口中只显示单一内容区域，而非具有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值为[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Maximized)和[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)和[getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)指定普通视图中顶部或侧边幻灯片区域的尺寸，当[getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)的值为[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored)时适用。

## **关于 Restoring INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（作为[getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在调整包含该视图的窗口大小时，侧边内容区域的尺寸是否应自动补偿新的大小。

下面的示例展示了如何访问演示文稿的[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getNormalViewProperties--)属性。

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
Aspose.Slides for Java 现已支持为演示文稿设置默认缩放值，以便打开演示文稿时已预设缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)来实现。[getSlideViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)都可以以编程方式进行设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中为[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。
{{% /alert %}} 

要设置视图属性，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)类的实例。  
1. 设置[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。  
1. 将演示文稿写入[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。  
   在以下示例中，我们已为幻灯片视图和备注视图设置了缩放值。

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

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)访问整个演示文稿的视图设置。[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#getGridSpacing--)和[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-)方法读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以磅为单位，1 英寸等于 72 磅。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印其当前网格间距，设置为四分之一英寸的间隔，并保存结果。

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

网格不同于[绘图参考线](/slides/zh/java/drawing-guides/)。网格间距控制规则的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会改变网格间距。

网格和绘图参考线均为编辑辅助工具。它们不会作为幻灯片内容呈现在 PDF、图像、SVG 或幻灯片放映中。存储网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **打开演示文稿时显示或隐藏批注**

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)访问整个演示文稿的视图设置。使用[IViewProperties.getShowComments](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#getShowComments--)和[IViewProperties.setShowComments](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#setShowComments-byte-)读取或更改在 PowerPoint 或其他兼容编辑器打开演示文稿时是否显示批注的存储偏好。

此设置仅控制存储的视图偏好。不添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。有关修改批注本身的操作，请参阅[Presentation Comments](/slides/zh/java/presentation-comments/)。

以下示例需要一个包含批注的现有 `comments.pptx`。它打印当前的可见性设置，要求隐藏批注，并在不删除任何批注的情况下保存新的 PPTX。示例还使用[IViewProperties.setLastView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iviewproperties/#setLastView-int-)配合[ViewType.SlideView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewtype/#SlideView)来配置初始编辑视图以及批注可见性。

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此设置不决定批注是否会包含在 PDF、HTML、图像、备注或讲义导出中。请分别配置相应的导出特定选项。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**  
文件存储了网格间距，但编辑器控制是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**  
不会。绘图参考线和网格间距是相互独立的设置。清除参考线不会影响已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**  
[视图设置](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[幻灯片视图](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而不是针对每个章节。因此，打开文档时整个文档只使用一套参数。

**我可以为不同的用户预定义不同的视图状态吗？**  
不能。设置存储在文件中并共享。查看器应用程序可能会遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个带有预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**  
可以。由于[视图属性](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)存储在演示文稿级别，您可以将其嵌入模板中，并从该模板创建新文档，从而拥有相同的初始视图配置。