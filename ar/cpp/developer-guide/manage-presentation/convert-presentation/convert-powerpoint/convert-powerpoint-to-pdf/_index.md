---
title: تحويل PPT و PPTX إلى PDF في C++ [تشمل ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام C++ يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض بتنسيق PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) تكشف طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يقوم Aspose.Slides للـ C++ بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:
* العروض التقديمية الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:
* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرة
* الروابط التشعبية
* الترويسات والتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا تقديميًا ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
Aspose يقدم محولًا مجانيًا على الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتطبيق عملي للإجراءات الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides يوفر خيارات مخصصة—خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتكوين DPI للصور، وغيرها.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 مع ضبط جودة JPEG إلى 90، دقة الصورة إلى 300 DPI، حفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **الاحتفاظ بملفات OLE المضمَّنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد تريد أن يتمكن مستلمو PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. استدعِ [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) مع `true` للحفاظ على ملفات OLE المضمَّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة معاينة كائن OLE أو أيقونته على صفحة PDF، لكن الملف المضمّن غير مُدرج كمرفق. ضبط الخيار إلى `true` يضيف بيانات الملف كذلك. تبقى المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا تقديميًا يحتوي بالفعل على مصنف Excel مضمّن ويصدره إلى PDF مع إرفاق المصنف.

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
1. افتح ملف PDF المُصدَّر في عارض يدعم مرفقات الملفات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. يكون العرض المسبق على صفحة PDF منفصلًا عن المرفق.

{{% alert color="info" title="Note" %}}
معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمَّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك مصنفات Excel. هذه متطلبات المعايير، وليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لإدراج الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا تقديميًا إلى PDF، متضمنًا أي شرائح مخفية.

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

المثال التالي يصدر عرضًا تقديميًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

Aspose.Slides يوفر طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتمكينك من اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

المثال التالي يصدر عرضًا تقديميًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة تحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخطوط](/slides/ar/cpp/font-substitution/).
{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ما لا يقل عن ثلاث شرائح.

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

المثال التالي ينسخ الشريحة الأولى من عرض تقديمي إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يتم تحجيم محتوى الشريحة لتلائمها ويُصدر الشريحة الواحدة إلى PDF.

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

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يصدر عرضًا تقديميًا إلى PDF، بحيث تُضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال للـ PDF**

Aspose.Slides يسمح لك باستخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود C++ يوضح عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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
Aspose.Slides يدعم عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك تنفيذ تحويلات [PDF إلى HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). كما تُدعم عمليات التحويل إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يعتبر Aspose.Slides الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم وضع علامة عليها كعناصر غير مهمة؛ يتم توفير النص البديل فقط للشكل بالكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides تحويل دفعة من ملفات PPT أو PPTX إلى PDF. يمكنك تكرار عملية التحويل عبر ملفاتك برمجيًا.

**هل من الممكن حماية PDF المحوَّل بكلمة مرور؟**

نعم. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني إدراج الشرائح المخفية في PDF؟**

استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لإدراج الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و[set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides للـ C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides للـ C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)