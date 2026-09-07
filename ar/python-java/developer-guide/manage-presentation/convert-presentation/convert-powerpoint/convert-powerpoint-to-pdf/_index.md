---
title: تحويل PPT و PPTX إلى PDF في Python عبر Java [تشمل ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Python عبر Java باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في Python عبر Java يوفر عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق عرضك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كوسيط إلى الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام الطريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) تضمن الطريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java يُدرج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، تقوم Aspose.Slides بملء حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بصورة "*Aspose.Slides v XX.XX*". **Note** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض إلى PDF

تُصدر Aspose.Slides العروض إلى PDF، مع ضمان أن تكون ملفات PDF الناتجة مطابقة بشكل كبير للعروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* الرموز النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يستخدم التحويل القياسي إعدادات التصدير الافتراضية لـ PDF. استخدم الخيارات المخصصة عندما تحتاج إلى التحكم في جودة الصورة أو محتوى الصفحة أو الامتثال للمعايير.

قم بتثبيت [Aspose.Slides for Python via Java](/slides/ar/python-java/installation/) وبيئة تشغيل Java متوافقة قبل تشغيل الأمثلة. كل مثال يقرأ الملف `presentation.pptx` من دليل العمل الحالي؛ استبدله بملف PPT أو PPTX أو ODP الخاص بك. ابدأ JVM مرة واحدة لكل عملية Python.

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
Aspose يقدم محولًا إلكترونيًا مجانيًا على الإنترنت لـ **محول PowerPoint إلى PDF**([**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf)) يوضح عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المحول لاختبار التنفيذ الفعلي للإجراء الموصوف هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصور النقطية المفضل، تحديد كيفية التعامل مع ملفات الميتافايل، تعيين مستوى ضغط النص، تكوين DPI للصور، وأكثر.

المثال البرمجي أدناه يوضح كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

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

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الطريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

الكود التالي يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

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

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/):

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

توفر Aspose.Slides الطريقة [setWarningCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setWarningCallback) تحت الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

استخدم وكيل JPype لتلقي استدعاءات التحذير من واجهة Java. حوِّل سلسلة الوصف من Java إلى سلسلة Python قبل فحص البادئة:

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
لمزيد من المعلومات حول تلقي استدعاءات التحذير لاستبدال الخطوط أثناء عملية العرض، راجع [الحصول على استدعاءات التحذير لاستبدال الخطوط](/slides/ar/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، اطلع على مقال [استبدال الخطوط](/slides/ar/python-java/font-substitution/).
{{% /alert %}}

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

أرقام الشرائح الممررة إلى الطريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) تبدأ من 1. يُصدّر هذا المثال الشرائح 1 و3 عندما تكون موجودة:

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

هذا المثال يُصدّر الشريحة الأولى على صفحة مقاسها 612 × 792 نقطة (US Letter). يقوم باستنساخ الشريحة في عرض جديد بالحجم المحدد:

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

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

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

## **معايير الوصول والامتثال للـ PDF**

عند إعداد ملفات PDF قابلة للوصول، راجع [إرشادات محتوى الويب للوصلية (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). استخدم [PdfOptions.setCompliance](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setCompliance) لاختيار معيار الإخراج: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

> **ملاحظة:** عند التصدير إلى PDF/UA، تتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم حفظ العناصر الفردية كمسارات منفصلة وقد يتم تعليمها كقطع فنية؛ يتم توفير النص البديل فقط للشكل كاملًا.

## **الأسئلة المتكررة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعيًا؟**

نعم، تدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في الـ PDF؟**

استخدم الطريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setJpegQuality) و[setSufficientResolution](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSufficientResolution) في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لضمان صور ذات جودة عالية في PDF.

**هل تدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، تسمح Aspose.Slides بتصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، للاستخدام في الوصول أو الأرشفة. اختر المعيار المناسب وراجع الناتج وفقًا لمتطلباتك.

## **موارد إضافية**

- [Aspose.Slides for Python via Java Documentation](/slides/ar/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/ar/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ar/conversion)