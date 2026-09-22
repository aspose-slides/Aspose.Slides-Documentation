---
title: فتح العروض التقديمية في Python
linktitle: فتح العروض التقديمية
type: docs
weight: 20
url: /ar/python-net/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- Python
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في Python، وتوفير كلمات مرور الفتح، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides for Python عبر .NET."
---
## **مقدمة**

[ Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ar/python-net/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات وتدفق البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر الفئة [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/). على سبيل المثال، يمكنك تقديم كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض الأصلي](/slides/ar/python-net/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك له.

لفتح عرض تقديمي موجود، مرر مسار ملفه إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). استخدم تعبير `with` بحيث يتم تحرير مقبض الملف والبيانات المؤقتة والموارد الأخرى بسرعة.

المثال التالي بلغة Python يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح فيه:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

كلمة المرور للفتح تشفر محتوى العرض. لتحميل العرض بالكامل، عيّن كلمة المرور الصحيحة إلى [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) ومرّر الخيارات إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

لعمليات اكتشاف كلمة المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/python-net/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/python-net/presentation-properties/).

## **فتح عروض تقديمية كبيرة**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/blob_management_options/) يتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور، والصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بملفات مؤقتة، وتحديد مقدار بيانات BLOB المحتفظ بها في الذاكرة.

هذا الكود بلغة Python يوضح تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

باستخدام `PresentationLockingBehavior.KEEP_LOCKED` يبقى ملف المصدر مقفلًا حتى يتم التخلص من كائن `Presentation`. لا تقم بنقل ملف المصدر أو استبداله أو حذفه بينما يظل هذا الكائن قائمًا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء التحميل. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/python-net/manage-blob/) للمزيد من خيارات التخزين وإدارة الذاكرة.

{{% /alert %}}

## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

قد يحتوي عرض تقديمي على بيانات ثنائية مدمجة لا تحتاجها التطبيق أو لا ترغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، المتاحة عبر [Presentation.vba_project](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/vba_project/);
- بيانات OLE مدمجة، المتاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- بيانات تحكم ActiveX، المتاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/ar/python-net/aspose.slides/control/active_x_control_binary/).

ضع [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) إلى `True` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظام كشف برمجيات خبيثة أو تنقية محتوى كامل.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن ملفًا ما معطوب ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً متعلقًا بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

لا يزال بالإمكان تحميل العرض، لكن قد يتم استبدال الخطوط أثناء العرض والتصدير. يمكنك [configure font substitution](/slides/ar/python-net/font-substitution/) أو [provide custom fonts](/slides/ar/python-net/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل يؤدي تحميل عرض تقديمي إلى تحميل وسائطه المدمجة أيضًا؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. تُحَل الموارد الخارجية وفق سلوك التحميل الافتراضي وقد تكون غير متاحة إذا تعذّر الوصول إلى مواقعها.