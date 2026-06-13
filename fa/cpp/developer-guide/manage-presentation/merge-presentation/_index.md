---
title: ترکیب کارآمد ارائه‌ها در C++
linktitle: ترکیب ارائه‌ها
type: docs
weight: 40
url: /fa/cpp/merge-presentation/
keywords:
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- C++
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) را با Aspose.Slides برای C++ ترکیب کنید و جریان کار خود را بهبود بخشید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با کلون کردن اسلایدها از یک ارائه به ارائه دیگر ادغام کنید. این مقاله توضیح می‌دهد چگونه می‌توانید کل ارائه‌ها یا اسلایدهای منتخب را ادغام کنید، در حین ادغام از یک اسلاید مستر یا طرح‌بندی خاص استفاده کنید، با ارائه‌های دارای اندازه اسلاید متفاوت برخورد کنید و اسلایدهای ادغام‌شده را به یک بخش از ارائه اضافه کنید. همچنین نکات عملی مربوط به محتویات ادغام‌شده شامل یادداشت‌های سخنران، نظرات، فایل‌های منبع محافظت‌شده با رمز عبور و استفاده از رشته‌ها را پوشش می‌دهد.

## **ادغام ارائه‌ها**

وقتی یک ارائه را به ارائه دیگر ادغام می‌کنید، عملاً اسلایدهای آن‌ها را در یک ارائه ترکیب می‌کنید تا یک فایل به دست آورید.

{{% alert title="اطلاعات" color="info" %}}

اکثریت برنامه‌های ارائه (PowerPoint یا OpenOffice) عملکردی برای ترکیب ارائه‌ها به این شکل ندارند.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/fa/cpp/)، اما به شما امکان می‌دهد ارائه‌ها را به روش‌های مختلف ادغام کنید. می‌توانید ارائه‌ها را با تمام اشکال، سبک‌ها، متن‌ها، قالب‌بندی، نظرات، انیمیشن‌ها و غیره ادغام کنید بدون اینکه نگران از دست رفتن کیفیت یا داده‌ها باشید.

**همچنین ببینید**

[Clone Slides](https://docs.aspose.com/slides/fa/cpp/clone-slides/)*.*

{{% /alert %}}

### **چه چیزهایی می‌توان ادغام کرد**

با Aspose.Slides می‌توانید

* کل ارائه‌ها را ادغام کنید. تمام اسلایدهای ارائه‌ها در یک ارائه جمع می‌شوند
* اسلایدهای خاصی را ادغام کنید. اسلایدهای انتخاب‌شده در یک ارائه قرار می‌گیرند
* ارائه‌ها را در یک قالب (PPT به PPT، PPTX به PPTX و غیره) و در قالب‌های مختلف (PPT به PPTX، PPTX به ODP و غیره) به یکدیگر متصل کنید.

{{% alert title="تذکر" color="warning" %}} 

علاوه بر ارائه‌ها، Aspose.Slides به شما امکان می‌دهد سایر فایل‌ها را نیز ادغام کنید:

* [Images](https://products.aspose.com/slides/fa/cpp/merger/image-to-image/)، مانند [JPG to JPG](https://products.aspose.com/slides/fa/cpp/merger/jpg-to-jpg/) یا [PNG to PNG](https://products.aspose.com/slides/fa/cpp/merger/png-to-png/)
* اسناد، مانند [PDF to PDF](https://products.aspose.com/slides/fa/cpp/merger/pdf-to-pdf/) یا [HTML to HTML](https://products.aspose.com/slides/fa/cpp/merger/html-to-html/)
* و دو فایل متفاوت مانند [image to PDF](https://products.aspose.com/slides/fa/cpp/merger/image-to-pdf/) یا [JPG to PDF](https://products.aspose.com/slides/fa/cpp/merger/jpg-to-pdf/) یا [TIFF to PDF](https://products.aspose.com/slides/fa/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **گزینه‌های ادغام**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کند

* هر اسلاید در ارائه خروجی یک سبک منحصربه‌فرد داشته باشد
* یک سبک مشخص برای تمام اسلایدهای ارائه خروجی استفاده شود.

برای ادغام ارائه‌ها، Aspose.Slides متدهای [AddClone](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) را (از رابط [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection)) ارائه می‌دهد. چندین پیاده‌سازی از متدهای `AddClone` وجود دارد که پارامترهای فرآیند ادغام ارائه را تعریف می‌کند. هر شیء Presentation دارای مجموعه‌ای به نام [Slides](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) است، بنابراین می‌توانید یک متد `AddClone` را از ارائه‌ای که می‌خواهید اسلایدها به آن اضافه شوند، فراخوانی کنید.

متد `AddClone` یک شیء `ISlide` را برمی‌گرداند که یک کلون از اسلاید منبع است. اسلایدهای موجود در ارائه خروجی به سادگی نسخه‌ای از اسلایدهای منبع هستند. بنابراین می‌توانید اسلایدهای حاصل را (مثلاً اعمال سبک‌ها یا گزینه‌های قالب‌بندی یا طرح‌ها) بدون نگرانی از تأثیر بر ارائه‌های منبع، تغییر دهید.

## **ادغام ارائه‌ها**

Aspose.Slides متد [**AddClone (ISlide)**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) را فراهم می‌کند که اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که اسلایدها طرح‌بندی و سبک‌های خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد C++ نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ادغام ارائه‌ها با یک اسلاید مستر**

Aspose.Slides متد [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) را فراهم می‌کند که اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که یک الگو (تم) اسلاید مستر اعمال می‌شود. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

این کد C++ عمل شرح‌داده‌شده را نشان می‌دهد:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="تذکر" color="warning" %}} 

طرح‌بندی اسلاید برای اسلاید مستر به‌صورت خودکار تعیین می‌شود. وقتی طرح‌بندی مناسب پیدا نشود، اگر پارامتر بولی `allowCloneMissingLayout` متد `AddClone` برابر `true` باشد، از طرح‌بندی اسلاید منبع استفاده می‌شود. در غیر این صورت، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) پرتاب خواهد شد.

{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائه خروجی دارای طرح‌بندی متفاوتی باشند، به‌جای آن هنگام ادغام از متد [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) استفاده کنید.

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد مجموعه اسلایدهای سفارشی مفید است. Aspose.Slides C++ به شما امکان می‌دهد فقط اسلایدهایی که نیاز دارید را انتخاب و وارد کنید. API قالب‌بندی، طرح‌بندی و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد C++ زیر یک ارائه جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌نماید:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **ادغام ارائه‌ها با یک طرح‌بندی اسلاید**

این کد C++ نشان می‌دهد چگونه اسلایدها را از ارائه‌ها ترکیب کنید در حالی که طرح‌بندی دلخواه خود را برای آنها اعمال کنید تا یک ارائه خروجی به‌دست آورید:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

{{% alert title="تذکر" color="warning" %}} 

شما نمی‌توانید ارائه‌ها با اندازه‌های اسلاید متفاوت را ادغام کنید.

{{% /alert %}}

برای ادغام 2 ارائه با اندازه اسلاید متفاوت، باید یکی از ارائه‌ها را تغییر اندازه دهید تا اندازه‌ آن با ارائه دیگر برابر شود.

این نمونه کد عملیات شرح‌داده‌شده را نشان می‌دهد:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ادغام اسلایدها به یک بخش از ارائه**

این کد C++ نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه ادغام کنید:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

اسلاید در انتهای بخش اضافه می‌شود.

{{% alert title="نکته" color="primary" %}}

Aspose یک برنامه وب FREE Collage را ارائه می‌دهد ([https://products.aspose.app/slides/fa/collage](https://products.aspose.app/slides/fa/collage)). با استفاده از این سرویس آنلاین می‌توانید [JPG to JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و غیره.

{{% /alert %}}

## **سوالات متداول**

**آیا یادداشت‌های سخنران هنگام ادغام حفظ می‌شوند؟**

بله. هنگام کلون کردن اسلایدها، Aspose.Slides همه عناصر اسلاید، از جمله یادداشت‌ها، قالب‌بندی و انیمیشن‌ها را منتقل می‌کند.

**آیا نظرات و نویسندگان آن‌ها منتقل می‌شوند؟**

نظرات، به عنوان بخشی از محتوای اسلاید، همراه با اسلاید کپی می‌شوند. برچسب‌های نویسنده نظرات به‌عنوان اشیاء نظر در ارائه حاصل حفظ می‌شوند.

**اگر ارائه منبع با رمز عبور محافظت شده باشد چه می‌شود؟**

باید با استفاده از [گزینه‌های بارگذاری](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) و متد `LoadOptions::set_Password` باز شود (لینک: /slides/fa/cpp/password-protected-presentation/). پس از بارگذاری، آن اسلایدها می‌توانند به‌صورت ایمن به یک فایل هدف بدون محافظت (یا حتی محافظت‌شده) کلون شوند.

**عملیات ادغام تا چه اندازه ایمن نسبت به رشته‌ها است؟**

از همان شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) در [چندین رشته](https://products.aspose.com/slides/fa/cpp/multithreading/) استفاده نکنید. قانون پیشنهادی این است: «یک سند — یک رشته»؛ فایل‌های مختلف می‌توانند به‌صورت موازی در رشته‌های جداگانه پردازش شوند.