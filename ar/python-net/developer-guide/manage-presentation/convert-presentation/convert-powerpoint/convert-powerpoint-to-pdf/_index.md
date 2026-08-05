---
title: تحويل PPT و PPTX إلى PDF في Python | خيارات متقدمة
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
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG باستخدام Python و Aspose.Slides—يتضمن حماية بكلمة مرور، اختيار الشرائح، والتحكم في جودة الصور."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى تنسيق PDF باستخدام Python يقدم العديد من الفوائد، بما في ذلك ضمان التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في هذه الصيغ إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF باستخدام Python، ما عليك سوى تمرير اسم الملف كوسيط في فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods). فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) تكشف عن طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for Python بكتابة معلومات الـ API ورقم الإصدار مباشرةً في المستندات الناتجة. على سبيل المثال، عندما يحول عرض تقديمي إلى PDF، يملأ Aspose.Slides for Python حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة بصيغة '*Aspose.Slides v XX.XX*'. **Note** لا يمكنك توجيه Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة في العرض إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مما يضمن أن محتوى ملفات PDF الناتجة يطابق تقريبًا العروض الأصلية. يتم تمثيل العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الرؤوس والتذييلات
* العلامات النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية تحويل PowerPoint إلى PDF القياسية تُنفّذ باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدَّم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة. يوضح لك هذا الكود Python كيفية تحويل PowerPoint إلى PDF:

_Steps: PowerPoint to PDF Conversions in Python_

الكود النموذجي التالي يوضح هذه التحويلات باستخدام Python عبر .NET
- <a name="python-net-powerpoint-to-pdf"><strong>خطوات: تحويل PowerPoint إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>خطوات: تحويل PPT إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>خطوات: تحويل PPTX إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل ODP إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل PPS إلى PDF باستخدام Python عبر .NET</a></strong>

_Code Steps:_

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتوفير ملف PowerPoint لها.
  * امتداد _.ppt_ لتحميل ملف **PPT** داخل الفئة _Presentation_.
  * امتداد _.pptx_ لتحميل ملف **PPTX** داخل الفئة _Presentation_.
  * امتداد _.odp_ لتحميل ملف **ODP** داخل الفئة _Presentation_.
  * امتداد _.pps_ لتحميل ملف **PPS** داخل الفئة _Presentation_.
- احفظ فئة _Presentation_ إلى تنسيق **PDF** عبر استدعاء طريقة **Save** واستخدام تعداد **SaveFormat.PDF**.

```python
import aspose.slides as slides

# ينشئ كائنًا من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# يحفظ العرض كملف PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

توفر Aspose محولًا مجانيًا عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. للحصول على تنفيذ حي للإجراء الموضح هنا، يمكنك إجراء تجربة مع المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides يوفر خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—تسمح لك بتخصيص PDF (الناتج من عملية التحويل)، أو قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF باستخدام خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تعيين إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى الضغط للنصوص، وتعيين DPI للصور، إلخ.

الكود أدناه يوضح عملية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```python
import aspose.slides as slides

# ينشئ كائنًا من فئة PdfOptions
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

# ينشئ كائنًا من فئة Presentation التي تمثل مستند PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # يحفظ العرض كملف PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا احتوى العرض على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية `show_hidden_slides` من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—لإرشاد Aspose.Slides لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا الكود Python يوضح لك كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```python
import aspose.slides as slides

# ينشئ كائنًا من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ كائنًا من فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يضيف الشرائح المخفية
pdfOptions.show_hidden_slides = True

# يحفظ العرض كملف PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود Python يوضح لك كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معايير الحماية من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يحدد كلمة مرور PDF وأذونات الوصول
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# يحفظ العرض كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تحويل الشرائح المختارة في PowerPoint إلى PDF**

هذا الكود Python يوضح لك كيفية تحويل شرائح محددة في عرض PowerPoint إلى PDF:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# يحدد مصفوفة مواضع الشرائح
slides_array = [ 1, 3 ]

# يحفظ العرض كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

هذا الكود Python يوضح لك كيفية تحويل PowerPoint عندما يكون حجم شريحته محددًا إلى PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# يخلق كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # ينشئ عرضًا جديدًا بحجم شريحة معدل.
    with slides.Presentation() as resized_presentation:

        # يعيّن حجم الشريحة المخصص.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # يستنسخ الشريحة الأولى من العرض الأصلي.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # يحفظ العرض المعاد تحجيمه إلى PDF مع الملاحظات.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

هذا الكود Python يوضح لك كيفية تحويل PowerPoint إلى ملاحظات PDF:

```python
import aspose.slides as slides

# ينشئ فئة Presentation التي تمثل ملف PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# يحفظ العرض إلى ملاحظات PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **معايير الوصول والامتثال للـ PDF**

Aspose.Slides يسمح لك باستخدام إجراء تحويل يتوافق مع [إرشادات وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود Python يوضح عملية تحويل PowerPoint إلى PDF يحصل فيها على عدة ملفات PDF تعتمد على معايير امتثال مختلفة:

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

دعم Aspose.Slides لعمليات تحويل PDF يمتد إلى السماح لك بتحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-html/)، [PDF إلى image](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-png/). عمليات تحويل PDF إلى تنسيقات متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-xml/)—مدعومة أيضًا.

{{% /alert %}}

> **Note:** عند تصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسوميات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُؤشر كعناصر صناعية؛ يتم توفير النص البديل فقط للكائن بأكمله.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من ملف PDF؟**

لا، Aspose.Slides for Python يدرج تلقائيًا معلومات الـ API ورقم الإصدار في ملف PDF الناتج. لا يمكن تعديل أو إزالة هذه المعلومات.

**كيف يمكنني تضمين شرائح معينة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة `save`.

**هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة `PdfOptions` قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصور (JPG، PNG)، SVG، TIFF، وXML.

**كيف أضمن أن PDF يلتزم بمعايير الوصول؟**

قم بتعيين خاصية `compliance` في `PdfOptions` إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان التوافق مع إرشادات الوصول.

**هل يمكنني تضمين الشرائح المخفية في ناتج PDF؟**

نعم، عن طريق تعيين خاصية `show_hidden_slides` في `PdfOptions` إلى `True` سيتم تضمين الشرائح المخفية في PDF.

**كيف أضبط جودة الصورة والدقة أثناء التحويل؟**

استخدم خاصيتي `jpeg_quality` و` sufficient_resolution` في `PdfOptions` للتحكم في جودة الصورة والدقة في PDF الناتج.

**هل يتعامل Aspose.Slides مع استبدال الخطوط تلقائيًا؟**

Aspose.Slides يكتشف استبدال الخطوط أثناء التحويل، ويمكنك التعامل معها باستخدام خاصية `warning_callback` في `SaveOptions` (محدودة حاليًا).

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](https://docs.aspose.com/slides/ar/python-net/)
- [مرجع API ل Aspose.Slides](https://reference.aspose.com/slides/ar/python-net/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/ar/conversion)