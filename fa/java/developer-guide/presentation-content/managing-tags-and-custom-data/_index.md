---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از جاوا
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/java/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- مقادیر جفتی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های سفارشی را در Aspose.Slides برای جاوا اضافه، خوانده، به‌روزرسانی و حذف کنید، همراه با مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله‌ توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌ طور خلاصه بیان می‌کند که داده‌ها در فایل‌های PPTX چگونه ذخیره می‌شوند، اشاره می‌کند که داده‌های خاص ارائه می‌تواند به‌ صورت برچسب‌ها و بخش‌های XML سفارشی وجود داشته باشد و برچسب‌ها را به‌ عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند.

همچنین نشان می‌دهد چگونه مقادیر برچسب را بخوانید و برچسب‌ها را به یک ارائه، یک اسلاید منفرد یا یک شکل اضافه کنید. علاوه‌ بر این، مقاله به وظایف رایج مدیریت برچسب مانند پاک کردن تمام برچسب‌ها، حذف یک برچسب بر اساس نام و دریافت لیست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—آیتم‌هایی با پسوند .pptx—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. قالب Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

با توجه به اینکه *اسلاید* یکی از عناصر ارائه‌هاست، یک *بخش اسلاید* محتویات یک اسلاید واحد را در بر دارد. یک بخش اسلاید می‌تواند روابط صریح با بسیاری از بخش‌ها—مانند User Defined Tags—که توسط ISO/IEC 29500 تعریف شده‌اند، داشته باشد.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌توانند به‌ صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITagCollection)) و CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection)) وجود داشته باشند.

{{% alert color="primary" %}} 

برچسب‌ها در واقع مقادیر جفت کلید‑مقدار رشته‌ای هستند. 

{{% /alert %}} 

## **دستگاه گرفتن مقادیر برچسب‌ها**

در Slides، یک برچسب متناظر با متدهای [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDocumentProperties#getKeywords--) و [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Java برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) دریافت کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides امکان افزودن برچسب‌ها به ارائه‌ها را فراهم می‌کند. یک برچسب معمولاً شامل دو مورد است:

- نام ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز به دسته‌بندی برخی ارائه‌ها بر اساس یک قانون یا ویژگی خاص داشته باشید، می‌توانید از افزودن برچسب به آن ارائه‌ها بهره ببرید. برای مثال، اگر بخواهید تمام ارائه‌های کشورهای آمریکای شمالی را در یک دسته قرار دهید، می‌توانید یک برچسب North American ایجاد کنید و سپس کشورهای مرتبط (ایالات متحده، مکزیک و کانادا) را به‌ عنوان مقادیر اختصاص دهید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) با Aspose.Slides برای Java اضافه کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) تنظیم شوند:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

یا برای هر [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) منفرد:

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

برچسب‌های اضافه‌شده از طریق مجموعه برچسب‌های داده سفارشی با استفاده از `getCustomData().getTags()` فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. در نتیجه، یک شناسه سفارشی که به‌ عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل:** می‌توانید یک شناسه سفارشی را در **متن Alt** شیء ذخیره کنید (مثلاً `shape.setAlternativeText("MyId")`). پس از صادر کردن به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **سوالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌کند.

**چگونه می‌توانم یک برچسب منفرد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از عملیات [Remove(name)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) بر روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید آن حذف کنید.

**چگونه می‌توانم لیست کامل نام‌های برچسب‌ها را برای آنالیز یا فیلتر کردن دریافت کنم؟**

از متد [getNamesOfTags](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#getNamesOfTags--) روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد یک آرایه شامل تمام نام‌های برچسب را برمی‌گرداند.