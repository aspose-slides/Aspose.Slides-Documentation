---
title: صدور معادلات ریاضی از ارائه‌ها در Android
linktitle: صدور معادلات
type: docs
weight: 30
url: /fa/androidjava/exporting-math-equations/
keywords:
- صدور معادلات ریاضی
- صدور معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "معادلات ریاضی را از ارائه‌های PowerPoint به‌صورت مستقیم به LaTeX یا MathML با Aspose.Slides برای Android از طریق Java صادر کنید."
---
## **مقدمه**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="info" %}} 
شما می‌توانید معادلات را مستقیم به LaTeX یا MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی است که در وب و بسیاری از برنامه‌ها استفاده می‌شود.
{{% /alert %}}

## **صادر کردن معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادلهٔ ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی یا مبدل خارجی نیست. یک معادلهٔ ریاضی در یک فریم متنی به عنوان یک [IMathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/) ذخیره می‌شود. از [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathparagraph/) استفاده کنید و سپس متد [IMathParagraph.toLatex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathparagraph/#toLatex--) را صدا بزنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش دهید، به برنامهٔ دیگری بفرستید یا پردازش بیشتری روی آن انجام دهید.

مثال زیر هر فریم متنی را در هر اسلاید بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تمام فریم‌های متنی موجود در یک اسلاید را برمی‌گرداند. بررسی نوع [IMathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imathportion/) معادلات واقعی قابل ویرایش را از متن و تصویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از یک‌سوی تمام دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشتهٔ برگردانده‌شده را با موتوری که برنامهٔ شما استفاده می‌کند تست کنید. اگر یک نماد یا عنصر Office Math نمایان مناسب در آن محیط نداشته باشد، آن را در رشتهٔ برگردانده‌شده با دستوری اختصاصی پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به‌صورت MathML**

در حالی که انسان‌ها به راحتی می‌توانند کد برخی قالب‌های معادله مانند LaTeX را بنویسند، نوشتن کد برای MathML برای آن‌ها دشوار است چون این قالب برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در قالب XML است، بنابراین MathML به‌طور گسترده‌ای به‌عنوان قالب خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه می‌توانید یک معادلهٔ ریاضی را از یک ارائه به MathML صادر کنید:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **سوالات متداول**

**دقیقا چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**  
شما می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**  
یک فرمول در داخل یک [MathPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathportion/) قرار دارد و یک [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) دارد. تصاویر و بخش‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صادر نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مربوط به PowerPoint است یا یک استاندارد؟**  
صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML—زیربخش ارائه‌ای استاندارد—استفاده می‌کند که به‌طور گسترده‌ای در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صادر کردن فرمول‌ها در جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادر کردن به MathML فایل ارائهٔ اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML تنها سریال‌سازی محتوای فرمول است و فایل ارائه را تغییر نمی‌دهد.