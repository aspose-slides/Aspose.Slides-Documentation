---
title: "فتح العروض التقديمية في Python"
linktitle: "فتح العروض التقديمية"
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
- مصدر خارجي
- كائن ثنائي
- Python
- Aspose.Slides
description: "افتح عروض PowerPoint (.pptx, .ppt) وعروض OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لبايثون عبر .NET — سريع، موثوق، ذو ميزات كاملة."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides أيضًا فتح العروض الحالية. بعد تحميل عرض تقديمي، يمكنك استرجاع المعلومات الخاصة به، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الموجودة، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرر مسار الملف إلى مُنشئها.

يوضح المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح الخاصة به:
```python
import aspose.slides as slides

# إنشاء كائن الفئة Presentation وتمرير مسار الملف إلى المنشئ الخاص بها.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    print(presentation.slides.length)
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرر كلمة المرور عبر خاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Python هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي المفكوك تشفيره.
```


## **فتح العروض التقديمية الكبيرة**

توفر Aspose.Slides خيارات—وخاصة خاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح هذا الكود بلغة Python كيفية تحميل عرض تقديمي كبير (مثلاً، 2 جيجابايت):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked—ستظل ملف العرض مقفولًا طوال فترة 
# نسخة الـ Presentation، لكن لا حاجة لتحميله في الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميجابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    # قم بإجراء تغييرات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # احفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل هذا! سيُطلق استثناء I/O لأن الملف مقفل حتى يتم التخلص من كائن العرض التقديمي.
    os.remove(file_path)

# لا بأس بتنفيذ ذلك هنا. لم يعد ملف المصدر مقفلًا بواسطة كائن العرض التقديمي.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يتسبب في نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

توفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة Python كيفية استخدام الواجهة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:
- مشروع VBA (يمكن الوصول إليه عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية لعنصر تحكم ActiveX (يمكن الوصول إليها عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام خاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح الكود التالي بلغة Python كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي.
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً أثناء التحميل يخص تحليل/تحقق من تنسيق الملف. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن قد يستبدل [rendering/export](/slides/ar/python-net/convert-presentation/) الخطوط لاحقًا. [Configure font substitutions](/slides/ar/python-net/font-substitution/) أو [add the required fonts](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا يحدث للوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح متاحة كموارد للعرض التقديمي. إذا كانت الوسائط مشيرة إلى مسارات خارجية، تأكد من إمكانية الوصول إلى تلك المسارات في بيئتك؛ وإلا قد تُغفل [rendering/export](/slides/ar/python-net/convert-presentation/) الوسائط.