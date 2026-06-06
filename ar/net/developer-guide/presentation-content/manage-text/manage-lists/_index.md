---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام .NET
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/net/manage-lists/
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
description: "تعلم كيفية إنشاء وتنسيق القوائم النقطية، وقوائم الصور، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET يتيح لك إنشاء وتنسيق القوائم ذات النقاط والمرقمة في عروض PowerPoint وOpenDocument. عنصر القائمة هو فقرة يتم التحكم في إعدادات النقطة الخاصة به من خلال تنسيق الفقرة.

استخدم خاصية [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/) للوصول إلى إعدادات القائمة على مستوى الفقرة. النقطة الرئيسية هي [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/)، التي تُعيد كائنًا من نوع [IBulletFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/). باستخدام هذا الكائن، يمكنك تعيين نوع النقطة، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

يظهر هذا المقال كيف تقوم بـ:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء نقطة صورة
- إنشاء قائمة متعددة المستويات عن طريق تعيين عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتعديل تنسيق القائمة في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) واضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/). يمكنك بعد ذلك ضبط [IBulletFormat.Char](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/char/)، [IBulletFormat.Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/color/)، و[IBulletFormat.Height](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/height/) للتحكم في مظهر النقطة.

الكود التالي بلغة C# يوضح كيفية إنشاء قائمة نقطية في شريحة:

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

النتيجة:

![النقاط الرمزية](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. اضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstyle/) أو ضبط [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith/) عندما يجب أن تبدأ القائمة برقم غير 1.

الكود التالي بلغة C# يوضح كيفية إنشاء قائمة مرقمة في شريحة:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

النتيجة:

![النقاط المرقمة](numbered_bullets.png)

## **إنشاء نقطة صورة**

Aspose.Slides يسمح لك باستبدال رمز النقطة العادي بصورة. تعمل نقاط الصورة بشكل أفضل مع الصور البسيطة التي تظل مقروءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من المثالي، إذا كنت تخطط لاستبدال رمز النقطة العادي بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. مثل هذه الصور تعمل جيدًا كرموز نقطية مخصصة.

ضع في اعتبارك أن الصورة ستُصغر إلى حجم صغير جدًا. لهذا السبب، نوصي بشدة باختيار صورة تظل واضحة وفعّالة بصريًا عندما تُستخدم كنقطة في قائمة.
{{% /alert %}}

لإنشاء نقطة صورة، أضف صورة إلى [Presentation.Images](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/images/) وعيّن كائن الصورة المرتجع إلى [IBulletFormat.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/picture/). اضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للنقاط](picture_for_bullets.png)

الكود التالي بلغة C# يوضح كيفية إنشاء نقاط صورة في شريحة:

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

النتيجة:

![النقاط الصورية](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [IParagraphFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/depth/) لوضع عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى الأعلى، المستوى 1 متداخل تحته، وهكذا.

الكود التالي بلغة C# يوضح كيفية إنشاء قائمة نقطية متعددة المستويات:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

النتيجة:

![القائمة متعددة المستويات](multilevel_list.png)

## **تغيير قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، وصل إلى الفقرة المستهدفة وقم بتحديث إعدادات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/) الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم المحمّلة من ملف PPT أو PPTX أو ODP.

الكود التالي بلغة C# يُغيّر الفقرة الأولى في إطار نص لاستخدام نمط قائمة مرقمة:

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **FAQ**

**هل يمكن تصدير القوائم النقطية والمرقمة إلى PDF أو صور؟**

نعم. Aspose.Slides يحافظ على تنسيق القوائم عندما يدعم format الهدف تخطيط النص وميزات النقاط المقابلة.

**هل يمكنني تحرير القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، وصل إلى الفقرة المستهدفة، افحص أو حدّث إعدادات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/)، ثم احفظ العرض.

**هل يمكن أن تحتوي القوائم على نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عناصر القائمة على أحرف يونيكود، مما يتيح إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.