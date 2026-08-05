---
title: صادرات معادلات ریاضی از ارائه‌ها در .NET
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/net/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- صادرات معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "معادلات ریاضی را از ارائه‌های PowerPoint به طور مستقیم به LaTeX یا MathML با Aspose.Slides برای .NET صادر کنید."
---
## **مقدمه**

Aspose.Slides for .NET به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها صادر کنید. به عنوان مثال، ممکن است لازم باشد معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کنید و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
شما می‌توانید معادلات را به‌صورت مستقیم به LaTeX یا به MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی است که در وب و بسیاری از برنامه‌ها مورد استفاده قرار می‌گیرد.
{{% /alert %}}

## **صادرات معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل MathML واسطه یا مبدل خارجی نیست. یک معادله ریاضی در یک فریم متنی به‌عنوان یک [MathPortion](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathportion/) ذخیره می‌شود. برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/imathparagraph/) از [MathPortion.MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathportion/mathparagraph/) استفاده کنید و سپس [IMathParagraph.ToLatex](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/imathparagraph/tolatex/) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه‌ای دیگر بفرستید یا بیشتر پردازش کنید.

مثال زیر هر فریم متنی را در هر اسلاید بررسی می‌کند، تمام قسمت‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextboxes/) تمام فریم‌های متنی یافت‌شده در یک اسلاید را برمی‌گرداند. بررسی نوع [MathPortion](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathportion/) معادلات قابل ویرایش واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از همان دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشته برگشتی را با موتور LaTeX مورد استفاده در برنامه خود آزمایش کنید. اگر یک نماد یا عنصر Office Math نمایندگی مناسبی در آن محیط نداشته باشد، آن را در رشته برگشتی با یک دستور مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بازبینی ثبت کنید.

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، نوشتن کد برای MathML برای آن‌ها دشوار است، زیرا هدف از این فرمت تولید خودکار توسط برنامه‌ها است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در XML است، بنابراین MathML به‌طور رایج به عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **پرسش‌های متداول**

**دقیقا چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

شما می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن عادی یا تصویر؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) است. تصاویر و بخش‌های متنی عادی که [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مختص PowerPoint است یا یک استاندارد؟**

صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد—که به‌صورت گسترده در برنامه‌ها و وب استفاده می‌شود.

**آیا صادرات فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیا حاوی بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML یک سریال‌سازی از محتوای فرمول است؛ آن فایل ارائه را تغییر نمی‌دهد.