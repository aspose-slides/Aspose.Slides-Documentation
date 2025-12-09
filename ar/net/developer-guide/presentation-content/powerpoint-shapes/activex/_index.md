---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية في .NET
linktitle: ActiveX
type: docs
weight: 80
url: /ar/net/activex/
keywords:
- ActiveX
- تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيف تستخدم Aspose.Slides for .NET تحكم ActiveX لأتمتة وتعزيز عروض PowerPoint، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يسمح لك Aspose.Slides for .NET بإدارة عناصر التحكم ActiveX، لكن إدارتها أصعب قليلاً ومختلفة عن الأشكال العادية في العرض. بدءًا من Aspose.Slides for .NET 6.9.0، يدعم المكوّن إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX المضاف مسبقًا في عرضك التقديمي وتعديله أو حذفه باستخدام خصائصه المختلفة. تذكر أن عناصر التحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض ولكنها في IControlCollection منفصلة. تُظهر هذه المقالة كيفية التعامل معها.
## **تعديل عناصر التحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع النص وزر الأمر البسيط على شريحة:

1. إنشاء كائن من فئة Presentation وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX فيه.
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
4. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن ControlEx.
5. تعديل الخصائص المختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
7. تعديل تسمية الزر، الخط والموقع.
8. إزاحة موقع إطارات عناصر التحكم ActiveX.
9. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```c#
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// الوصول إلى الشريحة الأولى في العرض التقديمي
ISlide slide = presentation.Slides[0];

// changing TextBox text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // تغيير صورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX، لذا في بعض الأحيان يمكن ترك الصورة دون تغيير.

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

    // تغيير البديلة
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

// نقل إطارات ActiveX للأسفل 100 نقطة
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// حفظ العرض التقديمي مع عناصر التحكم ActiveX المعدلة
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// الآن يتم إزالة عناصر التحكم
slide.Controls.Clear();

// حفظ العرض التقديمي مع عناصر التحكم ActiveX التي تم مسحها
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **إضافة عنصر تحكم ActiveX Media Player**
لإضافة عنصر التحكم ActiveX Media Player، يرجى تنفيذ الخطوات التالية:

1. إنشاء كائن من فئة Presentation وتحميل عرض تقديمي نمطي يحتوي على عناصر تحكم Media Player ActiveX فيه.
2. إنشاء كائن من فئة Presentation الهدف وإنشاء عرض تقديمي فارغ.
3. استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX من عرض تقديمي القالب إلى العرض الهدف.
4. الوصول إلى الشريحة المستنسخة في العرض الهدف.
5. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
6. الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
7. حفظ العرض التقديمي إلى ملف PPTX.

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// إنشاء عرض تقديمي فارغ
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


## **الأسئلة الشائعة**

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة .NET Runtime؟**

نعم. يعتبر Aspose.Slides هذه العناصر جزءًا من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما يُشير [OLE](/slides/ar/net/manage-ole/) إلى كائنات تطبيق مضمّنة (مثل ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX والماكروهات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات الوصفية والبيانات الوصفية الحالية؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تنفّذ VBA.