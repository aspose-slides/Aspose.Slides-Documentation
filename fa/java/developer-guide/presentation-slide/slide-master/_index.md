---
title: مدیریت اسلایدهای مستر در Java
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/java/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر متعدد
- مقایسه اسلایدهای مستر
- پس‌زمینه
- جای‌گیر
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر نااستفاده
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک را برای یک گروه از اسلایدها تعریف می‌کند. می‌تواند شامل اشکال مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک slide master معمول‌ترین روش برای حفظ سازگاری یک ارائه بدون تکرار قالب‌بندی در هر اسلاید است.

Aspose.Slides for Java از همین مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند master slide داشته باشد و هر master slide می‌تواند چند layout slide داشته باشد. اسلایدهای عادی معمولاً به‌صورت مستقیم به یک master slide ارجاع نمی‌دهند. در عوض، یک اسلاید عادی از یک layout slide استفاده می‌کند و آن layout slide متعلق به یک master slide است.

سلسله‌مراتبی به شرح زیر است:

1. **Slide master** - تنظیمات طراحی و تم مشترک را تعریف می‌کند.  
1. **Layout slide** - چیدمان خاصی از جای‌گیرها و قالب‌بندی‌های سطح layout را تعریف می‌کند.  
1. **Normal slide** - محتوای واقعی ارائه را شامل می‌شود و از یک layout slide استفاده می‌کند.

![سلسله‌مراتب اسلایدهای اصلی، اسلایدهای طرح‌بندی و اسلایدهای عادی](slide-master_2.jpg)

در Aspose.Slides، یک slide master با رابط [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) نمایان می‌شود. همه master slideهای یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasters--) در دسترس هستند که پیاده‌سازی‌کننده‌ی [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) است.

{{% alert color="info" title="Inheritance" %}}
هنگامی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. برای مثال، اگر یک master slide و یک layout slide هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره layout slideها، به [Apply or Change Slide Layouts](/slides/fa/java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دکمه Slide Master در نوار برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به master slideها از مجموعه `getMasters()` استفاده کنید:

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

همچنین می‌توانید master slide استفاده‌شده توسط یک اسلاید عادی را از طریق layout آن به‌دست آورید:

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

## **محتویات یک Slide Master**

یک master slide یک شیء شبیه اسلاید است. این شیء رابط [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از خصوصیات اسلایدی که توسط اسلایدهای عادی و layout استفاده می‌شود را در اختیار می‌گذارد. اعضای اختصاصی master در صفحه API [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) فهرست شده‌اند.

عضوهای معمولاً مورد استفاده در master slide عبارتند از:

| Member | Purpose |
| --- | --- |
| `getBackground()` | تنظیم پس‌زمینهٔ اسلاید در سطح master. |
| `getShapes()` | نگهداری اشکالی که بر روی master قرار گرفته‌اند، مانند لوگوها، فریم‌های تصویر و متن‌های مشترک. |
| `getLayoutSlides()` | نگهداری layout slideهایی که به این master تعلق دارند. |
| `getThemeManager()` | دسترسی به APIهای تم master. |
| `getHeaderFooterManager()` | مدیریت سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها برای master و layoutهای فرزند. |
| `getDependingSlides()` | برگرداندن اسلایدهای عادی که از طریق layoutهای خود به این master وابسته هستند. |

## **افزودن تصویر به Slide Master**

زمانی که یک تصویر را به یک master slide اضافه می‌کنید، در اسلایدهایی که از layoutهای آن master استفاده می‌کنند ظاهر می‌شود. این کار برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین master slide اضافه می‌کند:

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

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های Master**

از [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) برای پنهان‌کردن گرافیک‌های ارث‌برده‌شده از master، مانند لوگوها یا اشکال تزئینی، بدون حذف آن‌ها از master استفاده کنید. مقدار `false` را به [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) در اسلایدی که باید این گرافیک‌ها حذف شوند، بدهید و در اسلایدهایی که باید نمایش داده شوند مقدار `true` بگذارید.

مثال زیر یک نوار تزئینی آبی رنگ را روی یک master و دو اسلایدی که از همان layout خالی استفاده می‌کنند، ایجاد می‌کند. این نوار در اسلاید اول قابل مشاهده و در اسلاید دوم مخفی است. نیازی به ارائه ورودی یا تصویر نیست.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

این مثال از layout **Blank** عرضه‌شده با یک ارائهٔ جدید استفاده می‌کند و جای‌گیرهای اولیه اسلاید را حذف می‌کند.

### **انتخاب دامنهٔ تنظیم**

یک اسلاید عادی از master خود از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getLayoutSlide--) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) استفاده می‌کند. تنظیم این ویژگی بر روی یک اسلاید منفرد فقط آن اسلاید را تحت تأثیر قرار می‌دهد. مقدار `false` را به [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) پاس می‌دهد تا گرافیک‌های master برای اسلایدهایی که از آن layout مشترک استفاده می‌کنند، پنهان شود، حتی اگر تنظیم خود اسلایدها `true` باشد. برای پنهان‌کردن گرافیک فقط در یک اسلاید، ویژگی اسلاید را تغییر دهید و layout مشترک را دست‌نخورده بگذارید.

این تنظیم به‌عنوان کنترل نمایش بر روی خود master slide پشتیبانی نمی‌شود. در یک master، [getShowMasterShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/#getShowMasterShapes--) همیشه `false` برمی‌گرداند و مقدار `true` را به [setShowMasterShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) پاس دادن منجر به استثنا می‌شود. این متد را بر روی اسلاید عادی یا layout اعمال کنید.

### **تفاوت گرافیک‌ها از پس‌زمینه**

| Operation | Effect |
| --- | --- |
| Hide master graphics | نمایش گرافیک‌های ارث‌برده‌شده از master را بدون حذف آن‌ها یا تغییر اشکال اسلاید خود کنترل می‌کند. |
| Change the slide background fill | رنگ، گرادیان یا تصویر پس‌زمینه را تغییر می‌دهد. گرافیک‌های master شکل‌های جداگانه‌ای هستند و می‌توانند بر روی آن پس‌زمینه قابل مشاهده بمانند. برای جزئیات بیشتر به [Presentation Background](/slides/fa/java/presentation-background/) مراجعه کنید. |
| Delete a shape from the master | شکل منبع مشترک را حذف می‌کند، بنابراین برای هیچ اسلایدی که از آن master استفاده می‌کند، دیگر در دسترس نیست. |

## **کار با Placeholders**

Placeholders به‌طور معمول بر روی layout slideها تعریف می‌شوند. master slide سبک و تم مشترکی را فراهم می‌کند که layoutها از آن ارث می‌برند، در حالی که هر layout تصمیم می‌گیرد چه placeholdersی در دسترس هستند و در کجا قرار بگیرند.

در PowerPoint، دستورات placeholder در نمای Slide Master موجود است.

![دستور Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای افزودن placeholders جدید با Aspose.Slides، روی layout slideی که به master تعلق دارد کار کنید:

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

همچنین می‌توانید شکل‌های placeholder که از قبل بر روی master slide وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را پیدا کرده و یک پرکنندهٔ گرادیان خطی اعمال می‌کند:

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

![Placeholder عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی ارث‌برده می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر درباره placeholder و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/slides/fa/java/manage-placeholder/) و [Text Formatting](/slides/fa/java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ Slide Master**

یک پس‌زمینهٔ master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، ارث‌برده می‌شود. مثال زیر یک رنگ پس‌زمینهٔ ثابت برای اولین master slide تنظیم می‌کند:

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

برای مباحث مرتبط، به [Presentation Background](/slides/fa/java/presentation-background/) و [Presentation Theme](/slides/fa/java/presentation-theme/) مراجعه کنید.

## **کلون کردن یک Slide Master به ارائهٔ دیگر**

از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) برای کپی کردن یک master slide به ارائه‌ای دیگر استفاده کنید. master کپی‌شده سپس می‌تواند توسط layoutها و اسلایدهای مقصد استفاده شود.

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

اگر نیاز به کلون کردن اسلایدهای عادی همراه با master آن‌ها دارید، به [Clone Slides](/slides/fa/java/clone-slides/) نگاه کنید.

## **افزودن چند Slide Master**

یک ارائه می‌تواند شامل چندین master slide باشد. این کار زمانی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![دستورات PowerPoint برای درج و مدیریت master slideها](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کلون می‌کند، پس‌زمینهٔ متفاوتی به کلون می‌دهد، یک layout زیر آن master کلون شده ایجاد می‌کند و یک اسلاید جدید بر پایه آن layout اضافه می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **مقایسه Slide Masters**

master slideها می‌توانند با متد `equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) به ارث برده شده است، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند slide IDها یا مقادیر پویا مانند تاریخ فعلی مقایسه نمی‌شوند.

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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/java/compare-slides/) مراجعه کنید.

## **تنظیم Slide Master View به‌عنوان نمای پیش‌فرض**

از متد `setLastView` در [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

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

برای تنظیمات نمای بیشتر، به [Save Presentation](/slides/fa/java/save-presentation/) مراجعه کنید.

## **حذف Master Slideهای غیرقابل استفاده**

گاهی ارائه‌ها حاوی master slideهایی هستند که دیگر توسط هیچ اسلاید عادی استفاده نمی‌شوند. حذف masterهای غیرقابل استفاده می‌تواند اندازهٔ فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از `removeUnused` برای حذف masterهای غیرقابل استفاده از مجموعه `getMasters()` استفاده کنید:

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

همچنین می‌توانید از متد کم‌کد [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) استفاده کنید:

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

**تفاوت بین slide master و layout slide چیست؟**

slide master تنظیمات طراحی مشترک مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. یک layout slide متعلق به یک slide master است و چیدمان خاصی از placeholders را تعیین می‌کند. یک اسلاید عادی از یک layout slide استفاده می‌کند، بنابراین هم از layout و هم از master ارث می‌برد.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین slide master باشد. از چند master زمانی استفاده کنید که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی داشته باشند.

**آیا باید placeholders را به یک master slide یا یک layout slide اضافه کنم؟**

در اکثر موارد placeholders را به layout slideها اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را روی master slide بگذارید، سپس placeholders محتوایی را روی layoutهایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم یک master slide که هنوز استفاده می‌شود را حذف کنم؟**

خیر. یک master slide که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت ایمن مستقیماً حذف شود. ابتدا آن اسلایدها را به layoutهای زیر master دیگری منتقل کنید یا از روشی برای پاک‌سازی masterهای استفاده‌نشده استفاده کنید که فقط masterهایی را که در حال استفاده نیستند حذف می‌کند.