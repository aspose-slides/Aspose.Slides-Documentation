---
title: تحويل PPT و PPTX إلى PDF في Python عبر Java [متضمنة الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/python-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض
- PowerPoint إلى PDF
- العرض إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Python عبر Java باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يتيح تحويل عروض PowerPoint (PPT و PPTX و ODP وغيرها) إلى صيغة PDF في Python عبر Java عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط العرض وتنسيقه. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). فئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) توفر طريقة [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}

يقوم Aspose.Slides for Python via Java بإدراج معلومات API وإصدارها في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكن توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية بشكل كبير. تُ render العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النصوص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات وتذييلات الصفحات
* العلامات النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يستخدم التحويل القياسي إعدادات تصدير PDF الافتراضية. استخدم خيارات مخصصة عندما تحتاج إلى التحكم في جودة الصورة أو محتوى الصفحة أو التوافق مع معايير PDF.

قم بتثبيت [Aspose.Slides for Python via Java](/slides/ar/python-java/installation/) وجافا رن تايم متوافق قبل تشغيل الأمثلة. كل مثال يقرأ `presentation.pptx` من دليل العمل الحالي؛ استبدله بملف PPT أو PPTX أو ODP الخاص بك. ابدأ JVM مرة واحدة لكل عملية Python.

المثال التالي يحمل عرضاً ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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

تقدم Aspose أداة مجانية على الإنترنت تُدعى [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تجربة هذه الأداة لتطبيق عملي مباشر للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يقدم Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصور النقطية المفضلة، وتحديد طريقة معالجة ملفات الميتافايل، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وغيرها.

المثال التالي يصدر عرضاً إلى PDF 1.5 مع جودة JPEG محددة إلى 90، ودقة صورة 300 DPI، وحفظ ملفات الميتافايل بصيغة PNG، وضغط نص Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مدمج، قد ترغب في أن يتمكن متلقي PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) مع القيمة `True` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يتم عرض صورة المعاينة أو الأيقونة لكائن OLE على صفحة PDF، لكن الملف المدمج غير مضمّن كمرفق. ضبط الخيار على `True` يضيف بيانات الملف كمرفق إضافي. تبقى المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المدمج بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضاً يحتوي بالفعل على مصنف Excel مدمج ويصدره إلى PDF مع إرفاق المصنف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

للتحقق من النتيجة:

1. افتح PDF المُصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد المصنف المدمج.
3. احفظ المرفق وافتحه في Excel لتفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. تكون المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}

تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المدمجة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما في ذلك مصنفات Excel. هذه متطلبات المعايير، وليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي ولا يوضح تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لإدراج الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضاً إلى PDF، متضمنًا أي شرائح مخفية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تحويل PowerPoint إلى PDF محمّى بكلمة مرور**

المثال التالي يصدر عرضاً إلى PDF يتطلب كلمة المرور `password` لفتحه. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **اكتشاف استبدال الخطوط**

يقدم Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) تمكِّنك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضاً إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير. استخدم وكيل JPype لتلقي ردود التحذير من API جافا. حوّل سلسلة الوصف من جافا إلى سلسلة بايثون قبل فحص البادئة:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/python-java/font-substitution/).

{{% /alert %}}

## **تحويل شرائح محددة من PowerPoint إلى PDF**

أرقام الشرائح التي تُمرّر إلى [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) تُعدّ مرقمة بدءًا من 1. هذا المثال يصدر الشرائح 1 و3 عندما تكون موجودة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

هذا المثال يصدر الشريحة الأولى على صفحة مقاسها 612 × 792 نقطة (US Letter). يقوم بنسخ الشريحة إلى عرض تقديمي جديد بالحجم المحدد ويضبط محتوى الشريحة للتناسب.

```python
import jpipe
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد بها.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يصدر عرضاً إلى PDF، يوضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **إمكانية الوصول ومعايير الالتزام لملفات PDF**

عند إعداد ملفات PDF قابلة للوصول، راجع [إرشادات محتوى الويب لتسهيل الوصول (WCAG)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). استخدم [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) لاختيار معيار الإخراج: **PDF/A1a** و**PDF/A1b** و**PDF/UA**.

يوضح هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة وفقًا لمعايير الالتزام المختلفة:

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

> **ملاحظة:** عند التصدير إلى PDF/UA، يعامل Aspose.Slides الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُصنّف كآثار؛ يُقدَّم النص البديل فقط للشكل بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لملفات PPT أو PPTX متعددة إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المُحوّل بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع القيمة `True` في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و[setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الالتزام PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، لتلبية احتياجات الوصول أو الأرشفة. اختر المعيار المناسب وراجع المخرجات وفقًا لمتطلباتك.

## **موارد إضافية**

- [Aspose.Slides for Python via Java Documentation](/slides/ar/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)