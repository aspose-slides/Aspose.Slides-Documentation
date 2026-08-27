---
title: تحويل عروض PowerPoint إلى Markdown في بايثون
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/python-net/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- Python
- Python عبر .NET
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في بايثون والتحكم في مكان حفظ الصور المصدرة وكيفية إشارة Markdown المُولَّدة إليها."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python عبر .NET تحويل عروض PPT و PPTX إلى Markdown للتوثيق، ومواقع ثابتة، والهجرة المحتوى، وتدفقات العمل المتعلقة بالتحكم في الإصدارات. يمكنك اختيار نكهة Markdown، والتحكم في طريقة عرض محتوى الشرائح، وتحديد مكان تخزين الصور المصدرة وكيفية إشارة Markdown المُولَّد إليها.

بشكل افتراضي، يستخدم تصدير Markdown إخراجًا نصيًا فقط. لتصدير المحتوى المرئي، اضبط الخاصية [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/export_type/) إلى القيمة `SEQUENTIAL` أو `VISUAL` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownexporttype/). تُظهر `SEQUENTIAL` عناصر الشريحة بشكل منفصل وبالترتيب، بينما تُبقي `VISUAL` العناصر المجمعة معًا للحفاظ على علاقتها البصرية. قيمة `TEXT_ONLY` لا تُصدر موارد الصور.

## **تحويل عرض تقديمي إلى Markdown**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، ثم استدعِ الطريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/) مع القيمة `MD` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **اختر نكهة Markdown**

تتحكم الخاصية [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/flavor/) في مواصفة Markdown المستخدمة في الخرج. يتضمن تعداد [Flavor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/flavor/) القيم CommonMark و GitHub Flavored Markdown وغيرها من المتغيرات المدعومة.

المثال التالي يصدر عرضًا تقديميًا بصيغة CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/) خاصيتين للصور المحفوظة محليًا:

- [base_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/base_path/) يحدد الدليل الأساسي لمستند Markdown وموارده.
- [images_save_folder_name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) يحدد دليل الصور الفرعي. القيمة الافتراضية هي `Images`.

المثال التالي يعرض المحتوى المرئي، يكتب الصور إلى `output/assets`، ويُنشئ مراجع صور نسبية في مستند Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

يقوم Aspose.Slides بإنشاء دليل الصور الفرعي عند إنتاج تصدير موارد الصور، ولكن يجب على التطبيق إنشاء `base_path` قبل حفظ ملف Markdown.

## **تحضير Markdown والصور للنشر**

لا يكشف Aspose.Slides for Python عبر .NET عن ردود النداء .NET الخاصة بحفظ الصور لاستبدال كل رابط صورة مُولَّد أثناء التصدير. بدلاً من ذلك، صدّر مستند Markdown ومجلد الصور إلى دليل نشر، ثم نشر ذلك الدليل دون تغيير هيكله النسبي.

المثال التالي يُعدّ `cdn-origin/presentations/quarterly-report` كدليل نشر مركب أو متزامن. العينة نفسها لا تُجري أي تحميل شبكة: الروابط المُولَّدة تصبح صالحة بعد نشر الدليل في الموقع أو موقع CDN المقصود.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

انشر `presentation.md` مع دليل `assets`. يستخدم مستند Markdown مراجع صور نسبية، لذا يجب على العنصرين الحفاظ على نفس العلاقة في الوجهة. إذا كان نظام النشر يتطلب عناوين URL خارجية مطلقة، أعد كتابة الروابط المُولَّدة كخطوة معالجة لاحقة منفصلة بعد نشر جميع ملفات الصور.

## **الأسئلة الشائعة**

**هل يمكن لاستدعاءات بايثون تخصيص ملفات الصور الفردية والروابط أثناء تصدير Markdown؟**

لا. لا يكشف Aspose.Slides for Python عبر .NET عن ردود النداء .NET `ImageSaving` و `SvgImageSaving`. قم بتكوين الإخراج المحلي باستخدام [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/base_path/) و [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)، ثم انشر أو عَالج الموارد المُولَّدة لاحقًا.

**أين يتم حفظ الصور المصدرة؟**

يتم التحكم في موقع الصورة عبر [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/base_path/) و [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). يشير مستند Markdown إلى تلك الصور باستخدام مسارات نسبية.

**أي فاصل مسار يجب أن تستخدمه روابط الصور؟**

استخدم الشرطات المائلة (/) في روابط Markdown و URLs. استخدم `os.path.join` فقط لمسارات نظام الملفات، وقم بتوحيد أي رابط يُنشئ أثناء المعالجة اللاحقة بشكل منفصل.

**هل تُحافظ الروابط التشعبية أثناء تصدير Markdown؟**

نعم. تُحافظ على النصوص [hyperlinks](/slides/ar/python-net/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/python-net/slide-transition/) و [animations](/slides/ar/python-net/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكن تحويل العروض التقديمية إلى Markdown بالتوازي؟**

يمكنك معالجة ملفات عروض تقديمية مختلفة بالتوازي، ولكن لا تشارك نفس مثيل [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/python-net/multithreading/) واستخدم مثيلًا منفصلًا لكل ملف.