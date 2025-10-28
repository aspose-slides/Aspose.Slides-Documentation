---
title: تحويل عروض PowerPoint إلى HTML في Python
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML مستجيب في Python. احفظ التخطيط والروابط والصور باستخدام دليل التحويل الخاص بـ Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام Python. تغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML في Python
- تحويل PPT إلى HTML في Python
- تحويل PPTX إلى HTML في Python
- تحويل ODP إلى HTML في Python
- تحويل شريحة PowerPoint إلى HTML في Python

## **PowerPoint للـ Python إلى HTML**

للحصول على مثال كود Python لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation وحفظه بصيغة HTML.

## **حول تحويل PowerPoint إلى HTML**

باستخدام [**Aspose.Slides للـ Python عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) ) التي تحدد عملية تحويل PowerPoint إلى HTML:

- تحويل عرض PowerPoint كامل إلى HTML.
- تحويل شريحة معينة في عرض PowerPoint إلى HTML.
- تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
- تحويل عرض PowerPoint إلى HTML مستجيب.
- تحويل عرض PowerPoint إلى HTML مع تضمين ملاحظات المتحدث أو استبعادها.
- تحويل عرض PowerPoint إلى HTML مع تضمين التعليقات أو استبعادها.
- تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المضمنة.
- تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد.

{{% alert color="primary" %}} 

باستخدام واجهتها البرمجية الخاصة، طوّرت Aspose محولات مجانية من [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html), إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل الموضحة هنا، يدعم Aspose.Slides عمليات التحويل التالية المتعلقة بتنسيق HTML:

- [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
- [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
- [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
- [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. استخدم طريقة [حفظ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لحفظ الكائن كملف HTML.

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **تحويل PowerPoint إلى HTML مستجيب**

توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تتيح لك إنشاء ملفات HTML مستجيبة. يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى HTML مستجيب باستخدام python:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
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

توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج بعض الخطوط، يمكنك تمرير مصفوفة بأسماء الخطوط إلى البنية المُعلمة لفئة [EmbedAllFontsHtmlController]. الخطوط الشائعة مثل Calibri أو Arial، عند استخدامها في عرض، لا يلزم دمجها لأن معظم الأنظمة تحتوي بالفعل على هذه الخطوط. عندما تُدمج هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

فئة [EmbedAllFontsHtmlController] تدعم الوراثة وتوفر طريقة `WriteFont` التي يُقصد أن يتم تجاوزها. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **تحويل الشريحة إلى HTML**

قم بتحويل شريحة عرض منفصلة إلى HTML. للقيام بذلك استخدم نفس طريقة [**حفظ**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي توفرها فئة [Presentation] المستخدمة لتحويل العرض الكامل PPT(X) إلى مستند HTML. يمكن أيضًا استخدام فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتحديد خيارات التحويل الإضافية:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **حفظ CSS والصور عند التصدير إلى HTML**

باستخدام ملفات أنماط CSS الجديدة، يمكنك بسهولة تعديل نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML.

يعرض الكود python في هذا المثال كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص مع ارتباط إلى ملف CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا تريد دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`.

يعرض هذا الكود python كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و "Arial" (لأنهما موجودان بالفعل في النظام):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **دعم خاصية استجابة SVG**

يعرض المثال البرمجي أدناه كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط استجابة:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **تصدير ملفات الوسائط إلى ملف HTML**

باستخدام Aspose.Slides للـ python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation].
2. الحصول على مرجع إلى الشريحة.
3. إضافة فيديو إلى الشريحة.
4. كتابة العرض كملف HTML.

يعرض هذا الكود python كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:

```py
import aspose.slides as slides

# Loading a presentation
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

### **كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام Python؟**

يمكنك استخدام مكتبة Aspose.Slides للـ Python عبر .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML باستخدام طريقة `save()` مع `SaveFormat.HTML`.

### **هل يدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**

نعم، يتيح Aspose.Slides تحويل العرض بالكامل أو شرائح محددة إلى HTML من خلال تكوين `HtmlOptions` وفقًا لذلك.

### **هل يمكنني إنشاء HTML مستجيب من عروض PowerPoint؟**

نعم، باستخدام فئة `ResponsiveHtmlController` يمكنك تصدير عرضك إلى تخطيط HTML مستجيب يتكيف مع أحجام الشاشات المختلفة.

### **هل يمكن تضمين ملاحظات المتحدث أو التعليقات في HTML المُصدَّر؟**

نعم، يمكنك تكوين `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث والتعليقات عند تصدير عروض PowerPoint إلى HTML.

### **هل يمكنني دمج الخطوط عند تحويل عرض إلى HTML؟**

نعم، يوفر Aspose.Slides فئة `EmbedAllFontsHtmlController` التي تسمح بدمج الخطوط أو استثناء بعضها لتقليل حجم ملف الإخراج.

### **هل يدعم تحويل PowerPoint إلى HTML ملفات الوسائط مثل الفيديو والصوت؟**

نعم، يتيح Aspose.Slides تصدير محتوى الوسائط المدمج في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` وفئات التكوين ذات الصلة.

### **ما صيغ الملفات المدعومة للتحويل إلى HTML؟**

يدعم Aspose.Slides تحويل صيغ العروض PPT و PPTX و ODP إلى HTML. كما يتيح حفظ محتوى الشريحة كـ SVG وتصدير ملفات الوسائط.

### **هل يمكنني تجنب دمج الخطوط لتقليل حجم HTML الناتج؟**

نعم، يمكنك ربط الخطوط المتوفرة عادةً في النظام مثل Arial أو Calibri بدلاً من دمجها، باستخدام تنفيذ مخصص لـ `HtmlController`.

### **هل هناك أداة عبر الإنترنت لتحويل PowerPoint إلى HTML؟**

نعم، يمكنك تجربة أدوات الويب المجانية من Aspose مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي كود.

### **هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML المُصدَّر؟**

نعم، يتيح Aspose.Slides ربط ملفات CSS خارجية أثناء التحويل، مما يمكنك من تخصيص مظهر محتوى HTML الناتج بالكامل.