---
title: 管理演示文稿缩放（C++）
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/cpp/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 幻灯片缩放
- 章节缩放
- 概要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 创建和自定义缩放 — 在章节之间跳转，添加缩略图和过渡效果，适用于 PPT、PPTX 和 ODP 演示文稿。"
---

## **概述**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。当您进行演示时，这种快速跨内容导航的能力可能非常有用。

![overview_image](Overview.png)

* 要在单张幻灯片上对整个演示文稿进行概述，请使用[Summary Zoom](#Summary-Zoom)。
* 仅显示选定的幻灯片，请使用[Slide Zoom](#Slide-Zoom)。
* 仅显示单个章节，请使用[Section Zoom](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更加动态，允许您以任意顺序自由导航幻灯片，而不会中断演示的流程。幻灯片缩放非常适用于章节不多的短篇演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放帮助您深入多条信息，同时感觉像在同一画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/) 枚举、[IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) 接口下的若干方法。

### **创建缩放帧**
您可以通过以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向已创建的幻灯片添加标识文本和背景。
4. 向第一张幻灯片添加缩放帧（包含对已创建幻灯片的引用）。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何在幻灯片上创建缩放帧：
``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for C++，您可以通过以下方式创建带有不同幻灯片预览图像的缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向该幻灯片添加标识文本和背景。
4. 通过向与 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象，用于填充框架。
5. 向第一张幻灯片添加缩放帧（包含对已创建幻灯片的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何使用不同图像创建缩放帧：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 为幻灯片创建背景
SetSlideBackground(slide, Color::get_Cyan());

// 为幻灯片创建文本框
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 为缩放对象创建新图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//添加 ZoomFrame 对象
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化缩放帧**
在前面的章节中，我们展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您必须更改简单帧的格式。您可以对缩放帧应用多种格式选项。

您可以通过以下方式在幻灯片上控制缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向已创建的幻灯片添加一些标识文本和背景。
4. 向第一张幻灯片添加缩放帧（包含对已创建幻灯片的引用）。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象，用于填充框架。
6. 为第一个缩放帧对象设置自定义图像。
7. 更改第二个缩放帧对象的线条格式。
8. 移除第二个缩放帧对象图像的背景。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何在幻灯片上更改缩放帧的格式：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//向演示文稿添加新幻灯片
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 为第二张幻灯片创建背景
SetSlideBackground(slide2, Color::get_Cyan());

// 为第二张幻灯片创建文本框
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 为第三张幻灯片创建背景
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 为第三张幻灯片创建文本框
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//添加 ZoomFrame 对象
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// 为缩放对象创建新图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// 为 zoomFrame1 对象设置自定义图像
zoomFrame1->set_Image(image);

// 为 zoomFrame2 对象设置缩放帧格式
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// 设置 zoomFrame2 对象不显示背景
zoomFrame2->set_ShowBackground(false);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **章节缩放**
章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回到想要重点强调的章节，或用它们突出演示中各部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) 接口下的若干方法。

### **创建章节缩放帧**
您可以通过以下方式向幻灯片添加章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。
3. 向已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 向第一张幻灯片添加章节缩放帧（包含对已创建章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何在幻灯片上创建章节缩放帧：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 添加一个新章节到演示文稿
pres->get_Sections()->AddSection(u"Section 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **使用自定义图像创建章节缩放帧**
使用 Aspose.Slides for C++，您可以通过以下方式创建带有不同幻灯片预览图像的章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。
3. 向已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象，用于填充框架。
5. 向第一张幻灯片添加章节缩放帧（包含对已创建章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何使用不同图像创建章节缩放帧：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

// 为缩放对象创建新图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化章节缩放帧**
要创建更复杂的章节缩放帧，您必须更改简单帧的格式。您可以对章节缩放帧应用多种格式选项。

您可以通过以下方式在幻灯片上控制章节缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。
3. 向已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 向第一张幻灯片添加章节缩放帧（包含对已创建章节的引用）。
6. 更改已创建章节缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象，用于填充框架。
8. 为已创建的章节缩放帧对象设置自定义图像。
9. 设置 *返回到链接章节的原始幻灯片* 的功能。
10. 移除章节缩放帧对象图像的背景。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何在章节缩放帧上更改格式：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 添加一个新章节到演示文稿
pres->get_Sections()->AddSection(u"Section 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 为 SectionZoomFrame 设置格式
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **概要缩放**
概要缩放类似于一个登录页面，所有演示文稿的各部分会一次性展示。当您进行演示时，可以使用该缩放在演示的任意位置之间跳转，顺序任意。您可以发挥创意，快进或重新查看幻灯片的各个部分，而不会中断演示流程。

![overview_image](sumzoomsel.png)

对于概要缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) 接口下的若干方法。

### **创建概要缩放**
您可以通过以下方式向幻灯片添加概要缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将概要缩放帧添加到第一张幻灯片。
4. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何在幻灯片上创建概要缩放帧：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 2", slide);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 3", slide);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 4", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **添加和删除概要缩放章节**
概要缩放帧中的所有章节由 [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) 中。您可以通过以下方式使用 [ISummaryZoomSectionCollection] 接口添加或删除概要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将概要缩放帧添加到第一张幻灯片。
4. 向演示文稿添加新的幻灯片和章节。
5. 将创建的章节添加到概要缩放帧。
6. 从概要缩放帧中移除第一章节。
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何添加和删除概要缩放帧中的章节：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

//向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 2", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 向演示文稿添加新章节
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// 向 Summary Zoom 添加章节
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// 从 Summary Zoom 移除章节
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化概要缩放章节**
要创建更复杂的概要缩放章节对象，您必须更改简单帧的格式。您可以对概要缩放章节对象应用多种格式选项。

您可以通过以下方式在概要缩放帧中控制概要缩放章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将概要缩放帧添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 获取第一个对象的概要缩放章节对象。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象关联的 images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象，用于填充框架。
8. 为已创建的章节缩放帧对象设置自定义图像。
9. 设置 *返回到链接章节的原始幻灯片* 的功能。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了如何更改概要缩放章节对象的格式：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

//向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 2", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 获取第一个 SummaryZoomSection 对象
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// 为 SummaryZoomSection 对象设置格式
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **常见问题**

**我可以控制在显示目标后返回“父”幻灯片吗？**

是的。[Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) 具有 `set_ReturnToParent` 方法，可在观众访问目标内容后返回到原始幻灯片。

**我可以调整缩放过渡的“速度”或持续时间吗？**

是的。缩放支持设置过渡持续时间，您可以控制跳转动画的时长。

**演示文稿中可以包含多少个缩放对象有限制吗？**

文档中未注明硬性的 API 限制。实际限制取决于演示的整体复杂度和观看者的性能。您可以添加许多缩放帧，但需考虑文件大小和渲染时间。