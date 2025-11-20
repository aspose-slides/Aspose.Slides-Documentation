---
title: تحويل عروض PowerPoint إلى HTML في بايثون
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML متجاوب في بايثون. الحفاظ على التخطيط والروابط والصور مع دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من العيوب."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى صيغة HTML باستخدام بايثون. تغطي الموضوعات التالية.

- تحويل PowerPoint إلى HTML في بايثون
- تحويل PPT إلى HTML في بايثون
- تحويل PPTX إلى HTML في بايثون
- تحويل ODP إلى HTML في بايثون
- تحويل شريحة PowerPoint إلى HTML في بايثون

## **Python PowerPoint إلى HTML**

للحصول على عينة كود بايثون لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه، أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation وحفظه بصيغة HTML.

## **حول تحويل PowerPoint إلى HTML**

باستخدام [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** توفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML استجابة.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المضمَّنة.
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد.

{{% alert color="primary" %}} 

باستخدام API الخاص به، طورت Aspose محولات مجانية من [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

إلى جانب عمليات التحويل الموضحة هنا، يدعم Aspose.Slides أيضًا عمليات التحويل التالية المتعلقة بصيغة HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
1. استخدام طريقة [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)لحفظ الكائن كملف HTML.

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML في بايثون:
```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# حفظ العرض التقديمي إلى HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **تحويل PowerPoint إلى HTML استجابة**

توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تسمح لك بإنشاء ملفات HTML استجابة. هذا الكود يوضح لك كيفية تحويل عرض PowerPoint إلى HTML استجابة في بايثون:
```py
# إنشاء كائن Presentation يمثل ملف عرض تقديمي
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# حفظ العرض التقديمي إلى HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **تحويل PowerPoint إلى HTML مع الملاحظات**

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML مع الملاحظات في بايثون:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تسمح لك بضم جميع الخطوط في عرض أثناء تحويله إلى HTML.

لمنع تضمين بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنَشِئ مُعامل من الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). الخطوط الشائعة مثل Calibri أو Arial، عندما تُستخدم في عرض، لا تحتاج إلى تضمينها لأن معظم الأنظمة تحتوي بالفعل على هذه الخطوط. عندما يتم تضمين هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) تدعم الوراثة وتوفر طريقة `WriteFont` التي من المفترض أن تُستبدل. 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# استبعاد خطوط العرض التقديمية الافتراضية
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **تحويل الشريحة إلى HTML**

تحويل شريحة عرض منفصلة إلى HTML. لذلك استخدم نفس طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تُستخدم لتحويل العرض PPT(X) كامل إلى مستند HTML. يمكن أيضًا استخدام الفئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتعيين خيارات التحويل الإضافية:
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهة .net]
```



## **حفظ CSS والصور عند التصدير إلى HTML**

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML. 

الكود بايثون في هذا المثال يوضح لك كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .net]
```


## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا ترغب في تضمين الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`. 

هذا الكود بايثون يوضح لك كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنهما موجودان بالفعل على النظام): 
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .net]
```


## **دعم خاصية الاستجابة في SVG**

عينة الكود أدناه توضح كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط استجابة:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```



## **تصدير ملفات الوسائط إلى ملف HTML**

باستخدام Aspose.Slides للبايثون، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
1. الحصول على مرجع إلى الشريحة. 
1. إضافة فيديو إلى الشريحة. 
1. كتابة العرض كملف HTML. 

هذا الكود بايثون يوضح لك كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:
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

### **كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام بايثون؟**

يمكنك استخدام مكتبة Aspose.Slides للبايثون عبر .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML باستخدام طريقة `save()` مع `SaveFormat.HTML`.

### **هل تدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**

نعم، تتيح Aspose.Slides تحويل العرض بالكامل أو شرائح محددة إلى HTML من خلال تكوين `HtmlOptions` وفقًا لذلك.

### **هل يمكنني توليد HTML استجابة من عروض PowerPoint؟**

نعم، باستخدام فئة `ResponsiveHtmlController` يمكنك تصدير عرضك إلى تخطيط HTML استجابة يتكيف مع أحجام الشاشات المختلفة.

### **هل يمكن تضمين ملاحظات المتحدث أو التعليقات في ملف HTML المصدر؟**

نعم، يمكنك تكوين `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث والتعليقات عند تصدير عروض PowerPoint إلى HTML.

### **هل يمكنني تضمين الخطوط عند تحويل العرض إلى HTML؟**

نعم، توفر Aspose.Slides فئة `EmbedAllFontsHtmlController` التي تسمح لك بضم الخطوط أو استبعاد خطوط معينة لتقليل حجم الملف الناتج.

### **هل يدعم تحويل PowerPoint إلى HTML ملفات وسائط مثل الفيديوهات والصوت؟**

نعم، تسمح Aspose.Slides بتصدير محتوى الوسائط المدمج في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` وفئات التكوين ذات الصلة.

### **ما صيغ الملفات التي تدعمها التحويل إلى HTML؟**

تدعم Aspose.Slides تحويل صيغ العروض PPT و PPTX و ODP إلى HTML. كما تسمح بحفظ محتوى الشرائح كـ SVG وتصدير الأصول الإعلامية.

### **هل يمكنني تجنب تضمين الخطوط لتقليل حجم ملف HTML؟**

نعم، يمكنك ربط الخطوط المتاحة على النظام مثل Arial أو Calibri بدلاً من تضمينها، عبر تنفيذ مخصص لـ `HtmlController`.

### **هل هناك أداة على الإنترنت لتحويل PowerPoint إلى HTML؟**

نعم، يمكنك تجربة الأدوات المجانية على الويب من Aspose مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي كود.

### **هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML المصدر؟**

نعم، تسمح Aspose.Slides بربط ملفات CSS الخارجية أثناء التحويل، مما يتيح لك تخصيص مظهر محتوى HTML الناتج بالكامل.