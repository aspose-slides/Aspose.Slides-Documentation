---
title: تحويل PPT و PPTX إلى PDF في C++ [تشمل الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/cpp/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- PowerPoint إلى PDF
- عرض تقديمي إلى PDF
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
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في C++ عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل طريقة تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتشمل الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير التوافق على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. تُعرّض فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) طريقة `Save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ يدرج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مع ضمان تطابق ملفات PDF الناتجة مع العروض الأصلية قدر الإمكان. تُرسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

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

يعرض الكود التالي كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF في C++:

```c++
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// حفظ العرض كملف PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
تقدّم Aspose أداة مجانية على الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) تُظهر عملية التحويل من العرض إلى PDF. يمكنك تجربة هذه الأداة للحصول على تنفيذ عملي للعملية الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتكوين DPI للصور، وغير ذلك.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```c++
// إنشاء كائن من الفئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ضبط جودة صور JPG.
pdfOptions->set_JpegQuality(90);

// ضبط DPI للصور.
pdfOptions->set_SufficientResolution(300);

// ضبط سلوك ملفات الميتا.
pdfOptions->set_SaveMetafilesAsPng(true);

// ضبط مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تعريف وضع الامتثال لملف PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض الكود التالي كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```c++
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// إضافة الشرائح المخفية.
pdfOptions->set_ShowHiddenSlides(true);

// حفظ العرض كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح الكود التالي في C++ كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/):

```c++
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// حفظ العرض كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) التي تمكنك من اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

يعرض الكود التالي في C++ كيفية اكتشاف استبدال الخطوط:

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
    // إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
لمزيد من المعلومات حول استلام ردود النداءات لاستبدال الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من التفاصيل حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).
{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يوضح الكود التالي في C++ كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:

```C++
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Set array of slide numbers.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Save the presentation as a PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يوضح الكود التالي في C++ كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد مع حجم شريحة معدل.
auto resizedPresentation = MakeObject<Presentation>();

// ضبط حجم الشريحة المخصص.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// استنساخ الشريحة الأولى من العرض الأصلي.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// حفظ العرض المعاد تحجيمه إلى PDF مع الملاحظات.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظة الشريحة**

يوضح الكود التالي في C++ كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```C++
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// تكوين خيارات PDF مع تخطيط الملاحظات.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض إلى ملف PDF مع الملاحظات.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **معايير الوصول والامتثال للـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح الكود التالي في C++ عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ التحويلات التالية: [PDF to HTML](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-png/). كما تُدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/ar/cpp/conversion/pdf-to-xml/)—أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يعتبر Aspose.Slides الرسوميات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككيان واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُعدّ كملحقات؛ يُقدَّم النص البديل فقط للكيان بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides تحويل دفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتحديد كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `set_JpegQuality` و`set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يسمح Aspose.Slides لك بتصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **الموارد الإضافية**

- [وثائق Aspose.Slides for C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides for C++](https://reference.aspose.com/slides/ar/cpp/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)