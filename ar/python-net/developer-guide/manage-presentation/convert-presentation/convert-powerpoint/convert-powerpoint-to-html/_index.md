---
title: تحويل عروض PowerPoint إلى HTML باستخدام Python
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
description: "تحويل عروض PowerPoint إلى HTML مستجيب باستخدام Python. احفظ التخطيط والروابط والصور باستخدام دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى صيغة HTML باستخدام Python. تغطي المواضيع التالية:

- تحويل PowerPoint إلى HTML باستخدام Python
- تحويل PPT إلى HTML باستخدام Python
- تحويل PPTX إلى HTML باستخدام Python
- تحويل ODP إلى HTML باستخدام Python
- تحويل شريحة PowerPoint إلى HTML باستخدام Python

## **Python PowerPoint إلى HTML**

للحصول على عينة رموز Python لتحويل PowerPoint إلى HTML، يرجى مراجعة القسم أدناه أي [Convert PowerPoint to HTML](#convert-powerpoint-to-html). يمكن للرمز تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation وحفظه بصيغة HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides for Python عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.  

توفر **Aspose.Slides** العديد من الخيارات (في الغالب من فئة [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.  
* تحويل شريحة محددة من عرض PowerPoint إلى HTML.  
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.  
* تحويل عرض PowerPoint إلى HTML مستجيب.  
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.  
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.  
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.  
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.  

{{% alert color="primary" %}} 

باستخدام واجهته الخاصة، طوّر Aspose محولات مجانية من [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html) وغيرها.  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في إلقاء نظرة على [المحولّات المجانية الأخرى من Aspose](https://products.aspose.app/slides/conversion).  

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل الموضحة هنا، تدعم Aspose.Slides عمليات التحويل التالية المتعلّقة بصيغة HTML:

* HTML إلى صورة
* HTML إلى JPG
* HTML إلى XML
* HTML إلى TIFF

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
2. استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لحفظ الكائن كملف HTML.  

يعرض هذا الرمز كيفية تحويل PowerPoint إلى HTML في Python:

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
توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) التي تسمح لك بإنشاء ملفات HTML مستجيبة. يُظهر هذا الرمز كيفية تحويل عرض PowerPoint إلى HTML مستجيب في Python:

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
يُظهر هذا الرمز كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**
توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة بأسماء الخطوط إلى مُنشئ المعاملات في فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمجها إذا كانت موجودة مسبقًا في النظام، حيث إن دمجها يجعل ملف HTML الناتج كبيرًا غير ضروري.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) الوراثة وتوفر طريقة `WriteFont` التي يُقصد إعادة تعريفها.

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **تحويل شريحة إلى HTML**
تحويل شريحة عرض منفصلة إلى HTML. للقيام بذلك، استخدم نفس طريقة **[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)** المتوفرة في فئة **[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)** التي تُستعمل لتحويل العرض الكامل إلى مستند HTML. يمكن أيضًا استخدام فئة **[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)** لتعيين خيارات التحويل الإضافية:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **حفظ CSS والصور عند التصدير إلى HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل مظهر ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML.

يعرض الكود Python أدناه كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**
إذا كنت لا ترغب في دمج الخطوط (لتجنب زيادة حجم ملف HTML الناتج)، يمكنك ربط جميع الخطوط عبر تنفيذ نسخة مخصّصة من `LinkAllFontsHtmlController`.

يُظهر هذا الكود Python كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنهما متوفران بالفعل في النظام):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **دعم خاصية استجابة SVG**
يعرض المثال التالي كيفية تصدير عرض PPT(X) إلى HTML مع تخطيط استجابة:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **تصدير ملفات الوسائط إلى ملف HTML**
باستخدام Aspose.Slides for Python، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. الحصول على مرجع إلى الشريحة.  
3. إضافة فيديو إلى الشريحة.  
4. كتابة العرض كملف HTML.  

يعرض الكود Python أدناه كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:

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

## الأسئلة المتكررة

### **كيف يمكنني تحويل عرض PowerPoint إلى HTML باستخدام Python؟**
يمكنك استخدام مكتبة Aspose.Slides for Python عبر .NET لتحميل ملفات PPT أو PPTX أو ODP وتحويلها إلى HTML عبر طريقة `save()` مع `SaveFormat.HTML`.

### **هل تدعم Aspose.Slides تحويل شرائح PowerPoint الفردية إلى HTML؟**
نعم، تسمح Aspose.Slides بتحويل كل من العرض الكامل أو شرائح معينة إلى HTML عن طريق ضبط `HtmlOptions` وفقًا لذلك.

### **هل يمكنني إنشاء HTML مستجيب من عروض PowerPoint؟**
نعم، باستخدام فئة `ResponsiveHtmlController` يمكنك تصدير العرض إلى تخطيط HTML مستجيب يتكيف مع أحجام الشاشات المختلفة.

### **هل من الممكن تضمين ملاحظات المتحدث أو التعليقات في ملف HTML المُصدّر؟**
نعم، يمكنك ضبط `HtmlOptions` لتضمين أو استبعاد ملاحظات المتحدث أو التعليقات عند تصدير عروض PowerPoint إلى HTML.

### **هل يمكنني تضمين الخطوط عند تحويل عرض إلى HTML؟**
نعم، توفر Aspose.Slides فئة `EmbedAllFontsHtmlController` التي تسمح بدمج الخطوط أو استبعاد بعض الخطوط لتقليل حجم الملف الناتج.

### **هل يدعم تحويل PowerPoint إلى HTML ملفات وسائط مثل الفيديوهات والصوت؟**
نعم، تسمح Aspose.Slides بتصدير محتوى الوسائط المدمج في الشرائح إلى HTML باستخدام `VideoPlayerHtmlController` والفئات ذات الصلة.

### **ما صيغ الملفات المدعومة للتحويل إلى HTML؟**
تدعم Aspose.Slides تحويل صيغ العروض PPT و PPTX و ODP إلى HTML. كما يمكن حفظ محتوى الشرائح كملفات SVG وتصدير الأصول الإعلامية.

### **هل يمكنني تجنب دمج الخطوط لتقليل حجم ملف HTML الناتج؟**
نعم، يمكنك ربط الخطوط المتوفرة على النظام مثل Arial أو Calibri بدلاً من دمجها، عبر تنفيذ مخصص لـ `HtmlController`.

### **هل هناك أداة عبر الإنترنت لتحويل PowerPoint إلى HTML؟**
نعم، يمكنك تجربة أدوات Aspose المجانية على الويب مثل [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html) أو [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html) لتحويل العروض مباشرة في المتصفح دون كتابة أي شفرة.

### **هل يمكنني استخدام أنماط CSS مخصصة في ملف HTML المُصدّر؟**
نعم، تتيح Aspose.Slides ربط ملفات CSS خارجية أثناء التحويل، مما يسمح لك بتخصيص مظهر المحتوى HTML الناتج بالكامل.