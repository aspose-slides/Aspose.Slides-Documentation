---
title: تحويل عروض PowerPoint إلى Markdown في JavaScript
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صورة Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في JavaScript والتحكم في مكان حفظ الصور bitmap وmetafile وSVG والإشارة إليها."
---
## **نظرة عامة**

Aspose.Slides لـ Node.js عبر Java يمكنه تحويل عروض PPT و PPTX إلى Markdown للتوثيق، ومواقع الاستاتيكية، وهجرة المحتوى، وسير عمل التحكم بالإصدارات. يمكنك اختيار نوع Markdown، التحكم في طريقة عرض محتوى الشرائح، وتحديد أين تُحفظ الصور المُصدَّرة وكيف يتم الإشارة إليها في Markdown الذي يتم إنشاؤه.

بشكل افتراضي، تصدير Markdown يستخدم نصًا فقط. لتصدير المحتوى المرئي، اضبط نوع التصدير باستخدام طريقة [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) لتكون القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` يُظهر عناصر الشريحة بشكل منفصل ووفق الترتيب، بينما `Visual` يبقي العناصر المجمعة معًا للحفاظ على علاقتها البصرية. القيمة `TextOnly` لا تُصدر موارد الصور، لذا لا تُستدعى ردود النداء لحفظ الصور في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

حمِّل الملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **اختيار نمط Markdown**

طريقة [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) تتحكم في مواصفات Markdown المستخدمة في الإخراج. تعداد [Flavor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/flavor/) يتضمن CommonMark، وGitHub Flavored Markdown، وغيرها من المتغيرات المدعومة.

المثال التالي يصدر عرضًا تقديميًا كـ CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) توفر طريقتين لتكوين حفظ الصور محليًا:

- [setBasePath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) يحدد الدليل الأساسي لوثيقة Markdown ومواردها.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) يحدد المجلد الفرعي للصور. قيمته الافتراضية هي `Images`.

المثال التالي يُظهر المحتوى المرئي، يكتب الصور إلى `output/assets`، وينشئ إشارات صور نسبية في وثيقة Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

هذا السلوك يعمل أيضًا كاحتياط عندما يُعيد معالج حفظ الصور المخصص القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم طريقة [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) لتسجيل رد نداء للموارد bitmap وmetafile غير SVG التي تُصدر أثناء تصدير Markdown. رد النداء `MarkdownImageSavingHandler` يتلقى كائن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/)، قيمته [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/)، ومصفوفة السلسلة ذات العنصر الواحد التي تحتوي على رابط Markdown الناتج. احفظ أو حمِّل الصورة بالتنسيق المقدم، واستبدل `link[0]` بالإشارة التي يجب أن تظهر في إخراج Markdown.

الموارد التي تُصدر بصيغة SVG تُعالج بشكل منفصل. سجِّل رد نداء باستخدام طريقة [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/). رد النداء `MarkdownSvgImageSavingHandler` يتلقى كائن `ISvgImage` ومصفوفة `link` ذات العنصر الواحد. لا يوجد وسيط `ImageFormat` للـ SVG؛ اكتب أو حمِّل بيانات XML من طريقة `ISvgImage.getSvgData` بدلاً من ذلك. بناءً على وضع التصدير وتجمّع العناصر البصرية، قد يتم تحويل SVG في العرض المصدر إلى نقطية أو دمجها مع محتوى آخر؛ ثم تُمرَّر النتيجة غير SVG إلى رد نداء حفظ الصورة. سجِّل كلا ردَّي النداء عندما يتطلب كل مورد بصري مُصدَّر معالجة مخصصة.

في Node.js، أنشئ تطبيقات لهذه الواجهات باستخدام `java.newProxy`.

قيمة الإرجاع للمعالج تحدد من يعالج الصورة:

- أرجع `true` بعد أن يحفظ المعالج الصورة، أو يحمِّلها، أو يُحوِّلها، أو يعالجها بأي طريقة أخرى ويُعيّن قيمة صالحة إلى `link[0]`. يكتب Aspose.Slides تلك القيمة إلى وثيقة Markdown ولا يُجري الحفظ المحلي الافتراضي.
- أرجع `false` للسماح لـ Aspose.Slides بحفظ الصورة محليًا وتوليد رابطها وفق القيم المحددة بواسطة [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
معالج يُرجع `true` يتحمّل مسؤولية الصورة. إذا أرجع `true` دون تعيين رابط صالح غير فارغ، يفشل التصدير بـ `InvalidOperationException`.
{{% /alert %}}

### **حفظ الصور في دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يعتبر `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مُركَّب أو مُزامن. كل معالج يستخرج اسم الملف المُولَّد، يحفظ الصورة في ذلك الدليل المخصص، ويستبدل الإشارة المحلية المُولَّدة بعنوان URL عام على الـ CDN. العينة نفسها لا تُجري أي تحميل شبكي: يصبح URL صالحًا فقط بعد تركيب الدليل كأصل CDN أو نشر ملفاته على الـ CDN. لتخزين الكائنات، استبدل كتابة نظام الملفات بعملية تحميل SDK التخزينية وعيّن `link[0]` فقط بعد نجاح التحميل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

المعالج bitmap يُعيد عمدًا `false` للصور أصغر من 128 × 128 بكسل، لذا يحفظ Aspose.Slides تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد bitmap وmetafile الأكبر، بالإضافة إلى موارد SVG، بواسطة الشيفرة المخصصة. على سبيل المثال، الإشارة المحلية `fallback-images/image1.png` تصبح `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ الروابط المكتوبة في Markdown تستخدم الشرط المائل `/` وأسماء الملفات المشفَّرة في URL. اتبع نفس القاعدة عند بناء الروابط النسبية: استخدم `/`، لا separator الخاص بالنظام.

## **الأسئلة المتكررة**

**هل يمكن لمعالج واحد معالجة كل من الصور النقطية وصور SVG؟**

لا. استخدم [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) للموارد bitmap وmetafile، واستخدم [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) للموارد المُصدَّرة كـ SVG. الأول يوفّر كائن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/); الثاني يوفّر كائن `ISvgImage` يمكن قراءة بيانات SVG منه عبر `ISvgImage.getSvgData`. يُعالج SVG المصدر الذي يُحوَّل إلى نقطية أثناء التصدير بواسطة رد نداء حفظ الصورة بدلاً من ذلك.

**ماذا يحدث عندما يُعيد معالج حفظ الصورة `false`؟**

يستخدم Aspose.Slides سلوكه الافتراضي لحفظ الصور محليًا. يتم التحكم في موقع الصورة والإشارة المُولَّدة بالقيم المحددة عبر [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/markdownsaveoptions/).

**هل يمكن للمعالج توفير URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمعالج تحميل الصورة إلى تخزين كائنات أو تمريرها إلى خدمة أخرى، تعيين URL الناتج إلى `link[0]`، وإرجاع `true`. يجب أن يُتم المعالج المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يرمي تصدير Markdown استثناء `InvalidOperationException` من المعالج؟**

يحدث هذا الاستثناء عندما يُرجع المعالج `true` دون توفير رابط صالح. عيّن المسار النسبي أو URL الخارجي الذي يجب كتابته إلى Markdown قبل إرجاع `true`.

**أي فاصل مسار يجب أن تُستخدمه روابط الصور؟**

استخدم الشرط المائل `/` في روابط Markdown وURL. استخدم `path.join` فقط لمسارات نظام الملفات، ثم كوّن أو عيّن مرجع Markdown بصورة منفصلة.

**هل تُحافظ الروابط التشعبية أثناء تصدير Markdown؟**

نعم. تُحافظ النصوص [hyperlinks](/slides/ar/nodejs-java/manage-hyperlinks/) كروابط Markdown قياسية. ولا تُحوَّل [transitions](/slides/ar/nodejs-java/slide-transition/) و[animations](/slides/ar/nodejs-java/powerpoint-animation/) للشرائح.

**هل يمكن تحويل العروض إلى Markdown بشكل متوازي؟**

يمكنك معالجة ملفات عروض مختلفة بشكل متوازي، لكن لا تشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/nodejs-java/multithreading/) واستخدم كائنًا منفصلًا لكل ملف.