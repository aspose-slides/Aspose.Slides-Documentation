---
title: فتح العروض التقديمية على Android
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/androidjava/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- أندرويد
- جافا
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument على Android، وتزويد كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **مقدمة**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/ar/androidjava/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات والتيارات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو أي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/). على سبيل المثال، يمكن تقديم كلمة مرور الفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمّنة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشيء [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). حرّر العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد على الفور.

تُظهر مثال Java التالي كيفية فتح عرض والحصول على عدد الشرائح الخاصة به:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **فتح العروض المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) وقدم الخيارات إلى مُنشيء [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). سيفشل التحميل عندما تكون كلمة المرور مفقودة أو غير صحيحة.

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

للكشف عن كلمة المرور، والتحقق، وسير عمل التشفير، راجع [Password‑Protect Presentations](/slides/ar/androidjava/password-protected-presentation/). إذا تم حفظ عرض مشفر عمدًا بخصائص مستند عامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/androidjava/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) تُرجِع خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بملفات مؤقتة، وتقليل كمية بيانات BLOB المحتفظ بها في الذاكرة.

الكود Java التالي يوضح تحميل عرض كبير (مثلاً 2 GB):

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

{{% alert color="info" title="ملاحظة" %}}
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلاً حتى يتم تحرير مثيل العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما هذا المثيل ما زال حيًا.

قد يقوم Aspose.Slides بنسخ محتويات التيار المدخل أثناء التحميل. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التيار. راجع [Manage BLOBs](/slides/ar/androidjava/manage-blob/) للحصول على خيارات تخزين وإدارة ذاكرة إضافية.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) تقبل تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iresourceloadingcallback/). يمكن للرد الاتصال توفير بيانات بديلة، إعادة توجيه مورد، استخدام المحمّل الافتراضي، أو تخطي المورد. هذا مفيد عندما يحتوي العرض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض دون كائنات ثنائية مضمّنة**

قد يحتوي العرض على بيانات ثنائية مضمّنة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- بيانات OLE مضمّنة، متاحة عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- بيانات تحكم ActiveX، متاحة عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

قم بتعيين [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المُنقاة.

هذه الخيار يقلل من التعرض للحمولات المضمّنة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

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

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمَّل، لكن قد تستبدل الخطوط أثناء العرض أو التصدير. يمكنك [configure font substitution](/slides/ar/androidjava/font-substitution/) أو [provide custom fonts](/slides/ar/androidjava/custom-font/) لجعل الإخراج أكثر قابلية للتنبؤ.

**هل يحمّل تحميل العرض وسائطه المضمّنة أيضًا؟**

تصبح الملفات الصوتية والفيديو المضمّنة متاحة عبر نموذج كائن العرض. تُحل الموارد الخارجية وفق سلوك تحميل الموارد المكوّن وقد تكون غير متاحة إذا لم يمكن الوصول إلى مواقعها.