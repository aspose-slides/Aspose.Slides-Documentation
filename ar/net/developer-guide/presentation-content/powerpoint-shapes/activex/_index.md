---
title: إدارة عناصر تحكم ActiveX في العروض التقديمية باستخدام .NET
linktitle: ActiveX
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
description: "تعلم كيف يستخدم Aspose.Slides for .NET تقنية ActiveX لأتمتة وتحسين عروض PowerPoint، مما يمنح المطورين سيطرة قوية على الشرائح."
---

تُستخدم عناصر تحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for .NET إدارة عناصر تحكم ActiveX، لكن إدارتها أصعب قليلاً ومختلفة عن الأشكال العادية في العرض التقديمي. بدءًا من Aspose.Slides for .NET 6.9.0، يدعم المكوّن إدارة عناصر تحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر تحكم ActiveX الذي تم إضافته مسبقًا في العرض التقديمي وتعديله أو حذفه باستخدام خصائصه المتنوعة. تذكر أن عناصر تحكم ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض التقديمي بل هي جزء منفصل من IControlCollection. توضح هذه المقالة كيفية العمل معها.
## **تعديل عناصر تحكم ActiveX**
1. إنشاء مثيل لفئة Presentation وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.  
1. الحصول على مرجع الشريحة باستخدام فهرسها.  
1. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر IControlCollection.  
1. الوصول إلى عنصر تحكم ActiveX TextBox1 باستخدام كائن ControlEx.  
1. تغيير الخصائص المختلفة لعنصر تحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.  
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.  
1. تغيير تسمية الزر، الخط والموقع.  
1. تعديل موقع إطارات عناصر تحكم ActiveX.  
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.  

تقوم الشيفرة أدناه بتحديث عناصر تحكم ActiveX في شرائح العرض التقديمي إلى الشكل الموضح أدناه.
```c#
 // الوصول إلى العرض التقديمي مع عناصر تحكم ActiveX
 Presentation presentation = new Presentation("ActiveX.pptm");

 // الوصول إلى الشريحة الأولى في العرض التقديمي
 ISlide slide = presentation.Slides[0];

 // تغيير نص TextBox
 IControl control = slide.Controls[0];

 if (control.Name == "TextBox1" && control.Properties != null)
 {
     string newText = "Changed text";
     control.Properties["Value"] = newText;

     // تغيير صورة الاستبدال. سيقوم PowerPoint باستبدال هذه الصورة أثناء تنشيط ActiveX، لذلك في بعض الأحيان من المقبول ترك الصورة دون تغيير.

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

     // تغيير الاستبدال
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

 // نقل إطارات ActiveX 100 نقطة إلى الأسفل
 foreach (Control ctl in slide.Controls)
 {
     IShapeFrame frame = control.Frame;
     control.Frame = new ShapeFrame(
         frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
 }

 // حفظ العرض التقديمي مع عناصر تحكم ActiveX المعدلة
 presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


 // الآن يتم إزالة العناصر
 slide.Controls.Clear();

 // حفظ العرض التقديمي مع عناصر تحكم ActiveX التي تم مسحها
 presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **إضافة عنصر تحكم ActiveX Media Player**
1. إنشاء مثيل لفئة Presentation وتحميل عينة العرض التقديمي التي تحتوي على عناصر تحكم Media Player ActiveX.  
1. إنشاء مثيل لفئة Presentation الهدف وإنشاء مثال فارغ للعرض التقديمي.  
1. استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX من العرض التقديمي النموذجي إلى العرض التقديمي الهدف.  
1. الوصول إلى الشريحة المستنسخة في العرض التقديمي الهدف.  
1. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر IControlCollection.  
1. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.  
1. حفظ العرض التقديمي إلى ملف PPTX.  
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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

**هل يحتفظ Aspose.Slides بعناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يكن بإمكانها التنفيذ في بيئة تشغيل Python؟**  
نعم. يتعامل Aspose.Slides مع تلك العناصر كجزء من العرض التقديمي ويمكنه قراءة خصائصها وتعديلها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**  
عناصر تحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما يُشير [OLE](/slides/ar/net/manage-ole/) إلى كائنات تطبيق مضمَّنة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بشكل مختلف وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX والماكروهات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**  
يحافظ Aspose.Slides على العلامات والبيانات الوصفية الحالية؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.