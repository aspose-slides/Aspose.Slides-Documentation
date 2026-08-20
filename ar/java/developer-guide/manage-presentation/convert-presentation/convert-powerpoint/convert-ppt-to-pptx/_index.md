---
title: تحويل PPT إلى PPTX باستخدام Java
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT بصيغة PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX باستخدام Java و Aspose.Slides. يتضمن أمثلة Java للتحويل الفردي والدفعي، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Java تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو دليل من الملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل الملف المصدر باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/#Pptx). يقوم كتلة `finally` بتحرير العرض وإطلاق موارده.

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

امتداد الملف لا يحدّد تنسيق الإخراج بمفرده؛ فمعامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/#Pptx) هو ما يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحوّل كل ملف `.ppt` في دليل واحد. يُعالج كل ملف على حدة، لذا فإن فشل تحويل ملف واحد لا يوقف باقي المجموعة.

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

لأحمال الإنتاج، سجِّل الاستثناء الكامل، قرّر ما إذا كان يمكن الكتابة فوق ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة محاولة أو مراجعة. قد تتسبب الملفات التالفة، والملفات المحمية بكلمة مرور التي تُفتح دون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعها في فشل التحويل. راجع [Password‑Protected Presentations](/java/password-protected-presentation/) لتحميل الملفات المشفّرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، والرؤوس الرئيسية، والتنسيقات، والنص، والأشكال، والصور، والجداول، والمخططات. ومع ذلك، لا تمثّل PPT و PPTX كل ميزة بنفس الطريقة. قد يتم تطبيع أو حذف أو عرض مختلف لميزة قديمة لا يوجد لها مكافئ في PPTX أو غير مدعومة بالمكتبة.

تحقق من الملف المحوَّل عندما يحتوي على حركات، أو انتقالات، أو كائنات OLE مدمجة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مدمجة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل مناسب يدعم الماكرو عندما يلزم بقاء VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيُفتح أو يُعرض فيها العرض المحوَّل.

بالنسبة للمستندات المهمة، أعد فتح ملف PPTX المُولد برمجيًا وتفقد عدد الشرائح والمحتوى الرئيسي، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المستهدف. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) الناجح دليلاً على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يُعاد تحرير العرض في إصدارات PowerPoint الحالية، أو يُتبادل مع أنظمة تتعامل مع حزم Open XML، أو يُخزن بتنسيق أسهل للفحص والاسترداد من PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو احتياطية حتى يجتاز العرض المحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع خروج آخر، استخدم الدليل المتخصص في [Convert Presentations to Multiple Formats](/java/convert-presentation/) بدلاً من الافتراض بأن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **محول عبر الإنترنت**

لملف عرض sporadic أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعية أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/java/ppt-vs-pptx/)
- [Save Presentations in Java](/java/save-presentation/)
- [Supported File Formats](/java/supported-file-formats/)
- [Open Presentations in Java](/java/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يُحمِّل Aspose.Slides for Java ملفات العروض ويحفظها دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على كل المحتوى بدقة كاملة؟**

يُحافظ على محتوى العرض الشائع، لكن لا يُضمن الحفاظ على الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُولد عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا زوّدت كلمة المرور الصحيحة عند تحميل الملف. كلمة مرور مفقودة أو غير صحيحة سيؤدي إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصل حتى تتأكد من صحة عرض PPTX في المشاهد وسير العمل الذي يهمك. هذا يضمن وجود نسخة احتياطية في حال تم تحويل ميزة قديمة بطريقة مختلفة.