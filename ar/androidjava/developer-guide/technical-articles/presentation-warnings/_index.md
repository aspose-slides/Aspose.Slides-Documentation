---
title: التعامل مع تحذيرات العروض التقديمية على Android
type: docs
weight: 90
url: /ar/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية جمع وتصنيف واتخاذ إجراءات بشأن التحذيرات أثناء تحميل وعرض وتحويل وحفظ العروض التقديمية باستخدام Aspose.Slides لأندرويد عبر جافا."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن مشكلات يمكن استردادها أثناء تحميله أو عرضه أو تحويله أو حفظه للعرض التقديمي. تشمل الأمثلة سجلات المصدر التالفة، المحتوى الذي لا يمكن حفظه، استبدال الخطوط، وقيود تنسيق الهدف. تتيح دالة رد النداء للتحذير للتطبيق تسجيل هذه الحالات وتحديد ما إذا كان يجب استمرار العملية الحالية.

قم بتنفيذ الواجهة [IWarningCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarningcallback/) وتفحص القيم التي تعيدها [getWarningType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) الموردة عبر [IWarningInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/). أعد [ReturnAction.Continue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/returnaction/#Continue) لقبول التحذير أو [ReturnAction.Abort](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/returnaction/#Abort) لإيقاف العملية.

استخدم [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) للتحذيرات التي تُثار أثناء فتح عرض تقديمي. فئات خيارات العرض والتصدير ترث [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)، التي تستقبل التحذيرات من عرض الشرائح، التحويل، والحفظ. نظرًا لأن التحذير نفسه لا يحدد عملية التطبيق، اربط كل مثيل من رد النداء بمرحلة عملية عند بناء تقرير موحد.

## **التحذيرات والاستثناءات**

الوصف يمثل حالة يمكن لـ Aspose.Slides التعافي منها إذا أعادت دالة رد النداء `ReturnAction.Continue`. الاستثناء يعني أن العملية المطلوبة لا يمكن إكمالها بشكل طبيعي؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن التعامل معها بسياسة التحذير.

إرجاع `ReturnAction.Abort` يطلب من موزع التحذير إنهاء العملية الحالية عبر رفع استثناء. يعتمد الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد ينتج عن التحميل استثناء [PptxReadException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptreadexception/)، بينما قد ينتج عن الحفظ أو التصدير استثناء [PptxException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxexception/). عالج الاستثناء عند حدود العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع استثناء واحد أو رسالة معينة. يسجل رد النداء التحذير قبل إرجاع `ReturnAction.Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفّر الفئة [WarningType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/) ثوابت عددية للفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | يحتوي العرض التقديمي المصدر على فساد قد يجعل المستند المحفوظ بصيغته الأصلية غير قابل للاستخدام. | إلغاء. |
| [DataLoss](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#DataLoss) | قد يكون النص أو المخططات أو الصور أو بيانات أخرى مفقودة بعد التحميل أو الحفظ. | إلغاء. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إلغاء في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | قد يحدث فرق تنسيق محدود. | سجل للتشخيص واستمر. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | قد لا يفتح النتيجة أو يتصرف بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجّل واستمر إلا إذا كانت التوافقية إلزامية. |
| [UnexpectedContent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يكون أثره معروفًا بعد. | سجل واستمر، أو عالجه كخطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. احفظ القيمة التي تُرجعها [getDescription](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) للتشخيص، ولكن لا تعتمد على صيغتها في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

المثال التالي يستخدم تقريرًا واحدًا على مستوى التطبيق لخط أنابيب المعالجة بالكامل. كل مثيل منفصل من رد النداء يضع علامة على التحذيرات من التحميل، العرض، التحويل إلى PDF، وحفظ PPTX. السياسة تُلغي عند فساد المصدر أو فقدان البيانات، وتُلغي اختياريًا عند فقدان تنسيق كبير، وتستمر لبقية التحذيرات.

ضع `input.pptx` في دليل تطبيق قابل للكتابة ومرّر ذلك الدليل إلى `PresentationWarningExample.run`. يحفظ المثال نواتجّه في نفس الدليل. نفّذ معالجة العرض على خيط خلفي للحفاظ على استجابة واجهة Android.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

مرّر `false` للمعامل `abortOnMajorFormattingLoss` عند إنشاء `WarningPolicy` إذا كانت اختلافات التنسيق الكبيرة مقبولة. لا تزال قضايا التوافق، فقدان التنسيق الصغير، والمحتوى غير المتوقع محفوظة في التقرير حتى عند استمرار العملية. وسّع `WarningPolicy.getAction` إذا كان التطبيق يجب أن يرفض أيًا من تلك الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض تقديمي موقع تحذير أثناء التحميل بأن توقيعه سيفقد أثناء المعالجة. يبلّغ Aspose.Slides عن هذا الشرط `DataLoss` عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). يسمح رد نداء المرحلة التحميلية للتطبيق برفض الملف أو القبول الصريح للفقد المعلن.
- **استبدال الخطوط:** قد يُستبدل خط غير متوفر أثناء عرض شريحة أو تصديرها. تُبلّغ تحذيرات استبدال الخطوط كـ `DataLoss`، لذا السياسة الصارمة أعلاه تُلغي حتى لو كان التطبيق يعتبر الاستبدال مقبولًا بصريًا. لاختبار هذا السلوك، استخدم عرضًا تقديميًا يحتوي على نص بخط غير متوفر في وقت التشغيل. يحدد وصف التحذير الاستبدال؛ اضبط الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/androidjava/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يصادف المُحمّل سجلات أو ميزات لا يتعرف عليها. قد تستخدم هذه التحذيرات `UnexpectedContent`، أو فئة أقوى إذا كان من المعروف أن البيانات أو التنسيق متأثران.
- **توافق التنسيق:** قد يؤدي حفظ العرض إلى تنسيق آخر إلى حذف ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، حفظ عرض يحتوي على أكثر من ثماني خطوط إرشاد أفقية أو رأسية في PPT قد يُبلغ عن `CompatibilityIssue`. يمكن لرد نداء مرحلة الحفظ تسجيل الفقد والاستمرار، أو رفضه إذا كان الحفاظ على جميع الخطوط مطلوبًا.
- **سلوك التحميل:** يمكن أن تُنتج خيارات التحميل والسلوكيات القديمة تحذيرات أيضًا. على سبيل المثال، يُحدد [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استخدام سلوك قفل عرض تقديمي قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على المستند المصدر، التنسيق الهدف، العملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف يُنتج تحذيرًا أو أن كل سيناريو يندرج تحت فئة واحدة فقط.

## **التعامل الآمن مع العمليات التي تم إلغاؤها**

عند إرجاع رد النداء `ReturnAction.Abort`، لا تستخدم كائنًا فشل التحميل ولا تفترض أن ناتج العرض أو الحفظ مكتمل. قد تنتهي العملية بعد إنشاء ملف الخرج ولكن قبل إكماله.

احفظ النتائج المُتحقَّقة إلى مسار منفصل مثل `validated-output.pptx`. استبدل العرض التقديمي الموجود فقط بعد أن تنتهي العملية بنجاح، ويُرضي تقرير التحذير سياسة التطبيق، ويمكن فتح الناتج والتحقق منه. هذا يُجنب الكتابة فوق ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

التقرير الفارغ لا يضمن أن كل ميزة مصدرية قد حُفظت. نفّذ أي فحوصات محتوى أو بصرية إضافية يحتاجها التطبيق. انظر أيضًا إلى [Open Presentations](/slides/ar/androidjava/open-presentation/) و[Save Presentations](/slides/ar/androidjava/save-presentation/).

## **أسئلة متكررة**

**هل يمكن لرد النداء للتحذير معالجة كل خطأ في Aspose.Slides؟**

لا. يتعامل فقط مع الحالات القابلة للاسترداد التي تُبلغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث بشكل مستقل عن رد النداء حول استدعاءات التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction.Continue` مخرجات مطابقة؟**

لا. هو يسمح بمتابعة المعالجة فقط. قد يظل الشرط المبلّغ عنه يسبب اختلافات في البيانات أو التنسيق أو التوافق، لذا راجع أنواع التحذيرات والأوصاف المجمّعة.

**كيف يمكن للتطبيق تحديد العملية التي نتج عنها التحذير؟**

أنشئ مثيلًا من رد النداء لكل عملية وخزن مرحلة مُعرَّفة من قبل التطبيق مع القيم التي تُرجعها [getWarningType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iwarninginfo/#getDescription--)، كما هو موضح في المثال.