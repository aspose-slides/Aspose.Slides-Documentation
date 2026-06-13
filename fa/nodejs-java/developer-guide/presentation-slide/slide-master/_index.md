---
title: مدیریت اسلاید مسترهای ارائه در JavaScript
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/nodejs-java/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر چندگانه
- مقایسه اسلایدهای مستر
- پس‌زمینه
- محل‌نگهدار
- کپی اسلاید مستر
- رونوشت اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر غیرقابل استفاده
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای Node.js از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات فوتر باشد. در PowerPoint، ویرایش یک slide master روش معمول برای حفظ سازگاری ارائه بدون تکرار قالب‌بندی مشابه در هر اسلاید است.

Aspose.Slides برای Node.js از طریق Java از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند slide master داشته باشد و هر slide master می‌تواند شامل چندین layout slide باشد. اسلایدهای عادی معمولاً مستقیماً به یک slide master ارجاع نمی‌دهند. در عوض، یک اسلاید عادی از یک layout slide استفاده می‌کند و آن layout slide متعلق به یک slide master است.

ساختار به صورت زیر است:

1. **Slide master** – طرح و تم مشترک را تعریف می‌کند.  
1. **Layout slide** – ترکیب خاصی از placeholders و قالب‌بندی سطح layout را تعریف می‌کند.  
1. **Normal slide** – محتوای واقعی ارائه را شامل می‌شود و از یک layout slide استفاده می‌کند.

![سلسله مراتب slide master‌ها، layout slide‌ها و اسلایدهای عادی](slide-master_2.jpg)

در Aspose.Slides، یک slide master توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) نمایندگی می‌شود. تمام slide master‌های موجود در یک ارائه از طریق مجموعه `Presentation.getMasters()` در دسترس هستند.

{{% alert color="info" title="ارث‌بری" %}}

زمانی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. برای مثال، اگر یک slide master و یک layout slide هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره layout slide‌ها، به [اعمال یا تغییر طرح‌های اسلاید](/nodejs-java/slide-layout/) مراجعه کنید.

{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دستورات Slide Master در برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به slide master‌ها از مجموعه `getMasters()` استفاده کنید:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید slide master مورد استفاده توسط یک اسلاید عادی را از طریق layout آن به‌دست آورید:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **محتویات یک Slide Master**

یک slide master یک شیء شبیه اسلاید است. این شیء رفتار عمومی اسلایدها را از [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/) به ارث می‌برد، بنابراین بسیاری از ویژگی‌های اسلاید که در اسلایدهای عادی و layout استفاده می‌شوند، در دسترس است. اعضای خاص master در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) فهرست شده‌اند.

عضوهای معمولاً استفاده‌شده‌ی slide master شامل:

| Member | Purpose |
| --- | --- |
| `getBackground()` | پس‌زمینه سطح master را تنظیم می‌کند. |
| `getShapes()` | اشکالی که بر روی master قرار گرفته‌اند (مانند لوگوها، فریم‌های تصویر و متن مشترک) را ذخیره می‌کند. |
| `getLayoutSlides()` | layout slide‌های متعلق به master را ذخیره می‌کند. |
| `getThemeManager()` | دسترسی به API‌های تم master را فراهم می‌کند. |
| `getHeaderFooterManager()` | سرصفحه‌ها، پانویس‌ها، تاریخ‌ها و شماره‌های اسلاید برای master و layoutهای فرزندی آن را کنترل می‌کند. |
| `getDependingSlides()` | اسلایدهای عادی که از طریق layout به master وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به Slide Master**

وقتی یک تصویر را به یک slide master اضافه می‌کنید، در اسلایدهایی که از layout‌های آن master استفاده می‌کنند، نمایش داده می‌شود. این قابلیت برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین slide master اضافه می‌کند:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/nodejs-java/picture-frame/) مراجعه کنید.

## **کار با Placeholders**

Placeholders معمولاً در layout slide‌ها تعریف می‌شوند. slide master سبک و تم مشترکی را فراهم می‌کند که layoutها از آن ارث می‌برند، در حالی که هر layout تصمیم می‌گیرد کدام placeholders در دسترس هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات placeholders در نمای Slide Master موجود است.

![دستور Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای افزودن placeholders جدید با Aspose.Slides، با layout slideی که به master تعلق دارد کار کنید:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید اشکال placeholderهایی که از پیش بر روی یک slide master وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را پیدا کرده و یک پرکن خطی گرادیان اعمال می‌کند:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![placeholder عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی به ارث می‌رسد](slide-master_8.png)

برای گزینه‌های بیشتر مربوط به placeholders و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) و [Text Formatting](/nodejs-java/text-formatting/) نگاه کنید.

## **تغییر پس‌زمینه Slide Master**

پس‌زمینه master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر یک رنگ پس‌زمینه ثابت برای اولین slide master تنظیم می‌کند:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای موضوعات مرتبط، به [Presentation Background](/nodejs-java/presentation-background/) و [Presentation Theme](/nodejs-java/presentation-theme/) مراجعه کنید.

## **کپی کردن Slide Master به ارائه‌ای دیگر**

از `MasterSlideCollection.addClone` برای کپی کردن یک slide master به ارائه‌ای دیگر استفاده کنید. master کپی‌شده سپس می‌تواند توسط layoutها و اسلایدهای مقصد استفاده شود.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

اگر نیاز دارید اسلایدهای عادی را به همراه masterشان کپی کنید، به [Clone Slides](/nodejs-java/clone-slides/) مراجعه کنید.

## **افزودن چندین Slide Master**

یک ارائه می‌تواند شامل چندین slide master باشد. این ویژگی برای بخش‌های مختلف که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی دارند، مفید است.

![دستورات PowerPoint برای وارد کردن و مدیریت slide master‌ها](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کپی می‌کند، به کپی پس‌زمینه‌ای متفاوت می‌دهد، یک layout تحت آن master کپی‌شده ایجاد می‌کند و یک اسلاید جدید بر پایه آن layout اضافه می‌کند:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مقایسه Slide Masters**

slide master‌ها می‌توانند با متد `equals` که از [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/) به ارث برده شده است مقایسه شوند. مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به‌فرد مانند slide IDها یا مقادیر پویا مانند تاریخ جاری را مقایسه نمی‌کند.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

برای اطلاعات بیشتر، به [Compare Presentation Slides](/nodejs-java/compare-slides/) نگاه کنید.

## **تنظیم Slide Master View به‌عنوان نمای پیش‌فرض**

از متد `setLastView` روی [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیمات بیشتر نمایی، به [Save Presentation](/nodejs-java/save-presentation/) مراجعه کنید.

## **حذف Slide Masterهای غیرقابل استفاده**

گاهی اوقات ارائه‌ها شامل slide masterهایی هستند که دیگر توسط هیچ اسلاید عادی استفاده نمی‌شوند. حذف masterهای غیرقابل استفاده می‌تواند اندازه فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از `removeUnused` برای حذف masterهای غیرقابل استفاده از مجموعه `getMasters()` استفاده کنید:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید از متد کم‌کد `Compress.removeUnusedMasterSlides` استفاده کنید:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**تفاوت slide master و layout slide چیست؟**

یک slide master تنظیمات طراحی مشترک مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. یک layout slide متعلق به یک slide master است و ترکیب خاصی از placeholders را تعریف می‌کند. یک اسلاید عادی از یک layout slide استفاده می‌کند، بنابراین هم از layout و هم از master ارث می‌برد.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین slide master باشد. هنگام نیاز به سیستم‌های بصری یا برندینگ متفاوت برای بخش‌های مختلف، از چندین master استفاده کنید.

**آیا باید placeholders را به slide master اضافه کنم یا به layout slide؟**

در اکثر موارد placeholders را به layout slide‌ها اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را بر روی slide master بگذارید و placeholders محتوا را بر روی layoutهایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم یک slide master که هنوز استفاده می‌شود را حذف کنم؟**

نه. یک slide master که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به layoutهای زیر master دیگری منتقل کنید یا از روش پاک‌سازی masterهای غیرقابل استفاده استفاده کنید که فقط masterهایی را حذف می‌کند که در استفاده نیستند.