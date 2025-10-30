---
title: تحويل عروض PowerPoint إلى HTML باستخدام Python
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML متجاوب باستخدام Python. الحفاظ على التخطيط والروابط والصور مع دليل التحويل الخاص بـ Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

هذه المقالة توضح كيفية تحويل عرض PowerPoint إلى صيغة HTML باستخدام Python. تغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML باستخدام Python
- تحويل PPT إلى HTML باستخدام Python
- تحويل PPTX إلى HTML باستخدام Python
- تحويل ODP إلى HTML باستخدام Python
- تحويل شريحة PowerPoint إلى HTML باستخدام Python

## **Python PowerPoint إلى HTML**

للحصول على عينة كود Python لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT، PPTX و ODP في كائن Presentation وحفظه إلى صيغة HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides for Python عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية التحويل من PowerPoint إلى HTML:

* تحويل العرض التقديمي كاملاً إلى HTML.
* تحويل شريحة معينة في العرض التقديمي إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب.
* تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث مدمجة أو مستبعدة.
* تحويل عرض PowerPoint إلى HTML مع التعليقات مدمجة أو مستبعدة.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد.

{{% alert color="primary" %}} 
باستخدام واجهتها البرمجية الخاصة، طورت Aspose محولات مجانية ل[تحويل العروض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).
{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

إلى جانب عمليات التحويل الموصوفة هنا، يدعم Aspose.Slides عمليات تحويل أخرى تتعلق بصيغة HTML:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}

## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لحفظ الكائن كملف HTML.

هذا الكود يوضح كيفية تحويل PowerPoint إلى HTML في Python:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# حفظ العرض التقديمي كملف HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **تحويل PowerPoint إلى HTML متجاوب**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تمكنك من إنشاء ملفات HTML متجاوبة. يعرض الكود التالي كيفية تحويل عرض PowerPoint إلى HTML متجاوب في Python:

```py
# إنشاء كائن Presentation يمثل ملف عرض تقديمي
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# حفظ العرض التقديمي كملف HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**
هذا الكود يوضح كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**
توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تمكنك من دمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج بعض الخطوط، يمكنك تمرير مصفوفة بأسماء الخطوط إلى مُنشئ فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمج إذا كانت موجودة مسبقاً في النظام، لأن دمجها قد يزيد من حجم ملف HTML الناتج بلا فائدة.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) الوراثة وتوفر طريقة `WriteFont` التي يمكن تجاوزها.

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# استبعاد خطوط العرض التقديمي الافتراضية
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **تحويل شريحة إلى HTML**
تحويل شريحة منفصلة إلى HTML. للقيام بذلك استخدم نفس طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والتي تُستَخدم لتحويل العرض PPT(X) بالكامل إلى وثيقة HTML. يمكن أيضًا استخدام فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتعيين خيارات تحويل إضافية:

```py
# [TODO[not_supported_yet]: تنفيذ بايثون للواجهة .net]
```

## **حفظ ملفات CSS والصور عند التصدير إلى HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML.

يعرض الكود Python التالي كيفية استخدام طرق قابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```py
# [TODO[not_supported_yet]: تنفيذ بايثون للواجهات .net]
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**
إذا كنت لا ترغب في دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`.

يعرض هذا الكود Python كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (نظرًا لتوفرهما في النظام):

```py
# [TODO[not_supported_yet]: تنفيذ بايثون للواجهات .net]
```

## **دعم خاصية الاستجابة للـ SVG**
يعرض المثال أدناه كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط استجابي:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **تصدير ملفات الوسائط إلى ملف HTML**
باستخدام Aspose.Slides للـ Python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. الحصول على مرجع إلى الشريحة
3. إضافة فيديو إلى الشريحة
4. كتابة العرض كملف HTML

هذا الكود Python يوضح كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:

```py
import aspose.slides as slides

# تحميل عرض تقديمي
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## الأسئلة المتكررة

### **كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام Python؟**

يمكنك استخدام مكتبة Aspose.Slides for Python عبر .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML باستخدام طريقة `save()` مع `SaveFormat.HTML`.

### **هل يدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**

نعم، يتيح Aspose.Slides تحويل العرض بالكامل أو شرائح محددة إلى HTML من خلال ضبط `HtmlOptions` بالشكل المناسب.

### **هل يمكنني توليد HTML متجاوب من عروض PowerPoint؟**

نعم، باستخدام فئة `ResponsiveHtmlController` يمكنك تصدير عرضك إلى تخطيط HTML متجاوب يتكيف مع أحجام الشاشات المختلفة.

### **هل يمكن تضمين ملاحظات المتحدث أو التعليقات في الملف HTML المُصدَّر؟**

نعم، يمكنك ضبط `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث والتعليقات عند تصدير عروض PowerPoint إلى HTML.

### **هل يمكنني دمج الخطوط عند تحويل العرض إلى HTML؟**

نعم، توفر Aspose.Slides فئة `EmbedAllFontsHtmlController` التي تسمح بدمج الخطوط أو استبعاد خطوط محددة لتقليل حجم الملف الناتج.

### **هل يدعم تحويل PowerPoint إلى HTML ملفات وسائط مثل الفيديو والصوت؟**

نعم، يتيح Aspose.Slides تصدير محتوى الوسائط المدمج في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` وغيرها من الفئات المرتبطة.

### **ما صيغ الملفات المدعومة للتحويل إلى HTML؟**

يدعم Aspose.Slides تحويل صيغ PPT و PPTX و ODP إلى HTML. كما يسمح بحفظ محتوى الشرائح كـ SVG وتصدير ملفات الوسائط.

### **هل يمكن تجنب دمج الخطوط لتقليل حجم ملف HTML؟**

نعم، يمكنك ربط الخطوط المتوفرة على النظام مثل Arial أو Calibri بدلاً من دمجها، عبر تنفيذ مخصص لـ `HtmlController`.

### **هل هناك أداة على الإنترنت لتحويل PowerPoint إلى HTML؟**

نعم، يمكنك تجربة الأدوات المجانية من Aspose مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي كود.

### **هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML المُصدَّر؟**

نعم، يتيح Aspose.Slides ربط ملفات CSS خارجية أثناء التحويل، مما يسمح لك بتخصيص مظهر محتوى HTML الناتج بالكامل.