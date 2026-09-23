---
title: 检索并更新 JavaScript 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/nodejs-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分隔条
- 单视图
- 分隔条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。与不同内容区域定位相关的属性。此信息允许应用程序将其视图状态保存到文件中，从而在重新打开时视图保持在上次保存演示文稿时的相同状态。

已添加方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 用于访问演示文稿的普通视图属性。

已添加[NormalViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewRestoredProperties) 类及其派生类，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SplitterBarStateType) 枚举。

## **关于 NormalViewProperties**

表示普通视图属性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--)和[setShowOutlineIcons](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-)指定在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-)指定当侧边区域足够小且垂直分隔条应是否捕捉到最小化状态。

属性[getPreferSingleView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--)和[setPreferSingleView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-)指定用户是否更倾向于在整个窗口中只显示单个内容区域，而不是带有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)指定水平或垂直分隔条应呈现的状态。水平分隔条将幻灯片与幻灯片下方的内容区域分开，垂直分隔条将幻灯片与侧边内容区域分开。可能的值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)和[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)和[getRestoredTop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)指定在对[getVerticalBarState](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)和[getHorizontalBarState](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)分别应用[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SplitterBarStateType#Restored)值时，普通视图的顶部或侧边幻灯片区域的尺寸。

## **关于 Restoring NormalViewProperties**

指定普通视图中幻灯片区域的尺寸（作为[getRestoredTop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)的子项时为宽度，作为[getRestoredLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)的子项时为高度），当该区域处于可变的已恢复大小（既非最小化也非最大化）时。

方法[getDimensionSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--)指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--)指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应补偿新的大小。

下面的示例展示了如何访问演示文稿的[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)属性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java 现已支持为演示文稿设置默认缩放值，以便在打开演示文稿时已应用缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties)来实现。[getSlideViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--)都可以以编程方式进行设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中为[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation)设置[视图属性](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

设置视图属性请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation)类的实例。  
2. 为[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation)设置[视图属性](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ViewProperties)。  
3. 将演示文稿写入为[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。  
   在下面的示例中，我们已为幻灯片视图以及备注视图设置了缩放值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **设置网格间距**

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getViewProperties--)访问全局视图设置。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--)和[ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-)方法读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，这符合 API 文档的要求。

以下示例打开现有的 `demo.pptx`，打印当前网格间距，将间隔设置为四分之一英寸，并保存结果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

网格不同于[绘图指南](/slides/zh/nodejs-java/drawing-guides/)。网格间距控制规则的间隔，而绘图指南是单独定位的水平或垂直对齐线。添加、移动或清除绘图指南不会改变网格间距。

网格和绘图指南均为编辑辅助工具。它们不会在 PDF、图像、SVG 或放映中作为幻灯片内容呈现。存储网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **打开演示文稿时显示或隐藏批注**

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getViewProperties--)访问全局视图设置。使用[ViewProperties.getShowComments](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#getShowComments--)和[ViewProperties.setShowComments](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-)读取或更改存储的首选项，以决定在 PowerPoint 或其他兼容编辑器打开演示文稿时是否显示批注。

此设置仅控制存储的视图首选项。它不添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。有关更改批注本身的操作，请参阅[演示文稿批注](/slides/zh/nodejs-java/presentation-comments/)。

下面的示例需要一个包含批注的现有 `comments.pptx`。它打印当前的可见性设置，要求隐藏批注，并在不删除任何批注的情况下保存新的 PPTX。示例还使用[ViewProperties.setLastView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#setLastView-int-)与[ViewType.SlideView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewtype/#SlideView)一起配置初始编辑视图以及批注可见性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此设置不决定批注是否会包含在 PDF、HTML、图像、备注或讲义导出中。请分别配置相关的导出特定选项。

## **常见问题解答**

**重新打开演示文稿后网格为何不可见？**

文件会存储网格间距，但编辑器控制是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图指南会改变网格间距吗？**

不会。绘图指南和网格间距是相互独立的设置。清除指南不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getviewproperties/)在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)、[幻灯片视图](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)），而不是按章节，因此在打开文档时整个文档只会使用一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并且是共享的。查看器应用程序可以遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个带有预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。由于[视图属性](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getviewproperties/)存储在演示文稿级别，您可以将其嵌入模板，并基于该模板创建新文档，以获得相同的初始视图配置。