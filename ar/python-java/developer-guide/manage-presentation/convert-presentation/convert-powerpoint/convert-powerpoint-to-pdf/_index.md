---
title: تحويل PPT و PPTX إلى PDF في Python عبر Java [تتضمن ميزات متقدمة]
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
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Python عبر Java باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يتيح تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام Python عبر Java عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط العرض وتنسيقه. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). تعرض فئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) التي تُستخدم عادة لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
تدرج Aspose.Slides for Python عبر Java معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، تُملأ حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكن إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

تسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

تُصدر Aspose.Slides العروض إلى PDF، مع ضمان أن تتطابق ملفات PDF الناتجة بشكل قريب مع العروض الأصلية. تُعرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الارتباطات التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يستخدم التحويل القياسي الإعدادات الافتراضية لتصدير PDF. استخدم خيارات مخصصة عندما تحتاج إلى التحكم في جودة الصورة أو محتوى الصفحة أو امتثال PDF.

قم بتثبيت [Aspose.Slides for Python عبر Java](/slides/ar/python-java/installation/) وتأكد من وجود بيئة تشغيل Java متوافقة قبل تشغيل الأمثلة. كل مثال يقرأ الملف `presentation.pptx` من دليل العمل الحالي؛ استبدله بملف PPT أو PPTX أو ODP الخاص بك. ابدأ الـ JVM مرة واحدة لكل عملية Python.

المثال التالي يحمل عرضًا ويحفظ جميع الشرائح المرئية إلى PDF باستخدام الإعدادات الافتراضية للتصدير.

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
توفر Aspose أداة مجانية على الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتطبيق عملي مباشر للإجراءات الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة — خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصور النقطية المفضل، وتحديد كيفية معالجة ملفات الميتافايل، وضبط مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

المثال التالي يصدر عرضًا إلى PDF 1.5 بجودة JPEG 90، ودقة الصورة 300 DPI، والملفات الميتا محفوظة كـ PNG، وضغط نص Flate.

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

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في أن يتمكن مستقبلو PDF من الوصول إلى بيانات المصنف بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) مع `True` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يتم عرض صورة المعاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمن لا يُضاف كمرفق. ضبط الخيار إلى `True` يضيف بيانات الملف كذلك. تظل المعاينة تمثيلًا بصريًا؛ المرفق يسمح للمستلمين بفتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدّره إلى PDF مع إرفاق المصنف.

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

1. افتح ملف PDF المُصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. تكون المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تقوّم معايير PDF/A المرفقات: PDF/A-1 يحظر الملفات المضمنة، PDF/A-2 يسمح بمرفقات PDF/A فقط، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها مصنفات Excel. هذه متطلبات المعايير نفسها، وليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي لامتثال PDF ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF مع تضمين أي شرائح مخفية.

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

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

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

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتمكينك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير. استخدم وكيل JPype لتلقي استدعاءات التحذير من API Java. حوّل سلسلة الوصف Java إلى سلسلة Python قبل فحص بادئتها:

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخطوط](/slides/ar/python-java/font-substitution/).
{{% /alert %}}

### **معالجة الخطوط بدون نمط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق على النص حتى إذا لم يكن للخط نمط غامق مخصص. لا يزال النص يظهر بالغامق عبر "الخط الغامق الصناعي"، الذي يثخّن الحروف العادية اصطناعيًا. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) مع `True`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. القيمة الافتراضية هي `False`.

العرض النموذجي يحتوي على صندوقي نص: أحدهما بنص عادي والآخر بنص غامق مطبق على نفس الخط الذي لا يملك نمطًا غامقًا مخصصًا. المثال التالي يحمل العرض، يفعّل تحويل الأنماط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

المعاينات التالية تُظهر النتيجة مع تعطيل الخيار ومع تفعيله. في هذا المثال، يكون النص الغامق ذو خطوط أثقل مع الخيار معطل. مع تفعيل الخيار، تكون خطوطه أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد المناسب لعرضك.

| الخيار معطل (`False`، الافتراضي) | الخيار مفعَّل (`True`) |
|---|---|
| ![PDF مع إلغاء تمكين تعيين نمط الخط غير المدعوم](unsupported-bold-disabled.png) | ![PDF مع تمكين تعيين نمط الخط غير المدعوم](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تمكين الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند تكبير 800٪. يظل النص العادي قابلًا للبحث. مع تعطيل الخيار، يبقى كل النص قابلًا للبحث.

هذا الخيار يُحوّل النص المنسق كغامق عندما لا يتوفر للخط نمط غامق مخصص. بدلاً من ذلك، تقوم [استبدال الخطوط](/slides/ar/python-java/font-substitution/) باختيار خط آخر عندما يكون الخط الأصلي غير متوفر.

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

أرقام الشرائح التي تُمرَّر إلى [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) تُعدّ مرقمة بدءًا من 1. يُصدّر المثال التالي الشرائح 1 و3 عندما تكون موجودة:

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

يُصدّر هذا المثال الشريحة الأولى على صفحة بحجم 612×792 نقطة (US Letter). ينسخ الشريحة إلى عرض جديد بالحجم المحدد ويُقيس محتوى الشريحة ليناسب الحجم.

```python
import jpype
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

    # إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد بها.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يُصدّر عرضًا إلى PDF، مع وضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير إمكانية الوصول والامتثال لـ PDF**

عند إعداد ملفات PDF قابلة للوصول، استعن بـ [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). استخدم [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) لاختيار معيار الإخراج: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يُظهر الكود التالي عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

> **ملاحظة:** عند التصدير إلى PDF/UA، تُعامل Aspose.Slides الرسومات المعقّدة مثل SmartArt والرسوم البيانية والصيغ ككائن موحد واحد. لا تُحفظ عناصر المسار الفردية كقُطَع محتوى منفصلة وقد تُصنّف كعناصر صناعية؛ يُوفر النص البديل فقط للكائن الموحد بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، تدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل بين ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع `True` في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة الصورة العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام أساليب مثل [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و[setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل تدعم Aspose.Slides معايير امتثال PDF/A؟**

نعم، تتيح Aspose.Slides لك تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/)، بما فيها PDF/A1a وPDF/A1b وPDF/UA، لتوفير إمكانية الوصول أو الأرشفة. اختر المعيار المناسب وراجع النتيجة وفقًا لمتطلباتك.

## **موارد إضافية**

- [توثيق Aspose.Slides for Python عبر Java](/slides/ar/python-java/)
- [مرجع API لـ Aspose.Slides for Python عبر Java](https://reference.aspose.com/slides/python-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)