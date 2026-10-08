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
description: "دليل خطوة بخطوة لتحويل PPT و PPTX و ODP إلى ملفات PDF عالية الجودة ومتوافقة مع WCAG في Python باستخدام Aspose.Slides — يتضمن حماية بكلمة مرور، اختيار الشرائح، والتحكم في جودة الصور."
showReadingTime: true
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT و PPTX و ODP) إلى تنسيق PDF في Python يقدم عدة مزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF في Python، عليك ببساطة تمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ثم حفظ العرض بتنسيق PDF باستخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). تُظهر فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python يضيف معلومات API وإصدارها إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides for Python حقل Application بالقيمة '*Aspose.Slides*' وحقل PDF Producer بقيمة على شكل '*Aspose.Slides v XX.XX*'. **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides for Python لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:
* العروض الكاملة إلى PDF
* شرائح محددة في العرض إلى PDF

Aspose.Slides تصدر العروض إلى PDF، مما يضمن أن محتويات ملفات PDF الناتجة تتطابق بشكل وثيق مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:
* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط
* رؤوس وتذييلات
* قوائم نقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضاً ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose يقدم محولًا مجانيًا على الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. لتجربة التطبيق العملي للإجراء الموصوف هنا، يمكنك تجربة المحول.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

Aspose.Slides يوفر خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—تسمح لك بتخصيص ملف PDF (الناتج من عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تعيين إعداد جودة الصور النقطية المفضلة، تحديد كيفية معالجة ملفات الميتا، تعيين مستوى ضغط النص، تعيين DPI للصور، إلخ.

المثال التالي يصدر عرضًا إلى PDF 1.5 مع ضبط جودة JPEG إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا بصيغة PNG، وضغط نص Flate.

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

### **الحفاظ على ملفات OLE المضمَّنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمَّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. اضبط [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) إلى `True` للحفاظ على ملفات OLE المضمَّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `False`: يُظهر صورة معاينة أو أيقونة كائن OLE على صفحة PDF، لكن الملف المضمَّن لا يُدرج كمرفق. تعيين الخيار إلى `True` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ المرفق يسمح للمستلمين بفتح أو حفظ الملف المضمَّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على دفتر عمل Excel مضمَّن ويصدره إلى PDF مع إرفاق دفتر العمل.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

للتحقق من النتيجة:
1. افتح PDF المُصدَّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد دفتر العمل المضمَّن.
3. احفظ المرفق وافتحه في Excel لفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 تحظر الملفات المضمَّنة، PDF/A-2 تسمح بمرفقات PDF/A فقط، وPDF/A-3 تسمح بأنواع ملفات أخرى بما فيها دفاتر Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) من فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—لإخبار Aspose.Slides بتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF مع تضمين أي شرائح مخفية.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة بجودة عالية.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **معالجة الخطوط دون نوع خط عريض مخصص**

يمكن للعرض تطبيق تنسيق عريض للنص حتى عندما لا يحتوي الخط على نوع عريض مخصص. لا يزال النص يظهر عريضًا عبر **synthetic bolding**، الذي يُثخّن الحروف العادية اصطناعيًا. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب ضبط [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) إلى `True`. هذا الخيار يُظهر النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. قيمته الافتراضية هي `False`.

العرض النموذجي يحتوي على صندوقي نص: أحدهما بنص عادي والآخر بنص عريض يُطبق على نفس الخط الذي لا يمتلك نوعًا عريضًا مخصصًا. المثال التالي يحمل العرض، يُفعّل تحويل الأنماط غير المدعومة إلى صورة نقطية، ويصدّره إلى PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

المعاينات التالية تُظهر النتيجة عند إيقاف وتمكين الخيار. في هذا المثال، النص العريض يملك خطوطًا أكثر سمكًا عندما يكون الخيار معطَّلًا. عند تمكينه، تصبح الخطوط أخف؛ النص العادي يظل بدون تغيير. قارن النتائج قبل اختيار الإعداد المناسب لعروضك.

| الخيار معطل (`False`، الافتراضي) | الخيار مفعّل (`True`) |
|---|---|
| ![PDF مع إلغاء تمثيل نمط الخط غير المدعوم](unsupported-bold-disabled.png) | ![PDF مع تمثيل نمط الخط غير المدعوم مفعل](unsupported-bold-enabled.png) |

في هذا المثال، تمكين الخيار يحول النص العريض فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حدوده أكثر نعومة عند تكبير 800٪. يبقى النص العادي قابلًا للبحث. عندما يكون الخيار معطلًا، يبقى كلا النصين كنص.

هذا الخيار يحول النص المنسق كعريض عندما لا يحتوي الخط على نوع عريض مخصص. [استبدال الخط](/slides/ar/python-net/font-substitution/) بدلاً من ذلك يختار خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل شرائح محددة في PowerPoint إلى PDF**

المثال التالي يصدر الشريحتين 1 و 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بتكبير محتوى الشريحة ليناسب الحجم ويصدّر الشريحة الوحيدة إلى PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # إزالة الشريحة الفارغة التي تم إنشاؤها مع العرض التقديمي الجديد.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، حيث يتم وضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **معايير الوصول والامتثال للـ PDF**

Aspose.Slides يسمح لك باستخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

الكود Python التالي يوضح عملية تحويل PowerPoint إلى PDF ينتج فيها عدة ملفات PDF بناءً على معايير امتثال مختلفة:

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
دعم Aspose.Slides لعمليات تحويل PDF يتيح لك تحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك القيام بـ [PDF إلى HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) للتحويلات. تدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم الحفاظ على العناصر الفردية كمسارات منفصلة وقد تُصنَّف كعناصر فنية؛ يُقدَّم النص البديل فقط للشكل الكامل.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides for Python إزالة معلومات التطبيق من PDF؟**

لا، Aspose.Slides for Python يضيف تلقائيًا معلومات API ورقم الإصدار إلى PDF الناتج. لا يمكن تعديل هذه المعلومات أو إزالتها.

**كيف يمكنني تضمين شرائح معينة فقط في تحويل PDF؟**

يمكنك تحديد مؤشرات الشرائح التي تريد تحويلها بتمرير مصفوفة من مواضع الشرائح إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**هل يمكن حماية PDF بكلمة مرور أثناء التحويل؟**

نعم، يمكنك تعيين كلمة مرور وتحديد أذونات الوصول باستخدام فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) قبل حفظ العرض كملف PDF.

**هل يدعم Aspose.Slides تحويل PDF إلى صيغ أخرى؟**

نعم، Aspose.Slides يدعم تحويل ملفات PDF إلى صيغ مثل HTML، صيغ الصور (JPG, PNG)، SVG، TIFF، وXML.

**كيف يمكنني التأكد من أن PDF يتوافق مع معايير الوصول؟**

اضبط خاصية [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى معايير مثل `PDF_A1A`، `PDF_A1B`، أو `PDF_UA` لضمان الامتثال لإرشادات الوصول.

**هل يمكنني تضمين الشرائح المخفية في ملف PDF الناتج؟**

نعم، عن طريق ضبط خاصية [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) إلى `True`، ستُضمّن الشرائح المخفية في PDF.

**كيف أضبط جودة ودقة الصور أثناء التحويل؟**

استخدم خاصيتي [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) و[sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) للتحكم في جودة ودقة الصور في PDF الناتج.

**هل يتعامل Aspose.Slides مع استبدال الخطوط تلقائيًا؟**

Aspose.Slides يكتشف استبدال الخطوط أثناء التحويل، ويمكنك معالجتها باستخدام خاصية `warning_callback` في `SaveOptions` (محدود حاليًا).

## **موارد إضافية**

- [Aspose.Slides for Python عبر .NET Documentation](/slides/ar/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose محولات مجانية على الإنترنت](https://products.aspose.app/slides/conversion)