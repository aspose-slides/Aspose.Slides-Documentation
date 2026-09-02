---
title: صادرات معادلات ریاضی از ارائه‌ها در Java
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- صادرات معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "صادرات معادلات ریاضی از ارائه‌های PowerPoint به LaTeX یا MathML به‌صورت مستقیم با Aspose.Slides برای Java."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کنید و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
می‌توانید معادلات را مستقیماً به LaTeX یا به MathML، که یک استاندارد محبوب برای محتوای ریاضی است و در وب و بسیاری از برنامه‌ها استفاده می‌شود، صادر کنید.
{{% /alert %}}

## **صادر کردن معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی یا تبدیل‌کننده خارجی نیست. یک معادله ریاضی در یک فریم متن به صورت یک [IMathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/) ذخیره می‌شود. با استفاده از [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/#getMathParagraph--) می‌توانید یک [IMathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathparagraph/) دریافت کنید، سپس [IMathParagraph.toLatex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathparagraph/#toLatex--) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگری ارسال یا به‌طور بیشتر پردازش کنید.

مثال زیر هر فریم متن را در هر اسلاید بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تمام فریم‌های متنی یافت شده در یک اسلاید را برمی‌گرداند. بررسی نوع [IMathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/) معادلات قابل ویرایش واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همه دستورات، بسته‌ها یا کاراکترهای یونیکد یکسانی را پشتیبانی نمی‌کنند. رشته بازگشتی را با موتور LaTeX مورد استفاده در برنامه خود تست کنید. اگر یک نماد یا عنصر Office Math نماینده مناسبی در آن محیط نداشته باشد، آن را در رشته بازگشتی با یک دستور مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مسئله را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به صورت MathML**

در حالی که انسان‌ها به راحتی کد بعضی قالب‌های معادله مثل LaTeX را می‌نویسند، نوشتن کد برای MathML دشوار است زیرا این قالب برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در قالب XML است، به همین دلیل MathML به‌طور گسترده‌ای به عنوان قالب خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**  
می‌توانید یا یک پاراگراف ریاضی کامل ([MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/)) یا یک بلوک فرمول جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را فراهم می‌آورند.

**چگونه می‌توانم تشخیص دهم یک شیء در اسلاید یک فرمول ریاضی است نه متن معمولی یا تصویر؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی معمولی بدون [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا به‌طور خاص برای PowerPoint است یا یک استاندارد؟**  
صادرات به استاندارد MathML (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد که به‌طور گسترده‌ای در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صادرات فرمول‌ها در داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر این اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML صرفاً سریالیزه کردن محتوای فرمول است و فایل ارائه را تغییر نمی‌دهد.