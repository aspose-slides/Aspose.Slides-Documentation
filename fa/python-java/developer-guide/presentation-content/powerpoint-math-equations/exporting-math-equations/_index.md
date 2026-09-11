---
title: صادرات معادلات ریاضی از ارائه‌ها در پایتون
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/python-java/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- صادرات معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "صادرات معادلات ریاضی از ارائه‌های PowerPoint به LaTeX یا MathML به‌صورت مستقیم با Aspose.Slides برای Python از طریق Java."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها صادر کنید. به عنوان مثال، ممکن است بخواهید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کنید و در برنامه یا پلتفرم دیگری استفاده کنید. 

{{% alert color="info" title="توجه" %}} 

می‌توانید معادلات را مستقیماً به LaTeX یا به MathML صادر کنید؛ استانداردی محبوب برای محتوای ریاضی که در وب و بسیاری از برنامه‌ها استفاده می‌شود.

{{% /alert %}}

## **صدور معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را به‌طور مستقیم به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی و مبدل خارجی نیست. یک معادله ریاضی در یک فریم متنی به‌صورت یک [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) ذخیره می‌شود. از [MathPortion.getMathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/#getMathParagraph) برای دریافت یک [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) استفاده کنید و سپس [MathParagraph.toLatex](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/#toLatex) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگری بفرستید یا به‌طور بیشتر پردازش کنید.

مثال زیر هر فریم متنی را در هر اسلاید بررسی می‌کند، تمام قسمت‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#getAllTextBoxes) تمام فریم‌های متنی یافت‌شده در یک اسلاید را برمی‌گرداند. بررسی نوع [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) معادلات ویرایش‌پذیر واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از یک‌دست دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته بازگردانده‌شده را با موتور LaTeX مورد استفاده در برنامه‌تان تست کنید. اگر نماد یا عنصر Office Math نمایانگری مناسب در آن محیط نداشته باشد، آن را در رشته بازگردانده‌شده با یک دستور خاص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مسئله را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که نوشتن کد برای برخی قالب‌های معادله مثل LaTeX آسان است، نوشتن دستی MathML دشوارتر است زیرا برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها می‌توانند به سادگی MathML را بخوانند و تجزیه کنند زیرا مبتنی بر XML است؛ بنابراین MathML به‌طور گسترده‌ای به‌عنوان قالب خروجی و چاپ در بسیاری از زمینه‌ها استفاده می‌شود. 

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **سوالات متداول**

**دقیقا چه چیزی به‌صورت MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

می‌توانید کل پاراگراف ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML دارند.

**چگونه تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر عادی؟**

یک فرمول در داخل یک [MathPortion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) است. تصاویر و قسمت‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) ندارند، فرمول‌های قابل صدور نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مختص PowerPoint است یا یک استاندارد؟**

هدف صادرات، MathML استاندارد (XML) است. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعهٔ ارائه‌ای استاندارد که به طور گسترده در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صدور فرمول‌ها در داخل جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیا شامل قسمت‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML صرفاً سریال‌سازی محتوای فرمول است؛ فایل ارائه اصلی تغییر نمی‌کند.