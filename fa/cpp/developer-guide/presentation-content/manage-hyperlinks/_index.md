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
## **مقدمه**

یک ابرپیوند محتوای ارائه را به یک وب‌سایت یا یک مکان داخل ارائه متصل می‌کند. در PowerPoint، ابرپیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، شکل یا چارچوب رسانه‌ای.
* ناوبری به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for C++ به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، تنظیماتشان را به‌روزرسانی کنید و حذف نمایید. مثال‌های زیر نشان می‌دهند چگونه با ابرپیوندها روی عناصر تک‌تایی کار کنید و چگونه به ابرپیوندها در سطح ارائه، اسلاید یا چارچوب متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا چارچوب رسانه‌ای اختصاص دهید. عنصری که به آن ابرپیوند اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن لینک می‌شود، در حالی که یک شکل یا چارچوب، شیء اسلاید را لینک می‌کند.

برای ارائه‌هایی که دارای ابرپیوندهای نسبی هستند، به [Manage the Hyperlink Base](/slides/fa/cpp/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایهٔ سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) ایجاد کنید و با استفاده از متد [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) آن را به بخش متن اختصاص دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به اشکال و چارچوب‌های رسانه‌ای**

متد [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/) را بر روی مستطیل فراخوانی کنید تا کل ناحیهٔ آن قابل کلیک شود. برای نمایش راهنمایی به خوانندگان هنگام گذر ماوس بر روی مستطیل، از [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) استفاده کنید. هر دو متد برای چارچوب‌های تصویر، صدا و ویدئو نیز اعمال می‌شوند.

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

ابرپیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید مشخصی بپرند. مثال زیر از [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) برای لینک کردن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

می‌توانید رنگ متن پیوند شده را تغییر دهید، هنگام فعال‌سازی پیوند صدا پخش یا متوقف کنید و راهنمای متنی (tooltip) که هنگام گذر ماوس ظاهر می‌شود را تنظیم کنید.

### **رنگ**

متد [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) از [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) تعیین می‌کند که آیا یک ابرپیوند از رنگ ابرپیوند ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، لینک اول با استفاده از [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) رنگ پر متن قرمز خود را نمایش می‌دهد. لینک دوم رنگ ابرپیوند ارائه را حفظ می‌کند.

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

یک ابرپیوند می‌تواند هنگام فعال‌سازی صدا پخش کند یا صدای در حال پخش را متوقف کند. برای پیکربندی این رفتارها از متدهای زیر استفاده کنید:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) صدا مرتبط با ابرپیوند را مشخص می‌کند.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) تعیین می‌کند آیا فعال‌سازی ابرپیوند صدای قبلی را متوقف می‌کند یا خیر.

#### **افزودن صدا به ابرپیوند**

دکمهٔ موجود در اسلاید اول از [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) برای پخش صدا از `sampleaudio.wav` هنگام کلیک خواننده استفاده می‌کند. در اسلاید دوم، دکمهٔ جداگانه‌ای از [set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) برای توقف پخش و نگه داشتن خواننده در همان اسلاید استفاده می‌کند.

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

#### **استخراج صدا از ابرپیوند**

مثال زیر ارائهٔ ایجاد شده در بالا را باز می‌کند و صداهای ابرپیوند اولین شکل را از طریق [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) و [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) به حافظه می‌خواند.

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

### **Tooltip و تنظیمات تعامل**

می‌توانید تنظیمات زیر از [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) را پس از اختصاص ابرپیوند به متن یا شکل به‌روزرسانی کنید:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) متن راهنمایی را که بیننده می‌تواند به‌عنوان نکته برای پیوند نمایش دهد، تنظیم می‌کند.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) فریم هدف را در یک frameset والد HTML، در صورت لزوم، مشخص می‌کند.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) تعیین می‌کند آیا فعال‌سازی پیوند مقصد آن را به فهرست ابرپیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) مشخص می‌کند آیا ابرپیوند هنگام کلیک برجسته شود یا خیر.

## **حذف ابرپیوندها از ارائه‌ها**

از [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری مخازن ابرپیوند، شامل پیوندهای بخش متن، قبل از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) یا [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) را فراخوانی کنید؛ حذف عمل کلیک همتای ماوس‌اور آن را حذف نمی‌کند.

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

برای حذف بدون قید و شرط، [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در محدودهٔ انتخاب شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی ابرپیوندها پیش از جایگزینی متن SmartArt**

وقتی پاراگرافی در گرهٔ SmartArt موجود را جایگزین می‌کنید، پاک‌سازی بخش‌های متن می‌تواند یک ابرپیوند قدیمی را باقی بگذارد. پاراگراف را از طریق [ISmartArtNode::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_textframe/) بازیابی کنید. پیش از پاک‌سازی بخش‌ها، با استفاده از [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) که از طریق [get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) بر روی چارچوب متن گرهٔ شکل که پاراگراف را نمایش می‌دهد، فراخوانی می‌شود. این کار تمام ابرپیوندها در آن چارچوب، از جمله پیوندهای موجود در پاراگراف‌های دیگر، را حذف می‌کند.

مثال فرض می‌کند که شکل سوم در اسلاید اول یک گرافیک SmartArt است. این مثال پاراگراف اول گرهٔ چهارم را جایگزین می‌کند. در این ارائه، شکل اول گرهٔ متن آن پاراگراف را نمایش می‌دهد.

پس از افزودن هر دو بخش، مثال قالب‌بندی مؤثر آن‌ها را با استفاده از [GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) می‌خواند. متد مؤثر [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformateffectivedata/get_hyperlinkclick/) لینک جدید را برای بخش اول برمی‌گرداند و برای بخش دوم `nullptr` برمی‌گرداند.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"SmartArtHyperlink.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(2));
auto node = smartArt->get_NodeFromAll(3);
auto paragraph = node->get_TextFrame()->get_Paragraph(0);

node->get_Shape(0)->get_TextFrame()->get_HyperlinkQueries()->RemoveAllHyperlinks();
auto portions = paragraph->get_Portions();
portions->Clear();

auto link = MakeObject<Portion>(u"New reference");
auto destination = MakeObject<Hyperlink>(u"https://example.com/new");
link->get_PortionFormat()->set_HyperlinkClick(destination);
portions->Add(link);
auto text = MakeObject<Portion>(u" (updated)");
portions->Add(text);

auto firstAction = link->get_PortionFormat()->GetEffective()->get_HyperlinkClick();
auto secondAction = text->get_PortionFormat()->GetEffective()->get_HyperlinkClick();
Console::WriteLine(firstAction->get_ExternalUrl()); // https://example.com/new
Console::WriteLine(secondAction ? secondAction->get_ExternalUrl() : String(u"nullptr")); // nullptr
```

## **ساخت یک موجودی کامل از ابرپیوندها**

پیش از توزیع ارائه، اقدامات تعاملی و لینک‌های وب آن را فهرست کنید. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه فهرست صاف رشته‌های URL. هر دو متد [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) و [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) را برای هر مخزن بررسی کنید. آن‌ها مستقل‌اند: همان مخزن می‌تواند هر دو عمل را نشان دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر مخزن نیاز داشته باشد.

فقط اسکن ابرپیوندهای سطح شکل می‌تواند پیوندهای متصل به بخش‌های متن را نادیده بگیرد. به جای آن دامنهٔ مناسب را پرس و جو کنید و مخازن بازگردانده شده را نگه دارید تا بعدها بتوانید عمل‌هایشان را به‌روزرسانی یا حذف کنید.

### **پرس و جو دامنه‌های ارائه، اسلاید و چارچوب متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) از طریق [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)، [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) و [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) در دسترس است. هر دامنهٔ پرس و جوهای مشابهی دارد:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) مخازنی با عمل کلیک را برمی‌گرداند.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) مخازنی با عمل ماوس‌اور را برمی‌گرداند.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) مخازنی که هر یک یا هر دو عمل را دارند، برمی‌گرداند.

این مثال عمل‌های کلیک و ماوس‌اور را به یک شکل و متن آن اختصاص می‌دهد و یک عمل ماکرو را به یک دکمهٔ جداگانه اضافه می‌کند. مخازنی که توسط [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) بازگردانده می‌شوند، با تعداد هر نوع فعال‌سازی مقایسه می‌شوند. یک پرس و جوی چارچوب متن فقط پیوندهای موجود در متن را می‌شمارد. عمل‌های خود شکل در پرس و جوهای اسلاید و ارائه نمایان می‌شوند.

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

برای این مثال، پرس و جوهای ارائه و اسلاید هر کدام سه مخزن کلیک، دو مخزن ماوس‌اور و سه مخزن با هر یک از عمل‌ها را گزارش می‌کنند. پرس و جوی چارچوب متن یک مخزن در هر دسته گزارش می‌دهد.

### **دسته‌بندی عمل‌ها و مقصدها**

از [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب شامل موارد زیر می‌شوند:

| مقدار | معنی برای بررسی |
| --- | --- |
| `Hyperlink` | ابرپیوند خارجی؛ URL و طرح‌طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش ساختهٔ نمایش اسلاید، در زمینهٔ نمایش اسلاید حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش فعلی یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | راه‌اندازی برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائه دیگر؛ جدا از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل نامشخص که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) و مقاصد داخلی خاص را از طریق [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/) بخوانید. عمل‌های داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنا نیست که مخزن هیچ عملی ندارد. زمانی که [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) با URL نرمال‌شده متفاوت باشد، آن را حفظ کنید و در صورت موجود بودن، tooltip برگشتی توسط [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) را نیز اضافه کنید.

### **گزارش، پاک‌سازی و تأیید ابرپیوندها**

این مثال C++ ارائهٔ مثال قبلی را باز می‌کند و برای هر عمل یک رکورد JSON می‌نویسد. از [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری مخازن بر روی اسلایدهای عادی، مسترها، طرح‌بندی‌ها و یادداشت‌ها، از جمله مسترهای یادداشت و توزیع‌کننده، استفاده می‌کند. هویت اشاره‌گر برای شمارش هر مخزن یک بار به کار رفته و سیاست زیر اعمال می‌شود، سپس ارائهٔ ذخیره‌شده برای بررسی هر دو عمل کلیک و ماوس‌اور دوباره باز می‌شود.

رکورد گزارش شامل اندیس اسلاید یک‌پایه و [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) (در صورت موجود بودن) است. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) اسلاید مالک را برای مخازن پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و یادداشت‌ها اندیس اسلاید عادی ندارند و با دامنهٔ خود شناخته می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌طور جداگانه برچسب‌گذاری می‌شوند؛ انواع دیگر مخازن نام نوع زمان اجرا را حفظ می‌کنند. هر مخزن یک شناسهٔ محلی گزارش دریافت می‌کند تا دو عمل آن قابل هم‌پوشانی باشند.

این سیاست محدود کننده به‌طور عمدی تنها URLهای HTTPS مطلق و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایل، سایر عمل‌های نمایش اسلاید، عمل‌های نامشخص و سایر طرح‌URLها رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. تنها HTTPS به تنهایی اعتماد را تضمین نمی‌کند: لیست‌های مجاز میزبان و بررسی‌های دیگر را برای برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای عمل‌ها بررسی می‌کند.

برای اصلاح، [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) مخزن از [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) و [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) پشتیبانی می‌کند. در اینجا، کلیک‌های خارجی ممنوع با یک صفحهٔ ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و عمل‌های ماوس‌اور ممنوع دیگر به طور مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام تخلف‌های سیاست حذف شوند. قبل از استقرار، صفحهٔ جایگزین تحت مالکیت برنامه‌تان را انتخاب کنید.

پرچم صادرات گزارش از یک سیاست محافظت‌کننده برای مرور PDF استفاده می‌کند: عمل‌های ماوس‌اور و هر چیزی به جز یک لینک خارجی یا پرش اسلاید خاص را به‌عنوان ممکن است پشتیبانی‌نشده علامت‌گذاری می‌کند. این یک نکتهٔ مرور است، نه آزمون قابلیت یا تضمینی که لینک‌های بدون پرچم در صادرات زنده بمانند. صادرات‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/cpp/convert-powerpoint-to-html/) ممکن است ابرپیوندها را حفظ کنند، بسته به عمل، گزینه‌های صادرات و نمایشگر. [images](/slides/fa/cpp/convert-powerpoint-to-png/) و [video](/slides/fa/cpp/convert-powerpoint-to-video/) کاریزلا نمی‌توانند ابرپیوندهای تعاملی را حفظ کنند؛ هنگام بررسی برای این خروجی‌ها همهٔ عمل‌ها را پرچم بزنید.

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

با ورودی ایجاد شده در بالا، گزارش شامل پنج ردیف عمل می‌شود. لینک ماوس‌اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی که شامل URL کلیک خارجی ممنوع است نیز شاخهٔ جایگزینی را اجرا می‌کند. یک مخزن با کلیک مجاز و ماوس‌اور ممنوع، عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) است که هر دو نوع فعال‌سازی را در دامنهٔ انتخاب شده صرف‌نظر از سیاست حذف می‌کند. تأیید در اینجا فقط عمل‌های ابرپیوند را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیاء OLE یا سایر محتوای فعال حذف نمی‌شوند و فایل PDF یا HTML صادرشده نیز اعتبارسنجی نمی‌شود.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک ابرپیوند داخلی به یک اسلاید تک هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک دهید.

**آیا می‌توانم ابرپیوند را به عناصر اسلاید مستر بچسبانم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و طرح‌بندی از ابرپیوند پشتیبانی می‌کنند. لینک‌های این عناصر در طول نمایش اسلاید بر روی اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا ابرپیوندها هنگام صادرات به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

صادرات‌های PDF و HTML پشتیبانی‌شده ممکن است ابرپیوندها را حفظ کنند؛ تصاویر نقطه‌چکی و ویدئو نمی‌توانند این کار را انجام دهند. به ملاحظات صادرات در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.