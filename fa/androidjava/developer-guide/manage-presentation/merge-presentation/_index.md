---
title: ادغام کارآمد ارائه‌ها در Android
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "به‌سهولة ادغام ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) با Aspose.Slides برای Android از طریق Java، و بهینه‌سازی گردش کار شما."
---
## **مرور کلی**

ادغام ارائه‌های PowerPoint و OpenDocument یک وظیفه‌ی رایج در بسیاری از برنامه‌های Android است، به‌خصوص هنگام تولید گزارش‌ها، ترکیب اسلایدها از منابع مختلف، یا خودکارسازی گردش کار ارائه‌ها. Aspose.Slides یک API قدرتمند و آسان‌استفاده برای ترکیب چندین فایل PPT، PPTX یا ODP در یک ارائه‌ی واحد بدون نیاز به نصب Microsoft PowerPoint، LibreOffice یا OpenOffice فراهم می‌کند.

در این راهنما، نحوه‌ی ادغام ارائه‌های PowerPoint و OpenDocument را با تنها چند خط کد یاد می‌گیرید. مثال‌های آماده‑استفاده ارائه می‌شود و نحوه حفظ قالب‌بندی اسلایدها، لایوت‌ها و سایر عناصر ارائه در طول فرآیند ادغام نشان داده می‌شود.

چه برنامه‌ای سازمانی و پیشرفته بسازید و چه یک ابزار ساده‌ٔ خودکارسازی، Aspose.Slides ادغام ارائه‌ها را سریع، قابل‌اعتماد و مقیاس‌پذیر می‌کند. Aspose.Slides امکان ادغام ارائه‌ها را به روش‌های مختلف فراهم می‌کند. می‌توانید ارائه‌ها را همراه با تمام شکل‌ها، سبک‌ها، متن، قالب‌بندی، نظرات، انیمیشن‌ها و موارد دیگر ترکیب کنید—بدون نگرانی دربارهٔ از دست رفتن کیفیت یا داده‌ها.

{{% alert color="primary" %}}
See also:[Clone Slides](https://docs.aspose.com/slides/fa/androidjava/clone-slides/)
{{% /alert %}}

### **مواردی که می‌توان ادغام کرد**

با Aspose.Slides می‌توانید

* کل ارائه‌ها را ادغام کنید. تمام اسلایدهای موجود در ارائه‌ها در یک ارائه جمع می‌شوند
* اسلایدهای خاص را ادغام کنید. اسلایدهای انتخابی در یک ارائه قرار می‌گیرند
* ارائه‌ها را در یک فرمت (مثلاً PPT به PPT، PPTX به PPTX و غیره) یا در فرمت‌های متفاوت (مثلاً PPT به PPTX، PPTX به ODP و غیره) به‌یکدیگر متصل کنید

### **گزینه‌های ادغام**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کند:

* هر اسلاید در ارائهٔ خروجی دارای سبک منحصر به فردی باشد
* یک سبک خاص برای تمام اسلایدهای ارائهٔ خروجی استفاده شود

برای ادغام ارائه‌ها، Aspose.Slides متدهای [AddClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را از اینترفیس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) فراهم می‌کند. چندین پیاده‌سازی برای متدهای `AddClone` وجود دارد که پارامترهای فرآیند ادغام را تعریف می‌کند. هر شیء Presentation دارای کالکشن [Slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) است، بنابراین می‌توانید متد `AddClone` را از ارائه‌ای که می‌خواهید اسلایدها به آن اضافه شوند، فراخوانی کنید.

متد `AddClone` یک شیء `ISlide` برمی‌گرداند که کلون اسلاید منبع است. اسلایدهای ارائهٔ خروجی به سادگی کپی‌ای از اسلایدهای منبع هستند. بنابراین می‌توانید به اسلایدهای حاصل تغییراتی اعمال کنید (مثلاً اعمال سبک یا گزینه‌های قالب‌بندی یا لایوت) بدون این‌که ارائه‌های منبع تحت تأثیر قرار گیرند.

## **ادغام ارائه‌ها**

Aspose.Slides متد [**AddClone(ISlide)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را فراهم می‌کند که امکان ترکیب اسلایدها را فراهم می‌سازد در حالی که اسلایدها لایوت و سبک خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد Java نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **ادغام ارائه‌ها با یک Slide Master**

Aspose.Slides متد [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) را فراهم می‌کند که امکان ترکیب اسلایدها را همراه با اعمال یک قالب Slide Master ارائه می‌دهد. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائهٔ خروجی را تغییر دهید.

این کد Java عملیات توصیف‌شده را نشان می‌دهد:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
طرح لایوت برای Slide Master به‌صورت خودکار تعیین می‌شود. هنگامی که لایوت مناسب نتواند تعیین شود، در صورتی که پارامتر Boolean `allowCloneMissingLayout` متد `AddClone` برابر true باشد، لایوت اسلاید منبع استفاده می‌شود. در غیر این‌صورت، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PptxEditException) پرتاب می‌شود.
{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائهٔ خروجی لایوت متفاوتی داشته باشند، به‌جای آن هنگام ادغام از متد [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) استفاده کنید.

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد دک‌های سفارشی مفید است. Aspose.Slides for Android via Java به شما امکان می‌دهد تنها اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، لایوت و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد Java زیر یک ارائهٔ جدید می‌سازد، اسلایدهای عنوان از دو ارائه دیگر اضافه می‌کند و نتیجه را در یک فایل ذخیره می‌نماید:

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **ادغام ارائه‌ها با یک Slide Layout**

این کد Java نشان می‌دهد چگونه اسلایدها را از ارائه‌ها ترکیب کنید در حالی که لایوت دلخواه خود را بر روی آن‌ها اعمال می‌کنید تا یک ارائهٔ خروجی به‌دست آید:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

{{% alert title="Note" color="warning" %}} 
نمی‌توانید ارائه‌ها را با اندازه‌های اسلاید متفاوت ادغام کنید. 
{{% /alert %}}

برای ادغام 2 ارائه با اندازه‌های اسلاید متفاوت، باید یکی از ارائه‌ها را طوری تغییر اندازه دهید که با اندازهٔ ارائه‌ دیگری مطابقت داشته باشد.

این نمونه کد عمل توصیف‌شده را نشان می‌دهد:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **ادغام اسلایدها به یک بخش از ارائه**

این کد Java نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه ادغام کنید:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

اسلاید در انتهای بخش اضافه می‌شود.

{{% alert title="Tip" color="primary" %}}
Aspose یک برنامه وب رایگان به نام [FREE Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و غیره.
{{% /alert %}}

## **سوالات متداول**

**آیا محدودیتی برای تعداد اسلایدها هنگام ادغام ارائه‌ها وجود دارد؟**

بدون محدودیت‌های سخت‌گیرانه. Aspose.Slides می‌تواند فایل‌های بزرگ را مدیریت کند، اما عملکرد به اندازه فایل و منابع سیستم وابسته است. برای ارائه‌های بسیار بزرگ توصیه می‌شود از JVM 64‑bit استفاده کنید و حافظه Heap کافی تخصیص دهید.

**آیا می‌توانم ارائه‌ها را با ویدئو یا صداهای جاسازی‌شده ادغام کنم؟**

بله، Aspose.Slides محتوای چندرسانه‌ای جاسازی‌شده در اسلایدها را حفظ می‌کند، اما ممکن است اندازهٔ نهایی ارائه به‌طور قابل‌توجهی بزرگ‌تر شود.

**آیا فونت‌ها هنگام ادغام ارائه‌ها حفظ می‌شوند؟**

بله. فونت‌های استفاده‌شده در ارائه‌های منبع در فایل خروجی حفظ می‌شوند به شرطی که بر روی سیستم نصب شده باشند یا [embedded](/slides/fa/androidjava/embedded-font/).