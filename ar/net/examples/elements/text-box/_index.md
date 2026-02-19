---
title: مربع نص
type: docs
weight: 40
url: /ar/net/examples/elements/text-box/
keywords:
- مربع نص
- إضافة مربع نص
- الوصول إلى مربع نص
- إزالة مربع نص
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع مربعات النص في Aspose.Slides لـ .NET: إضافة، تنسيق، محاذاة، التفاف، ضبط تلقائي، وتنسيق النص باستخدام C# لعروض PPT و PPTX و ODP."
---
في Aspose.Slides، يتم تمثيل **مربع النص** بواسطة `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، ولكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة، والوصول إلى، وإزالة مربعات النص برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` بدون تعبئة أو حدود وبعض النص المنسق. إليك كيفية إنشاء واحد:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إنشاء شكل مستطيل (الافتراضي ملئ بحد ولا نص).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // إزالة التعبئة والحد لجعله يبدو كمربع نص نموذجي.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // تعيين تنسيق النص.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // تعيين محتوى النص الفعلي.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكن أن يعمل كمربع نص.

## **الوصول إلى مربعات النص حسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية معينة (مثلاً "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // يمكن فقط لـ AutoShapes أن تحتوي على نص قابل للتحرير.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // قم بفعل شيء مع مربع النص المتطابق.
            }
        }
    }
}
```

## **إزالة مربعات النص حسب المحتوى**

يوضح هذا المثال كيفية العثور على جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية معينة وحذفها:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.