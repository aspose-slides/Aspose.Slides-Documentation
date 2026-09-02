---
title: "تصدير شرائح العرض التقديمي كصور SVG في C++"
linktitle: "شريحة إلى SVG"
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint إلى SVG"
- "عرض تقديمي إلى SVG"
- "شريحة إلى SVG"
- "PPT إلى SVG"
- "PPTX إلى SVG"
- "خيارات تصدير SVG"
- "SVG تفاعلية"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تصدير شرائح PowerPoint كصور SVG في C++ والتحكم في الخطوط والنصوص والصور والمعرّفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صور يعتمد على XML ويمكن تحجيمه، يعمل جيدًا للنشر على الويب، وعارضات الشرائح، وتدفقات عمل الوصول، ومعالجة ما بعد التصدير الآلية. Aspose.Slides for C++ يُصدّر كل شريحة إلى ملف SVG منفصل ويتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المُصدّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، حدد شريحة، واكتبها إلى تدفق. المثال التالي يُصدّر كل شريحة في العرض التقديمي إلى ملف SVG منفصل.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

اسم الملف يستخدم [ISlide::get_SlideNumber](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/get_slidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدم شكل فردي باستخدام [IShape::WriteAsSvg](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين مخرجات SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/) يتحكم في رسم SVG. لإطارات النص، [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_useframesize/) يضيف إطار النص إلى منطقة الرسم، و[SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_useframerotation/) يحدّد ما إذا كان يتم تطبيق دوران الإطار. ضع [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) على `true` عندما يجب أن يُرسم النص دون ربط الحروف.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **التحكم في النص والخطوط**

### **تحويل كل النص إلى متجهات**

ضبط [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يُزيل الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، ولكن النص لن يكون قابلًا للتحديد أو البحث ك نص SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **اختر كيفية معالجة الخطوط الخارجية**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgexternalfontshandling/) للخطوط التي تُحمّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمينه.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **تقليل حجم الصور المدمجة**

استخدم [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_picturescompression/) لتقليل دقة الصور المدمجة، و[SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) لحذف المناطق المقطوعة من المصدر، و[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_jpegquality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **تعيين معرّفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgshapeformattingcontroller/) لتعيين [ISvgShape::set_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgshape/set_id/) لكل شكل SVG. لتعيين قيم [ISvgTSpan::set_Id](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgtspan/set_id/) على عناصر النص `tspan` أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). قم بتعيين أي من المتحكمين باستخدام [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

المتحكم التالي يستخدم [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_officeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدّادًا قابلًا للتكرار لشرائح النص الخاصة به. هذا يجعل المعرفات المُولدة مناسبة لمعالجة ما بعد العرض التقديمي غير المعدل.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **إضافة معالجات أحداث SVG**

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgshapeformattingcontroller/)، استدعِ [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isvgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدّر. قم بتعيين المتحكم باستخدام [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) وتعريف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يُمكّن عارضات الشرائح، تحسينات الوصول، وغيرها من سير عمل SVG التفاعلية.

## **الأسئلة الشائعة**

**متى يجب أن أستخدم [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) بدلاً من [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgexternalfontshandling/) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المدمجة، حذف المناطق المقطوعة من الصورة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن انخفاض دقة الصورة، انخفاض جودة JPEG، والنص المتجه كلٌ منها له تبادلات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. قم بتعيين المعرفات عبر متحكم التنسيق، ثم اختر عناصر SVG المطابقة في أداة ما بعد المعالجة أو سكريبت المتصفح.