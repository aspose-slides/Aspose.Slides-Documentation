---
title: معالجة تحذيرات العروض التقديمية في Java
type: docs
weight: 90
url: /ar/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- استدعاء التحذير
- سياسة التحذير
- فقدان البيانات
- فساد المصدر
- مشكلة التوافق
- استبدال الخط
- توقيع رقمي
- تحميل العرض التقديمي
- عرض العرض التقديمي
- تحويل العرض التقديمي
- حفظ العرض التقديمي
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "تعلم كيفية جمع التحذيرات وتصنيفها واتخاذ إجراءات بشأنها أثناء تحميل العروض التقديمية وعرضها وتحويلها وحفظها باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن مشاكل قابلة للاسترداد أثناء التحميل أو العرض أو التحويل أو الحفظ للعرض التقديمي. تشمل الأمثلة سجلات المصدر التالفة، المحتوى الذي لا يمكن المحافظة عليه، استبدال الخطوط، وقيود تنسيق الهدف. تسمح استدعاء التحذير للتطبيق بتسجيل هذه الحالات وتحديد ما إذا كان يمكن استمرار العملية الحالية.

قم بتنفيذ الواجهة [IWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarningcallback/) وتفحص القيم [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--) المقدمة عبر [IWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/). إرجع [ReturnAction.Continue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/returnaction/#Continue) لقبول التحذير أو [ReturnAction.Abort](https://reference.aspose.com/slides/ar/java/com.aspose.slides/returnaction/#Abort) لإيقاف العملية.

استخدم [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) للتحذيرات التي تُثار أثناء فتح عرض تقديمي. فئات خيارات العرض والتصدير ترث [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)، والتي تستقبل التحذيرات من عرض الشرائح، التحويل، والحفظ. لأن التحذير نفسه لا يحدد عملية التطبيق، اربط كل مثال استدعاء بمرحلة عملية عندما تنشئ تقريرًا موحدًا.

## **التحذيرات والاستثناءات**

الوصف يحكي حالة يمكن لـ Aspose.Slides التعافي منها إذا أعاد الاستدعاء `ReturnAction.Continue`. الاستثناء يعني أن العملية المطلوبة لا يمكن إكمالها بصورة طبيعية؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن التعامل معها بسياسة التحذير.

إرجاع `ReturnAction.Abort` يطلب من موزع التحذير إنهاء العملية الحالية عن طريق رفع استثناء. يعتمد نوع الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد ينتج عن التحميل استثناء [PptxReadException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptreadexception/)، بينما قد ينتج عن الحفظ أو التصدير استثناء [PptxException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxexception/). عالج الاستثناء عند حدود العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع استثناء أو رسالة واحدة. يسجل الاستدعاء التحذير قبل إرجاع `ReturnAction.Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

فئة [WarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/) توفر ثوابت عددية للفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#SourceFileCorruption) | يحتوي العرض التقديمي المصدر على فساد قد يجعل المستند المحفوظ بالتنسيق الأصلي غير قابل للاستخدام. | إيقاف. |
| [DataLoss](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#DataLoss) | قد يكون النص أو المخططات أو الصور أو أي بيانات أخرى غائبة بعد التحميل أو الحفظ. | إيقاف. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إيقاف في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | قد يحدث فرق تنسيق محدود. | سجل للتشخيص واستمر. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#CompatibilityIssue) | قد لا يفتح النتيجة أو يعمل بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجل واستمر ما لم يكن التوافق إلزاميًا. |
| [UnexpectedContent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/warningtype/#UnexpectedContent) | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يُعرف تأثيره بعد. | سجل واستمر، أو اعتبره خطأ في سياسة صارمة. |

يجب أن تقود الفئة اتخاذ قرار السياسة. احفظ القيمة التي تُرجعها [getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--) للتشخيص، لكن لا تعتمد على صيغتها في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

المثال التالي يستخدم تقريرًا على مستوى التطبيق للخط الأنابيب الكامل للمعالجة. مثال استدعاء منفصل يضع علامة على التحذيرات من التحميل، العرض، تحويل PDF، وحفظ PPTX. السياسة تُوقف عند فساد المصدر أو فقدان البيانات، وتُوقف اختياريًا عند فقدان تنسيق كبير، وتستمر لبقية التحذيرات.

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
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
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
                image.save("slide-1.png", ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
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

مرّر `false` للمعامل `abortOnMajorFormattingLoss` عند إنشاء `WarningPolicy` إذا كانت فروق التنسيق الكبيرة مقبولة. لا تزال مشكلات التوافق، فقدان التنسيق الصغير، والمحتوى غير المتوقع تُحفظ في التقرير حتى عندما تستمر العملية. قم بتمديد `WarningPolicy.getAction` إذا كان التطبيق يجب أن يرفض أيًا من تلك الفئات.

## **سيناريوهات التحذير الشائعة**

- **التوقيعات الرقمية:** يمكن أن ينتج عن عرض تقديمي موقّع تحذير أثناء التحميل بأن توقيعه سيفقد أثناء المعالجة. تُبلغ Aspose.Slides عن هذه الحالة `DataLoss` عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationsignedwarninginfo/). يسمح استدعاء مرحلة التحميل للتطبيق إما برفض الملف أو بقبول الفقدان المبلغ عنه صراحةً.
- **استبدال الخطوط:** قد يتم استبدال خط غير متوفر أثناء عرض شريحة أو تصديرها. تُبلغ تحذيرات استبدال الخط كـ `DataLoss`، لذا السياسة الصارمة أعلاه تُوقف حتى لو كان التطبيق يعتبر الاستبدال مقبولًا بصريًا. لاختبار هذا السلوك، استخدم عرضًا تقديميًا يحتوي على نص بخط غير متوفر في وقت التشغيل. يحدد وصف التحذير الاستبدال؛ اضبط الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/java/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يصادف المحمل سجلات عرض تقديمي أو ميزات لا يتعرف عليها. قد تستخدم هذه التحذيرات `UnexpectedContent`، أو فئة أكثر شدة عندما يُعرف أن البيانات أو التنسيق متأثران.
- **توافق التنسيق:** قد يؤدي الحفظ إلى تنسيق عرض تقديمي آخر إلى إغفال ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، حفظ عرض تقديمي يحتوي على أكثر من ثمانية خطوط دليل أفقية أو عمودية إلى PPT قد يُبلغ عن `CompatibilityIssue`. يمكن لاستدعاء مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الأدلة مطلوبًا.
- **سلوك التحميل:** يمكن أن تُنتج خيارات التحميل والسلوكيات القديمة تحذيرات أيضًا. على سبيل المثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) يحدد استخدام سلوك قفل عرض تقديمي قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على المستند المصدر، التنسيق المستهدف، العملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف ينتج تحذيرًا أو أن كل سيناريو يطابق فئة واحدة فقط.

## **معالجة العمليات المتوقفة بأمان**

عند إرجاع الاستدعاء `ReturnAction.Abort`، لا تستخدم كائنًا فشل في التحميل ولا تفترض أن إخراج العرض أو الحفظ قد اكتمل. يمكن أن تُنهي العملية بعد إنشاء ملف إخراج ولكن قبل إكماله.

احفظ النتائج التي تم التحقق منها إلى مسار منفصل مثل `validated-output.pptx`. استبدل العرض التقديمي الموجود فقط بعد أن تنتهي العملية بنجاح، وتُلبي تقرير التحذير سياسة التطبيق، ويمكن فتح الإخراج وفحصه. هذا يمنع الكتابة فوق ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

تقرير تحذير فارغ ليس ضمانًا بأن كل ميزة مصدرية تم حفظها. طبّق أي فحوصات محتوى أو بصرية إضافية يتطلبها التطبيق. راجع أيضًا [فتح العروض التقديمية](/slides/ar/java/open-presentation/) و[حفظ العروض التقديمية](/slides/ar/java/save-presentation/).

## **الأسئلة الشائعة**

**هل يمكن لاستدعاء التحذير معالجة كل خطأ في Aspose.Slides؟**

لا. إنه يتعامل مع الحالات القابلة للاسترداد التي تُبلّغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث بشكل مستقل عن الاستدعاء حول عمليات التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction.Continue` إنتاج مخرجات مطابقة تمامًا؟**

لا. هو يتيح فقط استمرار المعالجة. لا يزال بإمكان الحالة المبلّغ عنها أن تسبب اختلافات في البيانات أو التنسيق أو التوافق، لذا يجب مراجعة أنواع التحذيرات المجمعة ووصفها.

**كيف يمكن للتطبيق تحديد العملية التي أنتجت التحذير؟**

أنشئ مثال استدعاء لكل عملية وخزن مرحلة معرفة من قبل التطبيق مع القيم التي تُرجعها [getWarningType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getWarningType--) و[getDescription](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iwarninginfo/#getDescription--)، كما هو موضح في المثال.