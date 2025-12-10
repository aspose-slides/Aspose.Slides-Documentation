---
title: تحويل PPT و PPTX إلى PDF في C++ [ميزات متقدمة مشمولة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF ذات جودة عالية وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، وما إلى ذلك) إلى صيغة PDF باستخدام C++ عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. تعرض فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) طريقة `Save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides للـ C++ بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يُصدّر Aspose.Slides العروض إلى PDF، مع ضمان أن تكون ملفات PDF الناتجة متطابقة تقريبًا مع العروض الأصلية. يتم عرض العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

هذا الكود C++ يوضح كيفية تحويل عرض (PPT، PPTX، ODP، وما إلى ذلك) إلى PDF:
```c++
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// حفظ العرض كملف PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

يوفر Aspose أداة مجانية على الإنترنت تُدعى [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة لتطبيق عملي للإجراء المبيّن هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يقدِّم Aspose.Slides خيارات مخصَّصة — خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصَّصة**

باستخدام خيارات التحويل المخصَّصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتافايل، وضبط مستوى الضغط للنص، وتكوين DPI للصور، وأكثر.

يوضح المثال التالي كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصَّصة.
```c++
// إنشاء كائن PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين جودة صور JPG.
pdfOptions->set_JpegQuality(90);

// تعيين DPI للصور.
pdfOptions->set_SufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions->set_SaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تعريف وضع الامتثال لملف PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا الكود C++ يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c++
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// إضافة الشرائح المخفية.
pdfOptions->set_ShowHiddenSlides(true);

// حفظ العرض كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود C++ يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// حفظ العرض كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **اكتشاف استبدال الخطوط**

يقدم Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) تتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

هذا الكود C++ يوضح كيفية اكتشاف استبدال الخطوط:
```c++
// تنفيذ رد النداء للتحذير.
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
    // إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين رد النداء للتحذير في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول تلقي ردود النداء لاستبدال الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

هذا الكود C++ يوضح كيفية تحويل شرائح معينة فقط من عرض PowerPoint إلى PDF:
```C++
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
auto slides = MakeArray<int32_t>({ 1, 3 });

// حفظ العرض كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصَّص**

هذا الكود C++ يوضح كيفية تحويل عرض PowerPoint إلى PDF مع حجم شريحة محدد:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
auto resizedPresentation = MakeObject<Presentation>();

// تعيين حجم الشريحة المخصص.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// حفظ العرض المعاد قياسه إلى ملف PDF مع الملاحظات.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

هذا الكود C++ يوضح كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```C++
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// تكوين خيارات PDF مع تخطيط الملاحظات.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض إلى PDF مع الملاحظات.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **إمكانية الوصول ومعايير الامتثال للـ PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل متوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

هذا الكود C++ يوضح عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ عمليات التحويل التالية: [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). كما تُدعم عمليات تحويل PDF إلى صيغ متخصصة أخرى — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تنويع الملفات وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `set_JpegQuality` و `set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF متوافقة مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان توافق مستنداتك مع متطلبات الوصول والحفظ الأرشيفي.

## **موارد إضافية**

- [توثيق Aspose.Slides للـ C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides للـ C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)