---
title: "إدارة عناصر تحكم ActiveX في العروض التقديمية باستخدام .NET"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/net/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية استفادة Aspose.Slides for .NET من ActiveX لأتمتة وتعزيز عروض PowerPoint، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

تُستخدم عناصر تحكم ActiveX في العروض التقديمية. تتيح لك Aspose.Slides for .NET إدارة عناصر تحكم ActiveX، لكن إدارتها أكثر تعقيدًا ومختلفة عن الأشكال العادية في العرض. بدءًا من Aspose.Slides for .NET 6.9.0، يدعم المكوّن إدارة عناصر تحكم ActiveX. حاليًا، يمكنك الوصول إلى عنصر تحكم ActiveX المُضاف مسبقًا في عرضك وتعديله أو حذفه باستخدام خصائصه المتنوعة. تذكّر أن عناصر تحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض، بل هي جزء من IControlCollection المستقلة. توضح هذه المقالة كيفية العمل معها.

## **تعديل عناصر تحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثيل من فئة Presentation وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
1. الحصول على مرجع الشريحة حسب الفهرس الخاص بها.
1. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر تحكم ActiveX TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر تحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير عنوان الزر، الخط، والموقع.
1. تحريك موضع إطارات عناصر تحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

مقطع الشفرة أدناه يحدّث عناصر تحكم ActiveX على شرائح العرض التقديمي كما هو موضح أدناه.
```c#
// الوصول إلى العرض التقديمي مع  عناصر تحكم ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// الوصول إلى الشريحة الأولى في العرض التقديمي
ISlide slide = presentation.Slides[0];

// تغيير نص TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // تغيير صورة البديل. سيقوم PowerPoint باستبدال هذه الصورة أثناء تنشيط activeX، لذلك في بعض الأحيان من المقبول ترك الصورة دون تغيير.

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

// تحريك إطارات ActiveX 100 نقطة إلى الأسفل
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// حفظ العرض التقديمي مع عناصر تحكم ActiveX المعدلة
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// الآن يتم إزالة عناصر التحكم
slide.Controls.Clear();

// حفظ العرض التقديمي مع عناصر تحكم ActiveX التي تم مسحها
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **إضافة عنصر تحكم Media Player ActiveX**
لإضافة عنصر تحكم Media Player ActiveX، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثيل من فئة Presentation وتحميل نموذج العرض التقديمي الذي يحتوي على عناصر تحكم Media Player ActiveX.
1. إنشاء مثيل من فئة Presentation المستهدفة وتوليد عرض تقديمي فارغ.
1. استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX من العرض القالب إلى العرض المستهدف.
1. الوصول إلى الشريحة المستنسخة في العرض المستهدف.
1. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي إلى ملف PPTX.
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// إنشاء نسخة فارغة من العرض التقديمي
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


## **FAQ**

**هل يحافظ Aspose.Slides على عناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يكن بالإمكان تنفيذها في بيئة تشغيل .NET؟**

نعم. يعتبر Aspose.Slides هذه العناصر جزءًا من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يتطلب الحفاظ عليها تنفيذ عناصر التحكم نفسها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر تحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (الأزرار، مربعات النص، مشغل الوسائط)، بينما تشير [OLE](/slides/ar/net/manage-ole/) إلى كائنات تطبيق مضمنة (على سبيل المثال، ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات والبيانات الوصفية الموجودة؛ ومع ذلك، يتم تشغيل الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. لا تقوم المكتبة بتنفيذ VBA.