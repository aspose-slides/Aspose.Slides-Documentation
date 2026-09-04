---
title: حماية العروض التقديمية بكلمة مرور في Java
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/java/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من صحة كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Java
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق من صحة، فتح وفك تشفير العروض التقديمية المحمية بكلمة مرور PowerPoint PPT و PPTX في Java باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة مرور الفتح تشفر العرض التقديمي. كلمة المرور الصحيحة ضرورية لتحميل وعرض محتوى العرض، لذا يوفر هذا الحماية سريةً.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض. لإدارة كلمات المرور لتعديل العروض، راجع [Write-Protect Presentations](/slides/ar/java/write-protected-presentation/).

تطبق سير العمل أدناه على عروض PPT و PPTX. تُظهر الأمثلة كلا الصيغتين حيث يكون سلوك التعامل مع الملفات أو التيار مهمًا.

## **تشفير عرض تقديمي بكلمة مرور فتح**

استخدم [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) لتعيين كلمة مرور الفتح. ثم استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) لحفظ العرض المشفر.

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

## **إبقاء خصائص المستند عامة**

بشكل افتراضي، يشتمل Aspose.Slides على خصائص المستند في تشفير العرض. يتحكم الأسلوب [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. مرّر `false` قبل استدعاء [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) عندما تحتاج أن تقرأ أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات البيانات الوصفية بدون كلمة مرور الفتح.

المثال التالي ينشئ عرض PPTX مشفرًا مع ترك خصائص المستند المدمجة عامة:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تمرير `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر في العرض عامًا. يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [Manage Presentation Properties](/slides/ar/java/presentation-properties/).

## **تحميل عرض مشفر**

عيّن [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل إذا كانت كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدمة غير موجودة أو غير صحيحة.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكوك تشفيره.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح، استدعِ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#removeEncryption--)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

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

استخدم [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض. افحص [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) قبل طلب أو التحقق من كلمة المرور. عندما تكون الحماية موجودة، تحقق من القيمة المقدمة باستخدام [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **سير عمل مسار الملف**

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

### **سير عمل التيار**

إصدار التيار من [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) يوفر نفس سير العمل. أعد ضبط موضع التيار القابل للتمرير قبل تحميل العرض الكامل من ذلك التيار.

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

### **قِيَم عودة checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) تُعيد `true` فقط عندما يحتوي العرض على كلمة مرور فتح وكلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمل مشفرًا**

بعد تحميل عرض بكلمة مرور صحيحة، افحص [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) لتأكيد أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo.isPasswordProtected` كما هو موضح أعلاه.

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

## **توصيات أمان**

{{% alert color="warning" title="الأمان" %}}
لا تُسجِّل كلمات مرور الفتح ولا تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط ما دامت مطلوبة، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض مباشرةً.

قد تُفصح خصائص المستند العامة عن أسماء المؤلفين والعناوين والموضوعات والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصَّصة رغم أن محتوى العرض مشفر. قم بتشفير البيانات الوصفية الحساسة مع العرض. يجب أن يكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما تحتاج الأنظمة إلى الفهرسة أو التصنيف أو البحث أو إدارة الملف دون كلمة مرور فتح.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض.
1. أدخل كلمة مرور لحماية العرض عند العرض.
1. (اختياري) أدخل كلمة مرور منفصلة لحماية التعديل.
1. طبّق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [Write-Protect Presentations](/slides/ar/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض وتُطلب لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل كل الشرائح؟**

نعم. احصل على معلومات العرض، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، ثم تحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل يمكن للتطبيق قراءة البيانات الوصفية بدون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما يكون العرض مشفرًا مع تعطيل تشفير خصائص المستند. يجب على التطبيق حينها استخدام وضع التحميل الخاص بالخصائص فقط الموضح في [Manage Presentation Properties](/slides/ar/java/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كل من PPT و PPTX؟**

نعم. سلوك الكشف عن كلمة المرور والتحقق منها بناءً على مسار الملف أو التيار هو نفسه لعروض PPT و PPTX.