---
title: فتح العروض التقديمية في بايثون
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
description: "افتح عروض PowerPoint (.pptx, .ppt) ومستندات OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لبايثون عبر .NET—سريعة، موثوقة، متكاملة بالكامل."
---

## **نظرة عامة**

بصرف النظر عن إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرداد معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، حذف الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

توضح المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح فيه:
```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المُنشئ.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة إجمالي عدد الشرائح في العرض التقديمي.
    print(presentation.slides.length)
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Python هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # إجراء عمليات على العرض التقديمي المفكوك.
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وخاصة خاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح هذا الكود بلغة Python كيفية تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked — سيبقى ملف العرض التقديمي مقفولًا طوال مدة
# مثيل Presentation، ولكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميغابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    # إجراء تغييرات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # احفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا خلال هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل هذا! سيتم رفع استثناء I/O لأن الملف مقفول حتى يتم تحرير كائن العرض التقديمي.
    os.remove(file_path)

# لا بأس بالقيام بذلك هنا. لم يعد ملف المصدر مقفولًا بواسطة كائن العرض التقديمي.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد ينسخ Aspose.Slides محتويات التدفق. يؤدي تحميل عرض تقديمي كبير من تدفق إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عند الحاجة إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides واجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تمكنك من إدارة الموارد الخارجية. يوضح الكود التالي بلغة Python كيفية استخدام واجهة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .NET]
```


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:
- مشروع VBA (متاح عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (متاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية لتحكم ActiveX (متاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام خاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح الكود التالي بلغة Python كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي.
```


## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

سوف تحصل على استثناء أثناء التحميل يتعلق بتحليل/تحقق من التنسيق. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن قد يستبدل [rendering/export](/slides/ar/python-net/convert-presentation/) الخطوط لاحقًا. [Configure font substitutions](/slides/ar/python-net/font-substitution/) أو [add the required fonts](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تتحول إلى موارد عرض تقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد يحذف [rendering/export](/slides/ar/python-net/convert-presentation/) الوسائط.