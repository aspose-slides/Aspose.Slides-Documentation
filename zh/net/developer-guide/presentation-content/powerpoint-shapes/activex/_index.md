---
title: 管理 .NET 演示文稿中的 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/net/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中复用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，如文本框、命令按钮和媒体播放器。Aspose.Slides for .NET 通过 [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) 将幻灯片的控件公开。使用此集合可编辑控件、在幻灯片上移动它，或将其删除。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，打开它进行读取并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) 和 [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) 中的每个键值对。它读取演示文稿时不会激活控件、触发事件或宏、更改值或保存文件。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

从 `ActiveX.pptm` 选取的输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的属性集合显示为 `[]`。对于使用二进制存储的控件，`Properties` 可能返回 `null`，显示为 `Properties unavailable`。如果只需要名称，可在空检查后使用 [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/)。报告列出演示文稿中可用的属性。控件在运行时可能支持额外的属性。

## **修改 ActiveX 控件**

示例要求在第一张幻灯片上有一个名为 `TextBox1` 的文本框和一个名为 `CommandButton1` 的命令按钮的宏启用演示文稿。它使用 [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) 来更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示更新文本和外观的 PNG。示例通过 [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) 为这些图像赋值。

示例通过修改其 [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) 将第一张幻灯片上的所有控件向下移动 100 点。它将编辑后的演示文稿保存为 PPTM 格式，然后使用 [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) 保存第二份副本，其中该幻灯片上的所有 ActiveX 控件均已移除。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **添加 ActiveX 媒体播放器控件**

要复用已配置的 Windows Media Player 控件，请使用第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板。[ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) 将整张幻灯片复制到新演示文稿中。示例在其 [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持为外部文件，请选择播放器在播放期间能够访问的路径。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **常见问题**

**Aspose.Slides 能在不运行它们的情况下保留 ActiveX 控件吗？**

是的。Aspose.Slides 可以读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或点击按钮。一个 [OLE 对象](/slides/zh/net/manage-ole/) 使幻灯片能够包含或链接到由其他应用程序管理的内容，如 Excel 工作表。

**使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

请将演示文稿保存为 PPTM 等宏启用格式，以保留其 VBA 项目。当 Windows 版 PowerPoint 的安全设置同时允许 ActiveX 控件和宏时，PowerPoint 可以运行现有的事件处理程序。