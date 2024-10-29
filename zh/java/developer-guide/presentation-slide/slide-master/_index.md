---
title: 幻灯片母版
type: docs
weight: 70
url: /zh/java/slide-master/
keywords: "添加幻灯片母版, PPT母版幻灯片, 幻灯片母版PowerPoint, 图片到幻灯片母版, 占位符, 多个幻灯片母版, 比较幻灯片母版, Java, Aspose.Slides for Java"
description: "在Java中添加或编辑PowerPoint演示文稿的幻灯片母版"
---

## **什么是PowerPoint中的幻灯片母版**

**幻灯片母版**是一个幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景和其他属性。如果您想为您的公司创建具有相同样式和模板的演示文稿（或一系列演示文稿），则可以使用幻灯片母版。

幻灯片母版非常有用，因为它允许您一次设置和更改所有演示文稿幻灯片的外观。Aspose.Slides支持PowerPoint的幻灯片母版机制。

VBA还允许您操纵幻灯片母版并执行PowerPoint中支持的相同操作：更改背景、添加形状、自定义布局等。Aspose.Slides提供灵活的机制，允许您使用幻灯片母版并执行基本任务。

这些是基本的幻灯片母版操作：

- 创建或幻灯片母版。
- 将幻灯片母版应用于演示文稿幻灯片。
- 更改幻灯片母版背景。
- 向幻灯片母版添加图像、占位符、智能艺术等。

这些是涉及幻灯片母版的更高级操作：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将幻灯片与幻灯片母版复制到另一个演示文稿。
- 找出演示文稿中的重复幻灯片母版。
- 将幻灯片母版设置为演示文稿的默认视图。

{{% alert color="primary" %}} 

您可能想查看Aspose [**在线PowerPoint查看器**](https://products.aspose.app/slides/viewer)，因为它是这里描述的一些核心过程的实时实现。

{{% /alert %}} 


## **如何应用幻灯片母版**

在您处理幻灯片母版之前，您可能想了解它们如何在演示文稿中使用并应用于幻灯片。

* 每个演示文稿默认至少有一个幻灯片母版。
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同的方式为演示文稿的不同部分设置样式。

在**Aspose.Slides**中，幻灯片母版由 [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) 类型表示。

Aspose.Slides的 [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)对象包含 [**getMasters** ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)类型的 [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) 的列表，该列表包含在演示文稿中定义的所有母版幻灯片。

除了CRUD操作外， [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) 接口还包含这些有用的方法：[**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)和 [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) 方法。这些方法从基本的幻灯片克隆功能继承而来。但在处理幻灯片母版时，这些方法允许您实现复杂的设置。

当新幻灯片添加到演示文稿中时，幻灯片母版会自动应用于它。默认情况下，选择前一个幻灯片的幻灯片母版。

**注意**：演示文稿幻灯片存储在 [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 列表中，每个新幻灯片默认添加到集合的末尾。如果演示文稿只包含一个幻灯片母版，则该幻灯片母版将为所有新幻灯片选择。这就是您无需为每个新幻灯片定义幻灯片母版的原因。

这一原则对PowerPoint和Aspose.Slides是相同的。例如，在PowerPoint中，当您添加一个新演示文稿时，您只需按下最后一张幻灯片下方的底线，然后将创建一个新的幻灯片（带有最后演示文稿的幻灯片母版）：

![todo:image_alt_text](slide-master_1.jpg)

在Aspose.Slides中，您可以通过 [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) 方法在 [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类下执行等效任务。


## **幻灯片母版在幻灯片层次结构中**

使用幻灯片母版的幻灯片布局可以实现最大的灵活性。幻灯片布局允许您设置与幻灯片母版相同的所有样式（背景、字体、形状等）。然而，当多个幻灯片布局组合在一个幻灯片母版上时，将创建一种新样式。当您将幻灯片布局应用于单个幻灯片时，您可以根据幻灯片母版的样式更改其样式。

幻灯片母版优先于所有设置项：幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个 [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)对象都有一个 [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) 属性，其中包含幻灯片布局的列表。 [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) 类型有一个 [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) 属性，包含与应用于幻灯片的幻灯片布局的链接。幻灯片与幻灯片母版之间的交互通过幻灯片布局进行。

{{% alert color="info" title="注意" %}}

* 在Aspose.Slides中，所有幻灯片设置（幻灯片母版、幻灯片布局和幻灯片本身）实际上都是实现 [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) 接口的幻灯片对象。
* 因此，幻灯片母版和幻灯片布局可能实现相同的属性，您需要知道它们的值将如何应用于 [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) 对象。幻灯片母版首先应用于幻灯片，然后应用幻灯片布局。例如，如果幻灯片母版和幻灯片布局都有背景值，则幻灯片将最后得到幻灯片布局的背景。

{{% /alert %}}


## **幻灯片母版的组成**

要了解如何更改幻灯片母版，您需要知道其组成部分。这些是 [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/) 的核心属性。

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) 获取/设置幻灯片背景。
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - 获取/设置幻灯片主体的文本样式。
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) 获取/设置幻灯片母版的所有形状（占位符、图片框等）。
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) 获取/设置ActiveX控件。
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - 获取主题管理器。
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - 获取页眉和页脚管理器。

幻灯片母版方法：

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - 获取所有依赖于幻灯片母版的幻灯片。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 允许您基于当前幻灯片母版和新主题创建一个新的幻灯片母版。新的幻灯片母版将应用于所有依赖的幻灯片。


## **获取幻灯片母版**

在PowerPoint中，可以通过“视图 -> 幻灯片母版”菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用Aspose.Slides，您可以这样访问幻灯片母版：

```java
Presentation pres = new Presentation();
try {
    // 获取演示文稿的母版幻灯片
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

[IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) 接口表示一个幻灯片母版。 [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) 属性（与 [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) 类型相关）包含在演示文稿中定义的所有幻灯片母版的列表。


## **向幻灯片母版添加图像**

当您向幻灯片母版添加图像时，该图像将出现在所有依赖于该幻灯片母版的幻灯片上。

例如，您可以在幻灯片母版上放置公司的徽标和一些图像，然后切换回幻灯片编辑模式。您应该在每张幻灯片上看到图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用Aspose.Slides向幻灯片母版添加图像：

```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="另请参见" %}} 

有关向幻灯片添加图像的更多信息，请参见 [图片框](/slides/zh/java/picture-frame/#create-picture-frame) 文章。
{{% /alert %}}


## **向幻灯片母版添加占位符**

这些文本字段是幻灯片母版上的标准占位符：

* 点击编辑母版标题样式

* 编辑母版文本样式

* 第二级

* 第三级 

它们也出现在基于幻灯片母版的幻灯片上。您可以编辑幻灯片母版上的这些占位符，所做的更改会自动应用于幻灯片。

在PowerPoint中，您可以通过幻灯片母版 -> 插入占位符路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们用Aspose.Slides检查一个关于占位符的更复杂的示例。考虑一张带有幻灯片母版模板的占位符的幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们想要在幻灯片母版上以这种方式更改标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从幻灯片母版对象中检索标题占位符的内容，然后使用 `PlaceHolder.FillFormat` 字段：

```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
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

基于幻灯片母版的所有幻灯片的标题样式和格式将会改变：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另请参见" %}} 

* [在占位符中设置提示文本](https://docs.aspose.com/slides/java/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **更改幻灯片母版背景**

当您更改母版幻灯片的背景颜色时，演示文稿中的所有普通幻灯片将获得新颜色。以下Java代码演示了该操作：

```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="另请参见" %}} 

- [演示文稿背景](https://docs.aspose.com/slides/java/presentation-background/)

- [演示文稿主题](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **将幻灯片母版克隆到另一个演示文稿**

要将幻灯片母版克隆到另一个演示文稿，调用目标演示文稿中的 [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，并传入一个幻灯片母版。以下Java代码演示了如何将幻灯片母版克隆到另一个演示文稿：

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **向演示文稿添加多个幻灯片母版**

Aspose.Slides允许您向任何给定的演示文稿添加多个幻灯片母版和幻灯片布局。这使您能够以多种方式设置演示文稿幻灯片的样式、布局和格式选项。

在PowerPoint中，您可以通过“幻灯片母版”菜单添加新的幻灯片母版和布局，如下所示：

![todo:image_alt_text](slide-master_9.jpg)

使用Aspose.Slides，您可以通过调用 [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法添加新的幻灯片母版：

```java
// 添加一个新的母版幻灯片
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **比较幻灯片母版**

母版幻灯片实现了 [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) 接口，其中包含 [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) 方法，可以用于比较幻灯片。它对于结构和静态内容相同的母版幻灯片返回 `true`。

如果两个母版幻灯片的形状、样式、文本、动画和其他设置等相等，则它们被认为相等。比较不会考虑唯一标识符值（例如SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将幻灯片母版设置为演示文稿默认视图**

Aspose.Slides允许您将幻灯片母版设置为演示文稿的默认视图。默认视图是您打开演示文稿时首先看到的内容。

以下代码演示了如何在Java中将幻灯片母版设置为演示文稿的默认视图：

```java
// 实例化表示演示文稿文件的Presentation类
Presentation presentation = new Presentation();
try {
    // 将默认视图设置为幻灯片母版视图
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // 保存演示文稿
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **删除未使用的母版幻灯片**

Aspose.Slides提供了 [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法（来自 [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) 类），以允许您删除不需要和未使用的母版幻灯片。以下Java代码演示了如何从PowerPoint演示文稿中删除母版幻灯片：

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```