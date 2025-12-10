---
title: 在 C++ 中管理演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/cpp/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图像占位符
- 图表占位符
- 提示文本
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "轻松管理 Aspose.Slides for C++ 中的占位符：替换文本、定制提示并在 PowerPoint 与 OpenDocument 中设置图像透明度。"
---

## **在占位符中更改文本**
使用 [Aspose.Slides for C++](/slides/zh/cpp/)，您可以在演示文稿的幻灯片中查找和修改占位符。Aspose.Slides 允许您更改占位符中的文本。

**先决条件**：您需要一个包含占位符的演示文稿。您可以在标准的 Microsoft PowerPoint 应用程序中创建此类演示文稿。

以下是使用 Aspose.Slides 在该演示文稿中替换占位符文本的方法：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类，并将演示文稿作为参数传入。
2. 通过索引获取幻灯片引用。
3. 遍历形状以查找占位符。
4. 将占位符形状强制转换为 [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) 并使用与该 [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) 关联的 [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) 更改文本。
5. 保存修改后的演示文稿。

下面的 C++ 代码展示了如何更改占位符中的文本：
```c++
// 文档目录的路径。
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// 将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **在占位符中设置提示文本**
标准和预构建的布局包含占位符提示文本，例如 ***单击以添加标题*** 或 ***单击以添加副标题***。使用 Aspose.Slides，您可以将首选的提示文本插入占位符布局中。

下面的 C++ 代码展示了如何在占位符中设置提示文本：
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // 当其中没有文本时，PowerPoint 显示 "Click to add title".
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // 对副标题执行相同的操作。
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", AspNet::Slides::Export::SaveFormat::Pptx);
```


## **设置占位符图像透明度**
Aspose.Slides 允许您设置文本占位符中背景图像的透明度。通过调整该框架中图片的透明度，您可以让文本或图像突显出来（取决于文本和图片的颜色）。

下面的 C++ 代码展示了如何为图片背景（位于形状内部）设置透明度：
```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```


## **常见问题**

**什么是基础占位符，它与幻灯片上的本地图形有什么区别？**

基础占位符是布局或母版上原始的形状，幻灯片的形状从其继承——类型、位置以及部分格式来自该占位符。本地图形是独立的；如果没有基础占位符，则不适用继承。

**如何在不遍历每张幻灯片的情况下更新整个演示文稿中的所有标题或说明文字？**

在布局或母版上编辑相应的占位符。基于这些布局/母版的幻灯片会自动继承此更改。

**如何控制标准的页眉/页脚占位符——日期时间、幻灯片编号和页脚文本？**

在相应的范围（普通幻灯片、布局、母版、备注/讲义）使用 HeaderFooter 管理器，开启或关闭这些占位符并设置其内容。