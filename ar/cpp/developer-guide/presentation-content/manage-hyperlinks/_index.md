---
title: إدارة ارتباطات العرض التقديمي في C++
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/cpp/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة، تنسيق، تحديث، وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مع أمثلة C++."
---
## **مقدمة**

يربط الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض. في PowerPoint، يُستخدم الارتباط التشعبي عادةً لغرضين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

تتيح لك Aspose.Slides for C++ إضافة هذه الروابط، والتحكم في شكلها وصوتها، وتحديث إعداداتها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات التشعبية على مستوى العرض، أو الشريحة، أو إطار النص.

{{% alert color="info" title="Note" %}}

يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر PowerPoint عبر الإنترنت المجاني من Aspose](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **إضافة ارتباطات URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. يحدد العنصر الذي تُعيّن إليه الارتباط التشعبي المنطقة القابلة للنقر: يربط جزء النص النص المحدد، بينما يربط الشكل أو الإطار كائن الشريحة بالكامل.

للعروض التي تحتوي على ارتباطات تشعبية نسبية، راجع [إدارة قاعدة الارتباط التشعبي](/slides/ar/cpp/presentation-properties/#manage-the-hyperlink-base) لقراءة أو تغيير أو مسح القاعدة على مستوى المستند.

### **إضافة ارتباطات URL إلى النص**

لربط نص بموقع ويب، أنشئ [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) وعيّنها باستخدام طريقة [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) لجزء النص، كما هو موضح أدناه. يصبح فقط ذلك الجزء من النص قابلاً للنقر.

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

### **إضافة ارتباطات URL إلى الأشكال وإطارات الوسائط**

استدعِ [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/) على المستطيل لجعل مساحته بالكامل قابلة للنقر. استخدم [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) لتزويد القارئ بتلميح حول الهدف عندما يمر فوق المستطيل. كلتا الطريقتين تنطبق أيضًا على إطارات الصورة والصوت والفيديو.

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

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

تسمح الارتباطات التشعبية الداخلية للقارئ بالقفز من جدول المحتويات إلى شريحة معينة. يستخدم المثال التالي طريقة [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

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

## **تنسيق الارتباطات التشعبية**

يمكنك تغيير لون النص المرتبط، تشغيل أو إيقاف صوت عند تنشيط القارئ للارتباط، وتعيين التلميح (tooltip) الذي يظهر عند المرور فوقه.

### **اللون**

تحدد طريقة [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) في واجهة [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

في هذا المثال، يستخدم الارتباط الأول طريقة [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) لعرض تعبئة نصية حمراء. يحتفظ الارتباط الثاني بلون الارتباط التشعبي للعرض.

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

### **الصوت**

يمكن للارتباط التشعبي تشغيل صوت عند تنشيطه أو إيقاف صوت يُشغل بالفعل. استخدم الطرق التالية لضبط هذه السلوكيات:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) يحدد ملف الصوت المرتبط بالارتباط.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) يتحكم فيما إذا كان تنشيط الارتباط يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

يستخدم الزر في الشريحة الأولى طريقة [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) لتشغيل الصوت من `sampleaudio.wav` عندما ينقر القارئ للتقدم. في الشريحة الثانية، يستخدم زر منفصل طريقة [set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) لإيقاف التشغيل والحفاظ على القارئ على تلك الشريحة.

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

#### **استخراج صوت الارتباط التشعبي**

يفتح المثال التالي العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) و[get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **التلميح وإعدادات التفاعل**

يمكنك تحديث إعدادات [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) التالية عبر هذه الطرق بعد تعيين ارتباط تشعبي للنص أو الشكل:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML أصلية، إذا كان ذلك مناسبًا.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) يتحكم فيما إذا كان تنشيط الارتباط يضيف هدفه إلى قائمة الارتباطات المشاهدة.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) يتحكم فيما إذا كان الارتباط يُبرز عند النقر.

## **إزالة الارتباطات التشعبية من العروض**

استخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع حاويات الارتباطات، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) أو [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)؛ إزالة إجراء النقر لا يزيل نظيره عند المرور فوقه.

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

للإزالة غير المشروطة، تُزيل طريقة [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) كلا نوعي التنشيط في النطاق المحدد بنقرة واحدة. للتنظيف الانتقائي وتغطية القوالب، التخطيطات، والملاحظات، راجع [التقارير، التطهير، والتحقق من الارتباطات التشعبية](#report-sanitize-and-verify-hyperlinks).

### **مسح الارتباطات قبل استبدال نص SmartArt**

عند استبدال فقرة في عقدة SmartArt موجودة، قد يترك مسح أجزاء النص ارتباطًا تشعبيًا قديمًا ساريًا. استرجع الفقرة عبر [ISmartArtNode::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_textframe/). قبل مسح أجزائها، استدعِ [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) من خلال [get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) على إطار النص لشكل العقدة الذي يعرض الفقرة. يزيل ذلك كل ارتباط في ذلك الإطار، بما في ذلك الروابط في فقراته الأخرى.

يفترض المثال أن الشكل الثالث في الشريحة الأولى هو رسم SmartArt. يستبدل الفقرة الأولى من العقدة الرابعة. في هذا العرض، يعرض الشكل الأول للعقدة تلك الفقرة.

بعد إضافة الجزأين، يقرأ المثال تنسيقهما الفعلي باستخدام [GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/). تُعيد طريقة [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformateffectivedata/get_hyperlinkclick/) الفعلي الارتباط التشعبي الجديد للجزء الأول و`nullptr` للثاني.

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

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، احصر إجراءات التفاعل بالإضافة إلى روابط الويب. تُعيد طريقة [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/) وليس قائمة مسطحة من سلاسل URL. فحص كل من [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) و[get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) لكل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

يمكن أن يفتقد فحص الارتباطات على مستوى الشكل الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المرجعة حتى تتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **الاستعلام عن نطاقات العرض، الشريحة، وإطار النص**

تتوفر واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) عبر [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)، [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/)، و[ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). يدعم كل نطاق الاستعلامات نفسها:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) يُعيد حاويات بإجراء نقر.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) يُعيد حاويات بإجراء مرور فوق.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) يُعيد حاويات بإحدى الإجراءين أو كليهما.

يعين هذا المثال إجراءات النقر والمرور فوق إلى شكل ونصه، وإجراء ماكرو إلى زر منفصل. يقارن الحاويات التي تُعيدها طريقة [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) مع عدد كل نوع من أنواع التنشيط. يستعلم استعلام إطار النص فقط عن الروابط الموجودة في النص. تظهر إجراءات الشكل نفسه في استعلامي الشريحة والعرض.

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

في هذا المثال، يُظهر استعلاما العرض والشريحة ثلاثة حاويات نقر، وحاويتين مرور فوق، وثلاث حاويات تحتوي على أيٍ من الإجراءين. يُظهر استعلام إطار النص حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) لتفسير الإجراء قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) ما هو أكثر من تنقل ويب:

| القيم | معنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ تحقق من URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسَّر في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تشغيل ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجعه منفصلًا عن عناوين URL للويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) والوجهات الداخلية المحددة من [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على URL خارجي؛ عدم وجود URL لا يعني عدم وجود إجراء. احتفظ بـ [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) عندما يختلف عن URL المُعَدل، وتضمن التلميح الراجع من [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) إذا كان متوفرًا.

### **التقرير، التطهير، والتحقق من الارتباطات التشعبية**

يفتح هذا المثال C++ العرض التقديمي من المثال السابق ويكتب سجل JSON واحد لكل إجراء. يستخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع الحاويات على الشرائح العادية، القوالب، التخطيطات، والملاحظات، بما في ذلك قالب الملاحظات والقالب الموزع عندما تكون موجودة. يستخدم هوية المؤشر لحساب كل حاوية مرة واحدة، يطبق السياسة الموصوفة أدناه، ثم يعيد فتح العرض المحفوظ للتحقق من كل من إجراءات النقر والمرور فوق.

يقوم التقرير بتسجيل فهرس شريحة يبدأ من واحد و[get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) حيثما كان متاحًا. توفر [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) الشريحة المالكة للحاويات المدعومة. لا تحتوي القوالب والتخطيطات والملاحظات على فهرس شريحة عادي وتُحدد بنطاقها. تُصنَّف حاويات الشكل وحاويات تنسيق أجزاء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى بأسمائها النوعية في وقت التشغيل. يحصل كل حاوية على معرف محلي داخل التقرير لربط إجراءيها.

تسمح سياسة التطبيق المقيدة هذه فقط بـ URLs HTTPS مطلقة ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات العرض الأخرى، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفضات هي قرارات سياسة، لا حكم أمان من Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. تُفحص كل من URL الخارجية الأصلية والمعدّلة. يقوم المثال بتدقيق البيانات الوصفية دون اتباع الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) في الحاوية [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)، و[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال باقي الروابط غير المسموح بها وإجراءات المرور فوق بشكل مستقل. اضبط `replaceExternalClicks` إلى `false` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

تستخدم علامة تصدير التقرير سياسة مراجعة PDF محافظة: تُعلَّم إجراءات المرور فوق وأي شيء غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يُدعم. إنها إشارة مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط التي لم تُعلَّم عند التصدير. قد تحتفظ تصديرات [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/cpp/convert-powerpoint-to-html/) بالارتباطات حسب الإجراء، خيارات التصدير، والمستعرض. لا يمكن لتصديرات [الصور](/slides/ar/cpp/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/cpp/convert-powerpoint-to-video/) حفظ الارتباطات التفاعلية؛ يجب تعليم كل إجراء عند التدقيق لتلك المخرجات.

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

مع الإدخال المذكور أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط المرور فوق الملف والماكرو النقر، بينما تبقى روابط HTTPS والتنقل الداخلي للشرائح. يطبع التحقق صفر إجراءات محظورة. يُظهر إدخال يحتوي على URL نقر خارجي محظور فرع الاستبدال. يُبقي الحاوية ذات النقر المسموح والمرور فوق المحظور فعل النقر.

هذا التنظيف الانتقائي يختلف عن [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)، الذي يزيل كلا النوعين من التنشيط في النطاق المحدد بغض النظر عن السياسة. يتحقق التحقق هنا من إجراءات الارتباط فقط؛ لا يزيل مشاريع VBA المضمنة، كائنات OLE، أو محتوى نشط آخر، ولا يتحقق من ملف PDF أو HTML المصدر.

## **الأسئلة المتكررة**

**كيف يمكنني ربط بقسم أو أول شريحة له؟**

تُجَمِّع الأقسام في PowerPoint الشرائح، لكن الارتباط التشعبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط بأول شريحة في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي إلى عناصر الشريحة الرئيسية ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والعمل التخطيطي الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم القالب أو التخطيط المقابل.

**هل ستُحافظ الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ تصديرات PDF وHTML المدعومة بالارتباطات؛ لا يمكن للصور النقطية والفيديو حفظ الارتباطات التفاعلية. راجع اعتبارات التصدير في [التقرير، التطهير، والتحقق من الارتباطات التشعبية](#report-sanitize-and-verify-hyperlinks).