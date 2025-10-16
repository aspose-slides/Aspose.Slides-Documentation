---
title: Master Slide
type: docs
weight: 30
url: /cpp/examples/elements/masterslide/
keywords:
- code example
- master slide
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Explore Aspose.Slides for C++ master slide examples: create, edit, and style masters, placeholders, and themes in PPT, PPTX, and ODP with clear C++ code."
---

Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

This article demonstrates how to create, modify, and manage master slides using Aspose.Slides for C++.

## **Add a Master Slide**

This example shows how to create a new master slide by cloning the default one. It then adds a company name banner to all slides through layout inheritance.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Clone the default master slide.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Assign the new master slide to a layout slide.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Assign the layout slide to the first slide in the presentation.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Master slides provide a way to apply consistent branding or shared design elements across all slides. Any changes made to the master will automatically reflect on dependent layout and normal slides.

> 💡 **Note 2:** Any shapes or formatting added to a master slide are inherited by layout slides and, in turn, all normal slides using those layouts.
> The image below illustrates how a text box added on a master slide is automatically rendered on the final slide.

![Master Inheritance Example](master-slide-banner.png)

## **Access a Master Slide**

You can access master slides using the presentation master collection. Here’s how to retrieve and work with them:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Change the background type.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Remove a Master Slide**

Master slides can be removed either by index or by reference.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Remove a master slide by index.
    presentation->get_Masters()->RemoveAt(0);

    // Remove a master slide by reference.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Remove Unused Master Slides**

Some presentations contain master slides that are not in use. Removing these slides can help reduce file size.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Remove all unused master slides (even those marked as Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```
