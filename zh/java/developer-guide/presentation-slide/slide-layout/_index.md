---
title: 幻灯片布局
type: docs
weight: 60
url: /java/slide-layout/
keyword: "设置幻灯片大小，设置幻灯片选项，指定幻灯片大小，页脚可见性，子页脚，内容缩放，页面大小，Java，Aspose.Slides"
description: "在Java中设置PowerPoint幻灯片大小和选项"
---

幻灯片布局包含幻灯片上所有内容的占位符框和格式信息。布局决定了可用内容占位符及其放置位置。

幻灯片布局允许您快速创建和设计演示文稿（无论是简单还是复杂）。以下是PowerPoint演示文稿中使用的一些最流行的幻灯片布局：

* **标题幻灯片布局**。该布局由两个文本占位符组成。一个占位符用于标题，另一个用于副标题。
* **标题和内容布局**。该布局在顶部包含一个相对较小的占位符用于标题，以及一个更大的占位符用于核心内容（图表、段落、项目符号列表、编号列表、图像等）。
* **空白布局**。该布局没有占位符，因此允许您从头开始创建元素。

由于幻灯片母版是存储幻灯片布局信息的最高层级幻灯片，您可以使用母版幻灯片访问幻灯片布局并对其进行更改。可以通过类型或名称访问布局幻灯片。类似地，每个幻灯片都有一个唯一的ID，可以用来访问它。

或者，您可以直接对演示文稿中的特定幻灯片布局进行更改。

* 为了让您与幻灯片布局（包括母版幻灯片中的布局）进行工作，Aspose.Slides提供了类[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)下的属性，如[getLayoutSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--)和[getMasters()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)。
* 为了执行相关任务，Aspose.Slides提供了[MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)，[MasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/masterlayoutslidecollection/)，[SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/)，[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/baseslideheaderfootermanager/)以及其他许多类型。

{{% alert title="信息" color="info" %}}

有关特别处理母版幻灯片的更多信息，请参见[幻灯片母版](https://docs.aspose.com/slides/java/slide-master/)文章。

{{% /alert %}}

## **向演示文稿添加幻灯片布局**

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的实例。
1. 访问[MasterSlide集合](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/)。
1. 浏览现有布局幻灯片，以确认所需的布局幻灯片已在布局幻灯片集合中存在。否则，添加您想要的布局幻灯片。
1. 基于新的布局幻灯片添加一个空幻灯片。
1. 保存演示文稿。

以下Java代码演示了如何向PowerPoint演示文稿添加幻灯片布局：

```java
// 创建一个表示演示文稿文件的Presentation类实例
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // 浏览布局幻灯片类型
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // 演示文稿不包含某些布局类型的情况。
        // 演示文稿文件仅包含空白和自定义布局类型。
        // 但具有自定义类型的布局幻灯片具有不同的幻灯片名称，
        // 如“标题”、“标题和内容”等。可以使用这些
       // 名称进行布局幻灯片的选择。
        // 也可以使用占位符形状类型的集合。例如，
        // 标题幻灯片应仅具有标题占位符类型等。
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 添加带有添加的布局幻灯片的空幻灯片
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // 将演示文稿保存到磁盘
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **删除未使用的布局幻灯片**

Aspose.Slides提供了[removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)方法，该方法来自[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)类，可以让您删除不需要和未使用的布局幻灯片。以下Java代码演示了如何从PowerPoint演示文稿中删除布局幻灯片：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为幻灯片布局设置大小和类型**

为了允许您为特定布局幻灯片设置大小和类型，Aspose.Slides提供了来自[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的[getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--)和[getSize()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getSize--)属性。以下Java演示了该操作：

```java
// 创建一个表示演示文稿文件的Presentation对象
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // 将生成的演示文稿的幻灯片大小设置为源的大小
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // 克隆所需的幻灯片
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // 将演示文稿保存到磁盘
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **设置幻灯片内页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的实例。
1. 通过索引获取幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。 
1. 将日期时间占位符设置为可见。 
1. 保存演示文稿。

以下Java代码演示了如何设置幻灯片页脚的可见性（并执行相关任务）：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // 方法isFooterVisible用于指定幻灯片页脚占位符缺失
    {
        headerFooterManager.setFooterVisibility(true); // 方法setFooterVisibility用于设置幻灯片页脚占位符为可见
    }
    if (!headerFooterManager.isSlideNumberVisible()) // 方法isSlideNumberVisible用于指定幻灯片页码占位符缺失
    {
        headerFooterManager.setSlideNumberVisibility(true); // 方法setSlideNumberVisibility用于设置幻灯片页码占位符为可见
    }
    if (!headerFooterManager.isDateTimeVisible()) // 方法isDateTimeVisible用于指定幻灯片日期时间占位符缺失
    {
        headerFooterManager.setDateTimeVisibility(true); // 方法SetFooterVisibility用于设置幻灯片日期时间占位符为可见
    }
    headerFooterManager.setFooterText("页脚文本"); // 方法SetFooterText用于设置幻灯片页脚占位符的文本。
    headerFooterManager.setDateTimeText("日期和时间文本"); // 方法SetDateTimeText用于设置幻灯片日期时间占位符的文本。
} finally {
    presentation.dispose();
}
```

## **设置幻灯片内子页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的实例。
1. 通过索引获取母版幻灯片的引用。
1. 将母版幻灯片及所有子页脚占位符设置为可见。
1. 为母版幻灯片及所有子页脚占位符设置文本。 
1. 为母版幻灯片及所有子日期时间占位符设置文本。 
1. 保存演示文稿。

以下Java代码演示了该操作：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // 方法setFooterAndChildFootersVisibility用于将母版幻灯片及所有子页脚占位符设置为可见
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 方法setSlideNumberAndChildSlideNumbersVisibility用于将母版幻灯片及所有子页码占位符设置为可见
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 方法setDateTimeAndChildDateTimesVisibility用于将母版幻灯片及所有子日期时间占位符设置为可见

    headerFooterManager.setFooterAndChildFootersText("页脚文本"); // 方法setFooterAndChildFootersText用于设置母版幻灯片及所有子页脚占位符的文本
    headerFooterManager.setDateTimeAndChildDateTimesText("日期和时间文本"); // 方法setDateTimeAndChildDateTimesText用于设置母版幻灯片及所有子日期时间占位符的文本
} finally {
    presentation.dispose();
}
```

## **根据内容缩放设置幻灯片大小**

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的实例，并加载包含您想要设置大小的幻灯片的演示文稿。 
1. 创建另一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)类的实例来生成新的演示文稿。 
1. 通过索引获取幻灯片的引用（来自第一个演示文稿）。
1. 将幻灯片页脚占位符设置为可见。 
1. 将日期时间占位符设置为可见。 
1. 保存演示文稿。

以下Java代码演示了该操作：

```java
// 创建一个表示演示文稿文件的Presentation对象
Presentation presentation = new Presentation("demo.pptx");
try {
    // 将生成的演示文稿的幻灯片大小设置为源的大小
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // 方法SetSize用于设置幻灯片大小，并根据内容缩放以确保适合
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // 方法SetSize用于设置幻灯片大小，确保最大内容

    // 将演示文稿保存到磁盘
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **生成PDF时设置页面大小**

某些演示文稿（如海报）通常会转换为PDF文档。如果您希望将PowerPoint转换为PDF以访问最佳打印和可访问性选项，则希望将幻灯片设置为适合PDF文档的大小（例如A4）。

Aspose.Slides提供了[SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/)类，允许您指定幻灯片的首选设置。以下Java代码演示了如何使用来自`SlideSize`类的[getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--)属性为演示文稿中的幻灯片设置特定纸张大小：

```java
// 创建一个表示演示文稿文件的Presentation对象 
Presentation presentation = new Presentation();
try {
    // 设置SlideSize.Type属性  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // 设置PDF选项的不同属性
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // 将演示文稿保存到磁盘
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```