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
- إدارة النقطة
- إزاحة الفقرة
- إزاحة متدلية
- نقطة الفقرة
- قائمة مرقمة
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأقسام، النقاط، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

تمثل Aspose.Slides for .NET النص كهرمية من إطارات النص، الفقرات، والأقسام:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر إمكانية الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويوفر إمكانية الوصول إلى أقسامها وتنسيق مستوى الفقرة.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) يمثل وحدة تشغيل نص داخل الفقرة. يمكن لكل قسم أن يحتوي على نصه الخاص وتنسيق على مستوى الأحرف.

يمكن للفقرة بذلك أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام أقسام متعددة.

## **إنشاء وتنسيق الفقرات**

إنشاء فقرات في إطار النص الخاص بالشكل واستخدام الأقسام لتنسيق وحدات تشغيل النص الفردية. يوضح هذا القسم كيفية دمج أقسام متعددة داخل كل فقرة وتطبيق ألوان، أحجام خطوط، وأنماط مختلفة.

### **إنشاء فقرات مع أقسام متعددة**

يقوم المثال التالي بلغة C# بإنشاء ثلاث فقرات، كل منها يحتوي على ثلاث وحدات تشغيل نص في مجموعة [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) . يعيد استخدام الفقرة الافتراضية وقسمها الفارغ، ثم يضيف الفقرات والأقسام المتبقية. يتم تطبيق التنسيق عبر [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): القسم الأول في كل فقرة يكون أحمر، غامق، وبحجم 15 نقطة؛ الثاني أزرق، مائل، وبحجم 18 نقطة. يحتفظ القسم الثالث بتنسيقه الافتراضي:

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

## **إنشاء القوائم النقطية والمرقمة**

تنظيم نص الفقرة في قوائم باستخدام الرموز أو الأرقام أو الصور المخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم المتدرجة، وتحديد أرقام بدء مخصصة.

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر ذات الصلة أسهل للقراءة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

يضيف هذا المثال بلغة C# نقطة رمزية وعنصر مرقم إلى نفس إطار النص. يحدد [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) نوع النقطة، بينما يزود [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) الرمز و [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) يحدد نمط الترقيم. يستخدم العنصران نقاطًا سوداء بارتفاع 100 بالمائة وإزاحة فقرة 25 نقطة:

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

تتيح لك نقاط الصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

يضيف هذا المثال بلغة C# صورة إلى مجموعة صور العرض التقديمي كـ [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) ويستخدمها كقائمة نقطية للفقرة. يضبط [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) لاستخدام نقطة صورة ويعين الصورة عبر [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). يتم ضبط [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) على 100 بالمائة لتحديد حجم النقطة نسبة إلى نص الفقرة:

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

قم بتعيين [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) لتحديد الفقرات في مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

يحدد هذا المثال بلغة C# قيم [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) من 0 إلى 3 لأربع فقرات، مما ينشئ تسلسلًا هرميًا داخل إطار نص واحد. تستخدم كل فقرة نقطة رمزية، مع تبديل [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) بين نقطة دائرية وواصلة لتمييز المستويات المتجاورة:

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

استخدم [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) لتعيين الرقم الأولي المعروض للفقرة المرقمة.

يحدد هذا المثال بلغة C# [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) لاستخدام الترقيم لثلاث فقرات ويعين قيم [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) بـ 2، 3، و7. يتم تكوين القيمة الابتدائية بشكل منفصل لكل فقرة، مما يسمح للرقم المعروض بتخطي القيم:

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

ضبط هوامش الفقرة والمسافات لتحديد موضع السطر الأول والأسطر المتدفقة. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن أقسام النص الظاهرة.

### **تعيين إزاحة السطر الأول**

استخدم الخاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة إلى الهامش الأيسر للفقرة. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

يعطي المثال التالي ثلاث فقرات نفس قيمة [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) وهي 20 نقطة و قيم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) بـ 0، 20، و40 نقطة. تبدأ الأسطر الأولى بفواصل متزايدة تدريجيًا، بينما تحتفظ الأسطر المتدفقة بنفس الهامش الأيسر:

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

The result:
![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة متدلية**

إزاحة متدلية هي تنسيق فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الخاصية [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). اضبط `Indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار نسبة إلى جسم الفقرة.

عمليًا، تحدد [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) موضع الجهة اليسرى لجسم الفقرة، وتحدد [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء إزاحة متدلية، اضبط قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للمراجع، الاقتباسات، مداخل القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المتدفقة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

يجمع المثال التالي بلغة C# قيم [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) بـ 40 و60 نقطة مع قيم [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) بـ -20 و-30 نقطة. في كل فقرة، يبدأ السطر الأول إلى اليسار من الأسطر المتدفقة؛ الفقرة الثانية لديها إزاحة متدلية أعمق:

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

The result:
![إزاحة متدلية للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

تتحكم الخاصية [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) في تنسيق علامة نهاية الفقرة. ينشئ المثال التالي [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) مع تعيين [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) إلى 48 نقطة و[IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) إلى Times New Roman. يعيّن هذا التنسيق إلى علامة النهاية للفقرة الثانية، مع ترك أقسام النص الظاهرة دون تغيير:

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

## **إحصاء الأسطر المرسومة**

لقواعد الفقرة التي تؤثر على الالتفاف التلقائي وعلامات الترقيم في نهايات الأسطر، راجع [التحكم في فاصل الأسطر](/slides/ar/net/text-formatting/#control-line-breaking) و[التحكم في علامات الترقيم المتدلية](/slides/ar/net/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) لعد الأسطر التي يشغلها الفقرة بعد تنسيق النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتنسيقه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/)، ويمكنها شغل عدة أسطر مرسومة. فاصل السطر الصريح داخل الفقرة يجبر على سطر جديد دون إنشاء فقرة أخرى. يخلق الالتفاف التلقائي أسطرًا استنادًا إلى العرض المتاح دون إدراج فواصل أسطر صريحة في النص. لذا لا يعطي عد الفقرات أو أحرف الفواصل عدد الأسطر المرسومة.

ينشئ المثال التالي شكل نص، يُعد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يمكّن المثال [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) ويعطل [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص أو تغيير حجم الشكل تلقائيًا. يستخدم كل قياس [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة عددها. قد تختلف الأعداد الدقيقة حسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المتوقعة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص سيتعدى حاويته. الارتفاع المتاح، ارتفاعات الأسطر، تباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية مهم أيضًا؛ حتى سطر واحد قد يتجاوز العرض المتاح عندما يكون الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لجلب النص إلى عرض تقديمي أو لتصدير الفقرات الحالية للاستخدام خارجها. توضح هذه القسم أيضًا كيفية تحويل الفقرات الفردية إلى صور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى فقرات**

استخدم [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وأقسام في إطار نص.

يقوم هذا المثال بلغة C# بقراءة HTML من ملف ويمرر الترميز إلى [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). يزيل الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) لتصدير نطاق مختار من الفقرات كـ HTML. عند إعادة استخدام نص العرض التقديمي على موقع ويب، قد ترغب في الحفاظ على التنسيق المحلي دون نقل خط العرض أو حجمه أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) للتحكم في مدى اتباع المُصدّر لتوارث التنسيق.

قم بتنزيل [the sample presentation](text-inheritance.pptx) وضعه في دليل العمل للتطبيق. تحتوي شريحته الأولى على شكل نصي واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال عمدًا عدة مستويات تنسيق:

- يوفّر نمط النص الافتراضي للعرض خط Calibri وحجم 28 نقطة.
- يوفّر نمط النص من المستوى الأول لإطار النص نصًا أزرق ومائل.
- تحدد الفقرة صراحة نصًا غامقًا.
- يحدد القسم الثاني، "explicit red 18pt"، صراحة نصًا أحمر وحجم 18 نقطة.

يصدّر المثال الكامل التالي الفقرات نفسها ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML منفصل بترميز UTF-8:

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

يحتوي HTML الناتج على CSS التالي للقسم الأول، "Inherited text; ". تُظهر الجدول التصريحات ذات الصلة؛ تم حذف الخصائص الأخرى المُنشأة للوضوح.

| الإخراج | CSS ذو الصلة للقسم الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل بحجم 28 نقطة في Calibri، إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل؛ تزوّد الصفحة أو المتصفح المحيط بخط العائلة والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص غامق؛ تزوّد الصفحة أو المتصفح المحيط بخط العائلة، الحجم، اللون، والنمط المائل. |

القسم الثاني يحتفظ بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاثة. كما يحتفظ بالمائل مع `All` و`TextBox`، ولكن ليس مع `ParagraphOnly`. لذلك لا يؤدي تقييد التوارث إلى إزالة التنسيق الذي تم تعيينه صراحةً لفقرة أو قسم.

افتح الملفات في نفس المتصفح للمقارنة بينها. في الوضعين المقيدين، تُحل الخصائص CSS المحذوفة بواسطة أنماط الصفحة الهدف أو إعدادات المتصفح الافتراضية، لذا يعتمد المظهر الناتج على مكان استخدام HTML.

### **إنشاء مقطع HTML من الحافظة**

قم بتعيين [AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) إلى `false` للحصول على HTML عادي أو `true` لتضمين رأس الحافظة. كلا الإستدعائين يعيدان سلسلة. يقدم الرأس إزاحات البايت UTF-8 للـ HTML المحيط (`StartHTML` و`EndHTML`) والمحتوى الذي سيُلصق (`StartFragment` و`EndFragment`).

يصدّر هذا المثال فقرتين منسقتين كـ HTML عادي (`html`) وكمقطع HTML للحافظة (`clipboardHtml`). كتابة المقطع إلى حافظة النظام خطوة تطبيق منفصلة. تتطلب واجهة برمجة الحافظة التي تقبل بايتات HTML الخام UTF-8 بدون BOM.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **تحويل فقرة إلى صورة**

يقوم [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) برسم فقرة فردية مباشرة ويعيد [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). لست بحاجة إلى رسم الشكل المحتوي أو قص صورة bitmap يدويًا.

قد يعيد [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` إذا لم يتم العثور على الفقرة في المجموعة الأصلية، أو لا تمتلك حدود عرض صالحة، أو لا يمكن رسمها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المعادة بعد الاستخدام.

#### **رسم فقرة بالمقياس الافتراضي**

يستخدم المثال عرضًا تقديميًا بشريحة واحدة حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

يختار المثال التالي الفقرة الثانية عند الفهرس 1 ويستدعي [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) دون معلمات المقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن عملية الرسم تُعيد صورة قبل استدعاء [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) لحفظها بصيغة PNG. يحرّر تصريح `using` الصورة بعد الاستخدام.

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

The result:
![صورة الفقرة](paragraph_to_image_output.png)

#### **رسم فقرة في خلية جدول مع التحجيم**

استخدم نسخة [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) التي تقبل معلمات `float scaleX` و `float scaleY` لتعيين عوامل التحجيم الأفقي والرأسي. ينشئ المثال التالي جدولًا، يرسم الفقرة في خليةه الأولى بمقدار مرتين عرضها وارتفاعها الافتراضي، ويحفظ النتيجة كصورة PNG.

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

العامل `1` يحافظ على هذا المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعني أربع مرات عدد البكسلات. عادةً ما تُنتج العوامل الأكبر نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها أيضًا تزيد من استهلاك الذاكرة وحجم الملف. العوامل أقل من `1` تُنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل الأفقية والرأسية المختلفة تمدّد الناتج بشكل مستقل.

لا يزال رسم شكل كامل باستخدام [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) مفيدًا عندما يجب أن يتضمن الناتج تعبئة الشكل، حدوده، أو سياقًا بصريًا آخر. للحصول على صورة للفقرة فقط، استخدم [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص تمامًا؟**

نعم. اضبط [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على الحدود الدقيقة على الشريحة لفقرة محددة؟**

استخدم [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) لاسترجاع مستطيل الحد للفقرة. يوفر [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) حدود قسم فردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو ضبط)؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأقسام الفردية. لرؤية محاذاة الخطوط داخل السطر، راجع [محاذاة الخطوط داخل السطر](/slides/ar/net/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) للأقسام الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بأكثر من لغة.