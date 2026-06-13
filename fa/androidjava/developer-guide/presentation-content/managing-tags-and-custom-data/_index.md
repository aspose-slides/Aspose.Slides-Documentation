---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها در اندروید
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/androidjava/managing-tags-and-custom-data
keywords:
- خصوصیات سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- مقادیر جفتی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "افزودن، خواندن، به‌روزرسانی و حذف برچسب‌ها و داده‌های سفارشی در Aspose.Slides برای اندروید، همراه با مثال‌های Java برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌طور خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX را بیان می‌کند، ذکر می‌کند که داده‌های خاص ارائه می‌توانند به‌صورت برچسب‌ها و قسمت‌های XML سفارشی وجود داشته باشند، و برچسب‌ها را به‌عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند.

همچنین نشان می‌دهد چگونه مقادیر برچسب را بخوانید و چگونه برچسب‌ها را به یک ارائه، یک اسلاید منفرد یا یک شکل اضافه کنید. علاوه بر این، مقاله وظایف متداول مدیریت برچسب مانند پاک‌سازی تمام برچسب‌ها، حذف یک برچسب بر اساس نام، و بازیابی لیست نام‌های برچسب را پوشش می‌دهد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—آیتم‌هایی با پسوند .pptx—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

بایک *اسلاید* به‌عنوان یکی از عناصر ارائه‌ها، یک *بخش اسلاید* شامل محتوای یک اسلاید واحد است. یک بخش اسلاید می‌تواند روابط صریح به بخش‌های متعدد—مانند برچسب‌های تعریف‌شده توسط کاربر—که توسط ISO/IEC 29500 تعریف شده‌اند داشته باشد.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITagCollection)) و قسمت‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection)) موجود باشند.

{{% alert color="primary" %}} 
برچسب‌ها در اصل مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل متدهای [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) و [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Android از طریق Java برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) دریافت کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً از دو مورد تشکیل شده است:

- نام ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز دارید برخی از ارائه‌ها را بر اساس یک قانون یا ویژگی خاص دسته‌بندی کنید، افزودن برچسب‌ها می‌تواند مفید باشد. برای مثال، اگر می‌خواهید تمام ارائه‌های کشورهای آمریکای شمالی را با هم گروه‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کنید و سپس کشورهای مرتبط (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر تعیین کنید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) با استفاده از Aspose.Slides برای Android از طریق Java اضافه کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) تنظیم شوند:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

یا هر [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) فردی:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **محدودیت‌ها**

برچسب‌های اضافه‌شده از طریق مجموعه برچسب داده سفارشی با استفاده از `getCustomData().getTags()` فقط در داخل فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. در نتیجه، شناسه سفارشی که به عنوان برچسب اختصاص داده شده است نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه حل**: می‌توانید شناسه سفارشی را در **متن جایگزین** شیء (مثلاً `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از صادرات به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **سوالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یکجا حذف می‌کند.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از عملیات [remove(name)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) روی [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید آن حذف کنید.

**چگونه می‌توانم لیست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلترگیری دریافت کنم؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) بر روی [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.