---
title: ActiveX
type: docs
weight: 80
url: /ar/net/activex/
keywords: "ActiveX, عناصر تحكم ActiveX, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إدارة عناصر تحكم ActiveX في عرض PowerPoint باستخدام C# أو .NET"
---

يتم استخدام عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for .NET إدارة عناصر التحكم ActiveX، ولكن إدارتها أمر أكثر تعقيدًا ومختلفًا عن الأشكال العادية في العرض. بدءًا من Aspose.Slides for .NET 6.9.0، يدعم المكوّن إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX الذي تم إضافته مسبقًا في العرض وتعديله أو حذفه باستخدام خصائصه المتنوعة. تذكّر أن عناصر التحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض بل هي جزء من IControlCollection المنفصل. تُظهر هذه المقالة كيفية العمل معها.

## **تعديل عناصر تحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثيل من فئة Presentation وتحميل العرض الذي يحتوي على عناصر تحكم ActiveX.
1. الحصول على مرجع الشريحة عبر فهرستها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عن طريق الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تعديل تسمية الزر، الخط والموقع.
1. تحريك موقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض المعدل إلى ملف PPTX.

المقتطف البرمجي أدناه يحدّث عناصر التحكم ActiveX على شرائح العرض كما هو موضح أدناه.
```c#
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// الوصول إلى الشريحة الأولى في العرض التقديمي
ISlide slide = presentation.Slides[0];

// تغيير نص مربع النص
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // تغيير الصورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تفعيل ActiveX، لذا في بعض الأحيان يمكن ترك الصورة دون تغيير.

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

// تحريك إطارات ActiveX للأسفل بمقدار 100 نقطة
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المعدلة
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// الآن إزالة العناصر التحكم
slide.Controls.Clear();

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المُزالة
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **إضافة عنصر تحكم ActiveX Media Player**
لإضافة عنصر تحكم ActiveX Media Player، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثيل من فئة Presentation وتحميل العرض التجريبي الذي يحتوي على عناصر تحكم Media Player ActiveX.
1. إنشاء مثيل من فئة Presentation الهدف وتوليد مثيل عرض فارغ.
1. استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX في عرض القالب إلى عرض الهدف.
1. الوصول إلى الشريحة المستنسخة في عرض الهدف.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عن طريق الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض إلى ملف PPTX.
```c#
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// إنشاء مثال عرض تقديمي فارغ
Presentation newPresentation = new Presentation();

// إزالة الشريحة الافتراضية
newPresentation.Slides.RemoveAt(0);

// استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// حفظ العرض التقديمي
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة Python؟**

نعم. يتعامل Aspose.Slides معها كجزء من العرض ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض؟**

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، في حين أن [OLE](/slides/ar/net/manage-ole/) تشير إلى كائنات التطبيقات المضمنة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خاصية متميزة.

**هل تعمل أحداث ActiveX والماكروات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات التعريفية والبيانات الوصفية الحالية؛ ومع ذلك، تعمل الأحداث والماكروات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تنفّذ VBA.