---
title: إدارة القوائم النقطية والقوائم المرقمة
type: docs
weight: 70
url: /ar/net/manage-bullet-and-numbered-lists
keywords: "النقاط، قوائم نقطية، أرقام، قوائم مرقمة، نقاط مصورة، نقاط متعددة المستويات، عرض PowerPoint، C#، Csharp، Aspose.Slides ل .NET"
description: "إنشاء قوائم نقطية ومرقمة في عرض PowerPoint بلغة C# أو .NET"
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في Word وغيرها من محررات النصوص. **Aspose.Slides ل .NET** يسمح لك أيضاً باستخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

### لماذا استخدام القوائم النقطية؟

تساعد القوائم النقطية على تنظيم وتقديم المعلومات بسرعة وفعالية.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه قرائك أو مشاهديك إلى المعلومات المهمة
- تتيح لقرائك أو مشاهديك مسح النقاط الأساسية بسهولة
- تنقل وتقدم تفاصيل مهمة بكفاءة.

### لماذا استخدام القوائم المرقمة؟

تساعد القوائم المرقمة أيضاً في تنظيم وتقديم المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهماً أو عندما يتعين الإشارة إلى إدخال (على سبيل المثال، *راجع الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء نقاط** أدناه:

1. إنشاء مثيل من فئة العرض التقديمي.
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## إنشاء النقاط

لإنشاء قائمة نقطية، اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة (التي تريد إضافة قائمة نقطية إليها) في مجموعة الشرائح من خلال كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء مثيل من الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. تعيين نوع النقطة إلى Symbol ثم تعيين حرف النقطة.
9. تعيين نص الفقرة.
10. تعيين مسافة الفقرة لإعداد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقطة.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. إضافة الفقرة الثانية وتكرار الخطوات 7-12.
15. حفظ العرض التقديمي.

هذا الكود المثالي بلغة C#—تنفيذ للخطوات السابقة—يوضح لك كيفية إنشاء قائمة نقطية في شريحة:

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
    paragraph.Text = "نصي";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## إنشاء النقاط المصورة

يسمح لك Aspose.Slides ل .NET بتغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري إلى قائمة أو جذب المزيد من الانتباه إلى إدخالات في قائمة، يمكنك استخدام صورتك الخاصة كنقطة.

 {{% alert color="primary" %}} 

من المثالي، إذا كنت تنوي استبدال الرمز النقطي العادي بصورة، أن ترغب في اختيار صورة رسومية بسيطة ذات خلفية شفافة. مثل هذه الصور تعمل بشكل أفضل كرموز نقطية مخصصة.

في أي حال، سيتم تقليل الصورة التي تختارها إلى حجم صغير جداً، لذلك نوصي بشدة بأن تختار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة.

{{% /alert %}} 

لإنشاء نقطة مصورة، انتبه إلى هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء مثيل من الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. تحميل الصورة من القرص وإضافتها إلى [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) ثم استخدام مثيل [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) الذي تم إرجاعه من طريقة [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. تعيين نوع النقطة إلى Picture ثم تعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين مسافة الفقرة لإعداد النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. إضافة الفقرة الثانية وتكرار الخطوات 7-13.
15. حفظ العرض التقديمي.

هذا الكود بلغة C# يوضح لك كيفية إنشاء نقطة مصورة في شريحة:

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
    paragraph.Text = "نصي";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## إنشاء النقاط متعددة المستويات

لإنشاء قائمة نقطية تحتوي على عناصر على مستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. إضافة [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) في الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. إنشاء مثيل من الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) مع تعيين العمق على 0.
7. إنشاء مثيل من الفقرة الثانية باستخدام فئة Paragraph وتعليم العمق على 1.
8. إنشاء مثيل من الفقرة الثالثة باستخدام فئة Paragraph وتعليم العمق على 2.
9. إنشاء مثيل من الفقرة الرابعة باستخدام فئة Paragraph وتعليم العمق على 3.
10. إضافة الفقرات التي تم إنشاؤها في مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. حفظ العرض التقديمي.

هذا الكود، الذي هو تنفيذ للخطوات السابقة، يوضح لك كيفية إنشاء قائمة نقطية متعددة المستويات بلغة C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "نصي عمق 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 1;
    paragraph2.Text = "نصي عمق 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "نصي عمق 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "نصي عمق 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## إنشاء أرقام

هذا الكود بلغة C# يوضح لك كيفية إنشاء قائمة مرقمة في شريحة:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "نصي 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "نصي 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```