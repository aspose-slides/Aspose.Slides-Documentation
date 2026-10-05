---
title: تحويل PPT & PPTX إلى PDF باستخدام Python | خيارات متقدمة
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
- حفظ PowerPoint كملف PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides للـ Python
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG باستخدام Aspose.Slides في Python — يتضمن حماية بكلمة مرور، اختيار الشرائح، والتحكم في جودة الصورة."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى صيغة PDF باستخدام Python يقدم عدة مزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق عرضك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية المستندات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بهذه الصيغ إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF باستخدام Python، عليك فقط تمرير اسم الملف كمعامل إلى فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) تعرض طريقة [حفظ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
يقوم Aspose.Slides for Python بإدراج معلومات API وإصدار البرنامج في المستندات الناتجة. على سبيل المثال، عندما يقوم بتحويل عرض إلى PDF، يملأ حقل التطبيق بالقيمة '*Aspose.Slides*' وحقل منتج PDF بقيمة بصيغة '*Aspose.Slides v XX.XX*'. **ملاحظة** أنك لا تستطيع توجيه Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يسمح لك بالتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة في عرض إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مما يضمن أن محتويات ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم عرض العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* صور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* نقاط القوائم
* جداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية تحويل PowerPoint إلى PDF القياسية الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يقوم بتحميل عرض وي保存 جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة تحويل مجانية عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. لتطبيق عملي للإجراء الموضح هنا، يمكنك إجراء اختبار باستخدام الأداة.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF (الناتج من عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك ضبط إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتعيين DPI للصور، وغيرها.

المثال التالي يصدر عرضًا إلى PDF 1.5 مع ضبط جودة JPEG إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط النص بنظام Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. اضبط [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) على `True` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يتم عرض صورة معاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمّن لا يُضمّن كمرفق. ضبط الخيار على `True` يضيف بيانات الملف أيضًا. يظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. كائن OLE لا يتحول إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدره إلى PDF مع إرفاق المصنف.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

للتحقق من النتيجة:
1. افتح ملف PDF المُصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد موقع المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي للـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) من فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—لإخبار Aspose.Slides بتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، بما في ذلك أي شرائح مخفية.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

المثال التالي يصدر الشريحتين 1 و3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بقرص محتوى الشريحة ليناسب الحجم ويصدر الشريحة الوحيدة إلى PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد معها.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في طريقة عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، ويضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **معايير الوصول والامتثال لملفات PDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود Python عملية تحويل PowerPoint إلى PDF يحصل فيها على ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

{{% alert color="info" title="Note" %}}
يدعم Aspose.Slides عمليات تحويل PDF مما يتيح لك تحويل PDF إلى أكثر صيغ الملفات شيوعًا. يمكنك القيام بتحويلات [PDF إلى HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—مُدَعمة أيضًا.
{{% /alert %}}

> **ملاحظة:** عند تصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُ ozna as artifacts; يتم توفير النص البديل فقط للكيان الكامل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من PDF؟**

لا، يضيف Aspose.Slides for Python تلقائيًا معلومات API ورقم الإصدار إلى PDF الناتج. لا يمكن تعديل هذه المعلومات أو إزالتها.

**كيف يمكنني تضمين شرائح محددة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي ترغب في تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة [حفظ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصورة (JPG، PNG)، SVG، TIFF، وXML.

**كيف يمكنني التأكد من أن PDF الخاص بي يتوافق مع معايير الوصول؟**

اضبط خاصية [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الوصول.

**هل يمكن تضمين الشرائح المخفية في مخرجات PDF؟**

نعم، عن طريق ضبط خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى `True`، ستُضمّن الشرائح المخفية في PDF.

**كيف يمكنني تعديل جودة الصورة ودقتها أثناء التحويل؟**

استخدم خصائص [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) و [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) للتحكم في جودة الصورة ودقتها في PDF الناتج.

**هل يتعامل Aspose.Slides مع استبدال الخطوط تلقائيًا؟**

يكشف Aspose.Slides عن استبدال الخطوط أثناء التحويل، ويمكنك معالجتها باستخدام خاصية `warning_callback` في `SaveOptions` (محدودة حاليًا).

## **موارد إضافية**

- [توثيق Aspose.Slides for Python عبر .NET](/slides/ar/python-net/)
- [مرجع Aspose.Slides API](https://reference.aspose.com/slides/python-net/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)