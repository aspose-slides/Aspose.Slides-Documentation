---
title: استخراج پیشرفته متن از ارائه‌ها در اندروید
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/androidjava/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از سند باز
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- دریافت متن
- دریافت متن از اسلاید
- دریافت متن از ارائه
- دریافت متن از پاورپوینت
- دریافت متن از سند باز
- دریافت متن از PPT
- دریافت متن از PPTX
- دریافت متن از ODP
- پاورپوینت
- سند باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به سرعت متن را از ارائه‌های پاورپوینت و سند باز با استفاده از Aspose.Slides برای اندروید از طریق جاوا استخراج کنید. راهنمای ساده و گام به گام ما را برای صرفه‌جویی در زمان دنبال کنید."
---
## **مرور کلی**

استخراج متن از ارائه‌ها یک کار رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلایدها کار می‌کنند. چه با فایل‌های Microsoft PowerPoint در قالب PPT یا PPTX کار کنید و چه با ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تجزیه و تحلیل، خودکارسازی، فهرست‌بندی یا مهاجرت محتوا حیاتی باشد.

این مقاله یک راهنمای کامل در مورد نحوه استخراج مؤثر متن از فرمت‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides برای Android از طریق Java ارائه می‌دهد. شما یاد می‌گیرید که چگونه به‌صورت سیستماتیک بر عناصر ارائه تکرار کنید تا به‌دقت محتوای متنی مورد نیاز خود را بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides برای Android از طریق Java کلاس [SlideUtil](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/) را فراهم می‌کند. این کلاس چندین متد استاتیک بارگذاری‌شده برای استخراج تمام متن از یک ارائه یا اسلاید را ارائه می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [getAllTextBoxes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) استفاده کنید. این متد یک شیء از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) را به عنوان پارامتر می‌پذیرد. هنگام اجرا، متد تمام اسلاید را برای متن اسکن می‌کند و یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را بر می‌گرداند که قالب‌بندی متن را حفظ می‌کند.

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

برای اسکن متن از کل ارائه، از متد استاتیک [getAllTextFrames](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) ارائه‌شده توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/) استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. اولین پارامتر، شیء [IPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/) است که نمایانگر یک ارائه PowerPoint یا OpenDocument است که متن آن استخراج می‌شود.
1. دومین پارامتر، یک مقدار `boolean` است که نشان می‌دهد آیا اسلایدهای اصلی هنگام اسکن متن از ارائه گنجانده شوند یا خیر.

این متد یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را بر می‌گرداند که شامل اطلاعات قالب‌بندی متن است. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، از جمله اسلایدهای اصلی، اسکن می‌کند.

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

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/) نیز روش‌هایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textextractionarrangingmode/) نشان‌دهنده حالت سازماندهی نتایج استخراج متن است و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون در نظر گرفتن موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیبی که در اسلاید است، سازماندهی می‌شود.

حالت Unarranged می‌تواند زمانی که سرعت حیاتی است استفاده شود؛ سریع‌تر از حالت Arranged است.

[IPresentationText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationtext/) نمایانگر متن خام استخراج‌شده از ارائه است. متد `getSlidesText` آن یک آرایه از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidetext/) را بر می‌گرداند. هر شیء متن مربوط به اسلاید متناظر را نشان می‌دهد. شیء نوع [ISlideText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidetext/) دارای متدهای زیر است:

- `getText` - متنی که در اشکال اسلاید وجود دارد.
- `getMasterText` - متنی که در اشکال اسلاید اصلی (master) مرتبط با این اسلاید وجود دارد.
- `getLayoutText` - متنی که در اشکال اسلاید چیدمان (layout) مرتبط با این اسلاید وجود دارد.
- `getNotesText` - متنی که در اشکال اسلاید یادداشت‌ها (notes) مرتبط با این اسلاید وجود دارد.
- `getCommentsText` - متنی که در نظرات مرتبط با این اسلاید وجود دارد.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **سوالات متداول**

**Aspose.Slides در هنگام استخراج متن چقدر سریع اسلایدهای بزرگ را پردازش می‌کند؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/androidjava/open-presentation/) را پردازش کند، که آن را برای سناریوهای پردازش بلادرنگ یا دسته‌ای مناسب می‌سازد.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارهای موجود در ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیاء مربوط به نمودارها، استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای رایج ارائه دسترسی داشته و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها نیاز به لایسنس ویژه Aspose.Slides دارم؟**

می‌توانید با نسخه آزمایشی رایان Aspose.Slides متن را استخراج کنید، هرچند که این نسخه دارای [محدودیت‌های خاص](/slides/fa/androidjava/licensing/) است، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و برخورداری از قابلیت پردازش ارائه‌های بزرگ‌تر، خرید یک لایسنس کامل توصیه می‌شود.