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
- حفظ PowerPoint كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

إن تحويل عروض PowerPoint (PPT، PPTX، ODP، وغيرها) إلى تنسيق PDF باستخدام C++ يقدم عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وعناصر التنسيق في العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرِّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) توفر طريقة `Save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for C++ بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة على نمط "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح لك Aspose.Slides بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يُصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم تمثيل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يظهر هذا المثال بلغة C++ كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```c++
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

يقدم Aspose أداة تحويل مجانية عبر الإنترنت لـ [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك تجربة هذه الأداة للحصول على تنفيذ عملي للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خاصيات ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو تأمين PDF بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:
```c++
// إنشاء كائن فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين جودة صور JPG.
pdfOptions->set_JpegQuality(90);

// تعيين DPI للصور.
pdfOptions->set_SufficientResolution(300);

// تعيين السلوك للملفات الميتا.
pdfOptions->set_SaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تحديد وضع توافق PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الطريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يظهر هذا المثال بلغة C++ كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c++
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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

يُظهر هذا المثال بلغة C++ كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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


### **الكشف عن استبدالات الخطوط**

يوفر Aspose.Slides الطريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) التي تتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يظهر هذا المثال بلغة C++ كيفية الكشف عن استبدالات الخطوط:
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
    // إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين رد النداء للتحذير في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض التقديمي كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول استقبال ردود النداء لاستبدالات الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يوضح هذا المثال بلغة C++ كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```C++
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تحديد مصفوفة أرقام الشرائح.
auto slides = MakeArray<int32_t>({ 1, 3 });

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يوضح هذا المثال بلغة C++ كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد مع حجم شريحة معدل.
auto resizedPresentation = MakeObject<Presentation>();

// تعيين حجم الشريحة المخصص.
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

يوضح هذا المثال بلغة C++ كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```C++
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument file.
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


## **معايير الوصول والامتثال لملفات PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يوضح هذا المثال بلغة C++ عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ التحويلات إلى [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). كما يُدعم التحويل إلى صيغ متخصصة مثل [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لملفات PPT أو PPTX متعددة إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF المحول باستخدام كلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استخدم الطريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `set_JpegQuality` و`set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، لضمان توافق وثائقك مع متطلبات الوصول والحفظ الأرشيفي.

## **موارد إضافية**

- [Aspose.Slides for C++ Documentation](/slides/ar/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)