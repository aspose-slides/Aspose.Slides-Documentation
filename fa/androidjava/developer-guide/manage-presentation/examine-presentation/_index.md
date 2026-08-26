---
title: دریافت و به‌روزرسانی اطلاعات ارائه در Android
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "کاوش اسلایدها، ساختار و متادیتا در ارائه‌های PowerPoint و OpenDocument با استفاده از Java برای دریافت سریع‌تر بینش‌ها و ارزیابی هوشمند محتوا."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه می‌توان اطلاعات ارائه را در Aspose.Slides بررسی کرد. توضیح می‌دهد چطور می‌توان قالب فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کرد، خصوصیات سند آن را خواند و در صورت نیاز این خصوصیات را به‌روزرسانی کرد.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/documentproperties/) هستند و عملیات معمول کار با متادیتای ارائه را نشان می‌دهند.

## **بررسی قالب یک ارائه**

قبل از کار با یک ارائه ممکن است بخواهید بفهمید قالب (PPT، PPTX، ODP و ...) در حال حاضر چیست.

می‌توانید قالب ارائه را بدون بارگذاری آن بررسی کنید. به این کد Java نگاه کنید:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **دریافت خصوصیات ارائه**

این کد Java نشان می‌دهد چگونه می‌توان خصوصیات ارائه (اطلاعات دربارهٔ ارائه) را به‌دست آورد:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ادامه
```

ممکن است بخواهید به [خصوصیات موجود در کلاس DocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) نگاهی بیندازید.

## **به‌روزرسانی خصوصیات ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) را ارائه می‌دهد که امکان تغییر خصوصیات ارائه را فراهم می‌کند.

فرض کنید یک ارائه PowerPoint داریم که خصوصیات سند آن به‌صورت زیر نشان داده شده است.

![خصوصیات سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از خصوصیات ارائه را ویرایش کنیم:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

نتایج تغییر خصوصیات سند در زیر نشان داده شده‌اند.

![خصوصیات سند تغییر یافتهٔ ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها برای شما مفید باشند:

- [رمزگذاری ارائه‌ها](/slides/fa/androidjava/password-protected-presentation/)
- [قفل‌گذاری نوشتاری ارائه‌ها](/slides/fa/androidjava/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌یک هستند؟**

به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) در سطح ارائه بگردید، سپس آن ورودی‌ها را با مجموعهٔ [قلم‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#getFonts--) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به سرعت بگویم فایل اسلایدهای مخفی دارد و چندتا هستند؟**

از طریق [slide collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/) پیمایش کنید و پرچم [visibility](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#getHidden--) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده است و آیا متفاوت از مقدار پیش‌فرض هستند؟**

بله. اندازهٔ فعلی [slide size](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideSize--) و جهت آن را با پیش‌تنظیم‌های استاندارد مقایسه کنید؛ این به پیش‌بینی رفتار برای چاپ و خروجی کمک می‌کند.

**آیا راه سریعی برای دیدن این‌که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/) را عبور دهید، منبع دادهٔ آن‌ها را بررسی کنید ([data source](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)) و توجه کنید که داده داخلی است یا بر پایهٔ لینک، شامل هر لینکی که خراب باشد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیا را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و مولتی‌مدیا باشید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط بحرانی عملکرد را علامت‌گذاری کنید.