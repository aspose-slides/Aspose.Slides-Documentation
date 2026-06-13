---
title: تغییر اندازه اشکال در اسلایدهای ارائه
type: docs
weight: 100
url: /fa/cpp/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای C++ تغییر اندازه دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مروری کلی**

یکی از رایج‌ترین سوالاتی که مشتریان Aspose.Slides برای C++ می‌پرسند این است که چگونه شکل‌ها را طوری تغییر اندازه دهند که هنگام تغییر اندازه اسلاید، داده‌ها بریده نشوند. این مقالهٔ فنی کوتاه نحوهٔ انجام این کار را نشان می‌دهد.

## **تغییر اندازه شکل‌ها**

برای جلوگیری از عدم تراز شدن شکل‌ها هنگام تغییر اندازهٔ اسلاید، موقعیت و ابعاد هر شکل را به‌گونه‌ای به‌روزرسانی کنید که با طرح جدید اسلاید سازگار باشد.

```cpp
// بارگذاری فایل ارائه.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// دریافت اندازهٔ اصلی اسلاید.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغییر اندازهٔ اسلاید بدون مقیاس‌بندی اشکال موجود.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// دریافت اندازهٔ جدید اسلاید.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// تغییر اندازه و تغییر موقعیت اشکال در هر اسلاید.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // مقیاس‌بندی اندازهٔ شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
اگر اسلاید شامل جدول باشد، کد بالا به‌درستی کار نخواهد کرد. در این صورت، باید هر سلول جدول را جداگانه تغییر اندازه دهید.
{{% /alert %}} 

از کد زیر در پروژهٔ خود برای تغییر اندازهٔ اسلایدهای حاوی جدول استفاده کنید. برای جداول، تنظیم عرض یا ارتفاع یک حالت خاص است: باید ارتفاع ردیف‌ها و عرض ستون‌ها را به‌صورت جداگانه تنظیم کنید تا اندازهٔ کلی جدول تغییر کند.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// دریافت اندازهٔ اصلی اسلاید.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغییر اندازهٔ اسلاید بدون مقیاس‌بندی اشکال موجود.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// دریافت اندازهٔ جدید اسلاید.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // مقیاس‌بندی اندازهٔ شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // مقیاس‌بندی اندازهٔ شکل.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // مقیاس‌بندی موقعیت شکل.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // مقیاس‌بندی اندازهٔ شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**چرا پس از تغییر اندازهٔ اسلاید، شکل‌ها دچار انحراف یا قطع می‌شوند؟**  
هنگام تغییر اندازهٔ اسلاید، شکل‌ها موقعیت و اندازهٔ اولیهٔ خود را حفظ می‌کنند مگر این که مقیاس به‌طور صریح تغییر داده شود. این می‌تواند منجر به برش محتوا یا عدم تراز شدن شکل‌ها شود.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**  
مثال پایه برای اکثر انواع شکل‌ها (جعبه‌های متن، تصاویر، نمودارها و غیره) کار می‌کند. اما برای جداول، باید ردیف‌ها و ستون‌ها را جداگانه مدیریت کنید، زیرا ارتفاع و عرض جدول توسط ابعاد سلول‌های تک‌تکه تعیین می‌شود.

**چگونه هنگام تغییر اندازهٔ اسلاید، جداول را تغییر اندازه دهم؟**  
باید تمام ردیف‌ها و ستون‌های جدول را پیمایش کنید و ارتفاع و عرض آن‌ها را به‌صورت نسبت‌مند تغییر اندازه دهید، همان‌طور که در مثال دوم کد نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای اصلی (Master) و اسلایدهای طرح‌بندی (Layout) نیز کار می‌کند؟**  
بله، اما همچنین باید از طریق [Masters](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/) و [Layout slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_layoutslides/) حلقه بزنید و منطق مقیاس‌بندی یکسان را بر شکل‌های آن‌ها اعمال کنید تا سازگاری در سراسر ارائه حفظ شود.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکیپ) را همراه با تغییر اندازه تغییر دهم؟**  
بله. می‌توانید از [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/set_orientation/) برای تغییر جهت استفاده کنید. مطمئن شوید منطق مقیاس‌بندی را متناسب تنظیم کنید تا طرح حفظ شود.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**  
Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارد.

**چگونه می‌توانم از تغییر شکل اشکال با نسبت ابعاد ثابت جلوگیری کنم؟**  
قبل از مقیاس‌بندی می‌توانید متد `get_AspectRatioLocked` شکل را بررسی کنید. اگر قفل شده باشد، به‌جای مقیاس‌بندی جداگانهٔ عرض و ارتفاع، عرض یا ارتفاع را به‌صورت نسبت‌مند تنظیم کنید.