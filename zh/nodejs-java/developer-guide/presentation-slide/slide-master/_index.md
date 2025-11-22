---
title: 幻灯片母版
type: docs
weight: 70
url: /zh/nodejs-java/slide-master/
keywords: "添加幻灯片母版, PPT 母版幻灯片, 幻灯片母版 PowerPoint, 向幻灯片母版添加图像, 占位符, 多个幻灯片母版, 比较幻灯片母版, Java, Aspose.Slides for Node.js via Java"
description: "在 PowerPoint 演示文稿中使用 JavaScript 添加或编辑幻灯片母版"
---

## **什么是 PowerPoint 中的幻灯片母版**

**Slide Master** 是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景和其他属性。如果您想为公司创建具有相同样式和模板的演示文稿（或系列演示文稿），可以使用 **Slide Master**。

Slide Master 很有用，因为它允许您一次性设置和更改所有演示文稿幻灯片的外观。Aspose.Slides 支持 PowerPoint 的 Slide Master 机制。

VBA 也允许您操作 Slide Master，并执行 PowerPoint 支持的相同操作：更改背景、添加形状、定制布局等。Aspose.Slides 提供灵活的机制，使您能够使用 Slide Master 并执行基本任务。

这些是基本的 Slide Master 操作：

- 创建 Slide Master。
- 将 Slide Master 应用到演示文稿幻灯片。
- 更改 Slide Master 背景。 
- 向 Slide Master 添加图像、占位符、SmartArt 等。

这些是涉及 Slide Master 的更高级操作：

- 比较 Slide Master。
- 合并 Slide Master。
- 应用多个 Slide Master。
- 将带有 Slide Master 的幻灯片复制到另一个演示文稿。
- 查找演示文稿中重复的 Slide Master。
- 将 Slide Master 设置为演示文稿的默认视图。

{{% alert color="primary" %}} 
您可能想查看 Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer)，因为它是此处描述的某些核心流程的实时实现。
{{% /alert %}} 

## **Slide Master 如何应用**

在使用 Slide Master 之前，您可能需要了解它们在演示文稿中的使用方式以及如何应用到幻灯片上。

* 每个演示文稿默认至少拥有一个 Slide Master。
* 一个演示文稿可以包含多个 Slide Master。您可以添加多个 Slide Master，并以不同方式为演示文稿的不同部分设定样式。

在 **Aspose.Slides** 中，Slide Master 由 [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 类型表示。

Aspose.Slides 的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 对象包含 [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) 列表，返回 [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 类型，该集合包含演示文稿中定义的所有母版幻灯片的列表。

除了 CRUD 操作外，[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 类还包含以下有用方法： [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) 和 [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-)。这些方法继承自基本的幻灯片克隆功能。但在处理 Slide Master 时，这些方法允许您实现复杂的设置。

当向演示文稿添加新幻灯片时，会自动为其应用 Slide Master。默认情况下，会选择前一张幻灯片的 Slide Master。

**Note**: 演示文稿幻灯片存储在 [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) 列表中，默认情况下每个新幻灯片都会添加到集合的末尾。如果演示文稿只包含一个 Slide Master，则该母版会被所有新幻灯片使用。这就是您无需为每个新创建的幻灯片定义 Slide Master 的原因。

PowerPoint 和 Aspose.Slides 的原理相同。例如，在 PowerPoint 中，当您在最后一张幻灯片下方单击底线时，会创建一个新幻灯片（使用上一张幻灯片的 Slide Master）：

![todo:image_alt_text](slide-master_1.jpg)

在 Aspose.Slides 中，您可以使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类下的 [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) 方法来完成相同的任务。

## **幻灯片层级中的 Slide Master**

将 Slide Layout 与 Slide Master 结合使用可实现最大灵活性。Slide Layout 允许您设置与 Slide Master 相同的所有样式（背景、字体、形状等）。然而，当多个 Slide Layout 在同一 Slide Master 上组合时，会生成新样式。将 Slide Layout 应用于单个幻灯片时，您可以将其样式从 Slide Master 应用的样式中更改。

Slide Master 优先级最高：Slide Master → Slide Layout → Slide：

![todo:image_alt_text](slide-master_2)

Each [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) object has a [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) property with a list of Slide Layouts. A [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) type has a [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) property with a link on a Slide Layout applied to the slide. The interaction between a slide and Slide Master occurs through a Slide Layout.

{{% alert color="info" title="Note" %}}
* 在 Aspose.Slides 中，所有幻灯片设置（Slide Master、Slide Layout 以及幻灯片本身）实际上都是实现了 [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) 类的幻灯片对象。  
* 因此，Slide Master 和 Slide Layout 可能实现相同的属性，您需要了解它们的值如何应用于 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 对象。Slide Master 首先应用到幻灯片，然后再应用 Slide Layout。例如，如果 Slide Master 和 Slide Layout 都具有背景值，最终幻灯片将使用 Slide Layout 的背景。
{{% /alert %}}

## **Slide Master 包含哪些内容**

要了解如何更改 Slide Master，您需要了解其组成部分。这些是 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 的核心属性。

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) 获取/设置幻灯片背景。
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) - 获取/设置幻灯片正文的文本样式。
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) 获取/设置 Slide Master 的所有形状（占位符、图片框等）。
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) 获取/设置 ActiveX 控件。
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) - 获取主题管理器。
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) - 获取页眉页脚管理器。

Slide Master 方法：

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) - 获取所有依赖该 Slide Master 的幻灯片。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 允许您基于当前 Slide Master 和新主题创建新的 Slide Master。随后，该新 Slide Master 将应用于所有依赖的幻灯片。

## **获取 Slide Master**

在 PowerPoint 中，可通过 视图 → Slide Master 菜单访问 Slide Master：

![todo:image_alt_text](slide-master_3.jpg)

使用 Aspose.Slides，您可以通过以下方式访问 Slide Master：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 获取对演示文稿母版幻灯片的访问
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) 类代表 Slide Master。[Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) 属性（对应 [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) 类型）包含演示文稿中定义的所有 Slide Master 的列表。

## **向 Slide Master 添加图像**

当您向 Slide Master 添加图像时，该图像会显示在所有依赖该母版的幻灯片上。

例如，您可以将公司徽标和几张图片放置在 Slide Master 上，然后切换回幻灯片编辑模式。您应该会在每张幻灯片上看到该图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用 Aspose.Slides 向 Slide Master 添加图像：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
有关向幻灯片添加图像的更多信息，请参阅 [Picture Frame](/slides/zh/nodejs-java/picture-frame/#create-picture-frame) 文章。
{{% /alert %}}

## **向 Slide Master 添加占位符**

这些文本字段是 Slide Master 上的标准占位符：

* Click to edit Master title style
* Edit Master text styles
* Second level
* Third level

它们也会出现在基于 Slide Master 的幻灯片上。您可以在 Slide Master 上编辑这些占位符，修改会自动应用到幻灯片。

在 PowerPoint 中，您可以通过 Slide Master → Insert Placeholder 路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

下面我们使用 Aspose.Slides 查看更复杂的占位符示例。考虑一个从 Slide Master 模板化的占位符幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们希望以如下方式更改 Slide Master 上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从 Slide Master 对象检索标题占位符内容，然后使用 `PlaceHolder.FillFormat` 字段：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


标题样式和格式将会更改，适用于所有基于该 Slide Master 的幻灯片：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [在占位符中设置提示文本](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/nodejs-java/text-formatting/)
{{% /alert %}}

## **更改 Slide Master 背景**

当您更改母版幻灯片的背景颜色时，演示文稿中的所有普通幻灯片都会采用新颜色。以下 JavaScript 代码演示此操作：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
- [演示文稿背景](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [演示文稿主题](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)
{{% /alert %}}

## **将 Slide Master 克隆到另一个演示文稿**

要将 Slide Master 克隆到另一个演示文稿，请在目标演示文稿上调用 [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 方法，并将要克隆的 Slide Master 作为参数传入。以下 JavaScript 代码展示了如何将 Slide Master 克隆到另一个演示文稿：
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```


## **向演示文稿添加多个 Slide Master**

Aspose.Slides 允许您向任意演示文稿添加多个 Slide Master 和 Slide Layout。这使您可以以多种方式设置演示文稿幻灯片的样式、布局和格式选项。

在 PowerPoint 中，您可以通过以下方式添加新的 Slide Master 和 Layout（来自 “Slide Master 菜单）：
![todo:image_alt_text](slide-master_9.jpg)

使用 Aspose.Slides，您可以调用 [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 方法来添加新的 Slide Master：
```javascript
// 添加一个新的母版幻灯片
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **比较 Slide Master**

Master Slide 实现了包含 [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-) 方法的 [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) 类，可用于比较幻灯片。当 Master Slide 在结构和静态内容上完全相同​​时，返回 `true`。

如果两个 Master Slide 的形状、样式、文本、动画及其他设置等全部相同，则它们相等。比较时不考虑唯一标识符值（例如 SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将 Slide Master 设置为演示文稿默认视图**

Aspose.Slides 允许您将 Slide Master 设置为演示文稿的默认视图。默认视图是打开演示文稿时首先看到的视图。

以下代码演示如何在 JavaScript 中将 Slide Master 设置为演示文稿的默认视图：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类
var presentation = new aspose.slides.Presentation();
try {
    // 将默认视图设置为 SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // 保存演示文稿
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **删除未使用的母版幻灯片**

Aspose.Slides 提供了 [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) 方法（位于 [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) 类），帮助您删除不需要的未使用的母版幻灯片。以下 JavaScript 代码演示如何从 PowerPoint 演示文稿中删除母版幻灯片：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问答**

**PowerPoint 中的 Slide Master 是什么？**

Slide Master 是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景和其他属性。它允许您一次性设置和更改所有演示文稿幻灯片的外观。

**Slide Master 在演示文稿中如何应用？**

每个演示文稿默认至少有一个 Slide Master。添加新幻灯片时，会自动为其应用 Slide Master，通常继承前一张幻灯片的母版。演示文稿可以包含多个 Slide Master，以独特的方式为不同部分设定样式。

**Slide Master 中可以自定义哪些元素？**

- **Background**：设置幻灯片背景。
- **BodyStyle**：定义幻灯片正文的文本样式。
- **Shapes**：管理 Slide Master 上的所有形状，包括占位符和图片框。
- **Controls**：处理 ActiveX 控件。
- **ThemeManager**：访问主题管理器。
- **HeaderFooterManager**：管理页眉和页脚。

**如何向 Slide Master 添加图像？**

向 Slide Master 添加图像可确保该图像出现在所有依赖该母版的幻灯片上。例如，在 Slide Master 上放置公司徽标后，演示文稿中的每张幻灯片都会显示该徽标。

**Slide Master 与 Slide Layout 之间有什么关系？**

Slide Layout 与 Slide Master 协同工作，为幻灯片设计提供灵活性。Slide Master 定义整体样式和主题，而 Slide Layout 允许内容布局的变化。层级如下：

- **Slide Master** → 定义全局样式。
- **Slide Layout** → 提供不同的内容布局。
- **Slide** → 继承其 Slide Layout 的设计。

**我可以在同一演示文稿中拥有多个 Slide Master 吗？**

可以，演示文稿可以包含多个 Slide Master。这使您能够以不同方式为演示文稿的不同章节设定样式，提供设计灵活性。

**如何使用 Aspose.Slides 访问和修改 Slide Master？**

在 Aspose.Slides 中，Slide Master 由 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 类表示。您可以使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 对象的 [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) 方法访问 Slide Master。