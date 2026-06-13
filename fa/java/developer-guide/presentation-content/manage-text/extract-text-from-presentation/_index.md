---
title: "استخراج پیشرفته متن از ارائه‌ها در جاوا"
linktitle: "استخراج متن"
type: docs
weight: 90
url: /fa/java/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- بازیابی متن
- بازیابی متن از اسلاید
- بازیابی متن از ارائه
- بازیابی متن از پاورپوینت
- بازیابی متن از OpenDocument
- بازیابی متن از PPT
- بازیابی متن از PPTX
- بازیابی متن از ODP
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "به‌سرعت متن را از ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای جاوا استخراج کنید. راهنمای ساده و مرحله‌به‌مرحلهٔ ما را دنبال کنید تا زمان صرفه‌جویی کنید."
---
## **بررسی کلی**

استخراج متن از ارائه‌ها یک کار رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلایدها سر و کار دارند. چه با فایل‌های Microsoft PowerPoint با فرمت PPT یا PPTX کار کنید و چه با ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تجزیه و تحلیل، خودکارسازی، ایندکس‌گذاری یا مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج مؤثر متن از فرمت‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides for Java ارائه می‌دهد. شما یاد خواهید گرفت چگونه به‌صورت سیستماتیک از اجزای ارائه عبور کنید تا محتوای متنی مورد نیاز را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides for Java کلاس [SlideUtil](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/) را فراهم می‌کند. این کلاس چندین متد استاتیک Overloaded برای استخراج تمام متن از یک ارائه یا اسلاید ارائه می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) استفاده کنید. این متد یک شیء از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) را به‌عنوان پارامتر می‌گیرد. هنگام اجرا، متد کل اسلاید را برای متن اسکن می‌کند و آرایه‌ای از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را برمی‌گرداند که قالب‌بندی متن را نیز حفظ می‌کند.

قطعه کد زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از متد استاتیک [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/) ارائه می‌شود، استفاده کنید. این متد دو پارامتر می‌گیرد:

1. اولین پارامتر یک شیء [IPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/) است که نمایانگر یک ارائه PowerPoint یا OpenDocument است که متن آن استخراج خواهد شد.
2. دومین پارامتر مقدار `boolean` است که نشان می‌دهد اسلایدهای اصلی (master) هنگام اسکن متن از ارائه شامل شوند یا خیر.

متد یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را بر می‌گرداند که شامل اطلاعات قالب‌بندی متن است. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، شامل اسلایدهای اصلی، اسکن می‌کند.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج متن دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/) نیز روش‌هایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتیجه استخراج متن را مشخص می‌کند و می‌تواند به یکی از مقادیر زیر تنظیم شود:

- `Unarranged` - متن خام بدون توجه به موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیب که در اسلاید قرار دارد، سازماندهی می‌شود.

حالت Unarranged وقتی سرعت حیاتی است می‌تواند استفاده شود؛ این حالت سریع‌تر از حالت Arranged است.

[IPresentationText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationtext/) متن خام استخراج‌شده از ارائه را نمایان می‌کند. متد `getSlidesText` این نوع، آرایه‌ای از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidetext/) را برمی‌گرداند. هر شیء متن مربوط به اسلاید مربوطه را نشان می‌دهد. اشیاء type [ISlideText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidetext/) دارای متدهای زیر هستند:

- `getText` - متن داخل اشکال اسلاید.
- `getMasterText` - متن داخل اشکال اسلاید اصلی مرتبط با این اسلاید.
- `getLayoutText` - متن داخل اشکال اسلاید لایه‌بندی مرتبط با این اسلاید.
- `getNotesText` - متن داخل اشکال اسلاید یادداشت‌ها مرتبط با این اسلاید.
- `getCommentsText` - متن داخل نظرات مرتبط با این اسلاید.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **سؤالات متداول**

**سرعت پردازش Aspose.Slides برای استخراج متن از ارائه‌های بزرگ چقدر است؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/java/open-presentation/) را پردازش کند، به‌طوری‌که برای سناریوهای پردازش بلادرنگ یا دسته‌ای مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارهای موجود در ارائه استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیای مرتبط با نمودارها، استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای رایج ارائه دسترسی داشته و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به لایسنس ویژه Aspose.Slides نیاز دارم؟**

می‌توانید با نسخهٔ آزمایشی رایگان Aspose.Slides متن را استخراج کنید، هرچند که دارای [محدودیت‌های خاص](/slides/fa/java/licensing/) است، مانند پردازش تنها تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگ‌تر، خرید لایسنس کامل توصیه می‌شود.