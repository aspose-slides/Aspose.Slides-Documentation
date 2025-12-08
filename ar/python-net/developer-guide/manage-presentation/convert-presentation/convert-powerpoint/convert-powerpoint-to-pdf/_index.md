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
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG باستخدام Aspose.Slides في Python — يشمل حماية بكلمة مرور، اختيار الشرائح، والتحكم في جودة الصور."
showReadingTime: true
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى صيغة PDF باستخدام بايثون على تحقيق عدة مزايا، بما في ذلك ضمان التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في هذه الصيغ إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF في بايثون، كل ما عليك هو تمرير اسم الملف كمعامل في فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) تعرض طريقة  [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python يكتب مباشرة معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عندما يقوم بتحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides for Python بملء حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة بصيغة '*Aspose.Slides v XX.XX*'. **ملاحظة** لا يمكنك توجيه Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

Aspose.Slides يتيح لك تحويل:

* كامل العروض إلى PDF
* شرائح محددة في العرض إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مع ضمان أن محتويات ملفات PDF الناتجة مطابقة بدقة للعروض الأصلية. يتم تحويل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقاطية
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تُنفذ باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة. يُظهر هذا الكود بايثون كيفية تحويل PowerPoint إلى PDF:

_خطوات: تحويل PowerPoint إلى PDF في بايثون_

الكود النموذجي التالي يوضح هذه التحويلات باستخدام بايثون عبر .NET
- <a name="python-net-powerpoint-to-pdf"><strong>خطوات: تحويل PowerPoint إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>خطوات: تحويل PPT إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>خطوات: تحويل PPTX إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل ODP إلى PDF باستخدام Python عبر .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>خطوات: تحويل PPS إلى PDF باستخدام Python عبر .NET</a></strong>

_خطوات الكود:_

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتزويدها بملف PowerPoint.
  * امتداد _.ppt_ لتحميل ملف **PPT** داخل فئة _Presentation_.
  * امتداد _.pptx_ لتحميل ملف **PPTX** داخل فئة _Presentation_.
  * امتداد _.odp_ لتحميل ملف **ODP** داخل فئة _Presentation_.
  * امتداد _.pps_ لتحميل ملف **PPS** داخل فئة _Presentation_.
- حفظ الـ _Presentation_ إلى صيغة **PDF** باستدعاء طريقة **Save** واستخدام تعداد **SaveFormat.PDF**.
```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```


{{%  alert  color="primary"  %}} 

Aspose يوفر محولًا مجانيًا على الإنترنت **PowerPoint إلى PDF** يوضح عملية تحويل العرض إلى PDF. لتجربة التنفيذ الحي للإجراء الموضح هنا، يمكنك إجراء اختبار باستخدام المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

Aspose.Slides يقدم خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—تسمح لك بتخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك ضبط إعداد جودة الصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط النصوص، وتعيين DPI للصور، وغيرها.

المثال البرمجي أدناه يوضح عملية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة:
```python
import aspose.slides as slides

# ينشئ كائن من فئة PdfOptions
pdf_options = slides.export.PdfOptions()

# يحدد جودة صور JPG
pdf_options.jpeg_quality = 90

# يحدد DPI للصور
pdf_options.sufficient_resolution = 300

# يحدد سلوك ملفات الميتافي
pdf_options.save_metafiles_as_png = True

# يحدد مستوى ضغط النص للمحتوى النصي
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# يحدد وضع الامتثال لـ PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# ينشئ كائن من فئة Presentation التي تمثل مستند PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # يحفظ العرض التقديمي كمستند PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية `show_hidden_slides` من فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—لإرشاد Aspose.Slides لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا الكود بايثون يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```python
import aspose.slides as slides

# ينشئ كائنًا من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ينشئ كائنًا من فئة PdfOptions
pdfOptions = slides.export.PdfOptions()

# يضيف الشرائح المخفية
pdfOptions.show_hidden_slides = True

# يحفظ العرض التقديمي كملف PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود بايثون يوضح كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)):
```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
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

Aspose.Slides يقدم خاصية `warning_callback` ضمن فئة [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) للسماح لك باكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

هذا الكود بايثون يوضح كيفية اكتشاف استبدالات الخطوط:  
```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```


{{%  alert color="primary"  %}} 

للمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة في PowerPoint إلى PDF**

هذا الكود بايثون يوضح كيفية تحويل شرائح محددة في عرض PowerPoint إلى PDF:
```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# يحدد مصفوفة مواضع الشرائح
slides_array = [ 1, 3 ]

# يحفظ العرض التقديمي كملف PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

هذا الكود بايثون يوضح كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:
```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# إنشاء كائن من فئة Presentation يمثل ملف PowerPoint أو OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # إنشاء عرض تقديمي جديد بحجم شريحة معدل.
    with slides.Presentation() as resized_presentation:

        # تعيين حجم الشريحة المخصص.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # استنساخ الشريحة الأولى من العرض الأصلي.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # حفظ العرض المعاد تحجيمه كملف PDF مع الملاحظات.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشرائح**

هذا الكود بايثون يوضح كيفية تحويل PowerPoint إلى PDF ملاحظات:
```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation يمثل ملف PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saves the presentation to PDF notes
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```


## **معايير إمكانية الوصول والامتثال للـ PDF**

Aspose.Slides يتيح لك استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

هذا الكود بايثون يوضح عملية تحويل PowerPoint إلى PDF يتم فيها الحصول على ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

دعم Aspose.Slides لعمليات تحويل PDF يمتد إلى السماح لك بتحويل PDF إلى أكثر صيغ الملفات شيوعًا. يمكنك إجراء التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—مدعومة أيضًا.

{{% /alert %}}

## **الأسئلة المتداولة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من PDF؟**

لا، Aspose.Slides for Python يدرج تلقائيًا معلومات API ورقم الإصدار في PDF الناتج. لا يمكن تعديل أو إزالة هذه المعلومات.

**كيف يمكن تضمين شرائح محددة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة `save`.

**هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة `PdfOptions` قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصور (JPG، PNG)، SVG، TIFF، وXML.

**كيف أضمن أن PDF يلتزم بمعايير إمكانية الوصول؟**

عيّن خاصية `compliance` في `PdfOptions` إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الوصول.

**هل يمكن تضمين الشرائح المخفية في ملف PDF الناتج؟**

نعم، عن طريق تعيين خاصية `show_hidden_slides` في `PdfOptions` إلى `True`، سيتم تضمين الشرائح المخفية في PDF.

**كيف يمكن تعديل جودة الصورة والدقة أثناء التحويل؟**

استخدم خاصيتي `jpeg_quality` و `sufficient_resolution` في `PdfOptions` للتحكم في جودة الصورة ودقتها في PDF الناتج.

**هل يتعامل Aspose.Slides تلقائيًا مع استبدالات الخطوط؟**

Aspose.Slides يكتشف استبدالات الخطوط أثناء التحويل، ويمكنك معالجتها باستخدام خاصية `warning_callback` في `SaveOptions` (محدودة حاليًا).

## **الموارد الإضافية**

- [توثيق Aspose.Slides for .NET](https://docs.aspose.com/slides/python-net/)
- [مرجع Aspose.Slides API](https://reference.aspose.com/slides/python-net/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)