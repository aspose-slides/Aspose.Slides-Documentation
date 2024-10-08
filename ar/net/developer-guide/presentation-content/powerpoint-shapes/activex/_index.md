---
title: ActiveX
type: docs
weight: 80
url: /ar/net/activex/
keywords: "ActiveX, عناصر التحكم ActiveX, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إدارة عناصر التحكم ActiveX في عرض PowerPoint باستخدام C# أو .NET"
---

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. تتيح لك Aspose.Slides for .NET إدارة عناصر التحكم ActiveX، ولكن إدارتها تتطلب بعض التعقيد وتختلف عن الأشكال العادية في العرض التقديمي. بدءًا من Aspose.Slides for .NET 6.9.0، يدعم المكون إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك التقديمي وتعديله أو حذفه باستخدام خصائصه المختلفة. تذكر، أن عناصر التحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection الخاصة بالعرض التقديمي ولكنها جزء من IControlCollection المنفصلة. تُظهر هذه المقالة كيفية العمل معهم.
## **تعديل عناصر التحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط في شريحة:

1. قم بإنشاء مثيل من فئة العرض التقديمي وقم بتحميل العرض التقديمي مع عناصر التحكم ActiveX فيه.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. قم بالوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى IControlCollection.
1. قم بالوصول إلى عنصر التحكم ActiveX المسمى TextBox1 باستخدام كائن ControlEx.
1. قم بتغيير خصائص مختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. قم بتغيير تسمية الزر، الخط والموقع.
1. نقل موضع إطارات عناصر التحكم ActiveX.
1. اكتب العرض التقديمي المعدل إلى ملف PPTX.

يتحدث مقتطف الكود أدناه عن تحديث عناصر التحكم ActiveX على الشرائح كما هو موضح أدناه.

```c#
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// الوصول إلى الشريحة الأولى في العرض التقديمي
ISlide slide = presentation.Slides[0];

// تغيير نص TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "تم تغيير النص";
    control.Properties["Value"] = newText;

    // تغيير الصورة البديلة. ستقوم Powerpoint باستبدال هذه الصورة أثناء تفعيل ActiveX، لذا قد يكون من المقبول أحيانًا ترك الصورة دون تغيير.

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

// تغيير تسمية الزر
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // تغيير البديل
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

// نقل إطارات ActiveX 100 نقطة للأسفل
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المعدلة
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// الآن إزالة العناصر
slide.Controls.Clear();

// حفظ العرض التقديمي مع عناصر التحكم ActiveX التي تم مسحها
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **إضافة عنصر تحكم مشغل الوسائط ActiveX**
لإضافة عنصر تحكم مشغل الوسائط ActiveX، يرجى اتباع الخطوات التالية:

1. قم بإنشاء مثيل من فئة العرض التقديمي وقم بتحميل العرض التقديمي عينة مع عناصر التحكم Media Player ActiveX فيه.
1. قم بإنشاء مثيل فئة العرض التقديمي المستهدفة واجعل مثيل العرض فارغًا.
1. استنساخ الشريحة مع عنصر التحكم Media Player ActiveX في العرض المقدم كقالب إلى العرض المستهدف.
1. الوصول إلى الشريحة المستنسخة في العرض المستهدف.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي إلى ملف PPTX.

```c#
// إنشاء فئة العرض التقديمي التي تمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// إنشاء مثيل عرض تقديمي فارغ
Presentation newPresentation = new Presentation();

// إزالة الشريحة الافتراضية
newPresentation.Slides.RemoveAt(0);

// استنساخ الشريحة مع عنصر التحكم Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// حفظ العرض التقديمي
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```