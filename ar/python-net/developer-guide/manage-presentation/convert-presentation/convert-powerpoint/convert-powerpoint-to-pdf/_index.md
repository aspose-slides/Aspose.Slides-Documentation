---
title: تحويل PowerPoint إلى PDF باستخدام Python
linktitle: تحويل PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/python-net/convert-powerpoint-to-pdf/
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
- Aspose.Slides لـ Python
description: "تحويل العروض التقديمية PowerPoint إلى PDF باستخدام Python. حفظ PowerPoint كـ PDF مع الامتثال للمعايير أو معايير الوصول."
---

## **نظرة عامة**

يوفر تحويل مستندات PowerPoint إلى تنسيق PDF العديد من المزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وعرض العرض التقديمي الخاص بك. توضح هذه المقالة كيفية تحويل العروض التقديمية إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار الشرائح من أجل التحويل، وتطبيق معايير الامتثال على مستندات الخرج.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بتنسيقات مختلفة إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF باستخدام Python، عليك ببساطة تمرير اسم الملف كوسيط في [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) ثم حفظ العرض التقديمي كملف PDF باستخدام طريقة [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). تكشف فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) عن طريقة [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

Aspose.Slides لـ Python تكتب مباشرة معلومات API ورقم الإصدار في مستندات الإخراج. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تملأ Aspose.Slides لـ Python حقل التطبيق بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة في صيغة '*Aspose.Slides v XX.XX*'. **ملاحظة** أنه لا يمكنك إخبار Aspose.Slides لـ Python بتغيير أو إزالة هذه المعلومات من مستندات الإخراج.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* عرض تقديمي كامل إلى PDF
* شرائح محددة في عرض تقديمي إلى PDF
* عرض تقديمي 

تصدّر Aspose.Slides العروض التقديمية إلى PDF بطريقة تجعل محتويات ملفات PDF الناتجة مشابهة جدًا لتلك الموجودة في العروض التقديمية الأصلية. غالبًا ما يتم تقديم هذه العناصر والسمات المعروفة بشكل صحيح في تحويلات العرض التقديمي إلى PDF:

* الصور
* صناديق النص وأشكال أخرى
* النصوص وتنسيقها
* الفقرات وتنسيقها
* الروابط التشعبية
* الرأس والتذييل
* التعداد النقطي
* الجداول

## **تحويل PowerPoint إلى PDF**

يتم تنفيذ عملية تحويل PDF القياسية PowerPoint باستخدام الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام إعدادات مثلى عند أقصى مستويات الجودة. يوضح كود Python التالي كيفية تحويل PowerPoint إلى PDF:

_الخطوات: تحويل PowerPoint إلى PDF باستخدام Python_

يشرح كود العينة التالي هذه التحويلات باستخدام Python عبر .NET
- <a name="python-net-powerpoint-to-pdf"><strong>خطوات: تحويل PowerPoint إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>خطوات: تحويل PPT إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>خطوات: تحويل PPTX إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل ODP إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل PPS إلى PDF باستخدام Python عبر .NET</a></strong>

_خطوات الكود:_

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتزويدها بملف PowerPoint.
  * _.ppt_ امتداد لفتح ملف **PPT** داخل فئة _Presentation_.
  * _.pptx_ امتداد لفتح ملف **PPTX** داخل فئة _Presentation_.
  * _.odp_ امتداد لفتح ملف **ODP** داخل فئة _Presentation_.
  * _.pps_ امتداد لفتح ملف **PPS** داخل فئة _Presentation_.
- حفظ _Presentation_ إلى تنسيق **PDF** عن طريق استدعاء طريقة **Save** واستخدام تعداد **SaveFormat.PDF**.
  

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.ppt")

# Saves the presentation as a PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

توفر Aspose محول [**PowerPoint إلى PDF مجاني عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض التقديمي إلى PDF. من أجل تنفيذ مباشر للإجراء الموصوف هنا، يمكنك إجراء اختبار مع المحول.

{{% /alert %}}

## تحويل PowerPoint إلى PDF مع خيارات

توفر Aspose.Slides خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص الPDF (الناتج من عملية التحويل)، وتشفير الPDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك ضبط إعداد الجودة المفضل لديك لصور النقاط النقطية، وتحديد كيفية التعامل مع ملفات الميتا، وضبط مستوى الضغط للنصوص، وضبط DPI للصور، إلخ.

توضح مثال الكود أدناه عملية حيث يتم تحويل عرض تقديمي PowerPoint إلى PDF مع عدة خيارات مخصصة:

```python
import aspose.slides as slides

# Instantiates the PdfOptions class
pdf_options = slides.export.PdfOptions()

# Sets the quality for JPG images
pdf_options.jpeg_quality = 90

# Sets DPI for images
pdf_options.sufficient_resolution = 300

# Sets the behavior for metafiles
pdf_options.save_metafiles_as_png = True

# Sets the text compression level for textual content
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Defines the PDF compliance mode
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instantiates the Presentation class that represents a PowerPoint document
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Saves the presentation as a PDF document
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض التقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية `show_hidden_slides` من فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—لإخبار Aspose.Slides بإدراج الشرائح المخفية كصفحات في ملف PDF الناتج.

يوضح كود Python هذا كيفية تحويل عرض تقديمي PowerPoint إلى PDF مع إدراج الشرائح المخفية:

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiates the the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Adds hidden slides
pdfOptions.show_hidden_slides = True

# Saves the presentation as a PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح كود Python هذا كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) ):

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiates the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Sets PDF password and access permissions
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Saves the presentation as a PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **كشف استبدالات الخطوط**

تقدم Aspose.Slides خاصية `warning_callback` تحت فئة [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) للسماح لك بكشف استبدالات الخطوط في عملية تحويل العرض التقديمي إلى PDF.

يوضح كود Python هذا كيفية الكشف عن استبدالات الخطوط:  

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

للحصول على مزيد من المعلومات حول استبدال الخط، انظر مقالة [استبدال الخط](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

يوضح كود Python هذا كيفية تحويل شرائح محددة في عرض تقديمي PowerPoint إلى PDF:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Sets an array of slides positions
slides_array = [ 1, 3 ]

# Saves the presentation as a PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يوضح كود Python هذا كيفية تحويل PowerPoint عندما يكون حجم شريحته محددًا إلى PDF:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Sets the slide type and size 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يوضح كود Python هذا كيفية تحويل PowerPoint إلى PDF بالملاحظات:

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saves the presentation to PDF notes
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **معايير الوصول والامتثال للPDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من هذه المعايير: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح كود Python هذا عملية تحويل PowerPoint إلى PDF حيث يتم الحصول على عدة ملفات PDF تستند إلى معايير امتثال مختلفة:

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

{{% alert title="ملاحظة" color="warning" %}} 

دعم Aspose.Slides لعمليات تحويل PDF يمتد إلى السماح لك بتحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و [PDF إلى PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى تنسيقات متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و [PDF إلى XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/).

{{% /alert %}}