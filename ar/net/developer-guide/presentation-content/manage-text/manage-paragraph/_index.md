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
- إدارة نقطة
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- تحويل النص إلى HTML
- تحويل الفقرة إلى HTML
- تحويل الفقرة إلى صورة
- تحويل النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، والجزءات، والنقاط، والقوائم المرقمة، والإزاحات، ومحتوى HTML، وصور الفقرات باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET يمثل النص كهرمية من إطارات النص، الفقرات، والجزءات:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) يمثل فقرة واحدة داخل إطار النص ويوفر الوصول إلى الجزءات وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) يمثل مقطع نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق الأحرف الخاص به.

وبالتالي يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات مختلفة باستخدام عدة جزءات.

## **إنشاء وتنسيق الفقرات**

قم بإنشاء فقرات داخل إطار النص الخاص بالشكل واستخدم الجزءات لتنسيق مقاطع النص الفردية. يوضح هذا القسم كيفية الجمع بين عدة جزءات داخل كل فقرة وتطبيق ألوان، أحجام خطوط، وأنماط مختلفة.

### **إنشاء فقرات مع عدة جزءات**

المثال التالي بلغة C# ينشئ ثلاث فقرات، كل منها يحتوي على ثلاث مقاطع نص في مجموعة [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). يعيد استخدام الفقرة الافتراضية والجزء الفارغ، ثم يضيف الفقرات والجزءات المتبقية. يتم تطبيق التنسيق عبر [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): الجزء الأول في كل فقرة يكون أحمر، عريض، وبحجم 15 نقطة؛ الثاني أزرق، مائل، وبحجم 18 نقطة. الجزء الثالث يحتفظ بالتنسيق الافتراضي:

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

## **إنشاء قوائم نقطية ورقمية**

نظم نص الفقرة في قوائم باستخدام رموز أو أرقام أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم متعددة المستويات، والأرقام الابتدائية المخصصة.

### **إنشاء قائمة نقطية أو رقمية**

تسهل النقاط والترقيم قراءة العناصر ذات الصلة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

هذا المثال بلغة C# يضيف نقطة برمز وعنصر مرقم إلى نفس إطار النص. يحدد [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) نوع النقطة، بينما يزود [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) بالرمز و[IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) نمط الترقيم. كلا العنصرين يستخدمان نقاط سوداء بارتفاع 100٪ وإزاحة فقرة 25 نقطة:

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

### **استخدام نقاط صورة**

تتيح نقاط الصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

هذا المثال بلغة C# يضيف صورة إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) ويستخدمها كنقطة للفقرة. يضبط [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) لاستخدام نقطة صورة ويعيّن الصورة عبر [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). يتم ضبط [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) على 100٪ لتحديد حجم النقطة نسبة إلى نص الفقرة:

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

قم بتعيين [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) لوضع الفقرات في مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

هذا المثال بلغة C# يعين قيم [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) من 0 إلى 3 لأربع فقرات، مخلقاً هرمية داخل إطار نص واحد. كل فقرة تستخدم نقطة رمز، مع تبديل [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) بين نقطة دائرية وشرطة لتحديد المستويات المتجاورة:

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

### **بدء عناصر قائمة رقمية بقيم مخصصة**

استخدم [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) لتعيين الرقم الأولي المعروض للفقرة الرقمية.

هذا المثال بلغة C# يضبط [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) لاستخدام الترقيم لثلاث فقرات ويعيّن قيم [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) إلى 2 و3 و7. يتم تكوين القيمة الابتدائية بصورة منفصلة لكل فقرة، مما يسمح بتخطي الأرقام بين الفقرات:

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

قم بضبط الهوامش والإزاحات للفقرة للتحكم في موضع السطر الأول والأسطر المتفافرة. يمكنك أيضاً تنسيق علامة نهاية الفقرة بشكل منفصل عن جزء النص الظاهر.

### **تعيين إزاحة السطر الأول**

استخدم خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة إلى الهوامش اليسرى للفقرة. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. واستخدم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال التالي يعطي ثلاث فقرات نفس قيمة [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) البالغة 20 نقطة وقيم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) قدرها 0 و20 و40 نقطة. تبدأ الأسطر الأولى بأزاحات متزايدة، بينما تحتفظ الأسطر المتفافرة بنفس الهامش الأيسر:

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

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام خاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). اضبط `Indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عملياً، تحدد [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) الموضع الأيسر لجسم الفقرة، وتحدد [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `MarginLeft` موجبة و`Indent` سالبة.

هذا التنسيق مفيد للببليوغرافيا، المراجع، مدخلات القاموس، وغيرها من الفقرات التي تحتاج إلى محاذاة الأسطر المتفافرة تحت جسم الفقرة وليس تحت أول حرف من السطر الأول.

المثال التالي بلغة C# يقرن قيم [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) البالغة 40 و60 نقطة مع قيم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) قدرها -20 و-30 نقطة. في كل فقرة يبدأ السطر الأول إلى اليسار من الأسطر المتفافرة؛ الفقرة الثانية تحتوي على إزاحة معلقة أعمق:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص نهاية الفقرة**

خاصية [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) تتحكم في تنسيق علامة نهاية الفقرة. المثال التالي ينشئ [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) مع ضبط [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) إلى 48 نقطة و[IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) إلى Times New Roman. يعيّن هذا التنسيق لعلامة نهاية الفقرة الثانية، مع إبقاء جزء النص الظاهر دون تغيير:

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

## **عدد الأسطر المُعالجة**

للقواعد المتعلقة بالالتفاف التلقائي وعلامات الترقيم عند نهاية السطر، راجع [Control Line Breaking](/slides/ar/net/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/net/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) لعد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتخطيط القالب.

الفقرة هي عنصر واحد في [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/)، ويمكن أن تشغل عدة أسطر مُعالجة. كسر السطر الصريح داخل الفقرة يُجبر سطرًا جديدًا دون إنشاء فقرة أخرى. الالتفاف التلقائي ينشئ أسطرًا بناءً على العرض المتاح دون إدراج فواصل صريحة في النص. بذلك، عد الفقرات أو حروف كسر السطر لا يعطي عدد الأسطر المُعالجة.

المثال التالي ينشئ شكل نص، يعد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يُمكن المثال من تمكين [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) وتعطيل [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص تلقائيًا أو تعديل حجم الشكل. كل قياس يستخدم [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). أبعاد الشكل بوحدات النقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة عددها. قد تختلف الأعداد الدقيقة بحسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يتجاوز حاويته. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية كلها عوامل مهمة؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا كان الالتفاف معطَّلًا.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لجلب النص إلى عرض تقديمي أو لتصدير الفقرات الحالية للاستخدام خارجه. يوضح هذا القسم أيضًا طريقة تصيير الفقرات الفردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وجزءات داخل إطار النص.

هذا المثال بلغة C# يقرأ HTML من ملف ويمرره إلى [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). يمسح الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) لتصدير نطاق مختار من الفقرات إلى HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التأكيد المحلي دون نقل خطوط العرض أو حجم النص أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) للتحكم إلى أي مدى يتبع المُصدّر وراثة التنسيق.

حمّل [العرض التجريبي](text-inheritance.pptx) وضعه في دليل عمل التطبيق. يحتوي الشريحة الأولى على شكل نص واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال مستويات تنسيق متعددة عمدًا:

- النمط النصي الافتراضي للعرض يحدد Calibri بحجم 28 نقطة.
- نمط النص من المستوى الأول لإطار النص يحدد نصًا أزرق ومائل.
- الفقرة تحدد نصًا عريضًا صراحةً.
- الجزء الثاني، "explicit red 18pt"، يحدد نصًا أحمر بحجم 18 نقطة صراحةً.

المثال الكامل التالي يصدر نفس الفقرات ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF‑8 منفصل:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

HTML المُولد يحتوي على CSS التالي للجزء الأول، "Inherited text; ". الجدول يُدرج التصريحات ذات الصلة؛ الخصائص الأخرى تم حذفها للوضوح.

| الإخراج | CSS ذي الصلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل بحجم 28 pt في Calibri إذا كان الخط متوفرًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل؛ الصفحة أو المتصفح يقدمان عائلة الخط والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص عريض؛ الصفحة أو المتصفح يقدمان عائلة الخط، الحجم، اللون، والنمط المائل. |

الجزء الثاني يحتفظ بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `All` و`TextBox`، لكن ليس في `ParagraphOnly`. لذا فإن تقييد الوراثة لا يزيل التنسيق المعين صراحةً إلى فقرة أو جزء.

افتح الملفات في نفس المتصفح للمقارنة. في الوضعين المقيدين، تُحل الخصائص CSS المحذوفة عبر أنماط الصفحة الوجهة أو القيم الافتراضية للمتصفح، وبالتالي يختلف المظهر حسب مكان استخدام HTML.

### **تصيير فقرة كصورة**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) يصدر الفقرة الفردية مباشرةً ويعيد [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). احفظ النتيجة في ملف أو تدفق باستخدام [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). لا تحتاج إلى تصيير الشكل الحاوي أو اقتصاص صورة يدوياً.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) قد يُعيد `null` إذا لم تُعثر الفقرة في المجموعة الأم، أو لا توجد حدود تصيير صالحة، أو لا يمكن تصييرها. افحص النتيجة قبل حفظها وتخلص من الصورة المسترجعة بعد الاستخدام.

#### **تصيير فقرة بالمقياس الافتراضي**

المثال يستخدم عرضًا يحتوي على شريحة واحدة وشكل نصي أول يحتوي على ثلاث فقرات.

![شكل النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يختار الفقرة الثانية عند الفهرس 1 ويستدعي [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) دون معلمات مقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن التصيير يُعيد صورة قبل استدعاء [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) لحفظها بصيغة PNG. يضمن بيان `using` تحرير الصورة بعد الاستخدام.

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

#### **تصيير فقرة داخل خلية جدول مع مقياس**

استخدم نسخة [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) التي تقبل معلمات `float scaleX` و`float scaleY` لتحديد عوامل المقياس الأفقي والرأسي. يخلق المثال جدولًا، يصيّر الفقرة في خليتها الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

عامل مقياس `1` يبقي ذلك المحور على حجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعادل أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تنتج نصًا أكثر وضوحًا للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متماثلة للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل الأفقية والعمودية المختلفة تمدد المخرج بشكل مستقل.

تصيير الشكل كاملًا باستخدام [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) لا يزال مفيدًا عندما يتطلب الإخراج تعبئة الشكل أو حدوده أو سياقه المرئي. لتصوير الفقرة فقط، استخدم [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. اضبط [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة الدقيقة داخل الشريحة؟**

استخدم [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) لاسترجاع المستطيل المحيط بالفقرة. يوفر [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو مبرّر)؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الجزء الفردي.

لتحاذي الخطوط ذات الأحجام المختلفة عمودياً داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/net/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نصوص بعدة لغات.