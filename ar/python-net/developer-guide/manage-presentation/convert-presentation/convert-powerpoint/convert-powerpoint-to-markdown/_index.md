---
title: تحويل عروض PowerPoint التقديمية إلى ماركداون باستخدام بايثون
linktitle: PowerPoint إلى ماركداون
type: docs
weight: 140
url: /ar/python-net/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint إلى ماركداون
- تحويل OpenDocument إلى ماركداون
- تحويل العرض التقديمي إلى ماركداون
- تحويل الشريحة إلى ماركداون
- تحويل PPT إلى ماركداون
- تحويل PPTX إلى ماركداون
- تحويل ODP إلى ماركداون
- تحويل PowerPoint إلى MD
- تحويل OpenDocument إلى MD
- تحويل العرض التقديمي إلى MD
- تحويل الشريحة إلى MD
- تحويل PPT إلى MD
- تحويل PPTX إلى MD
- تحويل ODP إلى MD
- PowerPoint
- OpenDocument
- العرض التقديمي
- ماركداون
- بايثون
- Aspose.Slides
description: "تحويل شرائح PowerPoint وOpenDocument—PPT، PPTX، ODP—إلى ماركداون نظيف باستخدام Aspose.Slides لبايثون عبر .NET، أتمتة التوثيق والحفاظ على التنسيق."
---

## **تحويل العروض التقديمية إلى ماركداون**

يوضح المثال أدناه أبسط طريقة لتحويل عرض PowerPoint إلى ماركداون باستخدام Aspose.Slides for Python عبر .NET بالإعدادات الافتراضية.

1. قم بإنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحميل العرض التقديمي.
1. استدعِ الدالة `save` لتصديره كملف ماركداون.

استخدم مقتطف Python أدناه لإجراء التحويل:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **تحويل العروض التقديمية إلى نكهة ماركداون**

تتيح لك Aspose.Slides تحويل العروض التقديمية إلى صيغ ماركداون، بما في ذلك ماركداون الأساسي، CommonMark، ماركداون بنكهة GitHub، Trello، XWiki، GitLab، و17 نكهة أخرى من ماركداون.

يوضح المثال التالي بلغة Python كيفية تحويل عرض PowerPoint إلى CommonMark:
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


يتم سرد الـ23 نكهة ماركداون المدعومة في تعداد [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) لفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل العروض التقديمية التي تحتوي على صور إلى ماركداون**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تتيح لك تكوين ملف الماركداون الناتج. على سبيل المثال، يتحكم تعداد [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) في كيفية التعامل مع الصور: `SEQUENTIAL`، `TEXT_ONLY`، أو `VISUAL`.

### **تحويل الصور تسلسليًا**

إذا كنت تريد ظهور الصور بشكل فردي—واحدة تلو الأخرى—في الماركداون المُنشأ، اختر الخيار `SEQUENTIAL`. يوضح مثال Python أدناه كيفية تحويل عرض يحتوي على صور إلى ماركداون.
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```


### **تحويل الصور بصريًا**

إذا كنت تريد ظهور الصور معًا في الماركداون الناتج، اختر الخيار `VISUAL`. في هذا الوضع، تُحفظ الصور في الدليل الحالي للتطبيق (ويستخدم مستند الماركداون مسارات نسبية)، أو يمكنك تحديد مسار إخراج مخصص واسم مجلد.

يوضح مثال Python أدناه هذه العملية:
```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```


## **الأسئلة الشائعة**

**هل تبقى الروابط الفائقة محفوظة بعد التصدير إلى ماركداون؟**

نعم. النصوص [الروابط الفائقة](/slides/ar/python-net/manage-hyperlinks/) تُحافظ عليها كروابط ماركداون قياسية. الـ[transitions](/slides/ar/python-net/slide-transition/) و[animations](/slides/ar/python-net/powerpoint-animation/) للشرائح لا يتم تحويلها.

**هل يمكنني تسريع التحويل بتشغيله عبر عدة خيوط (threads)؟**

يمكنك تنفيذ المعالجة بالتوازي عبر الملفات، لكن لا يجب [لا تشارك](/slides/ar/python-net/multithreading/) لنفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) عبر الخيوط. استخدم كائنات/عمليات منفصلة لكل ملف لتجنب التعارض.

**ماذا يحدث للصور—أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/python-net/image/) إلى مجلد مخصص، ويشير ملف الماركداون إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك ضبط مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.