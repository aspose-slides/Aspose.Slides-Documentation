---
title: دریافت مرزهای پاراگراف از ارائه‌ها در .NET
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/net/paragraph/
keywords:
- مرزهای پاراگراف
- مرزهای بخش متن
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متن
- فریم متن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای پاراگراف و بخش‑متن را در Aspose.Slides برای .NET بازیابی کنید تا موقعیت‌یابی متن در ارائه‌های PowerPoint را بهینه کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محدوده‌ها، اندازه و مختصات پاراگراف‌ها و بخش‌های متنی را در Aspose.Slides به دست آورد. نحوه بازیابی مستطیل یک پاراگراف در یک `TextFrame` با استفاده از `GetRect()`، دریافت مختصات پاراگراف و بخش درون یک فریم متنی سلول جدول، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته‌بندی متن بر محدوده‌ها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را نشان می‌دهد.

## **دریافت مختصات پاراگراف و بخش در یک TextFrame**
با استفاده از Aspose.Slides برای .NET، توسعه‌دهندگان می‌توانند الآن مختصات مستطیلی پاراگراف را در مجموعه پاراگراف‌های یک TextFrame به دست آورند. همچنین امکان دریافت مختصات بخش درون مجموعه بخش‌های یک پاراگراف وجود دارد. در این بخش، با کمک یک مثال، نحوه دریافت مختصات مستطیلی پاراگراف به همراه مکان بخش درون پاراگراف را نشان می‌دهیم.

## **دریافت مختصات مستطیلی یک پاراگراف**
متد جدید **GetRect()** اضافه شده است. این متد امکان دریافت مستطیل مرزی پاراگراف را فراهم می‌کند.

```c#
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **دریافت اندازه یک پاراگراف و بخش درون فریم متنی سلول جدول**

برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion) یا [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph) در فریم متنی سلول جدول، می‌توانید از متدهای [IPortion.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/methods/getrect) و [IParagraph.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/methods/getrect) استفاده کنید.

این کد نمونه عملیات توضیح داده شده را نشان می‌دهد:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **سؤالات متداول**

**مختصات بازگردانده شده برای یک پاراگراف و بخش‌های متنی به چه واحدی اندازه‌گیری می‌شوند؟**

به واحد نقطه (point)؛ که 1 اینچ برابر 72 نقطه است. این واحد برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته‌بندی کلمات بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/wraptext/) در [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) فعال باشد، متن برای پر کردن عرض ناحیه شکسته می‌شود و این باعث تغییر مرزهای واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌دقت به پیکسل‌ها در تصویر صادراتی تبدیل کرد؟**

بله. نقطه‌ها به پیکسل با استفاده از رابطه زیر تبدیل می‌شوند: پیکسل = نقطه × (DPI / 72). نتیجه به DPI انتخاب‌شده برای رندر/صادرات وابسته است.

**چگونه پارامترهای قالب‌بندی «مؤثر» پاراگراف را دریافت کنم که ارث‌بری سبک را در نظر بگیرد؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/net/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی ترکیبی برای تورفتگی‌ها، فاصله‌ها، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.