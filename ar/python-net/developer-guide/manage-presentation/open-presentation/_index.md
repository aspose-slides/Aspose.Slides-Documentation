---
title: فتح العروض في Python
linktitle: فتح العروض
type: docs
weight: 20
url: /ar/python-net/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- Python
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides للغة Python عبر .NET—سريع، موثوق، كامل المميزات."
---

## **نظرة عامة**

بخلاف إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides أيضًا فتح العروض الموجودة. بعد تحميل عرض، يمكنك استرجاع المعلومات الخاصة به، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض**

لفتح عرض موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

المثال التالي بلغة Python يوضح كيفية فتح عرض والحصول على عدد الشرائح:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى مُنشئها.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض.
    print(presentation.slides.length)
```


## **فتح العروض المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض محمي بكلمة مرور، مرّر كلمة المرور عبر الخاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) من فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. المثال التالي بلغة Python يوضح هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض المفك تشفيره.
```


## **فتح العروض الكبيرة**

توفر Aspose.Slides خيارات—وخاصةً الخاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك على تحميل عروض كبيرة.

هذا الكود بلغة Python يوضح تحميل عرض كبير (على سبيل المثال، 2 GB):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked — سيبقى ملف العرض مقفولًا طوال عمر
# كائن Presentation، ولكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميغابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض الكبير ويمكن استخدامه، بينما يظل استهلاك الذاكرة منخفضًا.

    # قم بإجراء تغييرات على العرض.
    presentation.slides[0].name = "Large presentation"

    # احفظ العرض إلى ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل هذا! سيحدث استثناء I/O لأنه يظل الملف مقفولًا حتى يتم تحرير كائن العرض.
    os.remove(file_path)

# يمكن القيام بذلك هنا. لم يعد ملف المصدر مقفولًا بواسطة كائن العرض.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض كبير من تدفق يؤدي إلى نسخ العرض ويمكن أن يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

توفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. الكود التالي بلغة Python يوضح كيفية استخدام واجهة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


## **تحميل العروض دون الكائنات الثنائية المدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (متاح عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (متاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية لعنصر تحكم ActiveX (متاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام الخاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/)، يمكنك تحميل عرض دون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي الذي قد يكون ضارًا. الكود التالي بلغة Python يوضح كيفية تحميل عرض بدون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض.
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

سوف تحصل على استثناء أثناء التحميل يتعلق بالتحليل أو التحقق من صحة التنسيق. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint تالفة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن عملية [rendering/export](/slides/ar/python-net/convert-presentation/) قد تستبدل الخطوط. يمكنك [Configure font substitutions](/slides/ar/python-net/font-substitution/) أو [add the required fonts](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح متاحة كموارد للعرض. إذا كانت الوسائط موصولة بمسارات خارجية، تأكد من أن تلك المسارات متوفرة في بيئتك؛ وإلا قد تقوم عملية [rendering/export](/slides/ar/python-net/convert-presentation/) بتجاوز الوسائط.