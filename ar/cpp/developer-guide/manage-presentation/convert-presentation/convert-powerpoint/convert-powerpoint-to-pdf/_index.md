---
title: تحويل PowerPoint إلى PDF في C++
linktitle: تحويل PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/cpp/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- عرض تقديمي
- PowerPoint إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides لـ C++
description: "تحويل عروض PowerPoint التقديمية إلى PDF في C++. حفظ PowerPoint كـ PDF مع الامتثال أو معايير الوصول."
---

## **نظرة عامة**

يقدم تحويل مستندات PowerPoint إلى صيغة PDF عدة فوائد، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق عرضك التقديمي. تُظهر لك هذه المقالة كيفية تحويل العروض التقديمية إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار الشرائح للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بهذه الصيغ إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF، عليك ببساطة تمرير اسم الملف كوسيط في [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class ثم حفظ العرض التقديمي كـ PDF باستخدام دالة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e). يكشف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class دالة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

تقوم Aspose.Slides لـ C++ بكتابة معلومات واجهة برمجة التطبيقات ورقم الإصدار مباشرة في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides لـ C++ بملء حقل التطبيق بقيمة '*Aspose.Slides*' وحقل منتج PDF بقيمة في صيغة '*Aspose.Slides v XX.XX*'. **ملاحظة** أنك لا تستطيع إخبار Aspose.Slides لـ C++ بتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

تتيح لك Aspose.Slides تحويل:

* عرض تقديمي كامل إلى PDF
* شرائح معينة في عرض تقديمي إلى PDF
* عرض تقديمي 

تقوم Aspose.Slides بتصدير العروض التقديمية إلى PDF بطريقة تجعل محتويات PDF الناتجة مشابهة جدًا لتلك الموجودة في العروض التقديمية الأصلية. غالبًا ما يتم عرض هذه العناصر والسمات المعروفة بشكل صحيح في تحويلات العروض التقديمية إلى PDF:

* الصور
* مربعات النص والأشكال الأخرى
* النصوص وتنسيقها
* الفقرات وتنسيقها
* الروابط التشعبية
* رؤوس وتذييلات
* نقاط
* جداول

## **تحويل PowerPoint إلى PDF**

يتم تنفيذ عملية تحويل PowerPoint إلى PDF القياسية باستخدام الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام إعدادات مثالية عند أعلى مستويات الجودة.

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>الخطوات: تحويل PowerPoint إلى PDF في C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>الخطوات: تحويل PPT إلى PDF في C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>الخطوات: تحويل PPTX إلى PDF في C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>الخطوات: تحويل ODP إلى PDF في C++</strong></a>

تظهر لك هذه الشيفرة C++ كيفية تحويل PowerPoint إلى PDF:

```c++
// ينشيء كائن من 클래س Presentation يمثل ملف PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// يحفظ العرض التقديمي كـ PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

توفر Aspose أداة تحويل [**PowerPoint إلى PDF مجانية على الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العروض التقديمية إلى PDF. لأي تنفيذ حي للإجراء الموصوف هنا، يمكنك إجراء اختبار مع الأداة.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة - خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) - تسمح لك بتخصيص PDF (الناجم عن عملية التحويل)، وتأمين PDF بكلمة مرور، أو حتى تحديد كيف ينبغي أن تسير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل لديك للصور النقطية، وتحديد كيفية التعامل مع ملفات الميتا، وتعيين مستوى الضغط للنصوص، وتعيين DPI للصور، إلخ.

توضح المثال الشيفري أدناه عملية يتم فيها تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```c++
// ينشيء كائن PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// يعين الجودة لصور JPG
pdfOptions->set_JpegQuality(90);

// يعين DPI للصور
pdfOptions->set_SufficientResolution(300);

// يعين السلوك لملفات الميتا
pdfOptions->set_SaveMetafilesAsPng(true);

// يعين مستوى ضغط النص للمحتوى النصي
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// يحدد وضع الامتثال PDF
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// ينشيء كائن Presentation يمثل مستند PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// يحفظ العرض التقديمي كـ مستند PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض التقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص - خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) - لإ instruct Aspose.Slides لضم الشرائح المخفية كصفحات في ملف PDF الناتج.

تظهر لك هذه الشيفرة C++ كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```c++
// ينشيء كائن من класس Presentation يمثل ملف PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// ينشيء كائن PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// يضيف الشرائح المخفية
pdfOptions->set_ShowHiddenSlides(true);

// يحفظ العرض التقديمي كـ PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

تظهر لك هذه الشيفرة C++ كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)):

```c++
// ينشيء كائن Presentation يمثل ملف PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// ينشيء كائن PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// يعين كلمة مرور PDF وأذونات الوصول
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// يحفظ العرض التقديمي كـ PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### اكتشاف استبدالات الخطوط

توفر Aspose.Slides دالة [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) ضمن فئة [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) للسماح لك باكتشاف استبدالات الخطوط في عملية تحويل العرض التقديمي إلى PDF.

تظهر لك هذه الشيفرة C++ كيفية اكتشاف استبدالات الخطوط:

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"ستتم استبدال الخط"))
    {
        System::Console::WriteLine(u"تحذير استبدال الخط: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

والشيفرة C++ التالية توضح كيفية استخدام الفئة السابقة:

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول الحصول على ردود الاتصال لاستبدال الخطوط في عملية العرض، راجع [الحصول على ردود اتصال للتحذيرات لاستبدالات الخطوط](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخطوط](https://docs.aspose.com/slides/cpp/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المختارة في PowerPoint إلى PDF**

تظهر لك هذه الشيفرة C++ كيفية تحويل شرائح معينة في عرض PowerPoint إلى PDF:

```C++
// ينشيء كائن Presentation يمثل ملف PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// يعين مصفوفة مواضع الشرائح
auto slides = System::MakeArray<int32_t>({1, 3});

// يحفظ العرض التقديمي كـ PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصصة**

تظهر لك هذه الشيفرة C++ كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:

```C++
// المسار إلى دليل المستندات.
String dataDir = GetDataPath()

// ينشيء كائن من класس Presentation يمثل ملف PowerPoint 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// يعين نوع وحجم الشريحة 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **تحويل PowerPoint إلى PDF في عرض شريحة الملاحظات**

تظهر لك هذه الشيفرة C++ كيفية تحويل PowerPoint إلى PDF ملاحظات:

```C++
// المسار إلى دليل المستندات.
System::String dataDir = u"";

// ينشيء كائن Presentation يمثل ملف PowerPoint
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// يحفظ العرض التقديمي إلى PDF ملاحظات
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **معايير الوصول والامتثال لـ PDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

توضح هذه الشيفرة C++ عملية تحويل PowerPoint إلى PDF حيث يتم الحصول على ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="ملاحظة" color="warning" %}} 

دعم Aspose.Slides لعمليات تحويل PDF يمتد إلى السماح لك بتحويل PDF إلى أكثر تنسيقات الملفات شعبية. يمكنك القيام بتحويل [PDF إلى HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). ويتم دعم عمليات تحويل PDF الأخرى إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}