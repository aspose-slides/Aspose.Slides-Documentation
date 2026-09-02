---
title: بازگردانی و به‌روزرسانی اطلاعات ارائه در جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/java/examine-presentation/
keywords:
- فرمت ارائه
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
- Java
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از جاوا بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری به‌دست آورید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه می‌توان اطلاعات ارائه را در Aspose.Slides بررسی کرد. توضیح می‌دهد چگونه می‌توان فرمت فعلی یک ارائه را بدون بارگذاری کامل فایل تشخیص داد، ویژگی‌های سند آن را خواند و در صورت نیاز این ویژگی‌ها را به‌روزرسانی کرد.

مثال‌ها بر پایه APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/) هستند و عملیات معمولی برای کار با متادیتای ارائه را نشان می‌دهند.

## **بررسی فرمت ارائه**

قبل از کار بر روی یک ارائه، ممکن است بخواهید بفهمید که این ارائه در حال حاضر در چه فرمتی (PPT، PPTX، ODP و غیره) قرار دارد.

می‌توانید فرمت ارائه را بدون بارگذاری آن بررسی کنید. به این کد Java نگاه کنید:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **دریافت ویژگی‌های ارائه**

این کد Java نشان می‌دهد چگونه می‌توان ویژگی‌های ارائه (اطلاعات درباره ارائه) را دریافت کرد:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

ممکن است بخواهید ویژگی‌های موجود در کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#DocumentProperties--) را ببینید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) را فراهم می‌کند که امکان تغییر ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائه PowerPoint با ویژگی‌های سند زیر داریم.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه می‌توان برخی از ویژگی‌های ارائه را ویرایش کرد:

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

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده است.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر درباره یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها برای شما مفید باشند:

- [Password-Protect Presentations](/slides/fa/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها به‌صورت جاسازی شده موجود هستند و کدام‌ها؟**

به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) در سطح ارائه بگردید، سپس آن ورودی‌ها را با مجموعهٔ [قلم‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getFonts--) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم آیا فایل اسلایدهای پنهان دارد و چندتا؟**

از طریق [slide collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/) عبور کنید و پرچم [visibility](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getHidden--) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت سفارشی اسلاید استفاده شده‌اند و آیا با پیش‌فرض‌ها متفاوت هستند؟**

بله. اندازهٔ فعلی [slide size](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideSize--) و جهت آن را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار هنگام چاپ و خروجی کمک می‌کند.

**آیا راهی سریع برای مشاهده این‌که آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/) را پیمایش کنید، منبع دادهٔ آن‌ها را بررسی کنید ([data source](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--)) و ببینید داده داخلی است یا به‌صورت لینک و حتی آیا لینک شکسته است یا نه.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، شمارش اشیاء را انجام دهید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و رسانه‌های چندرسانه‌ای باشید؛ امتیاز پیچیدگی تخمینی بدهید تا نقاط احتمالی کاهش عملکرد را شناسایی کنید.