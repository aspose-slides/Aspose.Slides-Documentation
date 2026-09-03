---
title: معالجة تحذيرات العروض التقديمية في Node.js
type: docs
weight: 90
url: /ar/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- رد نداء التحذير
- سياسة التحذير
- فقدان البيانات
- فساد المصدر
- مشكلة التوافق
- استبدال الخط
- التوقيع الرقمي
- تحميل العرض التقديمي
- عرض العرض التقديمي
- تحويل العرض التقديمي
- حفظ العرض التقديمي
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "تعرف على كيفية جمع التحذيرات وتصنيفها والتعامل معها أثناء تحميل العروض التقديمية وعرضها وتحويلها وحفظها باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن مشاكل يمكن Recovery أثناء تحميله أو عرضه أو تحويله أو حفظه للعرض التقديمي. تشمل الأمثلة سجلات المصدر التالفة، المحتوى الذي لا يمكن حفظه، استبدال الخطوط، وقيود تنسيق الهدف. يسمح رد النداء التحذيري للتطبيق بتسجيل هذه الحالات وتحديد ما إذا كان يمكن متابعة العملية الحالية.

استخدم `java.newProxy` لتنفيذ واجهة [IWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarningcallback/) بلغة JavaScript وفحص القيم التي يوفرها [IWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/) عبر [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--). أرجع [ReturnAction.Continue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/returnaction/#Continue) لقبول التحذير أو [ReturnAction.Abort](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/returnaction/#Abort) لإيقاف العملية.

استخدم [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) للتحذيرات التي تظهر أثناء فتح عرض تقديمي. الفئات الخاصة بالتصدير والعرض ترث من [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)، والتي تستقبل التحذيرات من عرض الشرائح، التحويل، والحفظ. لأن التحذير ذاته لا يحدد العملية التطبيقية، اربط كل مثيل من رد النداء بمرحلة عملية عند إنشاء تقرير مشترك.

## **التحذيرات والاستثناءات**

التحذير يصف حالة يمكن لـ Aspose.Slides التعافي منها إذا أعاد رد النداء `ReturnAction.Continue`. الاستثناء يعني أن العملية المطلوبة لا يمكن إكمالها بصورة طبيعية؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن معالجتها بواسطة سياسة التحذير.

إرجاع `ReturnAction.Abort` يطلب من موزع التحذيرات إنهاء العملية الحالية عبر رفع استثناء. يعتمد نوع الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد ينتج عن التحميل استثناء [PptxReadException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptreadexception/)، بينما قد ينتج عن الحفظ أو التصدير استثناء [PptxException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxexception/). قم بالتقاط الخطأ من جسر Java عند حدود العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع استثناء واحد أو رسالة معينة. يسجل رد النداء التحذير قبل إرجاع `ReturnAction.Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفر فئة [WarningType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/) ثوابت عددية للفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | يحتوي العرض التقديمي المصدر على فساد قد يجعل المستند المحفوظ بتنسيقه الأصلي غير قابل للاستخدام. | إلغاء. |
| [DataLoss](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#DataLoss) | قد يغيب النص أو المخططات أو الصور أو أي بيانات أخرى بعد التحميل أو الحفظ. | إلغاء. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إلغاء في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | قد يحدث فرق تنسيقي محدود. | سجل لأغراض التشخيص واستمر. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | قد لا يفتح الناتج أو يعمل بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجل واستمر ما لم يكن التوافق إلزاميًا. |
| [UnexpectedContent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يُعرف تأثيره بعد. | سجل واستمر، أو اعتبره خطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. خزن القيمة التي تُرجعها [getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--) للتشخيص، لكن لا تعتمد على صياغتها في منطق التطبيق لأن نص الرسالة قد يتغير بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

المثال التالي بلغة JavaScript يستخدم تقريرًا واحدًا على مستوى التطبيق لبقية خطوط المعالجة. يُنشئ كل مثيل رد نداء منفصل لتصنيف التحذيرات القادمة من التحميل، العرض، تحويل PDF، وحفظ PPTX. تُلغي السياسة العملية عند حدوث فساد في المصدر أو فقدان بيانات، وتُلغي اختياريًا عند حدوث فقدان تنسيق كبير، وتستمر في الحالات الأخرى.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

مرر `false` للمعامل `abortOnMajorFormattingLoss` عند إنشاء `WarningPolicy` إذا كانت اختلافات التنسيق الكبيرة مقبولة. لا تزال مشكلات التوافق، وفقدان التنسيق الصغير، والمحتوى غير المتوقع محفوظة في التقرير حتى وإن استمرت العملية. قم بتمديد `WarningPolicy.getAction` إذا كان التطبيق يجب أن يرفض أيًا من هذه الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض تقديمي موقّع تحذير أثناء التحميل يُشير إلى أن توقيعه سيفقد خلال المعالجة. تُبلغ Aspose.Slides عن هذه الحالة باستخدام `DataLoss` عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationsignedwarninginfo/). يسمح رد النداء في مرحلة التحميل للتطبيق برفض الملف أو قبول الفقدان المبلغ عنه صراحةً.
- **استبدال الخطوط:** قد يتم استبدال خط غير متوفر أثناء عرض شريحة أو تصديرها. تُبلّغ تحذيرات استبدال الخطوط كـ `DataLoss`، لذا فإن السياسة الصارمة أعلاه تلغي حتى لو كان التطبيق يعتبر الاستبدال مقبولًا بصريًا. لاختبار ذلك، استخدم عرضًا تقديميًا يحتوي على نص بخط غير متوفر في وقت التشغيل. يحدد وصف التحذير الاستبدال؛ اضبط الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يصادف المحمل سجلات عرض تقديمي أو ميزات لا يتعرف عليها. قد تُستخدم هذه التحذيرات `UnexpectedContent`، أو فئة أكثر حدة إذا كان من المعروف أن البيانات أو التنسيق متأثران.
- **توافق التنسيق:** قد يؤدي حفظ العرض إلى تنسيق آخر إلى حذف ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، حفظ عرض يحتوي على أكثر من ثمانية دلائل أفقية أو رأسية إلى PPT قد يُبلغ عن `CompatibilityIssue`. يمكن لرد النداء في مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الدلائل ضروريًا.
- **سلوك التحميل:** قد تُنتج خيارات التحميل والسلوكيات القديمة تحذيرات أيضًا. على سبيل المثال، يُظهر [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استخدام سلوك قفل عرض تقديمي مهمل كـ `CompatibilityIssue`.

تعتمد التحذيرات على مستند المصدر، التنسيق الهدف، العملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف سيُنتج تحذيرًا أو أن كل سيناريو يندرج تحت فئة واحدة فقط.

## **معالجة العمليات المتوقفه بأمان**

عند إرجاع رد النداء `ReturnAction.Abort`، لا تستخدم كائنًا فشل في التحميل ولا تفترض أن ناتج العرض أو الحفظ مكتمل. قد تنتهي العملية بعد إنشاء ملف الإخراج ولكن قبل إتمامه.

احفظ النتائج التي تم التحقق منها إلى مسار منفصل مثل `validated-output.pptx`. استبدل العرض التقديمي الموجود فقط بعد إكمال العملية بنجاح، وتحقق أن تقرير التحذير يطابق سياسة التطبيق، وأن الإخراج يمكن فتحه وفحصه. يمنع ذلك الكتابة فوق ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

عدم وجود تقرير تحذير لا يضمن أن كل ميزة في المصدر قد تم حفظها. طبّق أي فحوصات محتوى أو بصرية إضافية يقتضيها التطبيق. راجع أيضًا [Open Presentations](/slides/ar/nodejs-java/open-presentation/) و[Save Presentations](/slides/ar/nodejs-java/save-presentation/).

## **الأسئلة الشائعة**

**هل يمكن لرد النداء التحذيري معالجة كل أخطاء Aspose.Slides؟**

لا. يقتصر على معالجة الحالات القابلة للانتعاش التي تُبلغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث خارج نطاق رد النداء عند استدعاء التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction.Continue` إخراجًا متطابقًا؟**

لا. يتيح فقط استمرار المعالجة. قد تتسبب الحالة المبلّغ عنها في اختلافات بالبيانات أو التنسيق أو التوافق، لذا يجب مراجعة أنواع التحذيرات المجمّعة وأوصافها.

**كيف يمكن للتطبيق تحديد العملية التي أنتجت التحذير؟**

أنشئ مثيلًا من رد النداء لكل عملية وخزن مرحلة معرفة من قبل التطبيق مع القيم التي تُرجعها [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--)، كما هو موضح في المثال.