---
title: حماية العروض التقديمية بكلمة مرور على Android
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/androidjava/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من صحة كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير العروض التقديمية PowerPoint بصيغ PPT و PPTX المحمية بكلمة مرور باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير العرض التقديمي. يلزم كلمة المرور الصحيحة لتحميل وعرض محتوى العرض، لذلك توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. حماية الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض، راجع [حماية العروض من الكتابة](/slides/ar/androidjava/write-protected-presentation/).

تطبيقات سير العمل أدناه تنطبق على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوكهما القائم على الملفات أو التدفقات مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور الفتح**

استخدم [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) لتعيين كلمة مرور الفتح. ثم استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) لحفظ العرض المشفر.

المثال التالي يقوم بتشفير عرض PPTX:

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

## **تحميل عرض مشفر**

قم بتعيين [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) عند تحميل الملف. يفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض المفكك.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح، واستدعِ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

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

## **التحقق من صحة كلمة مرور الفتح قبل التحميل**

استخدم [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) قبل طلب أو التحقق من كلمة المرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم التحقق منها باستخدام [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **سير عمل المسار إلى الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)، ثم يقوم بتحميل العرض الكامل:

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

### **سير عمل التدفق**

نسخة التدفق من [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) توفر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض الكامل من ذلك التدفق.

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

### **قيم الإرجاع لـ checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) تُعيد `true` فقط عندما يكون للعرض كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمّل مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، تحقق من [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) للتأكد من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo.isPasswordProtected` كما هو موضح أعلاه.

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

{{% alert color="warning" title="الأمان" %}}
لا تقوم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط طالما كان ذلك مطلوبًا، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض مباشرةً.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض عند العرض.
1. اختيارياً، أدخل كلمة مرور منفصلة لحماية التحرير.
1. طبق الحماية وقم بتنزيل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض من الكتابة](/slides/ar/androidjava/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تقوم بتشفير العرض وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من صحة كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، تحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، واطّق كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل تدعم عمليات التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها عبر المسار إلى الملف أو التدفق يعملان نفس الطريقة لعرض PPT و PPTX.