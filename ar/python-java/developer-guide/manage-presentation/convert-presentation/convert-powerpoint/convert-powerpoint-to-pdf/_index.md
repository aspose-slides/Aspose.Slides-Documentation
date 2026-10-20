---
title: تحويل PPT و PPTX إلى PDF في Python عبر Java [متضمنة ميزات متقدمة]
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

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في Python عبر Java يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدالات الخطوط، اختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). فئة [العرض التقديمي](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) تُظهر طريقة [حفظ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java يدرج معلومات واجهة برمجة التطبيقات وإصدارها في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة على الشكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية تقريبًا. يتم تمثيل العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

التحويل القياسي يستخدم إعدادات التصدير الافتراضية لـ PDF. استخدم خيارات مخصصة عندما تحتاج إلى التحكم في جودة الصورة أو محتوى الصفحة أو امتثال PDF.

المثال التالي يحمّل عرضًا تقديميًا ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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

Aspose يقدم محولًا مجانيًا على الإنترنت لملف [**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك تجربة هذا المحول لإجراء اختبار عملي للإجراءات الموصوفة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides يوفر خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—تسمح لك بتخصيص الـ PDF الناتج، قفل الـ PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصورة النقطية المفضلة، تحديد طريقة معالجة ملفات الميتافايل، تعيين مستوى ضغط النص، تكوين DPI للصور، والمزيد.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 مع جودة JPEG محددة بـ 90، دقة الصورة 300 DPI، حفظ ملفات الميتافايل كـ PNG، وضغط نص Flate.

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

### **اختيار ضغط الصور تلقائيًا**

عند احتواء عرض تقديمي على العديد من الصور الفوتوغرافية أو لقطات الشاشة، يمكن لتقليل حجم PDF المُصدّر أن يسهل إرساله بالبريد الإلكتروني أو تنزيله. استدعِ [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) مع `True` لتحديد أفضل خوارزمية ضغط لكل صورة تلقائيًا أثناء تصدير PDF.

المثال التالي يحمّل عرضًا موجودًا، يُفعّل اختيار ضغط الصور تلقائيًا، ويحفظه كمستند PDF. جميع إعدادات تصدير PDF الأخرى تحتفظ بالقيم الافتراضية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

هذا الخيار يحدد خوارزمية ضغط لكل صورة. خفض القيمة الممررة إلى [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) يقلل جودة صورة JPEG، بينما خفض القيمة الممررة إلى [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) يسمح بتقليل دقة الصور، مما قد يقلل التفاصيل. تمكين اختيار الضغط التلقائي لا يقلل من أي من هذين الإعدادين بحد ذاته.

اختيار خوارزميات ضغط الصور يتطلب وقتًا وذاكرة إضافيين للمعالجة. يعتمد انخفاض الحجم على صور العرض وإعدادات التصدير؛ لا يوجد انخفاض ثابت مضمون لكل عرض.

### **حفظ ملفات OLE المدمجة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر Excel مدمج، قد ترغب في أن يتمكن متلقي PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) مع `True` للحفاظ على ملفات OLE المدمجة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يتم عرض صورة المعاينة أو الأيقونة لكائن OLE على صفحة PDF، لكن الملف المدمج غير مُدرج كمرفق. ضبط الخيار إلى `True` يضيف بيانات الملف أيضًا. تبقى المعاينة تمثيلًا بصريًا؛ المرفق يسمح للمتلقين بفتح أو حفظ الملف المدمج بشكل منفصل. لا يصبح كائن OLE ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمّل عرضًا يحتوي على دفتر Excel مدمج مسبقًا ويصدّره إلى PDF مع إرفاق دفتر العمل.

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

1. افتح PDF المُصدّر في عارض يدعم مرفقات الملفات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد دفتر العمل المدمج.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}

معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 يحظر الملفات المدمجة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها دفاتر Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي للـ PDF ولا يُظهر تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، متضمناً أي شرائح مخفية.

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

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة بجودة عالية.

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

### **اكتشاف استبدالات الخطوط**

Aspose.Slides يوفر طريقة [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) تمكنك من اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير. استخدم وكيل JPype لتلقي ردود التحذير من واجهة Java. حوّل سلسلة الوصف من Java إلى سلسلة Python قبل فحص بادئتها:

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

### **معالجة الخطوط التي لا تملك نسخة غامقة مخصصة**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يمتلك الخط نسخة غامقة مخصصة. لا يزال النص يظهر غامقًا من خلال التسمين الاصطناعي، الذي يزيد من سمك الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) مع `True`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. قيمته الافتراضية هي `False`.

العرض التجريبي يحتوي على صندوقي نص: أحدهما نص عادي والآخر نص غامق مطبق على نفس الخط الذي لا يملك نسخة غامقة مخصصة. المثال التالي يحمّل العرض، يُفعّل تحويل الخطوط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

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

المعاينات التالية تُظهر النتيجة عندما يكون الخيار معطلًا ومفعّلاً. في هذا المثال، النص الغامق له خطوط أسمك عندما يكون الخيار معطلًا. مع تفعيل الخيار، الخطوط تصبح أرفع؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| خيار معطل (`False`, القيمة الافتراضية) | خيار مفعّل (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، تفعيل الخيار يحول النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص بدون OCR، وتظهر حدوده أكثر نعومة عند تكبير 800٪. يبقى النص العادي قابلًا للبحث. عندما يكون الخيار معطلًا، يبقى كلا السلسلتين نصًا.

هذا الخيار يحول النص المنسق كغامق إلى صورة نقطية عندما لا يملك الخط نسخة غامقة مخصصة. بدلاً من ذلك، [استبدال الخطوط](/slides/ar/python-java/font-substitution/) يختار خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

أرقام الشرائح الممررة إلى [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) تُعد 1‑based. المثال التالي يصدر الشرائح 1 و3 إذا كانتا موجودتين:

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

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

هذا المثال يصدر الشريحة الأولى على صفحة تبلغ أبعادها 612×792 نقطة (US Letter). ينسخ الشريحة إلى عرض تقديمي جديد بالحجم المحدد ويُكَبّر محتوى الشريحة لتناسب الصفحة.

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

    # إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد بها.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، مع وضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **إمكانية الوصول ومعايير الامتثال لملفات PDF**

عند إعداد ملفات PDF قابلة للولوج، استشر إرشادات [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). استخدم [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) لاختيار معيار الإخراج: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تنتج ملفات متعددة بناءً على معايير امتثال مختلفة:

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

> **ملاحظة:** عند تصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُؤشر كفنِّات؛ يتم توفير النص البديل فقط للشكل الكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، Aspose.Slides يدعم التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتحديد كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع `True` في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و[setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) في فئة [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، Aspose.Slides يتيح لك تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/)، بما فيها PDF/A1a، PDF/A1b، وPDF/UA، لتلبية احتياجات الوصول أو الأرشفة. اختر المعيار المناسب وراجع الناتج وفقًا لمتطلباتك.

## **موارد إضافية**

- [توثيق Aspose.Slides for Python via Java](/slides/ar/python-java/)
- [مرجع API لـ Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)