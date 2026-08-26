---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در C++
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/cpp/examine-presentation/
keywords:
- قالب ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌ها را در ارائه‌های PowerPoint و OpenDocument با استفاده از C++ بررسی کنید تا به بینش‌های سریعتر و ارزیابی‌های هوشمندانه‌تر محتوا دست یابید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه اطلاعات ارائه را در Aspose.Slides بررسی کنیم. این مقاله توضیح می‌دهد چگونه فرمت فعلی یک ارائه را بدون بارگذاری کل فایل تعیین کنیم، ویژگی‌های سند آن را بخوانیم و در صورت نیاز آن ویژگی‌ها را به‌روزرسانی کنیم.

نمونه‌ها بر پایه APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب ارائه**

قبل از کار بر روی یک ارائه، ممکن است بخواهید بدانید که نمای فعلی آن در چه قالبی (PPT، PPTX، ODP و غیره) ذخیره شده است.

می‌توانید قالب ارائه را بدون بارگذاری آن بررسی کنید. کد C++ زیر را ببینید:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **دریافت ویژگی‌های ارائه**

این کد C++ نشان می‌دهد چگونه ویژگی‌های ارائه (اطلاعات دربارهٔ ارائه) را دریافت کنیم:

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) را فراهم می‌کند که امکان اعمال تغییرات بر ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائه‌ی PowerPoint داریم که ویژگی‌های سند آن به‌صورت زیر نشان داده شده‌اند.

![ویژگی‌های سند اصلی ارائهٔ PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از ویژگی‌های ارائه را ویرایش کنیم:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده‌اند.

![ویژگی‌های سند تغییر یافتهٔ ارائهٔ PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این پیوندها برای شما مفید باشند:

- [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/cpp/password-protected-presentation/)
- [ارائه‌های محافظت‌شده در مقابل نوشتن](/slides/fa/cpp/write-protected-presentation/)

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها؟**

به دنبال [اطلاعات قلم‌های جاسازی‌شده](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه بگردید، سپس آن ورودی‌ها را با مجموعهٔ [قلم‌های واقعاً مورد استفاده در محتوا](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

در [کلکسیون اسلایدها](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/) پیمایش کنید و پرچم [پرچم قابلیت مشاهده](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/get_hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. [اندازه و جهت اسلاید](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slidesize/) فعلی را با تنظیمات پیش‌فرض مقایسه کنید؛ این کار به پیشبینی رفتار در چاپ و خروجی کمک می‌کند.

**آیا راهی سریع برای دیدن اینکه نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [نمودارها](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/) را مرور کنید، منبع [داده](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) آن‌ها را بررسی کنید و توجه داشته باشید که داده داخلی است یا مبتنی بر لینک، شامل هر لینک خراب.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند، ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را شمارش کنید و به‌دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و محتویات چندرسانه‌ای بگردید؛ امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط دردسر عملکردی احتمالی را نشان دهد.