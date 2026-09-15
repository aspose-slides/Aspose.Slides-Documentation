---
title: التعامل مع تحذيرات العروض التقديمية في بايثون عبر جافا
type: docs
weight: 90
url: /ar/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية جمع وتصنيف واتخاذ إجراءات بشأن التحذيرات أثناء تحميل وعرض وتحويل وحفظ العروض التقديمية باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن المشكلات القابلة للاسترداد أثناء التحميل أو العرض أو التحويل أو الحفظ للعرض التقديمي. تشمل الأمثلة السجلات المصدرية التالفة، المحتوى الذي لا يمكن الحفاظ عليه، استبدال الخطوط، والقيود في تنسيق الهدف. تسمح دالة رد النداء للتحذير للتطبيق بتسجيل هذه الحالات وتحديد ما إذا كان يمكن متابعة العملية الحالية.

نفّذ واجهة `IWarningCallback` عبر `jpype.JProxy` وتفحص القيم `getWarningType` و `getDescription` التي يقدمها `IWarningInfo`. أرجع [ReturnAction.Continue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/returnaction/#Continue) لقبول التحذير أو [ReturnAction.Abort](https://reference.aspose.com/slides/ar/python-java/aspose.slides/returnaction/#Abort) لإيقاف العملية.

استخدم [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setWarningCallback) للتحذيرات التي تُرفع أثناء فتح عرض تقديمي. ترث فئات خيارات العرض والتصدير [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setWarningCallback) التي تتلقى التحذيرات من عرض الشريحة، التحويل، والحفظ. نظرًا لأن التحذير نفسه لا يحدد عملية التطبيق، اربط كل مثال لدالة رد النداء بمرحلة عملية عند بناء تقرير مُدمج.

## **التحذيرات والاستثناءات**

التحذير يصف حالة يمكن لـ Aspose.Slides الاسترداد منها إذا أعادت دالة رد النداء `ReturnAction.Continue`. أما الاستثناء فيعني أن العملية المطلوبة لا يمكن إكمالها بشكل طبيعي؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن التعامل معها بسياسة التحذير.

إرجاع `ReturnAction.Abort` يطلب من موزّع التحذير إنهاء العملية الحالية عن طريق إثارة استثناء. يعتمد نوع الاستثناء العام على العملية وتنسيق العرض. على سبيل المثال، قد يُظهر التحميل استثناءً من نوع [PptxReadException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptreadexception/)، بينما قد يُظهر الحفظ أو التصدير استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxexception/). تعامل مع الاستثناء عند حد العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع استثناء أو رسالة واحدة. تسجّل دالة رد النداء التحذير قبل إرجاع `ReturnAction.Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفر الفئة [WarningType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/) الثوابت الصحيحة للفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#SourceFileCorruption) | يحتوي العرض التقديمي المصدر على تلف قد يجعل الوثيقة المحفوظة بالتنسيق الأصلي غير قابلة للاستخدام. | إلغاء. |
| [DataLoss](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#DataLoss) | قد يصبح النص أو المخططات أو الصور أو البيانات الأخرى غائبًا بعد التحميل أو الحفظ. | إلغاء. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | قد يفقد العرض التقديمي تنسيقًا مهمًا. | إلغاء في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | قد يحدث فرق تنسيق محدود. | سجل لأغراض التشخيص واستمر. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#CompatibilityIssue) | قد لا يفتح الناتج أو يعمل بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجّل واستمر ما لم تكن التوافقية إلزامية. |
| [UnexpectedContent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/warningtype/#UnexpectedContent) | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يُعرف تأثيره بعد. | سجل واستمر، أو عالجه كخطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. خزن القيمة التي تُرجعها `getDescription` للتشخيص، لكن لا تعتمد على صياغتها في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

يستخدم المثال التالي تقريرًا على مستوى التطبيق لكامل خط الأنابيب. مثال رد النداء المنفصل يوسم التحذيرات من التحميل، والعرض، والتحويل إلى PDF، وحفظ PPTX. تُلغي السياسة عند وجود فساد في المصدر أو فقدان بيانات، وتُلغي اختياريًا عند فقدان تنسيق كبير، وتستمر في باقي التحذيرات.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

مرّر `False` للمعامل `abort_on_major_formatting_loss` عند بناء `WarningPolicy` إذا كانت الفروقات التنسيقية الكبيرة مقبولة. لا تزال مشاكل التوافق، فقدان التنسيق الصغير، والمحتوى غير المتوقع مُسجلة في التقرير حتى عندما تستمر العملية. وسّع `WarningPolicy.get_action` إذا كان التطبيق يجب أن يرفض أيًا من هذه الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض تقديمي موقّع تحذير أثناء التحميل يُشير إلى أن توقيعه سيفقد أثناء المعالجة. تُبلغ Aspose.Slides عن هذه الحالة `DataLoss` عبر `IPresentationSignedWarningInfo`. يسمح رد النداء في مرحلة التحميل للتطبيق برفض الملف أو القبول الصريح للفقدان المُبلغ عنه.
- **استبدال الخطوط:** قد يُستبدل خط غير متاح أثناء عرض شريحة أو تصديرها. تُبلغ تحذيرات استبدال الخط كـ `DataLoss`، لذا تُلغي السياسة الصارمة أعلاه حتى لو كان التطبيق يعتبر الاستبدال مقبولًا بصريًا. لتجربة هذا السلوك، استخدم عرضًا تقديميًا يحتوي على نص بخط غير متاح للبيئة التنفيذية. يحدد وصف التحذير الاستبدال؛ عيّن الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/python-java/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يصادف المُحمّل سجلات أو ميزات لا يتعرف عليها. قد تُستخدم هذه التحذيرات `UnexpectedContent`، أو فئة أكثر شدة إذا كان من المعروف أن البيانات أو التنسيق تأثرا.
- **توافق الصيغ:** قد يؤدي حفظ العرض إلى صيغة أخرى إلى حذف ميزات أو إنتاج نتيجة تتصرف بصورة مختلفة في بعض التطبيقات. على سبيل المثال، حفظ عرض يحتوي على أكثر من ثمانية خطوط إرشاد أفقية أو رأسية إلى PPT قد يُبلغ عن `CompatibilityIssue`. يمكن لدالة رد النداء في مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الخطوط إلزاميًا.
- **سلوك التحميل:** قد تُنتج خيارات التحميل وسلوكيات التراث تحذيرات أيضًا. على سبيل المثال، يحدد `IObsoletePresLockingBehaviorWarningInfo` استخدام سلوك قفل عرض قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على المستند المصدر، والصيغة المستهدفة، والعملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف ينتج تحذيرًا أو أن كل سيناريو يُطابق فئة واحدة فقط.

## **معالجة العمليات الملغاة بأمان**

عند إرجاع دالة رد النداء `ReturnAction.Abort`، لا تستخدم كائنًا فشل في التحميل ولا تفترض أن إخراج العرض أو الحفظ كامل. قد تتوقف العملية بعد إنشاء ملف الإخراج ولكن قبل إكماله.

احفظ النتائج المُتحققة إلى مسار منفصل مثل `validated-output.pptx`. استبدل العرض التقديمي الموجود فقط بعد أن تنتهي العملية بنجاح، وتُرضي تقرير التحذير سياسة التطبيق، ويمكن فتح الإخراج والتحقق منه. يضمن ذلك عدم استبدال ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

التقرير الفارغ للتحذير ليس ضمانًا بأن كل ميزة في المصدر تم الحفاظ عليها. طبّق أي فحوصات محتوى أو بصرية إضافية تحتاجها تطبيقك. راجع أيضًا [Open Presentations](/slides/ar/python-java/open-presentation/) و[Save Presentations](/slides/ar/python-java/save-presentation/).

## **الأسئلة المتكررة**

**هل يمكن لدالة رد النداء للتحذير معالجة كل خطأ في Aspose.Slides؟**

لا. تتعامل فقط مع الحالات القابلة للاسترداد التي تُبلغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث بشكل مستقل عن رد النداء حول عمليات التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction.Continue` إنتاج مخرجات مطابقة تمامًا؟**

لا. هو يسمح فقط بالاستمرار في المعالجة. لا يزال الشرط المُبلغ عنه قد يسبب اختلافات في البيانات أو التنسيق أو التوافق، لذا راجع أنواع التحذيرات المجمعة وأوصافها.

**كيف يمكن للتطبيق تحديد العملية التي أنتجت التحذير؟**

أنشئ مثالًا لدالة رد النداء لكل عملية وخزن مرحلة معرفة من قبل التطبيق مع القيم التي تُرجعها `getWarningType` و `getDescription`، كما هو موضح في المثال.