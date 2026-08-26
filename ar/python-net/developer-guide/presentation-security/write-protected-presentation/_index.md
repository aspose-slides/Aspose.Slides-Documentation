---
title: حماية العروض التقديمية من الكتابة في بايثون
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/python-net/write-protected-presentation/
keywords:
- حماية الكتابة
- حماية الكتابة PowerPoint
- كلمة مرور للتعديل
- تقييد تحرير العرض التقديمي
- إزالة حماية الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعيين، اكتشاف، التحقق، وإزالة كلمات مرور الحماية من الكتابة في عروض PowerPoint بصيغة PPT و PPTX باستخدام Aspose.Slides للبايثون."
---
## **المقدمة**

كلمة مرور الحماية من الكتابة تقيد تعديل عرض تقديمي ولكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض تقديمي محمي من الكتابة دون كلمة المرور. اعتمادًا على التطبيق، قد يكون بإمكانهم أيضًا تعديل المحتوى وحفظه باسم مختلف، لذا لا يجب اعتبار الحماية من الكتابة كآلية سرية.

كلمة مرور الفتح تخدم غرضًا مختلفًا: فهي تشفر العرض التقديمي وتُطلب لتحميل محتواه. لتشفير عرض تقديمي أو التحقق من كلمة مرور الفتح، راجع [Password-Protect Presentations](/slides/ar/python-net/password-protected-presentation/).

تطبق سير العمل في هذه المقالة على عروض تقديمية بصيغ PPT و PPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ بصيغة PPT، استخدم الامتداد `.ppt` وتنسيق الحفظ المناسب لـ PPT.

## **تعيين الحماية من الكتابة على عرض تقديمي**

استخدم [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/set_write_protection/) لتعيين كلمة مرور لتعديل عرض تقديمي. حفظ العرض التقديمي يحافظ على إعداد الحماية.

المثال التالي يعيّن الحماية من الكتابة على عرض تقديمي بصيغة PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تحميل عرض تقديمي محمي من الكتابة**

نظرًا لأن الحماية من الكتابة لا تشفر محتوى العرض التقديمي، لا يلزم كلمة مرور لتحميل العرض التقديمي. تكون كلمة المرور ذات صلة فقط عند التحقق من التفويض لتعديل العرض المحمي.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

لا تقم بتمرير كلمة مرور الحماية من الكتابة إلى [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/). هذه الخاصية تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض التقديمي كلا النوعين من الحماية، قدِّم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور الحماية من الكتابة بشكل منفصل.

## **إزالة الحماية من الكتابة من عرض تقديمي**

استخدم [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/remove_write_protection/) لإزالة قيود التعديل، ثم احفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كان العرض التقديمي محميًا من الكتابة**

لتفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) كامل، استدعِ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) وتفقد [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/is_write_protected/). تستخدم الخاصية [NullableBool](https://reference.aspose.com/slides/ar/python-net/aspose.slides/nullablebool/) وتعيد `NullableBool.TRUE` عندما يتم الكشف عن الحماية من الكتابة.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

توفر نسخة التدفق من [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) نفس المعلومات لعرض تقديمي يُمرَّر كدفق.

## **التحقق من صحة كلمة مرور الحماية من الكتابة**

استخدم [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_write_protection/) للتحقق من صحة كلمة مرور التعديل دون تحميل العرض التقديمي الكامل. تحقق أولاً من [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/is_write_protected/) حتى يطلب التطبيق كلمة مرور أو يتحقق منها فقط عندما تكون الحماية من الكتابة موجودة.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_write_protection/) يتحقق فقط من كلمة مرور الحماية من الكتابة. لا يتحقق من كلمة مرور الفتح ولا يحدد ما إذا كان يمكن تحميل المحتوى المشفر. بالمقابل، [PresentationInfo.check_password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/check_password/) يتحقق فقط من كلمة مرور الفتح. إذا كان عرض تقديمي كامل قد تم تحميله بالفعل، فإن [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/check_write_protection/) يقدم فحصًا مكافئًا للحماية من الكتابة عبر مدير الحماية الخاص به.

في التطبيقات الإنتاجية، لا تُسجل كلمات المرور ولا تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط طالما هي مطلوبة.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض التقديمية بكلمة مرور](/slides/ar/python-net/password-protected-presentation/)
- [عروض تقديمية للقراءة فقط](/slides/ar/python-net/read-only-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تقوم الحماية من الكتابة بتشفير العرض التقديمي؟**

لا. فهي تقيد التعديل ولكنها تترك محتوى العرض التقديمي متاحًا للتحميل والعرض.

**هل كلمة مرور الحماية من الكتابة مطلوبة لفتح عرض تقديمي؟**

لا. فقط كلمة مرور الفتح مطلوبة لتحميل محتوى العرض التقديمي المشفر.

**هل يمكن أن يحتوي عرض تقديمي على كل من كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

نعم. قدِّم كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من صحة كلمة مرور الحماية من الكتابة بشكل منفصل عندما تكون صلاحية التعديل مطلوبة.