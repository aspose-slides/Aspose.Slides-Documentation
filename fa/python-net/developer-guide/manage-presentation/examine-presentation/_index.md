---
title: دریافت و به‌روزرسانی اطلاعات ارائه در پایتون
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-net/examine-presentation/
keywords:
- قالب ارائه
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
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌ها را در ارائه‌های PowerPoint و OpenDocument با استفاده از پایتون بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندتر به‌دست آید."
---
## **بررسی کلی**

این مقاله نحوه بررسی اطلاعات ارائه در Aspose.Slides را نشان می‌دهد. توضیح می‌دهد چگونه می‌توان قالب فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کرد، خصوصیات سند آن را بخوانید و در صورت نیاز آن خصوصیات را به‌روزرسانی کنید.

نمونه‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) ساخته شده‌اند و عملیات معمول کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید بدانید در حال حاضر قالب آن (PPT، PPTX، ODP و غیره) چیست.

می‌توانید قالب یک ارائه را بدون بارگذاری آن بررسی کنید. مثال پایتون زیر را ببینید:

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

ممکن است بخواهید [خصوصیات را در کلاس DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/#properties) مشاهده کنید.

## **به‌روزرسانی خصوصیات ارائه**

Aspose.Slides متد [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) را فراهم می‌کند که به شما امکان می‌دهد تغییراتی در خصوصیات ارائه اعمال کنید.

فرض کنید یک ارائه PowerPoint داریم که خصوصیات سند آن به شکل زیر نمایش داده شده است.

![ویژگی‌های اصلی سند ارائهٔ پاورپوینت](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از خصوصیات ارائه را ویرایش کنید:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

نتایج تغییر خصوصیات سند در زیر نشان داده شده است.

![ویژگی‌های تغییر یافتهٔ سند ارائهٔ پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها برای شما مفید باشند:

- [Password-Protect Presentations](/slides/fa/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/python-net/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا فونت‌ها تعبیه شده‌اند و کدام‌ها هستند؟**

به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) در سطح ارائه بگردید، سپس این ورودی‌ها را با مجموعهٔ [فونت‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) مقایسه کنید تا شناسایی کنید کدام فونت‌ها برای رندرینگ حیاتی هستند.

**چگونه می‌توانم سریعاً بفهمم فایل اسلایدهای مخفی دارد و چند تا هستند؟**

در [slide collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) پیمایش کنید و برای هر اسلاید پرچم [visibility flag](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) آن را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده است و آیا از پیش‌فرض‌ها متفاوت است؟**

بله. اندازهٔ فعلی [slide size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slide_size/) و جهت آن را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی‌گیری کمک می‌کند.

**آیا راهی سریع برای دیدن این که نمودارها به منابع دادهٔ خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) را مرور کنید، منبع دادهٔ آن‌ها را بررسی کنید ([data source](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/)) و مشخص کنید آیا داده‌ها داخلی هستند یا مبتنی بر لینک، از جمله هر لینک شکسته‌ای.

**چگونه می‌توانم «اسلایدهای سنگین» که ممکن است رندرینگ یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و رسانه‌های چندرسانه‌ای بگردید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط فشار عملکردی محتمل را برجسته کنید.