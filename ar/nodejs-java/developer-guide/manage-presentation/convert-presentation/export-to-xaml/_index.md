---
title: تصدير العروض التقديمية إلى XAML باستخدام JavaScript
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/nodejs-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في JavaScript باستخدام Aspose.Slides—حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---
## **نظرة عامة**

يشرح هذا المقال كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. يتضمن مقدمة موجزة عن XAML، ويظهر كيفية حفظ عرض تقديمي إلى XAML بالإعدادات الافتراضية، ويعرض كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. يجيب المقال أيضًا على بعض الأسئلة الشائعة المتعلقة بخطوط الاستبدال، توافق مجموعة XAML، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هو لغة توصيف تعتمد على XML تُستخدم لوصف واجهات المستخدم في أطر العمل مثل WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم مرئي أو كتابة التوصيف وتحريره مباشرة.

## **تصدير العروض إلى XAML باستخدام الإعدادات الافتراضية**

يوضح المثال التالي بلغة JavaScript كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

بشكل افتراضي، يتم حفظ الشرائح المصدرة في مجلد فرعي `input` داخل الدليل الحالي للعملية. يتم إنشاء المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُؤخذ اسم مجلد الإخراج من اسم ملف المصدر بدون الامتداد. في Aspose.Slides for Node.js via Java 26.8، ينتج تصدير `input.pptx` مسارًا متداخلًا مثل `input/input/Slide_1.xaml`. احتفظ بالمسارات الكاملة التي تم إنشاؤها عند التعامل مع الإخراج. الإخراج الافتراضي يكون نسبيًا بالنسبة للدليل الحالي للعمل، وليس بالضرورة بجوار ملف الإدخال.

## **تصدير العروض إلى XAML باستخدام خيارات مخصصة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides للعرض إلى XAML.

لحفظ الإخراج في موقع مخصص، قم بتنفيذ [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) ومرّر مثيل تنفيذك إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) في [XamlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/).

لتضمين الشرائح المخفية في إخراج XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `true`، كما هو موضح في المثال التالي بلغة JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **التقاط جميع الكائنات التي تم إنشاؤها بصيغة XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة تم تصديرها بالإضافة إلى صور وموارد مساعدة منفصلة. قم بتعيين [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) مخصص إلى [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) لتلقي هذه الكائنات بدلاً من استخدام الحفظ الافتراضي على نظام الملفات. ابدأ التصدير باستخدام التحميل الزائد لـ [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) الذي يقبل خيارات XAML.

في Node.js، نفّذ الواجهة Java باستخدام `java.newProxy` من حزمة `java` التي يستخدمها Aspose.Slides. حافظ على وصول الوكيل حتى يكتمل التصدير.

### **فهم دورة حياة رد النداء**

يقوم المُصدّر باستدعاء [IXamlOutputSaver.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) بشكل منفصل لكل كائن تم إنشاؤه:

- `path` يحدد الكائن وقد يتضمن دلائل نسبية. احتفظ بهذه المعلومات لأن XAML قد يشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات الكائن. يجب عدم فك تشفير الصور والموارد الثنائية الأخرى كنص.
- يتحمل الحافظ مسؤولية الاحتفاظ أو حفظ البيانات قبل الإرجاع. النسخ النموذجية تنسخ كل مصفوفة بايت Java إلى مخزن Node.js مملوك للتطبيق.
- اعتبر عملية التصدير ناجحة فقط عندما تعود عملية حفظ العرض وتكتمل كل ردود النداء بنجاح. لا تُهمش أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث الإيداع لاحقًا، فاعلِن النجاح الكلي فقط بعد أن ينجح هذا الخطوة أيضًا.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ينطبق أيضًا على الحافظ المخصص. الإعداد الافتراضي، `false`، يستثني وثائق XAML للشرائح المخفية. تمرير `true` يضمن تضمينها وأي موارد مطلوبة لتصديرها. عدد الموارد يعتمد على العرض؛ لا تفترض وجود رد نداء واحد لكل شريحة أو ترتيب ثابت لردود النداء.

### **التصدير إلى الذاكرة وفحص الكائنات**

هذا المثال الكامل يحمل `input.pptx`، يجمع كل كائن في خريطة JavaScript من أسماء إلى مخازن، ويطبع اسمه ونوعه وعدد البايتات. يحافظ على الأسماء المقدمة بدقة. الأسماء المكررة تجعل التجميع غير صالح بدلاً من الكتابة الصامتة لكائن. يتحقق المثال من ذلك قبل استخدام النتائج.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // فك تشفير XAML فقط، وفقط عندما يكون الفحص النصي مطلوبًا.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

فحوصات الامتداد مفيدة للفحص؛ احتفظ بكل الكائنات، بما في ذلك أنواع الموارد غير المألوفة. لا تغير البايتات عند التخزين أو النقل. استخدم فك ترميز UTF-8 فقط لـ XAML الذي يحتاج إلى معالجة نصية.

### **تجميع الكائنات المجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من أسمائه، ويكتب البايتات الأصلية إلى أرشيف ZIP باستخدام جسر Java. يتم تجميع ZIP في الذاكرة قبل حفظه على القرص. اسم الأرشيف الفريد يفصل بين وظائف التصدير المتزامنة. تستخدم إدخالات ZIP الشرط المائل للأمام وتحتفظ بالدلائل النسبية. تُرفض الأسماء غير الآمنة أو التي تتصادم بعد التطبيع قبل كتابة الحزمة بالكامل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // إغلاق العملية يُكمل دليل ZIP قبل حفظ الأرشيف.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

يستخدم المثال [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) لكتابة أرشيف محلي واحد؛ المُصدّر نفسه لا يكتب ملفات XAML أو صور منفصلة. للتخزين عن بعد، استبدل مرحلة كتابة الأرشيف بتحميل المصفوفات البايتية المجمعة. استخدم معرف وظيفة التصدير بالإضافة إلى اسم الكائن النسبي الكامل كمفتاح للكتلة، أو خزن معرف الوظيفة، الاسم النسبي، والبيانات الثنائية في صف قاعدة بيانات. انشر الوظيفة فقط بعد اكتمال جميع التحميلات أو التزامن على قاعدة البيانات. نظّف الإخراج الجزئي إذا فشل الإيداع.

لعروض تقديمية كبيرة، يمكن لمصرف مخصص حفظ كل كائن مباشرةً في تخزين التطبيق لتجنب الاحتفاظ بنسخة إضافية من التصدير الكامل في ذاكرة التطبيق. احفظ كل رد نداء متزامنًا من منظور المُصدّر: ارجع فقط بعد أن يقبل الوجهة البايتات، واسمح بفشل الأخطاء للوصول إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من المراجع**

- نمّط فواصل المسار عندما يتطلب الوجهة ذلك، لكن احتفظ بالدلائل النسبية. لا تستخدم الاسم الأساسي فقط ما لم تكن كل الأسماء المولدة معروفة بأنها فريدة وتظل مراجع الموارد صالحة.
- طبّق التحقق من صحة الاسم بحسب الوجهة. عند كتابة ملفات منفصلة، ارفض المسارات الجذرية وقطع التجوال، حل الوجهة إلى مسار مطلق، وتحقق من بقائها تحت دليل التصدير المقصود، مع تضمين فاصل الدليل في فحص الحاوية. استخدم دليلًا يتحكم فيه التطبيق دون روابط رمزية قد تُعيد توجيه الكتابة.
- استخدم حافظًا ومساحة اسم تخزين منفصلة لكل وظيفة تصدير. اكتشف التضارب بعد تطبيع الفواصل ووفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وافحص مراجع الموارد القائمة على الملفات، مثل سمات `Source` أو `ImageSource` للصور. حل كل URI نسبيًا ضد دليل الكائن XAML الحاوي، نمّط اسم التخزين الناتج، وتأكد من وجود المفتاح المطابق في الخريطة أو إدخال ZIP أو الكائن المخزن. عالج عناوين URI الخارجية وتعابير XAML بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `input/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `input/images/image1.png`. الاحتفاظ فقط بـ `image1.png` سيفسد ذلك العلاقة. في التخزين الكائني، احفظ نفس الهيكل تحت بادئة الوظيفة واجعل عناوين URL لتلك الموارد متاحة لمستهلك XAML. أعد فتح ZIP المكتمل للتحقق من أسماء الإدخالات و بايتات الموارد، وحمّل شرائح تمثيلية في بيئة XAML الهدف للتأكد من أن الصور تُحل بشكل صحيح.

## **الأسئلة المتداولة**

**كيف يمكنني ضمان خطوط ثابتة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الأصلي مفقودًا. هذا لا يضمن أن XAML المُولد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من أن الخطوط المشار إليها في XAML متوفرة في البيئة التي يُعرض فيها.

**هل XAML المصدّر مخصص فقط لـ WPF، أم يمكن استخدامه في مجموعات XAML أخرى أيضًا؟**

يقوم Aspose.Slides بتصدير XAML لـ WPF عبر API العامة له. لا يُضمن التوافق مع مجموعات XAML أخرى، مثل UWP وXamarin.Forms. اختبر التوصيف المُولد في بيئتك المستهدفة.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) في [XamlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/xamloptions/) — احتفظ به معطلاً إذا لم تكن بحاجة لتصديرها.