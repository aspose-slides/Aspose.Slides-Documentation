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
- 捕捉垂直分割条
- 单视图
- 栏状态
- 维度大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 配置 PowerPoint 演示文稿的普通视图布局、幻灯片和备注的缩放、网格间距以及评论可见性。"
---
## **介绍**

在 PowerPoint 的普通视图中，幻灯片位于侧边窗格（用于缩略图或大纲）和下面的备注窗格之间。Aspose.Slides for Node.js via Java 通过 [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) 公开演示文稿的已保存编辑首选项。这些包括窗格布局、缩放级别、网格间距和评论可见性。

## **关于 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) 访问 [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) 类。[setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 控制是否在大纲中的幻灯片标题旁显示图标。[setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 使侧边窗格在用户收窄时自动捕捉到其最小化状态。[setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) 表示在整个窗口中只显示一个窗格的偏好。

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) 控制侧边窗格与幻灯片之间的分隔条。[setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) 控制备注窗格上方的分隔条。这两者都接受一个 [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) 的值，可为 `Minimized`、`Maximized` 或 `Restored`。

## **关于恢复 NormalViewProperties**

当分隔条被恢复时，[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) 提供侧边窗格的已保存大小，而 [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) 提供上部幻灯片区域的已保存大小。两者均公开 [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) 控制在窗口大小改变时编辑器是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分隔条，将由 [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) 返回的大小设置为 80% 并启用自动调整，并将垂直分隔条最大化。它还调用 [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 在大纲视图中显示图标。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置默认缩放值**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) 为编辑器存储独立的缩放设置。这些设置不会影响幻灯片尺寸、幻灯片放映播放或图像导出的分辨率。

此示例打开现有演示文稿并调用 [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) 以适应编辑窗口的幻灯片。对于备注页，它禁用自动缩放并调用 [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) 将固定的 80% 缩放设置。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置网格间距**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) 设置整个演示文稿中编辑网格线之间的距离。它接受正数值（单位为点），每英寸 72 点。此示例打印现有演示文稿中的当前间距，并通过将间隔设为 18 点（四分之一英寸）来保存网格。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

网格以固定间隔重复。[绘图指南](/slides/zh/nodejs-java/drawing-guides/) 标记单个水平或垂直位置。两者都是编辑辅助，仅在显示它们的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏评论**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) 存储兼容编辑器在打开演示文稿时使用的首选项。对于包含评论的现有演示文稿，此示例打印当前设置并保存一份隐藏评论的副本。它还调用 [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) 并使用 [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) 使副本在幻灯片视图中打开。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隐藏评论会保留其文本、作者、位置、回复和状态。要更改评论本身，请参阅 [演示文稿评论](/slides/zh/nodejs-java/presentation-comments/)。导出设置决定评论是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格会隐藏？**

演示文稿会存储网格间隔。要看到网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**

不会。添加、移动或清除指南均不会更改网格间隔。

**演示文稿的不同部分可以有不同的视图设置吗？**

不会。[Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**

文件仅为所有人存储一套视图属性。编辑器也可能应用用户的本地首选项。

**我可以在模板中保存视图设置吗？**

可以。从模板创建的演示文稿会继承其已保存的视图设置。