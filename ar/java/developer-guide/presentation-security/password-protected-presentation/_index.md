---
title: حماية العروض التقديمية بكلمة مرور في جافا
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/java/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير باوربوينت
- فك تشفير باوربوينت
- التحقق من صحة كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Java
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق من صحة، فتح وفك تشفير العروض التقديمية المحمية بكلمة مرور من PowerPoint PPT وPPTX في جافا باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة مرور الفتح تشفر عرضًا تقديميًا. يلزم إدخال كلمة المرور الصحيحة لتحميل وعرض محتوى العرض، لذا توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/java/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT وPPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوكهما القائم على الملف أو التدفق مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور الفتح**

استخدم [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) لتحديد كلمة مرور الفتح. ثم استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) لحفظ العرض المشفر.

المثال التالي يشفر عرض PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحميل عرض تقديمي مشفر**

عيّن [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) عند تحميل الملف. يفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض الذي تم فك تشفيره.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح، استدعِ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#removeEncryption--)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق من كلمة مرور الفتح قبل التحميل**

استخدم [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة المقدمة عبر [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **سير العمل باستخدام مسار الملف**

المثال التالي يتحقق من كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)، ثم يحمل العرض الكامل:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **سير العمل باستخدام تدفق**

الإصدار المتدفق من [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) يوفر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض الكامل من ذلك التدفق.

المثال التالي يستخدم ملف PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **قيم الإرجاع للدالة checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) تُعيد `true` فقط عندما يكون للعرض كلمة مرور فتح و تكون كلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT وPPTX.

## **التحقق ما إذا كان العرض الذي تم تحميله مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، راجع [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) للتأكد من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo.isPasswordProtected` كما هو موضح أعلاه.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تقوم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحفظ كلمات المرور في الذاكرة فقط للمدة المطلوبة، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض فورًا.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض عند العرض.
1. اختياريًا أدخل كلمة مرور منفصلة لحماية التحرير.
1. طبّق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ar/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض وتُطلب لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وطبق التحقق قبل إنشاء نسخة كاملة من العرض.

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT وPPTX؟**

نعم. سلوك الكشف عن كلمة المرور بناءً على مسار الملف أو التدفق والتحقق منه متطابق لكلا الصيغتين.