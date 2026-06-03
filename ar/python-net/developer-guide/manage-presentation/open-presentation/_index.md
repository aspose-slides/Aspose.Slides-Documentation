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
description: "افتح عروض PowerPoint (.pptx, .ppt) وOpenDocument (.odp) بسهولة مع Aspose.Slides للبايثون عبر .NET—سريعة، موثوقة، ومتجمعة بالكامل."
---
## **المقدمة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات حوله، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

يُظهر المثال التالي بلغة Python كيفية فتح عرض تقديمي والحصول على عدد الشرائح الخاصة به:

```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المُنشئ.
with slides.Presentation("sample.pptx") as presentation:
    # طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    print(presentation.slides.length)
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة لفتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) في الفئة [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Python هذه العملية:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي المفكوك.
```

## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وخاصة خاصية [blob_management_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/blob_management_options/) في الفئة [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح الكود التالي بلغة Python تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# اختر سلوك KeepLocked — سيبقى ملف العرض مقفلًا طوال عمر
# كائن Presentation، ولكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 ميجابايت

with slides.Presentation(file_path, load_options) as presentation:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    # إجراء تغييرات على العرض التقديمي.
    presentation.slides[0].name = "Large presentation"

    # حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا خلال هذه العملية.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا تفعل ذلك! سيُطلق استثناء I/O لأن الملف مقفل حتى يتم التخلص من كائن العرض التقديمي.
    os.remove(file_path)

# لا مانع من القيام بذلك هنا. لم يعد ملف المصدر مقفلًا بواسطة كائن العرض التقديمي.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/python-net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (متاح عبر [Presentation.vba_project](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/vba_project/));
- بيانات كائن OLE المدمجة (متاحة عبر [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- بيانات ثنائية للتحكم ActiveX (متاحة عبر [Control.active_x_control_binary](https://reference.aspose.com/slides/ar/python-net/aspose.slides/control/active_x_control_binary/)).

باستخدام خاصية [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

تفيد هذه الخاصية في إزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح الكود التالي بلغة Python كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # تنفيذ عمليات على العرض التقديمي.
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً متعلقًا بالتحليل أو التحقق من صحة التنسيق أثناء التحميل. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، ولكن قد يستبدل [التص渲/rendering/export](/slides/ar/python-net/convert-presentation/) الخطوط لاحقًا. قم بـ[تكوين استبدالات الخطوط](/slides/ar/python-net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/python-net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض التقديمي. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من إمكانية الوصول إلى تلك المسارات في بيئتك؛ وإلا قد تُهمل [التص渲/rendering/export](/slides/ar/python-net/convert-presentation/) الوسائط.