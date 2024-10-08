---
title: 管理缩放
type: docs
weight: 60
url: /cpp/manage-zoom/
keywords: "缩放, 缩放帧, 添加缩放, 格式化缩放帧, 总结缩放, PowerPoint 演示文稿, C++, Aspose.Slides for C++"
description: "在 C++ 中为 PowerPoint 演示文稿添加缩放或缩放帧"
---

## **概述**
PowerPoint 中的缩放功能允许您在特定幻灯片、部分和演示文稿中跳转。当您进行演示时，这种快速跨内容导航的能力可能非常有用。

![overview_image](Overview.png)

* 要在单个幻灯片上总结整个演示文稿，请使用 [总结缩放](#Summary-Zoom)。
* 要仅显示选定的幻灯片，请使用 [幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用 [部分缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更具动态性，允许您在选择的任意顺序中自由导航幻灯片，而不会打断演示的流程。幻灯片缩放非常适合没有很多部分的简短演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放可以帮助您深入了解多条信息，同时又感觉您位于单个画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) 枚举、[IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) 接口以及一些在 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的方法。

### **创建缩放帧**

您可以通过以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建您打算链接到的缩放帧的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何在幻灯片上创建缩放帧：

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

// 向演示文稿添加新的幻灯片
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 为第二张幻灯片创建背景
SetSlideBackground(slide2, Color::get_Cyan());

// 为第二张幻灯片创建文本框
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"第二张幻灯片");

// 为第三张幻灯片创建背景
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 为第三张幻灯片创建文本框
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"第三张幻灯片");

// 添加 ZoomFrame 对象
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for C++，您可以通过以下方式创建带有不同幻灯片预览图像的缩放帧：
1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一个您打算链接到的幻灯片。
3. 为幻灯片添加标识文本和背景。
4. 通过将图像添加到与 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象关联的图像集合中，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，该图像将用于填充帧。
5. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何使用不同的图像创建缩放帧：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 为第二张幻灯片创建背景
SetSlideBackground(slide, Color::get_Cyan());

// 为第三张幻灯片创建文本框
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"第二张幻灯片");

// 为缩放对象创建新的图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// 添加 ZoomFrame 对象
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **格式化缩放帧**
在前面的部分中，我们向您展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您必须修改简单帧的格式。可以对缩放帧应用几种格式设置选项。

您可以通过以下方式控制幻灯片上缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建新幻灯片以链接到您打算链接的缩放帧。
3. 向创建的幻灯片添加一些标识文本和背景。
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。
5. 通过将图像添加到与 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象关联的图像集合中，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，该对象将用于填充帧。
6. 为第一个缩放帧对象设置一个自定义图像。
7. 更改第二个缩放帧对象的线条格式。
8. 从第二个缩放帧对象的图像中删除背景。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何更改幻灯片上缩放帧的格式：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
// 向演示文稿添加新的幻灯片
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 为第二张幻灯片创建背景
SetSlideBackground(slide2, Color::get_Cyan());

// 为第二张幻灯片创建文本框
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"第二张幻灯片");

// 为第三张幻灯片创建背景
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 为第三张幻灯片创建文本框
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"第三张幻灯片");

// 添加 ZoomFrame 对象
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// 为缩放对象创建新的图像
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

## **部分缩放**

部分缩放是链接到您演示文稿中的一个部分。您可以使用部分缩放返回到您想真正强调的部分。或者，您可以使用它们来突出您演示文稿中某些部分之间的联系。

![overview_image](seczoomsel.png)

对于部分缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) 接口和一些在 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的方法。

### **创建部分缩放帧**

您可以通过以下方式向幻灯片添加部分缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建一个您打算链接到的部分。
5. 将部分缩放帧（包含对创建的部分的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何在幻灯片上创建缩放帧：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **使用自定义图像创建部分缩放帧**

使用 Aspose.Slides for C++，您可以通过以下方式创建带有不同幻灯片预览图像的部分缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建一个您打算链接到的部分。
5. 通过将图像添加到与 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象关联的图像集合中，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，该图像将用于填充帧。
6. 将部分缩放帧（包含对创建的部分的引用）添加到第一张幻灯片。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何使用不同的图像创建缩放帧：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 为缩放对象创建新的图像
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **格式化部分缩放帧**

要创建更复杂的部分缩放帧，您必须修改简单帧的格式。可以对部分缩放帧应用几种格式设置选项。

您可以通过以下方式控制幻灯片上部分缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建一个您打算链接到的部分。
5. 将部分缩放帧（包含对创建的部分的引用）添加到第一张幻灯片。
6. 更改创建的部分缩放对象的大小和位置。
7. 通过将图像添加到与 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象关联的图像集合中，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，该对象将用于填充帧。
8. 为创建的部分缩放帧对象设置自定义图像。
9. 设置“从链接的部分返回到原始幻灯片”的能力。
10. 从部分缩放帧对象的图像中删除背景。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何更改部分缩放帧的格式：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 添加 SectionZoomFrame 对象
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 部分缩放帧的格式
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

## **总结缩放**

总结缩放就像一个着陆页，所有演示文稿的部分都会一次性显示。当您进行演示时，可以使用缩放从演示文稿中的一个地方跳转到另一个地方，无论您喜欢哪种顺序。您可以发挥创造力，提前跳过，或重新访问幻灯片放映的部分，而不会打断演示的流程。

![overview_image](sumzoomsel.png)

对于总结缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 接口，以及一些在 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口下的方法。

### **创建总结缩放**

您可以通过以下方式向幻灯片添加总结缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建具有标识背景的新幻灯片和为创建的幻灯片的新部分。
3. 将总结缩放帧添加到第一张幻灯片。
4. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何在幻灯片上创建总结缩放帧：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新的幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 向演示文稿添加新的幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 2", slide);

// 向演示文稿添加新的幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 3", slide);

// 向演示文稿添加新的幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 4", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **添加和删除总结缩放部分**

总结缩放帧中的所有部分由 [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 对象中。您可以通过 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) 接口通过以下方式添加或删除总结缩放部分对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建具有标识背景的新幻灯片和为创建的幻灯片的新部分。
3. 将总结缩放帧添加到第一张幻灯片。
4. 添加新幻灯片和部分到演示文稿。
5. 将创建的部分添加到总结缩放帧。
6. 从总结缩放帧中删除第一部分。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何在总结缩放帧中添加和删除部分：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 2", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 向演示文稿添加新部分
auto section3 = pres->get_Sections()->AddSection(u"部分 3", slide);

// 将部分添加到总结缩放中
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// 从总结缩放中删除部分
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// 保存演示文稿
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **格式化总结缩放部分**

要创建更复杂的总结缩放部分对象，您必须修改简单帧的格式。可以对总结缩放部分对象应用几种格式设置选项。

您可以通过以下方式控制总结缩放部分对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 创建具有标识背景的新幻灯片和为创建的幻灯片的新部分。
3. 将总结缩放帧添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个对象的总结缩放部分对象。
5. 通过将图像添加到与 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象关联的图像集合中，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，该对象将用于填充帧。
6. 为创建的部分缩放帧对象设置自定义图像。
7. 设置“从链接的部分返回到原始幻灯片”的能力。
8. 更改第二个缩放帧对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何更改总结缩放部分对象的格式：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 向演示文稿添加新幻灯片
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 1", slide);

// 向演示文稿添加新幻灯片
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 向演示文稿添加新部分
pres->get_Sections()->AddSection(u"部分 2", slide);

// 添加 SummaryZoomFrame 对象
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 获取第一个 SummaryZoomSection 对象
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// 格式化 SummaryZoomSection 对象
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