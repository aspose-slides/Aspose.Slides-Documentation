---
title: ActiveX
type: docs
weight: 80
url: /zh/net/activex/
keywords: "ActiveX, ActiveX 控件, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的 ActiveX 控件"
---

ActiveX 控件用于演示文稿中。Aspose.Slides for .NET 允许您管理 ActiveX 控件，但管理它们比普通演示文稿形状要复杂一些。从 Aspose.Slides for .NET 6.9.0 开始，该组件支持管理 ActiveX 控件。此时，您可以访问演示文稿中已添加的 ActiveX 控件，并使用其各种属性进行修改或删除。请记住，ActiveX 控件不是形状，并且不属于演示文稿的 IShapeCollection，而是属于单独的 IControlCollection。本文展示了如何与它们进行交互。
## **修改 ActiveX 控件**
要管理幻灯片上的简单 ActiveX 控件，例如文本框和简单命令按钮：

1. 创建 Presentation 类的实例并加载包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 IControlCollection 获取幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的不同属性，包括文本、字体、字体高度和框架位置。
1. 访问第二个控件，名为 CommandButton1。
1. 更改按钮标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码片段更新了演示文稿幻灯片上的 ActiveX 控件，如下所示。

```c#
// 访问包含 ActiveX 控件的演示文稿
Presentation presentation = new Presentation("ActiveX.pptm");

// 访问演示文稿中的第一张幻灯片
ISlide slide = presentation.Slides[0];

// 更改 TextBox 文本
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "更改的文本";
    control.Properties["Value"] = newText;

    // 更改替代图像。Powerpoint将在 ActiveX 激活期间替换此图像，因此有时保持图像不变是可以的。

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

// 更改按钮标题
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "消息框";
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

// 将 ActiveX 框架向下移动 100 个点
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// 以编辑后的 ActiveX 控件保存演示文稿
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// 现在移除控件
slide.Controls.Clear();

// 保存带有清除 ActiveX 控件的演示文稿
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **添加 ActiveX 媒体播放器控件**
要添加 ActiveX 媒体播放器控件，请执行以下步骤：

1. 创建 Presentation 类的实例，并加载包含媒体播放器 ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例，并生成空演示文稿实例。
1. 将模板演示文稿中包含媒体播放器 ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 访问目标 Presentation 中的克隆幻灯片。
1. 通过访问 IControlCollection 访问幻灯片中的 ActiveX 控件。
1. 访问媒体播放器 ActiveX 控件，并使用其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。

```c#
// 实例化表示 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation("template.pptx");

// 创建空演示文稿实例
Presentation newPresentation = new Presentation();

// 移除默认幻灯片
newPresentation.Slides.RemoveAt(0);

// 克隆带有媒体播放器 ActiveX 控件的幻灯片
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// 访问媒体播放器 ActiveX 控件并设置视频路径
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// 保存演示文稿
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```