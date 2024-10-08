---
title: 管理占位符
type: docs
weight: 10
url: /zh/cpp/manage-placeholder/
keywords: "占位符, 占位符文本, 提示文本, PowerPoint演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在C++中更改PowerPoint演示文稿中的占位符文本和提示文本"
---

## **更改占位符中的文本**
使用 [Aspose.Slides for C++](/slides/zh/cpp/)，您可以查找并修改演示文稿幻灯片上的占位符。Aspose.Slides允许您更改占位符中的文本。

**前提条件**：您需要一个包含占位符的演示文稿。您可以在标准的Microsoft PowerPoint应用程序中创建这样的演示文稿。

以下是您如何使用Aspose.Slides在该演示文稿中替换占位符中的文本：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类并将演示文稿作为参数传递。
2. 通过索引获取幻灯片引用。
3. 遍历形状以查找占位符。
4. 将占位符形状强制转换为 [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) 并使用与 [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) 相关联的 [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) 更改文本。
5. 保存修改后的演示文稿。

以下C++代码演示如何更改占位符中的文本：

```c++
// 文档目录的路径。
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 访问幻灯片中的第一个和第二个占位符，并强制转换为AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// 将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **设置占位符中的提示文本**
标准和预构建布局包含占位符提示文本，例如 ***点击添加标题*** 或 ***点击添加副标题***。使用Aspose.Slides，您可以将首选提示文本插入到占位符布局中。

以下C++代码演示如何在占位符中设置提示文本：

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // 当里面没有文本时，PowerPoint会显示“点击添加标题”。
        {
            text = u"点击添加标题";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // 对副标题做同样的处理。
        {
            text = u"点击添加副标题";
        }
        System::Console::WriteLine(u"占位符 : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **设置占位符图像透明度**

Aspose.Slides允许您设置文本占位符中背景图像的透明度。通过调整此类框架中图像的透明度，您可以使文本或图像突出（具体取决于文本和图像的颜色）。

以下C++代码演示如何为图片背景（位于形状内部）设置透明度：

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