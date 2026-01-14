---
title: فتح العروض التقديمية في بايثون
linktitle: فتح العروض التقديمية
type: docs
weight: 20
url: /ar/python-net/open-presentation/
keywords:
- فتح PowerPoint
- فتح العرض التقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل العرض التقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- Python
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx، .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides لبايثون عبر .NET—سريع، موثوق، ذو ميزات كاملة."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل العرض التقديمي، يمكنك استرجاع معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى منشئها.

يعرض المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المنشئ.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    print(presentation.slides.length)
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة لفتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر الخاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Python هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي المفكوك تشفيره.
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وخاصة الخاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك على تحميل عروض تقديمية كبيرة.

يظهر الكود التالي بلغة Python كيفية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked — سيبقى ملف العرض مقفلاً طوال مدة 
# نسخة Presentation، لكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميغابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    # إجراء تعديلات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل هذا! سيحدث استثناء I/O لأن الملف مقفول حتى يتم تحرير كائن العرض التقديمي.
    os.remove(file_path)

# يمكن فعل ذلك هنا. لم يعد ملف المصدر مقفولًا بواسطة كائن العرض التقديمي.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عند الحاجة لتحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الفئة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة Python كيفية استخدام الفئة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:
- مشروع VBA (يمكن الوصول إليه عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية للتحكم ActiveX (يمكن الوصول إليها عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام الخاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) ، يمكنك تحميل عرض تقديمي بدون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح الكود التالي بلغة Python كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي.
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستصلك استثناء أثناء التحميل يشير إلى فشل في التحليل/تحقق من الصيغة. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint معطوبة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن قد يستبدل [التصيير/التصدير](/slides/ar/python-net/convert-presentation/) الخطوط لاحقًا. قم بـ [تكوين استبدالات الخطوط](/slides/ar/python-net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تُصبح متاحة كموارد للعرض التقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن هذه المسارات متاحة في بيئتك؛ وإلا قد يقوم [التصيير/التصدير](/slides/ar/python-net/convert-presentation/) بتجاهل الوسائط.