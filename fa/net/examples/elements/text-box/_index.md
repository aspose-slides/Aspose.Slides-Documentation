---
title: جعبه متن
type: docs
weight: 40
url: /fa/net/examples/elements/text-box/
keywords:
- جعبه متن
- افزودن جعبه متن
- دسترسی به جعبه متن
- حذف جعبه متن
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با جعبه‌های متن در Aspose.Slides برای .NET: افزودن، قالب‌بندی، تراز، شکست خطوط، خودکاراندازه‌گیری و استایل دهی متن با استفاده از C# برای ارائه‌های PPT، PPTX و ODP."
---
در Aspose.Slides، یک **جعبه متن** توسط یک `AutoShape` نشان داده می‌شود. تقریباً هر شکلی می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما توضیح می‌دهد که چگونه جعبه‌های متن را به‌صورت برنامه‌نویسی اضافه، دسترسی پیدا کرده و حذف کنید.

## **افزودن جعبه متن**

یک جعبه متن ساده یک `AutoShape` بدون پر یا حاشیه و با متنی قالب‌بندی‌شده است. در ادامه نحوه‌ی ایجاد آن آمده است:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک شکل مستطیلی ایجاد کنید (به‌صورت پیش‌فرض پر با حاشیه و بدون متن).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // حذف پر و حاشیه برای اینکه شبیه یک جعبه متن معمولی باشد.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // تنظیم قالب‌بندی متن.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // متن واقعی را اختصاص دهید.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **نکته:** هر `AutoShape` که دارای `TextFrame` غیر خالی باشد می‌تواند به‌عنوان جعبه متن عمل کند.

## **دسترسی به جعبه‌های متن بر اساس محتوا**

برای یافتن تمام جعبه‌های متنی که شامل کلمه‌کلیدی خاصی هستند (مثلاً "Slide")، از طریق اشکال تكرار کنید و متن آن‌ها را بررسی کنید:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // فقط AutoShapeها می‌توانند متن قابل ویرایش داشته باشند.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // کاری با جعبه متن مطابق انجام دهید.
            }
        }
    }
}
```

## **حذف جعبه‌های متن بر اساس محتوا**

این مثال تمام جعبه‌های متنی را که در اسلاید اول وجود دارند و شامل کلمه‌کلیدی خاصی هستند، پیدا کرده و حذف می‌کند:

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

> 💡 **راهنما:** همیشه پیش از اصلاح مجموعهٔ اشکال، یک کپی از آن تهیه کنید تا هنگام تکرار خطاهای تغییر مجموعه رخ ندهد.