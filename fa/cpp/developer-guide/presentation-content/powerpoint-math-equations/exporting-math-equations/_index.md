---
title: صدور معادلات ریاضی از ارائه‌ها در C++
linktitle: صدور معادلات
type: docs
weight: 30
url: /fa/cpp/exporting-math-equations/
keywords:
- صدور معادلات ریاضی
- صدور معادلات به LaTeX
- PowerPoint به LaTeX
- MathML
- LaTeX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "صدور معادلات ریاضی از ارائه‌های PowerPoint به LaTeX یا MathML به‌صورت مستقیم با Aspose.Slides برای C++."
---
## **مقدمه**

Aspose.Slides برای C++ به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید. 

{{% alert color="primary" %}} 
می‌توانید معادلات را به‌صورت مستقیم به LaTeX یا به MathML صادر کنید، که یک استاندارد محبوب برای محتوای ریاضی است که در وب و بسیاری از برنامه‌ها استفاده می‌شود.
{{% /alert %}}

## **صادر کردن معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند معادله ریاضی PowerPoint را به‌صورت مستقیم به LaTeX تبدیل کند؛ نیازی به فایل MathML میانی یا مبدل خارجی نیست. یک معادله ریاضی در یک قاب متن به‌عنوان یک [IMathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathportion/) ذخیره می‌شود. از [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathparagraph/) استفاده کنید، سپس [IMathParagraph::ToLatex](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، به برنامه دیگری ارسال یا به‌طور بیشتری پردازش کنید.

مثال زیر هر قاب متن در هر اسلاید را بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل `.tex` جداگانه می‌نویسد:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextboxes/) تمام قاب‌های متنی یافت‌شده در یک اسلاید را برمی‌گرداند. بررسی نوع [IMathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathportion/) معادلات قابل ویرایش واقعی را از متن و تصاویر عادی جدا می‌کند.

موتورهای LaTeX و قالب‌های سند همگی از یک‌باره همان دستورات، بسته‌ها یا کاراکترهای یونیکد پشتیبانی نمی‌کنند. رشتهٔ بازگشتی را با موتور LaTeX مورد استفاده در برنامه‌تان آزمایش کنید. اگر نماد یا عنصر Office Math نمایانگر مناسبی در آن محیط نداشته باشد، آن را در رشتهٔ بازگشتی با یک دستور مخصوص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مسئله را برای بازبینی ثبت کنید.

## **ذخیره‌سازی معادلات ریاضی به عنوان MathML**

در حالی که افراد به‌راحتی می‌توانند کد برخی فرمت‌های معادله مانند LaTeX را بنویسند، نوشتن کد برای MathML دشوار است زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به‌راحتی MathML را می‌خوانند و تجزیه می‌کنند زیرا کد آن در XML است، بنابراین MathML به‌طور رایج به‌عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود. 

این کد نمونه نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **سوالات متداول**

**چه چیزی دقیقاً به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول تک‌تک؟**  
می‌توانید یا یک کل پاراگراف ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع روش نوشتن به MathML را ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء روی اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathportion/) قرار دارد و یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) دارد. تصاویر و بخش‌های متنی معمولی بدون یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) فرمول‌های قابل صادرات نیستند.

**منبع MathML در یک ارائه چیست—آیا مخصوص PowerPoint است یا یک استاندارد؟**  
صدور به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعهٔ ارائه‌ای استاندارد که به طور گسترده در برنامه‌ها و وب مورد استفاده قرار می‌گیرد.

**آیا صادر کردن فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادر کردن به MathML فایل ارائه اصلی را تغییر می‌دهد؟**  
خیر. نوشتن MathML یک سریال‌سازی از محتوای فرمول است؛ فایل ارائه اصلی را تغییر نمی‌دهد.