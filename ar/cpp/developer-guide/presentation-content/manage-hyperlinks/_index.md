---
title: إدارة ارتباطات العرض التقديمي في C++
linktitle: إدارة الارتباطات التشعبية
type: docs
weight: 20
url: /ar/cpp/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق الارتباط التشعبي
- إزالة الارتباط التشعبي
- تحديث الارتباط التشعبي
- ارتباط تشعبي نصي
- ارتباط تشعبي شريحة
- ارتباط تشعبي شكل
- ارتباط تشعبي صورة
- ارتباط تشعبي فيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة، وتنسيق، وتحديث، وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ C++، مع أمثلة بلغة C++."
---
## **المقدمة**

يربط الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو موقع داخل العرض التقديمي. في PowerPoint، عادةً ما يخدم الارتباطات التشعبية هدفين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* التنقل إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

Aspose.Slides for C++ يتيح لك إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث إعداداتها، وإزالتها. تُظهر الأمثلة أدناه كيفية التعامل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}

يمكنك أيضًا تعديل العروض التقديمية باستخدام [المحرر المجاني عبر الإنترنت لـ Aspose PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **إضافة ارتباطات URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تعين إليه الارتباط التشعبي يحدد منطقة النقر: الجزء النصي يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

للعروض التي تحتوي على روابط تشعبية نسبية، راجع [إدارة قاعدة الارتباط التشعبي](/slides/ar/cpp/presentation-properties/#manage-the-hyperlink-base) لقراءة أو تغيير أو مسح القاعدة على مستوى المستند.

### **إضافة ارتباطات URL إلى النص**

لربط النص بموقع ويب، أنشئ [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/)، ثم اسندها باستخدام طريقة [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) للجزء النصي، كما هو موضح أدناه. يصبح ذلك الجزء من النص فقط قابلاً للنقر.

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

لجعل شكل أو إطار قابل للنقر، استخدم طريقة [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/). ينتمي الارتباط التشعبي إلى الكائن نفسه وليس إلى جزء نص داخلها.

ينطبق النهج نفسه على إطارات الصورة والصوت والفيديو: اسند الارتباط التشعبي إلى الإطار واستخدم [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) لإضافة تلميح إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلًا للنقر:

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

تسمح الارتباطات التشعبية الداخلية للقارئ بالقفز من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) لربط النص “Page 2” في الشريحة الأولى إلى الشريحة الثانية.

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

### **اللون**

تحدد طريقة [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) في [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي في العرض التقديمي أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

يضيف المثال التالي ارتباطين تشعبيين نصيين إلى نفس الشريحة. يستخدم الأول تعبئة نص حمراء، بينما يحتفظ الثاني بلون الارتباط التشعبي الافتراضي.

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

يمكن للارتباط التشعبي تشغيل صوت عند التفعيل أو إيقاف صوت يتم تشغيله بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) تحدد الصوت المرتبط بالارتباط التشعبي.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) تتحكم فيما إذا كان تفعيل الارتباط التشعبي يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

يقوم المثال التالي بتحميل `sampleaudio.wav` وربطه بزر في الشريحة الأولى. عند النقر على الزر يتم تشغيل الصوت والتنقل إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

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

#### **استخراج صوت للارتباط التشعبي**

يفتح المثال التالي العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) و [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **إعدادات التلميح والتفاعل**

يمكنك تحديث إعدادات [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) التالية عبر هذه الطرق بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) تحدد النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) تحدد الإطار الهدف داخل مجموعة إطارات HTML الأصلية، عندما يكون ذلك مناسبًا.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) تتحكم فيما إذا كان تفعيل الارتباط يضيف وجهته إلى قائمة الارتباطات المشاهدَة.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) تتحكم فيما إذا كان يتم تمييز الارتباط عند النقر.

## **إزالة الارتباطات التشعبية من العروض التقديمية**

استخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع حاويات الارتباطات التشعبية، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التفعيل من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) أو [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); إزالة إجراء النقر لا تُزيل المقابل الخاص بالتمرير فوق الفأرة.

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

لإزالة غير مشروطة، [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) يزيل كلا نوعي التفعيل في النطاق المحدد في استدعاء واحد. للتنظيف الانتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، قم بجرد الإجراءات التفاعلية بالإضافة إلى روابط الويب الخاصة به. تُعيد [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) و [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

يمكن أن يؤدي فحص الارتباطات التشعبية على مستوى الشكل فقط إلى فقدان الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المرجعة لتتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **استعلام عن نطاقات العرض التقديمي، والشريحة، وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) متاحة عبر [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), و[ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). يدعم كل نطاق نفس الاستعلامات:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) ترجع الحاويات التي لها إجراء نقر.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) ترجع الحاويات التي لها إجراء تمرير فوق الفأرة.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) ترجع الحاويات التي لديها أحد الإجراءين أو كلاهما.

ينشئ المثال التالي ملف `hyperlink-audit-input.pptx` يحتوي على رابط نقر خارجي، ورابط تمرير فوق ملف، وتنقل داخلي إلى شريحة، ورابط تمرير فوق نص، وإجراء ماكرو. لا ينفذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأرقام تصف الحاويات، لا إجمالي الإجراءات. يستبعد نطاق إطار النص الروابط الخاصة بالشكل المحيط.

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

في هذا المثال، تقارير استعلامات العرض التقديمي والشريحة كلٌ منها ثلاث حاويات نقر، وحاويتين تمرير فوق الفأرة، وثلاث حاويات لديها أي من الإجراءين. تقرير إطار النص يُظهر حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) لتفسير الإجراء قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) ما هو أكثر من التنقل عبر الويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة محددة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُحل في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجع بشكل منفصل عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل الوسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) والوجهات الداخلية المحددة من [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على عنوان URL خارجي؛ عنوان URL فارغ لا يعني أن الحاوية لا تحتوي على إجراء. احفظ [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) عندما يختلف عن عنوان URL المُنظم، وضمّن التلميح الذي تُرجعه [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) عندما يكون متاحًا.

### **إعداد تقرير، وتطهير، والتحقق من الارتباطات التشعبية**

يقوم المثال التالي بلغة C++ بقراءة عرض تقديمي موجود (استخدم الملف الذي تم إنشاؤه أعلاه)، كتابة `hyperlink-audit.json`، تطبيق سياسة، حفظ `hyperlink-sanitized.pptx`، وإعادة فتحه للتحقق من نوعي التفعيل مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم هوية المؤشر لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لإنشاء جرد على مستوى الحزمة، يستعلم أيضًا صراحةً عن الماسترز، التخطيطات، الملاحظات، وعن ماسترز الملاحظات والنشرات عندما تكون موجودة.

يسجل التقرير فهرس شريحة يبدأ من الواحد و [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) حيث يتوفر. توفر [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) الشريحة المالكة للحاويات المدعومة. الماسترز، التخطيطات، والملاحظات لا تملك فهرس شريحة عادي وتُعرف بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى من الحاويات باسم نوعها في وقت التشغيل. تحصل كل حاوية على معرف محلي في التقرير بحيث يمكن ربط إجراءيها.

تسمح هذه السياسة التطبيقية المقيدة عمدًا فقط بعناوين URL مطلقة عبر HTTPS وهدف شريحة داخلي صالح. ترفض الماكروهات، البرامج، إجراءات الملفات، إجراءات عروض الشرائح الأخرى، الإجراءات غير المعروفة، ومخططات URL أخرى. هذه الرفض هي قرارات سياسات، لا حكم أمان من Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح بالمضيفين وفحوصات أخرى لتطبيقك. تُفحص كلٌ من عناوين URL الخارجية الأصلية والموحدة. يراجع المثال بيانات التعريف دون اتباع الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) في الحاوية [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) و[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية الممنوعة بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات الممنوعة الأخرى وإجراءات التمرير فوق الممنوعة بشكل مستقل. اضبط `replaceExternalClicks` إلى `false` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

تستخدم علامة تصدير التقرير سياسة مراجعة PDF محافظة: تُعلم عن إجراءات التمرير فوق الفأرة وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة محددة باعتبارها قد لا تكون مدعومة. إنها إشارة مراجعة، ليست اختبار قدرة أو ضمان أن الروابط غير المعلَّمة ستبقى بعد التصدير. قد تحتفظ صادرات [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/cpp/convert-powerpoint-to-html/) المدعومة بالارتباطات التشعبية، بحسب الإجراء، خيارات التصدير، والمشاهد. لا يمكن للصور النقطية [images](/slides/ar/cpp/convert-powerpoint-to-png/) والفيديو [video](/slides/ar/cpp/convert-powerpoint-to-video/) الحفاظ على الارتباطات التفاعلية؛ علم كل إجراء عند التدقيق لهذه المخرجات.

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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمسة صفوف إجراءات. تم إزالة رابط تمرير فوق الملف والماكرو، بينما بقيت الروابط HTTPS والتنقل الداخلي إلى الشرائح. تُظهر عملية التحقق عدم وجود إجراءات محظورة. إدخال يحتوي على رابط نقر خارجي محظور يختبر فرع الاستبدال. حاوية ذات نقر مسموح به وتمرير فوق محظور تحتفظ بإجراء النقر.

يختلف هذا التنظيف الانتقائي عن [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), الذي يزيل كلا نوعي التفعيل في جميع النطاق المحدد بغض النظر عن السياسة. تتحقق المراجعة هنا من إجراءات الارتباط التشعبي فقط؛ لا تُزيل مشروعات VBA المدمجة، كائنات OLE، أو أي محتوى نشط آخر، ولا تتحقق من صحة ملف PDF أو HTML مُصدَّر.

## **الأسئلة الشائعة**

**كيف يمكنني الإشارة إلى قسم أو شريحةه الأولى؟**

الأقسام في PowerPoint تُجمع الشرائح، لكن الارتباط التشعبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر الشريحة الرئيسة (Master) ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة (Master) والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل سيتم حفظ الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ صادرات PDF وHTML المدعومة بالارتباطات التشعبية؛ بينما لا يمكن للصور النقطية والفيديو ذلك. راجع ملاحظات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).