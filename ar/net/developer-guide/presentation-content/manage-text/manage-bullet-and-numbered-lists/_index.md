---
title: إدارة القوائم النقطية والرقمية
type: docs
weight: 70
url: /ar/net/manage-bullet-and-numbered-lists
keywords: "النقاط, قوائم نقطية, الأرقام, قوائم رقمية, نقاط بصورة, نقاط متعددة المستويات, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إنشاء قوائم نقطية ورقمية في عرض PowerPoint باستخدام C# أو .NET"
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في Word وغيرها من محررات النص. **Aspose.Slides for .NET** يسمح لك أيضًا باستخدام النقاط والأرقام في الشرائح في عروضك التقديمية. 

## **لماذا تستخدم القوائم النقطية؟**

القوائم النقطية تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القراء أو المشاهدين إلى المعلومات الهامة
- تتيح للقراء أو المشاهدين مسح النقاط الرئيسية بسهولة
- تنقل وتوصل التفاصيل المهمة بكفاءة.

## **لماذا تستخدم القوائم المرقمة؟**

القوائم المرقمة تساعد أيضًا في تنظيم وعرض المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يجب الإشارة إلى إدخال (على سبيل المثال، *انظر الخطوة 3*). 

**مثال على قائمة مرقمة**

هذه ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء كائن من الفئة Presentation. 
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**

لإنشاء قائمة نقطية، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة (التي تريد إضافة قائمة نقطية فيها) في مجموعة الشرائح عبر كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame]().
6. إنشاء أول كائن فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. ضبط نوع النقطة إلى Symbol ثم تحديد حرف النقطة.
9. ضبط نص الفقرة.
10. ضبط مسافة إزاحة الفقرة لتحديد النقطة.
11. ضبط لون النقطة.
12. ضبط ارتفاع النقطة.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. إضافة الفقرة الثانية وتكرار الخطوات من 7 إلى 12.
15. حفظ العرض التقديمي.

يعرض هذا المثال البرمجي بلغة C#—تنفيذ للخطوات أعلاه—كيفية إنشاء قائمة نقطية في شريحة:
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


## **إنشاء نقاط بصورة**

يتيح لك Aspose.Slides for .NET تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا أردت إضافة عنصر بصري جذاب إلى القائمة أو جذب انتباه أكبر إلى العناصر في القائمة، يمكنك استخدام صورتك الخاصة كنقطة. 

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. هذه الصور تعمل بشكل أفضل كرموز نقطية مخصصة. 

في أي حال، الصورة التي تختارها سيُقلّص حجمها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء أول كائن فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. تحميل الصورة من القرص وإضافتها إلى [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) ثم استخدام كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) الذي تم إرجاعه من طريقة [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. ضبط نوع النقطة إلى Picture ثم تعيين الصورة.
9. ضبط نص الفقرة.
10. ضبط مسافة إزاحة الفقرة لتحديد النقطة.
11. ضبط لون النقطة.
12. ضبط ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. إضافة الفقرة الثانية وتكرار الخطوات من 7 إلى 13.
15. حفظ العرض التقديمي.

يعرض هذا الكود بلغة C# كيفية إنشاء نقطة بصورة في شريحة:
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

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء أول كائن فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) وتعيين العمق إلى 0.
7. إنشاء الفقرة الثانية باستخدام الفئة Paragraph وتعيين العمق إلى 1.
8. إنشاء الفقرة الثالثة باستخدام الفئة Paragraph وتعيين العمق إلى 2.
9. إنشاء الفقرة الرابعة باستخدام الفئة Paragraph وتعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. حفظ العرض التقديمي.

يعرض هذا الكود، الذي هو تنفيذ للخطوات أعلاه، كيفية إنشاء قائمة نقطية متعددة المستويات بلغة C#:
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


## **إنشاء أعداد**

يعرض هذا الكود بلغة C# كيفية إنشاء قائمة مرقمة في شريحة:
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


## **الأسئلة المتكررة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى تنسيقات أخرى مثل PDF أو الصور؟**

نعم، يحافظ Aspose.Slides بالكامل على تنسيق وهيكل القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى تنسيقات مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل يمكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**

نعم، يتيح لك Aspose.Slides استيراد وتحرير القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بعدة لغات؟**

نعم، يدعم Aspose.Slides بالكامل العروض التقديمية متعددة اللغات، مما يتيح لك إنشاء القوائم النقطية والمرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.