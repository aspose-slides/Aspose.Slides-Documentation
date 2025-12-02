---
title: فتح العروض التقديمية في Python
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
description: "فتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة باستخدام Aspose.Slides للغة Python عبر .NET—سريع، موثوق، كامل المميزات."
---

## **نظرة عامة**

إلى جانب إنشاء عروض PowerPoint من الصفر، يتيح Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرداد المعلومات الخاصة به، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح القائمة، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

تظهر مثال Python التالي كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى منشئها.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    print(presentation.slides.length)
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح كود Python التالي هذه العملية:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي المفكوك
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وخاصة خاصية [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) في فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح كود Python التالي كيفية تحميل عرض تقديمي كبير (مثلاً، 2 جيجابايت):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked—ستظل ملف العرض التقديمي مقفلًا طوال مدة
# مثيل Presentation، لكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميجابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، بينما يظل استهلاك الذاكرة منخفضًا.

    # إجراء تغييرات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل ذلك! سيتم رفع استثناء I/O لأن الملف مقفل حتى يتم تحرير كائن العرض التقديمي.
    os.remove(file_path)

# يمكن القيام بذلك هنا. لم يعد ملف المصدر مقفلًا بواسطة كائن العرض التقديمي.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يتسبب في نسخ العرض التقديمي وقد يؤدي إلى إبطاء عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides واجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يوضح كود Python التالي كيفية استخدام واجهة `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


## **تحميل العروض التقديمية بدون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:
- مشروع VBA (متاح عبر [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (متاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية للتحكم ActiveX (متاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام خاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) يمكنك تحميل عرض تقديمي بدون أي كائنات ثنائية مدمجة.

تُفيد هذه الخاصية في إزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح كود Python التالي كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي.
```


## **FAQ**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً أثناء التحليل/التحقق من التنسيق عند التحميل. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن لاحقًا قد يستبدل [rendering/export](/slides/ar/python-net/convert-presentation/) الخطوط. يمكنك [Configure font substitutions](/slides/ar/python-net/font-substitution/) أو [add the required fonts](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

ستصبح متاحة كموارد للعرض التقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن هذه المسارات قابلة للوصول في بيئتك؛ وإلا قد يقوم [rendering/export](/slides/ar/python-net/convert-presentation/) بحذف الوسائط.