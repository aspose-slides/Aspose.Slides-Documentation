---
title: تحويل PPT و PPTX إلى PDF في C++ [مع ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة، قابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام C++ عدة مزايا، منها التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض الموجودة بالصيحات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. فئة [العرض التقديمي](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) توفر طريقة `Save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يضيف Aspose.Slides for C++ معلومات واجهة برمجة التطبيقات ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يتيح لك Aspose.Slides تحويل:

* العروض التقديمية كاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، مع ضمان أن تتطابق ملفات PDF الناتجة بشكل كبير مع العروض الأصلية. تُ render العناصر والخصائص بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* النقط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدَّم إلى PDF باستخدام الإعدادات المثلى وأعلى مستويات الجودة.

يعرض هذا الكود C++ كيفية تحويل عرض تقديمي (PPT، PPTX، ODP، إلخ) إلى PDF:

```c++
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

توفر Aspose مُحوِّلًا مجانيًا على الإنترنت لـ [محول PowerPoint إلى PDF](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) يُظهر عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المحول لإجراء اختبار عملي للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتافايل، وضبط مستوى ضغط النص، وتكوين DPI للصور، وأكثر من ذلك.

يوضح المثال التالي كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```c++
// إنشاء كائن فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين جودة الصور JPG.
pdfOptions->set_JpegQuality(90);

// تعيين DPI للصور.
pdfOptions->set_SufficientResolution(300);

// تعيين سلوك ملفات الميتافايل.
pdfOptions->set_SaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تحديد وضع الامتثال لـ PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

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

يبين هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/):

```c++
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتمكينك من اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

يعرض هذا الكود C++ كيفية اكتشاف استبدال الخطوط:

```c++
// تنفيذ استدعاء التحذير.
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
    // إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين رد نداء التحذير في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض التقديمي كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول تلقي ردود النداء لاستبدال الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يوضح هذا الكود C++ كيفية تحويل شرائح معينة فقط من عرض PowerPoint إلى PDF:

```C++
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
auto slides = MakeArray<int32_t>({ 1, 3 });

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يوضح هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF باستخدام حجم شريحة محدد:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يوضح هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```C++
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// تكوين خيارات PDF مع تخطيط الملاحظات.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي إلى PDF مع الملاحظات.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **معايير الوصول والامتثال لملفات PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يوضح هذا الكود C++ عملية تحويل من PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:

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

{{% alert title="Note" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء عمليات تحويل [PDF إلى HTML](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والمخططات والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم اعتبارها كعناصر فنية؛ يتم توفير النص البديل فقط للكائن بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل بين ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `set_JpegQuality` و`set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يسمح لك Aspose.Slides بتصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides for C++](https://reference.aspose.com/slides/ar/cpp/)
- [محولات مجانية على الإنترنت من Aspose](https://products.aspose.app/slides/ar/conversion)