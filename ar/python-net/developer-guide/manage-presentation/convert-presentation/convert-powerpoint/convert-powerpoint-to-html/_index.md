---
title: تحويل PowerPoint إلى HTML باستخدام Python
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint إلى HTML, تحويل عرض PowerPoint, PPTX, PPT, PPT إلى HTML, PPTX إلى HTML, PowerPoint إلى HTML, حفظ PowerPoint كـ HTML, حفظ PPT كـ HTML, حفظ PPTX كـ HTML, Python, Aspose.Slides, تصدير HTML"
description: "تحويل PowerPoint إلى HTML: حفظ PPTX أو PPT كـ HTML. حفظ الشرائح كـ HTML"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام Python. وتشمل المواضيع التالية.

- تحويل PowerPoint إلى HTML في Python
- تحويل PPT إلى HTML في Python
- تحويل PPTX إلى HTML في Python
- تحويل ODP إلى HTML في Python
- تحويل شريحة PowerPoint إلى HTML في Python

## **Python PowerPoint إلى HTML**

للحصول على رمز Python مثال لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من التنسيقات مثل PPT و PPTX و ODP في كائن العرض وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides لـ Python عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** توفر العديد من الخيارات (غالبًا من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل الوسائط في العرض (صور، مقاطع فيديو، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث مشمولة أو مستثناة. 
* تحويل عرض PowerPoint إلى HTML مع التعليقات مشمولة أو مستثناة. 
* تحويل عرض PowerPoint إلى HTML مع خطوط أصلية أو مدمجة. 
* تحويل عرض PowerPoint إلى HTML أثناء استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام واجهته البرمجية، طورت Aspose محولات مجانية [تحويل العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في التحقق من محولات أخرى [المجانية من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب عمليات التحويل الموصوفة هنا، تدعم Aspose.Slides أيضًا هذه العمليات التحويلية التي تتعلق بتنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لحفظ الكائن كملف HTML.

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML في Python:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# حفظ العرض كـ HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **تحويل PowerPoint إلى HTML متجاوب**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تتيح لك إنشاء ملفات HTML متجاوبة. هذا الكود يوضح لك كيفية تحويل عرض PowerPoint إلى HTML متجاوب في Python:

```py
# إنشاء كائن Presentation يمثل ملف عرض
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# حفظ العرض كـ HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**
هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**
توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تتيح لك تضمين جميع الخطوط في عرض عند تحويل العرض إلى HTML.

لمنع تضمين بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ مُعَلم. الخطوط الشعبية، مثل Calibri أو Arial، عند استخدامها في عرض، لا تحتاج إلى تضمينها لأن معظم الأنظمة تحتوي بالفعل على مثل هذه الخطوط. عندما يتم تضمين هذه الخطوط، يصبح مستند HTML الناتج ضخمًا بشكل غير ضروري.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) الوراثة وتوفر طريقة `WriteFont`، التي من المقرر أن تُكتب فوقها.

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# استبعاد الخطوط الافتراضية للعرض
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **تحويل الشريحة إلى HTML**
تحويل شريحة عرض منفصلة إلى HTML. لذلك استخدم نفس طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تستخدم لتحويل العرض الكامل PPT(X) إلى مستند HTML. يمكن أيضًا استخدام فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتعيين خيارات تحويل إضافية:

```py
# [TODO[not_supported_yet]: تنفيذ python لواجهة .net]
```

## **حفظ CSS والصور عند التصدير إلى HTML**
باستخدام ملفات أنماط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML.

يعرض الكود في هذا المثال كيفية استخدام الطرق القابلة للاستبدال لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .net]
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**
إذا كنت لا ترغب في تضمين الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط عن طريق تنفيذ نسختك الخاصة من `LinkAllFontsHtmlController`.

هذا الكود python يوضح لك كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنها موجودة بالفعل في النظام):

```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .net]
```

## **دعم خاصية SVG المتجاوبة**
يظهر نموذج الكود أدناه كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط متجاوب:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **تصدير ملفات الوسائط إلى ملف HTML**
باستخدام Aspose.Slides لـ Python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

هذا الكود python يوضح لك كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:

```py
import aspose.slides as slides

# تحميل عرض
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