---
title: ادغام مؤثر ارائه‌ها در جاوا
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
- جاوا
- Aspose.Slides
description: "به‌سادگی ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را با Aspose.Slides برای جاوا ادغام کنید و جریان کاری خود را بهبود دهید."
---
## **بررسی کلی**

ادغام ارائه‌های PowerPoint و OpenDocument یک کار رایج در بسیاری از برنامه‌های Java است، به‌ویژه هنگام تولید گزارش‌ها، ترکیب اسلایدهای مختلف از منابع گوناگون، یا خودکارسازی جریان کار ارائه‌ها. Aspose.Slides for Java یک API قدرتمند و آسان برای استفاده فراهم می‌کند تا چندین فایل PPT، PPTX یا ODP را بدون نصب Microsoft PowerPoint، LibreOffice یا OpenOffice در یک ارائه واحد ترکیب کند.

در این راهنما، شما یاد خواهید گرفت چگونه با استفاده از چند خط کد Java، ارائه‌های PowerPoint و OpenDocument را ادغام کنید. ما مثال‌های آماده استفاده را ارائه می‌دهیم و نحوه حفظ قالب‌بندی اسلایدها، طرح‌ها و سایر عناصر ارائه در طول فرآیند ادغام را نشان می‌دهیم.

چه در حال ساخت یک برنامه سطح سازمانی باشید و چه یک ابزار ساده خودکارسازی، Aspose.Slides ادغام ارائه‌ها در Java را سریع، قابل اعتماد و مقیاس‌پذیر می‌سازد. Aspose.Slides for Java به شما امکان می‌دهد ارائه‌ها را به روش‌های مختلف ادغام کنید. می‌توانید ارائه‌ها را همراه با تمام اشکال، سبک‌ها، متن، قالب‌بندی، نظرات، انیمیشن‌ها و موارد دیگر ترکیب کنید — بدون نگرانی در مورد از دست رفتن کیفیت یا داده‌ها.

{{% alert color="info" %}}
همچنین ببینید: [Clone Slides](https://docs.aspose.com/slides/fa/java/clone-slides/)
{{% /alert %}}

### **چه چیزهایی می‌توانند ادغام شوند؟**

**تمام ارائه‌ها** – تمام اسلایدهای چندین ارائه ترکیب می‌شوند و یک‌جا می‌شوند.

**اسلایدهای خاص** – فقط اسلایدهای انتخاب شده به یک ارائه واحد ادغام می‌شوند.

**ارائه‌ها در همان فرمت** (مثلاً PPT به PPT، PPTX به PPTX) و **در فرمت‌های مختلف** (مثلاً PPT به PPTX، PPTX به ODP).

### **گزینه‌های ادغام**

- هر اسلاید در ارائه خروجی سبک اصلی خود را حفظ می‌کند
- یک سبک خاص بر تمام اسلایدهای ارائه خروجی اعمال می‌شود

برای ادغام ارائه‌ها، Aspose.Slides متدهای `AddClone` را از اینترفیس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) ارائه می‌دهد. چندین overload برای متد `AddClone` وجود دارد که رفتار فرآیند ادغام را تعیین می‌کنند. هر شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) یک مجموعه Slides دارد. بنابراین می‌توانید متد `AddClone` را روی ارائه هدفی که می‌خواهید اسلایدها را به آن ادغام کنید، فراخوانی کنید.

متد `AddClone` یک شیء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) را برمی‌گرداند که یک کپی از اسلاید منبع است. اسلایدهای حاصل در ارائه خروجی صرفاً نسخه‌هایی از اسلایدهای اصلی هستند. این به این معنی است که می‌توانید اسلایدهای کپی شده را به‌صورت ایمن تغییر دهید — مانند اعمال سبک‌ها، گزینه‌های قالب‌بندی یا طرح‌ها — بدون اینکه به ارائه منبع اثر بگذارد.

## **ادغام ارائه‌ها**

Aspose.Slides متد [AddClone(ISlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) را فراهم می‌کند که به شما امکان ترکیب اسلایدها را در حالی که طرح‌ها و سبک‌های اصلی آن‌ها حفظ می‌شود (رفتار پیش‌فرض) می‌دهد.

کد جاوا زیر نشان می‌دهد چگونه ارائه‌ها را ادغام کنید:

```java
import com.aspose.slides.*;

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

## **ادغام ارائه‌ها با یک اسلاید مستر**

Aspose.Slides متد [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) را فراهم می‌کند که به شما امکان ترکیب اسلایدها را در حالی که یک اسلاید مستر از قالب ارائه اعمال می‌شود، می‌دهد. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

کد جاوا زیر این عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
طرح اسلاید برای اسلاید به‌صورت خودکار تعیین می‌شود. وقتی یک طرح مناسب پیدا نشود و پارامتر بولی `allowCloneMissingLayout` متد `AddClone` برابر `true` باشد، طرح اسلاید منبع استفاده می‌شود. در غیر این صورت، یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) صادر می‌شود.
{{% /alert %}}

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد مجموعه اسلایدهای سفارشی مفید است. Aspose.Slides for Java به شما امکان می‌دهد تنها اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، طرح و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد جاوا زیر یک ارائه جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌نماید:

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

## **ادغام ارائه‌ها با یک طرح اسلاید**

برای اعمال یک طرح اسلاید متفاوت بر اسلایدهای خروجی هنگام ادغام، به‌جای آن از متد [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه اسلایدها را از چندین ارائه ترکیب کنید در حالی که طرح اسلاید موردنظر خود را اعمال می‌کنید و یک ارائه خروجی واحد تولید می‌شود:

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **ادغام ارائه‌ها با اندازه اسلایدهای متفاوت**

برای ادغام دو ارائه با اندازه اسلایدهای متفاوت، باید یکی از آن‌ها را طوری تغییر اندازه دهید که با اندازه اسلاید ارائه دیگر مطاببت داشته باشد.

کد جاوا زیر این عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **ادغام اسلایدها به یک بخش از ارائه**

ادغام اسلایدها در یک بخش خاص از ارائه به سازماندهی محتوا و بهبود ناوبری اسلایدها کمک می‌کند. Aspose.Slides به شما امکان می‌دهد اسلایدها را به بخش‌های موجود ادغام کنید. این کار ساختار واضحی را تضمین می‌کند در حالی که قالب‌بندی اصلی هر اسلاید حفظ می‌شود.

کد جاوا زیر نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه ادغام کنید:

```java
import com.aspose.slides.*;

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

اسلاید به انتهای بخش اضافه می‌شود.

## **موارد مرتبط**

Aspose یک [ابزار رایگان آنلاین ساخت کلاژ](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و موارد دیگر.

به [ابزار رایگان آنلاین ادغام Aspose](https://products.aspose.app/slides/fa/merger) نگاهی بیندازید. این ابزار به شما امکان می‌دهد ارائه‌های PowerPoint را در همان فرمت (مثلاً PPT به PPT، PPTX به PPTX) یا در فرمت‌های مختلف (مثلاً PPT به PPTX، PPTX به ODP) ادغام کنید.

[![ابزار رایگان آنلاین ادغام Aspose](slides-merger.png)](https://products.aspose.app/slides/fa/merger)

علاوه بر ارائه‌ها، Aspose.Slides به شما امکان می‌دهد فایل‌های دیگر را نیز ادغام کنید:

- [**تصاویر**](https://products.aspose.com/slides/fa/java/merger/image-to-image/)، مانند [JPG به JPG](https://products.aspose.com/slides/fa/java/merger/jpg-to-jpg/) یا [PNG به PNG](https://products.aspose.com/slides/fa/java/merger/png-to-png/)
- [**اسناد**](https://products.aspose.com/slides/fa/java/merger/pdf-to-pdf/)، مانند [PDF به PDF](https://products.aspose.com/slides/fa/java/merger/pdf-to-pdf/) یا [HTML به HTML](https://products.aspose.com/slides/fa/java/merger/html-to-html/)
- [**انواع فایل‌های ترکیبی**](https://products.aspose.com/slides/fa/java/merger/image-to-pdf/)، مانند [تصویر به PDF](https://products.aspose.com/slides/fa/java/merger/image-to-pdf/)، [JPG به PDF](https://products.aspose.com/slides/fa/java/merger/jpg-to-pdf/)، یا [TIFF به PDF](https://products.aspose.com/slides/fa/java/merger/tiff-to-pdf/)

## **سوالات متداول**

### آیا محدودیتی برای تعداد اسلایدها هنگام ادغام ارائه‌ها وجود دارد؟

هیچ محدودیت سخت‌گیرانه‌ای وجود ندارد. Aspose.Slides می‌تواند فایل‌های بزرگ را مدیریت کند، اما عملکرد به اندازه فایل و منابع سیستم بستگی دارد. برای ارائه‌های بسیار بزرگ، توصیه می‌شود از JVM 64 بیتی استفاده کنید و حافظه heap کافی تخصیص دهید.

### آیا می‌توانم ارائه‌ها را با ویدئو یا صدای داخلی ادغام کنم؟

بله، Aspose.Slides محتوای چندرسانه‌ای درج‌شده در اسلایدها را حفظ می‌کند، اما ممکن است ارائه نهایی به‌طور قابل توجهی بزرگ‌تر شود.

### آیا فونت‌ها هنگام ادغام ارائه‌ها حفظ می‌شوند؟

بله. فونت‌های استفاده‌شده در ارائه‌های منبع در فایل خروجی حفظ می‌شوند، به شرط آنکه بر روی سیستم نصب شده باشند یا [درج شده](/slides/fa/java/embedded-font/).