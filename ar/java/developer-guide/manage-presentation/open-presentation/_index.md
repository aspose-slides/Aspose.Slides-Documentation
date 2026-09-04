---
title: فتح العروض التقديمية في Java
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/java/open-presentation/
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
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- Java
- Aspose.Slides
description: "تعلم كيف تفتح عروض PowerPoint و OpenDocument في Java، وتزويد كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides for Java."
---
## **المقدمة**

[Aspose.Slides for Java](https://products.aspose.com/slides/ar/java/) يمكنه تحميل عروض PowerPoint و OpenDocument من الملفات والمسارات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمنة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). حرّر (Dispose) العرض بعد الاستخدام بحيث يتم تحرير مقابض الملفات والبيانات المؤقتة وغيرها من الموارد بسرعة.

المثال التالي بلغة Java يوضح كيفية فتح عرض والحصول على عدد الشرائح:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **العروض المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للتعرف على كلمات المرور، والتحقق، وتدفقات العمل المتعلقة بالتشفير، راجع [Password-Protect Presentations](/slides/ar/java/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص المستند العامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ راجع [Manage Presentation Properties](/slides/ar/java/presentation-properties/).

## **فتح عروض كبيرة**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) تُعيد خيارات تتحكم في كيفية معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بالملفات المؤقتة، وتحديد مقدار بيانات BLOB المحتفظ بها في الذاكرة.

الكود التالي بلغة Java يوضح تحميل عرض كبير (مثلاً 2 جيجابايت):

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

مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلًا حتى يتم تحرير كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما تلك المثيلة لا تزال حية.

قد تنسخ Aspose.Slides محتوى تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/java/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.

{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) يقبل تنفيذًا لـ[IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/). يمكن للنداء المرتد تزويد بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض بدون الكائنات الثنائية المضمنة**

قد يحتوي العرض على بيانات ثنائية مضمّنة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، المتاحة عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getVbaProject--);
- بيانات OLE المضمّنة، المتاحة عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- بيانات التحكم ActiveX، المتاحة عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

عيّن [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمّل لتثبيت النتيجة المنقحة.

يقلل هذا الخيار من التعرض للحمولات المضمنة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

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

تقذف Aspose.Slides استثناءً متعلقًا بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

لا يزال بإمكان العرض التحميل، لكن قد يتم استبدال الخطوط أثناء العرض والتصدير. يمكنك [configure font substitution](/slides/ar/java/font-substitution/) أو [provide custom fonts](/slides/ar/java/custom-font/) لجعل الناتج أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا وسائطه المضمّنة؟**

تصبح ملفات الصوت والفيديو المضمّنة متاحة عبر نموذج كائن العرض. يتم حل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوَّن وقد تكون غير متوفرة إذا لم يمكن الوصول إلى مواقعها.