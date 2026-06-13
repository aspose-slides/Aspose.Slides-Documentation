---
title: صادر کردن معادلات ریاضی از ارائه‌ها در C++
linktitle: صادر کردن معادلات
type: docs
weight: 30
url: /fa/cpp/exporting-math-equations/
keywords:
- صادر کردن معادلات ریاضی
- MathML
- LaTeX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "صادرات بدون درز معادلات ریاضی از PowerPoint به MathML با استفاده از Aspose.Slides برای C++ را فعال کنید — قالب‌بندی را حفظ کنید و سازگاری را افزایش دهید."
---
## **مقدمه**

Aspose.Slides for C++ به شما امکان می‌دهد معادلات ریاضی را از ارائه‌ها استخراج کنید. به عنوان مثال، ممکن است نیاز داشته باشید معادلات ریاضی موجود در اسلایدها (از یک ارائه خاص) را استخراج کرده و در برنامه یا پلتفرم دیگری استفاده کنید.

{{% alert color="primary" %}} 

شما می‌توانید معادلات را به MathML صادر کنید، که یک فرمت یا استاندارد محبوب برای معادلات ریاضی و محتوای مشابه است که در وب و بسیاری از برنامه‌ها مشاهده می‌شود.

{{% /alert %}}

## **ذخیره معادلات ریاضی به‌صورت MathML**

در حالی که انسان‌ها به راحتی کد برخی فرمت‌های معادلات مانند LaTeX را می‌نویسند، نوشتن کد برای MathML برای آن‌ها دشوار است، زیرا این فرمت برای تولید خودکار توسط برنامه‌ها طراحی شده است. برنامه‌ها به راحتی MathML را می‌خوانند و تجزیه می‌کنند چون کد آن در قالب XML است، بنابراین MathML به‌طور معمول به عنوان فرمت خروجی و چاپ در بسیاری از حوزه‌ها استفاده می‌شود.

این نمونه کد نشان می‌دهد چگونه یک معادله ریاضی را از یک ارائه به MathML صادر کنید:

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

**دقیقاً چه چیزی به MathML صادر می‌شود—یک پاراگراف یا یک بلوک فرمول منفرد؟**

شما می‌توانید یا یک پاراگراف کامل ریاضی ([MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/)) یا یک بلوک منفرد ([MathBlock](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathblock/)) را به MathML صادر کنید. هر دو نوع یک روش برای نوشتن به MathML فراهم می‌کنند.

**چگونه می‌توانم تشخیص دهم که یک شیء در اسلاید یک فرمول ریاضی است و نه متن عادی یا تصویر؟**

یک فرمول در یک [MathPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathportion/) زندگی می‌کند و دارای یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) است. تصاویر و بخش‌های متن عادی که [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) ندارند، فرمول‌های قابل صادر نیستند.

**منبع MathML در یک ارائه چیست—آیا مخصوص PowerPoint است یا یک استاندارد؟**

صادرات به MathML استاندارد (XML) هدف دارد. Aspose از Presentation MathML استفاده می‌کند—زیرمجموعه ارائه‌ای استاندارد—که به‌طور گسترده‌ای در برنامه‌ها و وب استفاده می‌شود.

**آیا صادرات فرمول‌ها داخل جداول، SmartArt، گروه‌ها و غیره پشتیبانی می‌شود؟**

بله، اگر این اشیاء شامل بخش‌های متنی با یک [MathParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.mathtext/mathparagraph/) (یعنی فرمول‌های واقعی PowerPoint) باشند، صادر می‌شوند. اگر یک فرمول به‌صورت تصویر جاسازی شده باشد، صادر نمی‌شود.

**آیا صادرات به MathML فایل ارائه اصلی را تغییر می‌دهد؟**

خیر. نوشتن MathML یک سریال‌سازی از محتوای فرمول است؛ این کار فایل ارائه را تغییر نمی‌دهد.