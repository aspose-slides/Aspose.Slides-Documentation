---
title: 检索并更新 Android 上的演示文稿视图属性
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
- 分割条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 配置 PowerPoint 演示文稿的普通视图布局、幻灯片和备注缩放、网格间距以及批注可见性。"
---
## **介绍**

在 PowerPoint 的普通视图中，幻灯片显示在侧边面板（用于缩略图或大纲）和下方的备注面板之间。Aspose.Slides for Android via Java 通过 [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) 公开了演示文稿保存的编辑首选项。这些包括面板布局、缩放级别、网格间距和批注可见性。

## **关于 INormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) 访问 [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) 接口。 [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) 控制大纲中幻灯片标题旁是否显示图标。 [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) 使侧边面板在用户收窄时自动贴合到最小化状态。 [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) 表示在整个窗口中显示单个面板的首选项。

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) 控制侧边面板与幻灯片之间的分割条。 [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) 控制备注面板上方的分割条。这两个方法均接受 [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) 的值 `Minimized`、`Maximized` 或 `Restored`。

## **关于恢复 INormalViewProperties**

当分割条被恢复时，[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) 提供侧边面板的保存大小，而 [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) 提供上部幻灯片区域的保存大小。两者都公开 [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) 控制编辑器在窗口大小更改时是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分割条，将 [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) 返回的大小设置为 80% 并启用自动调整，并将垂直分割条最大化。它还调用 [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) 在大纲视图中显示图标。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置默认缩放值**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) 和 [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) 为编辑器存储独立的缩放设置。这些设置不会影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开现有演示文稿并调用 [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) 以使幻灯片适应编辑窗口。对于备注页，它禁用自动缩放并调用 [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) 将缩放固定为 80%。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置网格间距**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 设置整个演示文稿中编辑网格线之间的距离。它接受以点为单位的正数值，1 英寸等于 72 点。此示例打印现有演示文稿中的当前间距，并通过将间隔设为 18 点保存四分之一英寸的网格。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

网格以固定间隔重复。[Drawing guides](/slides/zh/androidjava/drawing-guides/) 标记单独的水平或垂直位置。两者都是编辑辅助，仅在显示它们的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏批注**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) 存储兼容编辑器在打开演示文稿时使用的首选项。对于包含批注的现有演示文稿，此示例打印当前设置并保存一个隐藏批注的副本。它还使用 [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) 调用 [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-)，使该副本以幻灯片视图打开。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隐藏批注会保留其文本、作者、位置、回复和状态。要修改批注本身，请参阅 [Presentation Comments](/slides/zh/androidjava/presentation-comments/)。导出设置控制批注是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格被隐藏？**

演示文稿保存了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘制指南会改变网格间距吗？**

不会。添加、移动或清除指南都不会改变网格间隔。

**演示文稿的不同章节可以有不同的视图设置吗？**

不能。[Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**

文件仅存储一套视图属性供所有人使用。编辑器可能会额外应用用户的本地首选项。

**我可以在模板中保存视图设置吗？**

可以。由该模板创建的演示文稿会继承其保存的视图设置。