---
title: تبدیل اسلایدهای پاورپوینت به PNG در اندروید
linktitle: پاورپوینت به PNG
type: docs
weight: 30
url: /fa/androidjava/convert-powerpoint-to-png/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- اندروید
- جاوا
- Aspose.Slides
description: "پیشنهادات پاورپوینت را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای اندروید از طریق جاوا، به‌گونه‌ای که نتایج دقیق و خودکار حاصل شود."
---
## **نمای کلی**

این مقاله نحوه تبدیل اسلایدهای ارائه به تصاویر PNG را با استفاده از Aspose.Slides برای Android از طریق Java توضیح می‌دهد. می‌توانید ارائه‌ها را در قالب‌هایی نظیر PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به عنوان یک تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر نحوه رندر با مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی بر حسب پیکسل و انتخاب سبک رندر گرادیان را نشان می‌دهند.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) دسترسی پیدا کنید. در این مثال هر اسلاید با [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) بدون پارامتر رندر می‌شود تا یک تصویر بندانگشتی ایجاد شود. سپس با استفاده از [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) و [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) هر اسلاید رندر شده به عنوان تصویر PNG ذخیره می‌گردد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
بارگذاری بدون پارامتر [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) با مقیاس 0.2 انجام می‌شود. به‌عنوان مثال، اسلایدی با اندازه 720 × 540 پوینت یک تصویر بندانگشتی 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با عوامل مقیاس یا اندازه تصویر صریح که در ادامه نشان داده شده‌اند استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

برای کنترل ابعاد رندر شده، عوامل مقیاس افقی و عمودی را به [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) پاس دهید. در این مثال، هر دو عامل برابر 2 هستند، بنابراین اسلایدی با اندازه 720 × 540 پوینت تصویر 1440 × 1080 پیکسل تولید می‌کند. عوامل مقیاس مساوی نسبت ابعاد اسلاید را حفظ می‌کنند. هر تصویر با استفاده از [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) در قالب PNG ذخیره می‌شود.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین ابعاد خروجی بر حسب پیکسل، به جای عوامل مقیاس، یک اندازه را به [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) پاس دهید. این مثال هر اسلاید را با اندازه 960 × 720 پیکسل رندر می‌کند و نتیجه را با [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ذخیره می‌گردد. برای جلوگیری از کشیده شدن تصویر، ابعادی را انتخاب کنید که نسبت ابعاد اسلاید را حفظ کنند.
```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتخاب سبک رندر گرادیان**

فرض کنید اسلایدی شامل پرکنش‌های گرادیان باشد، اما تغییرات رنگ در PNG استخراج‌شده روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید باشد. می‌توانید از متد [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) که توسط [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) به ارث برده شده است، برای انتخاب نحوه رندر کردن گرادیان‌ها استفاده کنید.

[gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول این فایل دو گرادیان خطی دارد: سیان به نارنجی در بالا و آبی به زرد در پایین. هر گرادیان دو توقف‌نقطه دارد، در 0٪ و 100٪.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) رندر می‌نماید.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر خروجی یک اسلاید یکسان را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های سیان به نارنجی و آبی به زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری می‌دهد. این 차اگگی به رنگ‌ها و نقاط توقف در گرادیان بستگی دارد.

وقتی خروجی استاندارد Aspose.Slides برای نیازهای شما کافی است، `Default` را انتخاب کنید. اگر اولویت شما انطباق ظاهر با PowerPoint است، `PowerPointUI` را امتحان کنید. هر دو خروجی را با نتیجه مورد نظر خود مقایسه کنید؛ هیچ‌یک به‌صورت کلی بر دیگری برتری ندارند.

## **سؤالات متداول**

**چگونه می‌توانم به‌جای کل اسلاید، یک شکل خاص مانند نمودار یا تصویر را خروجی بگیرم؟**  
Aspose.Slides از [ایجاد بندانگشتی برای اشکال منفرد](/slides/fa/androidjava/create-shape-thumbnails/) پشتیبانی می‌کند و به شما امکان می‌دهد یک شکل را به عنوان تصویر PNG رندر کنید.

**آیا تبدیل موازی در سرور پشتیبانی می‌شود؟**  
بله. برای هر رشته یا فرآیند یک نمونه‌ ارائه جداگانه استفاده کنید؛ [یک نمونه را بین رشته‌ها به اشتراک نگذارید](/slides/fa/androidjava/multithreading/).

**محدودیت‌های ارزیابی هنگام خروجی به PNG چیست؟**  
حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا دریافت لایسنس، [محدودیت‌های دیگر](/slides/fa/androidjava/licensing/) را اعمال می‌نماید.