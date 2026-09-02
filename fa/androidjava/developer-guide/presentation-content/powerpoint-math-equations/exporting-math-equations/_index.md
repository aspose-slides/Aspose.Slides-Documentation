---
title: صادرات معادلات ریاضی از ارائه‌ها در اندروید
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/androidjava/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- صادرات معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "صادرات معادلات ریاضی از ارائه‌های PowerPoint به LaTeX یا MathML به‌صورت مستقیم با Aspose.Slides برای اندروید از طریق Java."
---
## **مقدمه**

Aspose.Slides for Android via Java به شما امکان استخراج معادلات ریاضی از ارائه‌ها را می‌دهد. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
می‌توانید معادلات را مستقیماً به LaTeX یا به MathML صادر کنید؛ یک استاندارد محبوب برای محتوای ریاضی که در وب و بسیاری از برنامه‌ها استفاده می‌شود.
{{% /alert %}}

## **استخراج معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را به‌طور مستقیم به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی یا مبدل خارجی نیست. یک معادله ریاضی به‌صورت یک [IMathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/) در یک فریم متن ذخیره می‌شود. از [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathparagraph/) استفاده کنید و سپس [IMathParagraph.toLatex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathparagraph/#toLatex--) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگری بفرستید یا به‌طور بیشتر پردازش کنید.

مثال زیر هر فریم متن را در هر اسلاید بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را به یک فایل مجزا با پسوند `.tex` می‌نویسد:

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تمام فریم‌های متنی موجود در یک اسلاید را برمی‌گرداند. بررسی نوع [IMathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/) معادلات قابل ویرایش واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از یک‌سان دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته‌ی بازگشتی را با موتوری که برنامه‌تان استفاده می‌کند تست کنید. اگر نمادی یا عنصر Office Math در آن محیط نمایانگر مناسب نداشته باشد، آن را در رشته‌ی بازگشتی با دستوری مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که افراد به راحتی می‌توانند کد برخی قالب‌های معادله مانند LaTeX را بنویسند، نوشتن کد برای MathML دشوار است زیرا این قالب برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در XML است، بنابراین MathML به‌طور گسترده‌ای به عنوان قالب خروجی و چاپ در بسیاری از زمینه‌ها استفاده می‌شود.

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

**دقیقا چه چیزی به‌صورت MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع یک متد برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) ندارند، فرمول‌هایی برای صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مخصوص PowerPoint است یا یک استاندارد؟**

هدف صادرات یک MathML استاندارد (XML) است. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد که به‌طور گسترده در برنامه‌ها و وب به کار می‌رود.

**آیا صادرات فرمول‌ها درون جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، صادر می‌شوند. اگر فرمول به‌صورت تصویر嵌入 شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML باعث تغییر ارائه اصلی می‌شود؟**

نه. نوشتن MathML صرفاً سریال‌سازی محتوای فرمول است؛ فایل ارائه اصلی را تغییر نمی‌دهد.