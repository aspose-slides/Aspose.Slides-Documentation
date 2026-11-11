---
title: تحويل شرائح العرض التقديمي إلى صور SVG في C++
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- عرض تقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في C++ والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة XML قابل للتوسع يعمل جيدًا للنشر على الويب، وعارضات الشرائح، وسير عمل إمكانية الوصول، ومعالجة ما بعد الإنتاج الآلية. Aspose.Slides لـ C++ يصدر كل شريحة إلى ملف SVG منفصل ويتيح لك التحكم في كيفية كتابة النصوص، والخطوط، والصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، أو متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

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

يستخدم اسم الملف [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تهيئة إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) يتحكم في تصيير SVG. لإطارات النص، [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) يضمن تضمين إطار النص في منطقة التصيير، و[SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) يحدد ما إذا كان يتم تطبيق دوران الإطار. عيّن [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) إلى `true` عندما يجب أن يُصَغَر النص بدون الحروف المتصلة.

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

## **التحكم في قص نهايات الخط عند رؤوس الأسهم**

SVG 1.1 لا يملك إعداد إدخال مؤشر لتحديد مكان توقف الخط تحت رأس السهم. افتراضيًا، تقوم Aspose.Slides بتقليل طول الخط المُصدَّر بحيث لا يبرز حدّه عبر المؤشر. عيّن [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) إلى `true` لرسم الحد حتى نقطة النهاية الأصلية للخط. هذا الإعداد يؤثر فقط على إخراج SVG. يبقى الخط في موضعه وطوله على الشريحة.

المثال يرسم رؤوس أسهم مثلثية ومعينية على خطوط بعرض نقطتين وعشرة نقاط. يصدر الشريحة نفسها مرتين، مع تغيير خيار القص فقط.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

المقارنة تُظهر رأس السهم المثلثي على الخط بعرض 10 نقاط. عندما يكون القص مفعَّلًا، يكون الطرف حادًا. عندما يكون القص معطلًا، يبرز الحد عبر جوانب المؤشر المنحدرة ويترك طرفًا مسطحًا.

![مثلث 10‑نقطة مكبر مع طرف حاد عندما يكون القص مفعَّلًا وطرف مسطح عندما يكون القص معطلًا](line-end-cropping.png)

في الخطوط الأخرى من المثال، يكون الحد البارز أقل وضوحًا على المثلث بعرض نقطتين. الماس المملؤة تغطي نهاية الحد في كلا العرضين.

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان يبقى النص كنص أو يُحوَّل إلى رسومات متجهية، وكيفية تضمين أو الإشارة إلى الخطوط الخارجية. الخيارات التالية تساعدك على موازنة التناسق البصري، وإمكانية اختيار النص، واعتماديات الخط في SVG المُصدَّر.

### **تحويل كل النص إلى رسومات متجهية**

عيّن [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) إلى `true` لكتابة جميع نصوص الشرائح كرسومات متجهية. هذا يقضي على اعتماديات الخط ويجعل النتيجة البصرية أكثر تناسقًا عبر المتصفحات، لكن النص لن يكون قابلًا للاختيار أو البحث كـ SVG نصي.

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

### **اختر طريقة التعامل مع الخطوط الخارجية**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمينه.

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

استخدم [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) لتقليل دقة الصور المدمجة، و[SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) لحذف المناطق المقتصّة من المصدر، و[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو الحفاظ على بيانات الصورة.

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

## **التحكم في دقة تحويل ملفات الميتا إلى نقطية**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) يحدد الحد الأدنى لدقة تحويل ملفات الميتا إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطيات. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط مائلة متقاربة. المثال التالي يصدر الشريحة الأولى له بثلاث دقات rasterization عبر [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). جميع إعدادات التصدير الأخرى تبقى متطابقة حتى يمكن مقارنة النتائج.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

في المخرجات، تحولت صورة EMF إلى PNG مدمج واحد في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تمثيل ملف الميتا DPI | أبعاد PNG المدمج | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس منطقة الصورة النقطية المدمجة بالحجم المكبر نفسه. الخطوط المائلة تظهر بكسلية واضحة عند 72 DPI وحواف أكثر سلاسة عند الدقات الأعلى، بينما ينمو حجم ملف SVG. زيادة القيمة لا تحسن كل التفاصيل أو تغير كل صورة مُصدَّرة.

![تفصيل مكبر للخط المائل عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) يتحكم في تقليل دقة الصورة وقد يخبئ تأثير تغيير دقة rasterization لملفات الميتا. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة rasterization للملف الميتا.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) لتعيين [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) لكل شكل SVG. لتعيين قيم [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) على عناصر `tspan` النصية أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). عيّن أيٍ من المتحكمين عبر [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

المتحكم التالي يستخدم [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدادًا قابلًا لإعادة الاستخدام لتبعثر النص. هذا يجعل المعرفات المُولَّدة مناسبة لمعالجة ما بعد تقديم عرض تقديمي غير متغيّر.

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

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/)، استدعِ [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) لإضافة معالج JavaScript إلى الشكل المُصدَّر. عيّن المتحكم عبر [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) وعَرِّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة JavaScript المرجعية للمعالج. تمكين المعرفات ومعالجات الأحداث يتيح عارضات الشرائح، وتعزيزات إمكانية الوصول، وسير عمل SVG تفاعلية أخرى.

## **الأسئلة المتكررة**

**متى يجب علي استخدام [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) بدلاً من [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) عندما يجب أن يكون جميع النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف مناطق الصور المقتصّة، واختيار ملفات الخطوط المرتبطة عندما يمكن للبيئة المستهدفة خدمتها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى رسومات كلٌ له مقايضات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم تنسيق، ثم اختر العناصر المطابقة في أداة ما بعد المعالجة أو برنامج النصوص بالمتصفح.