---
title: مدیریت ابرلینک‌های ارائه در C++
linktitle: مدیریت ابرلینک
type: docs
weight: 20
url: /fa/cpp/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن ابرلینک
- ایجاد ابرلینک
- قالب‌بندی ابرلینک
- حذف ابرلینک
- به‌روزرسانی ابرلینک
- ابرلینک متن
- ابرلینک اسلاید
- ابرلینک شکل
- ابرلینک تصویر
- ابرلینک ویدئو
- ابرلینک قابل تغییر
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "به راحتی ابرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ مدیریت کنید—در عرض چند دقیقه تعامل و گردش کار را ارتقا دهید."
---
## **مقدمه**

یک ابرلینک مرجعی به یک شیء، داده یا مکانی درون چیزی است. این‌ها نمونه‌های رایج ابرلینک‌ها در ارائه‌های PowerPoint هستند:

* پیوندها به وب‌سایت‌ها در متن‌ها، اشکال یا رسانه‌ها
* پیوندها به اسلایدها

Aspose.Slides برای C++ به شما امکان می‌دهد کارهای متعددی مرتبط با ابرلینک‌ها در ارائه‌ها انجام دهید. 

{{% alert color="info" %}} 
ممکن است بخواهید ویرایشگر آنلاین رایگان و ساده Aspose برای PowerPoint را بررسی کنید.[free online PowerPoint editor.](https://products.aspose.app/slides/fa/editor)
{{% /alert %}} 

## **افزودن ابرلینک‌های URL**

### **افزودن ابرلینک‌های URL به متن**

این کد C++ نشان می‌دهد چگونه یک ابرلینک وب‌سایت را به متن اضافه کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **افزودن ابرلینک‌های URL به اشکال یا فریم‌ها**

این نمونه کد در C++ نشان می‌دهد چگونه یک ابرلینک وب‌سایت را به یک شکل اضافه کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **افزودن ابرلینک‌های URL به رسانه‌ها**

Aspose.Slides امکان افزودن ابرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد. 

این نمونه کد نشان می‌دهد چگونه به یک **تصویر** ابرلینک اضافه کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// تصویر را به ارائه اضافه می‌کند
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 این نمونه کد نشان می‌دهد چگونه به یک **فایل صوتی** ابرلینک اضافه کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 این نمونه کد نشان می‌دهد چگونه به یک **ویدئو** ابرلینک اضافه کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="نکته"  color="info"  %}} 
ممکن است بخواهید *[Manage OLE](https://docs.aspose.com/slides/fa/cpp/manage-ole/)* را ببینید.
{{% /alert %}}

## **استفاده از ابرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که ابرلینک‌ها امکان افزودن ارجاع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این نمونه کد نشان می‌دهد چگونه فهرست مطالبی با ابرلینک‌ها ایجاد شود:

``` cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

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

## **قالب‌بندی ابرلینک‌ها**

### **رنگ**

با متدهای [set_ColorSource()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) و [get_ColorSource()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) در اینترفیس [IHyperlink](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink)، می‌توانید رنگ ابرلینک‌ها را تنظیم و همچنین اطلاعات رنگ را از آن‌ها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این خصوصیت برای نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این نمونه کد عملیاتی را نشان می‌دهد که در آن ابرلینک‌های با رنگ‌های مختلف به یک اسلاید اضافه شده‌اند:

``` cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **حذف ابرلینک‌ها از ارائه‌ها**

### **حذف ابرلینک‌ها از متن**

این کد C++ نشان می‌دهد چگونه ابرلینک را از یک متن در اسلاید ارائه حذف کنید:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

### **حذف ابرلینک‌ها از اشکال یا فریم‌ها**

این کد C++ نشان می‌دهد چگونه ابرلینک را از یک شکل در اسلاید ارائه حذف کنید:

``` cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **Hyperlink قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.hyperlink) قابل تغییر است. با این کلاس می‌توانید مقادیر متدهای زیر را تغییر دهید:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

این قطعه کد نشان می‌دهد چگونه یک ابرلینک به اسلاید اضافه و پس از آن نکته راهنمای (tooltip) آن را ویرایش کنید:

``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **متدهای پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید IHyperlinkQueries را از یک ارائه، اسلاید یا متنی که ابرلینک در آن تعریف شده است، دسترسی داشته باشید. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

کلاس IHyperlinkQueries متدهای زیر را پشتیبانی می‌کند:

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **سوالات متداول**

### چگونه می‌توان navigation داخلی نه فقط به یک اسلاید، بلکه به «بخش» یا اولین اسلاید یک بخش ایجاد کرد؟

بخش‌ها در PowerPoint گروه‌بندی‌هایی از اسلایدها هستند؛ navigation در واقع به یک اسلاید خاص هدف می‌گیرد. برای «رفتن به یک بخش»، معمولاً به اولین اسلاید آن بخش لینک می‌کنید.

### آیا می‌توانم ابرلینک را به عناصر اسلاید مستر وصل کنم تا در تمام اسلایدها کار کند؟

بله. عناصر اسلاید مستر و لایه‌ها از ابرلینک پشتیبانی می‌کنند. چنین لینک‌هایی در اسلایدهای فرزند ظاهر می‌شوند و در طول نمایش اسلاید قابل کلیک هستند.

### آیا ابرلینک‌ها هنگام صادرات به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟

در [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، بله—لینک‌ها عموماً حفظ می‌شوند. هنگام صادرات به [images](/slides/fa/cpp/convert-powerpoint-to-png/) و [video](/slides/fa/cpp/convert-powerpoint-to-video/)، قابلیت کلیک شدن منتقل نمی‌شود زیرا فرمت‌های این‌گونه (فریم‌های رستر/ویدئو) از ابرلینک‌ها پشتیبانی نمی‌کنند.