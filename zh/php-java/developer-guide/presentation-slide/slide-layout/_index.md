---
title: 幻灯片布局
type: docs
weight: 60
url: /zh/php-java/slide-layout/
keyword: "设置幻灯片大小，设置幻灯片选项，指定幻灯片大小，页脚可见性，子页脚，内容缩放，页面大小，Java，Aspose.Slides"
description: "设置PowerPoint幻灯片大小和选项"
---

幻灯片布局包含所有出现在幻灯片上的内容的占位符框和格式信息。布局决定了可用的内容占位符及其放置位置。

幻灯片布局允许您快速创建和设计演示文稿（无论简单还是复杂）。以下是一些在PowerPoint演示文稿中使用的最流行的幻灯片布局：

* **标题幻灯片布局**。该布局包含两个文本占位符，一个用于标题，另一个用于副标题。
* **标题和内容布局**。该布局在顶部包含一个相对较小的占位符用于标题，以及一个较大的占位符用于核心内容（图表，段落，项目列表，编号列表，图像等）。
* **空白布局**。该布局没有占位符，因此允许您从头开始创建元素。

由于幻灯片母版是存储有关幻灯片布局信息的最高层次幻灯片，您可以使用母版幻灯片访问幻灯片布局并对其进行更改。可以通过类型或名称访问布局幻灯片。类似地，每个幻灯片都有一个唯一的ID，可以用于访问它。

或者，您可以直接对演示文稿中的特定幻灯片布局进行更改。

* 为了让您能够处理幻灯片布局（包括母版幻灯片中的布局），Aspose.Slides提供了如[getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--)和[getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)等属性，位于[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类下。
* 为了执行相关任务，Aspose.Slides提供[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)，[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)，[SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/)，[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/)等多种类型。

{{% alert title="信息" color="info" %}}

有关使用母版幻灯片的更多信息，请参见[幻灯片母版](https://docs.aspose.com/slides/php-java/slide-master/)文章。

{{% /alert %}}

## **将幻灯片布局添加到演示文稿**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。
1. 访问[MasterSlide集合](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/)。
1. 浏览现有布局幻灯片，以确认所需布局幻灯片是否已存在于布局幻灯片集合中。否则，请添加所需的布局幻灯片。
1. 基于新布局幻灯片添加一个空白幻灯片。
1. 保存演示文稿。

这段PHP代码演示如何将幻灯片布局添加到PowerPoint演示文稿：

```php
  # 实例化一个表示演示文件的Presentation类
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # 遍历布局幻灯片类型
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # 演示文稿不包含某些布局类型的情况。
      # 演示文件仅包含空白和自定义布局类型。
      # 但是，自定义类型的布局幻灯片具有不同的幻灯片名称，
      # 如“标题”，“标题和内容”等。并且可以使用这些
      # 名称进行布局幻灯片选择。
      # 您还可以使用一组占位符形状类型。例如，
      # 标题幻灯片应仅具有标题占位符类型等。
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Title") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
          }
        }
      }
    }
    # 使用添加的布局幻灯片添加空幻灯片
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # 将演示文稿保存到磁盘
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **移除未使用的布局幻灯片**

Aspose.Slides提供了[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)方法，来自[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)类，以允许您删除不需要和未使用的布局幻灯片。这段PHP代码演示如何从PowerPoint演示文稿中移除布局幻灯片：

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置幻灯片布局的大小和类型**

为了让您能够设置特定布局幻灯片的大小和类型，Aspose.Slides提供了[getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--)和[getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--)属性（来自[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类）。以下Java演示该操作：

```php
  # 实例化一个表示演示文件的Presentation对象
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # 为生成的演示文稿设置幻灯片大小为源文件的大小
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # 克隆所需幻灯片
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # 将演示文稿保存到磁盘
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **在幻灯片内设置页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

这段PHP代码演示如何设置幻灯片页脚的可见性（并执行相关任务）：

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # isFooterVisible方法用于指定幻灯片页脚占位符缺失
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// setFooterVisibility方法用于将幻灯片页脚占位符设置为可见

    }
    # isSlideNumberVisible方法用于指定幻灯片页码占位符缺失
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// setSlideNumberVisibility方法用于将幻灯片页码占位符设置为可见

    }
    # isDateTimeVisible方法用于指定幻灯片日期时间占位符缺失
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// SetFooterVisibility方法用于将幻灯片日期时间占位符设置为可见

    }
    $headerFooterManager->setFooterText("页脚文本");// SetFooterText方法用于设置幻灯片页脚占位符的文本。

    $headerFooterManager->setDateTimeText("日期和时间文本");// SetDateTimeText方法用于设置幻灯片日期时间占位符的文本。

  } finally {
    $presentation->dispose();
  }
```

## **在幻灯片内设置子页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。
1. 通过其索引获取母版幻灯片的引用。
1. 将母版幻灯片和所有子页脚占位符设置为可见。
1. 为母版幻灯片和所有子页脚占位符设置文本。
1. 为母版幻灯片和所有子日期时间占位符设置文本。
1. 保存演示文稿。

这段PHP代码演示该操作：

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// setFooterAndChildFootersVisibility方法用于设置母版幻灯片和所有子页脚占位符为可见

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// setSlideNumberAndChildSlideNumbersVisibility方法用于设置母版幻灯片和所有子页码占位符为可见

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// setDateTimeAndChildDateTimesVisibility方法用于设置母版幻灯片和所有子日期时间占位符为可见

    $headerFooterManager->setFooterAndChildFootersText("页脚文本");// setFooterAndChildFootersText方法用于为母版幻灯片和所有子页脚占位符设置文本

    $headerFooterManager->setDateTimeAndChildDateTimesText("日期和时间文本");// setDateTimeAndChildDateTimesText方法用于为母版幻灯片和所有子日期时间占位符设置文本

  } finally {
    $presentation->dispose();
  }
```

## **根据内容缩放设置幻灯片大小**

1. 创建一个表示要设置大小的幻灯片的演示文稿实例。
1. 创建另一个实例的演示文稿类以生成新的演示文稿。
1. 通过索引获取幻灯片的引用（来自第一个演示文稿）。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

这段PHP代码演示该操作：

```php
  # 实例化一个表示演示文件的Presentation对象
  $presentation = new Presentation("demo.pptx");
  try {
    # 为生成的演示文稿设置幻灯片大小为源文件的大小
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// SetSize方法用于设置幻灯片大小以确保内容适合

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// SetSize方法用于设置幻灯片大小，以最大化内容大小

    # 将演示文稿保存到磁盘
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **生成PDF时设置页面大小**

某些演示文稿（如海报）通常会转换为PDF文档。如果您希望将PowerPoint转换为PDF以获得最佳打印和可访问性选项，您希望将幻灯片设置为适合PDF文档的大小（例如A4）。

Aspose.Slides提供[SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/)类，以允许您指定幻灯片的首选设置。此PHP代码演示如何使用[getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--)属性（来自`SlideSize`类）为演示文稿中的幻灯片设置特定纸张大小：

```php
  # 实例化一个表示演示文件的Presentation对象
  $presentation = new Presentation();
  try {
    # 设置SlideSize.Type属性
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # 设置PDF选项的不同属性
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # 将演示文稿保存到磁盘
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```