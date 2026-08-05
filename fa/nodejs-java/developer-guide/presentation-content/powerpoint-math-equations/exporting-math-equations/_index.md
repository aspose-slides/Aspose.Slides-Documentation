---
title: صدور معادلات ریاضی از ارائه‌ها در جاوا اسکریپت
linktitle: صدور معادلات
type: docs
weight: 30
url: /fa/nodejs-java/exporting-math-equations/
keywords:
- صدور معادلات ریاضی
- صدور معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "معادلات ریاضی را مستقیماً از ارائه‌های PowerPoint به LaTeX یا MathML با Aspose.Slides برای Node.js از طریق Java صادر کنید."
---
## **معرفی**

Aspose.Slides به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
شما می‌توانید معادلات را مستقیماً به LaTeX یا MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی استفاده شده در وب و بسیاری از برنامه‌ها است.
{{% /alert %}}

## **صدور معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل MathML واسط یا مبدل خارجی نیست. یک معادله ریاضی در یک فریم متنی به عنوان یک [MathPortion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathportion/) ذخیره می‌شود. از [MathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) برای دریافت یک [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) استفاده کنید و سپس [MathParagraph.toLatex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/#toLatex--) را فراخوانی کنید. این متد یک رشته باز می‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگری ارسال یا برای پردازش‌های بعدی استفاده کنید.

مثال زیر هر فریم متنی را در تمام اسلایدها بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) تمام فریم‌های متنی یافت‌شده در یک اسلاید را برمی‌گرداند. بررسی نوع [MathPortion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathportion/) معادلات قابل ویرایش واقعی را از متن و تصویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همه از یک‌دست دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته بازگردانده‌شده را با موتور LaTeX مورد استفاده در برنامه خود تست کنید. اگر نماد یا عنصر Office Math نمایان‌گری مناسبی در آن محیط نداشته باشد، آن را در رشته بازگردانده‌شده با یک فرمان مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بازبینی ثبت کنید.

## **ذخیره معادلات ریاضی به صورت MathML**

در حالی که انسان‌ها به راحتی می‌توانند کد برخی فرمت‌های معادله مانند LaTeX را بنویسند، نوشتن کد برای MathML برای آن‌ها دشوار است زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به آسانی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در XML است، بنابراین MathML به طور گسترده‌ای به عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**در واقع چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول منفرد؟**  
می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/)) یا یک بلوک منفرد ([MathBlock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی معمولی که [MathParagraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مختص PowerPoint است یا یک استاندارد؟**  
صدور هدفمند به MathML استاندارد (XML) است. Aspose از Presentation MathML—زیرمجموعهٔ ارائه‌ای استاندارد—استفاده می‌کند که به‌ طور گسترده‌ای در برنامه‌ها و وب استفاده می‌شود.

**آیا صدور فرمول‌ها داخل جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph] (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صدور به MathML فایل ارائهٔ اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML یک سریالی‌سازی از محتوای فرمول است؛ این کار فایل ارائه را تغییر نمی‌دهد.