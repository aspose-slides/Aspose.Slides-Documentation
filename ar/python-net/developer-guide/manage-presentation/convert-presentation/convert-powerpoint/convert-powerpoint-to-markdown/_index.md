---
title: تحويل PowerPoint إلى Markdown في بايثون
type: docs
weight: 140
url: /ar/python-net/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض, Markdown, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "تحويل PowerPoint إلى Markdown في بايثون"
---

{{% alert color="info" %}} 

تمت إضافة دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، ستحتاج إلى تعيين `saveOptions.export_type = MarkdownExportType.VISUAL` كما يجب تعيين `base_path` حيث سيتم حفظ الصور المشار إليها في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتمثيل كائن العرض.
2. استخدم [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) لحفظ الكائن كملف Markdown.

يوضح لك هذا الكود بلغة بايثون كيفية تحويل PowerPoint إلى Markdown: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## تحويل PowerPoint إلى نكهة Markdown

تتيح لك Aspose.Slides تحويل PowerPoint إلى Markdown (الذي يحتوي على بناء جملة أساسي)، CommonMark، Markdown المعتمد على GitHub، Trello، XWiki، GitLab، و 17 نكهة Markdown أخرى.

يوضح لك هذا الكود بلغة بايثون كيفية تحويل PowerPoint إلى CommonMark: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

توجد 23 نكهة Markdown مدعومة [مُدرجة تحت تعداد Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل العرض الذي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة للملف Markdown الناتج. يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)، على سبيل المثال، إلى قيم تحدد كيفية عرض الصور أو التعامل معها: `Sequential`, `TextOnly`, `Visual`.

### **تحويل الصور بالتسلسل**

إذا كنت ترغب في ظهور الصور بشكل فردي واحدة تلو الأخرى في Markdown الناتج، يجب عليك اختيار الخيار التسلسلي. يوضح لك هذا الكود بلغة بايثون كيفية تحويل عرض يحتوي على صور إلى Markdown: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **تحويل الصور بصريًا**

إذا كنت ترغب في ظهور الصور معًا في Markdown الناتج، يجب عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند Markdown)، أو يمكنك تحديد المسار المفضل واسم المجلد.

يوضح لك هذا الكود بلغة بايثون العملية: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```