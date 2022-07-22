---
title: ActiveX
type: docs
weight: 80
url: /net/activex/
keywords: "ActiveX, ActiveX controls, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Manage ActiveX controls in PowerPoint presentation in C# or .NET"
---

ActiveX controls are used in presentations. Aspose.Slides for .NET lets you manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for .NET 6.9.0, the component supports managing ActiveX controls. At the moment, you can access already added ActiveX control in your presentation and modify or delete it by using its various properties. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlCollection. This article shows how to work with them.
## **Modify ActiveX Controls**
To manage a simple ActiveX control like a text box and simple command button on a slide:

1. Create an instance of the Presentation class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the TextBox1 ActiveX control using the ControlEx object.
1. Change the different properties of the TextBox1 ActiveX control including text, font, font height and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

The code snippet below updates the ActiveX controls on the presentation slides to the slide as shown below.

```c#
// Accessing the presentation with  ActiveX controls
Presentation presentation = new Presentation("ActiveX.pptm");

// Accessing the first slide in presentation
ISlide slide = presentation.Slides[0];

// changing TextBox text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // changing substitute image. Powerpoint will replace this image during activeX activation, so sometime it's OK to leave image unchanged.

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

    // changing substitute
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


## **Add ActiveX Media Player Control**
To add ActiveX Media Player control, please perform following steps:

1. Create an instance of the Presentation class and load the sample presentation with Media Player ActiveX controls in it.
1. Create an instance of target Presentation class and generate empty presentation instance.
1. Clone the slide with Media Player ActiveX control in template presentation to target Presentation.
1. Access the cloned slide in target Presentation.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

```c#
// Instantiate Presentation class that represents PPTX file
Presentation presentation = new Presentation("template.pptx");

// Create empty presentation instance
Presentation newPresentation = new Presentation();

// Remove default slide
newPresentation.Slides.RemoveAt(0);

// Clone slide with Media Player ActiveX Control
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Access the Media Player ActiveX control and set the video path
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Save the Presentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

