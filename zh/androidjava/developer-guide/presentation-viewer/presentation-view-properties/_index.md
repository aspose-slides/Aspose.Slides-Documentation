---
title: 演示视图属性
type: docs
url: /androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、一个侧边内容区域和一个底部内容区域。与不同内容区域的位置有关的属性。这些信息使应用程序能够将其视图状态保存到文件中，以便在重新打开时视图与上次保存的演示文稿时是一致的。

方法 [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) 已添加以提供对演示文稿普通视图属性的访问。 

[**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties)、 [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties)接口及其子类、 [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) 枚举已添加。

{{% /alert %}} 


## **关于 INormalViewProperties** #
表示普通视图属性。

方法 [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 和 [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定应用程序是否应在普通视图模式的任何内容区域中显示轮廓内容时显示图标。

方法 [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 和 [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定垂直分隔条在侧边区域足够小时是否应贴合到最小化状态。

属性 [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 和 [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定用户是否更喜欢在标准普通视图中的三个内容区域上查看全窗口的单个内容区域。如果启用，应用程序可以选择在整个窗口中显示其中一个内容区域。

方法 [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分隔条应显示的状态。水平分隔条将幻灯片与幻灯片下方的内容区域分开，垂直分隔条将幻灯片与侧边内容区域分开。可能的值为：[**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 和 [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法 [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 和 [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定普通视图的顶部或侧边幻灯片区域的大小，当 [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 值应用于 [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 时。

## **关于恢复 INormalViewProperties** 
指定普通视图的幻灯片区域的大小（作为 [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子项时为宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子项时为高度），当区域的恢复大小为可变时（既不是最小化也不是最大化）。

方法 [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

方法 [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应补偿新大小

以下示例展示了如何访问 [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 属性以获取演示文稿。

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
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

Aspose.Slides for Android via Java 现在支持为演示文稿设置默认缩放值，以便在打开演示文稿时，缩放已设置好。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) 来完成。 [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) 和 [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) 可以通过编程方式设置。在本主题中，我们将通过示例查看如何设置 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

为了设置视图属性，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 设置 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)。
3. 将演示文稿写入 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 文件。
   在下面的示例中，我们为幻灯片视图和备注视图设置了缩放值。

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation();
try {
    // 设置演示文稿的视图属性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 幻灯片视图的缩放值（以百分比表示）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 备注视图的缩放值（以百分比表示）

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```