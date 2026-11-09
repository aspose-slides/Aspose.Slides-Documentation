---
title: Manage Presentation Zoom in C++
linktitle: Manage Zoom
type: docs
weight: 60
url: /cpp/manage-zoom/
keywords:
- zoom
- zoom frame
- slide zoom
- section zoom
- summary zoom
- add zoom
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Create and customize Zoom with Aspose.Slides for C++ — jump between sections, add thumbnails and transitions in PowerPoint presentations."
---

## **Introduction**

PowerPoint zooms let you navigate between specific slides and sections during a slide show. With Aspose.Slides for C++, you can create slide, section, and summary zooms and customize their previews, borders, and transitions.

![PowerPoint zoom overview](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#summary-zoom).
* To show selected slides only, use a [Slide Zoom](#slide-zoom).
* To show a single section only, use a [Section Zoom](#section-zoom).

## **Slide Zoom**

A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms let you explore related information from a single overview slide.

![Selecting slides for a slide zoom](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) interface, and methods on the [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) interface.

### **Create Zoom Frames**

Use [IShapeCollection::AddZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addzoomframe/) to place links to individual slides on an overview slide. This example creates two target slides with distinct backgrounds and labels, then adds a preview of each to the first slide and saves the presentation as PPTX. Frame positions and dimensions are specified in points.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto secondSlide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());

secondSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
secondSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
secondSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Cyan());

auto textBox = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
textBox->get_TextFrame()->set_Text(u"Second Slide");

thirdSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
thirdSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
thirdSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkKhaki());

textBox = thirdSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
textBox->get_TextFrame()->set_Text(u"Third Slide");

overviewSlide->get_Shapes()->AddZoomFrame(20, 20, 250, 200, secondSlide);
overviewSlide->get_Shapes()->AddZoomFrame(200, 250, 250, 200, thirdSlide);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Create Zoom Frames with Custom Images**

Pass a custom image to [IShapeCollection::AddZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addzoomframe/) to replace the target slide's default preview. This example requires a local image, loads it with [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/), and adds it to the presentation using [IImageCollection::AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). The resulting frame displays that image while still linking to the second slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <Util/Images.h>
#include <IImage.h>
#include <DOM/IImageCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Cyan());

auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
textBox->get_TextFrame()->set_Text(u"Second Slide");

auto image = Images::FromFile(u"image.png");
auto previewImage = presentation->get_Images()->AddImage(image);
image->Dispose();

overviewSlide->get_Shapes()->AddZoomFrame(20, 20, 300, 200, slide, previewImage);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Zoom Frames**

This example customizes two slide zoom frames. It assigns a local image to the first frame through [IZoomObject::set_ZoomImage](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_zoomimage/), and gives the second frame a five-point, dash-dot pink border through [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/). Setting [IZoomObject::set_ShowBackground](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_showbackground/) to `false` hides the second frame's background. A local image is required for the custom preview; both frames retain their slide targets in the saved PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <Util/Images.h>
#include <IImage.h>
#include <DOM/IImageCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Zoom/IZoomFrame.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/LineDashStyle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto secondSlide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());

secondSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
secondSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
secondSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Cyan());

auto textBox = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
textBox->get_TextFrame()->set_Text(u"Second Slide");

thirdSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
thirdSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
thirdSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkKhaki());

textBox = thirdSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
textBox->get_TextFrame()->set_Text(u"Third Slide");

auto firstZoomFrame = overviewSlide->get_Shapes()->AddZoomFrame(20, 20, 250, 200, secondSlide);
auto secondZoomFrame = overviewSlide->get_Shapes()->AddZoomFrame(200, 250, 250, 200, thirdSlide);

auto image = Images::FromFile(u"image.png");
auto previewImage = presentation->get_Images()->AddImage(image);
image->Dispose();

firstZoomFrame->set_ZoomImage(previewImage);

secondZoomFrame->get_LineFormat()->set_Width(5);
secondZoomFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondZoomFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
secondZoomFrame->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

secondZoomFrame->set_ShowBackground(false);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Section Zoom**

A section zoom links to a section in your presentation. Use it to revisit a topic or show how different parts of the presentation connect.

![Selecting a section for a section zoom](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) interface and methods on the [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) interface.

### **Create Section Zoom Frames**

Create a section with [ISectionCollection::AddSection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/addsection/), then pass the returned section to [IShapeCollection::AddSectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsectionzoomframe/). This example places a section zoom on the first slide and links it to a section beginning with a colored slide. The frame's position and dimensions are specified in points, and the presentation is saved as PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_YellowGreen());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

auto section = presentation->get_Sections()->AddSection(u"Section 1", slide);
auto sectionZoomFrame = overviewSlide->get_Shapes()->AddSectionZoomFrame(20, 20, 300, 200, section);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Create Section Zoom Frames with Custom Images**

The image overload of [IShapeCollection::AddSectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsectionzoomframe/) lets you display a custom preview without changing the destination section. This example requires a local image, which is loaded with [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) and added through [IImageCollection::AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). The saved presentation contains a section zoom on the first slide linked to the newly created section.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <Util/Images.h>
#include <IImage.h>
#include <DOM/IImageCollection.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_YellowGreen());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

auto image = Images::FromFile(u"image.png");
auto previewImage = presentation->get_Images()->AddImage(image);
image->Dispose();

auto section = presentation->get_Sections()->AddSection(u"Section 1", slide);
auto sectionZoomFrame = overviewSlide->get_Shapes()->AddSectionZoomFrame(20, 20, 300, 200, section, previewImage);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Change a Section Zoom's Target Section**

Use [ISectionZoomFrame::set_TargetSection](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/set_targetsection/) to redirect an existing section zoom without recreating it. Choose a populated section from the same presentation's [get_Sections](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sections/) collection. Assigning an empty section leaves the current target unchanged, so check [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/getslideslistofsection/) before assigning it. See [Manage Slide Sections](/slides/cpp/slide-section/) for more about sections.

The following example loads a presentation file, which must contain multiple populated sections, an existing section zoom named `Section navigation`, and a section with the unique name `Results`. It searches all slides for the zoom and finds the destination by name rather than by a collection index that can change when sections are reordered. If names are not unique, use [ISection::get_SectionId](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_sectionid/) to identify the destination instead.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/Zoom/ISectionZoomFrame.h>
#include <system/console.h>
#include <DOM/ISectionSlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"section-zoom.pptx");

System::SharedPtr<ISectionZoomFrame> zoom;
for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count() && !zoom; ++slideIndex)
{
    auto slide = presentation->get_Slide(slideIndex);
    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto candidate = System::DynamicCast<ISectionZoomFrame>(slide->get_Shape(shapeIndex));
        if (candidate && candidate->get_Name() == u"Section navigation")
        {
            zoom = candidate;
            break;
        }
    }
}

System::SharedPtr<ISection> targetSection;
for (auto sectionIndex = 0; sectionIndex < presentation->get_Sections()->get_Count(); ++sectionIndex)
{
    auto section = presentation->get_Sections()->idx_get(sectionIndex);
    if (section->get_Name() == u"Results")
    {
        targetSection = section;
        break;
    }
}

if (!zoom || !targetSection)
{
    System::Console::WriteLine(u"The section zoom or destination section was not found.");
}
else if (targetSection->GetSlidesListOfSection()->get_Count() == 0)
{
    System::Console::WriteLine(u"The destination section is empty.");
}
else
{
    auto currentSection = zoom->get_TargetSection();
    if (currentSection)
    {
        System::Console::WriteLine(u"Current section: " + currentSection->get_Name());
    }
    zoom->set_TargetSection(targetSection);
    presentation->Save(u"section-zoom-updated.pptx", SaveFormat::Pptx);
}

```

### **Format Section Zoom Frames**

This example moves and resizes a section zoom to 100 by 75 points, assigns a local image through [IZoomObject::set_ZoomImage](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_zoomimage/), and applies a 2.5-point, dash-dot brown border. It enables [IZoomObject::set_ReturnToParent](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_returntoparent/) to return to the originating slide after the section, disables [IZoomObject::set_ShowBackground](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_showbackground/), and sets [IZoomObject::set_TransitionDuration](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_transitionduration/) to 1.5 seconds. A local image is required for the custom preview.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <Util/Images.h>
#include <IImage.h>
#include <DOM/IImageCollection.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Zoom/ISectionZoomFrame.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/LineDashStyle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_YellowGreen());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

auto section = presentation->get_Sections()->AddSection(u"Section 1", slide);

auto sectionZoomFrame = overviewSlide->get_Shapes()->AddSectionZoomFrame(20, 20, 300, 200, section);
sectionZoomFrame->set_X(100);
sectionZoomFrame->set_Y(300);
sectionZoomFrame->set_Width(100);
sectionZoomFrame->set_Height(75);

auto image = Images::FromFile(u"image.png");
auto previewImage = presentation->get_Images()->AddImage(image);
image->Dispose();

sectionZoomFrame->set_ZoomImage(previewImage);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

sectionZoomFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomFrame->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
sectionZoomFrame->get_LineFormat()->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Summary Zoom**

A summary zoom provides an overview of presentation sections. During a slide show, you can use it to jump to a section, skip ahead, or revisit a topic without following the slide order.

![Selecting sections for a summary zoom](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) interfaces and methods on the [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) interface.

### **Create a Summary Zoom**

Use [IShapeCollection::AddSummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsummaryzoomframe/) to create an overview of the presentation's sections. This example creates four sections with distinct slide backgrounds and adds a summary zoom to the first slide. The frame's position and dimensions are specified in points, and the resulting overview is saved in a PPTX presentation.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Zoom/ISummaryZoomFrame.h>
#include <DOM/Zoom/ISummaryZoomSection.h>
#include <DOM/Zoom/ISummaryZoomSectionCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 1", slide);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Aqua());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 2", slide);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Chartreuse());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 3", slide);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkGreen());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 4", slide);

auto summaryZoomFrame = overviewSlide->get_Shapes()->AddSummaryZoomFrame(150, 50, 300, 200);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Add and Remove a Summary Zoom Section**

A summary zoom stores its [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) objects in [ISummaryZoomFrame::get_SummaryZoomCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/get_summaryzoomcollection/). This example creates an overview of two sections, adds a third section using [ISummaryZoomSectionCollection::AddSummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/addsummaryzoomsection/), and removes the first section's entry using [ISummaryZoomSectionCollection::RemoveSummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/removesummaryzoomsection/). Removing the entry leaves the presentation section and its slides intact.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Zoom/ISummaryZoomFrame.h>
#include <DOM/Zoom/ISummaryZoomSection.h>
#include <DOM/Zoom/ISummaryZoomSectionCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

auto firstSection = presentation->get_Sections()->AddSection(u"Section 1", slide);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Aqua());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 2", slide);

auto summaryZoomFrame = overviewSlide->get_Shapes()->AddSummaryZoomFrame(150, 50, 300, 200);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Chartreuse());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

auto thirdSection = presentation->get_Sections()->AddSection(u"Section 3", slide);

summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(thirdSection);

summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(firstSection);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Summary Zoom Sections**

This example formats the first entry in [ISummaryZoomFrame::get_SummaryZoomCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/get_summaryzoomcollection/), using the zero-based index `0`. It requires a local image for [IZoomObject::set_ZoomImage](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_zoomimage/), applies a 1.5-point, dash-dot black border, and sets [IZoomObject::set_TransitionDuration](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_transitionduration/) to 1.5 seconds. Setting [IZoomObject::set_ReturnToParent](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_returntoparent/) to `false` disables the automatic return to the summary slide for this entry.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <Util/Images.h>
#include <IImage.h>
#include <DOM/IImageCollection.h>
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Zoom/ISummaryZoomFrame.h>
#include <DOM/Zoom/ISummaryZoomSection.h>
#include <DOM/Zoom/ISummaryZoomSectionCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto overviewSlide = presentation->get_Slide(0);

auto slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 1", slide);

slide = presentation->get_Slides()->AddEmptySlide(overviewSlide->get_LayoutSlide());
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Aqua());
slide->get_Background()->set_Type(BackgroundType::OwnBackground);

presentation->get_Sections()->AddSection(u"Section 2", slide);

auto summaryZoomFrame = overviewSlide->get_Shapes()->AddSummaryZoomFrame(150, 50, 300, 200);

auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

auto image = Images::FromFile(u"image.png");
auto previewImage = presentation->get_Images()->AddImage(image);
image->Dispose();

summarySection->set_ZoomImage(previewImage);
summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. Set [IZoomObject::set_ReturnToParent](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_returntoparent/) to `true` to return to the originating slide after the target content is shown.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Set [IZoomObject::set_TransitionDuration](https://reference.aspose.com/slides/cpp/aspose.slides/izoomobject/set_transitionduration/) to control the transition duration in seconds.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.
