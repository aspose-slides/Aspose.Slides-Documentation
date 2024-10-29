---
title: 幻灯片母版
type: docs
weight: 70
url: /zh/php-java/slide-master/
keywords: "添加幻灯片母版, PPT母版幻灯片, 幻灯片母版PowerPoint, 幻灯片母版中的图像, 占位符, 多个幻灯片母版, 比较幻灯片母版, Java, Aspose.Slides for PHP via Java"
description: "在PowerPoint演示文稿中添加或编辑幻灯片母版"
---

## **什么是PowerPoint中的幻灯片母版**

**幻灯片母版**是一个幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。如果您希望为您的公司创建一份（或一系列）具有相同样式和模板的演示文稿，可以使用幻灯片母版。

幻灯片母版非常有用，因为它允许您一次设置和更改所有演示文稿幻灯片的外观。Aspose.Slides支持PowerPoint的幻灯片母版机制。

VBA还允许您操作幻灯片母版，并执行PowerPoint中支持的相同操作：更改背景、添加形状、自定义布局等。Aspose.Slides提供灵活的机制，使您能够使用幻灯片母版并对其执行基本任务。

以下是基本的幻灯片母版操作：

- 创建或编辑幻灯片母版。
- 将幻灯片母版应用于演示文稿幻灯片。
- 更改幻灯片母版背景。
- 向幻灯片母版添加图像、占位符、智能艺术等。

以下是涉及幻灯片母版的更高级操作：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将带有幻灯片母版的幻灯片复制到另一个演示文稿。
- 查找演示文稿中的重复幻灯片母版。
- 将幻灯片母版设置为演示文稿的默认视图。

{{% alert color="primary" %}}

您可能想查看Aspose的[**在线PowerPoint查看器**](https://products.aspose.app/slides/viewer)，因为它是此处描述的一些核心过程的实时实现。

{{% /alert %}}

## **如何应用幻灯片母版**

在您使用幻灯片母版之前，您可能想了解它们在演示文稿中的用法和应用于幻灯片的方式。

* 每个演示文稿默认至少有一个幻灯片母版。
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同的方式为演示文稿的不同部分设置样式。

在**Aspose.Slides**中，幻灯片母版由[**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/)类型表示。

Aspose.Slides的[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)对象包含[**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)类型的[**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)的列表，其中包含演示文稿中定义的所有母版幻灯片的列表。

除了CRUD操作之外，[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)接口还包含以下有用方法：[**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)和[**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-)。这些方法继承自基本的幻灯片克隆功能。但在处理幻灯片母版时，这些方法允许您实现复杂的设置。

当新的幻灯片被添加到演示文稿时，幻灯片母版会自动应用于它。默认情况下，选择上一个幻灯片的幻灯片母版。

**注意**：演示文稿幻灯片存储在[getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--)列表中，每个新幻灯片默认情况下都会添加到集合的末尾。如果演示文稿只包含一个幻灯片母版，则该幻灯片母版会被选用于所有新幻灯片。这就是您无需为每个新创建的幻灯片定义幻灯片母版的原因。

PowerPoint和Aspose.Slides的原理是相同的。例如，在PowerPoint中，当您添加一个新的演示文稿时，只需在最后一张幻灯片下的底部点击一下，新的幻灯片（带有上一个演示文稿的幻灯片母版）将被创建：

![todo:image_alt_text](slide-master_1.jpg)

在Aspose.Slides中，您可以通过[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)方法在[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类下执行等效任务。

## **幻灯片母版在幻灯片层次结构中的位置**

使用幻灯片布局与幻灯片母版结合可以实现最大的灵活性。幻灯片布局允许您设置与幻灯片母版相同的样式（背景、字体、形状等）。然而，当多个幻灯片布局组合在一个幻灯片母版上时，会创建新的样式。当您将幻灯片布局应用于单个幻灯片时，您可以从幻灯片母版应用的样式更改其样式。

幻灯片母版的优先级高于所有设置项：幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个[IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)对象都有一个带有幻灯片布局列表的[**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--)属性。[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)类型具有一个带有应用于幻灯片的幻灯片布局链接的[**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--)属性。幻灯片与幻灯片母版之间的交互通过幻灯片布局发生。

{{% alert color="info" title="注意" %}}

* 在Aspose.Slides中，所有的幻灯片设置（幻灯片母版、幻灯片布局和幻灯片本身）实际上都是实现了[**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)接口的幻灯片对象。
* 因此，幻灯片母版和幻灯片布局可以实现相同的属性，您需要了解它们的值将如何应用于[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)对象。幻灯片母版首先应用于幻灯片，然后应用幻灯片布局。例如，如果幻灯片母版和幻灯片布局都具有背景值，幻灯片最后将拥有来自幻灯片布局的背景。

{{% /alert %}}

## **幻灯片母版的组成部分**

要了解如何更改幻灯片母版，您需要知道其组成部分。这些是[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)的核心属性。

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) 获取/设置幻灯片背景。
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - 获取/设置幻灯片主体的文本样式。
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) 获取/设置幻灯片母版的所有形状（占位符、图片框等）。
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) 获取/设置ActiveX控件。
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - 获取主题管理器。
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - 获取页眉和页脚管理器。

幻灯片母版方法：

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - 获取所有依赖于幻灯片母版的幻灯片。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 允许您基于当前幻灯片母版和新主题创建一个新的幻灯片母版。然后将新的幻灯片母版应用于所有依赖幻灯片。

## **获取幻灯片母版**

在PowerPoint中，可以通过视图 -> 幻灯片母版菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用Aspose.Slides，您可以通过以下方式访问幻灯片母版：

```php
  $pres = new Presentation();
  try {
    # 获取演示文稿的母版幻灯片
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

[IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)接口表示一个幻灯片母版。[Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--)属性（与[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)类型相关）包含演示文稿中定义的所有幻灯片母版的列表。

## **向幻灯片母版添加图像**

当您向幻灯片母版添加图像时，该图像将出现在所有依赖于该幻灯片母版的幻灯片上。

例如，您可以在幻灯片母版上放置公司的徽标和一些图像，然后切换回幻灯片编辑模式。您应该在每个幻灯片上看到图像。

![todo:image_alt_text](slide-master_4.png)

您可以使用Aspose.Slides向幻灯片母版添加图像：

```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="另请参阅" %}}

有关向幻灯片添加图像的更多信息，请参阅[图片框](/slides/zh/php-java/picture-frame/#create-picture-frame)文章。
{{% /alert %}}

## **向幻灯片母版添加占位符**

这些文本字段是幻灯片母版上的标准占位符：

* 点击编辑母版标题样式

* 编辑母版文本样式

* 第二级

* 第三级

它们也会出现在基于幻灯片母版的幻灯片上。您可以在幻灯片母版上编辑这些占位符，所做的更改会自动应用于幻灯片。

在PowerPoint中，您可以通过幻灯片母版 -> 插入占位符路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们用Aspose.Slides检查一个更复杂的占位符示例。考虑一个带有从幻灯片母版模板化的占位符的幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们希望以这种方式更改幻灯片母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从幻灯片母版对象中检索标题占位符内容，然后使用`PlaceHolder.FillFormat`字段：

```php

```

标题样式和格式将对所有基于幻灯片母版的幻灯片进行更改：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另请参阅" %}}

* [设置占位符中的提示文本](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}

## **更改幻灯片母版上的背景**

当您更改母版幻灯片的背景颜色时，演示文稿中的所有正常幻灯片将获得新颜色。以下是演示该操作的PHP代码：

```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="另请参阅" %}}

- [演示文稿背景](https://docs.aspose.com/slides/php-java/presentation-background/)

- [演示文稿主题](https://docs.aspose.com/slides/php-java/presentation-theme/)

  {{% /alert %}}

## **将幻灯片母版克隆到另一个演示文稿**

要将幻灯片母版克隆到另一个演示文稿，请调用目标演示文稿中的[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)方法，并传递一个幻灯片母版。以下PHP代码展示了如何将幻灯片母版克隆到另一个演示文稿：

```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```

## **向演示文稿添加多个幻灯片母版**

Aspose.Slides允许您向任何给定演示文稿添加多个幻灯片母版和幻灯片布局。这使您能够以多种方式为演示文稿幻灯片设置样式、布局和格式选项。

在PowerPoint中，您可以通过以下方式添加新的幻灯片母版和布局（来自“幻灯片母版菜单”）：

![todo:image_alt_text](slide-master_9.jpg)

使用Aspose.Slides，您可以通过调用[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)方法来添加新的幻灯片母版：

```php
  # 添加新的母版幻灯片
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```

## **比较幻灯片母版**

母版幻灯片实现了[IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)接口，其中包含[**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)方法，可以用来比较幻灯片。当母版幻灯片在结构和静态内容上相同时，返回`true`。

如果两个母版幻灯片的形状、样式、文本、动画和其他设置等相等，则它们是相等的。比较不考虑唯一标识符值（例如SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将幻灯片母版设置为演示文稿的默认视图**

Aspose.Slides允许您将幻灯片母版设置为演示文稿的默认视图。默认视图是当您打开演示文稿时首先看到的内容。

以下代码展示了如何将幻灯片母版设置为演示文稿的默认视图：

```php
  # 实例化表示演示文稿文件的Presentation类
  $presentation = new Presentation();
  try {
    # 将默认视图设置为SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # 保存演示文稿
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **删除未使用的母版幻灯片**

Aspose.Slides提供[removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)方法（来自[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)类），允许您删除不需要和未使用的母版幻灯片。以下PHP代码展示了如何从PowerPoint演示文稿中删除母版幻灯片：

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```