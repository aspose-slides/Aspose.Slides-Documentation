---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در پایتون
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-net/examine-presentation/
keywords:
- فرمت ارائه
- خصوصیات ارائه
- خصوصیات سند
- دریافت خصوصیات
- خواندن خصوصیات
- تغییر خصوصیات
- اصلاح خصوصیات
- به‌روزرسانی خصوصیات
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- پاورپوینت
- اُپن‌داکیومنت
- ارائه
- پایتون
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌ها را در ارائه‌های پاورپوینت و اُپن‌داکیومنت با استفاده از پایتون بررسی کنید تا بینش‌های سریع‌تر و بررسی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه اطلاعات ارائه در Aspose.Slides را بررسی کنید. توضیح می‌دهد چگونه می‌توان فرمت فعلی یک ارائه را بدون بارگذاری کامل فایل تشخیص داد، خصوصیات سند آن را بخوانید و در صورت نیاز آن خصوصیات را به‌روز کنید.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) تهیه شده‌اند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی فرمت یک ارائه**

قبل از کار با یک ارائه ممکن است بخواهید متوجه شوید که در حال حاضر این ارائه در چه فرمت (PPT، PPTX، ODP و غیره) است.

می‌توانید فرمت یک ارائه را بدون بارگذاری آن بررسی کنید. مثال پایتون زیر را ببینید:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **دریافت خصوصیات ارائه**

این کد پایتون نشان می‌دهد چگونه خصوصیات ارائه (اطلاعات دربارهٔ ارائه) را دریافت کنید:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

ممکن است بخواهید خصوصیات را در کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/#properties) ببینید.

## **به‌روزرسانی خصوصیات ارائه**

Aspose.Slides متد [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) را فراهم می‌کند که به شما امکان می‌دهد تغییراتی در خصوصیات ارائه اعمال کنید.

فرض کنید یک ارائه PowerPoint با خصوصیات سند زیر داریم.

![خصوصیات سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از خصوصیات ارائه را ویرایش کنید:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

نتایج تغییر خصوصیات سند در زیر نشان داده شده است.

![خصوصیات سند تغییر یافتهٔ ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه فقط‑خواندنی است](https://docs.aspose.com/slides/fa/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگذاری دارای رمز عبور است](https://docs.aspose.com/slides/fa/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تایید رمز عبور استفاده‌شده برای حفاظت از یک ارائه](https://docs.aspose.com/slides/fa/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که فونت‌ها جاسازی شده‌اند و کدام‌ها؟**

در سطح ارائه به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) بگردید، سپس آن ورودی‌ها را با مجموعهٔ [فونت‌های واقعی استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) مقایسه کنید تا فونت‌های حیاتی برای رندرینگ شناسایی شوند.

**چگونه می‌توانم سریعاً بفهمم آیا فایل اسلایدهای مخفی دارد و چند تا هستند؟**

از طریق [slide collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) پیمایش کنید و برای هر اسلاید پرچم [visibility](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) آن را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده‌اند و آیا با پیش‌فرض‌ها متفاوت هستند؟**

بله. اندازهٔ فعلی [slide size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slide_size/) و جهت آن را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار هنگام چاپ و خروجی کمک می‌کند.

**آیا راه سریع برای دیدن این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) را مرور کنید، منبع دادهٔ آن‌ها را با [data source](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) بررسی کنید و مشخص کنید آیا داده داخلی است یا بر پایهٔ لینک، از جمله لینک‌های شکسته.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندرینگ یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید تعداد اشیا را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و چندرسانه‌ای‌ها بگردید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط فشار عملکردی محتمل شناسایی شوند.