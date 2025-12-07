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
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في C++ باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C++ عدة فوائد، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `Save`. تُظهر فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) طريقة `Save` التي تُستخدم عادةً لتحويل عرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides للغة C++ بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مع ضمان أن تكون ملفات PDF الناتجة مطابقة تمامًا للعروض الأصلية. يتم تمثيل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الارتباطات التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود C++ كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```c++
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

يوفر Aspose أداة تحويل مجانية على الإنترنت **PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتطبيق عملي للإجراءات الموصوفة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — تمكنك من تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، والمزيد.

```c++
// إنشاء كائن من فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين جودة صور JPG.
pdfOptions->set_JpegQuality(90);

// تعيين DPI للصور.
pdfOptions->set_SufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions->set_SaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تحديد وضع الامتثال لـ PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

```c++
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// إضافة الشرائح المخفية.
pdfOptions->set_ShowHiddenSlides(true);

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يعرض هذا الكود С++ كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتمكينك من اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

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
    // إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تعيين استدعاء التحذير في خيارات PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // حفظ العرض التقديمي كملف PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول استلام ردود استدعاء لاستبدالات الخطوط أثناء عملية التقديم، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يعرض هذا الكود C++ كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```C++
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
auto slides = MakeArray<int32_t>({ 1, 3 });

// حفظ العرض التقديمي كملف PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يعرض هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
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


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يعرض هذا الكود C++ كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```C++
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// تهيئة خيارات PDF مع تخطيط الملاحظات.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف PDF مع الملاحظات.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **معايير الوصول والامتثال لـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل متوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). تدعم عمليات التحويل إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لملفات PPT أو PPTX المتعددة إلى PDF. يمكنك تنفيذ حلقة عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية ملف PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `set_ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `set_JpegQuality` و`set_SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير ملفات PDF متوافقة مع معايير مختلفة، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، مما يضمن تلبية المستندات لمتطلبات الوصول والحفظ الأرشيفي.

## **موارد إضافية**

- [توثيق Aspose.Slides للغة C++](/slides/ar/cpp/)
- [مرجع API لـ Aspose.Slides للغة C++](https://reference.aspose.com/slides/cpp/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)