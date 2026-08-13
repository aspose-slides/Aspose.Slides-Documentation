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

Aspose.Slides برای C++ به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها صادر کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="info" %}} 
شما می‌توانید معادلات را مستقیماً به LaTeX یا MathML صادر کنید، که استانداردی محبوب برای محتوای ریاضی در وب و بسیاری از برنامه‌ها است.
{{% /alert %}}

## **صادرات معادلات ریاضی به LaTeX**

Aspose.Slides می‌تواند یک معادله ریاضی PowerPoint را مستقیماً به LaTeX تبدیل کند؛ نیازی به فایل میانی MathML یا مبدل خارجی نیست. یک معادله ریاضی به‌صورت یک [IMathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathportion/) در یک قاب متن ذخیره می‌شود. برای دریافت یک [IMathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathparagraph/) از متد [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) استفاده کنید و سپس متد [IMathParagraph::ToLatex](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) را فراخوانی کنید. این متد یک رشته برمی‌گرداند که می‌توانید آن را ذخیره، نمایش، برای برنامه دیگری بفرستید یا به‌طور بیشتری پردازش کنید.

مثال زیر هر قاب متن را در تمام اسلایدها بررسی می‌کند، تمام بخش‌های ریاضی را پیدا می‌کند و هر معادله را در یک فایل جداگانه با پسوند `.tex` می‌نویسد:

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

موتورهای LaTeX و قالب‌های سند همگی از یکدست دستورات، بسته‌ها یا کاراکترهای Unicode پشتیبانی نمی‌کنند. رشتهٔ برگردانده‌شده را با موتور LaTeX استفاده‌شده در برنامهٔ خود آزمایش کنید. اگر نماد یا عنصر Office Math نمایانگر مناسبی در آن محیط نداشت، آن را با دستور خاص پروژه جایگزین کنید یا معادله را نادیده بگیرید و مشکل را برای بررسی ثبت کنید.

## **ذخیره معادلات ریاضی به‌صورت MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مثل LaTeX را می‌نویسند، نوشتن کد برای MathML دشوار است زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به سادگی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در XML است، بنابراین MathML معمولاً به‌عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این نمونه کد نشان می‌دهد چگونه یک معادله ریاضی را از ارائه به MathML صادر کنید:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

**دقیقا چه چیزی به‌صورت MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**  
می‌توانید کل پاراگراف ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع متدی برای نوشتن به MathML ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن یا تصویر معمولی؟**  
یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathportion/) قرار دارد و یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) دارد. تصاویر و بخش‌های متنی معمولی بدون [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) قابل صادرات به عنوان فرمول نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا خاص PowerPoint است یا استاندارد؟**  
هدف صادرات، MathML استاندارد (XML) است. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعهٔ ارائه‌ای استاندارد که در برنامه‌ها و وب به‌طور گسترده‌ای به کار می‌رود.

**آیا صادرات فرمول‌ها در جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**  
بله، اگر آن اشیاء بخش‌های متنی دارای [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) داشته باشند، صادر می‌شوند. اگر فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML محتوای اصلی ارائه را تغییر می‌دهد؟**  
خیر. نوشتن MathML تنها سریال‌سازی محتوای فرمول است و فایل ارائه را تغییر نمی‌دهد.