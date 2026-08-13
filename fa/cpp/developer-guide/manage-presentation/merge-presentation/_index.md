---
title: ادغام کارآمد ارائه‌ها در C++
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/cpp/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- C++
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) را با Aspose.Slides برای C++ ادغام کنید، جریان کاری خود را ساده‌سازی کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با کپی‌برداری از اسلایدها از یک ارائه به ارائهٔ دیگر ترکیب کنید. این مقاله توضیح می‌دهد چگونه کل ارائه‌ها یا اسلایدهای انتخابی را ادغام کنید، در حین ادغام از یک اسلاید مستر یا چینش خاص استفاده کنید، ارائه‌هایی با اندازهٔ اسلایدهای متفاوت را مدیریت کنید و اسلایدهای ادغام شده را به یک بخش از ارائه اضافه کنید. همچنین نکات عملی مرتبط با محتوای ادغام شده، از جمله یادداشت‌های سخنران، نظرات، فایل‌های منبع دارای رمز عبور و استفاده از رشته‌ها را پوشش می‌دهد.

## **ادغام ارائه‌ها**

هنگامی که یک ارائه را به ارائهٔ دیگر ادغام می‌کنید، در واقع اسلایدهای آن‌ها را در یک ارائهٔ واحد ترکیب می‌کنید تا یک فایل به دست آورید.

{{% alert title="Info" color="info" %}}

اکثریت برنامه‌های ارائه (PowerPoint یا OpenOffice) توابعی ندارند که به کاربران اجازهٔ ترکیب ارائه‌ها به این شکل را بدهند.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/fa/cpp/) اما امکان ادغام ارائه‌ها را به روش‌های مختلف فراهم می‌کند. شما می‌توانید ارائه‌ها را به همراه تمام اشکال، سبک‌ها، متون، قالب‌بندی، نظرات، انیمیشن‌ها و غیره ادغام کنید بدون اینکه نگران از دست رفتن کیفیت یا داده‌ها باشید.

**همچنین ببینید**

[Clone Slides](https://docs.aspose.com/slides/fa/cpp/clone-slides/)*.*

{{% /alert %}}

### **چه چیزهایی می‌تواند ادغام شود**

با Aspose.Slides می‌توانید ادغام کنید

* کل ارائه‌ها. تمام اسلایدهای ارائه‌ها در یک ارائه پایان می‌یابند
* اسلایدهای خاص. اسلایدهای انتخابی در یک ارائه پایان می‌یابند
* ارائه‌ها در یک قالب (PPT به PPT، PPTX به PPTX، و غیره) و در قالب‌های مختلف (PPT به PPTX، PPTX به ODP، و غیره) به یکدیگر.

{{% alert title="Note" color="warning" %}}

به‌جز ارائه‌ها، Aspose.Slides امکان ادغام فایل‌های دیگر را نیز می‌دهد:

* [تصاویر](https://products.aspose.com/slides/fa/cpp/merger/image-to-image/)، مانند [JPG به JPG](https://products.aspose.com/slides/fa/cpp/merger/jpg-to-jpg/) یا [PNG به PNG](https://products.aspose.com/slides/fa/cpp/merger/png-to-png/)
* اسناد، مانند [PDF به PDF](https://products.aspose.com/slides/fa/cpp/merger/pdf-to-pdf/) یا [HTML به HTML](https://products.aspose.com/slides/fa/cpp/merger/html-to-html/)
* و دو فایل متفاوت مانند [image به PDF](https://products.aspose.com/slides/fa/cpp/merger/image-to-pdf/) یا [JPG به PDF](https://products.aspose.com/slides/fa/cpp/merger/jpg-to-pdf/) یا [TIFF به PDF](https://products.aspose.com/slides/fa/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **گزینه‌های ادغام**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کنند آیا

* هر اسلاید در ارائهٔ خروجی سبک منحصر به‌فرد خود را حفظ کند
* یک سبک خاص برای تمام اسلایدهای ارائهٔ خروجی استفاده شود.

برای ادغام ارائه‌ها، Aspose.Slides روش‌های [AddClone](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) را (از رابط [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection)) فراهم می‌کند. چندین پیاده‌سازی از متدهای `AddClone` وجود دارد که پارامترهای فرآیند ادغام ارائه را تعریف می‌کند. هر شیء Presentation دارای مجموعهٔ [Slides](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) است، بنابراین می‌توانید متد `AddClone` را از ارائه‌ای که می‌خواهید اسلایدها به آن اضافه شوند فراخوانی کنید.

متد `AddClone` یک شیء `ISlide` برمی‌گرداند که کپی‌ای از اسلاید منبع است. اسلایدهای یک ارائهٔ خروجی به سادگی نسخه‌ای از اسلایدهای منبع هستند. بنابراین می‌توانید تغییرات لازم را روی اسلایدهای حاصل (مثلاً اعمال سبک یا گزینه‌های قالب‌بندی یا چینش) اعمال کنید بدون این‌که نگران تأثیر بر ارائه‌های منبع باشید.

## **ادغام ارائه‌ها**

Aspose.Slides متد [**AddClone (ISlide)**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که اسلایدها چینش و سبک‌های خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد C++ نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ادغام ارائه‌ها با اسلاید مستر**

Aspose.Slides متد [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که یک قالب اسلاید مستر به آن‌ها اعمال می‌شود. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائهٔ خروجی را تغییر دهید.

این کد C++ عملیات توضیح داده شده را نشان می‌دهد:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}}

چینش اسلاید برای اسلاید مستر به‌طور خودکار تعیین می‌شود. هنگامی که یک چینش مناسب قابل تعیین نباشد، اگر پارامتر بولی `allowCloneMissingLayout` متد `AddClone` برابر با true تنظیم شده باشد، چینش اسلاید منبع استفاده می‌شود. در غیر این صورت، [PptxEditException](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) پرتاب خواهد شد.

{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائهٔ خروجی چینش متفاوتی داشته باشند، به‌جای آن هنگام ادغام از متد [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) استفاده کنید.

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد مجموعه اسلایدهای سفارشی مفید است. Aspose.Slides C++ به شما اجازه می‌دهد تنها اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، چینش و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد C++ زیر یک ارائهٔ جدید می‌سازد، اسلایدهای عنوان را از دو ارائهٔ دیگر اضافه می‌کند و نتیجه را در یک فایل ذخیره می‌نماید:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// در کد بالا اعلان شده است.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

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

## **ادغام ارائه‌ها با یک چینش اسلاید**

این کد C++ نشان می‌دهد چگونه اسلایدها را از ارائه‌ها ترکیب کنید در حالی که چینش دلخواه خود را بر روی آن‌ها اعمال کنید تا یک ارائهٔ خروجی به دست آید:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

{{% alert title="Note" color="warning" %}}

نمی‌توانید ارائه‌هایی با اندازه‌های اسلاید متفاوت را ادغام کنید.

{{% /alert %}}

برای ادغام ۲ ارائه با اندازه‌های اسلاید متفاوت، باید یکی از ارائه‌ها را تغییر اندازه دهید تا اندازهٔ آن با ارائهٔ دیگر مطابقت داشته باشد.

این کد نمونه عملیات توضیح داده شده را نشان می‌دهد:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

این کد C++ نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه اضافه کنید:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

{{% alert title="Tip" color="info" %}}

Aspose یک برنامه وب FREE Collage ارائه می‌دهد ([https://products.aspose.app/slides/fa/collage](https://products.aspose.app/slides/fa/collage)). با استفاده از این سرویس آنلاین می‌توانید [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG، گریدهای عکس ([photo grids](https://products.aspose.app/slides/fa/collage/photo-grid)) و موارد دیگر را ترکیب کنید.

{{% /alert %}}

## **سوالات متداول**

### آیا یادداشت‌های سخنران هنگام ادغام حفظ می‌شوند؟

بله. هنگام کپی‌برداری از اسلایدها، Aspose.Slides تمام عناصر اسلاید از جمله یادداشت‌ها، قالب‌بندی و انیمیشن‌ها را انتقال می‌دهد.

### آیا نظرات و نویسندگان آن‌ها منتقل می‌شوند؟

نظرات به‌عنوان بخشی از محتوای اسلاید کپی می‌شوند. برچسب‌های نویسندهٔ نظر به‌عنوان اشیاء نظر در ارائهٔ حاصل حفظ می‌شوند.

### اگر ارائهٔ منبع دارای رمز عبور باشد چه می‌شود؟

باید با استفاده از [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) و [باز کردن با رمز عبور](/slides/fa/cpp/password-protected-presentation/) باز شود؛ پس از بارگذاری، آن اسلایدها می‌توانند به‌صورت ایمن به یک فایل هدف بدون رمز یا حتی فایل هدف دارای رمز کپی شوند.

### عملیات ادغام تا چه اندازه‌ای ایمن برای استفاده در چند رشته است؟

از همان شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) در [چندین رشته](/slides/fa/cpp/multithreading/) استفاده نکنید. قانون پیشنهادی این است: «یک سند — یک رشته»؛ فایل‌های مختلف می‌توانند به‌صورت موازی در رشته‌های جداگانه پردازش شوند.