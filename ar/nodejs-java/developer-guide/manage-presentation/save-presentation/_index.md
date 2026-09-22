---
title: حفظ العروض التقديمية في جافا سكريبت
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/nodejs-java/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع العرض المحدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- Node.js
- JavaScript
- Aspose.Slides
description: "احفظ عروض PowerPoint وOpenDocument إلى ملفات أو تدفقات باستخدام JavaScript مع Aspose.Slides، وقم بتكوين إخراج PPTX وتقرير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [افتح عرضًا موجودًا](/slides/ar/nodejs-java/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لكتابة النتيجة. يمكن لـ Aspose.Slides لـ Node.js عبر Java حفظ عرض تقديمي إلى ملف أو تدفق بصيغ PowerPoint وOpenDocument وPDF وغيرها. تغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، قم بتمرير مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save). تحدد قيمة التنسيق نوع الملف الذي تنشئه Aspose.Slides.

المثال التالي ينشئ عرضًا تقديميًا ويحفظه كملف PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // إضافة أو تعديل محتوى العرض التقديمي هنا.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بالتنسيق الأصلي**

لأمثلة اكتشاف الملفات والتدفقات، وسلوك العروض التقديمية التي تم إنشاؤها حديثًا، والتمييز بين تنسيقات المصدر والإخراج، راجع [تحديد تنسيق العرض التقديمي الأصلي](/slides/ar/nodejs-java/detect-presentation-source-format/).

في تطبيق معالجة الدُفعات، قد لا يكون تنسيق الإدخال معروفًا مسبقًا. بعد تحميل ملف، اقرأ تنسيقه الأصلي من طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSourceFormat). مرّر قيمة [SourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sourceformat/) الناتجة إلى طريقة [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/#toSaveFormat) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) المقابلة، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لكتابة العرض التقديمي المعدل.

المثال الكامل التالي يعالج كل ملف في دليل الإدخال، يُحدّث عنوانه، ويحفظه إلى دليل الإخراج بالتنسيق الذي تم تحميله منه:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/#toSaveFormat) يطابق صيغ PPT وPPTX وODP وPPTM وPPSX وPPSM وPOTX وPOTM וPPS וPOT וOTP וFODP وPowerPoint XML إلى صيغ حفظ العروض التقديمية المقابلة. إنه يطابق صيغ المصدر للعروض فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يؤدي إلى حدوث خطأ.

تستخدم ملفات PPT وPPS وPOT القديمة نفس الحاوية الثنائية. عندما يتم تحميل مثل هذا العرض من تدفق دون امتداد ملف، قد يتم التعرف على ملف PPS أو POT على أنه PPT. إذا كانت هناك حاجة للحفاظ على هذه الأنواع الفرعية القديمة، احفظ اسم الملف الأصلي أو بيانات التعريف الخاصة بالتنسيق بشكل منفصل واستخدمه عند اختيار اسم ملف الإخراج وتنسيقه.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر تدفقًا قابلاً للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرض تقديمي جديد إلى تدفق ملف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد العرض الذي يفتح به PowerPoint العرض المحفوظ في البداية. استخدم طريقة [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setLastView) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض الشريحة الرئيس كعرض مبدئي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

لإنشاء ملف PPTX يتوافق مع ملف التعريف الصارم لـ Office Open XML، أنشئ مثيلًا من [PptxOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/) واستخدم طريقة [setConformance](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setConformance) مع [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). ثم مرّر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

يحدّ أرشيف ZIP القياسي الحجم المضغوط وغير المضغوط لكل إدخال، وحجم الأرشيف الكلي، وعدد الإدخالات. نظرًا لأن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. تُرفع امتدادات ZIP64 الحدود الخاصة بالحجم وعدد الإدخالات.

استخدم طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Never) يعطل امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Always) يكتب دائمًا امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
إذا تم استخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Never) ولم يتمكن العرض من التوافق مع حدود ZIP القياسية، سيؤدي عملية الحفظ إلى رمي استثناء [PptxException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف باستخدام طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). توفر فئة [CompressionLevel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/) القيم التالية:

- [None](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#None) يخزن البيانات بدون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط.
- [Level2](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level2) إلى [Level5](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level5) تفضّل تدريجيًا مخرجات أصغر على حساب سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level7) و[Level8](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level8) تفضّلان مخرجات أصغر أكثر على حساب سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أكثر وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

المثال التالي يستخدم أعلى مستوى ضغط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية دون تحديث المصغّر**

عند حفظ العرض كملف PPTX، تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في صورة المصغّر للوثيقة:

- `true` يعيد إنشاء المصغّر أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `false` يحافظ على المصغّر الحالي. إذا لم يكن للعرض مصغّر، لا تقوم Aspose.Slides بإنشائه.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث المصغّر الخاص به:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
إلغاء تحديث المصغّر يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم بالنسبة المئوية**

لمراقبة عملية الحفظ، نفّذ واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/) باستخدام وكيل Java ومرّر التنفيذ إلى طريقة [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). بعد ذلك تستدعي Aspose.Slides طريقة [IProgressCallback.reporting](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/#reporting-double-) بقيم التقدم أثناء التصدير.

المثال التالي يبلّغ عن تقدم تصدير PDF إلى وحدة التحكم:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مجانية مبنية على Aspose.Slides API. تقوم بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides الحفظ المتزايد أو “الحفظ السريع”?**  
لا. كل عملية حفظ تكتب ملفًا كاملاً بدلاً من تحديث الأجزاء التي تغيرت فقط.

**هل يمكن لعدة خيوط حفظ نفس مثيل Presentation؟**  
لا. مثيل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) [ليس آمنًا للآثيرات](/slides/ar/nodejs-java/multithreading/). يجب الوصول إلى كل مثيل وحفظه من خلال خيط واحد في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند حفظ عرض تقديمي؟**  
تظل [الروابط التشعبية](/slides/ar/nodejs-java/manage-hyperlinks/) في العرض التقديمي. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذلك يجب أن يكون بإمكان العرض المحفوظ الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف، العنوان، الشركة، وتاريخ الإنشاء؟**  
نعم. اضبط [خصائص المستند](/slides/ar/nodejs-java/presentation-properties/) المناسبة قبل الحفظ، وستقوم Aspose.Slides بكتابتها إلى ملف الإخراج.