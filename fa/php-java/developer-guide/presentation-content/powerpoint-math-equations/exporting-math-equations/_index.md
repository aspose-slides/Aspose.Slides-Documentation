---
title: صادرات معادلات ریاضی از ارائه‌ها در PHP
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/php-java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "قفل‌گشایی صادر کردن بی‌دردسر معادلات ریاضی از PowerPoint به MathML با استفاده از Aspose.Slides برای PHP از طریق Java — حفظ قالب‌بندی و ارتقاء سازگاری."
---
## **معرفی**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
شما می‌توانید معادلات را به MathML، یک فرمت یا استاندارد محبوب برای معادلات ریاضی و محتوای مشابه که در وب و بسیاری از برنامه‌ها مشاهده می‌شود، صادر کنید.
{{% /alert %}}

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، برای نوشتن کد MathML دچار مشکل می‌شوند زیرا این فرمت به‌گونه‌ای طراحی شده است که به‌طور خودکار توسط برنامه‌ها تولید شود. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌نمایند زیرا کد آن در XML است، بنابراین MathML به‌طور معمول به‌عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

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

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول فردی؟**  
می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/)) یا یک بلوک فردی ([MathBlock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathportion/) زندگی می‌کند و یک [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) دارد. تصاویر و بخش‌های متن عادی که [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مختص PowerPoint است یا یک استاندارد؟**  
صادرات به استاندارد MathML (XML) هدف دارد. Aspose از Presentation MathML—زیرمجموعهٔ ارائه‌ای استاندارد—استفاده می‌کند که به‌طور گسترده در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صادرات فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mathparagraph/) (یعنی فرمول‌های حقیقی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌عنوان تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML یک سریالی‌سازی از محتوای فرمول است؛ آن فایل ارائه را تغییر نمی‌دهد.