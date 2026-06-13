---
title: مدیریت مسترهای اسلاید ارائه در اندروید
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/androidjava/slide-master/
keywords:
- اسلاید مستر
- مستر اسلاید
- مستر اسلاید PPT
- چندین اسلاید مستر
- مقایسه اسلایدهای مستر
- پس‌زمینه
- فاصله‌نگهدار
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر بلااستفاده
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای Android از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک را برای یک گروه از اسلایدها تعریف می‌کند. می‌تواند شامل شکل‌های مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات فوتر باشد. در PowerPoint، ویرایش اسلاید مستر روش معمول برای حفظ یکنواختی ارائه بدون تکرار قالب‌بندی در هر اسلاید است.

Aspose.Slides برای Android از طریق Java از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند حاوی یک یا چند اسلاید مستر باشد و هر اسلاید مستر می‌تواند چندین اسلاید چیدمان داشته باشد. اسلایدهای عادی معمولاً مستقیماً به اسلاید مستر ارجاع نمی‌دهند؛ بلکه یک اسلاید عادی از یک اسلاید چیدمان استفاده می‌کند و آن چیدمان متعلق به یک اسلاید مستر است.

سلسله مراتب به صورت زیر است:

1. **اسلاید مستر** – طراحی و تم مشترک را تعیین می‌کند.  
1. **اسلاید چیدمان** – چینش خاصی از فضا نگهدارها و قالب‌بندی در سطح چیدمان را تعریف می‌کند.  
1. **اسلاید عادی** – محتوای واقعی ارائه را شامل می‌شود و از یک اسلاید چیدمان استفاده می‌کند.

![سلسله مراتب اسلایدهای مستر، چیدمان و عادی](slide-master_2.jpg)

در Aspose.Slides، اسلاید مستر توسط اینترفیس [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) نمایش داده می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getMasters--) در دسترس هستند که اینترفیس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) را پیاده‌سازی می‌کند. برای مشاهده کل سطح API Android از طریق Java، به مرجع API [com.aspose.slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) مراجعه کنید.

{{% alert color="info" title="ارث‌بری" %}}

هنگامی که یک ویژگی در بیش از یک سطح تعریف شود، سطح دقیق‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید چیدمان هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن چیدمان از پس‌زمینه چیدمان استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای چیدمان، به [Apply or Change Slide Layouts](/slides/fa/androidjava/slide-layout/) مراجعه کنید.

{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint می‌توانید نمای اسلاید مستر را از **View > Slide Master** باز کنید.

![دکمه Slide Master در تب View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، از مجموعه `getMasters()` برای دسترسی به اسلایدهای مستر استفاده کنید:

```java
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

همچنین می‌توانید اسلاید مستری که یک اسلاید عادی از آن استفاده می‌کند، از طریق چیدمان آن دریافت کنید:

```java
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

## **آنچه یک اسلاید مستر شامل می‌شود**

اسلاید مستر شیئی شبیه اسلاید است. این شیء اینترفیس [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از ویژگی‌های اسلایدی که توسط اسلایدهای عادی و چیدمان استفاده می‌شود، در دسترس است.

اعضای متداول اسلاید مستر عبارتند از:

| Member | Purpose |
| --- | --- |
| `getBackground()` | تنظیم پس‌زمینه سطح مستر اسلاید. |
| `getShapes()` | ذخیره شکل‌هایی که روی مستر قرار گرفته‌اند، مانند لوگوها، فریم‌های تصویر و متن‌های مشترک. |
| `getLayoutSlides()` | ذخیره اسلایدهای چیدمان متعلق به مستر. |
| `getThemeManager()` | دسترسی به APIهای تم مستر. |
| `getHeaderFooterManager()` | کنترل سرصفحه‌ها، پاصفحه‌ها، تاریخ‌ها و شماره‌ اسلایدها برای مستر و چیدمان‌های فرزند. |
| `getDependingSlides()` | بازگرداندن اسلایدهای عادی که از طریق چیدمان‌های خود به مستر وابسته هستند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری به اسلاید مستر اضافه می‌کنید، بر روی اسلایدهایی که از چیدمان‌های آن مستر استفاده می‌کنند نشان داده می‌شود. این برای لوگوها، واترمارک‌ها، باندهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

```java
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

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/slides/fa/androidjava/picture-frame/) مراجعه کنید.

## **کار با فضا نگهدارها**

فضا نگهدارها عموماً در اسلایدهای چیدمان تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را فراهم می‌کند که چیدمان‌ها از آن ارث می‌ببرند، در حالی که هر چیدمان تصمیم می‌گیرد کدام فضا نگهدارها در دسترس هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات فضا نگهدار در نمای اسلاید مستر موجود است.

![دستور Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای افزودن فضا نگهدارهای جدید با Aspose.Slides، بر روی اسلاید چیدمانی که به مستر تعلق دارد کار کنید:

```java
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

همچنین می‌توانید شکل‌های فضا نگهدار موجود در یک اسلاید مستر را قالب‌بندی کنید. مثال زیر فضا نگهدار عنوان را پیدا کرده و یک پر کردن گرادیان خطی اعمال می‌کند:

```java
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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

![فضا نگهدار عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی به ارث برده می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر فضا نگهدار و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/slides/fa/androidjava/manage-placeholder/) و [Text Formatting](/slides/fa/androidjava/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه اسلاید مستر**

یک پس‌زمینه مستر توسط چیدمان‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، ارث بری می‌شود. مثال زیر یک رنگ پس‌زمینه یکدست برای اولین اسلاید مستر تنظیم می‌کند:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/androidjava/presentation-background/) و [Presentation Theme](/slides/fa/androidjava/presentation-theme/) مراجعه کنید.

## **کلون کردن اسلاید مستر به ارائه دیگر**

از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) برای کپی یک اسلاید مستر به ارائه دیگری استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط چیدمان‌ها و اسلایدهای مقصد استفاده شود.

```java
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

اگر نیاز به کلون کردن اسلایدهای عادی به همراه مستر آن‌ها دارید، به [Clone Slides](/slides/fa/androidjava/clone-slides/) نگاه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. این برای بخش‌های مختلفی که به برندینگ، ساختار صفحه یا تنظیمات تم متفاوت نیاز دارند مفید است.

![دستورات PowerPoint برای درج و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه‌ای متفاوت می‌دهد، یک چیدمان زیر آن مستر کلون‌شده ایجاد می‌کند و اسلاید جدیدی بر پایه آن چیدمان اضافه می‌کند:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

اسلایدهای مستر می‌توانند با متد `equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) به ارث برده شده مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به فرد مانند شناسه اسلاید یا مقادیر پویا مثل تاریخ فعلی در مقایسه در نظر گرفته نمی‌شوند.

```java
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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/androidjava/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به عنوان نمای پیش‌فرض**

از متد `setLastView` بر روی [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیمات نمای بیشتر، به [Save Presentation](/slides/fa/androidjava/save-presentation/) نگاهی بیندازید.

## **حذف اسلایدهای مستر بلااستفاده**

گاهی ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید عادی استفاده نمی‌شوند. حذف مسترهای بلااستفاده می‌تواند حجم فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از `removeUnused` برای حذف مسترهای بلااستفاده از مجموعه `getMasters()` استفاده کنید:

```java
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
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤال‌های متداول**

**تفاوت اسلاید مستر و اسلاید چیدمان چیست؟**

اسلاید مستر تنظیمات طراحی مشترک مانند تم، پس‌زمینه، شکل‌های عمومی و سبک‌های متن را تعیین می‌کند. اسلاید چیدمان به یک اسلاید مستر تعلق دارد و چینش خاصی از فضا نگهدارها را تعریف می‌کند. یک اسلاید عادی از یک اسلاید چیدمان استفاده می‌کند، بنابراین از هر دو چیدمان و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. هنگامی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی دارند، از چند مستر استفاده کنید.

**آیا فضا نگهدارها را باید به اسلاید مستر یا اسلاید چیدمان اضافه کنم؟**

در اکثر موارد فضا نگهدارها را به اسلایدهای چیدمان اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را در مستر بگذارید، سپس فضا نگهدارهای محتوایی را در چیدمان‌هایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

خیر. اسلاید مستری که اسلایدهای وابسته دارد، به‌صورت مستقیم قابل حذف نیست. ابتدا آن اسلایدها را به چیدمان‌های زیر مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای بلااستفاده استفاده کنید که فقط مسترهای بدون استفاده را حذف می‌کند.