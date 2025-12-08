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
description: "通过 .NET 的 Aspose.Slides for Python 自动化 PowerPoint 和 OpenDocument 幻灯片母版，以最大化开发效率。为初学者和高级用户提供的完整指南。"
---

## **概述**

**Slide Master** 是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。如果您想为公司创建具有相同样式和模板的演示文稿（或一系列演示文稿），可以使用 Slide Master。

Slide Master 非常有用，因为它允许一次性设置和更改所有演示文稿幻灯片的外观。Aspose.Slides 支持 PowerPoint 的 Slide Master 机制。

VBA 也允许您操作 Slide Master 并执行 PowerPoint 支持的相同操作：更改背景、添加形状、定制布局等。Aspose.Slides 提供灵活的 API，使您能够使用 Slide Master 并执行常见任务。

以下是基本的 Slide Master 操作：

- 创建 Slide Master。
- 将 Slide Master 应用于演示文稿幻灯片。
- 更改 Slide Master 背景。
- 向 Slide Master 添加图像、占位符、SmartArt 等。

以下是涉及 Slide Master 的更高级操作：

- 比较 Slide Master。
- 合并 Slide Master。
- 应用多个 Slide Master。
- 将幻灯片及其 Slide Master 复制到另一个演示文稿。
- 识别演示文稿中的重复 Slide Master。
- 将 Slide Master 设置为演示文稿的默认视图。

{{% alert color="primary" %}}
您可能想查看 Aspose [Online PowerPoint Viewer](https://products.aspose.app/slides/viewer)，因为它是本文所述一些核心流程的实时实现。
{{% /alert %}}

## **Slide Master 的应用方式**

在使用 Slide Master 之前，您可能想了解 Slide Master 在演示文稿中的使用方式以及如何应用到幻灯片。

- 默认情况下，每个演示文稿至少有一个 Slide Master。
- 一个演示文稿可以包含多个 Slide Master。您可以添加多个 Slide Master，并以不同方式为演示文稿的不同部分设置样式。

在 Aspose.Slides 中，Slide Master 由 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 类型表示。

Aspose.Slides 的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象包含类型为 [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) 的 [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 集合，保存了演示文稿中定义的所有母版幻灯片。

除 CRUD 操作外，[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) 类还提供了诸如 [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) 和 [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/) 等实用方法。这些方法扩展了基本的幻灯片克隆功能，在处理 Slide Master 时可实现更复杂的布局。

当向演示文稿添加新幻灯片时，会自动为其应用 Slide Master。默认情况下，选取前一张幻灯片的 Slide Master。

**Note:** 演示文稿幻灯片存储在 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合中，默认情况下每个新幻灯片都会添加到该集合的末尾。如果演示文稿仅包含一个 Slide Master，则该 Slide Master 会被选中用于所有新幻灯片。因此，您无需为每个新创建的幻灯片显式指定 Slide Master。

相同的原理适用于 PowerPoint 和 Aspose.Slides。例如，在 PowerPoint 中添加新幻灯片时，您可以单击最后一张幻灯片下方的空白区域，系统会创建使用前一张幻灯片 Slide Master 的新幻灯片。

![todo:image_alt_text](slide-master_1.jpg)

在 Aspose.Slides 中，您可以使用 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 类的 [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 方法完成相同的操作。

## **Slides 层次结构中的 Slide Master**

将 **Slide Layouts** 与 **Slide Master** 结合使用能够提供最大的灵活性。Slide Layout 可以定义与 Slide Master 相同类型的样式（背景、字体、形状等）。当在一个 Slide Master 下定义多个 Slide Layout 时，它们共同构成一个统一的样式系统。通过将 Slide Layout 应用于单个幻灯片，您可以在 Slide Master 提供的基础上调整其样式。

优先级顺序为：**Slide Master** → **Slide Layout** → **Slide**。

![todo:image_alt_text](slide-master_2.jpg)

每个 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 对象都有一个包含所有幻灯片布局的 [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) 属性。每个 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 则拥有一个指向所应用布局的 [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) 属性。幻灯片与 Slide Master 的交互是通过其 Slide Layout 实现的。

{{% alert color="info" title="Note" %}}
- 在 Aspose.Slides 中，所有幻灯片构件（Slide Master、Slide Layout 和幻灯片本身）都是继承自 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类的幻灯片对象。
- 由于 Slide Master 和 Slide Layout 暴露了许多相同的属性，您需要了解这些属性如何应用到 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 对象上。Slide Master 先被应用，随后是 Slide Layout。例如，如果 Slide Master 和 Slide Layout 都定义了背景，则最终使用 Slide Layout 中的背景。
{{% /alert %}}

## **Slide Master 的组成部分**

要了解如何修改 Slide Master，必须先了解其组成部分。以下是 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 的核心属性：

- `background` — 获取/设置幻灯片背景。
- `body_style` — 获取/设置幻灯片正文的文本样式。
- `shapes` — 获取/设置 Slide Master 上的所有形状（占位符、图片框等）。
- `controls` — 获取/设置 ActiveX 控件。
- `theme_manager` — 获取主题管理器。
- `header_footer_manager` — 获取页眉和页脚管理器。

Slide Master 方法：

- `get_depending_slides()` — 获取所有依赖于该 Slide Master 的幻灯片。
- `apply_external_theme_to_depending_slides(fname)` — 基于当前 Slide Master 和外部主题创建新的 Slide Master，然后将其应用于所有依赖的幻灯片。

## **获取 Slide Master**

在 PowerPoint 中，您可以通过 **View** → **Slide Master** 访问 Slide Master：

![todo:image_alt_text](slide-master_3.jpg)

使用 Aspose.Slides，您可以按如下方式访问 Slide Master：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 获取演示文稿中的第一张母版幻灯片。
    master_slide = presentation.masters[0]
```


[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 类表示一个 Slide Master。[masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 属性（即 [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)）保存了演示文稿中定义的所有 Slide Master。

## **向 Slide Master 添加图像**

将图像添加到 Slide Master 后，该图像会出现在所有依赖该母版的幻灯片上。

例如，将公司徽标或其他图像放置在 Slide Master 上，然后返回普通视图，您将在每个依赖的幻灯片上看到该图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用 Aspose.Slides 向 Slide Master 添加图像：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}}
有关向幻灯片添加图像的更多信息，请参阅 [Add Picture Frames to Presentations with Python](/slides/zh/python-net/picture-frame/) 文章。
{{% /alert %}}

## **向 Slide Master 添加占位符**

以下文本字段是 Slide Master 上的标准占位符：

- 单击编辑 Master 标题样式
- 编辑 Master 文本样式
- 二级
- 三级

这些占位符也会出现在基于该 Slide Master 的幻灯片上。您可以在 Slide Master 上编辑这些占位符，修改会自动应用到相应的幻灯片。

在 PowerPoint 中，您可以通过 **Slide Master** → **Insert Placeholder** 添加占位符：

![todo:image_alt_text](slide-master_5.png)

下面我们来看一个更复杂的占位符示例。考虑一张从 Slide Master 继承占位符的幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们希望按如下方式更新 Slide Master 上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，从 Slide Master 中获取标题占位符，然后使用 `PlaceHolder.fill_format` 属性：

```python
# 获取对母版幻灯片标题占位符的引用。
title_placeholder = master_slide.shapes[0]

# 设置填充格式为渐变。
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


标题样式和格式将在所有基于该 Slide Master 的幻灯片上发生变化：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}}
* [使用 Python 管理演示文稿中的占位符](/slides/zh/python-net/manage-placeholder/)
* [使用 Python 格式化 PowerPoint 文本](/slides/zh/python-net/text-formatting/)
{{% /alert %}}

## **更改 Slide Master 背景**

更改 Slide Master 的背景颜色后，演示文稿中的所有常规幻灯片都会继承新颜色。下面的 Python 代码演示了这一点：

```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="See also" %}}
- [使用 Python 管理演示文稿背景](/slides/zh/python-net/presentation-background/)
- [使用 Python 管理 PowerPoint 演示文稿主题](/slides/zh/python-net/presentation-theme/)
{{% /alert %}}

## **向演示文稿添加多个 Slide Master**

Aspose.Slides 允许您向任何演示文稿添加多个 Slide Master 和 Slide Layout。这使您能够以多种不同方式配置幻灯片的样式、布局和格式选项。

在 PowerPoint 中，您可以通过 **Slide Master** 菜单添加新的 Slide Master 和 Slide Layout，步骤如下：

![todo:image_alt_text](slide-master_9.jpg)

使用 Aspose.Slides，您可以调用 `add_clone` 方法添加新的 Slide Master：

```python
# 添加新的母版幻灯片。
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **比较 Slide Master**

Slide Master 继承自 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类，该类包含用于比较幻灯片的 `equals(slide)` 方法。当 Slide Master 在结构和静态内容上完全相同时，该方法返回 true。

如果两个 Slide Master 的形状、样式、文本、动画以及其他设置完全相同，则视为相等。比较会忽略唯一标识符值（例如 `slide_id`）和动态内容（例如日期占位符中的当前日期）。

## **将 Slide Master 设置为演示文稿的默认视图**

Aspose.Slides 允许您将 Slide Master 设置为演示文稿的默认视图。默认视图是打开演示文稿时首先看到的视图。下面的 Python 示例展示了如何将 Slide Master 设置为演示文稿的默认视图：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 将默认视图设置为母版视图。
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # 保存演示文稿。
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **删除未使用的母版幻灯片**

Aspose.Slides 在 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类中提供了 `remove_unused_master_slides` 方法，可删除不需要的、未使用的母版幻灯片。以下 Python 代码展示了如何从 PowerPoint 演示文稿中删除未使用的母版幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**什么是 PowerPoint 中的 Slide Master？**

Slide Master 是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。它允许您一次性设置和更改所有演示文稿幻灯片的外观。

**Slide Master 与 Slide Layout 有何关联？**

Slide Layout 与 Slide Master 协同工作，为幻灯片设计提供灵活性。Slide Master 定义全局样式和主题，而 [Slide Layout](/slides/zh/python-net/slide-layout/) 则允许在内容布局上进行变化。层级结构如下：

- **Slide Master** → 定义全局样式。
- **Slide Layout** → 提供不同的内容布局。
- **Slide** → 从其 Slide Layout 继承设计。

**演示文稿中可以有多个 Slide Master 吗？**

可以，一个演示文稿可以包含多个 Slide Master。这使您能够以不同方式为演示文稿的不同章节设置样式，提供了更大的设计灵活性。

**如何使用 Aspose.Slides 访问和修改 Slide Master？**

在 Aspose.Slides 中，Slide Master 由 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 类表示。您可以通过 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象的 [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 属性访问 Slide Master。