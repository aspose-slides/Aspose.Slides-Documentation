---
title: صادرات معادلات ریاضی از ارائه‌ها در C++
linktitle: صادرات معادلات
type: docs
weight: 30
url: /fa/cpp/exporting-math-equations/
keywords:
- صادرات معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "صادرات بدون مشکل معادلات ریاضی از PowerPoint به MathML را با استفاده از Aspose.Slides برای C++ باز کنید — قالب‌بندی را حفظ کنید و سازگاری را ارتقا دهید."
---
## **مقدمه**

Aspose.Slides for C++ به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 
می‌توانید معادله‌ها را به MathML صادر کنید، قالب یا استانداردی محبوب برای معادلات ریاضی و محتویات مشابه که در وب و بسیاری از برنامه‌ها مشاهده می‌شود. 
{{% /alert %}}

## **ذخیرهٔ معادلات ریاضی به MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادله مانند LaTeX را می‌نویسند، نوشتن کد برای MathML برای آن‌ها دشوار است زیرا MathML قرار است به‌صورت خودکار توسط برنامه‌ها تولید شود. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در XML است، بنابراین MathML به‌طور معمول به‌عنوان قالب خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

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

## **سؤالات متداول**

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول جداگانه؟**

می‌توانید یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک جداگانه ([MathBlock](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع روشی برای نوشتن به MathML ارائه می‌دهند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است نه متن عادی یا تصویر؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathportion/) زندگی می‌کند و یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) دارد. تصاویر و بخش‌های متنی عادی بدون [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) قابل استخراج به‌صورت فرمول نیستند.

**MathML در یک ارائه از کجا می‌آید—آیا مخصوص PowerPoint است یا یک استاندارد؟**

صدور به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعهٔ ارائه‌ای استاندارد که به‌طور گسترده در برنامه‌ها و وب استفاده می‌شود.

**آیا استخراج فرمول‌ها داخل جدول‌ها، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر آن اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) باشند (یعنی فرمول‌های واقعی PowerPoint)، استخراج می‌شوند. اگر یک فرمول به‌صورت تصویر تعبیه شده باشد، استخراج نمی‌شود.

**آیا استخراج به MathML فایل ارائهٔ اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML سریال‌سازی محتویات فرمول است؛ این کار فایل ارائه را تغییر نمی‌دهد.