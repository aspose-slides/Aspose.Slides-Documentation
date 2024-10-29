---
title: 幻灯片布局
type: docs
weight: 60
url: /zh/net/slide-layout/
keyword: "设置幻灯片大小，设置幻灯片选项，指定幻灯片大小，页脚可见性，子页脚，内容缩放，页面大小，C#，Csharp，.NET，Aspose.Slides"
description: "在C#或.NET中设置PowerPoint幻灯片大小和选项"
---

幻灯片布局包含了用于幻灯片上所有内容的占位符框和格式信息。布局决定了可用的内容占位符以及它们放置的位置。

幻灯片布局允许您快速创建和设计演示文稿（无论是简单的还是复杂的）。以下是PowerPoint演示文稿中使用的一些最流行的幻灯片布局：

* **标题幻灯片布局**。该布局由两个文本占位符组成。一个占位符用于标题，另一个用于副标题。
* **标题和内容布局**。该布局在顶部包含相对较小的占位符用于标题，并且有一个较大的占位符用于核心内容（图表、段落、项目符号列表、编号列表、图像等）。
* **空白布局**。该布局没有占位符，因此允许您从头开始创建元素。

由于幻灯片母版是存储幻灯片布局信息的层次结构中的顶级幻灯片，您可以使用母版幻灯片访问幻灯片布局并对其进行更改。可以通过类型或名称访问布局幻灯片。类似地，每个幻灯片都有一个唯一的ID，可用于访问它。

另外，您可以直接对演示文稿中的特定幻灯片布局进行更改。

* 为了让您能使用幻灯片布局（包括母版幻灯片中的布局），Aspose.Slides提供了如[LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/)和[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)这样的属性，属于[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类。
* 为了执行相关任务，Aspose.Slides提供了[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/)以及许多其他类型。

{{% alert title="信息" color="info" %}}

有关具体使用母版幻灯片的更多信息，请参见[幻灯片母版](https://docs.aspose.com/slides/net/slide-master/)文章。

{{% /alert %}}

## **将幻灯片布局添加到演示文稿**

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类的实例。
1. 访问[MasterSlide集合](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)。
1. 浏览现有布局幻灯片以确认所需的布局幻灯片是否已经存在于布局幻灯片集合中。否则，添加您想要的布局幻灯片。
1. 基于新的布局幻灯片添加一个空白幻灯片。
1. 保存演示文稿。

以下C#代码向您展示如何将幻灯片布局添加到PowerPoint演示文稿中：

```c#
// 实例化一个表示演示文稿文件的Presentation类
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // 遍历布局幻灯片类型
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // 演示文稿不包含某些布局类型的情况。
        // 演示文稿文件仅包含空白和自定义布局类型。
        // 但具有自定义类型的布局幻灯片有不同的幻灯片名称，
        // 例如“标题”、“标题和内容”等。可以使用这些
        // 名称来选择布局幻灯片。
        // 您也可以使用一组占位符形状类型。例如，
        // 标题幻灯片应仅具有标题占位符类型等。
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 添加带有添加的布局幻灯片的空白幻灯片
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // 将演示文稿保存到磁盘
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **移除未使用的布局幻灯片**

Aspose.Slides提供了来自[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)类的[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)方法，允许您删除不需要的和未使用的布局幻灯片。以下C#代码向您展示如何从PowerPoint演示文稿中移除布局幻灯片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **为幻灯片布局设置大小和类型**

为了让您设置特定布局幻灯片的大小和类型，Aspose.Slides提供了来自[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类的[Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type)和[Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size)属性。以下C#示例演示了该操作：

```c#
// 实例化一个表示演示文稿文件的Presentation对象
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 将生成的演示文稿的幻灯片大小设置为源的大小
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// 将演示文稿保存到磁盘
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **设置幻灯片内页脚可见性**

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

以下C#代码向您展示如何设置幻灯片页脚的可见性（并执行相关任务）：

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // 属性IsFooterVisible用于指定幻灯片页脚占位符缺失
    {
        headerFooterManager.SetFooterVisibility(true); // 方法SetFooterVisibility用于设置幻灯片页脚占位符为可见
    }
    if (!headerFooterManager.IsSlideNumberVisible) // 属性IsSlideNumberVisible用于指定幻灯片页码占位符缺失
    {
        headerFooterManager.SetSlideNumberVisibility(true); // 方法SetSlideNumberVisibility用于设置幻灯片页码占位符为可见
    }
    if (!headerFooterManager.IsDateTimeVisible) // 属性IsDateTimeVisible用于指定幻灯片日期时间占位符缺失
    {
        headerFooterManager.SetDateTimeVisibility(true); // 方法SetFooterVisibility用于设置幻灯片日期时间占位符为可见
    }
    headerFooterManager.SetFooterText("页脚文本"); // 方法SetFooterText用于设置幻灯片页脚占位符的文本
    headerFooterManager.SetDateTimeText("日期和时间文本"); // 方法SetDateTimeText用于设置幻灯片日期时间占位符的文本。

    presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```

## **设置幻灯片内子页脚可见性**

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取母版幻灯片的引用。
1. 将母版幻灯片和所有子页脚占位符设置为可见。
1. 为母版幻灯片和所有子页脚占位符设置文本。
1. 为母版幻灯片和所有子日期时间占位符设置文本。
1. 保存演示文稿。

以下C#代码演示了该操作：

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // 方法SetFooterAndChildFootersVisibility用于将母版幻灯片和所有子页脚占位符设置为可见
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // 方法SetSlideNumberAndChildSlideNumbersVisibility用于将母版幻灯片和所有子页码占位符设置为可见
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // 方法SetDateTimeAndChildDateTimesVisibility用于将母版幻灯片和所有子日期时间占位符设置为可见

    headerFooterManager.SetFooterAndChildFootersText("页脚文本"); // 方法SetFooterAndChildFootersText用于为母版幻灯片和所有子页脚占位符设置文本
    headerFooterManager.SetDateTimeAndChildDateTimesText("日期和时间文本"); // 方法SetDateTimeAndChildDateTimesText用于设置母版幻灯片和所有子日期时间占位符的文本
}
```

## **根据内容缩放设置幻灯片大小**

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例，并加载包含您要设置大小的幻灯片的演示文稿。
1. 创建另一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例以生成新的演示文稿。
1. 通过索引获取幻灯片的引用（来自第一份演示文稿）。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

以下C#示例演示了该操作：

```c#
// 实例化一个表示演示文稿文件的Presentation对象 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 将生成的演示文稿的幻灯片大小设置为源的大小
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // 方法SetSize用于设置幻灯片大小并确保内容适应
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // 方法SetSize用于设置幻灯片大小为内容的最大大小
           
// 将演示文稿保存到磁盘
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **设置生成PDF时的页面大小**

某些演示文稿（如海报）通常会转换为PDF文档。如果您希望将PowerPoint转换为PDF以访问最佳打印和可访问性选项，您希望将幻灯片设置为适合PDF文档的大小（例如A4）。

Aspose.Slides提供了[SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/)类，允许您指定幻灯片的首选设置。以下C#代码向您展示如何使用来自`SlideSize`类的[Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/)属性为演示文稿中的幻灯片设置特定纸张大小：

```c#
// 实例化一个表示演示文稿文件的Presentation对象 
Presentation presentation = new Presentation();

// 设置SlideSize.Type属性 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// 设置PDF选项的不同属性
PdfOptions opts = new PdfOptions();
opts.SufficientResolution = 600;

// 将演示文稿保存到磁盘
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```