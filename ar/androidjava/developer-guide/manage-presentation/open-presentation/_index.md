---
title: فتح العروض التقديمية على Android
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/androidjava/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- Android
- Java
- Aspose.Slides
description: "تعرف على كيفية فتح عروض PowerPoint وOpenDocument على Android، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides لأندرويد عبر Java."
---
## **المقدمة**

[Aspose.Slides for Android عبر Java](https://products.aspose.com/slides/ar/androidjava/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات والتدفقات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل من خلال الفئة [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض الأصلي](/slides/ar/androidjava/detect-presentation-source-format/) لتختار كيفية معالجة التطبيق له.

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). احرص على التخلص من كائن العرض بعد الاستخدام لتحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد على الفور.

المثال التالي بلغة Java يوضح كيفية فتح عرض تقديمي والحصول على عدد شرائحه:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **فتح العروض المحمية بكلمة سر**

كلمة المرور للفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

للتعرف على كلمة المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/androidjava/presentation-properties/).

## **فتح العروض الكبيرة**

تُعيد الدالة [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بالملفات المؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

المثال التالي بلغة Java يوضح تحميل عرض كبير (مثال: 2 جيجابايت):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلاً حتى يتم التخلص من كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يكون هذا الكائن قيد الحياة.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء التحميل. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/androidjava/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

تقبل الدالة [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) تنفيذًا لـ[IResourceLoadingCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iresourceloadingcallback/). يمكن للاستدعاء توفير بيانات بديلة، إعادة توجيه المورد، استخدام المحمل الافتراضي، أو تخطي المورد. يُعد هذا مفيدًا عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **تحميل العروض بدون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getVbaProject--)؛
- بيانات OLE مدمجة، متاحة عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--)؛
- بيانات التحكم ActiveX، متاحة عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)`.

قم بتعيين [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، ولكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمَّل، لكن عملية العرض والتصدير قد تستبدل الخطوط. يمكنك [تكوين استبدال الخطوط](/slides/ar/androidjava/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/androidjava/custom-font/) لجعل النتيجة أكثر توقعًا.

**هل تحميل العرض يقوم أيضًا بتحميل وسائطه المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. يتم حل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوَّن وقد تكون غير متاحة إذا تعذر الوصول إلى مواقعها.