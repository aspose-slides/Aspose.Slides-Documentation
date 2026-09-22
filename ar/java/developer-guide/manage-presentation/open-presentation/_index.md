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
- مصدر خارجي
- كائن ثنائي
- Java
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint و OpenDocument في Java، وتوفير كلمات مرور للفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides for Java."
---
## **المقدمة**

[Aspose.Slides for Java](https://products.aspose.com/slides/ar/java/) يمكنه تحميل عروض PowerPoint و OpenDocument من الملفات وتيارات البيانات. بعد تحميل العرض التقديمي، يمكنك فحص هيكله، تحرير الشرائح، إدارة الموارد، وحفظه بالصيغة الأصلية أو بصيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل من خلال فئة [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء كائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تيار، يمكنك [تحديد صيغة العرض التقديمي الأصلية](/slides/ar/java/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك له.

لفتح عرض تقديمي موجود، مرر مسار الملف إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). قم بتحرير العرض التقديمي بعد الاستخدام بحيث يتم تحرير مقابض الملفات والبيانات المؤقتة وغيرها من الموارد بسرعة.

المثال التالي بلغة Java يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

تشفّر كلمة المرور للفتح محتوى العرض التقديمي. لتحميل العرض بالكامل، مرر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للحصول على سير عمل كشف كلمة المرور، التحقق، والتشفير، راجع [Password-Protect Presentations](/slides/ar/java/password-protected-presentation/). إذا تم حفظ عرض تقديمي مشفر عمدًا بخصائص المستند العامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر إلى [Manage Presentation Properties](/slides/ar/java/presentation-properties/).

## **فتح العروض التقديمية الكبيرة**

ترجع [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) خيارات تتحكم في كيفية تعامل Aspose.Slides مع كائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفولًا، السماح بالملفات المؤقتة، وتحديد مقدار بيانات BLOB المحتفظ بها في الذاكرة.

الكود التالي بلغة Java يوضح تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):

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
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفولًا حتى يتم تحرير كائن العرض التقديمي. لا تقم بنقل، استبدال، أو حذف ملف المصدر طالما أن هذا الكائن لا يزال نشطًا.

قد تقوم Aspose.Slides بنسخ محتويات تيار الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عمومًا أكثر كفاءة من التيار. راجع [Manage BLOBs](/slides/ar/java/manage-blob/) للحصول على خيارات إضافية لتخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

تقبل [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/). يمكن للنداء الرجعي توفير بيانات بديلة، إعادة توجيه مورد، استخدام المحمّل الافتراضي، أو تخطي المورد. هذا مفيد عندما يحتوي العرض التقديمي على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

قد يحتوي العرض التقديمي على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getVbaProject--);
- بيانات OLE المدمجة، متاحة عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- بيانات التحكم ActiveX، متاحة عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

قم بتعيين [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض التقديمي المحمّل لتثبيت النتيجة المنقّاة.

يقلل هذا الخيار من التعرض للحمولات المدمجة غير المرغوبة، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

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

تطرح Aspose.Slides استثناءً في التحليل أو تنسيق أثناء التحميل. يجب التعامل مع هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض التقديمي أن يظل يُحمّل، لكن قد تستبدل الخطوط أثناء العرض والتصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/java/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/java/custom-font/) لجعل النتيجة أكثر قابلية للتنبؤ.

**هل تحميل عرض تقديمي يحمل أيضًا الوسائط المدمجة؟**

تصبح الصوتيات والفيديو المدمجين متاحين عبر نموذج كائن العرض التقديمي. يتم حل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوّن وقد تكون غير متاحة إذا لم يمكن الوصول إلى مواقعها.