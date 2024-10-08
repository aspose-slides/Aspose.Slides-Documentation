---
title: ActiveX
type: docs
weight: 80
url: /zh/cpp/activex/
---


ActiveX 控件用于演示文稿。Aspose.Slides for C++ 允许您管理 ActiveX 控件，但管理它们比正常的演示文稿形状要复杂和不同。从 Aspose.Slides for C++ 18.1 起，该组件支持管理 ActiveX 控件。目前，您可以访问已添加到演示文稿中的 ActiveX 控件，并通过使用其各种属性进行修改或删除。请记住，ActiveX 控件不是形状，并不属于演示文稿的 IShapeCollection，而是单独的 IControlCollection。本文展示了如何使用它们。

## **修改 ActiveX 控件**
要管理一张幻灯片上的简单 ActiveX 控件，如文本框和简单命令按钮：

1. 创建 Presentation 类的实例，并加载包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 IControlCollection 访问幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的不同属性，包括文本、字体、字体高度和框架位置。
1. 访问第二个名为 CommandButton1 的访问控件。
1. 更改按钮标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码片段更新了演示文稿幻灯片上的 ActiveX 控件，如下所示。

``` cpp
// 访问包含 ActiveX 控件的演示文稿
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// 访问演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 更改 TextBox 文本
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"更改的文本";
    control->get_Properties()->idx_set(u"Value", newText);

    // 更改替代图像。Powerpoint 将在 ActiveX 激活期间替换此图像，因此有时可以保持图像不变。
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
    String newCaption = u"消息框";
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

// 保存包含编辑后 ActiveX 控件的演示文稿
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// 现在删除控件
slide->get_Controls()->Clear();

// 保存清除 ActiveX 控件的演示文稿
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **添加媒体播放器 ActiveX 控件**
ActiveX 控件用于演示文稿。Aspose.Slides for C++ 允许您添加和管理 ActiveX 控件，但管理它们比正常的演示文稿形状要复杂和不同。从 Aspose.Slides for C++ 18.1 起，在 Aspose.Slides 中新增了添加媒体播放器 ActiveX 控件的支持。请记住，ActiveX 控件不是形状，并不属于演示文稿的 IShapeCollection，而是单独的 IControlExCollection。本文展示了如何使用它们。要管理媒体播放器 ActiveX 控件，请执行以下步骤：

1. 创建 Presentation 类的实例，并加载包含媒体播放器 ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例，并生成空的演示文稿实例。
1. 将模板演示文稿中包含媒体播放器 ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 访问目标 Presentation 中的克隆幻灯片。
1. 通过访问 IControlCollection 访问幻灯片中的 ActiveX 控件。
1. 访问媒体播放器 ActiveX 控件并通过其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。

``` cpp
// 实例化表示 PPTX 文件的 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 创建空的演示文稿实例
auto newPresentation = System::MakeObject<Presentation>();

// 删除默认幻灯片
newPresentation->get_Slides()->RemoveAt(0);

// 克隆包含媒体播放器 ActiveX 控件的幻灯片
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// 访问媒体播放器 ActiveX 控件并设置视频路径
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// 保存演示文稿
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```