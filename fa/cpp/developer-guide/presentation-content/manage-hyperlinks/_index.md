---
title: مدیریت ابرپیوندهای ارائه در C++
linktitle: مدیریت ابرپیوندها
type: docs
weight: 20
url: /fa/cpp/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن ابرپیوند
- ایجاد ابرپیوند
- قالب‌بندی ابرپیوند
- حذف ابرپیوند
- به‌روزرسانی ابرپیوند
- ابرپیوند متن
- ابرپیوند اسلاید
- ابرپیوند شکل
- ابرپیوند تصویر
- ابرپیوند ویدئو
- ابرپیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف ابرپیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++، با استفاده از مثال‌های C++."
---
## **معرفی**

یک ابرپیوند محتویات ارائه را به یک وب‌سایت یا مکان دیگری درون ارائه متصل می‌کند. در PowerPoint، ابرپیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، شکل یا قاب رسانه‌ای.
* هدایت به اسلاید دیگر، مثلا از فهرست مطالب.

Aspose.Slides for C++ به شما امکان افزودن این پیوندها، کنترل ظاهر و صدا، به‌روزرسانی تنظیمات و حذف آن‌ها را می‌دهد. مثال‌های زیر نشان می‌دهند چگونه با ابرپیوندها در عناصر منفرد کار کنید و چگونه به ابرپیوندها در سطح ارائه، اسلاید یا قاب‑متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
شما می‌توانید ارائه‌ها را با **[ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor)** ویرایش کنید.
{{% /alert %}} 

## **افزودن ابرپیوندهای URL**

شما می‌توانید یک URL وب‌سایت را به متن، شکل یا قاب رسانه‌ای اختصاص دهید. عنصری که ابرپیوند به آن اختصاص می‌یابد، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن، متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب، شیء اسلاید را لینک می‌کند.

برای ارائه‌های حاوی ابرپیوندهای نسبی، به **[مدیریت پایه ابرپیوند](/slides/fa/cpp/presentation-properties/#manage-the-hyperlink-base)** مراجعه کنید تا پایه سطوح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن ابرپیوندهای URL به متن**

برای لینک‌کردن متن به یک وب‌سایت، یک **[Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/)** ایجاد کنید و با متد **[set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/)** بخشی از متن را اختصاص دهید، همان‌طور که در زیر نشان داده شد. تنها همان بخش متن قابل کلیک می‌شود.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **افزودن ابرپیوندهای URL به شکل‌ها و قاب‌های رسانه‌ای**

برای قابل کلیک کردن یک شکل یا قاب، از متد **[set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/)** آن استفاده کنید. ابرپیوند به خود شیء تعلق دارد، نه به بخشی از متن داخل آن.

همین روش برای قاب‌های تصویر، صوت و ویدئو نیز صدق می‌کند: ابرپیوند را به قاب اختصاص دهید و در صورت نیاز از **[set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/)** برای افزودن نکتهٔ راهنمایی استفاده کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **استفاده از ابرپیوندها برای ایجاد فهرست مطالب**

ابیرپیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید مشخصی بروید. مثال زیر از **[SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/)** برای لینک‌کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
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
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **قالب‌بندی ابرپیوندها**

### **رنگ**

متد **[set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/)** از **[IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/)** تعیین می‌کند که آیا یک ابرپیوند از رنگ ابرپیوند ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، **[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/)** را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این قابلیت در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو ابرپیوند متنی را به همان اسلاید اضافه می‌کند. اولی با پر شدن متن قرمز، دومین رنگ پیش‌فرض ابرپیوند را حفظ می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **صدا**

یک ابرپیوند می‌تواند هنگام فعال‌سازی صدا پخش کند یا صدایی که در حال پخش است متوقف کند. از روش‌های زیر برای پیکربندی این رفتارها استفاده کنید:

- **[IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/)** صدا مربوط به ابرپیوند را مشخص می‌کند.
- **[IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/)** کنترل می‌کند که آیا فعال‌سازی ابرپیوند صدا را متوقف می‌کند یا خیر.

#### **افزودن صدای ابرپیوند**

مثال زیر فایل `sampleaudio.wav` را بارگذاری کرده و به دکمه‌ای در اسلاید اول اختصاص می‌دهد. کلیک بر روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌برد. یک شکل دوم در همان اسلاید هنگام کلیک صدا را متوقف می‌کند، بدون انجام عمل ناوبری.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **استخراج صدای ابرپیوند**

مثال زیر ارائهٔ ساخته‌شده در بالا را باز می‌کند و صداهای ابرپیوند اولین شکل را از طریق **[get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/)** و **[get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/)** در حافظه می‌خواند.

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **نکتهٔ راهنما و تنظیمات تعامل**

بعد از اختصاص ابرپیوند به متن یا شکل، می‌توانید تنظیمات زیر **[IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/)** را با این متدها به‌روز کنید:

- **[set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/)** متنی را که بیننده می‌تواند به‌عنوان راهنما نمایش دهد تنظیم می‌کند.
- **[set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/)** چارچوب هدف را در یک فریم‌ست HTML والد مشخص می‌کند، در صورت امکان.
- **[set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/)** تعیین می‌کند که آیا فعال‌سازی لینک به فهرست ابرپیوندهای مشاهده‌شده افزوده می‌شود یا نه.
- **[set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/)** کنترل می‌کند که آیا ابرپیوند هنگام کلیک برجسته می‌شود یا خیر.

## **حذف ابرپیوندها از ارائه‌ها**

از **[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** برای جمع‌آوری کانتینرهای ابرپیوند، شامل پیوندهای بخش‑متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط **[RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)** یا **[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)** را فراخوانی کنید؛ حذف عمل کلیک، عمل ماوس‑اور را حذف نمی‌کند.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

برای حذف بدون شرط، **[RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)** هر دو نوع فعال‌سازی را در محدودهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و نکات، به **[گزارش، تصفیه و تأیید ابرپیوندها](#report-sanitize-and-verify-hyperlinks)** مراجعه کنید.

## **ساخت فهرست کامل ابرپیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و پیوندهای وب آن را فهرست کنید. **[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** اشیای **[IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/)** را برمی‌گرداند، نه لیستی تخت از رشته‌های URL. برای هر کانتینر هر دو **[get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/)** و **[get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/)** را بررسی کنید. این‌ها مستقل هستند: همان کانتینر می‌تواند هر دو عمل را داشته باشد، بنابراین یک گزارش کامل می‌تواند تا دو ردیف برای هر کانتینر داشته باشد.

فقط اسکن ابرپیوندهای سطح شکل ممکن است پیوندهای متصل به بخش‌های متن را از دست بدهد. به جای آن دامنهٔ مناسب را پرس‌و‌جو کنید و کانتینرهای بازگشتی را نگه دارید تا بعداً بتوانید اقداماتشان را به‌روزرسانی یا حذف کنید.

### **پرس‌و‌جوی دامنه‌های ارائه، اسلاید و قاب‑متن**

رابط **[IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/)** از طریق **[IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)**، **[IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/)** و **[ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/)** در دسترس است. هر دامنه همان پرس‌و‌جوها را پشتیبانی می‌کند:

- **[GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/)** کانتینرهای دارای عمل کلیک را برمی‌گرداند.
- **[GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/)** کانتینرهای دارای عمل ماوس‑اور را برمی‌گرداند.
- **[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/)** کانتینرهای دارای هر دو یا یکی از این اعمال را برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک ماوس‑اور فایل، ناوبری اسلاید داخلی، یک لینک ماوس‑اور متن و یک عمل ماکرو است. هیچ‌یک از این اعمال اجرا نمی‌شوند. همان سه پرس‌و‌جو در هر دامنه کار می‌کند؛ شمارش‌ها نشانگر تعداد کانتینرها، نه مجموع اعمال هستند. دامنهٔ قاب‑متن پیوندهای خود شکل محدودکننده را شامل نمی‌شود.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
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
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

در این مثال، پرس‌و‌جوهای ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر ماوس‑اور و سه کانتینر دارای هر یک از اعمال را گزارش می‌کنند. پرس‌و‌جوی قاب‑متن یک کانتینر در هر دسته گزارش می‌دهد.

### **دسته‌بندی اعمال و مقصدها**

از **[IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/)** برای تفسیر عمل قبل از تفسیر مقصد استفاده کنید. مقادیر **[HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/)** بیش از ناوبری وب شامل می‌شوند:

| مقادیر | معنای ممیزی |
| --- | --- |
| `Hyperlink` | ابرپیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌فرض اسلایدشو. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش فعلی یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | راه‌اندازی برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائه دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری یا عمل ناشناخته که نیاز به بررسی دارد. |

مقصدهای خارجی را از **[get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/)** و مقصدهای داخلی خاص را از **[get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/)** بخوانید. اعمال داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنی نیست که کانتینر بدون عمل باشد. هنگام متفاوت بودن **[get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/)** از URL نرمال‌شده، آن را حفظ کنید و نکتهٔ راهنمایی برگشتی توسط **[get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/)** را در صورت موجود بودن اضافه کنید.

### **گزارش، تصفیه و تأیید ابرپیوندها**

مثال زیر در C++ یک ارائهٔ موجود (فایل ساخته‌شده در بالا) را می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را مجدداً بررسی کند. قبل از تغییر کانتینرها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوباره از هویت اشاره‌گر استفاده می‌کند. پرس‌و‌جوهای ارائه اسلایدهای معمولی را پوشش می‌دهد؛ برای موجودی سراسری بسته، مسترها، لایه‌ها، نکات و مسترهای نکات و برگه‌ها را نیز به‌صورت صریح پرس‌و‌جو می‌کند.

گزارش شاخص اسلاید به‌صورت یک‌پایه و **[get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/)** (در صورت موجود بودن) را ثبت می‌کند. **[ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/)** اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، لایه‌ها و نکات شاخص اسلاید معمولی ندارند و با دامنهٔ خود شناسایی می‌شوند. کانتینرهای شکل و فرمت‌بندی بخش‑متن به‌طور جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا را حفظ می‌کنند. هر کانتینر یک شناسهٔ گزارش‑محلی می‌گیرد تا دو عمل آن بتوانند به‌هم مرتبط شوند.

این سیاست کاربردی محدودکننده فقط URLهای مطلق HTTPS و اهداف اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح URL‌ها رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. تنها HTTPS اعتماد ایجاد نمی‌کند: لیست سفید میزبان‌ها و سایر بررسی‌ها را به برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتاها را بدون دنبال‌کردن لینک‌ها یا اجرا کردن اعمال ممیزی می‌کند.

برای اصلاح، **[get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/)** کانتینر پشتیبانی می‌کند **[SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)**، **[RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)** و **[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)**. در اینجا، پیوندهای کلیک خارجی ممنوع با یک صفحهٔ فرودی HTTPS ثابت جایگزین می‌شوند؛ سایر کلیک‌ها و ماوس‑اورهای ممنوع به‌صورت جداگانه حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام نقض‌های سیاست حذف شوند. قبل از استقرار، صفحهٔ جایگزین متعلق به برنامه را انتخاب کنید.

پرچم صادراتی گزارش از سیاست بازنگری PDF محافظه‌کارانه استفاده می‌کند: اعمال ماوس‑اور و هر چیزی جز لینک خارجی یا پرش اسلاید خاص را به‌عنوان «احتمالاً پشتیبانی نمی‌شود» علامت‌گذاری می‌کند. این یک نکتهٔ راهنمایی بازنگری است، نه آزمون قابلیت یا تضمینی برای بقا پس از صادرات. صادرات‌های **[PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)** و **[HTML](/slides/fa/cpp/convert-powerpoint-to-html/)** ممکن است بسته به عمل، گزینه‌های صادرات و نمایشگر، ابرپیوندها را حفظ کنند. **[تصاویر](/slides/fa/cpp/convert-powerpoint-to-png/)** رستر و **[ویدئو](/slides/fa/cpp/convert-powerpoint-to-video/)** نمی‌توانند ابرپیوندهای تعاملی را حفظ کنند؛ هنگام ممیزی برای این خروجی‌ها هر عمل را پرچم بزنید.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

با ورودی ساخته‌شده در بالا، گزارش شامل پنج ردیف عمل می‌شود. پیوند ماوس‑اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و ماوس‑اور ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با **[RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)** تفاوت دارد که هر دو نوع فعال‌سازی را در تمام دامنهٔ انتخاب‌شده صرف نظر از سیاست حذف می‌کند. تأیید در اینجا فقط اعمال ابرپیوندها را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل‌های PDF یا HTML صادرشده را ارزیابی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک ابرپیوند داخلی به یک اسلاید فردی هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم ابرپیوند را به عناصر مستر اسلاید متصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لایه‌ها از ابرپیوندها پشتیبانی می‌کنند. این پیوندها در حالت نمایش اسلاید روی اسلایدهایی که از مستر یا لایهٔ مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا ابرپیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

صدورهای PDF و HTML پشتیبانی‌شده ممکن است ابرپیوندها را حفظ کنند؛ تصاویر رستر و ویدئو نمی‌توانند. برای جزئیات بیشتر به **[گزارش، تصفیه و تأیید ابرپیوندها](#report-sanitize-and-verify-hyperlinks)** مراجعه کنید.