---
title: ادغام کارآمد ارائه‌ها در Java
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "با Aspose.Slides برای Java، به‌سهولت ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را ادغام کنید و جریان کار خود را بهینه‌سازی کنید."
---
## **نمای کلی**

ادغام ارائه‌های PowerPoint و OpenDocument یک کار رایج در بسیاری از برنامه‌های Java است، به‌ویژه هنگام تولید گزارش‌ها، ترکیب اسلایدها از منابع مختلف، یا خودکارسازی جریان‌های کاری ارائه. Aspose.Slides برای Java یک API قدرتمند و آسان برای ترکیب چندین فایل PPT، PPTX یا ODP به یک ارائهٔ واحد فراهم می‌کند بدون نیاز به نصب Microsoft PowerPoint، LibreOffice یا OpenOffice.

در این راهنما، خواهید آموخت که چگونه ارائه‌های PowerPoint و OpenDocument را با استفاده از چند خط کد Java ادغام کنید. مثال‌های آماده را ارائه خواهیم داد و نشان می‌دهیم که چگونه قالب‌بندی اسلایدها، طرح‌ها و سایر عناصر ارائه را در طول فرآیند ادغام حفظ کنید.

چه برنامه‌ای سازمانی بزرگ بسازید یا ابزاری ساده برای خودکارسازی، Aspose.Slides ادغام ارائه‌ها در Java را سریع، قابل اعتماد و مقیاس‌پذیر می‌کند. Aspose.Slides برای Java امکان ادغام ارائه‌ها را به روش‌های مختلف فراهم می‌کند. می‌توانید ارائه‌ها را همراه با تمام اشکال، سبک‌ها، متن، قالب‌بندی، نظرات، انیمیشن‌ها و موارد دیگر ترکیب کنید—بدون نگرانی دربارهٔ از دست رفتن کیفیت یا داده.

{{% alert color="primary" %}}

همچنین ببینید: [Clone Slides](https://docs.aspose.com/slides/fa/java/clone-slides/)

{{% /alert %}}

### **چه چیزهایی می‌توان ادغام کرد؟**

با Aspose.Slides می‌توانید موارد زیر را ادغام کنید:

**کل ارائه‌ها** – تمام اسلایدهای چندین ارائه در یک فایل ترکیب می‌شوند.

**اسلایدهای خاص** – فقط اسلایدهای انتخاب‌شده به یک ارائهٔ واحد ادغام می‌شوند.

**ارائه‌ها با فرمت یکسان** (مثلاً PPT به PPT، PPTX به PPTX) و **در فرمت‌های متفاوت** (مثلاً PPT به PPTX، PPTX به ODP).

### **گزینه‌های ادغام**

می‌توانید گزینه‌هایی تعیین کنید که آیا:

- هر اسلاید در ارائه خروجی سبک اصلی خود را حفظ کند
- یک سبک خاص بر همهٔ اسلایدهای ارائه خروجی اعمال شود

برای ادغام ارائه‌ها، Aspose.Slides متدهای `AddClone` را از رابط [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) فراهم می‌کند. چندین بارگیری (overload) برای متد `AddClone` وجود دارد که رفتار فرآیند ادغام را تعریف می‌کند. هر شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) دارای یک مجموعهٔ Slides است. بنابراین می‌توانید متد `AddClone` را بر روی ارائه هدفی که می‌خواهید اسلایدها را در آن ادغام کنید، فراخوانی کنید.

متد `AddClone` یک شیء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) را برمی‌گرداند که یک کپی از اسلاید منبع است. اسلایدهای نتیجه در ارائه خروجی صرفاً کپی‌هایی از اسلایدهای اصلی هستند. این به این معنی است که می‌توانید اسلایدهای کپی‌شده را به‌صورت ایمن تغییر دهید—مانند اعمال سبک‌ها، گزینه‌های قالب‌بندی یا طرح‌ها—بدون تأثیر بر ارائهٔ منبع.

## **ادغام ارائه‌ها**

Aspose.Slides متد [AddClone(ISlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) را فراهم می‌کند که به شما امکان ترکیب اسلایدها را در حالی که طرح‌ها و سبک‌های اصلی آن‌ها را حفظ می‌کند (رفتار پیش‌فرض) می‌دهد.

کد Java زیر نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **ادغام ارائه‌ها با یک Slide Master**

Aspose.Slides متد [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) را فراهم می‌کند که به شما امکان ترکیب اسلایدها را در حالی که یک Slide Master از قالب ارائه اعمال می‌شود، می‌دهد. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

کد Java زیر این عملیات را نشان می‌دهد:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}

چیدمان اسلاید به‌صورت خودکار تعیین می‌شود. وقتی چیدمان مناسب یافت نشود و پارامتر بولی `allowCloneMissingLayout` متد `AddClone` روی `true` تنظیم شده باشد، چیدمان اسلاید منبع استفاده می‌شود. در غیر این صورت، یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.

{{% /alert %}}

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد دک‌های سفارشی مفید است. Aspose.Slides برای Java به شما امکان انتخاب و وارد کردن تنها اسلایدهایی که نیاز دارید را می‌دهد. این API قالب‌بندی، طرح و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد Java زیر یک ارائهٔ جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائهٔ دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌نماید:

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

برای اعمال یک Slide Layout متفاوت بر اسلایدهای خروجی هنگام ادغام، به‌جای متد قبلی می‌توانید از [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) استفاده کنید.

کد Java زیر نشان می‌دهد چگونه اسلایدها را از چندین ارائه ترکیب کنید در حالی که Slide Layout دلخواه خود را اعمال می‌کنید و در نهایت یک ارائهٔ خروجی واحد به‌دست می‌آید:

```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

برای ادغام دو ارائه با اندازه‌های اسلاید متفاوت، یکی از آن‌ها را باید طوری تغییر اندازه دهید که با اندازه اسلاید ارائهٔ دیگر منطبق شود.

کد Java زیر این عملیات را نشان می‌دهد:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **ادغام اسلایدها به یک بخش (Section) در ارائه**

ادغام اسلایدها به یک بخش خاص در ارائه به سازماندهی بهتر محتوا و بهبود ناوبری اسلایدها کمک می‌کند. Aspose.Slides به شما اجازه می‌دهد اسلایدها را به بخش‌های موجود اضافه کنید. این کار ساختار واضحی را تضمین می‌کند در حالی که قالب‌بندی اصلی هر اسلاید حفظ می‌شود.

کد Java زیر نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه اضافه کنید:

```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

اسلاید به انتهای آن بخش افزوده می‌شود.

## **موارد مرتبط**

Aspose یک [FREE Online Collage Maker](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و موارد دیگر.

به [Aspose FREE Online Merger](https://products.aspose.app/slides/fa/merger) سر بزنید. این ابزار به شما اجازه می‌دهد ارائه‌های PowerPoint را در همان فرمت (مثل PPT به PPT، PPTX به PPTX) یا بین فرمت‌های مختلف (مثل PPT به PPTX، PPTX به ODP) ترکیب کنید.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/fa/merger)

علاوه بر ارائه‌ها، Aspose.Slides امکان ترکیب فایل‌های دیگر را نیز دارد:

- [**Images**](https://products.aspose.com/slides/fa/java/merger/image-to-image/)، مانند [JPG به JPG](https://products.aspose.com/slides/fa/java/merger/jpg-to-jpg/) یا [PNG به PNG](https://products.aspose.com/slides/fa/java/merger/png-to-png/)
- **Documents**، مانند [PDF به PDF](https://products.aspose.com/slides/fa/java/merger/pdf-to-pdf/) یا [HTML به HTML](https://products.aspose.com/slides/fa/java/merger/html-to-html/)
- **Mixed file types**، مانند [image به PDF](https://products.aspose.com/slides/fa/java/merger/image-to-pdf/)، [JPG به PDF](https://products.aspose.com/slides/fa/java/merger/jpg-to-pdf/)، یا [TIFF به PDF](https://products.aspose.com/slides/fa/java/merger/tiff-to-pdf/)

## **سؤال‌های متداول**

**آیا محدودیتی برای تعداد اسلایدها هنگام ادغام ارائه‌ها وجود دارد؟**

هیچ محدودیت سخت‌گیرانه‌ای وجود ندارد. Aspose.Slides می‌تواند فایل‌های بزرگ را پردازش کند، اما عملکرد به اندازه فایل و منابع سیستم بستگی دارد. برای ارائه‌های بسیار بزرگ توصیه می‌شود از JVM 64‑بیتی استفاده کنید و حافظهٔ Heap کافی تخصیص دهید.

**آیا می‌توانم ارائه‌ها را که شامل ویدیو یا صوت جاسازی‌شده هستند، ادغام کنم؟**

بله، Aspose.Slides محتوای چندرسانه‌ای جاسازی‌شده در اسلایدها را حفظ می‌کند، اما ممکن است حجم نهایی ارائه به‌طور قابل توجهی افزایش یابد.

**آیا هنگام ادغام ارائه‌ها قلم‌ها (فونت‌ها) حفظ می‌شوند؟**

بله. قلم‌های استفاده‌شده در ارائه‌های منبع در فایل خروجی حفظ می‌شوند، به شرط آنکه بر روی سیستم نصب باشند یا [embedded](/slides/fa/java/embedded-font/).