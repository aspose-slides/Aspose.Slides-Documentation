---
title: 在 Python 中管理 PowerPoint 幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 80
url: /zh/python-net/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 重复母版幻灯片
- 未使用的母版幻灯片
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自动化处理 PowerPoint 和 OpenDocument 的幻灯片母版，以最大化开发效率。面向初学者和高级用户的完整指南。"
---

## **什么是PowerPoint中的幻灯片母版**

**幻灯片母版**是一个幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景和其他属性。如果您希望为您的公司创建一份（或一系列）具有相同风格和模板的演示文稿，您可以使用幻灯片母版。

幻灯片母版的用途在于它允许您一次性设置和更改所有演示文稿幻灯片的外观。Aspose.Slides支持PowerPoint中的幻灯片母版机制。

VBA还允许您操作幻灯片母版并执行PowerPoint中支持的相同操作：更改背景、添加形状、自定义布局等。Aspose.Slides提供灵活的机制，使您能够使用幻灯片母版并执行基本任务。

基本的幻灯片母版操作包括：

- 创建或幻灯片母版。
- 将幻灯片母版应用于演示文稿幻灯片。
- 更改幻灯片母版背景。
- 向幻灯片母版添加图像、占位符、智能艺术等。

更高级的幻灯片母版操作包括：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将带有幻灯片母版的幻灯片复制到另一个演示文稿中。
- 找出演示文稿中的重复幻灯片母版。
- 将幻灯片母版设置为演示文稿的默认视图。

{{% alert color="primary" %}} 

您可能想要查看Aspose [**在线PowerPoint查看器**](https://products.aspose.app/slides/viewer)，因为它是这里描述的一些核心过程的实时实现。

{{% /alert %}} 

## **如何应用幻灯片母版**

在使用幻灯片母版之前，您可能想要了解它们如何在演示文稿中使用以及如何应用于幻灯片。

* 每个演示文稿默认至少有一个幻灯片母版。
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同方式为演示文稿的不同部分设置样式。

在**Aspose.Slides**中，幻灯片母版由[**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)类型表示。

Aspose.Slides的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象包含[**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)列表，该列表是[**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)类型，其中包含演示文稿中定义的所有母版幻灯片的列表。

除了CRUD操作，[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)接口包含以下有用方法：[**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)和[**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)方法。这些方法继承自基本的幻灯片克隆功能。但在处理幻灯片母版时，这些方法允许您实现复杂的设置。

当将新幻灯片添加到演示文稿时，幻灯片母版将自动应用于它。前一个幻灯片的幻灯片母版默认被选中。

**注意**：演示文稿幻灯片存储在[Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)列表中，每个新幻灯片默认被添加到集合的末尾。如果一个演示文稿包含一个幻灯片母版，则该幻片母版将被选为所有新幻灯片。这就是您不必为每个新幻灯片定义幻灯片母版的原因。

原则对于PowerPoint和Aspose.Slides是相同的。例如，在PowerPoint中，当您添加一个新演示文稿时，您可以直接按最后一张幻灯片下方的底线，然后将创建一个新幻灯片（带有上一个演示文稿的幻灯片母版）：

![todo:image_alt_text](slide-master_1.jpg)

在Aspose.Slides中，您可以通过[add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)方法在[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类下执行相应任务。

## **幻灯片母版在幻灯片层次结构中的位置**

使用幻灯片母版的幻灯片布局可实现最大灵活性。幻灯片布局允许您设置与幻灯片母版相同的所有样式（背景、字体、形状等）。然而，当多个幻灯片布局在一个幻灯片母版上组合时，将创建一种新样式。当您将幻灯片布局应用于单个幻灯片时，您可以更改其样式与幻灯片母版所应用的样式不同。

幻灯片母版优先于所有设置项：幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个[IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)对象都有一个[**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)属性，包含幻灯片布局列表。一个[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide)类型有一个[**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)属性，链接到应用于该幻灯片的幻灯片布局。幻灯片与幻灯片母版之间的交互通过幻灯片布局进行。

{{% alert color="info" title="注意" %}}

* 在Aspose.Slides中，所有幻灯片设置（幻灯片母版、幻灯片布局和幻灯片本身）实际上是实现了[**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)接口的幻灯片对象。
* 因此，幻灯片母版和幻灯片布局可能实现相同的属性，您需要知道它们的值将如何应用于[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)对象。幻灯片母版首先应用于幻灯片，然后应用幻灯片布局。例如，如果幻灯片母版和幻灯片布局都有背景值，幻灯片将最终具有来自幻灯片布局的背景。

{{% /alert %}}

## **幻灯片母版的组成部分**

若要了解如何修改幻灯片母版，您需要知道它的组成部分。这些是[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)的核心属性。

- `background` 获取/设置幻灯片背景。
- `body_style` 获取/设置幻灯片主体的文本样式。
- `shapes` 获取/设置幻灯片母版的所有形状（占位符、图片框等）。
- `controls` 获取/设置ActiveX控件。
- `theme_manager` 获取主题管理器。
- `header_footer_manager` 获取页眉和页脚管理器。

幻灯片母版方法：

- `get_depending_slides()` - 获取所有依赖于幻灯片母版的幻灯片。
- `apply_external_theme_to_depending_slides(fname)` - 允许您基于当前幻灯片母版和新主题创建新的幻灯片母版。新幻灯片母版将应用于所有依赖幻灯片。

## **获取幻灯片母版**

在PowerPoint中，可以通过视图 -> 幻灯片母版菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用Aspose.Slides，您可以这样访问幻灯片母版：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # 获取演示文稿的母版幻灯片
    masterSlide = pres.masters[0]
```

[IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)接口表示幻灯片母版。`masters`属性（与[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)类型相关）包含演示文稿中定义的所有幻灯片母版的列表。

## **向幻灯片母版添加图像**

当您向幻灯片母版添加图像时，该图像将出现在所有依赖于此幻灯片母版的幻灯片上。

例如，您可以将公司标志和一些图像放置在幻灯片母版上，然后切换回幻灯片编辑模式。您应该在每个幻灯片上都看到该图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用Aspose.Slides向幻灯片母版添加图像：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="另请参阅" %}} 

有关如何向幻灯片添加图像的更多信息，请参见[图片框](/slides/zh/python-net/picture-frame/#create-picture-frame)文章。
{{% /alert %}}

## **向幻灯片母版添加占位符**

这些文本字段是幻灯片母版上的标准占位符：

* 点击编辑母版标题样式

* 编辑母版文本样式

* 第二级

* 第三级

它们也会出现在基于幻灯片母版的幻灯片上。您可以在幻灯片母版上编辑这些占位符，所做的更改将自动应用于幻灯片。

在PowerPoint中，您可以通过“幻灯片母版 -> 插入占位符”路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们用Aspose.Slides检查更复杂的占位符示例。考虑一个从幻灯片母版模板化的幻灯片，其中有占位符：

![todo:image_alt_text](slide-master_6.png)

我们希望以这种方式更改幻灯片母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从幻灯片母版对象中检索标题占位符的内容，然后使用`PlaceHolder.FillFormat`字段：

```python
# 获取母版标题占位符的引用
titlePlaceholder = masterSlide.shapes[0]

# 将填充格式设置为渐变填充
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

标题样式和格式将对所有基于幻灯片母版的幻灯片发生变化：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另请参阅" %}} 

* [在占位符中设置提示文本](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **更改幻灯片母版的背景**

当您更改母版幻灯片的背景颜色时，演示文稿中的所有普通幻灯片将获得新的颜色。以下Python代码演示了该操作：

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="另请参阅" %}} 

- [演示文稿背景](https://docs.aspose.com/slides/python-net/presentation-background/)

- [演示文稿主题](https://docs.aspose.com/slides/python-net/presentation-theme/)

{{% /alert %}}

## **将幻灯片母版克隆到另一个演示文稿**

要将幻灯片母版克隆到另一个演示文稿，请调用来自目标演示文稿的`add_clone(source_slide, dest_master, allow_clone_missing_layout)`方法，并传入一个幻灯片母版。以下Python代码演示了如何将幻灯片母版克隆到另一个演示文稿：

```python
# 添加一个新的母版幻灯片
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **向演示文稿添加多个幻灯片母版**

Aspose.Slides允许您向任何给定的演示文稿添加多个幻灯片母版和幻灯片布局。这使您能够以多种方式为演示文稿幻灯片设置样式、布局和格式选项。

在PowerPoint中，您可以通过“幻灯片母版菜单”以这种方式添加新的幻灯片母版和布局：

![todo:image_alt_text](slide-master_9.jpg)

使用Aspose.Slides，您可以通过调用`add_clone`方法添加新的幻灯片母版：

```python
# 添加一个新的母版幻灯片
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **比较幻灯片母版**

母版幻灯片实现了[IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)接口，其中包含`equals(slide)`方法，该方法可以用于比较幻灯片。如果母版幻灯片在结构和静态内容上相同，它将返回`true`。

如果两个母版幻灯片的形状、样式、文本、动画及其他设置等相等，则两者是相等的。比较不考虑唯一标识符值（例如SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将幻灯片母版设置为演示文稿的默认视图**

Aspose.Slides允许您将幻灯片母版设置为演示文稿的默认视图。默认视图是您打开演示文稿时首先看到的内容。

以下代码演示了如何在Python中将幻灯片母版设置为演示文稿的默认视图：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的Presentation类
with slides.Presentation() as presentation:
    # 将默认视图设置为SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # 保存演示文稿
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的母版幻灯片**

Aspose.Slides提供`remove_unused_master_slides`方法（来自[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)类），允许您删除不需要的未使用幻灯片母版。以下Python代码演示了如何从PowerPoint演示文稿中移除母版幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```