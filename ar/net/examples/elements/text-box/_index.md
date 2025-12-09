---
title: مربع النص
type: docs
weight: 40
url: /ar/net/examples/elements/text-box/
keywords:
- مثال على مربع النص
- إضافة مربع نص
- الوصول إلى مربع النص
- حذف مربع النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتنسيق مربعات النص في C# باستخدام Aspose.Slides: تعيين الخطوط، والمحاذاة، والالتفاف، والملاءمة التلقائية، والروابط لتحسين الشرائح لـ PowerPoint و OpenDocument."
---

في Aspose.Slides، يتم تمثيل **مربع النص** بواسطة `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، ولكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يوضح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجياً.

## إضافة مربع نص

مربع النص هو ببساطة `AutoShape` بدون تعبئة أو حد ومع بعض النص المنسق. إليك كيفية إنشاء واحد:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
````

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكن أن يعمل كمربع نص.

## الوصول إلى مربعات النص حسب المحتوى

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية معينة (مثل "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## حذف مربعات النص حسب المحتوى

يوضح هذا المثال كيفية العثور على جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية معينة وحذفها:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطأ تعديل المجموعة.