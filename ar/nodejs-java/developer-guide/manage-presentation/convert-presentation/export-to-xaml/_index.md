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
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML باستخدام JavaScript و Aspose.Slides—حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة مختصرة عن XAML، وتوضح طريقة حفظ العرض إلى XAML بالإعدادات الافتراضية، وتظهر كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الاحتياطي، وتوافق XAML مع الأنظمة المختلفة، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هي لغة توصيف تعتمد على XML تُستخدم لوصف واجهات المستخدم في أطر عمل مثل WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم مرئي أو كتابة وتحرير العلامات مباشرة.

## **تصدير العروض إلى XAML باستخدام الخيارات الافتراضية**

يوضح مثال JavaScript التالي كيفية تصدير عرض إلى XAML بالإعدادات الافتراضية:

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

بشكل افتراضي، يتم حفظ الشرائح المصدرة في مجلد فرعي يسمى `input` داخل دليل العمل الحالي للعملية. يتم إنشاء المجلد تلقائيًا، ويتم حفظ أي صور مطلوبة هناك أيضًا.

يُؤخذ اسم المجلد الناتج من اسم ملف المصدر بدون الامتداد. في Aspose.Slides for Node.js via Java 26.8، يُنتج تصدير `input.pptx` مسارًا متداخلًا مثل `input/input/Slide_1.xaml`. احتفظ بالمسارات الكاملة التي تم إنشاؤها عند معالجة المخرجات. يكون الإخراج الافتراضي نسبيًا إلى دليل العمل الحالي، وليس بالضرورة بجانب ملف الإدخال.

## **تصدير العروض إلى XAML باستخدام خيارات مخصصة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides للعرض إلى XAML.

لحفظ المخرجات في موقع مخصص، نفّذ [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) ومرّر مثيل تنفيذك إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

لإدراج الشرائح المخفية في مخرجات XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `true`، كما هو موضح في مثال JavaScript التالي:

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

## **التقاط جميع قطع XAML المتولدة**

قد ينتج تصدير XAML مستند XAML لكل شريحة تم تصديرها بالإضافة إلى صور وموارد داعمة منفصلة. عيّن [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) مخصصًا إلى [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) لاستلام هذه القطع بدلاً من استخدام الحافظ الافتراضي لنظام الملفات. ابدأ التصدير باستخدام الدالة المتعددة للمعلمات في [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) التي تقبل خيارات XAML.

في Node.js، نفّذ الواجهة Java باستخدام `java.newProxy` من حزمة `java` المستخدمة بواسطة Aspose.Slides. احتفظ بالوكيل فعالًا حتى يكتمل التصدير.

### **فهم دورة حياة الـ Callback**

المصدِّر يستدعي [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) بصورة منفصلة لكل قطعة متولدة:

- `path` يحدد القطعة وقد يتضمن أدلة نسبية. احفظ هذه المعلومات لأن XAML قد يشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات القطعة. يجب عدم تحويل الصور والموارد الثنائية الأخرى إلى نص.
- الحافظ مسؤول عن الاحتفاظ أو تخزين البيانات قبل الإرجاع. تنسخ الأمثلة كل مصفوفة بايت Java إلى مخزن Node.js مملوك للتطبيق.
- عُدّ التصدير ناجحًا فقط عندما تعود عملية حفظ العرض وتكتم جميع الـ callbacks بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث التخزين لاحقًا، أبلغ عن النجاح الإجمالي فقط بعد نجاح تلك الخطوة كذلك.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ينطبق أيضًا على الحافظ المخصص. الإعداد الافتراضي، `false`، يستبعد مستندات XAML للشرائح المخفية. تمرير `true` يضيفها وجميع الموارد المطلوبة لتصديرها. عدد الموارد يعتمد على العرض؛ لا تفترض وجود استدعاء واحد لكل شريحة أو ترتيب ثابت للـ callbacks.

### **التصدير إلى الذاكرة وفحص القطع**

هذا المثال الكامل يحمل `input.pptx`، يجمع كل قطعة في خريطة JavaScript من أسماء إلى مخازن، ويطبع الاسم والنوع وعدد البايتات. يحافظ على الأسماء المقدمة تمامًا. الأسماء المكررة تجعل المجموعة غير صالحة بدلاً من الكتابة فوق القطعة بصمت. يتحقق المثال من ذلك قبل استخدام النتائج.

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

        // فك ترميز XAML فقط، وفقط عندما يكون الفحص النصي مطلوبًا.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

فحص الامتدادات مفيد للتدقيق؛ احتفظ بجميع القطع، بما في ذلك أنواع الموارد غير المألوفة. اترك البايتات دون تعديل عند التخزين أو النقل. استخدم فك ترميز UTF-8 فقط لـ XAML الذي يحتاج إلى معالجة نصية.

### **حزم القطع المجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من أسمائه، ويكتب البايتات الأصلية إلى أرشيف ZIP باستخدام جسر Java. يُجمع ZIP في الذاكرة قبل حفظه إلى القرص. يميز اسم الأرشيف الفريد بين وظائف التصدير المتزامنة. تستخدم إدخالات ZIP شرطة مائلة أمامية وتحتفظ بالأدلة النسبية. تُرفض الأسماء غير الآمنة أو المتصادمة بعد التطبيع قبل كتابة الحزمة.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // إغلاق ينهِ دليل ZIP قبل حفظ الأرشيف.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

يستخدم المثال [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) لكتابة أرشيف محلي واحد؛ المصدِّر نفسه لا يكتب ملفات XAML أو صور منفصلة. للتخزين البعيد، استبدل مرحلة كتابة الأرشيف بتحميل القطع المجمعة. استخدم معرف مهمة التصدير مع الاسم النسبي الكامل للقطعة كمفتاح لـ blob، أو خزن معرف المهمة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر المهمة فقط بعد اكتمال جميع التحميلات أو ارتكاب معاملة قاعدة البيانات. نظف المخرجات الجزئية إذا فشل التخزين.

للعروض الكبيرة، يمكن للحافظ المخصص تخزين كل قطعة مباشرة في تخزين التطبيق لتجنب الاحتفاظ بنسخة إضافية من التصدير بالكامل في الذاكرة. حافظ على تزامن كل callback من منظور المصدِّر: عُد فقط بعد أن يقبل الوجهة البايتات، واسمح للأخطاء بالوصول إلى المستدعي.

### **حفظ أسماء الموارد والتحقق من المراجع**

- طوّع فواصل المسار عندما يتطلب الوجهة ذلك، لكن حافظ على الأدلة النسبية. لا تستخدم الاسم الأساسي فقط إلا إذا كان كل اسم مولد فريدًا ومراجع الموارد لا تزال صالحة.
- طبّق فحصًا خاصًا بالوجهة لأسماء الملفات. عند كتابة ملفات منفصلة، ارفض المسارات الجذرية و segments الانتقالية، حلّ الوجهة إلى مسار مطلق، وتحقق من بقائه تحت دليل التصدير المستهدف، بما في ذلك فاصل الدليل في فحص الاحتواء. استخدم دليلًا يتحكم به التطبيق دون روابط رمزية قد تعيد توجيه الكتابة.
- استخدم حافظًا ونطاق تخزين منفصل لكل مهمة تصدير. اكتشف التصادمات بعد تطبيع الفاصل وبحسب حساسية حالة الأحرف للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وافحص مراجع الموارد القائمة على الملفات، مثل صفة `Source` أو `ImageSource` للصور. حل كل URI نسبي مقابل دليل القطعة XAML الحاوية، طوّع الاسم الناتج، وتأكد من وجود المفتاح المقابل في الخريطة أو إدخال ZIP أو الكائن المخزن. عالج URIs الخارجية وتعبيرات XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `input/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `input/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذه العلاقة. لتخزين الكائنات، احفظ نفس البنية تحت بادئة المهمة واجعل عناوين URL لتلك الموارد متاحة لمستهلك XAML. أعد فتح ملف ZIP المكتمل للتحقق من أسماء الإدخالات و بايتات الموارد، وحمّل شرائح نموذجية في بيئة XAML الهدف للتأكد من أن الصور تُحلّ بنجاح.

## **الأسئلة الشائعة**

**كيف يمكنني ضمان خط ثابت إذا لم يتوفر الخط الأصلي على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الأصلي غير موجود. هذا لا يضمن أن XAML المتولد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من أن الخطوط المشار إليها في XAML متوفرة في البيئة التي يُعرض فيها.

**هل XAML المصدّر مخصص فقط لـ WPF، أم يمكن استخدامه مع أنظمة XAML أخرى أيضًا؟**

تصدّر Aspose.Slides XAML لـ WPF عبر واجهته العامة. لا يضمن التوافق مع أنظمة XAML أخرى مثل UWP وXamarin.Forms. اختبر العلامات المتولدة في بيئتك المستهدفة.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — أبقها غير مفعلة إذا لم تكن بحاجة لتصديرها.