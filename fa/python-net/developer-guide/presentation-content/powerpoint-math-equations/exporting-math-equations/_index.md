---
title: صادرات معادلات ریاضی از ارائه‌ها در پایتون
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/python-net/exporting-math-equations/
keywords:
- صادر کردن معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "صادرات بی‌وقفه معادلات ریاضی از پاورپوینت به MathML با استفاده از Aspose.Slides برای پایتون از طریق .NET را فعال کنید—قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **معرفی**

Aspose.Slides for Python via .NET به شما امکان صادر کردن معادلات ریاضی از ارائه‌ها را می‌دهد. به عنوان مثال، ممکن است نیاز داشته باشید معادلات را از اسلایدهای خاص استخراج کرده و در برنامه یا پلتفرم دیگری دوباره استفاده کنید.

{{% alert color="primary" %}}
می‌توانید معادلات را به MathML صادر کنید؛ این استاندارد گسترده‌ای برای نمایش محتوای ریاضی در وب و بسیاری از برنامه‌هاست.
{{% /alert %}}

## **ذخیره معادلات ریاضی به‌صورت MathML**

اگرچه انسان‌ها به راحتی می‌توانند LaTeX بنویسند، MathML معمولاً به‌صورت خودکار توسط برنامه‌ها تولید می‌شود. چون MathML مبتنی بر XML است، برنامه‌ها می‌توانند آن را به‌دقت بخوانند و تجزیه کنند، بنابراین به‌عنوان فرمت خروجی و چاپ در بسیاری از زمینه‌ها به‌کار می‌رود.

کد نمونه زیر نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **پرسش‌های متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود – یک پاراگراف یا یک بلوک فرمول جداگانه؟**

شما می‌توانید یک پاراگراف ریاضی کامل ([MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML دارند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/) قرار دارد و یک [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) دارد. تصاویر و بخش‌های متنی معمولی که [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید – آیا مختص PowerPoint است یا یک استاندارد؟**

صادرات هدف، MathML استاندارد (XML) است. Aspose از Presentation MathML استفاده می‌کند – زیرمجموعهٔ ارائه‌ای استاندارد که در برنامه‌ها و وب به‌طور گسترده‌ای استفاده می‌شود.

**آیا صادر کردن فرمول‌ها در داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیاء شامل بخش‌های متنی با [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائهٔ اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML صرفاً سریال‌سازی محتوای فرمول است و فایل ارائه را تغییر نمی‌دهد.