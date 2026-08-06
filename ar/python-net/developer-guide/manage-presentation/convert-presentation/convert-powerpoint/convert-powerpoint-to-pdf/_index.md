---
title: تحويل PPT & PPTX إلى PDF في Python | خيارات متقدمة
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
- Python
- Aspose.Slides for Python
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG باستخدام Python و Aspose.Slides — يتضمن حماية بكلمة مرور، اختيار الشرائح، والتحكم في جودة الصورة."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى صيغة PDF باستخدام Python يوفر عدة مزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **التثبيت**

```bash
pip install aspose.slides
```

الحزمة تتضمن بيئة التشغيل التي تحتاجها، لذا لا يلزم تثبيت Microsoft PowerPoint على الجهاز الذي يجري التحويل.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في هذه الصيغ إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF في Python، ما عليك سوى تمرير اسم الملف كمعامل إلى فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods). فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) توفر طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يكتب Aspose.Slides for Python معلومات API ورقم الإصدار مباشرةً في مستندات الإخراج. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides for Python حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة من الشكل '*Aspose.Slides v XX.XX*'. **ملاحظة** أنه لا يمكن توجيه Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من مستندات الإخراج.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة في العرض إلى PDF

يصدر Aspose.Slides عروضًا إلى PDF، مع ضمان تطابق محتويات ملفات PDF الناتجة مع العروض الأصلية. تُرسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تُنفَّذ عملية تحويل PowerPoint إلى PDF القياسية باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة. يُظهر هذا الكود Python كيفية تحويل PowerPoint إلى PDF:

_خطوات: تحويل PowerPoint إلى PDF في Python_

الكود النموذجي التالي يوضح هذه التحويلات باستخدام Python عبر .NET
- <a name="python-net-powerpoint-to-pdf"><strong>خطوات: تحويل PowerPoint إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>خطوات: تحويل PPT إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>خطوات: تحويل PPTX إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل ODP إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل PPS إلى PDF باستخدام Python عبر .NET</a></strong>

_خطوات الكود:_

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتزويده بملف PowerPoint.
  * امتداد _.ppt_ لتحميل ملف **PPT** داخل فئة _Presentation_.
  * امتداد _.pptx_ لتحميل ملف **PPTX** داخل فئة _Presentation_.
  * امتداد _.odp_ لتحميل ملف **ODP** داخل فئة _Presentation_.
  * امتداد _.pps_ لتحميل ملف **PPS** داخل فئة _Presentation_.
- حفظ الـ _Presentation_ بصيغة **PDF** عن طريق استدعاء طريقة **Save** واستخدام تعداد **SaveFormat.PDF**.

```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

توفر Aspose محولًا مجانيًا على الإنترنت لـ **PowerPoint إلى PDF** يوضح عملية التحويل من العرض إلى PDF. لتجربة تنفيذ حي للإجراء الموضح هنا، يمكنك إجراء اختبار باستخدام المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF (الناتج من عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد جودة مفضل للصور النقطية، تحديد كيفية معالجة ملفات الميتافايل، ضبط مستوى ضغط النصوص، تعيين DPI للصور، وغيرها.

يُظهر المثال البرمجي أدناه عملية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```python
import aspose.slides as slides

# ينشئ كائن من فئة PdfOptions
pdf_options = slides.export.PdfOptions()

# يضبط جودة صور JPG
pdf_options.jpeg_quality = 90

# يضبط DPI للصور
pdf_options.sufficient_resolution = 300

# يضبط سلوك ملفات الميتا
pdf_options.save_metafiles_as_png = True

# يضبط مستوى ضغط النص للمحتوى النصي
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# يعرف وضع الامتثال لـ PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# ينشئ كائن من فئة Presentation الذي يمثل مستند PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # يحفظ العرض التقديمي كملف PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية `show_hidden_slides` من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—لإخبار Aspose.Slides بضم الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود Python كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ كائن من فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يضيف الشرائح المخفية
pdfOptions.show_hidden_slides = True

# يحفظ العرض التقديمي كملف PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يعرض هذا الكود Python كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يضبط كلمة مرور PDF وأذونات الوصول
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

يعرض هذا الكود Python كيفية تحويل شرائح محددة في عرض PowerPoint إلى PDF:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# يحدد مصفوفة مواضع الشرائح
slides_array = [ 1, 3 ]

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يعرض هذا الكود Python كيفية تحويل PowerPoint عندما يكون حجم شريحته محددًا إلى PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# ينشئ كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # ينشئ عرضًا تقديميًا جديدًا بحجم شريحة معدل.
    with slides.Presentation() as resized_presentation:

        # يحدد حجم الشريحة المخصص.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # يستنسخ الشريحة الأولى من العرض الأصلي ويحذف الشريحة الفارغة الافتراضية.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # يحفظ العرض التقديمي المعاد تحجيمه كملف PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يعرض هذا الكود Python كيفية تحويل PowerPoint إلى ملاحظات PDF:

```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# يضبط خيارات PDF مع تخطيط الملاحظات
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# يحفظ العرض التقديمي كملف PDF يحتوي على الملاحظات
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **إمكانية الوصول ومعايير الامتثال لـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات إتاحة محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يُظهر هذا الكود Python عملية تحويل PowerPoint إلى PDF يحصل فيها على عدة PDF بناءً على معايير امتثال مختلفة:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF لتتيح لك تحويل PDF إلى أشهر صيغ الملفات. يمكنك إجراء التحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-png/). تدعم عمليات التحويل المتخصصة أيضًا [PDF إلى SVG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-xml/).

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسوميات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُصنف كعناصر فنية؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة المتكررة**

### هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من ملف PDF؟

لا، يضيف Aspose.Slides for Python معلومات API ورقم الإصدار تلقائيًا إلى ملف PDF الناتج. لا يمكن تعديل هذه المعلومات أو إزالتها.

### كيف يمكنني تضمين شرائح محددة فقط في تحويل PDF؟

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواقع الشرائح إلى طريقة `save`.

### هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة `PdfOptions` قبل حفظ العرض كملف PDF.

### هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصور (JPG، PNG)، SVG، TIFF، وXML.

### كيف يمكنني التأكد من أن PDF يتوافق مع معايير الوصول؟

حدد خاصية `compliance` في `PdfOptions` إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الإتاحة.

### هل يمكنني تضمين الشرائح المخفية في النتيجة PDF؟

نعم، عن طريق ضبط خاصية `show_hidden_slides` في `PdfOptions` إلى `True`، سيتم تضمين الشرائح المخفية في PDF.

### كيف أضبط جودة الصورة والدقة أثناء التحويل؟

استخدم خاصيتي `jpeg_quality` و `sufficient_resolution` في `PdfOptions` للتحكم في جودة الصورة والدقة في PDF الناتج.

### هل يتعامل Aspose.Slides مع استبدال الخطوط تلقائيًا؟

يقوم Aspose.Slides باكتشاف استبدال الخطوط أثناء التحويل، ويمكنك التعامل معها باستخدام خاصية `warning_callback` في `SaveOptions` (محدودة حاليًا).

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](https://docs.aspose.com/slides/ar/python-net/)
- [مرجع API لـ Aspose.Slides](https://reference.aspose.com/slides/ar/python-net/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)