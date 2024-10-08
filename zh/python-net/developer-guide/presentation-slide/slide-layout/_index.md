---
title: 幻灯片布局
type: docs
weight: 60
url: /zh/python-net/slide-layout/
keyword: "设置幻灯片大小，设置幻灯片选项，指定幻灯片大小，页脚可见性，子页脚，内容缩放，页面大小，Python，Aspose.Slides"
description: "在Python中设置PowerPoint幻灯片大小和选项"
---

幻灯片布局包含占位符框和所有出现在幻灯片上的内容的格式信息。布局确定可用的内容占位符以及它们放置的位置。

幻灯片布局允许您快速创建和设计演示（无论是简单还是复杂）。以下是一些在PowerPoint演示文稿中常用的幻灯片布局：

* **标题幻灯片布局**。这个布局包含两个文本占位符。一个占位符用于标题，另一个用于副标题。
* **标题和内容布局**。这个布局在顶部包含一个相对较小的占位符用于标题和一个更大的占位符用于核心内容（图表、段落、项目符号列表、编号列表、图像等）。
* **空白布局**。这个布局没有占位符，因此允许您从头开始创建元素。

由于幻灯片母版是存储幻灯片布局信息的最高层次的幻灯片，您可以使用母版幻灯片访问幻灯片布局并对其进行更改。布局幻灯片可以通过类型或名称访问。同样，每个幻灯片都有一个唯一的ID，可以用于访问它。

或者，您可以直接对演示文稿中的特定幻灯片布局进行更改。

* Aspose.Slides提供了`layout_slides`和`masters`等属性，用于处理幻灯片布局（包括母版幻灯片）在[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类下。
* 为执行相关任务，Aspose.Slides提供了[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)，[MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)，[SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/)，[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/)等多种类型。

{{% alert title="信息" color="info" %}}

有关如何处理母版幻灯片的更多信息，请参见[幻灯片母版](https://docs.aspose.com/slides/python-net/slide-master/)文章。

{{% /alert %}}

## **将幻灯片布局添加到演示文稿**

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 访问[MasterSlide集合](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/)。
1. 遍历现有的布局幻灯片，确认所需的布局幻灯片已存在于布局幻灯片集合中。否则，添加所需的布局幻灯片。
1. 根据新的布局幻灯片添加一个空幻灯片。
1. 保存演示文稿。

下面的Python代码展示了如何将幻灯片布局添加到PowerPoint演示文稿中：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation类
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 遍历布局幻灯片类型
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # 演示文稿没有某些布局类型的情况。
        # 演示文稿文件仅包含空白和自定义布局类型。
        # 但具有自定义类型的布局幻灯片有不同的幻灯片名称，
        # 如“标题”、“标题和内容”等。可以使用这些
        # 名称进行布局幻灯片选择。
        # 您还可以使用一组占位符形状类型。例如，
        # 标题幻灯片应只包含标题占位符类型等。
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Title and Object":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Title":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # 添加带有添加的布局幻灯片的空幻灯片
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # 将演示文稿保存到磁盘
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的布局幻灯片**

Aspose.Slides提供了[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)类中的`remove_unused_layout_slides`方法，允许您删除不必要和未使用的布局幻灯片。下面的Python代码展示了如何从PowerPoint演示文稿中移除布局幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **为幻灯片布局设置大小和类型**

为了允许您为特定布局幻灯片设置大小和类型，Aspose.Slides提供了来自[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的`type`和`size`属性。下面的Python代码演示了此操作：

```python
import aspose.slides as slides

// 实例化一个表示演示文稿文件的Presentation对象 
# 实例化一个表示演示文稿文件的Presentation对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # 为生成的演示文稿设置与源相同的幻灯片大小
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # 将演示文稿保存到磁盘
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在幻灯片中设置页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 设置幻灯片页脚占位符为可见。
1. 设置日期时间占位符为可见。
1. 保存演示文稿。

下面的Python代码展示了如何设置幻灯片页脚的可见性（并执行相关任务）：

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # 属性is_footer_visible用于指定幻灯片页脚占位符缺失
    if not headerFooterManager.is_footer_visible: 
        # 方法set_footer_visibility用于设置幻灯片页脚占位符为可见
        headerFooterManager.set_footer_visibility(True) 
        # 属性is_slide_number_visible用于指定幻灯片页码占位符缺失
    if not headerFooterManager.is_slide_number_visible:  
        # 方法set_slide_number_visibility用于设置幻灯片页码占位符为可见
        headerFooterManager.set_slide_number_visibility(True) 
        # 属性is_date_time_visible用于指定幻灯片日期时间占位符缺失
    if not headerFooterManager.is_date_time_visible: 
        # 方法set_date_time_visibility用于设置幻灯片日期时间占位符为可见 
        headerFooterManager.set_date_time_visibility(True)

    # 方法set_footer_text用于设置幻灯片页脚占位符的文本 
    headerFooterManager.set_footer_text("页脚文本") 
    # 方法set_date_time_text用于设置幻灯片日期时间占位符的文本。
    headerFooterManager.set_date_time_text("日期和时间文本") 

    # 将演示文稿保存到磁盘
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **在幻灯片中设置子页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过其索引获取母版幻灯片的引用。
1. 设置母版幻灯片及所有子页脚占位符为可见。
1. 为母版幻灯片和所有子页脚占位符设置文本。
1. 为母版幻灯片和所有子日期时间占位符设置文本。
1. 保存演示文稿。

下面的Python代码演示了此操作：

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # 方法set_footer_and_child_footers_visibility用于设置母版幻灯片及所有子页脚占位符为可见
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # 方法set_slide_number_and_child_slide_numbers_visibility用于设置母版幻灯片及所有子页码占位符为可见
    manager.set_date_time_and_child_date_times_visibility(True) # 方法set_date_time_and_child_date_times_visibility用于设置母版幻灯片及所有子日期时间占位符为可见

    manager.set_footer_and_child_footers_text("页脚文本") # 方法set_footer_and_child_footers_text用于设置母版幻灯片及所有子页脚占位符的文本
    manager.set_date_time_and_child_date_times_text("日期和时间文本") # 方法set_date_time_and_child_date_times_text用于设置母版幻灯片及所有子日期时间占位符的文本
```

## **根据内容缩放设置幻灯片大小**

1. 创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例，并加载包含您想要设置大小的幻灯片的演示文稿。
1. 创建另一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例以生成新的演示文稿。
1. 通过其索引获取幻灯片的引用（来自第一个演示文稿）。
1. 设置幻灯片页脚占位符为可见。
1. 设置日期时间占位符为可见。
1. 保存演示文稿。

下面的Python代码演示了此操作：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # 将生成演示文稿的幻灯片大小设置为源的大小
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # 方法set_size用于设置幻灯片大小以确保内容适合
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # 方法set_size用于设置幻灯片大小为内容的最大大小
                
        # 将演示文稿保存到磁盘
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在生成PDF时设置页面大小**

某些演示文稿（如海报）通常被转换为PDF文档。如果您希望将PowerPoint转换为PDF以访问最佳打印和可访问性选项，您需要将幻灯片设置为适合PDF文档的大小（例如A4）。

Aspose.Slides提供了[SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/)类，以便您指定幻灯片的首选设置。下面的Python代码展示了如何使用`type`属性（来自`SlideSize`类）为演示文稿中的幻灯片设置特定的纸张大小：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation对象  
with slides.Presentation() as presentation:
    # 设置SlideSize.Type属性 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # 设置PDF选项的不同属性
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # 将演示文稿保存到磁盘
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```