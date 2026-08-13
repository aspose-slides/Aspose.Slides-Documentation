---
title: صادرات معادلات ریاضی از ارائه‌ها در جاوا
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
description: "معادلات ریاضی را مستقیماً از ارائه‌های PowerPoint به LaTeX یا MathML با Aspose.Slides برای جاوا صادر کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="info" %}} 
می‌توانید معادلات را مستقیماً به LaTeX یا به MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی در وب و بسیاری از برنامه‌ها است.
{{% /alert %}}

## **صادر کردن معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی و مبدل خارجی نیست. یک معادله ریاضی در یک فریم متن به عنوان یک [IMathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/) ذخیره می‌شود. از [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/#getMathParagraph--) برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathparagraph/) استفاده کنید و سپس [IMathParagraph.toLatex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathparagraph/#toLatex--) را فراخوانی کنید. این متد یک رشته بازمی‌گرداند که می‌توانید آن را ذخیره، نمایش دهید، به برنامه دیگری بفرستید یا به‌طور بیشتری پردازش کنید.

مثال زیر هر فریم متن را در هر اسلاید بررسی می‌کند، تمام بخش‌های ریاضی را پیدا کرده و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تمام فریم‌های متنی موجود در یک اسلاید را بر می‌گرداند. بررسی نوع [IMathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imathportion/) معادلات قابل ویرایش واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از یک مجموعه دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته بازگردانده‌شده را با موتور LaTeX مورد استفاده در برنامه‌تان تست کنید. اگر نماد یا عنصر Office Math نمایانگری مناسب در آن محیط نداشته باشد، آن را در رشته بازگردانده‌شده با یک دستور مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و موضوع را برای بررسی ثبت نمایید.

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که انسان‌ها به راحتی می‌توانند کد برخی فرمت‌های معادله مانند LaTeX را بنویسند، نوشتن کد برای MathML برای آن‌ها دشوار است زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در قالب XML است، بنابراین MathML به‌طور معمول به‌عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

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

## **پرسش‌های متداول**

**دقیقا چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

می‌توانید یا کل پاراگراف ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع روشی برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید فرمول ریاضی است نه متن یا تصویر معمولی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) است. تصاویر و بخش‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**منبع MathML در یک ارائه از کجا آمده است—آیا مخصوص PowerPoint است یا یک استاندارد؟**

صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌گری استاندارد که به‌طور گسترده‌ای در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صادرات فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML، ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML صرفاً سریالی‌سازی محتوای فرمول است؛ فایل ارائه را تغییر نمی‌دهد.