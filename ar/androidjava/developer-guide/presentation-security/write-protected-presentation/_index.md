---
title: حماية العروض من الكتابة على Android
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/androidjava/write-protected-presentation/
keywords:
- حماية من الكتابة
- حماية كتابة PowerPoint
- كلمة مرور للتعديل
- تقييد تعديل العرض
- إزالة الحماية من الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعيين، اكتشاف، التحقق من صحة وإزالة كلمات مرور الحماية من الكتابة في عروض PowerPoint PPT و PPTX باستخدام Aspose.Slides لأندرويد عبر جافا."
---
## **مقدمة**

كلمة مرور الحماية من الكتابة تقيد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض محمي من الكتابة بدون كلمة المرور. اعتمادًا على التطبيق، قد يكون بإمكانهم أيضًا تعديل المحتوى وحفظه باسم مختلف، لذا لا ينبغي اعتبار الحماية من الكتابة كآلية سرية.

كلمة مرور الفتح تخدم غرضًا مختلفًا: فهي تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. لتشفير عرض تقديمي أو التحقق من صحة كلمة مرور الفتح، راجع [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/).

تطبق سير العمل في هذه المقالة على كل من عروض PPT و PPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ إلى PPT، استخدم امتداد `.ppt` وتنسيق الحفظ المقابل لـ PPT.

## **تعيين الحماية من الكتابة على العرض التقديمي**

استخدم [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) لتعيين كلمة مرور لتعديل العرض التقديمي. حفظ العرض التقديمي يُثبت إعداد الحماية.

المثال التالي يضع الحماية من الكتابة على عرض PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحميل عرض محمي من الكتابة**

نظرًا لأن الحماية من الكتابة لا تشفر محتوى العرض التقديمي، لا يلزم كلمة مرور لتحميل العرض. كلمة المرور ذات صلة فقط عند التحقق من صلاحية تعديل العرض المحمي.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

لا تقم بتمرير كلمة مرور الحماية من الكتابة إلى [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). هذه الطريقة تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض التقديمي كلا النوعين من الحماية، قدم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور الحماية من الكتابة بشكل منفصل.

## **إزالة الحماية من الكتابة من العرض التقديمي**

استخدم [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) لإزالة قيد التعديل، ثم احفظ العرض التقديمي.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محمياً من الكتابة**

لفحص ملف دون إنشاء مثيل كامل من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، استدعِ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) وتفحص [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). تستخدم الطريقة [NullableBool](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/nullablebool/) وتعيد `NullableBool.True` عندما تُكتشف الحماية من الكتابة.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

الإصدار المتعدد للـ Stream من [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) يُقدم نفس المعلومات لعرض تقديمي مُقدم كتيار.

## **التحقق من صحة كلمة مرور الحماية من الكتابة**

استخدم [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) للتحقق من صحة كلمة مرور التعديل دون تحميل العرض الكامل. تحقق أولاً من [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) بحيث يطلب التطبيق أو يتحقق من كلمة المرور فقط عندما تكون الحماية من الكتابة موجودة.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) يتحقق فقط من كلمة مرور الحماية من الكتابة. لا يتحقق من كلمة مرور الفتح أو يحدد ما إذا كان يمكن تحميل المحتوى المشفر. على العكس، [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) يتحقق فقط من كلمة مرور الفتح. إذا تم تحميل عرض تقديمي كامل مسبقًا، فإن [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) يقدم فحص الحماية من الكتابة المكافئ عبر مدير الحماية الخاص به.

في التطبيقات الإنتاجية، لا تقم بتسجيل كلمات المرور أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط طالما كانت ضرورية.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/ar/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تُشفّر الحماية من الكتابة عرضًا تقديميًا؟**

لا. إنها تقيد التعديل ولكن تترك محتوى العرض متاحًا للتحميل والعرض.

**هل كلمة مرور الحماية من الكتابة مطلوبة لفتح العرض؟**

لا. فقط كلمة مرور الفتح مطلوبة لتحميل محتوى العرض المشفر.

**هل يمكن للعرض أن يمتلك كلًا من كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

نعم. قم بتوفير كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور الحماية من الكتابة بشكل منفصل عند الحاجة إلى صلاحية تعديل.