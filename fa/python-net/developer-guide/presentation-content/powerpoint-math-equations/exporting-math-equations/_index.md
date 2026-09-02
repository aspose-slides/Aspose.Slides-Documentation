---
title: صدور معادلات ریاضی از ارائه‌ها در پایتون
linktitle: صدور معادلات
type: docs
weight: 30
url: /fa/python-net/exporting-math-equations/
keywords:
- صدور معادلات ریاضی
- صدور معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: معادلات ریاضی را مستقیماً از ارائه‌های PowerPoint به LaTeX یا MathML با Aspose.Slides برای Python از طریق .NET صادر کنید.
---
## **مقدمه**

Aspose.Slides برای Python از طریق .NET به شما امکان صدور معادلات ریاضی از ارائه‌ها را می‌دهد. به عنوان مثال، ممکن است نیاز داشته باشید معادلات را از اسلایدهای خاص استخراج کرده و در برنامه یا پلتفرم دیگری دوباره استفاده کنید.

{{% alert color="primary" %}}
می‌توانید معادلات را به‌صورت مستقیم به LaTeX یا به MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی در وب و بسیاری از برنامه‌ها است.
{{% /alert %}}

## **صدور معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را به‌صورت مستقیم به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی یا مبدل خارجی نیست. یک معادله ریاضی در یک قاب متن به عنوان یک [MathPortion](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/) ذخیره می‌شود. از [MathPortion.math_paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) برای دریافت یک [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) استفاده کنید و سپس [MathParagraph.to_latex](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) را فراخوانی کنید. این متد یک رشته بازمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگر ارسال یا برای پردازش‌های بیشتر استفاده کنید.

مثال زیر هر قاب متن را در هر اسلاید بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) تمام قاب‌های متنی را که در یک اسلاید یافت می‌شوند برمی‌گرداند. بررسی نوع [MathPortion](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/) معادلات قابل ویرایش واقعی را از متن عادی و تصاویر جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همه از یک‌سان دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته بازگردانده‌شده را با موتور LaTeX مورد استفاده در برنامه‌تان تست کنید. اگر یک نماد یا عنصر Office Math نمایان‌سازی مناسبی در آن محیط نداشته باشد، آن را در رشته بازگردانده‌شده با دستور خاص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به صورت MathML**

اگرچه انسان‌ها می‌توانند به‌راحتی LaTeX بنویسند، اما MathML معمولاً به‌صورت خودکار توسط برنامه‌ها تولید می‌شود. از آنجا که MathML مبتنی بر XML است، برنامه‌ها می‌توانند آن را به‌صورت قابل اعتماد خوانده و تجزیه کنند، بنابراین به‌طور گسترده به‌ عنوان قالب خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

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

## **سؤالات متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود— یک پاراگراف یا یک بلوک فرمول جداگانه؟**  
می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathportion/) وجود دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) است. تصاویر و بخش‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) ندارند، فرمول‌های قابل صدور نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مخصوص PowerPoint است یا یک استاندارد؟**  
صدور به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد که به‌ طور گسترده در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صدور فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صدور به MathML فایل ارائه اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML یک سریال‌سازی از محتوای فرمول است؛ فایل ارائه را تغییر نمی‌دهد.