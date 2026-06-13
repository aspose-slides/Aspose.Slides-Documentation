---
title: صادرات معادلات ریاضی از ارائه‌ها در .NET
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/net/exporting-math-equations/
keywords:
- صادر کردن معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "صادرات یکپارچه معادلات ریاضی از PowerPoint به MathML را با استفاده از Aspose.Slides برای .NET فعال کنید—قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **مقدمه**

Aspose.Slides برای .NET امکان صادرات معادلات ریاضی را از ارائه‌ها فراهم می‌کند. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید. 

{{% alert color="primary" %}} 
می‌توانید معادلات را به MathML صادر کنید، که یک فرمت یا استاندارد محبوب برای معادلات ریاضی و محتوای مشابه است که در وب و بسیاری از برنامه‌ها مشاهده می‌شود. 
{{% /alert %}}

## **ذخیره معادلات ریاضی به عنوان MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، نوشتن کد برای MathML برای آن‌ها دشوار است زیرا این فرمت قرار است به‌صورت خودکار توسط برنامه‌ها تولید شود. برنامه‌ها به‌راحتی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در XML است، بنابراین MathML به‌طور معمول به‌عنوان یک فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود. 

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

## **سوالات متداول**

**دقیقا چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**  
می‌توانید یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع یک روش برای نوشتن به MathML ارائه می‌دهند.  

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathportion/) قرار دارد و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) است. تصاویر و بخش‌های متنی معمولی که [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) ندارند، فرمول‌های قابل صادرات نیستند.  

**منبع MathML در یک ارائه چیست—آیا مختص PowerPoint است یا یک استاندارد؟**  
صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد—که به‌طور گسترده‌ای در برنامه‌ها و وب استفاده می‌شود.  

**آیا صادرات فرمول‌ها در داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیا شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.  

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML یک سریال‌سازی از محتوای فرمول است؛ آن فایل ارائه را تغییر نمی‌دهد.