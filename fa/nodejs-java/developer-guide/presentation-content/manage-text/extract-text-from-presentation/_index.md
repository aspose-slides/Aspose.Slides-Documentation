---
title: استخراج پیشرفته متن از ارائه‌ها در جاوا اسکریپت
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/nodejs-java/extract-text-from-presentation/
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به‌سرعت متن را از ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java استخراج کنید. راهنمای ساده گام‌به‌گام ما را دنبال کنید تا زمان صرفه‌جویی شود."
---
## **مرور کلی**

استخراج متن از ارائه‌ها کاری رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلایدها سروکار دارند. چه با فایل‌های Microsoft PowerPoint با فرمت PPT یا PPTX کار کنید و چه با ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تحلیل، خودکارسازی، ایندکس‌گذاری یا مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج مؤثر متن از قالب‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides برای Node.js از طریق Java ارائه می‌دهد. شما یاد می‌گیرید چگونه به‌صورت سیستماتیک از عناصر ارائه عبور کنید تا محتوای متنی مورد نیاز را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides برای Node.js از طریق Java کلاس [SlideUtil](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/) را فراهم می‌کند. این کلاس چندین متد استاتیک بارگذاری‌شده برای استخراج تمام متن از یک ارائه یا اسلاید را در اختیار می‌گذارد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [getAllTextBoxes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) استفاده کنید. این متد یک شیء اسلاید را به‌عنوان پارامتر می‌پذیرد. هنگام اجرا، متد کل اسلاید را برای متن اسکن می‌کند و آرایه‌ای از اشیاء [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را برمی‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از متد استاتیک [getAllTextFrames](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/) ارائه می‌شود، استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. ابتدا، شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) که نمایانگر ارائه PowerPoint یا OpenDocument است و متن از آن استخراج می‌شود.
1. دوم، مقدار `boolean` که نشان می‌دهد آیا اسلایدهای مستر هنگام اسکن متن از ارائه گنجانده شوند یا نه.

متد یک آرایه از اشیاء [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را برمی‌گرداند که شامل اطلاعات قالب‌بندی متن است. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، از جمله اسلایدهای مستر، اسکن می‌کند.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج متن دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/) نیز متدهایی برای استخراج تمام متن از ارائه‌ها ارائه می‌دهد:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتیجه استخراج متن را تعیین می‌کند و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون در نظر گرفتن موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیب که در اسلاید ظاهر می‌شود، سازماندهی می‌شود.

حالت Unarranged می‌تواند زمانی استفاده شود که سرعت بحرانی باشد؛ این حالت نسبت به حالت Arranged سریع‌تر است.

[PresentationText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationtext/) متن خام استخراج‌شده از ارائه را نشان می‌دهد. متد `getSlidesText` این کلاس یک آرایه از اشیاء را برمی‌گرداند که هر یک متن اسلاید مربوطه را نمایندگی می‌کند. هر شیء متن اسلاید متدهای زیر را داراست:

- متد `getText` متن داخل اشکال اسلاید را برمی‌گرداند.
- متد `getMasterText` متن داخل اشکال اسلاید مستر مرتبط با این اسلاید را برمی‌گرداند.
- متد `getLayoutText` متن داخل اشکال اسلاید Layout مرتبط با این اسلاید را برمی‌گرداند.
- متد `getNotesText` متن داخل اشکال اسلاید یادداشت‌ها مرتبط با این اسلاید را برمی‌گرداند.
- متد `getCommentsText` متن داخل نظرات مرتبط با این اسلاید را برمی‌گرداند.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **سوالات متداول**

**Aspose.Slides در هنگام استخراج متن از ارائه‌های بزرگ چقدر سریع عمل می‌کند؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و می‌تواند حتی [ارائه‌های بزرگ](/slides/fa/nodejs-java/open-presentation/) را پردازش کند، لذا برای سناریوهای پردازش زمان واقعی یا دسته‌ای مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها داخل ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیاء مرتبط با نمودارها استخراج کند تا بتوانید محتویات متنی را در ساختارهای رایج ارائه تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به licence ویژه‌ای از Aspose.Slides نیاز دارم؟**

می‌توانید با نسخه آزمایشی رایگان Aspose.Slides متن را استخراج کنید، هرچند برخی [محدودیت‌ها](/slides/fa/nodejs-java/licensing/) دارد، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگتر، خرید لایسنس کامل توصیه می‌شود.