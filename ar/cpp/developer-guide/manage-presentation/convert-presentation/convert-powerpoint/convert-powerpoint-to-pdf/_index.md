---
title: تحويل PPT و PPTX إلى PDF في C++ [متضمن ميزات متقدمة]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة شيفرة سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C++ يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف بدائل الخطوط، اختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) تُظهر طريقة `Save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

يقوم Aspose.Slides للغة C++ بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على صيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يتيح لك Aspose.Slides تحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من العرض إلى PDF

يُصدّر Aspose.Slides العروض إلى PDF، مع ضمان أن تطابق ملفات PDF الناتجة العروض الأصلية بأقرب قدر ممكن. تُرسم العناصر والسمات بدقة في عملية التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

يعرض هذا الكود C++ كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```c++
// إنشاء كائن الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

يقدم Aspose محولًا مجانيًا عبر الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتجربة تنفيذ الإجراء الموضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصورة النقطية المفضلة لديك، تحديد كيفية معالجة ملفات الميتافایل، ضبط مستوى الضغط للنص، تكوين DPI للصور، وأكثر.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```c++
// إنشاء كائن فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين جودة صور JPG.
pdfOptions->set_JpegQuality(90);

// تعيين DPI للصور.
pdfOptions->set_SufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions->set_SaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تعريف وضع امتثال PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c++
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// إضافة الشرائح المخفية.
pdfOptions->set_ShowHiddenSlides(true);

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن الفئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين كلمة مرور PDF وصلاحيات الوصول.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **اكتشاف بدائل الخطوط**

يوفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) تحت فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتتمكن من اكتشاف بدائل الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود C++ كيفية اكتشاف بدائل الخطوط:
```c++
// تنفيذ رد النداء التحذيري.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض التقديمي كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

للمزيد من المعلومات حول استلام ردود النداء المتعلقة ببدائل الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

للمزيد من المعلومات حول بدائل الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

يُظهر هذا الكود C++ كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```C++
// إنشاء كائن الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ضبط مصفوفة أرقام الشرائح.
auto slides = MakeArray<int32_t>({ 1, 3 });

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF مع تحديد حجم الشريحة:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
auto resizedPresentation = MakeObject<Presentation>();

// ضبط حجم الشريحة المخصص.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// حفظ العرض التقديمي المعاد تحجيمه كملف PDF مع الملاحظات.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```C++
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// تكوين خيارات PDF مع تخطيط الملاحظات.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف PDF مع الملاحظات.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **إمكانية الوصول ومعايير الامتثال للـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أيٍ من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود C++ عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:
```C++
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


{{% alert title="ملاحظة" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء عمليات تحويل [PDF إلى HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و [PDF إلى PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و [PDF إلى XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

## **الأسئلة المتداولة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم الطريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل `set_JpegQuality` و `set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides للغة C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides للغة C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)