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
description: "使用 Aspose.Slides for C++ 编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中复用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for C++ 通过[IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) 暴露幻灯片的控件。使用此集合可以编辑控件、在幻灯片上移动或删除它。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，请以读取方式打开并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[类标识](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/)以及[存储属性](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/)中的每个键值对。它读取演示文稿时不会激活控件、触发事件或宏、更改值或保存文件。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

从 `ActiveX.pptm` 选择的输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的属性集合显示为 `[]`。对于使用二进制存储的控件，`get_Properties` 可能返回 `nullptr`，显示为 `Properties unavailable`。如果只需要名称，请在确认集合存在后使用[get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/)。报告列出了演示文稿中可用的属性。控件在运行时可能支持其他属性。

## **修改 ActiveX 控件**

示例要求在第一张幻灯片上有一个名为 `TextBox1` 的文本框和一个名为 `CommandButton1` 的命令按钮的宏启用演示文稿。它使用[控件属性集合](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/)来更改文本框的值和按钮的标题。每个控件还具有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示其更新文本和外观的 PNG。示例通过[IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/)为这些图像赋值。

示例通过更改其[框架](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/)将第一张幻灯片上的每个控件向下移动 100 点。它以 PPTM 格式保存编辑后的演示文稿，然后使用[IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/)保存第二个副本，其中已移除该幻灯片上的所有 ActiveX 控件。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **添加 ActiveX 媒体播放器控件**

要重用已配置的 Windows Media Player 控件，请使用第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板。[ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) 将整张幻灯片复制到新的演示文稿中。示例在其[属性集合](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/)中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持为外部文件，请选择播放器在播放期间能够访问的路径。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **常见问题**

**Aspose.Slides 能在不运行的情况下保留 ActiveX 控件吗？**

可以。Aspose.Slides 可以读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或单击按钮。一个[OLE 对象](/slides/zh/cpp/manage-ole/) 使幻灯片能够包含或链接到由其他应用程序管理的内容，例如 Excel 工作表。

**使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

请将演示文稿保存为如 PPTM 的宏启用格式，以保留其 VBA 项目。当 Windows 版 PowerPoint 的安全设置允许 ActiveX 控件和宏时，它可以运行现有的事件处理程序。