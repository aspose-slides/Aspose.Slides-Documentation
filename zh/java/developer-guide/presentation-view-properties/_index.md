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
- 捕捉垂直分割栏
- 单视图
- 栏状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关不同内容区域定位的属性。这些信息使应用程序能够将视图状态保存到文件中，以便重新打开时视图保持与上次保存演示文稿时相同的状态。

已添加方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)，用于访问演示文稿的普通视图属性。

已添加[INormalViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties)接口及其派生类，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType)枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)和[setShowOutlineIcons](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定当侧边区域足够小时时，垂直分割栏是否应自动收起到最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--)和[setPreferSingleView](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定用户是否更倾向于在整个窗口中查看单一内容区域，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割栏的显示状态。水平分割栏将幻灯片与幻灯片下方的内容区域分隔，垂直分割栏将幻灯片与侧边内容区域分隔。可能的取值有[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Maximized)和[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)和[getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)在对[getVerticalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)分别应用[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SplitterBarStateType#Restored)值时，指定普通视图中顶部或侧边幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（当作为[getRestoredTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定幻灯片区域的大小（当为restoredTop的子项时为宽度，为restoredLeft的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应自动调整以适应新的大小。

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
Aspose.Slides for Java 现在支持为演示文稿设置默认缩放值，打开演示文稿时即已设置缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)来实现。[getSlideViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)均可以编程方式进行设置。在本主题中，我们将通过示例演示如何在[Aspose.Slides](/slides/zh/)中为[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。 
{{% /alert %}} 

要设置视图属性，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)类的实例。
1. 为[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)设置[View Properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ViewProperties)。
1. 将演示文稿写入[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。  
   在下面的示例中，我们已经为幻灯片视图和备注视图设置了缩放值。

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
## **常见问题**

### 我可以为演示文稿的不同章节设置不同的视图设置吗？

[View settings](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而不是按章节定义，因此在打开文档时整篇文稿使用同一套参数。

### 我可以为不同用户预定义不同的视图状态吗？

不能。设置存储在文件中并且是共享的。查看器应用程序可能会尊重用户偏好，但文件本身只包含一套视图属性。

### 我可以准备一个预定义 View Properties 的模板，使新演示文稿以相同的方式打开吗？

可以。因为[view properties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getViewProperties--)存储在演示文稿级别，您可以将其嵌入模板中，并基于该模板创建新文档，从而拥有相同的初始视图配置。