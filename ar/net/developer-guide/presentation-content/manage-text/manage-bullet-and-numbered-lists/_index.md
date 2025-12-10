---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية في .NET
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/net/manage-bullet-and-numbered-lists
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
- نقطة رمزية
- نقطة صورة
- نقطة مخصصة
- قائمة متعددة المستويات
- إنشاء نقطة
- إضافة نقطة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في Word وبرامج تحرير النص الأخرى. **Aspose.Slides for .NET** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية. 

## **لماذا نستخدم القوائم النقطية؟**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تخدم قائمة النقاط هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه قراءك أو مشاهديك إلى المعلومات المهمة
- تمكن قراءك أو مشاهديك من مسح النقاط الرئيسية بسهولة
- تنقل وتوصّل التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

القوائم المرقمة تساعد أيضًا في تنظيم وعرض المعلومات. من الناحية المثالية، يجب عليك استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (مثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يحتاج العنصر إلى الإشارة إليه (مثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثال من فئة Presentation. 
2. أداء عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء نقاط**

لإنشاء قائمة نقطية، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الوصول إلى الشريحة (التي تريد إضافة قائمة نقطية إليها) في مجموعة الشرائح عبر كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) .
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame]().
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) .
8. تعيين نوع النقطة إلى Symbol ثم تعيين حرف النقطة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة لتحديد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقطة.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) .
14. إضافة الفقرة الثانية وتكرار الخطوات من 7 إلى 12.
15. حفظ العرض التقديمي.

هذا المثال البرمجي بلغة C#—تنفيذ للخطوات أعلاه—يعرض لك كيفية إنشاء قائمة نقطية في شريحة:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إنشاء نقاط صورة**

يتيح لك Aspose.Slides for .NET تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت تريد إضافة اهتمام بصري إلى قائمة أو جذب المزيد من الانتباه إلى عناصر القائمة، يمكنك استخدام صورتك الخاصة كنقطة. 

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل هذه الصور بشكل أفضل كرُموز نقطية مخصصة. 

في جميع الأحوال، سيتم تقليل حجم الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة صورة، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) .
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) .
7. تحميل صورة من القرص وإضافتها إلى [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) ثم استخدام مثال [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) الذي تم إرجاعه من طريقة [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) .
8. تعيين نوع النقطة إلى Picture ثم تعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة لتحديد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) .
14. إضافة الفقرة الثانية وتكرار الخطوات من 7 إلى 13.
15. حفظ العرض التقديمي.

يظهر لك هذا الكود بلغة C# كيفية إنشاء نقطة صورة في شريحة:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة — قوائم إضافية تحت القائمة النقطية الرئيسية — اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) .
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) .
11. حفظ العرض التقديمي.

هذا الكود، وهو تنفيذ للخطوات أعلاه، يوضح لك كيفية إنشاء قائمة نقطية متعددة المستويات بلغة C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إنشاء أرقام**

يظهر لك هذا الكود بلغة C# كيفية إنشاء قائمة مرقمة في شريحة:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى تنسيقات أخرى مثل PDF أو الصور؟**

نعم، يحافظ Aspose.Slides بالكامل على تنسيق وهيكل القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى تنسيقات مثل PDF، الصور، وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**

نعم، يتيح لك Aspose.Slides استيراد وتعديل القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بعدة لغات؟**

نعم، يدعم Aspose.Slides بالكامل العروض التقديمية المتعددة اللغات، مما يتيح لك إنشاء قوائم نقطية ومرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.