---
title: به‌دست‌آوردن محدوده‌های پاراگراف از ارائه‌ها در .NET
linktitle: حدود پاراگراف
type: docs
weight: 43
url: /fa/net/paragraph-bounds/
keywords:
- حدود پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- قاب متن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه حدود پاراگراف را در Aspose.Slides برای .NET دریافت کنید تا موقعیت‌یابی متن در ارائه‌های PowerPoint بهینه شود."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توان حدود، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides دریافت کرد. نشان می‌دهد چگونه با استفاده از [IParagraph.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getrect/) یک مستطیل پاراگراف را از یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) دریافت کرد، چطور مختصات پاراگراف را داخل قاب متن سلول جدول به‌دست آورد و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته شدن متن بر حدود، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [IParagraph.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محدودهٔ یک پاراگراف استفاده کنید.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **دریافت اندازهٔ یک پاراگراف داخل قاب متن سلول جدول**

برای دریافت اندازه و مختصات یک [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) در قاب متن سلول جدول، از [IParagraph.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getrect/) استفاده کنید. مستطیل بازگردانده شده نسبت به قاب متن سلول جدول است، بنابراین هنگام نیاز به مختصات سطح اسلاید، موقعیت جدول و جابه‌جایی سلول را اضافه کنید.

مثال زیر حدود پاراگراف داخل یک سلول جدول را دریافت می‌کند و مستطیل‌هایی روی اسلاید می‌کشد تا این حدود را به‌صورت بصری نشان دهد:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**مختصات پاراگراف با چه واحدهایی اندازه‌گیری می‌شود؟**

آن‌ها بر حسب پوینت اندازه‌گیری می‌شوند، به‌طوری که ۱ اینچ برابر ۷۲ پوینت است. این برای تمام مختصات و ابعاد روی اسلاید صادق است.

**آیا بسته شدن متن (Word Wrapping) بر حدود پاراگراف تأثیر می‌گذارد؟**

بله. اگر [TextFrameFormat.WrapText](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/wraptext/) برای [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود و این باعث تغییر حدود واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اعتماد به پیکسل‌ها در تصویر خروجی تبدیل کرد؟**

بله. پوینت‌ها را با استفاده از این فرمول به پیکسل تبدیل کنید: پیکسل = پوینت × (DPI / ۷۲). نتیجه به DPI انتخابی برای رندر یا خروجی بستگی دارد.

**چگونه می‌توانم پارامترهای قالب‌بندی «موثر» پاراگراف را با در نظر گرفتن ارث‌بری سبک دریافت کنم؟**

از [effective paragraph formatting data structure](/slides/fa/net/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی تجمیع‌شده برای تورفتگی‌ها، فاصله‌ها، بسته شدن متن، راست به چپ و موارد دیگر را برمی‌گرداند.