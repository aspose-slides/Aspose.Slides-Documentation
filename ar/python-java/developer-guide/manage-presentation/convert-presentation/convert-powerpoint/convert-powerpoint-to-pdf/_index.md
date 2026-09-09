---
title: تحويل PPT و PPTX إلى PDF في Python عبر Java [متضمنة الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/python-java/convert-powerpoint-to-pdf/
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
- Python
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Python عبر Java باستخدام Aspose.Slides، مع أمثلة برمجية سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في Python عبر Java يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) تعرض طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يُدرج Aspose.Slides for Python عبر Java معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على الشكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق تقريبًا العروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط الفائقة
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يستخدم التحويل القياسي إعدادات التصدير الافتراضية لملف PDF. استخدم الخيارات المخصصة عندما تحتاج إلى التحكم في جودة الصورة، محتوى الصفحة، أو امتثال PDF.

قم بتثبيت [Aspose.Slides for Python via Java](/slides/ar/python-java/installation/) وبيئة تشغيل Java المتوافقة قبل تشغيل الأمثلة. كل مثال يقرأ `presentation.pptx` من دليل العمل الحالي؛ استبدله بملف PPT أو PPTX أو ODP الخاص بك. ابدأ الـ JVM مرة واحدة لكل عملية Python.

هذا الكود يحول عرضًا تقديميًا إلى PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
توفر Aspose محولًا مجانيًا على الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) الذي يوضح عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتطبيق عملي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) — التي تتيح لك تخصيص ملف PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، تحديد طريقة معالجة ملفات الميتا، تعيين مستوى الضغط للنص، تكوين DPI للصور، وأكثر.

يبين مثال الشيفرة أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

استخدم وكيل JPype لتلقي ردود التحذير من واجهة برمجة تطبيقات Java. حوّل سلسلة الوصف من Java إلى سلسلة Python قبل فحص البادئة الخاصة بها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
لمزيد من المعلومات حول تلقي ردود التحذير لاستبدال الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Font Substitution](/slides/ar/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، اطلع على مقالة [Font Substitution](/slides/ar/python-java/font-substitution/).
{{% /alert %}}

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

أرقام الشرائح التي يتم تمريرها إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) تبدأ من 1. هذا المثال يصدر الشرائح 1 و3 عندما تكون موجودة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

هذا المثال يصدر الشريحة الأولى على صفحة قياسها 612 × 792 نقطة (US Letter). ينسخ الشريحة إلى عرض تقديمي جديد بالحجم المحدد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **تحويل PowerPoint إلى PDF في وضع شريحة الملاحظات**

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **معايير الوصول والامتثال لملفات PDF**

عند إعداد ملفات PDF قابلة للوصول، راجع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). استخدم [PdfOptions.setCompliance](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setCompliance) لتحديد معيار الإخراج: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تُنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم وضع علامة عليها كآثار؛ يتم توفير النص البديل فقط للكائن الكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF مجمّعة؟**

نعم، يدعم Aspose.Slides تحويل دفعة من عدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) في فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSufficientResolution) في فئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير امتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير ملفات PDF متوافقة مع [various standards](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، للوصول أو الأرشفة. اختر المعيار المناسب وراجع النتيجة وفقًا لاحتياجاتك.

## **موارد إضافية**

- [توثيق Aspose.Slides for Python عبر Java](/slides/ar/python-java/)
- [مرجع API لـ Aspose.Slides for Python عبر Java](https://reference.aspose.com/slides/ar/python-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)