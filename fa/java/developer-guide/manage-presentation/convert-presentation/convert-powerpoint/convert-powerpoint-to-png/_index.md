---
title: تبدیل اسلایدهای PowerPoint به PNG در Java
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به صورت PNG
- ذخیره PPTX به صورت PNG
- صدور PPT به PNG
- صدور PPTX به PNG
- Java
- Aspose.Slides
description: "ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای Java، تضمین نتایج دقیق و خودکار."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را به تصاویر PNG با استفاده از Aspose.Slides for Java تبدیل کنید. می‌توانید ارائه‌ها را در قالب‌های PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به عنوان یک تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر رندر با مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی بر حسب پیکسل و انتخاب سبک رندر گرادیان را نشان می‌دهند.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) دسترسی پیدا کنید. مثال هر اسلاید را با [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) بدون پارامترها رندر می‌کند تا یک تصویر بندانگشتی ایجاد شود. سپس با استفاده از [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) و [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) هر اسلاید رندر شده را به عنوان تصویر PNG ذخیره می‌کند.

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
بارگذاری بدون پارامتر [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) با مقیاس ۰٫۲ رندر می‌شود. به عنوان مثال، اسلایدی با اندازه ۷۲۰ × ۵۴۰ پوینت یک تصویر بندانگشتی ۱۴۴ × ۱۰۸ پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های دارای عوامل مقیاس یا اندازه تصویر صریح نشان‌داده‌شده در پایین استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

برای کنترل ابعاد رندر، عوامل مقیاس افقی و عمودی را به [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) پاس دهید. در این مثال هر دو عامل برابر ۲ است، بنابراین اسلایدی با اندازه ۷۲۰ × ۵۴۰ پوینت یک تصویر ۱۴۴۰ × ۱۰۸۰ پیکسل تولید می‌کند. عوامل مقیاس برابر نسبت ابعاد اسلاید را حفظ می‌کند. هر تصویر با فرمت PNG توسط [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ذخیره می‌شود.

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

برای تعیین ابعاد خروجی بر حسب پیکسل، به جای عوامل مقیاس، یک اندازه را به [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) پاس دهید. این مثال هر اسلاید را با ابعاد ۹۶۰ × ۷۲۰ پیکسل رندر می‌کند و نتیجه را با [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ذخیره می‌کند. برای جلوگیری از کشیدگی تصویر، ابعادی را انتخاب کنید که نسبت عرض به ارتفاع اسلاید را حفظ کند.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

فرض کنید اسلایدی دارای پرکننده‌های گرادیان باشد، اما انتقال‌ها در PNG صادر شده روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید، به نظر برسند. می‌توانید از متد [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) که توسط [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) به ارث برده شده است، برای انتخاب نحوه رندر گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل دو گرادیان خطی است: از فیروزه‌ای به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دو توقف دارد، در ۰٪ و ۱۰۰٪.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) رندر می‌نماید.

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

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های فیروزه‌ای به نارنجی و آبی به زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری می‌دهد. تفاوت بسته به رنگ‌ها و نقاط توقف در گرادیان است.

`Default` را زمانی انتخاب کنید که خروجی استاندارد Aspose.Slides برای نیازهای شما کافی باشد. وقتی هدف شما تطبیق ظاهر با PowerPoint است، `PowerPointUI` را امتحان کنید. هر دو خروجی را با نتیجه مورد نظر خود مقایسه کنید؛ هیچ‌یک به‌صورت تمام‌عیار برتر نیست.

## **پرسش‌های متداول**

**چگونه می‌توانم یک شکل خاص، مانند نمودار یا تصویر، به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [ایجاد تصویرهای بندانگشتی برای اشکال فردی](/slides/fa/java/create-shape-thumbnails/) پشتیبانی می‌کند و به شما امکان می‌دهد یک شکل را به عنوان تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**

بله. برای هر رشته یا فرایند یک نمونه جداگانه از ارائه استفاده کنید؛ [از اشتراک یک نمونه واحد بین رشته‌ها خودداری کنید](/slides/fa/java/multithreading/).

**محدودیت‌های حالت ارزیابی هنگام صادرات به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمانی که لایسنس اعمال نشود، [محدودیت‌های دیگر](/slides/fa/java/licensing/) را اعمال می‌کند.