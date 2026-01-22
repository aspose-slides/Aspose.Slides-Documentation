---
title: 在 JavaScript 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 70
url: /zh/nodejs-java/slide-master/
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
- 重复的母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Node.js 中管理幻灯片母版：创建、编辑并应用布局、主题和占位符到 PPT、PPTX 和 ODP，提供简明示例。"
---

## **PowerPoint 中的母版是什么**

A **Slide Master** 是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。如果你想为公司创建一套样式统一的演示文稿（或一系列演示文稿），可以使用母版。 

A Slide Master 有用，因为它允许一次性设置并更改所有演示文稿幻灯片的外观。Aspose.Slides 支持来自 PowerPoint 的母版机制。 

VBA 也允许你操作母版并执行 PowerPoint 支持的相同操作：更改背景、添加形状、自定义布局等。Aspose.Slides 提供灵活的机制，使你能够使用母版并执行基本任务。 

These are basic Slide Master operations:

- 创建或获取母版。
- 将母版应用于演示文稿幻灯片。
- 更改母版背景。 
- 向母版添加图像、占位符、Smart Art 等。

These are more advanced operations involving Slide Master: 

- 比较母版。
- 合并母版。
- 应用多个母版。
- 将带有母版的幻灯片复制到另一个演示文稿。
- 查找演示文稿中重复的母版。
- 将母版设为演示文稿的默认视图。

{{% alert color="primary" %}} 

您可能想查看 Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) 因为它是本文所述核心过程的一些实时实现。

{{% /alert %}} 


## **如何应用母版**

在使用母版之前，你可能想了解它们在演示文稿中的使用方式以及如何应用到幻灯片。 

* 每个演示文稿默认至少有一个母版。 
* 演示文稿可以包含多个母版。你可以添加多个母版，并用它们以不同方式为演示文稿的不同部分设置样式。 

在 **Aspose.Slides** 中，母版由[**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)类型表示。

Aspose.Slides 的[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)对象包含[**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--)列表，返回[**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)类型，该集合包含演示文稿中定义的所有母版列表。

除了 CRUD 操作外，[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)类还提供以下有用方法： [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) 和 [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-) 方法。这些方法继承自基本的幻灯片克隆功能。但在处理母版时，这些方法允许你实现复杂的设置。

当向演示文稿添加新幻灯片时，会自动为其应用母版。默认选择前一张幻灯片的母版。

**注意**：演示文稿幻灯片存储在[getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--)列表中，默认情况下每个新幻灯片都会添加到集合末尾。如果演示文稿仅包含一个母版，则该母版会被选为所有新幻灯片的母版。这就是你无需为创建的每个新幻灯片单独定义母版的原因。

PowerPoint 和 Aspose.Slides 的原理相同。例如，在 PowerPoint 中，当你在最后一张幻灯片下方单击底部线时，会创建一个带有上一张演示文稿母版的新幻灯片：

![todo:image_alt_text](slide-master_1.jpg)

在 Aspose.Slides 中，你可以使用[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)方法在[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)类下执行相同任务。

## **母版在幻灯片层级中的位置**

使用幻灯片布局与母版相结合可实现最大灵活性。幻灯片布局允许你设置与母版相同的所有样式（背景、字体、形状等）。然而，当多个幻灯片布局组合在母版上时，会创建新的样式。当你将幻灯片布局应用于单个幻灯片时，可以将其样式从母版应用的样式中更改。

母版高于所有设置项：母版 → 幻灯片布局 → 幻灯片：

![todo:image_alt_text](slide-master_2)

每个[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide)对象都有一个[**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--)属性，返回幻灯片布局列表。一个[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)类型拥有[**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--)属性，指向应用于该幻灯片的幻灯片布局。幻灯片与母版之间的交互通过幻灯片布局实现。

{{% alert color="info" title="Note" %}}

* 在 Aspose.Slides 中，所有幻灯片设置（母版、幻灯片布局以及幻灯片本身）实际上都是实现了[**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide)类的幻灯片对象。
* 因此，母版和幻灯片布局可能实现相同的属性，你需要了解它们的值如何应用到[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)对象。母版首先应用于幻灯片，然后应用幻灯片布局。例如，如果母版和幻灯片布局都具有背景值，最终幻灯片将使用幻灯片布局的背景。

{{% /alert %}}


## **母版包含哪些内容**

要了解如何更改母版，需要知道其组成部分。这些是[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)的核心属性。

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) 获取/设置幻灯片背景。
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) 获取/设置幻灯片正文的文本样式。
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) 获取/设置母版的所有形状（占位符、图片框等）。
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) 获取/设置 ActiveX 控件。
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) 获取主题管理器。
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) 获取页眉页脚管理器。

母版方法：

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) 获取所有依赖于该母版的幻灯片。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) 允许你基于当前母版和新主题创建新的母版，然后将该新母版应用于所有依赖的幻灯片。

## **获取母版**

在 PowerPoint 中，可通过“视图 -> 幻灯片母版”菜单访问母版：

![todo:image_alt_text](slide-master_3.jpg)

使用 Aspose.Slides，你可以这样访问母版：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 获取对演示文稿母版幻灯片的访问
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[MasterSlide]类表示母版。[Masters]属性（对应[MasterSlideCollection]类型）包含演示文稿中定义的所有母版列表。

## **向母版添加图像**

当向母版添加图像时，该图像会出现在所有依赖该母版的幻灯片上。

例如，你可以在母版上放置公司徽标和几张图片，然后切换回幻灯片编辑模式。你应该在每张幻灯片上看到该图像。

![todo:image_alt_text](slide-master_4.png)

你可以使用 Aspose.Slides 向母版添加图像：
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


{{% alert color="primary" title="另见" %}} 

有关向幻灯片添加图像的更多信息，请参阅[Picture Frame](/slides/zh/nodejs-java/picture-frame/#create-picture-frame)文章。
{{% /alert %}}

## **向母版添加占位符**

这些文本字段是母版上的标准占位符：

* 单击编辑母版标题样式
* 编辑母版文本样式
* 二级标题
* 三级标题

它们也会出现在基于母版的幻灯片上。你可以在母版上编辑这些占位符，修改会自动应用到幻灯片。

在 PowerPoint 中，你可以通过“母版 -> 插入占位符”路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们查看一个更复杂的占位符示例，使用 Aspose.Slides。考虑一个从母版模板化占位符的幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们想以如下方式更改母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从母版对象检索标题占位符内容，然后使用`PlaceHolder.FillFormat`字段：
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


标题样式和格式会对所有基于该母版的幻灯片产生更改：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另见" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}

## **更改母版背景**

当你更改母版幻灯片的背景颜色时，演示文稿中的所有普通幻灯片都会获得新颜色。以下 JavaScript 代码演示了该操作：
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


{{% alert color="primary" title="另见" %}} 

- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **将母版克隆到另一个演示文稿**

要将母版克隆到另一个演示文稿，调用目标演示文稿的[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)方法，并传入要克隆的母版。以下 JavaScript 代码展示了如何将母版克隆到另一个演示文稿：
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


## **向演示文稿添加多个母版**

Aspose.Slides 允许向任意演示文稿添加多个母版和幻灯片布局。这使你能够以多种方式为演示文稿幻灯片设置样式、布局和格式选项。

在 PowerPoint 中，你可以通过“母版菜单”添加新的母版和布局：

![todo:image_alt_text](slide-master_9.jpg)

使用 Aspose.Slides，你可以通过调用[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)方法添加新的母版：
```javascript
// 添加新的母版幻灯片
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **比较母版**

母版实现了[BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide)类，其中包含[**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-)方法，可用于比较母版。对于结构和静态内容相同的母版，该方法返回`true`。

两个母版在形状、样式、文本、动画及其他设置等方面相同即视为相等。比较不考虑唯一标识符（如 SlideId）和动态内容（如日期占位符的当前日期值）。

## **将母版设为演示文稿默认视图**

Aspose.Slides 允许将母版设为演示文稿的默认视图。默认视图是打开演示文稿时首先看到的视图。

以下代码展示了如何在 JavaScript 中将母版设为演示文稿的默认视图：
```javascript
// 实例化一个表示演示文件的 Presentation 类
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

Aspose.Slides 提供了[removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-)方法（来自[Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)类），可删除不需要且未使用的母版幻灯片。以下 JavaScript 代码展示了如何从 PowerPoint 演示文稿中删除母版幻灯片：
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


## **FAQ**

**PowerPoint 中的母版是什么？**

母版是一种幻灯片模板，定义了演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。它允许一次性设置并更改所有演示文稿幻灯片的外观。  

**母版在演示文稿中如何应用？**

每个演示文稿默认至少有一个母版。当添加新幻灯片时，会自动为其应用母版，通常继承前一张幻灯片的母版。演示文稿可以包含多个母版，以独特方式为不同部分设置样式。  

**母版中可以自定义哪些元素？**

母版由多个核心属性组成，可自定义：

- **背景**：设置幻灯片背景。
- **BodyStyle**：定义幻灯片正文的文本样式。
- **Shapes**：管理母版上的所有形状，包括占位符和图片框。
- **Controls**：处理 ActiveX 控件。
- **ThemeManager**：访问主题管理器。
- **HeaderFooterManager**：管理页眉和页脚。  

**如何向母版添加图像？**

向母版添加图像可确保它出现在所有依赖该母版的幻灯片上。例如，将公司徽标放置在母版上后，演示文稿中的每张幻灯片都会显示该徽标。  

**母版与幻灯片布局有何关联？**

幻灯片布局与母版协同工作，提供幻灯片设计的灵活性。母版定义全局样式和主题，幻灯片布局允许在内容安排上进行变化。层级如下：

- **母版** → 定义全局样式。
- **幻灯片布局** → 提供不同的内容安排。
- **幻灯片** → 从其幻灯片布局继承设计。

**一个演示文稿可以包含多个母版吗？**

是的，演示文稿可以包含多个母版。这允许你以不同方式为演示文稿的不同章节设置样式，提供设计上的灵活性。  

**如何使用 Aspose.Slides 访问和修改母版？**

在 Aspose.Slides 中，母版由[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)类表示。你可以通过[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)对象的[getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/)方法访问母版。