---
title: إدارة أشكال العرض التقديمي في .NET
linktitle: تعديل الشكل
type: docs
weight: 40
url: /ar/net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- عكس الشكل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تحديد، تعديل، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وعكس أشكال العروض التقديمية باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET تمثّل الأشكال على الشريحة كمجموعة مرتبة من نوع [IShapeCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/). تُعدّ المجموعة هي المكان الذي تجد فيه الأشكال وتعدّلها ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق وتعديل نقاط ضبط الشكل المُعينة مسبقًا، ثم يُظهر كيفية استنساخ، وإزالة، وإخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، وتصدير SVG، والمحاذاة، وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي يحتاجها سير العمل الخاص بك فقط.

## **تحديد وإيجاد الأشكال**

تُعد فهارس المجموعة ملائمة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. قد يغيّر إضافة أو إزالة أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لكيفية كتابة العروض وتحوّيلها:

- [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/name/) مفيدة للقوالب التي يتحكم فيها المطورون وسهلة الفحص في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يُضمن أن تكون فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/alternativetext/) مفيدة عندما يحدد وصف قابل للوصول أو وسم تم توفيره من قبل المؤلف الشكل. هو مرئي للمستخدمين، ويمكن ترجمته أو إعادة كتابته للوصول، ولا يُضمن أن يكون فريدًا. لا تعيد استخدام نص وصول ذو معنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/officeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل الذي يستخدمه PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا غبار له خلال عمر الشكل. الشكل المستنسخ أو المُعاد إنشاؤه هو شكل مختلف ويتلقى معرفًا خاصًا به.

خاصية [UniqueId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/uniqueid/) ذات نطاق العرض، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي اعتبارها مفتاحًا خارجيًا دائمًا. إذا كان التعرف طويل الأمد ضروريًا، احتفظ بالترابط في بيانات التطبيق وتأكد من أن الشكل المتوقع لا يزال موجودًا.

للحصول على مثال عملي لقراءة وتحديث كل من عنوان النص البديل ووصفه، انظر [Manage Alternative Text Titles and Descriptions](/slides/ar/net/presentation-accessibility/). استخدم النص البديل لشرح معنى العنصر البصري للقراء، واحفظه منفصلًا عن أسماء الأشكال التي يستخدمها الكود للعثور على الأشكال.

المثال التالي يبحث عن طريق `Name` بمقارنة ترتيبية ويُبلّغ معرف interop ذو نطاق شريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُظهر الكود هذا النتيجة بدلاً من الاستمرار مع الكائن الخطأ.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

عند كون العملية محددة لنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المسمى من نوع [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **تحديد وتعديل ضبط الشكل المُعد مسبقًا**

يمكن للأشكال الهندسية المُعدة مسبقًا كشف نقاط ضبط تتحكم في خصائص مثل حجم الزاوية، أو نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة القراءة فقط [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/adjustments/). المجموعة نفسها تُزودها الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/net/aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحص خاصية القراءة فقط [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/type/)، التي يصفها قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeadjustmenttype/) ما يتحكم به الضبط. خاصية القراءة فقط [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/name/) تُوفر معلومات تعريف إضافية وهي مفيدة خاصةً عندما يحتوي الإعداد المُسبق على أكثر من ضبط من نفس النوع الدلالي.

استخدم خاصية القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة التي يجب تغييرها |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [RawValue](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | سمك ذيل السهم | `RawValue` |
| `ArrowheadLength` | طول رأس السهم | `RawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `RawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [AngleValue](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `AngleValue` |

لا يمكن تعيين `Type` و `Name`. `RawValue` هو عدد صحيح للقراءة والكتابة بوحدات الهندسة الأصلية للإعداد، بينما `AngleValue` هو زاوية للقراءة والكتابة بالدرجات. عدد، ترتيب، معنى، والنطاق الصالح للضبط يعتمد على [ShapeType](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/shapetype/) الخاص بالإعداد. قد تكون القيمة صالحة لإعداد ما لكنها غير صالحة أو لها تأثير مختلف لإعداد آخر.

عندما يكون `Type` هو `ShapeAdjustmentType.Custom`، لا يتعرف API على معنى دلالي قياسي. فحص `Name`، نوع الإعداد، والقيمة الحالية، واترك الضبط دون تغيير ما لم تكن المعنى والنطاق المتوقع معروفين. حتى للأنواع المعروفة، تحقق ما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/net/connector/) هذا الوضع مع تعديلات انحناء الموصل.

المثال الكامل التالي يُنشئ نسخًا افتراضية ومُعدلة من ثلاثة أشكال مُعدة مسبقًا. يكرّر عبر كل ضبط، يُبلّغ `Name` و `Type`، يغيّر القيم المتعلقة بالحجم عبر `RawValue`، يغيّر الزوايا عبر `AngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المُعدّل، السهم رباعي الاتجاهات، والفطيرة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// يضيف رؤوسًا لأعمدة الشكل الافتراضي والمعدَّل.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

فحص النوع الدلالي قبل تغيير قيمة يجعل الكود واضحًا بشأن نواياه ويتجنب افتراض أن فهرس مجموعة معين له نفس المعنى عبر أشكال مُعدة مسبقًا مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة مباشرة. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس المُلتقَطة قبل تلك العملية.

### **استنساخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/insertclone/) يخلق نسخة أيضًا لكنه يضعها في فهرس z-order محدد. التحميل الزائد الذي يقبل إحداثيات ينقل النسخة دون تغيير حجمها؛ التحميل الزائد مع العرض والارتفاع يمكنه تغيير الحجم أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا معنونا إلى الأمام، ويُدرج نسخة ثانية في الخلف. لا تُغيّر التغييرات على أي نسخة المصدر.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. أعطِ معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقدة تُدار بواسطة العرض، لكن النسخة تبقى عنصر مجموعة جديد له هوية شكل جديدة.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة تطابقات متعددة أثناء تكرار مفهرس، تجول من النهاية بحيث يظل كل فهرس متبقي صالحًا.

هذا المثال يزيل كل شكل يحمل اسماً معينًا. يقرأ `slide.Shapes[i]`، ليس عنصر مجموعة ثابت، ولا يقوم بالتحويل غير الضروري للشكل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تظل الإشارات إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المُحفظة. ضع في اعتبارك الموصلات، والرسوم المتحركة، وغيرها من ميزات العرض التي قد تشير إلى الكائن المُزال؛ إزالة شكل ظاهر قد يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/hidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنع ظهوره في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

الإخفاء ليس حذفًا أو أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإعادة إظهاره، ويظل جزءًا من ملف العرض.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `Count - 1` هو الأمام.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

يُنشأ المستطيل أولاً ويجلس في البداية خلف القطعة البيضوية. نقله إلى الفهرس النهائي يضعه في المقدمة. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن هذه العمليات تُضيف أو تُدرج عناصر مجموعة جديدة وقد تُغيّر التكديس المقصود.

## **فحص الأشكال على شرائح التخطيط**

لشرائح عادية، وشرائح تخطيط، وشرائح أساسية مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل في شريحة عادية في موقع مماثل. فحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق مقدَّم من تخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/fillformat/) و [LineFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/lineformat/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت شريحة عادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/writeassvg/) يكتب محتوى شكل واحد مُعرض إلى تدفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بالكامل ولا الأشكال المجاورة.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

احتفظ بالعرض مفتوحًا أثناء التقديم. يعتمد الناتج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التركيبة الكاملة، صدّر الشريحة بدلًا من شكل فردي. المتصل يملك التدفق ويجب أن يُفرغ (dispose)ه.

## **محاذاة الأشكال**

تُطابق الدالات [SlideUtil.AlignShapes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/alignshapes/) إما كل الأشكال أو فهارس مجموعة مختارة. تحدد [ShapesAlignmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapesalignmenttype/) الحافة، أو الخط المركزي، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المحددة بالنسبة لبعضها.

هذا المثال يُحاذى ثلاثة أشكال إلى الحافة العليا للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

تغيّر المحاذاة المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو العمودي عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الدالة.

## **انعكاس شكل**

تخزن الفئة [ShapeFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeframe/) الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيم `FlipH` و `FlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/): `True` يُفعل الانعكاس، `False` يُعطل، و `NotDefined` يُحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير معكوس.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

المثال يحافظ على جميع قيم الإطار الأخرى ويستبدل فقط إعدادَي الانعكاس. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/frame/) جديد يستبدل الإطار بالكامل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

الشكل المحفوظ مُنعكس أفقيًا وعموديًا مع الحفاظ على موقعه وحجمه ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب أن أستخدم فهرس مجموعة كمُعرف للشكل؟**

فقط لمعالجة قصيرة الأمد عندما لن تتغيّر المجموعة قبل استخدام الفهرس. يفضَّل اعتماد اتفاقية `Name` أو `AlternativeText` للقوالب المكتوبة، أو `OfficeInteropShapeId` للأعمال التي تعتمد على interop في الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة بنفس الفهرس. يمكن العثور عليه، وإعادة ترتيبه، وتعديله، أو إظهاره مرة أخرى.

**لماذا ظهر شكل مستنسخ أمام شكل آخر؟**

`AddClone` يضيف النسخة إلى نهاية المجموعة، وهي أمام ترتيب Z. استخدم `InsertClone` لتحديد الفهرس الأولي أو `Reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مُعد مسبقًا؟**

فقط بعد التحقق من الإعداد الدقيق وتخطيط المجموعة. يفضَّل تكرار عبر `IGeometryShape.Adjustments` والتحقق من `IAdjustValue.Type`؛ استخدم `IAdjustValue.Name` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.