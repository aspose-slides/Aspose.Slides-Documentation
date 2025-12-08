---
title: فتح عرض تقديمي في بايثون
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
description: "فتح عروض PowerPoint (.pptx, .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides للغة Python عبر .NET - سريع، موثوق، كامل الميزات."
---

## **نظرة عامة**

بعيدًا عن إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استخراج معلومات حوله، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

يظهر المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح فيه:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى منشئها.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    print(presentation.slides.length)
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر الخاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) الخاصة بفئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لتفكيك التشفير وتحميله. يوضح الكود التالي بلغة Python هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي المفكوك الشيفرة.
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وبشكل خاص الخاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يعرض الكود التالي بلغة Python كيفية تحميل عرض تقديمي كبير (على سبيل المثال 2 جيجابايت):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked—ستظل ملف العرض مؤمنًا طوال عمر
# كائن Presentation، لكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميغابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    # أجرِ تغييرات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # احفظ العرض التقديمي إلى ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل ذلك! سيُلقى استثناء I/O لأن الملف مؤمن حتى يتم التخلص من كائن العرض التقديمي.
    os.remove(file_path)

# لا بأس القيام بذلك هنا. لم يعد ملف المصدر مؤمنًا من قبل كائن العرض التقديمي.
os.remove(file_path)
```


{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند العمل مع الدفقات، قد يقوم Aspose.Slides بنسخ محتويات الدفق. تحميل عرض تقديمي كبير من دفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصى بشدة باستخدام مسار ملف العرض بدلاً من الدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [إدارة BLOB](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يوضح الكود التالي بلغة Python كيفية استخدام الواجهة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .NET]
```


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات التحكم الثنائي لـ ActiveX (يمكن الوصول إليها عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام الخاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي الذي قد يكون ضارًا. يوضح الكود التالي بلغة Python كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # إجراء عمليات على العرض التقديمي.
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

سوف تحصل على استثناء تحقق من الصيغة/التحليل أثناء التحميل. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، ولكن قد يستبدل [التصrender/التصدير](/slides/ar/python-net/convert-presentation/) الخطوط لاحقًا. قم بـ[تكوين استبدال الخطوط](/slides/ar/python-net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

ستصبح متاحة كموارد للعرض التقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد يتجاهل [التصrender/التصدير](/slides/ar/python-net/convert-presentation/) الوسائط.