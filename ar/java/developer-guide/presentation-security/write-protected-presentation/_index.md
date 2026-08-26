---
title: حماية العروض التقديمية من الكتابة في جافا
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/java/write-protected-presentation/
keywords:
- حماية الكتابة
- PowerPoint بحماية الكتابة
- كلمة مرور للتعديل
- تقييد تحرير العرض التقديمي
- إزالة حماية الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "ضبط، اكتشاف، التحقق من صحة، وإزالة كلمات مرور حماية الكتابة في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides للغة Java."
---
## **المقدمة**

كلمة مرور حماية الكتابة تقيد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض تقديمي محمي من الكتابة دون كلمة المرور. حسب التطبيق، قد يتمكنون أيضًا من تعديل المحتوى وحفظه باسم مختلف، لذا لا يجب اعتبار حماية الكتابة آلية سرية.

كلمة مرور الفتح لها غرض مختلف: تشفر العرض التقديمي وتكون ضرورية لتحميل محتواه. لتشفير عرض تقديمي أو التحقق من كلمة مرور الفتح، راجع [Password-Protect Presentations](/slides/ar/java/password-protected-presentation/).

تطبق سير العمل في هذا المقال على عروض PPT وPPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ إلى PPT استخدم امتداد `.ppt` وتنسيق الحفظ المناسب لـ PPT.

## **تعيين حماية الكتابة على عرض تقديمي**

استخدم [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) لتعيين كلمة مرور لتعديل العرض التقديمي. سيؤدي حفظ العرض التقديمي إلى تثبيت إعداد الحماية.

المثال التالي يعين حماية كتابة على عرض تقديمي PPTX:

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

## **تحميل عرض تقديمي محمي من الكتابة**

نظرًا لأن حماية الكتابة لا تشفر محتوى العرض التقديمي، لا تحتاج إلى كلمة مرور لتحميل العرض. تكون كلمة المرور ذات صلة فقط عند التحقق من التفويض لتعديل العرض المحمي.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

لا تمرّر كلمة مرور حماية الكتابة إلى [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). تلك الطريقة تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض النوعان من الحماية، زوِّد كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور حماية الكتابة بشكل منفصل.

## **إزالة حماية الكتابة من عرض تقديمي**

استخدم [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) لإزالة قيد التعديل، ثم احفظ العرض التقديمي.

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

## **التحقق مما إذا كان العرض التقديمي محميًا من الكتابة**

لمعاينة ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) كامل، استدعِ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) وتفقد [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). تستخدم الطريقة [NullableBool](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/) وتعيد `NullableBool.True` عندما تُكتشف حماية كتابة.

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

يوفر التحميل عبر الدفق لـ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) نفس المعلومات لعرض تقديمي يُوفر كدفق.

## **التحقق من صحة كلمة مرور حماية الكتابة**

استخدم [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) للتحقق من كلمة مرور التعديل دون تحميل العرض الكامل. افحص أولًا [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) حتى يطلب التطبيق أو يتحقق من كلمة المرور فقط عندما تكون حماية الكتابة موجودة.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) يتحقق فقط من كلمة مرور حماية الكتابة. لا يتحقق من كلمة مرور الفتح ولا يحدد ما إذا كان يمكن تحميل محتوى مشفر. بالمقابل، [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) يتحقق فقط من كلمة مرور الفتح. إذا تم تحميل عرض تقديمي كامل مسبقًا، يوفر [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) التحقق المكافئ عبر مدير الحماية.

في التطبيقات الإنتاجية، لا تسجل كلمات المرور أو تدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط طالما كانت مطلوبة.

{{% alert color="info" title="انظر أيضًا" %}}
- [Password-Protect Presentations](/slides/ar/java/password-protected-presentation/)
- [Read-Only Presentations](/slides/ar/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تحمي حماية الكتابة عرضًا تقديميًا عن طريق التشفير؟**

لا. إنها تقيد التعديل ولكن تترك محتوى العرض متاحًا للتحميل والعرض.

**هل كلمة مرور حماية الكتابة مطلوبة لفتح العرض التقديمي؟**

لا. فقط كلمة مرور الفتح مطلوبة لتحميل محتوى عرض مشفر.

**هل يمكن أن يحتوي العرض على كل من كلمة مرور الفتح وكلمة مرور حماية الكتابة؟**

نعم. زوِّد كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور حماية الكتابة بشكل منفصل عندما يتطلب التفويض تعديل العرض.