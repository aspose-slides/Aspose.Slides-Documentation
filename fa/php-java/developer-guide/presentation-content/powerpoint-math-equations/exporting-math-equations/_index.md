---
title: صادر کردن معادلات ریاضی از ارائه‌ها در PHP
linktitle: صادر کردن معادلات
type: docs
weight: 30
url: /fa/php-java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- صادرات معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "معادلات ریاضی ارائه‌های PowerPoint را به‌صورت مستقیم به LaTeX یا MathML با Aspose.Slides برای PHP از طریق Java صادر کنید."
---
## **مقدمه**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کنید و در برنامه یا پلتفرم دیگری استفاده نمایید.

{{% alert color="primary" %}} 

می‌توانید معادلات را مستقیماً به LaTeX یا به MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی استفاده‌شده در وب و بسیاری از برنامه‌ها است.

{{% /alert %}}

## **صادر کردن معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را به‌صورت مستقیم به LaTeX تبدیل کند؛ نیازی به فایل میانی MathML یا مبدل خارجی نیست. یک معادله ریاضی به‌عنوان یک [MathPortion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathportion/) در یک فریم متن ذخیره می‌شود. از [MathPortion::getMathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathportion/#getMathParagraph) برای دریافت یک [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) استفاده کنید و سپس [MathParagraph::toLatex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/#toLatex) را فراخوانی نمایید. این متد یک رشته برمی‌گرداند که می‌توانید ذخیره، نمایش، به برنامه دیگری ارسال یا به‌طور بیشتری پردازش کنید.

مثال زیر هر فریم متن در هر اسلاید را بررسی می‌کند، تمام MathPortion‌ها را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#getAllTextBoxes) تمام فریم‌های متنی یافت‌شده در یک اسلاید را بازمی‌گرداند. بررسی نوع [MathPortion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathportion/) معادلات قابل ویرایش واقعی را از متن و تصویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همه یک‌نواخت از دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته بازگشتی را با موتور LaTeX مورد استفاده در برنامه خود آزمایش کنید. اگر نماد یا عنصر Office Math نمایانگر مناسبی در آن محیط نداشته باشد، آن را در رشته بازگشتی با یک دستور مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بازبینی ثبت کنید.

## **ذخیره معادلات ریاضی به صورت MathML**

در حالی که انسان‌ها به راحتی می‌توانند کد برخی فرمت‌های معادله مانند LaTeX را بنویسند، نوشتن کد MathML برایشان دشوار است، زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در XML است، بنابراین MathML به‌طور معمول به‌عنوان قالب خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا بلوک فرمول جداگانه؟**

می‌توانید یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء روی اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) است. تصاویر و قسمت‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مخصوص PowerPoint است یا استانداردی؟**

صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد که به‌طور گسترده در برنامه‌ها و وب استفاده می‌شود.

**آیا صادرات فرمول‌ها داخل جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML صرفاً سریال‌سازی محتوای فرمول است و فایل ارائه را تغییر نمی‌دهد.