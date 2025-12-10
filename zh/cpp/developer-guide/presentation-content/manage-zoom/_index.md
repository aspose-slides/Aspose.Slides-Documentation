---
title: 在 C++ 中管理演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/cpp/manage-zoom/
keywords:
- 缩放
- 缩放框架
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 创建和自定义缩放——在章节之间跳转，添加缩略图和过渡效果，支持 PPT、PPTX 和 ODP 演示文稿。"
---

## **概述**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。演示时，这种快速跨内容导航的能力可能非常有用。

![overview_image](Overview.png)

* 要在单张幻灯片上概括整个演示文稿，请使用[摘要缩放](#Summary-Zoom)。
* 只显示选定幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 只显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更具活力，让您可以自由地按任意顺序在幻灯片之间导航，而不会中断演示的流程。幻灯片缩放非常适用于章节不多的短篇演示，但在其他演示场景中也可使用。

幻灯片缩放帮助您深入多个信息块，同时让您感觉置于同一画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) 枚举、[IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) 接口，以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的若干方法。

### **创建缩放框架**

您可以通过以下方式在幻灯片上添加缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建您打算链接缩放框架的新幻灯片。
3. 为已创建的幻灯片添加标识文本和背景。
4. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何在幻灯片上创建缩放框架：
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

// 向演示文稿添加新幻灯片
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

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

// 添加 ZoomFrame 对象
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **使用自定义图像创建缩放框架**

使用 Aspose.Slides for C++，您可以通过以下方式创建具有不同幻灯片预览图像的缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一个您打算链接缩放框架的新幻灯片。
3. 为该幻灯片添加标识文本和背景。
4. 通过向与 [Presentation] 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充框架。
5. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何使用不同图像创建缩放框架：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//为第二张幻灯片创建背景
SetSlideBackground(slide, Color::get_Cyan());

//为第三张幻灯片创建文本框
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//为缩放对象创建新图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//添加 ZoomFrame 对象
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化缩放框架**

在前面的章节中，我们展示了如何创建简单的缩放框架。要创建更复杂的缩放框架，您必须更改简单框架的格式。您可以对缩放框架应用多种格式化选项。

您可以通过以下方式在幻灯片上控制缩放框架的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建您打算链接缩放框架的新幻灯片。
3. 为已创建的幻灯片添加一些标识文本和背景。
4. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
5. 通过向与 [Presentation] 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充框架。
6. 为第一个缩放框架对象设置自定义图像。
7. 更改第二个缩放框架对象的线条格式。
8. 删除第二个缩放框架对象图像的背景。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何在幻灯片上更改缩放框架的格式：
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

// 添加 ZoomFrame 对象
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

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回到您想要特别强调的章节，或用来突出演示中某些部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的若干方法。

### **创建章节缩放框架**

您可以通过以下方式在幻灯片上添加章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一个新幻灯片。
3. 为已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放框架的新章节。
5. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何在幻灯片上创建章节缩放框架：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **使用自定义图像创建章节缩放框架**

使用 Aspose.Slides for C++，您可以通过以下方式创建具有不同幻灯片预览图像的章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一个新幻灯片。
3. 为已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放框架的新章节。
5. 通过向与 [Presentation] 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充框架。
5. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何使用不同图像创建章节缩放框架：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 添加新章节到演示文稿
pres->get_Sections()->AddSection(u"Section 1", slide);

//为缩放对象创建新图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

//保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化章节缩放框架**

要创建更复杂的章节缩放框架，您必须更改简单框架的格式。您可以对章节缩放框架应用多种格式化选项。

您可以通过以下方式在幻灯片上控制章节缩放框架的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一个新幻灯片。
3. 为已创建的幻灯片添加标识背景。
4. 创建您打算链接缩放框架的新章节。
5. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
6. 更改已创建章节缩放对象的大小和位置。
7. 通过向与 [Presentation] 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充框架。
8. 为已创建的章节缩放框架对象设置自定义图像。
9. 设置*从链接章节返回原始幻灯片*的功能。
10. 删除章节缩放框架对象图像的背景。
11. 更改第二个缩放框架对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何更改章节缩放框架的格式：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新章节
pres->get_Sections()->AddSection(u"Section 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// SectionZoomFrame 的格式设置
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


## **摘要缩放**

摘要缩放类似于一个登陆页面，演示文稿的所有部分一次性展示。当您进行演示时，可以使用缩放在演示的任意位置之间任意顺序跳转。您可以创意演示、提前跳过或重新观看幻灯片的某些部分，而不会中断演示的流程。

![overview_image](sumzoomsel.png)

对于摘要缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的若干方法。

### **创建摘要缩放**

您可以通过以下方式在幻灯片上添加摘要缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 为创建的幻灯片创建带标识背景的新幻灯片并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何在幻灯片上创建摘要缩放框架：
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


### **添加和移除摘要缩放章节**

所有摘要缩放框架中的章节均由 [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 对象中。您可以通过以下方式使用 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 接口添加或移除摘要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 为创建的幻灯片创建带标识背景的新幻灯片并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 向演示文稿添加新幻灯片和新章节。
5. 将创建的章节添加到摘要缩放框架。
6. 从摘要缩放框架中移除第一章节。
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何在摘要缩放框架中添加和移除章节：
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

// 添加章节到 Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// 删除 Summary Zoom 中的章节
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **格式化摘要缩放章节**

要创建更复杂的摘要缩放章节对象，您必须更改简单框架的格式。您可以对摘要缩放章节对象应用多种格式化选项。

您可以通过以下方式在摘要缩放框架中控制摘要缩放章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 为创建的幻灯片创建带标识背景的新幻灯片并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个对象的摘要缩放章节对象。
5. 通过向与 [Presentation] 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充框架。
6. 为已创建的章节缩放框架对象设置自定义图像。
7. 设置*从链接章节返回原始幻灯片*的功能。
8. 更改第二个缩放框架对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码展示了如何更改摘要缩放章节对象的格式：
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 添加新幻灯片到演示文稿
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 添加新章节到演示文稿
pres->get_Sections()->AddSection(u"Section 1", slide);

// 添加新幻灯片到演示文稿
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 添加新章节到演示文稿
pres->get_Sections()->AddSection(u"Section 2", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 获取第一个 SummaryZoomSection 对象
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection 对象的格式设置
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

**Can I control returning to the 'parent' slide after showing the target?**

是的。Zoom 框架或章节的 `set_ReturnToParent` 方法可在查看目标内容后将观看者返回到原始幻灯片。

**Can I adjust the 'speed' or duration of the Zoom transition?**

是的。Zoom 支持设置过渡持续时间，以便您控制跳转动画的时长。

**Are there limits on how many Zoom objects a presentation can contain?**

目前文档中未列出硬性 API 限制。实际限制取决于演示文稿的整体复杂度以及观看者的性能。您可以添加大量 Zoom 框架，但请注意文件大小和渲染时间。