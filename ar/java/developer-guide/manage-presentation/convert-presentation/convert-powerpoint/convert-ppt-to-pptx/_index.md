---
title: تحويل PPT إلى PPTX في Java
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في Java باستخدام Aspose.Slides. يتضمن أمثلة Java للتحويل الفردي ومجموعات التحويل، ومعالجة الأخطاء، وملاحظات الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. Aspose.Slides for Java يمكنه تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. توضح هذه المقالة طريقة تحويل ملف واحد أو دليل من الملفات وتشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل الملف المصدر باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/#Pptx). يقوم الكتلة `finally` بتحرير العرض وتحرير موارده.

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

امتداد الملف لا يحدد تنسيق الإخراج بحد ذاته؛ إنما حجة [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/#Pptx) هي التي تحدد ذلك. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت تحتاج إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف على حدة، لذا فإن فشل تحويل ملف واحد لا يوقف باقي الدفعة.

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

لأحمال الإنتاج، سجّل الاستثناء بالكامل، وحدد ما إذا كان يمكن استبدال ملف الإخراج الحالي، واكتب أسماء الملفات الفاشلة إلى طابور إعادة المحاولة أو المراجعة. قد تتسبب الملفات التالفة أو الملفات المحمية بكلمة مرور والتي تُفتح بدون كلمة المرور المطلوبة أو المسارات غير القابلة للوصول أو المحتوى غير المدعوم في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب الرئيسية، التخطيطات، النص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض بشكل مختلف ميزة قديمة لا يوجد لها ما يعادلها في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على رسوم متحركة، انتقالات، كائنات OLE مدمجة أو مرتبطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو وحدات ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما تحتاج إلى الحفاظ على VBA. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحوّل.

للمستندات الهامة، أعد فتح PPTX المُولد برمجيًا وافحص عدد الشرائح الرئيسية والمحتوى، ثم قارن مظهره وسلوك عرض الشرائح في المشغّل المستهدف. لا تُعامل استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) الناجح كدليل على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى يتم استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض في إصدارات PowerPoint الحالية، أو عند تبادله مع أنظمة تعمل مع حزم Open XML، أو حفظه بتنسيق أسهل للفحص والاستعادة من تنسيق PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو نسخة استرجاع حتى يجتاز العرض المحوّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو نوع إخراج آخر بدلاً من ذلك، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/java/convert-presentation/) بدلاً من الافتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف واحد عرضيًا أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفقية أو المعالجة البرمجية للأخطاء، استخدم واجهة برمجة تطبيقات Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في Java](/slides/ar/java/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/java/supported-file-formats/)
- [فتح العروض التقديمية في Java](/slides/ar/java/open-presentation/)

## **الأسئلة المتكررة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. Aspose.Slides for Java يحمل ويحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة؟**

إنه يحافظ على محتوى العرض التقديمي الشائع، لكن لا يمكن ضمان الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف الناتج عندما يحتوي على وحدات ماكرو أو كائنات OLE أو ActiveX أو وسائط أو رسوم متحركة متخصصة أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. عدم توفير كلمة مرور أو كلمة مرور غير صحيحة سيؤدي إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصل حتى تتحقق من PPTX في المشغلات وسير العمل التي تهمك. هذا يوفر نسخة احتياطية في حال تم تحويل ميزة قديمة بشكل مختلف.