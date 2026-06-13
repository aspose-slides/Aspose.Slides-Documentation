---
title: "مدیریت اسلاید مسترهای ارائه در جاوا"
linktitle: "اسلاید مستر"
type: docs
weight: 70
url: /fa/java/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر چندگانه
- مقایسه اسلایدهای مستر
- پس‌زمینه
- مکان‌گیر
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر بدون استفاده
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت اسلاید مستרها در Aspose.Slides برای جاوا: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک برای یک گروه از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها, پس‌زمینه‌ها, سبک‌های متنی, تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک slide master معمولاً روشی برای حفظ ثبات یک ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for Java همان مدل را پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید master داشته باشد و هر اسلاید master می‌تواند چندین اسلاید layout را شامل شود. اسلایدهای عادی معمولاً به‌طور مستقیم به اسلاید master ارجاع نمی‌دهند. در عوض، یک اسلاید عادی از یک اسلاید layout استفاده می‌کند و آن اسلاید layout به یک اسلاید master تعلق دارد.

سلسله‌مراتب به شرح زیر است:

1. **Slide master** – طراحی مشترک و تم را تعریف می‌کند.  
1. **Layout slide** – یک ترتیب خاص از مکان‌گیرها و قالب‌بندی در سطح طرح را تعریف می‌کند.  
1. **Normal slide** – شامل محتوای واقعی ارائه است و از یک layout slide استفاده می‌کند.

![سلسله‌مراتب اسلایدهای master، اسلایدهای layout و اسلایدهای normal](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید master توسط رابط [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) نشان داده می‌شود. تمام اسلایدهای master در یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasters--) در دسترس هستند که پیاده‌سازی [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) را دارد.

{{% alert color="info" title="ارث‌بری" %}}
زمانی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید master و یک اسلاید layout هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای layout، به [Apply or Change Slide Layouts](/slides/fa/java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masterها**

در PowerPoint می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دستور Slide Master در برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides از مجموعه `getMasters()` برای دسترسی به اسلایدهای master استفاده کنید:

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

همچنین می‌توانید اسلاید master استفاده‌شده توسط یک اسلاید عادی را از طریق layout آن دریافت کنید:

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

## **محتویات یک Slide Master**

یک اسلاید master یک شیء شبیه اسلاید است. این شیء رابط [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از ویژگی‌های اسلاید که برای اسلایدهای عادی و layout استفاده می‌شود را در اختیار می‌گذارد. اعضای اختصاصی master در صفحه API [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) فهرست شده‌اند.

عضوهای معمولاً استفاده‌شده master عبارتند از:

| عضو | هدف |
| --- | --- |
| `getBackground()` | پس‌زمینه اسلاید در سطح master را تنظیم می‌کند. |
| `getShapes()` | اشکالی که بر روی master قرار گرفته‌اند، مانند لوگوها، قاب‌های تصویر و متن مشترک، را ذخیره می‌کند. |
| `getLayoutSlides()` | اسلایدهای layout متعلق به master را ذخیره می‌کند. |
| `getThemeManager()` | دسترسی به APIهای تم master را فراهم می‌کند. |
| `getHeaderFooterManager()` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها را برای master و layoutهای فرزند آن کنترل می‌کند. |
| `getDependingSlides()` | اسلایدهای normalی که از طریق layoutهای خود به master وابسته هستند را بر می‌گرداند. |

## **افزودن تصویر به یک Slide Master**

زمانی که تصویری را به یک اسلاید master اضافه کنید، بر روی اسلایدهایی که از layoutهای آن master استفاده می‌کنند ظاهر می‌شود. این برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید master اضافه می‌کند:

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

برای اطلاعات بیشتر درباره قاب‌های تصویر، به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید.

## **کار با Placeholders**

Placeholders معمولاً در اسلایدهای layout تعریف می‌شوند. اسلاید master سبک و تم مشترکی را فراهم می‌کند که این layoutها ارث‌بری می‌کنند، در حالی که هر layout تصمیم می‌گیرد کدام placeholders موجود باشد و در کجا قرار گیرند.

در PowerPoint دستورات placeholder در نمای Slide Master در دسترس هستند.

![دستور Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای افزودن placeholders جدید با Aspose.Slides، با اسلاید layout که به master تعلق دارد کار کنید:

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

همچنین می‌توانید اشکال placeholder که قبلاً بر روی یک اسلاید master وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را پیدا کرده و یک پرکن خطی گرادیان اعمال می‌کند:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![placeholder عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی ارث‌بری می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر درباره placeholders و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/slides/fa/java/manage-placeholder/) و [Text Formatting](/slides/fa/java/text-formatting/) نگاه کنید.

## **تغییر پس‌زمینه یک Slide Master**

پس‌زمینه master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر یک رنگ پس‌زمینه‌ی ثابت برای اولین اسلاید master تنظیم می‌کند:

```java
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

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/java/presentation-background/) و [Presentation Theme](/slides/fa/java/presentation-theme/) مراجعه کنید.

## **کپی کردن یک Slide Master به ارائه‌ای دیگر**

از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) برای کپی کردن یک اسلاید master به ارائه‌ای دیگر استفاده کنید. master کپی‌شده سپس می‌تواند توسط layoutها و اسلایدهای مقصد استفاده شود.

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

اگر نیاز به کپی کردن اسلایدهای عادی همراه با master آن‌ها دارید، به [Clone Slides](/slides/fa/java/clone-slides/) مراجعه کنید.

## **افزودن چندین Slide Master**

یک ارائه می‌تواند شامل چندین اسلاید master باشد. این برای بخش‌های مختلفی که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی دارند، مفید است.

![دستورات PowerPoint برای وارد کردن و مدیریت اسلایدهای master](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کپی می‌کند، به کپی پس‌زمینه‌ای متفاوت می‌دهد، یک layout تحت آن master کپی‌شده می‌سازد و یک اسلاید جدید بر پایه آن layout اضافه می‌کند:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **مقایسه Slide Masterها**

اسلایدهای master می‌توانند با متد `equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) ارث‌بری می‌شود مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و تنظیمات دیگر اسلاید را بررسی می‌کند. شناسه‌های منحصربه‌فرد مانند شناسه اسلاید یا مقادیر پویا مانند تاریخ جاری را مقایسه نمی‌کند.

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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/java/compare-slides/) مراجعه کنید.

## **تنظیم نمای Slide Master به‌عنوان نمای پیش‌فرض**

از متد `setLastView` در [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/java/save-presentation/) نگاه کنید.

## **حذف اسلایدهای Master استفاده‌نشده**

گاهی ارائه‌ها شامل اسلایدهای master می‌شوند که دیگر توسط هیچ اسلاید عادی استفاده نمی‌شوند. حذف masterهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری قالب‌ها را ساده‌تر کند.

از `removeUnused` برای حذف masterهای استفاده‌نشده از مجموعه `getMasters()` استفاده کنید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید از متد کم‌کد [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) استفاده کنید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**فرق بین slide master و layout slide چیست؟**

یک slide master تنظیمات طراحی مشترک مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متنی را تعریف می‌کند. یک layout slide به یک اسلاید master تعلق دارد و چینش خاصی از مکان‌گیرها را تعریف می‌کند. یک اسلاید عادی از یک layout slide استفاده می‌کند، بنابراین هم از layout و هم از master ارث‌بری می‌کند.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند چندین slide master داشته باشد. هنگام نیاز به سیستم‌های بصری یا برندینگ متفاوت برای بخش‌های مختلف، از masterهای متعدد استفاده کنید.

**آیا باید placeholders را به یک اسلاید master یا یک اسلاید layout اضافه کنم؟**

در اغلب موارد، placeholders را به اسلایدهای layout اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را روی اسلاید master بگذارید و سپس placeholders محتوا را روی layoutهایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم یک اسلاید master که هنوز استفاده می‌شود را حذف کنم؟**

خیر. اسلاید master که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به layoutهای زیر یک master دیگر منتقل کنید یا از روش پاک‌سازی masterهای استفاده‌نشده استفاده کنید که فقط masterهایی را حذف می‌کند که در حال حاضر استفاده نمی‌شوند.