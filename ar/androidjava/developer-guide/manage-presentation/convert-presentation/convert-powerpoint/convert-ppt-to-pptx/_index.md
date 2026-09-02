---
title: تحويل PPT إلى PPTX على Android
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/androidjava/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX على Android باستخدام Aspose.Slides. يتضمن أمثلة Java للتحويل الفردي وتحويل الدُفعات، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Android عبر Java تحميل ملف PPT وحفظه كـ PPTX بدون Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو دليل من الملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Pptx). يُفرغ كتلة `finally` العرض وتحرّر موارده.

```java
// تحميل عرض PPT القديم.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // حفظ العرض بتنسيق PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

امتداد الملف لا يحدد تنسيق الإخراج بحد ذاته؛ بل يقوم بذلك المعامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Pptx). احرص على اختلاف مسارات الإدخال والإخراج إذا كنت تحتاج إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذا عدم نجاح تحويل أحد الملفات لا يوقف باقي الدفعة.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

في بيئات الإنتاج، سجِّل الاستثناء الكامل، وقرر ما إذا كان من الممكن كتابة فوق ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة محاولة أو مراجعة. يمكن أن تتسبب الملفات التالفة، والملفات المحمية بكلمة مرور تم فتحها بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعًا في فشل التحويل. راجع [العروض التقديمية المحمية بكلمة مرور](/androidjava/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما تحتفظ عملية التحويل بالشرائح، والقوالب، والتنسيقات، والنص، والأشكال، والصور، والجداول، والرسوم البيانية. ومع ذلك، لا تمثل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تعديل أو حذف أو عرض مختلف لميزة قديمة لا يوجد لها مايلف في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على حركات، أو انتقالات، أو كائنات OLE مضمنة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مدمجة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح فيها أو يُعرض فيها العرض التقديمي المحوّل.

بالنسبة للمستندات الهامة، أعد فتح ملف PPTX المُولَّد برمجيًا وتفقد عدد الشرائح الرئيسية ومحتواها، ثم قارن مظهره وسلوك عرض الشرائح في العارض المقصود. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض التقديمي في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تتعامل مع حزم Open XML، أو تخزينه في تنسيق أسهل للفحص والاستعادة مقارنةً بتنسيق PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو نسخة احتياطية حتى يجتاز العرض التقديمي المحوّل فحوصات الدقة الخاصة بك.

إذا كنت بحاجة إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم إرشادات التنسيق المحدد في [تحويل العروض التقديمية إلى صيغ متعددة](/slides/ar/androidjava/convert-presentation/) بدلاً من افتراض أن جميع الأهداف تحفظ ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عرضي أو مقارنة سريعة، يمكنك استخدام [محول PPT إلى PPTX عبر الإنترنت](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). لإجراء التحويلات المتكررة أو المعالجة الدفعية أو التعامل مع الأخطاء على مستوى التطبيق، استخدم API Android عبر Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/androidjava/ppt-vs-pptx/)
- [حفظ العروض التقديمية على Android](/slides/ar/androidjava/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/androidjava/supported-file-formats/)
- [فتح العروض التقديمية على Android](/slides/ar/androidjava/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for Android عبر Java بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ تحويل PPT إلى PPTX على جميع المحتويات بدقة؟**

إنه يحافظ على المحتوى الشائع للعرض التقديمي، لكن لا يُضمن الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُولَّد عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو حركات متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. عدم وجود كلمة مرور أو كلمة مرور غير صحيحة يتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تقوم بالتحقق من PPTX في العارضات وسير العمل التي تهمك. هذا يضمن وجود نسخة احتياطية في حال تم تحويل ميزة قديمة بطريقة مختلفة.