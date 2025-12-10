---
title: 使用 C++ 在演示文稿中管理 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/cpp/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何利用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发者提供对幻灯片的强大控制。"
---

ActiveX 控件在演示文稿中使用。Aspose.Slides for C++ 允许您管理 ActiveX 控件，但管理它们比普通演示文稿形状更为复杂且不同。自 Aspose.Slides for C++ 18.1 起，该组件支持管理 ActiveX 控件。目前，您可以访问演示文稿中已添加的 ActiveX 控件，并通过其各种属性对其进行修改或删除。请记住，ActiveX 控件不是形状，也不属于演示文稿的 IShapeCollection，而是独立的 IControlCollection。本文展示了如何使用它们。

## **修改 ActiveX 控件**
要在幻灯片上管理诸如文本框和简易命令按钮等简单的 ActiveX 控件：

1. 创建 Presentation 类的实例并加载其中包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 IControlCollection 来获取幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的各种属性，包括文本、字体、字体高度和框架位置。
1. 访问名为 CommandButton1 的第二个控件。
1. 更改按钮的标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码片段将演示文稿幻灯片上的 ActiveX 控件更新为如下所示的幻灯片。
``` cpp
// 访问带有  ActiveX 控件的演示文稿
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// 访问演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 更改 TextBox 文本
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // 更改替代图像。PowerPoint 将在 ActiveX 激活期间替换此图像，因此有时可以不更改图像。
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// 更改按钮标题
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // 更改替代
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// 将 ActiveX 框架向下移动 100 点
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// 保存已编辑 ActiveX 控件的演示文稿
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// 现在删除控件
slide->get_Controls()->Clear();

// 保存已清除 ActiveX 控件的演示文稿
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **添加 Media Player ActiveX 控件**
ActiveX 控件在演示文稿中使用。Aspose.Slides for C++ 允许您添加和管理 ActiveX 控件，但管理它们比普通演示文稿形状更为复杂且不同。自 Aspose.Slides for C++ 18.1 起，已在 Aspose.Slides 中加入对添加 Media Player ActiveX 控件的支持。请记住，ActiveX 控件不是形状，也不属于演示文稿的 IShapeCollection，而是独立的 IControlExCollection。本文展示了如何使用它们。要管理 Media Player ActiveX 控件，请执行以下步骤：

1. 创建 Presentation 类的实例并加载其中包含 Media Player ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例并生成空白演示文稿实例。
1. 将模板演示文稿中带有 Media Player ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 在目标 Presentation 中访问克隆的幻灯片。
1. 通过访问 IControlCollection 获取幻灯片中的 ActiveX 控件。
1. 访问 Media Player ActiveX 控件，并使用其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。
``` cpp
// 实例化表示 PPTX 文件的 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 创建空的演示文稿实例
auto newPresentation = System::MakeObject<Presentation>();

// 删除默认幻灯片
newPresentation->get_Slides()->RemoveAt(0);

// 克隆带有 Media Player ActiveX 控件的幻灯片
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// 访问 Media Player ActiveX 控件并设置视频路径
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// 保存演示文稿
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**如果在 C++ 运行时无法执行，Aspose.Slides 在读取和重新保存时是否会保留 ActiveX 控件？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改它们的属性和框架；不需要执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何区别？**

ActiveX 控件是交互式受管控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/cpp/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然有效？**

Aspose.Slides 保留现有的标记和元数据；不过，事件和宏只能在 Windows 上的 PowerPoint 中，在安全设置允许的情况下运行。该库不会执行 VBA。