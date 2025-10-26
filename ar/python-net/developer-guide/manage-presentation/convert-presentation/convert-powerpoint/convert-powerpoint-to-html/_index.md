---
title: تحويل عروض PowerPoint إلى HTML باستخدام Python
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
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
description: "تحويل عروض PowerPoint إلى HTML متجاوب باستخدام Python. الحفاظ على التخطيط والروابط والصور مع دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

يوضح هذا المقال كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام Python. يغطي المواضيع التالية:

- تحويل PowerPoint إلى HTML باستخدام Python
- تحويل PPT إلى HTML باستخدام Python
- تحويل PPTX إلى HTML باستخدام Python
- تحويل ODP إلى HTML باستخدام Python
- تحويل شريحة PowerPoint إلى HTML باستخدام Python

## **PowerPoint إلى HTML في Python**

للحصول على مثال كود Python لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [Convert PowerPoint to HTML](#convert-powerpoint-to-html). يستطيع الكود تحميل عدد من الصيغ مثل PPT وPPTX وODP في كائن Presentation وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides for Python عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية التحويل من PowerPoint إلى HTML:

* تحويل العرض التقديمي بالكامل إلى HTML.
* تحويل شريحة محددة في العرض التقديمي إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب.
* تحويل عرض PowerPoint إلى HTML متضمنًا أو مستثنيًا ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML متضمنًا أو مستثنيًا التعليقات.
* تحويل عرض PowerPoint إلى HTML باستخدام الخطوط الأصلية أو المضمنة.
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد.

{{% alert color="primary" %}} 

باستخدام واجهتها البرمجية الخاصة، طورت Aspose محولات مجانية من [العرض التقديمي إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html) وغيرها. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بالإضافة إلى عمليات التحويل المذكورة هنا، يدعم Aspose.Slides عمليات تحويل أخرى تتعلق بتنسيق HTML:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Convert PowerPoint to HTML**
باستخدام Aspose.Slides، يمكنك تحويل العرض التقديمي بالكامل إلى HTML بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
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

## **Convert PowerPoint to Responsive HTML**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تسمح بإنشاء ملفات HTML متجاوبة. يوضح الكود التالي كيفية تحويل عرض PowerPoint إلى HTML متجاوب في Python:

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

## **Convert PowerPoint to HTML with Notes**
هذا الكود يوضح كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convert PowerPoint to HTML with Original Fonts**
توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تسمح بدمج جميع الخطوط في العرض التقديمي أثناء تحويله إلى HTML.

لتجنب دمج خطوط معينة، يمكنك تمرير مصفوفة بأسماء الخطوط إلى المُنشئ المعامل من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمج لأنها موجودة مسبقًا في معظم الأنظمة. عندما تُدمج هذه الخطوط، يصبح مستند HTML الناتج كبيرًا غير ضروري.

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

## **Convert Slide to HTML**
تحويل شريحة عرض منفصلة إلى HTML. لهذا استخدم نفس طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تُستَخدم لتحويل العرض الكامل PPT(X) إلى مستند HTML. يمكن أيضًا استخدام فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتعيين خيارات التحويل الإضافية:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Save CSS and Images When Exporting To HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل نمط ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML.

الكود Python في هذا المثال يوضح كيفية استخدام طرق يمكن تجاوزها لإنشاء وثيقة HTML مخصصة مع رابط إلى ملف CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Link All Fonts When Converting Presentation to HTML**
إذا كنت لا ترغب في دمج الخطوط (لتقليل حجم ملف HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`.

هذا الكود Python يوضح كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و"Arial" (لأنهما موجودان بالفعل في النظام):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Support of SVG Responsive Property**
يوضح عينة الكود أدناه كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط استجابي:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Export Media Files to HTML file**
باستخدام Aspose.Slides للـ Python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة.
3. إضافة فيديو إلى الشريحة.
4. كتابة العرض التقديمي كملف HTML.

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

## Frequently Asked Questions

### **كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام Python؟**

يمكنك استخدام مكتبة Aspose.Slides للـ Python عبر .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML عبر طريقة `save()` مع `SaveFormat.HTML`.

### **هل يدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**

نعم، يتيح Aspose.Slides تحويل العرض بالكامل أو شرائح محددة إلى HTML عن طريق ضبط `HtmlOptions` بالشكل المناسب.

### **هل يمكنني إنشاء HTML متجاوب من عروض PowerPoint؟**

نعم، باستخدام فئة `ResponsiveHtmlController` يمكنك تصدير عرضك إلى تخطيط HTML متجاوب يتكيف مع مختلف أحجام الشاشات.

### **هل يمكن تضمين ملاحظات المتحدث أو التعليقات في ملف HTML المُصدَّر؟**

نعم، يمكنك ضبط `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث والتعليقات عند تصدير عروض PowerPoint إلى HTML.

### **هل يمكنني دمج الخطوط عند تحويل العرض إلى HTML؟**

نعم، توفر Aspose.Slides فئة `EmbedAllFontsHtmlController` التي تسمح بدمج الخطوط أو استبعاد خطوط معينة لتقليل حجم الملف الناتج.

### **هل يدعم تحويل PowerPoint إلى HTML ملفات وسائط مثل الفيديوهات والصوت؟**

نعم، يسمح Aspose.Slides بتصدير محتوى الوسائط المدمج في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` وفئات التهيئة المرتبطة.

### **ما صيغ الملفات التي يدعمها التحويل إلى HTML؟**

يدعم Aspose.Slides تحويل صيغ PPT وPPTX وODP إلى HTML. كما يتيح حفظ محتوى الشرائح كـ SVG وتصدير ملفات الوسائط.

### **هل يمكنني تجنب دمج الخطوط لتقليل حجم ملف HTML؟**

نعم، يمكنك ربط الخطوط المتوفرة في النظام مثل Arial أو Calibri بدلاً من دمجها، عبر تنفيذ نسخة مخصصة من `HtmlController`.

### **هل هناك أداة على الإنترنت لتحويل PowerPoint إلى HTML؟**

نعم، يمكنك تجربة أدوات Aspose المجانية عبر الإنترنت مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي كود.

### **هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML الناتج؟**

نعم، يتيح Aspose.Slides ربط ملفات CSS خارجية أثناء التحويل، مما يسمح لك بتخصيص مظهر المحتوى HTML بالكامل.