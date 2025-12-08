---
title: تحويل عروض PowerPoint إلى HTML باستخدام Python
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
description: "تحويل عروض PowerPoint إلى HTML استجابي باستخدام Python. حافظ على التخطيط والروابط والصور مع دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام Python. وتغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML في بايثون
- تحويل PPT إلى HTML في بايثون
- تحويل PPTX إلى HTML في بايثون
- تحويل ODP إلى HTML في بايثون
- تحويل شريحة PowerPoint إلى HTML في بايثون

## **PowerPoint إلى HTML باستخدام Python**

للحصول على عينة كود Python لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدة صيغ مثل PPT و PPTX و ODP في كائن Presentation وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**

باستخدام [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

باستخدام [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** توفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (صور، فيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML استجابي.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.

{{% alert color="primary" %}} 

باستخدام API الخاص بها، قامت Aspose بتطوير محولات مجانية [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، وغيرها.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل الموضحة هنا، تدعم Aspose.Slides أيضًا عمليات التحويل التالية التي تتضمن تنسيق HTML:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لحفظ الكائن كملف HTML.

يعرض هذا الكود كيفية تحويل PowerPoint إلى HTML باستخدام python:
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


## **تحويل PowerPoint إلى HTML استجابي**

Aspose.Slides توفر الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تسمح لك بإنشاء ملفات HTML استجابية. يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى HTML استجابي باستخدام python:
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

يعرض هذا الكود كيفية تحويل PowerPoint إلى HTML مع الملاحظات باستخدام python:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

Aspose.Slides توفر الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تسمح لك بدمج جميع الخطوط في عرض تقديمي أثناء تحويله إلى HTML.

لمنع دمج بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ معلمات من الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). الخطوط الشائعة مثل Calibri أو Arial، عند استخدامها في عرض تقديمي، لا تحتاج إلى دمجها لأن معظم الأنظمة تحتوي عليها بالفعل. عندما يتم دمج هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) تدعم الوراثة وتوفر طريقة `WriteFont`، والتي من المفترض أن تُعاد تعريفها.
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

تحويل شريحة عرض تقديمي منفصلة إلى HTML. للقيام بذلك استخدم نفس طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تُستخدم لتحويل عرض PPT(X) كامل إلى مستند HTML. يمكن أيضًا استخدام فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتعيين خيارات التحويل الإضافية:
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهة .net]
```


## **حفظ CSS والصور عند التصدير إلى HTML**

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML.

يعرض كود python في هذا المثال كيفية استخدام الطرق القابلة لإعادة التعريف لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .net]
```


## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا ترغب في دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط من خلال تنفيذ نسخة خاصة بك من `LinkAllFontsHtmlController`.

يعرض هذا الكود python كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنهما موجودان بالفعل في النظام):
```py
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .net]
```


## **دعم خاصية SVG الاستجابية**

يعرض عينة الكود أدناه كيفية تصدير عرض PPT(X) إلى HTML مع التخطيط الاستجابي:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **تصدير ملفات الوسائط إلى ملف HTML**

باستخدام Aspose.Slides للـ python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع للشرائح.
3. إضافة فيديو إلى الشريحة.
4. كتابة العرض كملف HTML.

يعرض هذا الكود python كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:
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


## **الأسئلة المتكررة**

**كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام Python؟**

يمكنك استخدام مكتبة Aspose.Slides for Python via .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML باستخدام طريقة `save()` مع `SaveFormat.HTML`.

**هل تدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**

نعم، يسمح Aspose.Slides بتحويل العرض بالكامل أو شرائح محددة إلى HTML عن طريق ضبط `HtmlOptions` وفقًا لذلك.

**هل يمكنني إنشاء HTML استجابي من عروض PowerPoint؟**

نعم، باستخدام فئة `ResponsiveHtmlController`، يمكنك تصدير عرضك إلى تخطيط HTML استجابي يتكيف مع أحجام الشاشات المختلفة.

**هل يمكن تضمين ملاحظات المتحدث أو التعليقات في HTML المُصدَّر؟**

نعم، يمكنك ضبط `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث والتعليقات عند تصدير عروض PowerPoint إلى HTML.

**هل يمكنني دمج الخطوط عند تحويل عرض تقديمي إلى HTML؟**

نعم، يوفر Aspose.Slides الفئة `EmbedAllFontsHtmlController` التي تسمح بدمج الخطوط أو استبعاد بعض الخطوط لتقليل حجم الملف الناتج.

**هل يدعم تحويل PowerPoint إلى HTML ملفات الوسائط مثل الفيديوهات والصوت؟**

نعم، يسمح Aspose.Slides بتصدير محتوى الوسائط المضمن في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` والفئات المرتبطة.

**ما صيغ الملفات المدعومة للتحويل إلى HTML؟**

يدعم Aspose.Slides تحويل صيغ العروض PPT و PPTX و ODP إلى HTML. كما يتيح حفظ محتوى الشرائح كـ SVG وتصدير موارد الوسائط.

**هل يمكنني تجنب دمج الخطوط لتقليل حجم HTML الناتج؟**

نعم، يمكنك ربط الخطوط المتوفرة في النظام مثل Arial أو Calibri بدلاً من دمجها، باستخدام تنفيذ مخصص لـ `HtmlController`.

**هل توجد أداة عبر الإنترنت لتحويل PowerPoint إلى HTML؟**

نعم، يمكنك تجربة الأدوات المجانية عبر الويب من Aspose مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي كود.

**هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML المُصدَّر؟**

نعم، يسمح Aspose.Slides بالربط بملفات CSS خارجية أثناء التحويل، مما يتيح لك تخصيص مظهر محتوى HTML الناتج بالكامل.
