---
title: دریافت مرزهای بخش متن از ارائه‌ها در C++
linktitle: مرزهای بخش
type: docs
weight: 47
url: /fa/cpp/portion-bounds/
keywords:
- مرزهای بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای بخش متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++ بازیابی کنید."
---
## **بررسی کلی**

یک بخش متن نمایانگر یک تکه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد تا به‌طور مستقل از محتوای اطراف با آن تکه کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت محدوده یک تکه متن، اعمال قالب‌بندی فقط بر روی بخشی از پاراگراف، یا کنترل رفتار متن در سطح جزئی‌تر داشته باشید.  
این مقاله نشان می‌دهد چگونه می‌توان مستطیل محدودکننده یک بخش را با استفاده از [IPortion::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/getrect/) به دست آورد. همچنین نحوه دریافت مختصات ابتدای یک بخش را با استفاده از [IPortion::GetCoordinates](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/getcoordinates/) نشان می‌دهد. علاوه بر این، سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، از جمله اعمال یک لینک به یک تکه متن واحد، درک چگونگی حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و وراثت تم، و رسیدگی به مواردی که یک فونت مشخص موجود نیست.

## **دریافت مرزهای یک بخش متن**

از [IPortion::GetRect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/getrect/) برای دریافت مستطیل محدودکننده یک بخش متن استفاده کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **دریافت مختصات یک بخش متن**

از [IPortion::GetCoordinates](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/getcoordinates/) برای دریافت مختصات ابتدای یک بخش متن استفاده کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **پرسش‌های متداول**

**آیا می‌توانم فقط به بخشی از متن در یک پاراگراف یک پیوند اضافه کنم؟**

بله، می‌توانید [اختصاص یک پیوند](/slides/fa/cpp/manage-hyperlinks/) را به یک بخش فردی اعمال کنید؛ فقط آن تکه قابل کلیک خواهد بود، نه تمام پاراگراف.

**وراثت سبک چگونه کار می‌کند: بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

خصوصیات در سطح بخش بالاترین اولویت را دارند. اگر یک خصوصیت در [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) تنظیم نشده باشد، Aspose.Slides آن را از [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) دریافت می‌کند. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) یا [theme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/theme/) استفاده می‌کند.

**اگر فونت مشخص‌شده برای یک بخش در دستگاه یا سرور هدف موجود نباشد چه می‌شود؟**

[قواعد جایگزینی فونت](/slides/fa/cpp/font-selection-sequence/) اعمال می‌شوند. ممکن است متن دوباره جریان یابد: معیارها، هایفن‌گذاری و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت پر متن یا گرادیان مخصوص به بخش را به‌طور مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر و شفافیت در سطح [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) می‌تواند با تکه‌های همسایه متفاوت باشد.