---
title: تحويل PPT و PPTX إلى PDF في Python | خيارات متقدمة
linktitle: PowerPoint إلى PDF
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
- Aspose.Slides for Python
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG باستخدام Aspose.Slides في Python — يتضمن حماية بكلمة مرور، اختيار الشرائح، والتحكم بجودة الصورة."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى صيغة PDF في Python يقدم عدة مزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF في Python، ما عليك سوى تمرير اسم الملف كمعامل إلى الفئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods). تُظهر الفئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) طريقة [Save](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/#methods) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

Aspose.Slides for Python يكتب مباشرة معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides for Python حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة بصيغة '*Aspose.Slides v XX.XX*'. **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة في العرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مع ضمان تطابق محتويات ملفات PDF الناتجة بشكل وثيق مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

يتم تنفيذ عملية تحويل PowerPoint إلى PDF القياسية باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة. يوضح لك هذا الكود Python كيفية تحويل PowerPoint إلى PDF:

_الخطوات: تحويل PowerPoint إلى PDF في Python_

الكود النموذجي التالي يوضح هذه التحويلات باستخدام Python عبر .NET
- <a name="python-net-powerpoint-to-pdf"><strong>الخطوات: تحويل PowerPoint إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>الخطوات: تحويل PPT إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>الخطوات: تحويل PPTX إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>الخطوات: تحويل ODP إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>الخطوات: تحويل PPS إلى PDF باستخدام Python عبر .NET</a></strong>

_خطوات الكود:_

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتزويده بملف PowerPoint.
  * امتداد _.ppt_ لتحميل ملف **PPT** داخل فئة _Presentation_.
  * امتداد _.pptx_ لتحميل ملف **PPTX** داخل فئة _Presentation_.
  * امتداد _.odp_ لتحميل ملف **ODP** داخل فئة _Presentation_.
  * امتداد _.pps_ لتحميل ملف **PPS** داخل فئة _Presentation_.
- حفظ الـ _Presentation_ إلى صيغة **PDF** باستدعاء طريقة **Save** واستخدام تعداد **SaveFormat.PDF**.

```python
import aspose.slides as slides

# ينشئ فئة Presentation التي تمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

يوفر Aspose أداة مجانية عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. لتجربة تنفيذية حية للإجراءات الموضحة هنا، يمكنك اختبار المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF (الناتج من عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تعيين إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط النصوص، وتحديد DPI للصور، وغيرها.

يوضح المثال البرمجي أدناه عملية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:

```python
import aspose.slides as slides

# ينشئ فئة PdfOptions
pdf_options = slides.export.PdfOptions()

# يحدد جودة صور JPG
pdf_options.jpeg_quality = 90

# يحدد DPI للصور
pdf_options.sufficient_resolution = 300

# يحدد سلوك ملفات الميتا
pdf_options.save_metafiles_as_png = True

# يحدد مستوى ضغط النص للمحتوى النصي
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# يحدد وضع امتثال PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# ينشئ فئة Presentation التي تمثل مستند PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # يحفظ العرض التقديمي كملف PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية `show_hidden_slides` من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)—لإرشاد Aspose.Slides لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يوضح هذا الكود Python كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```python
import aspose.slides as slides

# ينشئ فئة Presentation التي تمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يضيف الشرائح المخفية
pdfOptions.show_hidden_slides = True

# يحفظ العرض التقديمي كملف PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح هذا الكود Python كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# ينشئ كائن Presentation الذي يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يحدد كلمة مرور PDF وأذونات الوصول
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **اكتشاف استبدالات الخطوط**

توفر Aspose.Slides خاصية `warning_callback` ضمن فئة [SaveOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveoptions/) لتسمح لك باكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يوضح هذا الكود Python كيفية اكتشاف استبدالات الخطوط:

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](https://docs.aspose.com/slides/ar/python-net/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة في PowerPoint إلى PDF**

يوضح هذا الكود Python كيفية تحويل شرائح معينة في عرض PowerPoint إلى PDF:

```python
import aspose.slides as slides

# ينشئ كائن Presentation الذي يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# يحدد مصفوفة مواضع الشرائح
slides_array = [ 1, 3 ]

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يوضح هذا الكود Python كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # إنشاء عرض تقديمي جديد بحجم شريحة معدل.
    with slides.Presentation() as resized_presentation:

        # تعيين حجم الشريحة المخصص.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # نسخ الشريحة الأولى من العرض التقديمي الأصلي.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # حفظ العرض التقديمي بالحجم المعدل كملف PDF مع الملاحظات.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يوضح هذا الكود Python كيفية تحويل PowerPoint إلى PDF يحتوي على ملاحظات:

```python
import aspose.slides as slides

# ينشئ فئة Presentation التي تمثل ملف PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# يحفظ العرض التقديمي إلى ملاحظات PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **معايير الوصول والامتثال لـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يظهر هذا الكود Python عملية تحويل PowerPoint إلى PDF ينتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

يمتد دعم Aspose.Slides لعمليات تحويل PDF إلى السماح لك بتحويل PDF إلى أكثر صيغ الملفات شيوعًا. يمكنك القيام بتحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/python-net/conversion/pdf-to-xml/)—.

{{% /alert %}}

> **ملاحظة:** عند تصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسوميات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا تُحافظ عناصر المسار الفردية كمتن منفصل وقد تُعلم كعناصر صناعية؛ يتم توفير النص البديل فقط للشكل بأكمله.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من PDF؟**

لا، يضيف Aspose.Slides for Python تلقائيًا معلومات API ورقم الإصدار إلى PDF الناتج. لا يمكن تعديل هذه المعلومات أو إزالتها.

**كيف يمكنني تضمين شرائح معينة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة `save`.

**هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتعريف أذونات الوصول باستخدام فئة `PdfOptions` قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، وصيغ الصور (JPG، PNG)، وSVG، وTIFF، وXML.

**كيف يمكنني التأكد من أن PDF يلتزم بمعايير الوصول؟**

قم بتعيين خاصية `compliance` في `PdfOptions` إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الوصول.

**هل يمكن تضمين الشرائح المخفية في ناتج PDF؟**

نعم، بتعيين خاصية `show_hidden_slides` في `PdfOptions` إلى `True` سيتم تضمين الشرائح المخفية في PDF.

**كيف أضبط جودة الصورة والدقة أثناء التحويل؟**

استخدم خاصيتي `jpeg_quality` و `sufficient_resolution` في `PdfOptions` للتحكم في جودة الصورة والدقة في PDF الناتج.

**هل يتعامل Aspose.Slides تلقائيًا مع استبدالات الخطوط؟**

يكشف Aspose.Slides عن استبدالات الخطوط أثناء التحويل، ويمكنك معالجتها باستخدام خاصية `warning_callback` في `SaveOptions` (محدودية حالية).

## **موارد إضافية**

- [توثيق Aspose.Slides for .NET](https://docs.aspose.com/slides/ar/python-net/)
- [مرجع API لـ Aspose.Slides](https://reference.aspose.com/slides/ar/python-net/)
- [المحولين المجانيين عبر الإنترنت من Aspose](https://products.aspose.app/slides/ar/conversion)