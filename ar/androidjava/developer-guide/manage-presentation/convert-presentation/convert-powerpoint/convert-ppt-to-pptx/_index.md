---
title: "تحويل PPT إلى PPTX على Android"
linktitle: "PPT إلى PPTX"
type: docs
weight: 20
url: /ar/androidjava/convert-ppt-to-pptx/
keywords:
- "تحويل PowerPoint"
- "تحويل عرض تقديمي"
- "تحويل شريحة"
- "تحويل PPT"
- "PPT إلى PPTX"
- "حفظ PPT كـ PPTX"
- "تصدير PPT إلى PPTX"
- "PowerPoint"
- "عرض تقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "تحويل ملفات PPT القديمة إلى PPTX على Android باستخدام Aspose.Slides. يتضمن أمثلة Java للتحويل الفردي وتحويل الدفعات، ومعالجة الأخطاء، وملاحظات الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Android عبر Java تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. تُظهر هذه المقالة كيفية تحويل ملف واحد أو دليل من الملفات وتوضح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Pptx). تقوم كتلة `finally` بتحرير العرض وتحرير موارده.

```java
// تحميل عرض PPT القديم.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // حفظ العرض بصيغة PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

امتداد الملف لا يحدد تنسيق الإخراج بحد ذاته؛ المعامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/#Pptx) هو الذي يحدده. حافظ على مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذلك فشل تحويل واحد لا يوقف ما تبقى من الدفعة.

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

لأحمال الإنتاج، سجّل الاستثناء الكامل، وحدد ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة محاولة أو مراجعة. يمكن أن تتسبب الملفات التالفة، والملفات المحمية بكلمة مرور المفتوحة بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعم في فشل التحويل. راجع [Password-Protected Presentations](/androidjava/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، والقوالب الرئيسية، والتخطيطات، والنص، والأشكال، والصور، والجداول، والمخططات. ومع ذلك، لا تمثل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تعديل أو حذف أو عرض بشكل مختلف أي ميزة قديمة لا يوجد لها مكافئ في PPTX أو غير مدعومة من المكتبة.

تحقق من الملف المحوَّل عندما يحتوي على رسومات متحركة، أو انتقالات، أو كائنات OLE مضمَّنة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مضمَّنة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما يجب التأكد من توفر الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحوَّل.

 للمستندات المهمة، أعد فتح ملف PPTX المُنشأ برمجيًا وتفحص عدد الشرائح ومحتواها الرئيسي، ثم قارن مظهره وسلوك تشغيل الشرائح في المشاهد المقصود. لا تُعَدّ استدعاء ناجح لـ [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) دليلًا على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى تستخدم PPTX**

استخدم PPTX عندما يتم تعديل العرض في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تعمل مع حزم Open XML، أو تخزينه بتنسيق يسهل فحصه واستعادته مقارنةً بـ PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض المحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) بدلاً من افتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **محول عبر الإنترنت**

لملف عرضي أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعية أو معالجة الأخطاء على مستوى التطبيق، استخدم API Android عبر Java.

## **مقالات ذات صلة**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for Android عبر Java بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على كل المحتوى بدقة؟**

يحافظ على محتوى العرض الشائع، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنتَج عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا زوّدت كلمة المرور الصحيحة عند تحميل الملف. يؤدي عدم وجود كلمة مرور أو كلمة مرور غير صحيحة إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصلي حتى تتأكد من صحة PPTX في المشاهد وسير العمل التي تهمك. هذا يوفِّر نسخة احتياطية للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.