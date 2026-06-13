---
title: مدیریت پیوندهای ارائه در C++
linktitle: مدیریت پیوند
type: docs
weight: 20
url: /fa/cpp/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به‌راحتی پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ مدیریت کنید—تعامل و جریان کار را در عرض چند دقیقه ارتقا دهید."
---
## **مقدمه**

یک پیوند (hyperlink) مرجعی به یک شیء، داده یا مکانی در چیزی است. این‌ها پیوندهای رایج در ارائه‌های PowerPoint هستند:

* پیوند به وب‌سایت‌ها داخل متن‌ها، اشکال یا رسانه‌ها
* پیوند به اسلایدها

Aspose.Slides برای C++ به شما امکان انجام بسیاری از وظایف مرتبط با پیوندها در ارائه‌ها را می‌دهد.

{{% alert color="primary" %}} 
ممکن است بخواهید Aspose ساده، [ویرایشگر رایگان آنلاین PowerPoint را بررسی کنید.](https://products.aspose.app/slides/fa/editor)
{{% /alert %}} 

## **افزودن پیوندهای URL**

### **افزودن پیوندهای URL به متن**

این کد C++ نشان می‌دهد چگونه یک پیوند وب‌سایت به یک متن اضافه کنید:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **افزودن پیوندهای URL به اشکال یا فریم‌ها**

این نمونه کد در C++ نشان می‌دهد چگونه یک پیوند وب‌سایت به یک شکل اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **افزودن پیوندهای URL به رسانه‌ها**

Aspose.Slides به شما اجازه می‌دهد پیوندهایی به تصاویر، فایل‌های صوتی و ویدئویی اضافه کنید.

این نمونه کد نشان می‌دهد چگونه یک پیوند به یک **تصویر** اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// اضافه کردن تصویر به ارائه
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

این نمونه کد نشان می‌دهد چگونه یک پیوند به یک **فایل صوتی** اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

این نمونه کد نشان می‌دهد چگونه یک پیوند به یک **ویدئو** اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 
ممکن است بخواهید *[مدیریت OLE](https://docs.aspose.com/slides/fa/cpp/manage-ole/)* را ببینید.
{{% /alert %}}

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

از آنجا که پیوندها به شما اجازه می‌دهند مراجع به اشیاء یا مکان‌ها را اضافه کنید، می‌توانید از آنها برای ایجاد فهرست مطالب استفاده کنید.

این نمونه کد نشان می‌دهد چگونه یک فهرست مطالب با پیوندها ایجاد کنید:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **قالب‌بندی پیوندها**

### **رنگ**

با متدهای [set_ColorSource()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) و [get_ColorSource()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) در اینترفیس [IHyperlink](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink) می‌توانید رنگ پیوندها را تنظیم کرده و همچنین اطلاعات رنگ را از پیوندها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این نمونه کد عملی را نشان می‌دهد که در آن پیوندهایی با رنگ‌های مختلف به همان اسلاید اضافه شدند:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **حذف پیوندها از ارائه‌ها**

### **حذف پیوندها از متن**

این کد C++ نشان می‌دهد چگونه پیوند را از یک متن در اسلاید ارائه حذف کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **حذف پیوندها از اشکال یا فریم‌ها**

این کد C++ نشان می‌دهد چگونه پیوند را از یک شکل در اسلاید ارائه حذف کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **پیوند قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.hyperlink) قابل تغییر (mutable) است. با استفاده از این کلاس می‌توانید مقادیر متدهای زیر را تغییر دهید:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

این قطعه کد نشان می‌دهد چگونه یک پیوند به اسلاید اضافه کنید و پس از آن tooltip آن را ویرایش کنید:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **متدهای پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید IHyperlinkQueries را از یک ارائه، اسلاید یا متنی که پیوند برای آن تعریف شده است دسترسی پیدا کنید.

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

کلاس IHyperlinkQueries این متدها را پشتیبانی می‌کند:

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **سوالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint مجموعه‌ای از اسلایدها هستند؛ ناوبری عملاً به یک اسلاید خاص اشاره می‌کند. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش پیوند می‌دهید.

**آیا می‌توانم پیوندی را به عناصر اسلاید مستر وصل کنم تا در همه اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و لایه‌ها از پیوندها پشتیبانی می‌کنند. این پیوندها در اسلایدهای فرزند ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

**آیا پیوندها هنگام خروجی گرفتن به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/cpp/convert-powerpoint-to-html/) بله—پیوندها معمولاً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/cpp/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/cpp/convert-powerpoint-to-video/)، قابلیت کلیک شدن منتقل نمی‌شود به دلیل ماهیت آن فرمت‌ها (فریم‌های رستر/ویدئو پیوند را پشتیبانی نمی‌کنند).