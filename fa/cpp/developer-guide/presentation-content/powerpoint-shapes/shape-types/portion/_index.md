---
title: مدیریت بخش‌های متن در ارائه‌ها با استفاده از C++
linktitle: بخش متن
type: docs
weight: 70
url: /fa/cpp/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++ مدیریت کنید و عملکرد و سفارشی‌سازی را بهبود بخشید."
---
## **مقدمه**

یک بخش متن نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد تا به‌طور مستقل از محتوای اطراف با آن قطعه کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت موقعیت یک قطعه متن، اعمال قالب‌بندی تنها بر بخشی از پاراگراف، یا کنترل رفتار متن در سطحی دقیق‌تر داشته باشید.

## **دریافت مختصات یک بخش متن**
**GetCoordinates()** متدی است که به IPortion و کلاس Portion اضافه شده و امکان دریافت مختصات ابتدای بخش را فراهم می‌کند:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک پیوند را فقط به بخشی از متن داخل یک پاراگراف اعمال کنم؟**

بله، می‌توانید یک [یک پیوند اختصاص دهید](/slides/fa/cpp/manage-hyperlinks/) به یک بخش مجزا؛ فقط آن قطعه قابل کلیک خواهد بود و نه تمام پاراگراف.

**چگونه ارث‌بری سبک‌ها کار می‌کند: بخش (Portion) چه چیزی را نادیده می‌گیرد و چه چیزی از Paragraph/TextFrame گرفته می‌شود؟**

ویژگی‌های سطح Portion بالاترین ارجاع را دارند. اگر ویژگی‌ای در [Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) دریافت می‌کند؛ اگر در آنجا نیز تنظیم نشده باشد، از [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) یا سبک [theme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/theme/) گرفته می‌شود.

**اگر فونت تعیین‌شده برای یک Portion در ماشین/سرور هدف موجود نباشد چه اتفاقی می‌افتد؟**

[قوانین جایگزینی فونت](/slides/fa/cpp/font-selection-sequence/) اعمال می‌شوند. متن ممکن است دوباره قالب‌بندی شود: معیارها، تقسیم‌شدن واژگان و عرض می‌توانند تغییر کنند و این برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت یا گرادیان پر متن مخصوص به یک Portion را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر شدن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portion/) می‌توانند متفاوت از بخش‌های مجاور باشند.