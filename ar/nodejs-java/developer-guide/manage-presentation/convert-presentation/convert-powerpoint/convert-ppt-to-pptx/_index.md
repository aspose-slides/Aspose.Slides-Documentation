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
description: "تحويل ملفات PPT القديمة إلى PPTX في Node.js باستخدام Aspose.Slides. يتضمن أمثلة JavaScript للتحويل الفردي والتحويل الدفعي، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، ثم استدعِ الدالة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) مع المتغيّر [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). يقوم كتلة `finally` بتحرير العرض وإطلاق موارده.

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

امتداد الملف لا يحدد تنسيق الإخراج بنفسه؛ بل يتحدد عبر معامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). احتفظ بمسارات الإدخال والإخراج مختلفة إذا كنت بحاجة للاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذلك فشل تحويل واحد لا يوقف باقي الدفعة.

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

في بيئات الإنتاج، سجّل الخطأ بالكامل، وقرّر ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة انتظار لإعادة المحاولة أو المراجعة. يمكن أن تتسبب الملفات الفاسدة، والملفات المحمية بكلمة مرور تُفتح بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعها في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/nodejs-java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب الرئيسية، التخطيطات، النص، الأشكال، الصور، الجداول، والرسوم البيانية. مع ذلك، لا تمثل صيغتي PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تعديل أو حذف أو عرض مختلف لميزة قديمة لا يوجد لها ما يعادلها في PPTX أو لا تدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على رسوم متحركة، انتقالات، كائنات OLE مدمجة أو مرتبطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس صيغة تدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كذلك تأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحوّل.

بالنسبة للمستندات الهامة، افتح ملف PPTX المُولد برمجيًا وفحص عدد الشرائح الرئيسي والمحتوى، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المستهدف. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى تُستخدم PPTX**

استخدم PPTX عندما سيتم تحرير العرض في إصدارات PowerPoint الحالية، أو تبادله مع الأنظمة التي تتعامل مع حزم Open XML، أو تخزينه بصيغة أسهل للفحص والاستعادة مقارنةً بصيغة PPT الثنائية القديمة. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو نسخة استرجاعية حتى يجتاز العرض المحوّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم إرشادات الفئات المحددة في [Convert Presentations to Multiple Formats](/slides/ar/nodejs-java/convert-presentation/) بدلاً من افتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عارض أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدُفعية أو معالجة الأخطاء على مستوى التطبيق، استخدم API Node.js عبر Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/nodejs-java/ppt-vs-pptx/)
- [حفظ العروض في Node.js](/slides/ar/nodejs-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/nodejs-java/supported-file-formats/)
- [فتح العروض في Node.js](/slides/ar/nodejs-java/open-presentation/)

## **الأسئلة المتكررة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. Aspose.Slides لـ Node.js عبر Java يقوم بتحميل وحفظ ملفات العروض دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ تحويل PPT إلى PPTX على جميع المحتويات بدقة؟**

إنه يحافظ على محتوى العرض الشائع، لكن الدقة الكاملة ليست مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنشأ عندما يحتوي على ماكرو، كائنات OLE أو ActiveX، وسائط، رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا زوّدت كلمة المرور الصحيحة عند تحميل الملف. كلمة مرور مفقودة أو غير صحيحة تتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصل حتى تتأكد من صحة ملف PPTX في المشاهد وسير العمل الذين يهمونك. هذا يوفر نسخة استرجاعية إذا تم تحويل ميزة قديمة بطريقة مختلفة.