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
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG في Python باستخدام Aspose.Slides — يتضمن حماية كلمة المرور، اختيار الشرائح، والتحكم في جودة الصورة."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP) إلى تنسيق PDF في Python يقدم عدة مزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير التوافق على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بهذه الصيغ إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF في Python، عليك فقط تمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ثم حفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). تُظهر فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python يُدرج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويله عرض تقديمي إلى PDF، يملأ Aspose.Slides for Python حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة بصيغة '*Aspose.Slides v XX.XX*'. **Note** أنه لا يمكنك إرشاد Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح لك Aspose.Slides بالتحويل:

* كل العروض إلى PDF
* شرائح محددة في عرض تقديمي إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن محتويات ملفات PDF الناتجة تتطابق عن كثب مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الارتباطات التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF خيارات افتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يقوم بتحميل عرض وت حفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية على الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. لتطبيق عملي للإجراء الموصوف هنا، يمكنك إجراء اختبار باستخدام الأداة.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF (الناتج من عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتحديد مستوى الضغط للنص، وتعيين DPI للصور، إلخ.

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

### **اختيار ضغط الصورة تلقائيًا**

عند احتواء عرض على العديد من الصور أو لقطات الشاشة، قد يجعل تقليل حجم PDF المُصدَّر من الأسهل إرساله بالبريد أو تنزيله. اضبط [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) إلى `True` لاختيار الخوارزمية الأنسب لضغط كل صورة تلقائيًا أثناء تصدير PDF.

المثال التالي يحمل عرضًا موجودًا، يُفعِّل اختيار ضغط الصورة التلقائي، ويحفظه كوثيقة PDF. جميع إعدادات تصدير PDF الأخرى تحتفظ بالقيم الافتراضية.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

هذا الخيار يحدد خوارزمية ضغط لكل صورة. خفض [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) يقلل من جودة صورة JPEG، بينما خفض [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) يسمح بتقليل دقة الصور إلى دقة أقل، ما قد يقلل التفاصيل. تمكين اختيار الضغط التلقائي لا يقلل من أي من هذه الإعدادات بحد ذاته.

اختيار خوارزميات ضغط الصور يتطلب وقت معالجة إضافي وذاكرة. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يُضمن تقليل ثابت لكل عرض.

### **الحفاظ على ملفات OLE المضمَّنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر Excel مضمّن، قد ترغب في أن يتمكن متلقي PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. اضبط [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) إلى `True` للحفاظ على ملفات OLE المضمَّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يتم عرض صورة المعاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمّن لا يُضمَّن كمرفق. ضبط الخيار إلى `True` يضيف بيانات الملف كذلك. تظل المعاينة تمثيلًا بصريًا؛ يسمح المرفق للمستلمين بفتح أو حفظ الملف المضمّن منفصلًا. كائن OLE لا يتحول إلى ورقة عمل Excel تفاعلية على صفحة PDF.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

للتحقق من النتيجة:

1. افتح PDF المُصدَّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد موقع دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 يحظر الملفات المضمَّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك دفاتر Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد التوافق الافتراضي ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) من فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—لإرشاد Aspose.Slides لتضمين الشرائح المخفية كصفحات في PDF الناتج.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يُصدِّر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **معالجة الخطوط التي لا تمتلك نوعًا غامقًا مخصصًا**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. لا يزال النص يظهر غامقًا عبر الغامق الاصطناعي، الذي يزيد سمك الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب ضبط [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) إلى `True`. هذا الخيار يُظهر النص المتأثر كصورة نقطية أثناء تصدير PDF وقد يُحسّن مظهره لبعض الخطوط. قيمته الافتراضية هي `False`.

العرض النموذجي يحتوي على مربعين نصيين: أحدهما بنص عادي والآخر بنص غامق مطبق على نفس الخط الذي لا يمتلك نوعًا غامقًا مخصصًا. المثال التالي يحمل العرض، يُفعل تحويل النص الغامق غير المدعوم إلى صورة نقطية، ويصدِّره إلى PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

المعاينات التالية تُظهر النتيجة مع الخيار معطَّل ومعه مفعَّل. في هذا المثال، يمتلك النص الغامق خطوطًا سميكة عندما يكون الخيار معطَّل. مع تفعيل الخيار، تصبح خطوطه أضعف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد للعرض الخاص بك.

| الخيار معطل (`False`، الافتراضي) | الخيار مفعل (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، تفعيل الخيار يحول النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند تكبير 800٪. يظل النص العادي قابلًا للبحث. مع تعطيل الخيار، يبقى كلا السطرين نصًا.

هذا الخيار يحوّل النص المنسق كغامق عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. [استبدال الخطوط](/slides/ar/python-net/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

المثال التالي يُصدِّر الشرائح 1 و3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ما لا يقل عن ثلاث شرائح.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُعيد تحجيم محتوى الشريحة ليناسب الحجم ويصدِّر الشريحة الوحيدة إلى PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد بها.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يُصدِّر عرضًا إلى PDF، مع وضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **معايير الوصول والامتثال للـ PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يطابق [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود Python يُظهر عملية تحويل PowerPoint إلى PDF يحصل فيها على عدة ملفات PDF مبنية على معايير امتثال مختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF إلى أكثر صيغ الملفات شيوعًا. يمكنك إجراء [PDF إلى HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) تحويلات. كما تُدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—أيضًا.
{{% /alert %}}

> **Note:** عند التصدير إلى PDF/UA، يعتبر Aspose.Slides الرسومات المعقدة مثل SmartArt والمخططات والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم وضع علامة عليها كعناصر غير ضرورية؛ يتم توفير النص البديل فقط للكائن الكامل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من PDF؟**

لا، Aspose.Slides for Python يدرج تلقائيًا معلومات API ورقم الإصدار في PDF الناتج. لا يمكن تعديل أو إزالة هذه المعلومات.

**كيف يمكنني تضمين شرائح محددة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) .

**هل من الممكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، يدعم Aspose.Slides تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصور (JPG، PNG)، SVG، TIFF، وXML.

**كيف أضمن أن PDF الخاص بي يطابق معايير الوصول؟**

اضبط خاصية [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) في [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الوصول.

**هل يمكنني تضمين الشرائح المخفية في مخرجات PDF؟**

نعم، بضبط خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) في [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى `True`، سيتم تضمين الشرائح المخفية في PDF.

**كيف أضبط جودة الصورة ودقتها أثناء التحويل؟**

استخدم خاصيتي [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) و[sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) في [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) للتحكم في جودة الصورة ودقتها في PDF الناتج.

**هل يتعامل Aspose.Slides مع استبدال الخطوط تلقائيًا؟**

Aspose.Slides يكتشف استبدال الخطوط أثناء التحويل، ويمكنك معالجته باستخدام خاصية `warning_callback` في `SaveOptions` (محدود حاليًا).

## **موارد إضافية**

- [Aspose.Slides for Python via .NET Documentation](/slides/ar/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)