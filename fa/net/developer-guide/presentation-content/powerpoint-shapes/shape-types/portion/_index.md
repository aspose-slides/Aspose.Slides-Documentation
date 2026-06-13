---
title: مدیریت بخش‌های متنی در ارائه‌ها در .NET
linktitle: بخش متن
type: docs
weight: 70
url: /fa/net/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه بخش‌های متنی را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET مدیریت کنید و عملکرد و سفارشی‌سازی را بهبود بخشید."
---
## **بررسی کلی**

یک بخش متنی نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد با آن قطعه به طور مستقل از محتوای اطراف کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز داشته باشید موقعیت یک قطعه متن را بازیابی کنید، قالب‌بندی را فقط برای بخشی از یک پاراگراف اعمال کنید، یا رفتار متن را در سطح دقیق‌تری کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از متد `GetCoordinates()` مختصات ابتدای یک بخش را به دست آورید. همچنین سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، از جمله اعمال یک پیوند به یک قطعه متن منفرد، درک چگونگی حل قالب‌بندی از طریق بخش، پاراگراف، قاب متن و ارث‌بری تم، و مدیریت مواردی که یک قلم مشخص در دسترس نیست. علاوه بر این، اشاره می‌کند که پرکردن متن، رنگ و شفافیت می‌توانند برای هر بخش به طور متفاوتی درون همان پاراگراف تنظیم شوند.

## **دریافت مختصات یک بخش متنی**
متد **GetCoordinates()** به IPortion و کلاس Portion اضافه شده است که امکان بازیابی مختصات ابتدای بخش را فراهم می‌کند:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند را فقط بر روی بخشی از متن در یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید یک پیوند را به یک بخش منفرد [اختصاص پیوند](/slides/fa/net/manage-hyperlinks/) اعمال کنید؛ فقط همان قطعه قابل کلیک خواهد بود، نه تمام پاراگراف.

**نحوهٔ کار ارث‌بری سبک‌ها چگونه است: چه چیزی توسط یک Portion بازنویسی می‌شود و چه چیزی از Paragraph/TextFrame گرفته می‌شود؟**

ویژگی‌های سطح Portion بالاترین اولویت را دارند. اگر ویژگی‌ای روی [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/) می‌گیرد؛ اگر در آنجا نیز تنظیم نشده باشد، از سبک [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/theme/) دریافت می‌شود.

**اگر قلم مشخص‌شده برای یک Portion در ماشین/سرور هدف موجود نباشد چه می‌شود؟**

[قوانین جایگزینی قلم](/slides/fa/net/font-selection-sequence/) اعمال می‌شوند. متن ممکن است دوباره‌چیدمان شود: متریک‌ها، hyphenation و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت یا گرادیان پر رنگ متن مخصوص یک Portion را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر شدن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) می‌تواند متفاوت از قطعات همسایه باشد.