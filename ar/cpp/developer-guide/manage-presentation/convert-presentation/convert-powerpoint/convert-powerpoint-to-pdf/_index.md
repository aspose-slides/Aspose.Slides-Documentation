---
title: تحويل PPT و PPTX إلى PDF في C++ [يتضمن ميزات متقدمة]
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
- حفظ PowerPoint كPDF
- حفظ PPT كPDF
- حفظ PPTX كPDF
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

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في C++ يوفر عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) تكشف عن طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يقوم Aspose.Slides for C++ بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح لك Aspose.Slides بتحويل:
* عروض تقديمية كاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

Aspose.Slides تصدر العروض التقديمية إلى PDF، مما يضمن أن PDFs الناتجة مطابقة إلى حد كبير للعروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:
* صور
* مربعات نصية وأشكال
* تنسيق النص
* تنسيق الفقرة
* روابط تشعبية
* رؤوس وتذييلات
* نقاط تعداد
* جداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية تحويل PowerPoint إلى PDF القياسية الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يقوم بتحميل عرض وت保存 جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
تقدم Aspose محولًا مجانيًا على الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يُظهر عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتنفيذ عمليًا للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — التي تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية التعامل مع ملفات الميتا، وضبط مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

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

### **اختيار ضغط الصورة تلقائيًا**

عندما يحتوي عرض تقديمي على العديد من الصور الفوتوغرافية أو لقطات الشاشة، يمكن أن يقلل تقليل حجم PDF المُصدّر من صعوبة إرساله عبر البريد الإلكتروني أو تنزيله. استدعِ [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) مع `true` لتحديد تلقائيًا أكثر خوارزمية ضغط ملاءمة لكل صورة أثناء تصدير PDF.

المثال التالي يقوم بتحميل عرض تقديمي موجود، يفعّل اختيار ضغط الصورة تلقائيًا، ويحفظه كمستند PDF. تبقى جميع إعدادات تصدير PDF الأخرى على قيمها الافتراضية.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

هذا الخيار يختار خوارزمية ضغط لكل صورة. خفض جودة JPEG باستخدام [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) يقلل من جودة صورة JPEG، بينما خفض الدقة باستخدام [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) يسمح بالتحويل إلى دقة أقل، مما قد يقلل التفاصيل. تمكين اختيار الضغط التلقائي لا يقلل من أي من هذه الإعدادات.

يتطلب اختيار خوارزميات ضغط الصورة وقت معالجة إضافي وذاكرة. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يضمن تقليل ثابت لكل عرض.

### **الحفاظ على ملفات OLE المدمجة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مدمج، قد ترغب في أن يتمكن متلقي PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى عرض الشرائح. استدعِ [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) مع `true` للحفاظ على ملفات OLE المدمجة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو أيقونة كائن OLE على صفحة PDF، لكن الملف المدمج لا يُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا مرئيًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المدمج بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

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
1. افتح ملف PDF المُصدّر في عارض يدعم المرفقات مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد دفتر العمل المدمج.
3. احفظ المرفق وافتحه في Excel لفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المدمجة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما في ذلك دفاتر عمل Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي لـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

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

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط بدون نمط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق للنص حتى إذا لم يكن للخط نمط غامق مخصص. يمكن للنص أن يظهر غامقًا عبر التغليظ الصناعي، الذي يزيد سماكة الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، حاول استدعاء [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) مع `true`. هذا الخيار يرسم النص المتأثر كصورة bitmap أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. قيمته الافتراضية هي `false`.

يتضمن عرض العينة مربعين نصيين: أحدهما يحتوي على نص عادي والآخر على تنسيق غامق لنفس الخط الذي لا يمتلك نمط غامق مخصص. المثال التالي يحمل العرض، يفعّل تقطيع الخطوط غير المدعومة، ويصدّره إلى PDF:

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

العروض التالية تظهر النتيجة مع تعطيل الخيار والنتيجة مع تمكينه. في هذا المثال، يكون النص الغامق أكثر سمكًا عندما يكون الخيار معطَّل. عند تمكين الخيار، تكون خطوطه أرفع؛ يبقى النص العادي بدون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF مع تعسّق نمط الخط غير المدعوم معطل](unsupported-bold-disabled.png) | ![PDF مع تعسّق نمط الخط غير المدعوم مفعَّل](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تمكين الخيار إلى تحويل النص الغامق فقط إلى صورة bitmap: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حدوده أضعف عند التكبير 800%. يبقى النص العادي قابلًا للبحث. عند تعطيل الخيار، يظل كلا النصين نصًا.

هذا الخيار يحول النص المنسق كغامق إلى صورة bitmap عندما لا يمتلك الخط نمط غامق مخصص. [Font substitution](/slides/ar/cpp/font-substitution/) بدلاً من ذلك يختار خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و 3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يضبط محتوى الشريحة لتلائم الحجم ويصدر الشريحة الوحيدة إلى PDF.

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

// إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد بها.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF في عرض شريحة الملاحظات**

المثال التالي يصدر عرضًا إلى PDF، حيث يضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال لـ PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود C++ عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير الامتثال المختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء تحويلات [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى صيغ متخصصة — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والمخططات والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم تصنيفها كملحقات؛ يتم توفير النص البديل للكيان الكامل فقط.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لملفات PPT أو PPTX المتعددة إلى PDF. يمكنك الانتقال عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل من الممكن حماية PDF المحول بكلمة مرور؟**

نعم. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم. يمكنك التحكم في جودة الصورة باستخدام طرق مثل [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و[set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) في الفئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير امتثال PDF/A؟**

نعم. يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides لـ C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)