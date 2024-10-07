---
title: فتح العرض التقديمي
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "فتح PowerPoint, PPTX, PPT, فتح العرض التقديمي, تحميل العرض التقديمي, بايثون"
description: "فتح أو تحميل العرض التقديمي PPT, PPTX, ODP في بايثون"
---

بالإضافة إلى إنشاء عروض PowerPoint من البداية، يسمح Aspose.Slides بفتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك الحصول على معلومات حول العرض، تحريره (المحتوى على الشرائح)، إضافة شرائح جديدة أو إزالة الشرائح الموجودة، إلخ.

## فتح العرض التقديمي

لفتح عرض تقديمي موجود، كل ما عليك هو إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتمرير مسار الملف (للعرض التقديمي الذي تود فتحه) إلى مُنشئه.

يوضح لك هذا الكود بلغة بايثون كيفية فتح عرض تقديمي وأيضًا معرفة عدد الشرائح التي يحتوي عليها:

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى مُنشئه
with slides.Presentation("pres.pptx") as pres:
    # طباعة العدد الإجمالي للشرائح الموجودة في العرض التقديمي
    print(pres.slides.length)
```

## **فتح عرض تقديمي محمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة المرور من خلال خاصية `password` (من فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)) لفك التشفير وتحميل العرض التقديمي. يوضح لك هذا الكود بلغة بايثون العملية:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## فتح عرض تقديمي كبير

يوفر Aspose.Slides خيارات (خاصية `blob_management_options` على وجه الخصوص) تحت فئة [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) للسماح لك بتحميل العروض التقديمية الكبيرة.

يوضح هذا الكود بلغة بايثون عملية تحميل عرض تقديمي كبير (على سبيل المثال، بحجم 2 جيجابايت):

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، لكن استهلاك الذاكرة لا يزال منخفضًا.

    # يتم إجراء تغييرات على العرض التقديمي.
    pres.slides[0].name = "عرض تقديمي كبير جدًا"

    # سيتم حفظ العرض التقديمي في ملف آخر. يظل استهلاك الذاكرة منخفضًا خلال العملية
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # لا يمكن فعل ذلك! سيتم طرح استثناء IO لأن الملف مقفل أثناء عدم التخلص من كائنات pres
    os.remove("pres.pptx")

# من الجيد القيام بذلك هنا. الملف المصدر ليس مقفلاً بواسطة كائن pres.
os.remove("pres.pptx")
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير من خلال تدفقه سيؤدي إلى نسخ محتويات العرض التقديمي وتسبب تحميلًا بطيئًا. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس تدفقه.

عندما تريد إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [مرافق Blob](https://docs.aspose.com/slides/python-net/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 

## تحميل العرض التقديمي

يوفر Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) مع طريقة واحدة للسماح لك بإدارة الموارد الخارجية. يوضح لك هذا الكود بلغة بايثون كيفية استخدام واجهة `IResourceLoadingCallback`:

```python
# [TODO[not_supported_yet]: تنفيذ بايثون لواجهات .net]
```

<h2>فتح وحفظ العرض التقديمي</h2>

<a name="python-net-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في بايثون</strong></a>

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتمرير الملف الذي تود فتحه.
2. حفظ العرض التقديمي.

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPT
with slides.Presentation() as presentation:
    
    #...قم ببعض العمل هنا...

    # احفظ عرضك التقديمي في ملف
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```