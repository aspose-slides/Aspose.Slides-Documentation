---
title: تحويل PPT إلى PPTX في Node.js
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/nodejs-java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في Node.js باستخدام Aspose.Slides. يتضمن أمثلة JavaScript للتحويل الفردي والدفعي، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Node.js عبر Java تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو دليل يحتوي على ملفات ويشرح ما يلزم التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). تقوم كتلة `finally` بتحرير العرض وإصدار موارده.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// تحميل عرض PPT القديم.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // حفظ العرض بتنسيق PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

امتداد الملف لا يحدد تنسيق الإخراج بحد ذاته؛ إنما المعامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) هو الذي يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت تحتاج إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذا فإن فشل تحويل ملف واحد لا يوقف باقي الدفعة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

لأعباء العمل الإنتاجية، سجِّل الخطأ بالكامل، قرّر ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة المحاولة أو المراجعة. قد تتسبب الملفات التالفة، الملفات المحمية بكلمة مرور المفتوحة بدون كلمة المرور المطلوبة، المسارات غير القابلة للوصول، والمحتوى غير المدعوم في فشل التحويل. راجع [العروض التقديمية المحمية بكلمة مرور](/nodejs-java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

تحافظ عملية التحويل عادةً على الشرائح، القوالب، التخطيطات، النصوص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثل كل من PPT و PPTX كل ميزة بنفس الطريقة. قد يتم تعديل أو حذف أو عرض مختلف لميزة قديمة لا يوجد لها نظير في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحول عندما يحتوي على رسوم متحركة، انتقالات، كائنات OLE مدمجة أو مرتبطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو ماكرو VBA. الملف PPTX العادي ليس صيغة تدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيُفتح أو يُعرض فيها العرض المحول.

للمستندات الهامة، أعد فتح ملف PPTX المولد برمجيًا وتفقد عدد الشرائح الرئيسية والمحتوى، ثم قارن مظهره وسلوك عرض الشرائح في العارض المقصود. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى تستخدم PPTX**

استخدم PPTX عندما يُعدُّ العرض محلاً للتحرير في إصدارات PowerPoint الحالية، أو يتم تبادله مع أنظمة تتعامل مع حزم Open XML، أو يُخزن بصيغة أسهل للفحص والاسترداد مقارنةً بتنسيق PPT الثنائي القديم. احتفظ بنسخة PPT الأصلية كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض المحول فحوصات الدقة الخاصة بك.

إذا كنت بحاجة إلى PDF أو HTML أو صور أو XPS أو أي نوع خروج آخر، استخدم الإرشادات الخاصة بالتنسيق في [تحويل العروض إلى تنسيقات متعددة](/nodejs-java/convert-presentation/) بدلاً من افتراض أن جميع الأهداف ستحافظ على ميزات PowerPoint القابلة للتحرير.

## **محول على الإنترنت**

لملف عرضي أو مقارنة سريعة، يمكنك استخدام [محول PPT إلى PPTX على الإنترنت](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعية أو التعامل مع الأخطاء على مستوى التطبيق، استخدم واجهة Node.js عبر Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/nodejs-java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في Node.js](/nodejs-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/nodejs-java/supported-file-formats/)
- [فتح العروض التقديمية في Node.js](/nodejs-java/open-presentation/)

## **الأسئلة المتكررة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. تقوم Aspose.Slides for Node.js عبر Java بتحميل وحفظ ملفات العروض دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على كل المحتوى بدقة مطلقة؟**

يحافظ على محتوى العرض الشائع، لكن لا يُضمن الحفاظ على الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المولد عندما يحتوي على ماكروهات، كائنات OLE أو ActiveX، وسائط، رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا زودت كلمة المرور الصحيحة عند تحميل الملف. عدم توفير كلمة المرور أو توفير كلمة غير صحيحة يؤدي إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتحقق من PPTX في العارضين وسير العمل الذين يهمك الأمر. هذا يضمن وجود نسخة للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.