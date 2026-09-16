---
title: مدیریت پیوندهای ارائه در C++
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/cpp/manage-hyperlinks/
keywords:
- اضافه کردن URL
- اضافه کردن پیوند
- ایجاد پیوند
- قالب بندی پیوند
- حذف پیوند
- به روزرسانی پیوند
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
description: "پیوندها را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه، قالب بندی، به روزرسانی و حذف کنید، با استفاده از مثال‌های C++."
---
## **مقدمه**

یک پیوند (hyperlink) محتوای ارائه را به یک وب‌سایت یا موقعیتی درون ارائه وصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از طریق متن، شکل یا چارچوب رسانه‌ای.
* رفتن به اسلاید دیگری، برای مثال از جدول محتوا.

Aspose.Slides for C++ امکان افزودن این پیوندها، کنترل ظاهر و صدا، به‌روزرسانی تنظیمات و حذف آنها را فراهم می‌کند. مثال‌های زیر نشان می‌دهند چطور با پیوندهای هشتگی بر روی عناصر منفرد کار کنیم و چگونه به پیوندها در سطح ارائه، اسلاید یا فریم‑متن دسترسی پیدا کنیم.

{{% alert color="info" title="توجه" %}}

می‌توانید همچنین ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) ویرایش کنید.

{{% /alert %}} 

## **افزودن پیوند URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا چارچوب رسانه‌ای اختصاص دهید. عنصری که به آن پیوند اختصاص می‌دهید، ناحیه کلیک‌شدنی را تعیین می‌کند: بخشی از متن، متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا چارچوب، شیء اسلاید را لینک می‌کند.

### **افزودن پیوند URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/cpp/aspose.slides/hyperlink/) ایجاد کنید و با استفاده از متد [set_HyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/set_hyperlinkclick/) بخشی از متن را به آن اختصاص دهید، همان‌گونه که در زیر نشان داده شده است. تنها همان بخش متن کلیک‌شدنی می‌شود.

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

### **افزودن پیوند URL به اشکال و چارچوب‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا چارچوب، از متد [set_HyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/set_hyperlinkclick/) آن استفاده کنید. پیوند به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همان روش برای چارچوب‌های تصویر، صدا و ویدئو نیز اعمال می‌شود: پیوند را به چارچوب اختصاص دهید و برای افزودن راهنمایی (tooltip) در صورت نیاز از [set_Tooltip](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_tooltip/) استفاده کنید.

مثال زیر یک مستطیل را قابل کلیک می‌سازد:

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

## **استفاده از پیوندها برای ساختن فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی بپرند. مثال زیر از [SetInternalHyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) برای لینک کردن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندها**

### **رنگ**

متد [set_ColorSource](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_colorsource/) از [IHyperlink](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/) تعیین می‌کند که آیا پیوند از رنگ پیوند ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال یک رنگ متن دلخواه، [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر شدگی بخش را تنظیم کنید. این امکان در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متنی به همان اسلاید اضافه می‌کند. اولین پیوند از رنگ پر شدگی متنی قرمز استفاده می‌کند، در حالی که دومین پیوند رنگ پیش‌فرض پیوند را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال‌سازی صدا پخش کند یا صدایی که در حال پخش است را متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_sound/) صدای مرتبط با پیوند را مشخص می‌کند.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) کنترل می‌کند که آیا فعال‌سازی پیوند صدای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدای پیوند**

مثال زیر `sampleaudio.wav` را بارگیری کرده و به یک دکمه در اسلاید اول متصل می‌کند. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. یک شکل دوم در همان اسلاید هنگام کلیک صدا را متوقف می‌کند، بدون انجام عمل ناوبری.

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

#### **استخراج صدای پیوند**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صدای پیوند شکل اول را از طریق [get_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_sound/) و [get_BinaryData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudio/get_binarydata/) به حافظه می‌خواند.

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

### **راهنما (Tooltip) و تنظیمات تعامل**

پس از اختصاص پیوند به متن یا شکل، می‌توانید تنظیمات زیر را از طریق این متدها به‌روزرسانی کنید:

- [set_Tooltip](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_tooltip/) متنی را که بیننده می‌تواند به عنوان راهنمایی برای لینک مشاهده کند، تعیین می‌کند.
- [set_TargetFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_targetframe/) فریم هدف را درون یک frameset HTML والد (در صورت امکان) مشخص می‌کند.
- [set_History](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_history/) کنترل می‌کند که آیا فعال‌سازی لینک مقصد آن را به فهرست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [set_HighlightClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/set_highlightclick/) کنترل می‌کند که آیا پیوند هنگام کلیک برجسته می‌شود یا نه.

## **حذف پیوندها از ارائه‌ها**

با استفاده از [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) می‌توانید قبل از تغییر آنها، تمام کانتینرهای پیوند شامل پیوندهای بخش متن را جمع‌آوری کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) یا [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) را فراخوانی کنید؛ حذف عمل کلیک باعث حذف عمل mouse‑over نمی‌شود.

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

برای حذف بدون قید، [RemoveAllHyperlinks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) را ببینید.

## **ساخت فهرست کامل پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را موجودی کنید. [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkcontainer/) را بر می‌گرداند، نه یک فهرست صاف از رشته‌های URL. برای هر کانتینر هم [get_HyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) و هم [get_HyperlinkMouseOver](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) را بررسی کنید. این دو مستقل هستند: یک کانتینر می‌تواند هر دو اقدام را افشا کند، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن تنها پیوندهای سطح شکل می‌تواند پیوندهای پیوست شده به بخش‌های متن را از دست بدهد. به جای آن، حوزه مناسب را پرس‌وجو کنید و کانتینرهای برگردانده‌شده را نگه دارید تا بعدها بتوانید اقداماتشان را به‌روزرسانی یا حذف کنید.

### **پرس‌وجو در حوزه‌های ارائه، اسلاید و فریم‑متن**

واسطه [IHyperlinkQueries](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/) از طریق [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)، [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) و [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) در دسترس است. هر حوزه همان پرس‌وجوها را پشتیبانی می‌کند:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) کانتینرهای دارای عمل کلیک را بر می‌گرداند.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) کانتینرهای دارای عمل mouse‑over را بر می‌گرداند.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) کانتینرهایی که هر یک یا هر دو عمل را دارند بر می‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` با یک لینک کلیک خارجی، یک لینک فایل mouse‑over، ناوبری اسلاید داخلی، یک لینک متن mouse‑over و یک عمل ماکرو ایجاد می‌کند. هیچ‌یک از این اعمال اجرا نمی‌شود. همان سه پرس‌وجو در هر حوزه کار می‌کند؛ شمارش‌ها تعداد کانتینرها را نشان می‌دهند، نه مجموع اقدامات. حوزه فریم‑متن لینک‌های خود شکل دربر نمی‌گیرد.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هرکدام سه کانتینر کلیک، دو کانتینر mouse‑over و سه کانتینر با هر یک از این اقدامات را گزارش می‌دهند. پرس‌وجوی فریم‑متن یک کانتینر در هر دسته گزارش می‌کند.

### **دسته‌بندی اقدامات و مقصدها**

برای تفسیر یک عمل پیش از تفسیر مقصد آن، از [IHyperlink::get_ActionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_actiontype/) استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را شامل می‌شوند:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به یک اسلاید مشخص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری‌های پیش‌فرض نمایش اسلاید، در زمینه نمایش اسلاید حل می‌شوند. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع نمایش سفارشی. |
| `StartMacro` | اجرا کردن یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائه دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عملی نامشخص که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق [get_ExternalUrl](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_externalurl/) و مقاصد داخلی خاص را از طریق [get_TargetSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_targetslide/) بخوانید. اقدامات داخلی و فرمان‌های پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنی نیست که کانتینر هیچ عملی ندارد. هنگام اختلاف بین URL اصلی و نرمال‌شده، [get_ExternalUrlOriginal](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) را حفظ کنید و راهنمایی (tooltip) بازگردانده‌شده توسط [get_Tooltip](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlink/get_tooltip/) را در صورت موجود بودن وارد کنید.

### **گزارش، پاک‌سازی و تأیید پیوندها**

مثال C++ زیر یک ارائه موجود (فایلی که در بالا ایجاد شده) را می‌خواند، `hyperlink-audit.json` می‌نویسد، یک سیاست را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر، کانتینرها را جمع‌آوری می‌کند و از هویت اشاره‌گر برای جلوگیری از پردازش دوباره همان کانتینر استفاده می‌کند. پرس‌وجوهای ارائه اسلایدهای عادی را پوشش می‌دهند؛ برای موجودی سرتاسری بسته، به‌صراحت مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و توزیع‌کننده را نیز پرس‌وجو می‌کند.

گزارش یک ایندکس اسلاید مبتنی بر یک‑پایه و [get_SlideId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_slideid/) را (در صورت موجود بودن) ثبت می‌کند. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecomponent/get_slide/) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، لایه‌ها و یادداشت‌ها ایندکس اسلاید عادی ندارند و توسط حوزه‌شان شناسایی می‌شوند. کانتینرهای شکل و قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان‌اجرای خود را حفظ می‌کنند. هر کانتینر یک شناسه محلی گزارش دریافت می‌کند تا دو عمل آن بتوانند با هم مرتبط شوند.

این سیاست کاربردی به‌صورت عمدی تنها URLهای HTTPS مطلق و هدف‌های داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اقدامات ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. فقط داشتن HTTPS اعتماد برقرار نمی‌کند: لیست‌های سفید میزبان و بررسی‌های دیگر را برای برنامه خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اقدامات ممیزی می‌کند.

برای بهبود، [get_HyperlinkManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) کانتینر‌ها از [SetExternalHyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) و [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌های ممنوع و اعمال mouse‑over ممنوع به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. پیش از استقرار، صفحه جایگزین متعلق به برنامه خود را انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بازبینی PDF محتاطانه استفاده می‌کند: اعمال mouse‑over و هر چیزی به جز یک لینک خارجی یا جهش اسلاید خاص را به‌عنوان احتمال عدم پشتیبانی پرچم می‌زند. این یک راهنمای بازبینی است، نه تست توانایی یا ضمانتی که لینک‌های بدون پرچم در خروجی بمانند. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و نمایشگر. [تصاویر](/slides/fa/cpp/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/cpp/convert-powerpoint-to-video/) رستر نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام ممیزی برای این خروجی‌ها، هر عمل را پرچم کنید.

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

با ورودی ایجاد‌شده در بالا، گزارش پنج ردیف عمل دارد. لینک فایل mouse‑over و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. یک ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخه جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و mouse‑over ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [RemoveAllHyperlinks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) متفاوت است که هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده صرف‌نظر از سیاست حذف می‌کند. تأیید در اینجا تنها اقدامات پیوند را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل‌های PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید فردی هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوندی را به عناصر مستر اسلاید الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لایه‌ها از پیوندها پشتیبانی می‌کنند. لینک‌های این عناصر در زمان نمایش اسلاید در اسلایدهایی که از مستر یا لایه مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستر و ویدئو نمی‌توانند. برای جزئیات به ملاحظات خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.