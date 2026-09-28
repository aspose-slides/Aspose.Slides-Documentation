---
title: مدیریت اسلاید مسترهای ارائه در اندروید
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/androidjava/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر متعدد
- مقایسه اسلایدهای مستر
- پس‌زمینه
- نگهدارنده
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای Android از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک برای یک گروه از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش اسلاید مستر راه معمول برای حفظ ثبات یک ارائه بدون تکرار قالب‌بندی در هر اسلاید است.

Aspose.Slides برای Android از طریق Java از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید طرح‌بندی داشته باشد. اسلایدهای عادی معمولاً به‌صورت مستقیم به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید عادی از یک اسلاید طرح‌بندی استفاده می‌کند و آن اسلاید طرح‌بندی متعلق به یک اسلاید مستر است.

سلسله مراتب به‌صورت زیر است:

1. **اسلاید مستر** – تنظیمات طراحی و تم مشترک را تعریف می‌کند.  
1. **اسلاید طرح‌بندی** – ترتیب خاصی از نگهدارنده‌ها و قالب‌بندی‌های سطح طرح‌بندی را تعریف می‌کند.  
1. **اسلاید عادی** – محتوای واقعی ارائه را در بر دارد و از یک اسلاید طرح‌بندی استفاده می‌کند.

![سلسله مراتب اسلایدهای مستر، اسلایدهای طرح‌بندی و اسلایدهای عادی](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید مستر توسط رابط [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) نمایش داده می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getMasters--) در دسترس هستند که رابط [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) را پیاده‌سازی می‌کند. برای مشاهدهٔ تمام سطح API ‎Android از طریق Java، به مرجع API [com.aspose.slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) مراجعه کنید.

{{% alert color="info" title="Inheritance" %}}
زمانی که همان ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید طرح‌بندی هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن طرح‌بندی از پس‌زمینهٔ طرح‌بندی استفاده می‌کنند. برای اطلاعات بیشتر دربارهٔ اسلایدهای طرح‌بندی، به [Apply or Change Slide Layouts](/slides/fa/androidjava/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint، می‌توانید نمای اسلاید مستر را از **View** > **Slide Master** باز کنید.

![دستور اسلاید مستر در زبانهٔ View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به اسلایدهای مستر از مجموعه `getMasters()` استفاده کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید اسلاید مستری که یک اسلاید عادی از آن استفاده می‌کند را از طریق طرح‌بندی‌اش به دست آورید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **محتویات یک اسلاید مستر**

یک اسلاید مستر یک شیء شبیه اسلاید است. این شیء رابط [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از ویژگی‌های اسلایدی که توسط اسلایدهای عادی و طرح‌بندی استفاده می‌شود، در دسترس است.

اعضای معمولاً استفاده‑شدهٔ اسلاید مستر شامل موارد زیر هستند:

| Member | Purpose |
| --- | --- |
| `getBackground()` | پس‌زمینهٔ اسلاید در سطح مستر را تنظیم می‌کند. |
| `getShapes()` | اشکالی که بر روی مستر قرار گرفته‌اند، مانند لوگوها، قاب‌های تصویر و متن‌های مشترک، را ذخیره می‌کند. |
| `getLayoutSlides()` | اسلایدهای طرح‌بندی وابسته به این مستر را نگه می‌دارد. |
| `getThemeManager()` | دسترسی به APIهای تم مستر را فراهم می‌کند. |
| `getHeaderFooterManager()` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شمارهٔ اسلایدها را برای مستر و طرح‌بندی‌های فرزندش کنترل می‌کند. |
| `getDependingSlides()` | اسلایدهای عادی که از طریق طرح‌بندی‌ها به این مستر وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری را به یک اسلاید مستر اضافه می‌کنید، آن تصویر در اسلایدهایی که از طرح‌بندی‌های آن مستر استفاده می‌کنند، ظاهر می‌شود. این کار برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر لوگویی را به اولین اسلاید مستر اضافه می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای اطلاعات بیشتر دربارهٔ قاب‌های تصویر، به [Picture Frame](/slides/fa/androidjava/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های مستر**

از [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) برای مخفی کردن گرافیک‌های ارث‌بردهٔ مستر، مانند لوگوها یا اشکال تزئینی، بدون حذف آن‌ها از مستر استفاده کنید. مقدار `false` را به [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) در اسلایدی که می‌خواهید این گرافیک‌ها را حذف کند، بدهید و در اسلایدهایی که می‌خواهید نمایش داده شوند مقدار `true` را نگه دارید.

مثال زیر یک نوار تزئینی آبی را بر روی یک مستر و دو اسلایدی که از همان طرح‌بندی خالی استفاده می‌کنند، ایجاد می‌کند. این نوار در اسلاید اول قابل مشاهده و در اسلاید دوم مخفی است. نیازی به ارائهٔ ورودی یا تصویر نیست.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این مثال از طرح‌بندی **Blank** که همراه یک ارائهٔ جدید ارائه می‌شود استفاده می‌کند و نگهدارنده‌های اولیهٔ اسلاید را حذف می‌کند.

### **انتخاب دامنهٔ تنظیم**

یک اسلاید عادی از مستر خود از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getLayoutSlide--) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) استفاده می‌کند. تنظیم این ویژگی در یک اسلاید منفرد فقط بر همان اسلاید اثر می‌گذارد. مقدار `false` را به [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) پاس دهید تا گرافیک‌های مستر برای اسلایدهایی که از آن طرح‌بندی مشترک استفاده می‌کنند مخفی شوند، حتی اگر تنظیم شخصی آن‌ها `true` باشد. برای مخفی کردن گرافیک‌ها فقط در یک اسلاید، ویژگی اسلاید را تغییر دهید و طرح‌بندی مشترک را دست‌نخورده بگذارید.

این تنظیم به‌عنوان کنترل وضوح در خود اسلاید مستر پشتیبانی نمی‌شود. در یک مستر، [getShowMasterShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) همیشه `false` برمی‌گرداند و پاس دادن `true` به [setShowMasterShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) باعث بروز استثنا می‌شود. این روش را بر روی اسلاید عادی یا یک طرح‌بندی اعمال کنید.

### **تمایز گرافیک‌ها از پس‌زمینه**

| Operation | Effect |
| --- | --- |
| Hide master graphics | نمایش گرافیک‌های ارث‌بردهٔ مستر را بدون حذف آن‌ها یا تغییر اشکال خود اسلاید کنترل می‌کند. |
| Change the slide background fill | رنگ، گرادیان یا تصویر پس‌زمینه را تغییر می‌دهد. گرافیک‌های مستر اشکال جداگانه‌ای هستند و می‌توانند بر روی آن پس‌زمینه همچنان قابل مشاهده باشند. برای اطلاعات بیشتر به [Presentation Background](/slides/fa/androidjava/presentation-background/) مراجعه کنید. |
| Delete a shape from the master | شکل منبع مشترک را حذف می‌کند، به‌طوری‌که دیگر در هیچ اسلایدی که از آن مستر استفاده می‌کند در دسترس نیست. |

## **کار با نگهدارنده‌ها**

نگهدارنده‌ها معمولاً در اسلایدهای طرح‌بندی تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را که این طرح‌بندی‌ها از آن ارث می‌برند، فراهم می‌کند، در حالی که هر طرح‌بندی تصمیم می‌گیرد کدام نگهدارنده‌ها در دسترس هستند و در کجا قرار گیرند.

در PowerPoint، دستورات نگهدارنده‌ها در نمای اسلاید مستر قابل دسترسی هستند.

![دستور Insert Placeholder در نمای اسلاید مستر PowerPoint](slide-master_5.png)

برای افزودن نگهدارنده‌های جدید با Aspose.Slides، با اسلاید طرح‌بندی که به مستر تعلق دارد کار کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید اشکال نگهدارنده‌ای که از پیش بر روی یک اسلاید مستر وجود دارند را قالب‌بندی کنید. مثال زیر نگهدارندهٔ عنوان را پیدا می‌کند و پر شدن گرادیان خطی را به آن اعمال می‌نماید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نگهدارندهٔ عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی ارث‌برده می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر مربوط به نگهدارنده‌ها و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/slides/fa/androidjava/manage-placeholder/) و [Text Formatting](/slides/fa/androidjava/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ اسلاید مستر**

پس‌زمینهٔ مستر توسط طرح‌بندی‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، ارث‌برده می‌شود. مثال زیر یک رنگ پس‌زمینهٔ ثابت را برای اولین اسلاید مستر تنظیم می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/androidjava/presentation-background/) و [Presentation Theme](/slides/fa/androidjava/presentation-theme/) نگاه کنید.

## **کپی اسلاید مستر به ارائه‌ای دیگر**

از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) برای کپی یک اسلاید مستر به ارائهٔ دیگری استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط طرح‌بندی‌ها و اسلایدهای مقصد استفاده شود.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

اگر نیاز دارید اسلایدهای عادی را همراه با مسترشان کپی کنید، به [Clone Slides](/slides/fa/androidjava/clone-slides/) مراجعه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این ویژگی زمانی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![دستورات PowerPoint برای درج و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کپی می‌کند، پس‌زمینهٔ کپی را متفاوت می‌سازد، یک طرح‌بندی زیر آن مستر کپی‌شده ایجاد می‌کند و یک اسلاید جدید بر پایهٔ آن طرح‌بندی می‌افزاید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مقایسه اسلایدهای مستر**

اسلایدهای مستر می‌توانند با متد `equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) ارث‌بری می‌شود، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به‌فرد مانند شناسهٔ اسلاید یا مقادیر دینامیک نگهدارنده‌ها مانند تاریخ جاری را در نظر نمی‌گیرد.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

برای اطلاعات بیشتر به [Compare Presentation Slides](/slides/fa/androidjava/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به‌عنوان نمای پیش‌فرض**

از متد `setLastView` در [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/androidjava/save-presentation/) نگاه کنید.

## **حذف اسلایدهای مستر غیر استفاده‌شده**

گاهی ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید عادی استفاده نمی‌شوند. حذف مسترهای غیر استفاده‌شده می‌تواند اندازهٔ فایل را کاهش داده و نگهداری قالب‌ها را ساده‌تر کند.

از `removeUnused` برای حذف مسترهای غیر استفاده‌شده از مجموعه `getMasters()` استفاده کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید از متد کم‌کد [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) استفاده کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**تفاوت اسلاید مستر و اسلاید طرح‌بندی چیست؟**

اسلاید مستر تنظیمات طراحی مشترکی مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. اسلاید طرح‌بندی متعلق به یک اسلاید مستر است و ترتیب خاصی از نگهدارنده‌ها را تعریف می‌کند. یک اسلاید عادی از یک اسلاید طرح‌بندی استفاده می‌کند، بنابراین از هر دو طرح‌بندی و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. زمانی که بخش‌های مختلف به سیستم‌های بصری یا برندینگ متفاوتی نیاز دارند، از مسترهای متعدد استفاده کنید.

**آیا باید نگهدارنده‌ها را به اسلاید مستر یا اسلاید طرح‌بندی اضافه کنم؟**

در اکثر موارد، نگهدارنده‌ها را به اسلایدهای طرح‌بندی اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را بر روی اسلاید مستر بگذارید و سپس نگهدارنده‌های محتوا را بر روی طرح‌بندی‌هایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

نه. اسلاید مستری که اسلایدهای وابسته دارد، نمی‌تواند به‌طور مستقیم حذف شود. ابتدا آن اسلایدها را به طرح‌بندی‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده که فقط مسترهای بدون استفاده را حذف می‌کند، استفاده کنید.