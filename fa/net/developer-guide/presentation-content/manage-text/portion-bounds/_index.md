---
title: دریافت محدوده بخش متن از ارائه‌ها در .NET
linktitle: محدوده بخش
type: docs
weight: 47
url: /fa/net/portion-bounds/
keywords:
- محدوده بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های بخش متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET بازیابی کنید."
---
## **بررسی کلی**

یک بخش متن نمایانگر یک تکه خاص از متن درون یک پاراگراف است و به شما امکان می‌دهد تا به صورت مستقل بر روی آن بخش نسبت به محتوای اطراف کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت محدوده یک تکه متن، اعمال قالب‌بندی فقط بر روی بخشی از پاراگراف یا کنترل رفتار متن در سطح دقیق‌تری دارید.

این مقاله نشان می‌دهد چگونه با استفاده از [IPortion.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/getrect/) مستطیل محدودکننده یک بخش متن را به دست آورید. همچنین نشان می‌دهد چگونه با استفاده از [IPortion.GetCoordinates](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/getcoordinates/) مختصات ابتدای یک بخش متن را دریافت کنید. علاوه بر این، سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، مانند اعمال یک پیوند به یک تکه متن واحد، درک نحوه حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و وراثت تم، و رسیدگی به مواردی که یک فونت مشخص در دسترس نیست.

## **دریافت محدوده یک بخش متن**

برای بازیابی مستطیل محدودکننده یک بخش متن از [IPortion.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/getrect/) استفاده کنید:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **دریافت مختصات یک بخش متن**

برای بازیابی مختصات ابتدای یک بخش متن از [IPortion.GetCoordinates](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/getcoordinates/) استفاده کنید:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**آیا می‌توانم یک پیوند را فقط بر روی بخشی از متن درون یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید [یک پیوند اختصاص دهید](/slides/fa/net/manage-hyperlinks/) به یک بخش مجزا؛ تنها آن بخش قابل کلیک خواهد بود و نه کل پاراگراف.

**وراثت سبک چگونه کار می‌کند: یک بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

خصوصیات در سطح بخش بالاترین اولویت را دارند. اگر یک خصوصیت در [IPortion](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/) تنظیم نشده باشد، Aspose.Slides آن را از [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) می‌گیرد. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) یا [theme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/theme/) استفاده می‌کند.

**اگر فونت مشخص‌شده برای یک بخش در ماشین یا سرور هدف موجود نباشد، چه می‌شود؟**

[قواعد جایگزینی فونت](/slides/fa/net/font-selection-sequence/) اعمال می‌شود. ممکن است متن بازآرایی شود: معیارها، تقسیم واژه و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق اهمیت دارد.

**آیا می‌توانم شفافیت یا گرادیان پر متن مخصوص به یک بخش را به‌طور مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر و شفافیت در سطح [IPortion](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/) می‌تواند متفاوت از بخش‌های همسایه باشد.