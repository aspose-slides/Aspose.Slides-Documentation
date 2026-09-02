---
title: إدارة فقرات نص PowerPoint في .NET
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة العلامة النقطية
- إزاحة الفقرة
- إزاحة معلقة
- علامة الفقرة
- قائمة رقمية
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق الفقرات، الأجزاء، العلامات النقطية، القوائم الرقمية، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET تمثل النص كهرمية من إطارات النص، الفقرات، والأجزاء:

* [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر وصولاً إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر وصولاً إلى أجزائه وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) يمثل تشغيل نص داخل فقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق الأحرف.

بالتالي يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع عدة أجزاء**

الخطوات التالية تنشئ إطار نص مع ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الوصول إلى مرجع الشريحة المعنية عبر فهرسها.
3. إضافة شكل [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة عنصرين آخرين من نوع [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق على مستوى الأحرف عبر [IPortion.PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/portionformat/) .
9. حفظ العرض المعدل.

هذا المثال بلغة C# ينفذ الخطوات:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **إنشاء القوائم المنقطة والمرقمة**

### **إنشاء قائمة منقطة أو مرتبة**

تجعل العلامات النقطية والترقيم العناصر ذات الصلة أسهل للقراءة. في Aspose.Slides، يتم تعريف إعدادات القوائم عبر [IBulletFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/) .

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الوصول إلى مرجع الشريحة المعنية عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/) لعلامة نقطية رمزية.
7. تعيين [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/) وتحديد حرف العلامة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون العلامة، وارتفاع العلامة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/) .
11. تكوين نمط العلامة الرقمية وإضافة الفقرة إلى إطار النص.
12. حفظ العرض.

هذا المثال بلغة C# ينشئ علامة نقطية رمزية وعلامة رقمية:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **استخدام العلامات الصورية**

تسمح لك العلامات الصورية باستخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الوصول إلى مرجع الشريحة المعنية عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة العلامة وإضافتها إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) .
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [IBulletFormat.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/type/) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/bullettype/) .
8. تعيين الصورة عبر [IBulletFormat.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/picture/) وتحديد ارتفاع العلامة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض المعدل.

هذا المثال بلغة C# ينشئ علامة صورية:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **إنشاء قائمة متعددة المستويات**

تعيين [IParagraphFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/depth/) لوضع الفقرات عند مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) وإزالة الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز علاماتها النقطية.
4. تعيين قيم [IParagraphFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/depth/) إلى `0`، `1`، `2`، و `3` .
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة C# ينشئ قائمة نقطية بأربع مستويات:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدم [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith/) لتعيين الرقم الأول المعروض لفقرة مرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ar/net/aspose.slides/ibulletformat/numberedbulletstartwith/) إلى `2`، `3`، و `7` لكل فقرة على حدة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض.

هذا المثال بلغة C# يعيّن رقم بداية مخصص لكل فقرة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **تعيين إزاحة السطر الأول**

استخدم خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك فقط السطر الأول بالنسبة إلى الهامش الأيسر للفقرة. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة مع جسم الفقرة.

استخدم [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

يعرض المثال أدناه عدة فقرات ويطبق قيم مختلفة لـ [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض المعدل.

هذا الشيفرة توضح كيفية تعيين إزاحة الفقرة:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

النتيجة:

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يكون فيه السطر الأول يبدأ إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) . عيّن `Indent` إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عملياً، تحدد خاصية [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) موقع الهامش الأيسر لجسم الفقرة، وتحدد خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) موضع السطر الأول بالنسبة لذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

يكون هذا التنسيق مفيداً للببليوغرافيا، المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذيةً مع جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة [MarginLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginleft/) موجبة لكل فقرة.
6. تعيين قيمة سالبـة لـ [Indent](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض المعدل.

هذا الشيفرة توضح كيفية تعيين إزاحة معلقة لفقرة:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

النتيجة:

![إزاحة معلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

خاصية [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/endparagraphportionformat/) تتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط وخط اللاتينية لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) ومسح الفقرة الافتراضية الخاصة به.
3. إنشاء فقرتين وإضافة أجزاء نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fontheight/) و [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/latinfont/) .
6. إسناد التنسيق إلى [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/endparagraphportionformat/) وحفظ العرض.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار نص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الوصول إلى شريحة وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) .
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. حفظ العرض المعدل.

هذا المثال بلغة C# يستورد HTML إلى إطار نص:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **تصدير نص الفقرة إلى HTML**

استخدم [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphcollection/exporttohtml/) لتصدير مجموعة مختارة من الفقرات كملف HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة والعثور على [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) الذي يحتوي على النص.
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphcollection/exporttohtml/) مع فهرس الفقرة الابتدائية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المسترجعة إلى ملف.

هذا المثال بلغة C# يصدر جميع الفقرات من الشكل النصي الأول:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **عرض الفقرة كصورة**

[IParagraph.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getimage/) يعرض فقرة فردية مباشرة ويعيد كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) . احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/) . لا تحتاج إلى عرض الشكل المحتوي أو قص صورة يدوياً.

[IParagraph.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getimage/) يمكن أن يعيد `null` إذا لم يتم العثور على الفقرة في مجموعة الأبواب الخاصة بها، أو لا تمتلك حدود عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتأكد من تحرير الصورة المسترجعة بعد الاستخدام.

#### **عرض الفقرة بالمقياس الافتراضي**

نفترض أن لدينا ملف عرض يسمى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المسترجعة بصيغة PNG. تعليمة `using` تضمن تحرير الصورة بشكل صحيح.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **عرض الفقرة في خلية جدول مع التحجيم**

استخدم نسخة [IParagraph.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getimage/) التي تقبل معلمات `float scaleX` و `float scaleY` لتحديد عوامل التحجيم الأفقي والرأسي. المثال التالي ينشئ جدولاً، يعرض الفقرة في خليةه الأولى بارتفاع وعرض يبلغ ضعف الحجم الافتراضي، ويحفظ النتيجة كصورة PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

عامل التحجيم `1` يحافظ على البكسل الافتراضي للمحور. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريباً ضعف الأبعاد الافتراضية، أي بأربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تنتج نصاً أكثر وضوحاً للتكبير أو للإخراج عالي الدقة، لكنها أيضاً تزيد من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تنتج صوراً أصغر بأقل تفاصيل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تمدد الناتج بشكل مستقل.

عرض الشكل الكامل باستخدام [IShape.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getimage/) يظل مفيداً عندما يجب أن يشمل الإخراج تعبئة الشكل، أو حدوده، أو سياقه البصري. للصور التي تحتوي على فقرة فقط، استخدم [IParagraph.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getimage/) .

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. عيّن [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/wraptext/) لتعطيل التفاف السطر بحيث لا تنكسر السطور عند حدود إطار النص.

**كيف يمكنني الحصول على الحدود الفعلية للفقرة على الشريحة؟**

استخدم [IParagraph.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getrect/) لاسترجاع المستطيل المحيط بالفقرة. يوفر [IPortion.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/getrect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نصوص بعدة لغات.