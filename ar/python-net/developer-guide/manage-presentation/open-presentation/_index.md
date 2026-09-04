---
title: فتح العروض في بايثون
linktitle: فتح العروض
type: docs
weight: 20
url: /ar/python-net/open-presentation/
keywords:
- فتح PowerPoint
- فتح العرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل العرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- Python
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في بايثون، وتوفير كلمات مرور للفتح، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **مقدمة**

[Aspose.Slides لـ Python عبر .NET](https://products.aspose.com/slides/ar/python-net/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات والمسارات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالصيغة الأصلية أو بصيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل عبر الفئة [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/). على سبيل المثال، يمكنك تزويد كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). استخدم عبارة `with` حتى يتم تحرير مقابض الملفات، البيانات المؤقتة، وغيرها من الموارد على الفور.

يعرض المثال التالي بلغة Python كيفية فتح عرض والحصول على عدد الشرائح فيه:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **فتح العروض المحمية بكلمة مرور**

كلمة المرور للفتح تشفر محتوى العرض. لتحميل العرض بالكامل، عيّن كلمة المرور الصحيحة إلى [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

للتعرف على كلمة المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/python-net/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/python-net/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/blob_management_options/) يتحكم في كيفية معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بالملفات المؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

يظهر الكود التالي بلغة Python كيفية تحميل عرض كبير (مثلاً 2 جيجابايت):

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

مع `PresentationLockingBehavior.KEEP_LOCKED` يظل ملف المصدر مقفلاً حتى يتم التخلص من كائن `Presentation`. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يكون هذا الكائن موجودًا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف أكثر كفاءة عادةً من التدفق. راجع [Manage BLOBs](/slides/ar/python-net/manage-blob/) للمزيد من خيارات التخزين وإدارة الذاكرة.

{{% /alert %}}

## **تحميل العروض دون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشروعات VBA، متاحة عبر [Presentation.vba_project](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/vba_project/)؛
- بيانات OLE المدمجة، متاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/)؛
- بيانات عنصر تحكم ActiveX، متاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/ar/python-net/aspose.slides/control/active_x_control_binary/)؛

قم بتعيين [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) إلى `True` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تثير Aspose.Slides استثناءً أثناء التحليل أو تنسيق الملف عند التحميل. عالج هذا الفشل بصورة منفصلة عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

لا يزال بالإمكان تحميل العرض، لكن قد تستبدل الخطوط أثناء العرض أو التصدير. يمكنك [configure font substitution](/slides/ar/python-net/font-substitution/) أو [provide custom fonts](/slides/ar/python-net/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. تُحل الموارد الخارجية وفق سلوك التحميل الافتراضي وقد تكون غير متوفرة إذا تعذر الوصول إلى مواقعها.