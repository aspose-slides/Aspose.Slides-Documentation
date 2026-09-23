---
title: 检索并更新 PHP 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/php-java/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **简介**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关不同内容区域定位的属性。这些信息使应用程序能够将视图状态保存到文件中，以便重新打开时视图保持为上次保存演示文稿时的相同状态。

已添加方法 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) ，以提供对演示文稿普通视图属性的访问。

已添加 [NormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties) 类及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

[Methods getShowOutlineIcons](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) 指定在普通视图模式下的任意内容区域显示大纲内容时，应用程序是否应显示图标。

[Methods getSnapVerticalSplitter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) 指定当侧边区域足够小且垂直分割条应是否自动折叠到最小状态。

属性 [getPreferSingleView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) 指定用户是否倾向于在整个窗口中仅显示单一内容区域，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中的一个内容区域。

[Methods getVerticalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 指定水平或垂直分割条应呈现的状态。水平分割条将幻灯片与其下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值有： [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Minimized) 、 [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Maximized) 和 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Restored)。

[Methods getRestoredLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 和 [getRestoredTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties#getRestoredTop) 在对 [getVerticalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 分别应用 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SplitterBarStateType/#Restored) 值时，指定普通视图顶部或侧边幻灯片区域的尺寸。

## **关于 Restoring INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（作为 [getRestoredTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) 的子项时表示宽度，作为 [getRestoredLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 的子项时表示高度），当该区域采用可变的恢复大小（既非最小化也非最大化）时。

[Method getDimensionSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) 指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

[Method getAutoAdjust](https://reference.aspose.com/slides/zh/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) 指定在调整包含视图的窗口大小时，侧边内容区域的尺寸是否应自动补偿新的尺寸。

下面的示例演示如何访问演示文稿的 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 属性。

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # 恢复演示文稿的视图属性
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **设置默认缩放值**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java 现已支持为演示文稿设置默认缩放值，使得打开演示文稿时已预先设置缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties) 来实现。可以以编程方式设置 [getSlideViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) 和 [getNotesViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中为 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 设置 [View Properties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

设置视图属性的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 类的实例。  
2. 设置 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ViewProperties)。  
3. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。  

下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

```php
  $presentation = new Presentation();
  try {
    # 设置演示文稿的视图属性
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 幻灯片视图的缩放值（百分比）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 备注视图的缩放值（百分比）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **设置网格间距**

使用 [Presentation::getViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getViewProperties) 访问演示文稿级别的视图设置。 [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#getGridSpacing) 和 [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#setGridSpacing) 方法读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，符合 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，打印其当前网格间距，将间隔设置为四分之一英寸，然后保存结果。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

网格不同于 [drawing guides](/slides/zh/php-java/drawing-guides/)。网格间距控制规则的间隔，而绘图指南是单独定位的水平或垂直对齐线。添加、移动或清除绘图指南不会改变网格间距。

网格和绘图指南都是编辑辅助工具。它们不会在 PDF、图像、SVG 或幻灯片放映中作为幻灯片内容渲染。存储网格间距并不保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **打开演示文稿时显示或隐藏批注**

使用 [Presentation::getViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getviewproperties/) 访问演示文稿级别的视图设置。使用 [ViewProperties::getShowComments](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/getshowcomments/) 和 [ViewProperties::setShowComments](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/setshowcomments/) 读取或更改在 PowerPoint 或其他兼容编辑器打开演示文稿时是否应显示批注的存储偏好。

此设置仅控制存储的视图偏好。它不会添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。有关更改批注本身的操作，请参阅 [Presentation Comments](/slides/zh/php-java/presentation-comments/)。

下面的示例需要一个包含批注的现有 `comments.pptx`，它会打印当前的可见性设置，将批注设为隐藏，并保存一个不删除任何批注的新 PPTX。示例还使用 [ViewProperties::setLastView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/setlastview/) 与 [ViewType::SlideView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewtype/#SlideView) 一起配置初始编辑视图以及批注可见性。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此设置不决定批注在 PDF、HTML、图像、备注或讲义导出时是否包含。请分别配置相应的导出特定选项。

## **常见问题解答**

**为什么重新打开演示文稿后网格不可见？**  
文件会存储网格间距，但编辑器控制是否显示网格。请检查编辑器的网格可见性设置。

**清除绘图指南会改变网格间距吗？**  
不会。绘图指南和网格间距是相互独立的设置。清除指南不会改变已存储的网格间隔。

**我能为演示文稿的不同章节设置不同的视图设置吗？**  
[View settings](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getviewproperties/) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/getslideviewproperties/)），而不是按章节。因此，文档打开时会使用一套参数应用于整个文档。

**我能为不同用户预定义不同的视图状态吗？**  
不能。设置存储在文件中并且是共享的。查看器应用程序可以遵循用户偏好，但文件本身只有一套视图属性。

**我可以准备一个包含预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**  
可以。因为 [view properties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getviewproperties/) 存储在演示文稿级别，你可以将它们嵌入模板中，并从该模板创建新文档，以获得相同的初始视图配置。