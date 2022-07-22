---
title: Merge Presentation - C++ PowerPoint API
linktitle: Merge Presentation
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "Merge PowerPoint, PPTX, PPT, combine PowerPoint, merge presentation, combine presentation, C++"
description: The article explains how you can merge or combine PowerPoint Presentations using C++ PowerPoint API or Library.
---

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free online** [Merger app](https://products.aspose.app/slides/merger). It allows people to merge PowerPoint presentations in the same format (PPT to PPT, PPTX to PPTX, etc.) and merge presentations in different formats (PPT to PPTX, PPTX to ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) , however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data. 

**See also**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **What Can Be Merged**

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

### **Merging Options**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) methods (from the [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides. 

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) method that allows you to combine slides while the slides retain their layouts and styles (default parameters). 

This C++ code shows you how to merge presentations:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations with Slide Master**

Aspose.Slides provides the [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation. 

This code in C++ demonstrates the described operation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `AddClone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) will be thrown. 

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) method instead when merging. 

## **Merge Specific Slides From Presentations**

This C++ code shows you how to select and combine specific slides from different presentations to get one output presentation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations With Slide Layout**

This C++ code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations With Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

You cannot merge presentations with different slide sizes. 

{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Slides to Presentation Section**

This C++ code shows you how to merge a specific slide to a section in a presentation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}
