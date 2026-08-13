---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية في .NET
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/net/manage-lists/
aliases:
  - /net/إدارة-القوائم-النقطية-والمرقمة/
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
- نقطة رمز
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
description: "تعلم كيفية إنشاء وتنسيق القوائم النقطية، والصور، ومتعددة المستويات، والمرقمة في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ .NET."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for .NET إنشاء وتنسيق القوائم ذات النقاط والترقيم في عروض PowerPoint و OpenDocument. عنصر القائمة هو فقرة يتم التحكم في إعدادات النقاط الخاصة بها من خلال تنسيق الفقرة.

استخدم الخاصية [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/) للوصول إلى إعدادات القوائم على مستوى الفقرة. نقطة الدخول الرئيسية هي [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/)، والتي تُعيد كائنًا من نوع [IBulletFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/). باستخدام هذا الكائن، يمكنك ضبط نوع النقطة، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

تظهر هذه المقالة كيف يمكن:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء نقطة بصورة
- إنشاء قائمة متعددة المستويات عن طريق ضبط عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتعديل تنسيق القوائم في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) واضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/). يمكنك بعد ذلك ضبط [IBulletFormat.Char](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/char/)، [IBulletFormat.Color](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/color/)، و[IBulletFormat.Height](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/height/) للتحكم في مظهر النقطة.

يوضح الكود التالي بلغة C# كيفية إنشاء قائمة نقطية في شريحة:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![نقاط الرمز](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. اضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstyle/) أو ضبط [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith/) عندما يجب أن تبدأ القائمة من قيمة مختلفة عن 1.

يوضح الكود التالي بلغة C# كيفية إنشاء قائمة مرقمة في شريحة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **إنشاء نقطة بصورة**

يسمح لك Aspose.Slides باستبدال رمز النقطة العادي بصورة. تعمل النقاط المصورة بشكل أفضل مع الصور البسيطة التي تظل مقروءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="info" %}}
من الناحية المثالية، إذا كنت تخطط لاستبدال رمز النقطة العادي بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. تعمل هذه الصور بشكل جيد كرموز نقطية مخصصة.
{{% /alert %}}

لإنشاء نقطة بصورة، أضف صورة إلى [Presentation.Images](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/images/) وعيّن كائن الصورة المرتجع إلى [IBulletFormat.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/picture/). اضبط [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للنقاط](picture_for_bullets.png)

يوضح الكود التالي بلغة C# كيفية إنشاء نقاط مصورة في شريحة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

![النقاط المصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [IParagraphFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/depth/) لتحديد مستويات عناصر القائمة. المستوى 0 هو المستوى الأعلى، المستوى 1 متدَّخِل تحته، وهكذا.

يوضح الكود التالي بلغة C# كيفية إنشاء قائمة نقطية متعددة المستويات:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **تعديل قائمة موجودة**

لتغيير تنسيق القوائم في عرض تقديمي موجود، قم بالوصول إلى الفقرة المستهدفة وتحديث إعدادات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/) الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم التي تم تحميلها من ملف PPT أو PPTX أو ODP.

يقوم الكود التالي بلغة C# بتغيير الفقرة الأولى في إطار نص لاستخدام نمط قائمة مرقمة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **الأسئلة المتكررة**

### هل يمكن تصدير القوائم النقطية والمرقمة إلى PDF أو صور؟

نعم. يحافظ Aspose.Slides على تنسيق القوائم عندما يدعم تنسيق الهدف تخطيط النص وميزات النقاط المقابلة.

### هل يمكنني تحرير القوائم في العروض التقديمية الموجودة؟

نعم. قم بتحميل العرض التقديمي، وصول إلى الفقرة المستهدفة، فحص أو تحديث إعدادات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/bullet/) الخاصة بها، ثم احفظ العرض التقديمي.

### هل يمكن أن تحتوي القوائم على نص غير لاتيني؟

نعم. يمكن لنص عنصر القائمة أن يحتوي على أحرف Unicode، وبالتالي يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض التقديمي تدعم الأحرف التي تحتاجها.