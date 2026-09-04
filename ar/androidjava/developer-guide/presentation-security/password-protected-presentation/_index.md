---
title: حماية العروض التقديمية بكلمة مرور على Android
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/androidjava/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور افتتاحية
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض التقديمي
- فحص كلمة مرور العرض التقديمي
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير عروض PowerPoint PPT و PPTX المحمية بكلمة مرور باستخدام Aspose.Slides للأندرويد عبر جافا."
---
## **نظرة عامة**

كلمة المرور الافتتاحية تقوم بتشفير العرض التقديمي. يُشترط توفير كلمة المرور الصحيحة لتحميل وعرض محتوى العرض التقديمي، لذا توفر هذه الحماية السرية.

كلمة المرور الافتتاحية مختلفة عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل ولكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور الخاصة بتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/androidjava/write-protected-presentation/).

تطبق سير العمل أدناه على عروض PPT و PPTX. تُظهر الأمثلة كلا الصيغتين حيث يكون سلوك التعامل مع الملفات أو التيارات مهمًا.

## **تشفير عرض تقديمي بكلمة مرور افتتاحية**

استخدم [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) لتعيين كلمة مرور افتتاحية. ثم استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) لحفظ العرض التقديمي المشفر.

المثال التالي يشفر عرضًا تقديميًا بصيغة PPTX:

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

## **جعل خصائص المستند عامة**

بشكل افتراضي، يضم Aspose.Slides خصائص المستند في تشفير العرض التقديمي. تتحكم طريقة [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) في هذا السلوك بصورة مستقلة عن تشفير محتوى الشرائح. مرّر `false` قبل استدعاء [IProtectionManager.encrypt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) عندما تحتاج أن تقرأ أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات البيانات الوصفية دون كلمة مرور افتتاحية.

المثال التالي يخلق عرضًا تقديميًا بصيغة PPTX مشفرًا مع ترك خصائص المستند المدمجة عامة:

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

تمرير `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر من العرض التقديمي عامًا. إنه يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [Manage Presentation Properties](/slides/ar/androidjava/presentation-properties/).

## **تحميل عرض تقديمي مشفر**

عيّن [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) إلى كلمة المرور الافتتاحية ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل إذا كانت كلمة المرور الافتتاحية مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكك.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض التقديمي بكلمة المرور الافتتاحية، استدعِ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--)، ثم احفظ النتيجة. يمكن بعدها تحميل العرض التقديمي المحفوظ دون كلمة مرور.

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

## **التحقق من صحة كلمة مرور افتتاحية قبل التحميل**

استخدم [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/) دون إنشاء مثيل كامل للعرض التقديمي. تحقق من [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) قبل طلب أو التحقق من كلمة المرور. عندما تكون الحماية موجودة، تحقق من القيمة المقدمة باستخدام [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **سير عمل مسار الملف**

المثال التالي يتحقق من كلمة مرور افتتاحية لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)، ثم يحمل العرض التقديمي كاملًا:

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

يوفر التحميل عبر التيار للطريقة [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) نفس سير العمل. أعد تعيين موضع التيار القابل للبحث قبل تحميل العرض التقديمي الكامل من ذلك التيار.

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

### **قِيَم إرجاع checkPassword**

يرجع [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) `true` فقط عندما يكون للعرض التقديمي كلمة مرور افتتاحية ويكون كلمة المرور المقدمة صحيحة. يرجع `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض التقديمي لا يحتوي على كلمة مرور افتتاحية.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض التقديمي المحمَّل مشفرًا**

بعد تحميل عرض تقديمي بكلمة مرور صحيحة، افحص [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) لتأكيد أن العرض المصدر كان مشفرًا. لاكتشاف حماية كلمة المرور الافتتاحية قبل التحميل، استخدم `IPresentationInfo.isPasswordProtected` كما هو موضح أعلاه.

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

## **توصيات أمنية**

{{% alert color="warning" title="Security" %}}
لا تُسجِّل كلمات المرور الافتتاحية ولا تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحفظ كلمات المرور في الذاكرة فقط للمدة المطلوبة، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض مباشرةً.

قد تكشف خصائص المستند العامة أسماء المؤلفين والعناوين والموضوعات والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة حتى وإن كان محتوى العرض التقديمي مشفرًا. شفر البيانات الوصفية الحساسة مع العرض التقديمي. يجب أن يكون جعل الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما تحتاج الأنظمة إلى فهرسة أو تصنيف أو بحث أو إدارة الملف دون كلمة مرور افتتاحية.
{{% /alert %}}

## **حماية العرض التقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض عند العرض.
1. اختياريًا، أدخل كلمة مرور منفصلة لحماية التعديل.
1. طبّق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ar/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة المرور الافتتاحية وكلمة مرور الحماية من الكتابة؟**

كلمة المرور الافتتاحية تشفر العرض التقديمي وتُطلب لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور افتتاحية دون تحميل كل الشرائح؟**

نعم. احصل على معلومات العرض التقديمي، تحقق مما إذا كانت هناك حماية كلمة مرور افتتاحية، وحقق من صحة كلمة المرور قبل إنشاء مثيل كامل للعرض التقديمي.

**هل يمكن لتطبيق قراءة البيانات الوصفية دون كلمة المرور الافتتاحية؟**

نعم، ولكن فقط عندما يكون العرض مشفرًا مع تعطيل تشفير خصائص المستند. يجب على التطبيق حينها استخدام وضع التحميل المخصص للخصائص الوصفية كما هو موضح في [Manage Presentation Properties](/slides/ar/androidjava/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كلا من PPT و PPTX؟**

نعم. سلوك الكشف عن كلمة المرور وتحققها عبر مسار الملف أو التيار يتم بنفس الطريقة لعروض PPT و PPTX.