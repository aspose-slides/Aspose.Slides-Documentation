---
title: دریافت و به‌روزرسانی اطلاعات ارائه در جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/java/examine-presentation/
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
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "کاوش اسلایدها، ساختار و فراداده‌ها در ارائه‌های PowerPoint و OpenDocument با استفاده از Java برای دریافت سریع‌تر بینش‌ها و ارزیابی‌های هوشمند محتوا."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه اطلاعات ارائه را در Aspose.Slides بررسی کنید. توضیح می‌دهد که چگونه فرمت فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کنید، خصوصیات سند آن را بخوانید و در صورت نیاز این خصوصیات را به‌روز کنید.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/) ساخته شده‌اند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی فرمت ارائه**

قبل از کار روی یک ارائه، ممکن است بخواهید فرمت (PPT، PPTX، ODP و ...) که ارائه در حال حاضر دارد را بیابید.

می‌توانید فرمت یک ارائه را بدون بارگذاری آن بررسی کنید. به این کد جاوا مراجعه کنید:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **دریافت خصوصیات ارائه**

این کد جاوا نشان می‌دهد که چگونه خصوصیات ارائه (اطلاعات دربارهٔ ارائه) را دریافت کنید:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

ممکن است بخواهید [خصوصیات زیر کلاس DocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#DocumentProperties--) را ببینید.

## **به‌روزرسانی خصوصیات ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) را فراهم می‌کند که به شما امکان می‌دهد تغییراتی در خصوصیات ارائه اعمال کنید.

فرض کنید یک ارائه PowerPoint با خصوصیات سند زیر داریم.

![خصوصیات سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد که چگونه برخی از خصوصیات ارائه را ویرایش کنید:

```java
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

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه محافظت‌شده از نوشتن (فقط-خواندنی) است](https://docs.aspose.com/slides/fa/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگذاری با رمز عبور محافظت شده است](https://docs.aspose.com/slides/fa/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأیید رمز عبوری که برای محافظت از یک ارائه استفاده شده است](https://docs.aspose.com/slides/fa/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام یک هستند؟**

در سطح ارائه به دنبال [اطلاعات قلم‌های جاسازی‌شده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) بگردید، سپس آن ورودی‌ها را با مجموعهٔ [قلم‌های واقعی مورد استفاده در محتوا](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getFonts--) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به‌سرعت بفهمم که آیا فایل اسلایدهای مخفی دارد و چه تعداد؟**

از طریق [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/) مرور کنید و پرچم [قابلیت نمایش](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getHidden--) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت‌گیری اسلاید سفارشی استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. اندازهٔ فعلی [اسلاید](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideSize--) و جهت‌گیری آن را با تنظیمات پیش‌فرض مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی کمک می‌کند.

**آیا راه سریع برای بررسی این که آیا نمودارها به منابع دادهٔ خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [نمودارها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/) را پیمایش کنید، منبع دادهٔ آن‌ها را بررسی کنید و تعیین کنید که داده داخلی است یا بر پایهٔ لینک، شامل هر لینک شکسته‌ای.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و چندرسانه‌ای بگردید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط دشوار عملکرد را شناسایی کنید.