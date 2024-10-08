---
title: 幻灯片母版
type: docs
weight: 80
url: /net/slide-master/
keywords: "添加幻灯片母版, PPT 母版幻灯片, 幻灯片母版 PowerPoint, 图像到幻灯片母版, 占位符, 多个幻灯片母版, 比较幻灯片母版, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中添加或编辑 PowerPoint 演示文稿的幻灯片母版"
---


## **PowerPoint 中的幻灯片母版是什么**
**幻灯片母版**是一种幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景及其他属性。如果您想为您的公司创建具有相同风格和模板的演示文稿（或一系列演示文稿），可以使用幻灯片母版。

幻灯片母版很有用，因为它允许您一次性设置和更改所有演示文稿幻灯片的外观。Aspose.Slides 支持 PowerPoint 的幻灯片母版机制。

VBA 还允许您操纵幻灯片母版并执行 PowerPoint 中支持的相同操作：更改背景、添加形状、自定义布局等。Aspose.Slides 提供灵活的机制，使您能够使用幻灯片母版并执行基本任务。

这些是基本的幻灯片母版操作：

- 创建或更新幻灯片母版。
- 将幻灯片母版应用于演示文稿幻灯片。
- 更改幻灯片母版背景。
- 向幻灯片母版添加图像、占位符、智能艺术等。

以下是涉及幻灯片母版的更高级操作：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将带有幻灯片母版的幻灯片复制到另一个演示文稿。
- 找出演示文稿中的重复幻灯片母版。
- 将幻灯片母版设置为演示文稿默认视图。

{{% alert color="primary" %}} 

您可能想看看 Aspose [**在线 PowerPoint 查看器**](https://products.aspose.app/slides/viewer)，因为它是此处描述的一些核心过程的实时实现。

{{% /alert %}} 


## **如何应用幻灯片母版**
在您使用幻灯片母版之前，您可能想了解它们如何在演示文稿中使用并应用于幻灯片。

* 每个演示文稿默认具有至少一个幻灯片母版。
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同的方式样式化演示文稿的不同部分。

在 **Aspose.Slides** 中，幻灯片母版由 [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) 类型表示。

Aspose.Slides 的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象包含 [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) 列表，其类型为 [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)，该列表包含在演示文稿中定义的所有母版幻灯片的列表。

除了 CRUD 操作，[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 接口还包含以下有用方法：[**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) 和 [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone) 方法。这些方法来自基本的幻灯片克隆功能。但在处理幻灯片母版时，这些方法允许您实现复杂的设置。

当新幻灯片被添加到演示文稿时，幻灯片母版会自动应用于它。默认情况下，选择上一张幻灯片的幻灯片母版。

**注意**：演示文稿幻灯片存储在 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 列表中，每个新幻灯片默认添加到集合的末尾。如果演示文稿只包含一个幻灯片母版，则该幻片母版将在所有新幻灯片中被选中。这就是您不需要为每个新幻灯片定义幻片母版的原因。

这一原则在 PowerPoint 和 Aspose.Slides 中是一致的。例如，在 PowerPoint 中，当您添加新的演示文稿时，您只需按下最后一张幻灯片下方的底线，然后会创建一张新的幻灯片（带有上一个演示文稿的幻灯片母版）：

![todo:image_alt_text](slide-master_1.jpg)

在 Aspose.Slides 中，您可以通过 [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) 方法在 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类下执行等效任务。


## **幻灯片母版在幻灯片层次结构中的位置**
使用幻灯片母版的幻灯片布局可以最大限度地提高灵活性。幻灯片布局允许您设置与幻灯片母版相同的所有样式（背景、字体、形状等）。但是，当多个幻灯片布局组合在幻灯片母版上时，会创建新的样式。当您将幻灯片布局应用于单个幻灯片时，可以更改其样式，以区别于幻灯片母版应用的样式。

幻灯片母版的优先级高于所有设置项：幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个 [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) 对象都有一个 [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) 属性，其中包含幻灯片布局的列表。 [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) 类型有一个 [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) 属性，指向应用于该幻灯片的幻灯片布局。幻灯片与幻灯片母版之间的交互通过幻灯片布局进行。

{{% alert color="info" title="注意" %}}

* 
   在 Aspose.Slides 中，所有幻灯片的设置（幻灯片母版、幻灯片布局和幻灯片本身）实际上都是实现了 [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) 接口的幻灯片对象。
* 因此，幻灯片母版和幻灯片布局可能实现相同的属性，您需要了解其值将如何应用于 [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) 对象。幻灯片母版首先应用于幻灯片，然后再应用幻灯片布局。例如，如果幻灯片母版和幻灯片布局都具有背景值，最终的幻灯片将会使用幻灯片布局的背景。

{{% /alert %}}


## **幻灯片母版包含什么**
要理解如何更改幻灯片母版，您需要了解其组成部分。这些是 [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) 的核心属性。

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - 获取/设置幻灯片背景。
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - 获取/设置幻灯片主体的文本样式。
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - 获取/设置幻灯片母版的所有形状（占位符、图片框等）。
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - 获取/设置 ActiveX 控件。
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - 获取主题管理器。
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - 获取页眉和页脚管理器。

幻灯片母版方法：

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - 获取所有依赖于幻灯片母版的幻灯片。
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - 允许您基于当前幻灯片母版和新主题创建新的幻灯片母版。然后，将新的幻灯片母版应用于所有依赖的幻灯片。


## **获取幻灯片母版**
在 PowerPoint 中，可以从视图 -> 幻灯片母版菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用 Aspose.Slides，您可以通过以下方式访问幻灯片母版：

```c#
IMasterSlide master = pres.Masters[0];
```

[IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) 接口表示幻灯片母版。 [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 属性（与 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 类型相关）包含在演示文稿中定义的所有幻灯片母版的列表。


## **向幻灯片母版添加图像**
当您向幻灯片母版添加图像时，该图像将在所有依赖于该幻灯片母版的幻灯片上显示。

例如，您可以在幻灯片母版上放置公司的徽标和几张图片，然后切换回幻灯片编辑模式。您应该在每张幻灯片上看到该图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用 Aspose.Slides 向幻灯片母版添加图像：

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="另见" %}} 

有关向幻灯片添加图像的更多信息，请参见 [图片框](/slides/net/picture-frame/#create-picture-frame) 文章。
{{% /alert %}}


## **向幻灯片母版添加占位符**
这些文本字段是幻灯片母版上的标准占位符：

* 点击编辑母版标题样式

* 编辑母版文本样式

* 第二级

* 第三级 

  它们也出现在基于幻灯片母版的幻灯片上。您可以在幻灯片母版上编辑这些占位符，所做的更改将自动应用于幻灯片。

在 PowerPoint 中，您可以通过幻灯片母版 -> 插入占位符路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们用 Aspose.Slides 来检查一个关于占位符的复杂示例。考虑一张从幻灯片母版模板化的幻灯片，其上都有占位符：

![todo:image_alt_text](slide-master_6.png)

我们希望以这种方式更改幻灯片母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从幻灯片母版对象检索标题占位符内容，然后使用 `PlaceHolder.FillFormat` 字段：

```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```

标题样式和格式会在所有基于幻灯片母版的幻灯片中进行更改：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另见" %}} 

* [在占位符中设置提示文本](https://docs.aspose.com/slides/net/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **更改幻灯片母版的背景**
当您更改母版幻灯片的背景颜色时，演示文稿中的所有普通幻灯片将获得新的颜色。以下 C# 代码演示了该操作：

```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="另见" %}} 
- [演示文稿背景](https://docs.aspose.com/slides/net/presentation-background/)

- [演示文稿主题](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **克隆幻灯片母版到另一个演示文稿**
要将幻灯片母版克隆到另一个演示文稿，请调用目标演示文稿中的 [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) 方法，并传入一个幻灯片母版。以下 C# 代码演示了如何将幻灯片母版克隆到另一个演示文稿：

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **向演示文稿添加多个幻灯片母版**
Aspose.Slides 允许您向任何给定的演示文稿添加多个幻灯片母版和幻灯片布局。这允许您以多种方式设置演示文稿幻灯片的样式、布局和格式选项。

在 PowerPoint 中，您可以通过“幻灯片母版”菜单添加新的幻灯片母版和布局，如下所示：

![todo:image_alt_text](slide-master_9.jpg)

使用 Aspose.Slides，您可以通过调用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) 方法添加新的幻灯片母版：

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **比较幻灯片母版**
母版幻灯片实现了 [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) 接口，包含 [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals) 方法，可以用于比较幻灯片。如果母版幻灯片在结构和静态内容上相同，则返回 `true`。

两个母版幻灯片相等的条件是它们的形状、样式、文本、动画和其他设置等都是相同的。比较不考虑唯一标识符值（例如 SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将幻灯片母版设置为演示文稿的默认视图**
Aspose.Slides 允许您将幻灯片母版设置为演示文稿的默认视图。默认视图是打开演示文稿时首先看到的内容。

以下代码演示了如何在 C# 中将幻灯片母版设置为演示文稿的默认视图：

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **删除未使用的母版幻灯片**

Aspose.Slides 提供了 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类），以便您删除不需要和未使用的母版幻灯片。以下 C# 代码演示了如何从 PowerPoint 演示文稿中删除母版幻灯片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```