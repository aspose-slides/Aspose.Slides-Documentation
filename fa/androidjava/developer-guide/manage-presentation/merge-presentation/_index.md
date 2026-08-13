---
title: به‌صورت مؤثر ارائه‌ها را در اندروید ترکیب کنید
linktitle: ترکیب ارائه‌ها
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
- اندروید
- جاوا
- Aspose.Slides
description: "به‌سادگی ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) را با Aspose.Slides برای اندروید از طریق جاوا ادغام کنید و جریان کاری خود را بهینه کنید."
---
## **Overview**

ادغام ارائه‌های PowerPoint و OpenDocument یک کار معمول در بسیاری از برنامه‌های Android است، به‌ویژه هنگام تولید گزارش‌ها، ترکیب اسلایدها از منابع مختلف یا خودکارسازی گردش کار ارائه‌ها. Aspose.Slides یک API قدرتمند و آسان‌استفاده برای ترکیب چندین فایل PPT، PPTX یا ODP در یک ارائه واحد فراهم می‌کند بدون نیاز به نصب Microsoft PowerPoint، LibreOffice یا OpenOffice.

در این راهنما، یاد خواهید گرفت چگونه ارائه‌های PowerPoint و OpenDocument را با چند خط کد ادغام کنید. مثال‌های آماده برای استفاده در دسترس است و نشان می‌دهد چگونه قالب‌بندی، چینش‌ها و سایر عناصر ارائه را در طول فرآیند ادغام حفظ کنید.

چه برنامه‌ای سطح سازمانی بسازید و چه ابزار ساده‌ای برای خودکارسازی، Aspose.Slides ادغام ارائه‌ها را سریع، قابل‌اعتماد و مقیاس‌پذیر می‌سازد. Aspose.Slides امکان ادغام ارائه‌ها را به روش‌های مختلف فراهم می‌کند. می‌توانید ارائه‌ها را با تمام اشکال، سبک‌ها، متن، قالب‌بندی، نظرات، انیمیشن‌ها و موارد دیگر ترکیب کنید — بدون نگرانی دربارهٔ کاهش کیفیت یا داده‌ها.

{{% alert color="info" %}}
همچنین ببینید: [Clone Slides](https://docs.aspose.com/slides/fa/androidjava/clone-slides/)
{{% /alert %}}

### **What Can Be Merged**

با Aspose.Slides می‌توانید 

* تمام ارائه‌ها را ادغام کنید. تمام اسلایدهای موجود در ارائه‌ها در یک ارائه جمع می‌شوند
* اسلایدهای خاص را ادغام کنید. اسلایدهای انتخاب‌شده در یک ارائه قرار می‌گیرند
* ارائه‌ها را در یک فرمت (PPT به PPT، PPTX به PPTX و غیره) و در فرمت‌های مختلف (PPT به PPTX، PPTX به ODP و غیره) به یکدیگر ترکیب کنید. 

### **Merging Options**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کند 

* هر اسلاید در ارائه خروجی سبک منحصر به فردی حفظ کند
* یک سبک خاص برای تمام اسلایدهای ارائه خروجی استفاده شود. 

برای ادغام ارائه‌ها، Aspose.Slides متدهای [AddClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (از رابط [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection)) را فراهم می‌کند. چندین پیاده‌سازی از متدهای `AddClone` وجود دارد که پارامترهای فرآیند ادغام ارائه را تعریف می‌کنند. هر شیء Presentation یک مجموعه [Slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) دارد، بنابراین می‌توانید متد `AddClone` را از ارائه‌ای که می‌خواهید اسلایدها به آن اضافه شوند، فراخوانی کنید.

متد `AddClone` یک شیء `ISlide` بازمی‌گرداند که یک کلون از اسلاید منبع است. اسلایدهای ارائه خروجی صرفاً کپی‌ای از اسلایدهای منبع هستند. بنابراین می‌توانید تغییرات لازم (مانند اعمال سبک‌ها یا گزینه‌های قالب‌بندی یا چینش‌ها) را بر روی اسلایدهای حاصل انجام دهید بدون اینکه نگران تأثیر بر روی ارائه‌های منبع باشید. 

## **Merge Presentations** 

Aspose.Slides متد [**AddClone(ISlide)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را ارائه می‌دهد که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که اسلایدها چینش و سبک‌های خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد Java نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```java
import com.aspose.slides.*;

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

## **Merge Presentations with a Slide Master**

Aspose.Slides متد [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که قالب مستر اسلاید ارائه اعمال می‌شود. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

این کد Java عملیات توصیف‌شده را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
چینش اسلاید برای مستر اسلاید به‌صورت خودکار تعیین می‌شود. وقتی چینش مناسب قابل تشخیص نیست، اگر پارامتر بولی `allowCloneMissingLayout` متد `AddClone` روی true تنظیم شده باشد، چینش اسلاید منبع استفاده می‌شود. در غیر این صورت، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PptxEditException) پرتاب خواهد شد.
{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائه خروجی چینش متفاوتی داشته باشند، هنگام ادغام از متد [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) استفاده کنید.

## **Merge Specific Slides from Presentations**

ادغام اسلایدهای خاص از چندین ارائه برای ساخت دک‌های سفارشی مفید است. Aspose.Slides for Android via Java به شما اجازه می‌دهد فقط اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، چینش و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد Java زیر یک ارائه جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌نماید:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Merge Presentations with a Slide Layout**

این کد Java نشان می‌دهد چگونه اسلایدها را از ارائه‌ها ترکیب کنید در حالی که چینش دلخواه خود را بر روی آن‌ها اعمال می‌کنید تا یک ارائه خروجی به‌دست آید:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 
نمی‌توانید ارائه‌ها را با اندازه‌های اسلاید متفاوت ادغام کنید. 
{{% /alert %}}

برای ادغام ۲ ارائه با اندازه اسلاید متفاوت، باید یکی از ارائه‌ها را به‌گونه‌ای تغییر اندازه دهید تا با اندازه ارائه دیگر منطبق شود.

این کد نمونه عملیات توصیف‌شده را نشان می‌دهد:

```java
import com.aspose.slides.*;

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

## **Merge Slides to a Presentation Section**

این کد Java نشان می‌دهد چگونه یک اسلاید خاص را به بخشی در یک ارائه ادغام کنید:

```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose یک برنامه وب رایگان **Collage** ارائه می‌دهد https://products.aspose.app/slides/fa/collage. با استفاده از این سرویس آنلاین می‌توانید [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG ترکیب کنید، شبکه‌های عکسی بسازید و غیره.
{{% /alert %}}

## **FAQ**

### آیا محدودیتی در تعداد اسلایدها هنگام ادغام ارائه‌ها وجود دارد؟

محدودیت سخت‌گیرانه‌ای نیست. Aspose.Slides می‌تواند فایل‌های بزرگ را پردازش کند، اما عملکرد به حجم فایل و منابع سیستم وابسته است. برای ارائه‌های بسیار بزرگ استفاده از JVM ۶۴‑بیتی و تخصیص کافی حافظه heap توصیه می‌شود.

### آیا می‌توانم ارائه‌ها را با ویدیو یا صدا تعبیه‌شده ادغام کنم؟

بله، Aspose.Slides محتوای چندرسانه‌ای تعبیه‌شده در اسلایدها را حفظ می‌کند، اما ممکن است فایل نهایی به‌طور قابل‌توجهی بزرگ‌تر شود.

### آیا فونت‌ها هنگام ادغام ارائه‌ها حفظ می‌شوند؟

بله. فونت‌های استفاده‌شده در ارائه‌های منبع در فایل خروجی حفظ می‌شوند، به شرط آنکه بر روی سیستم نصب باشند یا [embedded](/slides/fa/androidjava/embedded-font/).