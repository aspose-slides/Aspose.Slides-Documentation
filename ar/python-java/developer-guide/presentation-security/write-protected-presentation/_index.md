---
title: حماية العروض التقديمية من الكتابة في بايثون
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/python-java/write-protected-presentation/
keywords:
- حماية الكتابة
- حماية الكتابة لبرنامج PowerPoint
- كلمة مرور للتعديل
- تقييد تحرير العرض التقديمي
- إزالة حماية الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعيين واكتشاف والتحقق من وصلاحية وإزالة كلمات مرور حماية الكتابة في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **مقدمة**

كلمة مرور الحماية من الكتابة تقيد تعديل العرض التقديمي ولكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض تقديمي محمي من الكتابة دون كلمة المرور. اعتمادًا على التطبيق، قد يتمكنون أيضًا من تحرير المحتوى وحفظه باسم مختلف، لذا لا ينبغي اعتبار الحماية من الكتابة كآلية سرية.

كلمة مرور الفتح تخدم غرضًا مختلفًا: فهي تشفر العرض التقديمي وتكون ضرورية لتحميل محتواه. لتشفير عرض تقديمي أو التحقق من صحة كلمة مرور الفتح، راجع [Password-Protect Presentations](/slides/ar/python-java/password-protected-presentation/).

تنطبق سير العمل في هذه المقالة على كل من عروض PPT و PPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ إلى PPT، استخدم امتداد `.ppt` وتنسيق الحفظ المقابل لـ PPT.

## **تعيين حماية الكتابة على عرض تقديمي**

استخدم [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#setWriteProtection) لتعيين كلمة مرور لتعديل العرض التقديمي. حفظ العرض التقديمي يحافظ على إعداد الحماية.

المثال التالي يحدد حماية الكتابة على عرض PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحميل عرض محمي من الكتابة**

نظرًا لأن حماية الكتابة لا تشفر محتوى العرض التقديمي، لا يلزم أي كلمة مرور لتحميل العرض. تكون كلمة المرور ذات صلة فقط عند التحقق من صلاحية تعديل العرض المحمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

لا تمرر كلمة مرور حماية الكتابة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword). هذه الطريقة تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض كلا نوعي الحماية، قدم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور حماية الكتابة بشكل منفصل.

## **إزالة حماية الكتابة من عرض تقديمي**

استخدم [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#removeWriteProtection) لإزالة قيود التعديل، ثم احفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) كامل، استدعِ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) وتفحص [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#isWriteProtected). تستخدم الطريقة [NullableBool](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/) وتعيد `NullableBool.True_` عندما يتم اكتشاف حماية الكتابة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

توفر نسخة التدفق من [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) نفس المعلومات لعرض تم توفيره كتيار.

## **التحقق من صحة كلمة مرور حماية الكتابة**

استخدم [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#checkWriteProtection) للتحقق من صحة كلمة مرور التعديل دون تحميل العرض الكامل. تحقق أولاً من [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#isWriteProtected) بحيث يطلب التطبيق أو يتحقق من كلمة المرور فقط عندما تكون حماية الكتابة موجودة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#checkWriteProtection) يتحقق فقط من كلمة مرور حماية الكتابة. لا يتحقق من كلمة مرور الفتح ولا يحدد ما إذا كان يمكن تحميل المحتوى المشفر. بالمقابل، [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#checkPassword) يتحقق فقط من كلمة مرور الفتح. إذا تم تحميل عرض كامل بالفعل، يوفر [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#checkWriteProtection) فحصًا مكافئًا لحماية الكتابة عبر مدير الحماية الخاص به.

في التطبيقات الإنتاجية، لا تقوم بتسجيل كلمات المرور أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط للمدة اللازمة.

{{% alert color="info" title="See also" %}}
- [حماية كلمة مرور العروض التقديمية](/slides/ar/python-java/password-protected-presentation/)
- [العروض التقديمية للقراءة فقط](/slides/ar/python-java/read-only-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تقوم حماية الكتابة بتشفير العرض التقديمي؟**

لا. إنها تقيد التعديل ولكنها تترك محتوى العرض متاحًا للتحميل والعرض.

**هل كلمة مرور حماية الكتابة مطلوبة لفتح العرض التقديمي؟**

لا. فقط كلمة مرور الفتح مطلوبة لتحميل محتوى العرض المشفر.

**هل يمكن أن يحتوي العرض التقديمي على كل من كلمة مرور الفتح وكلمة مرور حماية الكتابة؟**

نعم. قدم كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور حماية الكتابة بشكل منفصل عندما تكون صلاحية الت تعديل مطلوبة.