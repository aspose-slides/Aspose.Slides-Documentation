---
title: تحويل PPT و PPTX إلى PDF في C++ [الميزات المتقدمة مشمولة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/cpp/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في C++ يقدم العديد من المزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) تعرض طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
تُدرج Aspose.Slides لـ C++ معلومات API وإصدارها في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح لك Aspose.Slides بـ تحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يُصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق الأصل عن كثب. تُرسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يقوم بتحميل عرض وت حفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
توفر Aspose محولًا مجانيًا عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتطبيق عملي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر من ذلك.

المثال التالي يُصدر عرضًا إلى PDF 1.5 مع جودة JPEG مضبوطة إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **الحفاظ على ملفات OLE المضمّنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. استدعِ [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) مع `true` للحفاظ على ملفات OLE المضمّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يُعرض صورة معاينة كائن OLE أو أيقونته على صفحة PDF، لكن الملف المضمّن لا يُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كذلك. تظل المعاينة تمثيلًا بصريًا؛ يتيح المرفق للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يقوم بتحميل عرض يحتوي بالفعل على دفتر عمل Excel مضمّن ويصدره إلى PDF مع إرفاق دفتر العمل.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

للتحقق من النتيجة:

1. افتح PDF المصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرةً إذا سمح العارض بذلك. تكون المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يحظر الملفات المضمّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك دفاتر Excel. هذه قيود المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، بما في ذلك أي شرائح مخفية.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) تحت الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتمكينك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة تحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
لمزيد من المعلومات حول استبدال الخطوط، راجع المقالة [استبدال الخط](/slides/ar/cpp/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط بدون خط عريض مخصص**

يمكن للعرض تطبيق تنسيق عريض للنص حتى عندما لا يمتلك الخط نوعًا عريضًا مخصصًا. لا يزال النص يظهر عريضًا من خلال التسمك الصناعي، الذي يثخّن الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب استدعاء [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) مع `true`. هذا الخيار يُرَسِّم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يُحسّن مظهره لبعض الخطوط. قيمته الافتراضية هي `false`.

العرض التجريبي يحتوي على مربعين نصيين: أحدهما بنص عادي والآخر بتنسيق عريض لنفس الخط الذي لا يمتلك نوعًا عريضًا مخصصًا. المثال التالي يحمل العرض، يُفعِّل تحويل الأنماط الخطية غير المدعومة إلى نقطية، ويصدره إلى PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

المعاينات التالية تُظهر النتيجة مع تعطيل الخيار والنتيجة مع تمكينه. في هذا المثال، يكون النص العريض ذو خطوط أسمك عندما يكون الخيار معطلًا. مع تمكين الخيار، تصبح خطوطه أخف؛ يبقى النص العادي دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تمكين الخيار إلى تحويل النص العريض فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند التكبير 800 %. يبقى النص العادي قابلاً للبحث. مع تعطيل الخيار، يبقى كلا النصين نصًا.

يقوم هذا الخيار بتحويل النص المنسق كعريض إلى نقطية عندما لا يمتلك الخط نوعًا عريضًا مخصصًا. [استبدال الخط](/slides/ar/cpp/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الخط الأصلي غير متوفر.

## **تحويل الشرائح المختارة من PowerPoint إلى PDF**

المثال التالي يصدر الشريحة 1 و 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُعيد تحجيم محتوى الشريحة ليناسبها ويصدر الشريحة الوحيدة إلى PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، حيث يُوضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **معايير الوصول والامتثال لملفات PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الكود C++ عملية تحويل من PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات شائعة. يمكنك تنفيذ [PDF إلى HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) تحويلات. تُدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، تعامل Aspose.Slides الرسوميات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا تُحافظ عناصر المسار الفردية كمحتوى منفصل وقد تُعلَّم كعناصر غير مرغوبة؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**  
نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**  
نعم. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**  
استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و[set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**  
نعم، يسمح لك Aspose.Slides بتصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides لـ C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)