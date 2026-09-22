---
title: حفظ العروض التقديمية في Java
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/java/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض إلى ملف
- العرض إلى تدفق
- نوع عرض محدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تجديد الصورة المصغرة
- حفظ التقدم
- Java
- Aspose.Slides
description: "حفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في Java باستخدام Aspose.Slides، وتكوين إخراج PPTX وتقارير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح عرض تقديمي موجود](/slides/ar/java/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة. يمكن لـ Aspose.Slides for Java حفظ عرض تقديمي إلى ملف أو تدفق بصيغ PowerPoint و OpenDocument و PDF وصيغ أخرى. تغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-). تحدد قيمة التنسيق نوع الملف الذي تنشئه Aspose.Slides.

المثال التالي ينشئ عرضًا تقديميًا ويحفظه كملف PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // أضف أو عدّل محتوى العرض التقديمي هنا.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بالتنسيق الأصلي لها**

لأمثلة اكتشاف الملف والتدفق، سلوك العروض التقديمية التي تم إنشاؤها حديثًا، والتمييز بين تنسيقات المصدر والإخراج، راجع [تحديد تنسيق العرض التقديمي الأصلي](/slides/ar/java/detect-presentation-source-format/).

في تطبيق معالجة دفعات، قد لا يكون تنسيق الإدخال معروفًا مسبقًا. بعد تحميل ملف، اقرأ تنسيقه الأصلي من طريقة [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSourceFormat--) . مرّر القيمة الناتجة من [SourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sourceformat/) إلى طريقة [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#toSaveFormat-int-) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) المقابلة، ثم استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة العرض المعدل.

المثال الكامل التالي يُعالج كل ملف في دليل إدخال، يُحدّث عنوانه، ويحفظه إلى دليل إخراج بالتنسيق الذي تم تحميله منه:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#toSaveFormat-int-) يطابق PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML إلى تنسيقات الحفظ المقابلة لها. وهو يطابق تنسيقات مصدر العرض فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يؤدي إلى حدوث استثناء [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

تستخدم ملفات PPT و PPS و POT القديمة نفس الحاوية الثنائية. عندما يُحمَّل عرض تقديمي من تدفق بدون امتداد ملف، قد يُعرف ملف PPS أو POT على أنه PPT. إذا كان من الضروري الحفاظ على هذه الأنواع الفرعية القديمة، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالتنسيق بشكل منفصل واستخدمها عند اختيار اسم الملف وتنسيقه للإخراج.

## **حفظ العروض التقديمية إلى تدفقات**

لكتابة عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر تدفقًا قابلًا للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد العرض الذي يفتح به PowerPoint العرض المحفوظ أولاً. استخدم طريقة [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض Master Slide كالعرض الأولي:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

لإنشاء ملف PPTX يتوافق مع الملف التعريفي Strict لـ Office Open XML، أنشئ كائنًا من [PptxOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/) واستخدم طريقة [setConformance](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/#setConformance-int-) مع [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). ثم مرّر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

تقيد الأرشفة ZIP القياسية حجم كل إدخال مضغوط وغير مضغوط، وحجم الأرشيف الكلي، وعدد الإدخالات. بما أن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. تمديدات ZIP64 ترفع الحدود القابلة للتطبيق على الحجم وعدد الإدخالات.

استخدم طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Never) يعطل امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Always) يكتب امتدادات ZIP64 دائمًا.

المثال التالي يُفعِّل امتدادات ZIP64 دائمًا للإخراج:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="تحذير" %}}
إذا تم استخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Never) ولا يستطيع العرض أن يتناسب مع حدود ZIP القياسية، فإن عملية الحفظ ترمي استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف باستخدام طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). توفر فئة [CompressionLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/) القيم التالية:

- [None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#None) تخزن البيانات دون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط.
- [Level2](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level2) حتى [Level5](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level5) تفضّل تدريجيًا حجمًا أصغر على حساب سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level8) تفضّلان حجمًا أصغر أكثر على حساب سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أكثر وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

المثال التالي يستخدم أقصى مستوى ضغط:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية دون تجديد الصورة المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) في صورة المستند المصغرة:

- `true` يُعيد إنشاء الصورة المصغرة أثناء عملية الحفظ. هذا هو القيمة الافتراضية.
- `false` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لا تُنشئ Aspose.Slides واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تجديد صورته المصغرة:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}
إلغاء تجديد الصورة المصغرة يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

لمراقبة عملية الحفظ، نفّذ واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/) ومرّر التنفيذ إلى طريقة [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). ثم تستدعي Aspose.Slides طريقة [IProgressCallback.reporting](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/#reporting-double-) مع قيم التقدم أثناء التصدير.

المثال التالي يُظهر تقدم تصدير PDF إلى وحدة التحكم:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}
توفر Aspose أداة مجانية لتقسيم PowerPoint [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على Aspose.Slides API. تقوم بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides الحفظ المتزايد أو “الحفظ السريع”?**  
لا. كل عملية حفظ تكتب ملف إخراج كامل بدلاً من تحديث الأجزاء التي تغيرت فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**  
لا. كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) غير آمن للاستخدام عبر الخيوط ([is not thread-safe](/slides/ar/java/multithreading/)). يجب الوصول إلى كل كائن وحفظه من خيط واحد في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عندما أحفظ عرضًا تقديميًا؟**  
تظل [الروابط التشعبية](/slides/ar/java/manage-hyperlinks/) موجودة في العرض. لا تنسخ Aspose.Slides الملفات المرتبطة خارجيًا، لذا يجب أن يكون للعرض المحفوظ القدرة على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف والعنوان والشركة وتاريخ الإنشاء؟**  
نعم. اضبط [خصائص المستند](/slides/ar/java/presentation-properties/) المناسبة قبل الحفظ، وستكتب Aspose.Slides هذه الخصائص إلى ملف الإخراج.