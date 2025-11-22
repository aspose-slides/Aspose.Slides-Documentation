---
title: ActiveX
type: docs
weight: 80
url: /zh/net/activex/
keywords: "ActiveX, ActiveX 控件, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的 ActiveX 控件"
---

ActiveX 控件在演示文稿中使用。Aspose.Slides for .NET 允许您管理 ActiveX 控件，但管理它们比普通演示文稿形状稍微复杂且不同。自 Aspose.Slides for .NET 6.9.0 起，组件支持管理 ActiveX 控件。目前，您可以访问演示文稿中已添加的 ActiveX 控件，并通过其各种属性对其进行修改或删除。请记住，ActiveX 控件不是形状，也不属于演示文稿的 IShapeCollection，而是单独的 IControlCollection。本文展示了如何使用它们。

## **修改 ActiveX 控件**

要在幻灯片上管理诸如文本框和简单命令按钮等简单的 ActiveX 控件，请执行以下操作：

1. 创建 Presentation 类的实例并加载其中包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 IControlCollection 获取幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的各种属性，包括文本、字体、字体大小和框架位置。
1. 访问第二个名为 CommandButton1 的访问控件。
1. 更改按钮的标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码片段将演示文稿幻灯片上的 ActiveX 控件更新为如下所示的幻灯片。
```c#
// Accessing the presentation with ActiveX controls
Presentation presentation = new Presentation("ActiveX.pptm");

// Accessing the first slide in presentation
ISlide slide = presentation.Slides[0];

// changing TextBox text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 更改替代图像。PowerPoint 会在 ActiveX 激活期间替换此图像，因此有时可以保持图像不变。

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// changing Button caption
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // 更改替代图像
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Moving ActiveX frames 100 points down
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Save the presentation with Edited ActiveX Controls
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Now removing controls
slide.Controls.Clear();

// Saving the presentation with cleared ActiveX controls
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **添加 ActiveX Media Player 控件**

要添加 ActiveX Media Player 控件，请执行以下步骤：

1. 创建 Presentation 类的实例并加载其中包含 Media Player ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例并生成空白演示文稿实例。
1. 将模板演示文稿中包含 Media Player ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 在目标 Presentation 中访问克隆的幻灯片。
1. 通过访问 IControlCollection 获取幻灯片中的 ActiveX 控件。
1. 访问 Media Player ActiveX 控件并使用其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。
```c#
// 实例化表示 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation("template.pptx");

// 创建空的演示文稿实例
Presentation newPresentation = new Presentation();

// 删除默认幻灯片
newPresentation.Slides.RemoveAt(0);

// 克隆带有媒体播放器 ActiveX 控件的幻灯片
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// 访问媒体播放器 ActiveX 控件并设置视频路径
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// 保存演示文稿
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **常见问题**

**Aspose.Slides 在读取并重新保存时是否会保留无法在 Python 运行时执行的 ActiveX 控件？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改其属性和框架；不需要执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何区别？**

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/net/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，并具有不同的属性模型。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然有效？**

Aspose.Slides 保留现有的标记和元数据；然而，事件和宏只能在 Windows 上的 PowerPoint 中在安全设置允许时运行。该库不会执行 VBA。