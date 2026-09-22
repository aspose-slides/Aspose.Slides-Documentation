---
title: حفظ العروض التقديمية على Android
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/androidjava/save-presentation/
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
- نوع عرض مُعرّف مسبقًا
- صيغة Office Open XML الصارمة
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Android
- Java
- Aspose.Slides
description: "احفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات على Android باستخدام Aspose.Slides، وقم بتكوين إخراج PPTX وإبلاغ التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح أحد العروض الموجودة](/slides/ar/androidjava/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة. Aspose.Slides for Android عبر Java يمكنه حفظ عرض تقديمي إلى ملف أو تدفق بصيغ PowerPoint و OpenDocument و PDF وغيرها. الأقسام التالية تغطي عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). تحدد قيمة الصيغة نوع الملف الذي تنشئه Aspose.Slides.

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

## **حفظ العروض التقديمية بالصيغ الأصلية**

لأمثلة اكتشاف الملفات وتدفقات البيانات، وسلوك العروض التي تم إنشاؤها حديثًا، والتمييز بين صيغ المصدر والصيغ الناتجة، راجع [Determine the Original Presentation Format](/slides/ar/androidjava/detect-presentation-source-format/).

في تطبيق معالجة دفعة، قد لا تكون صيغة الإدخال معروفة مسبقًا. بعد تحميل ملف، اقرأ صيغته الأصلية من طريقة [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . مرّر القيمة الناتجة من [SourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sourceformat/) إلى طريقة [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) المقابلة، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل إدخال، يُحدّث عنوانه، ويحفظه إلى دليل إخراج بالصغة التي تم تحميله منها:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) يطابق PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML إلى صيغ الحفظ المقابلة للعروض. يطابق صيغ المصدر فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يؤدي إلى استثناء [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

ملفات PPT و PPS و POT القديمة تستخدم نفس الحاوية الثنائية. عندما يُحمَّل مثل هذا العرض من تدفق دون امتداد ملف، قد يُعرَّف ملف PPS أو POT على أنه PPT. إذا كان الحفاظ على هذه الأنواع الفرعية القديمة مطلوبًا، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالصيفة بشكل منفصل واستخدمهما عند اختيار اسم الصيفة ومخرجات الصيفة.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر تدفقًا قابلًا للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

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

يمكنك تحديد طريقة العرض التي يفتح فيها PowerPoint العرض المحفوظ أولًا. استخدم طريقة [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض Slide Master كطريقة العرض الأولية:

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

## **حفظ العروض التقديمية بصيغة Office Open XML الصارمة**

لإنشاء ملف PPTX يتطابق مع الملف الشخصي الصارم لـ Office Open XML، أنشئ كائن [PptxOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/) واستخدم طريقة [setConformance](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) معه مع القيمة [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). ثم مرّر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

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

## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

يحد الأرشيف ZIP القياسي من حجم الضغط وغير المضغوط لكل مدخل، وحجم الأرشيف الكلي، وعدد المدخلات. بما أن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. تمديدات ZIP64 ترفع الحدود المطبقة على الحجم وعدد المدخلات.

استخدم طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض التقديمي حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Never) يعطل امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Always) دائمًا يكتب امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للإخراج:

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

{{% alert color="warning" title="Warning" %}}
إذا تم استخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Never) ولا يمكن للعرض التقديمي أن يتناسب ضمن حدود ZIP القياسية، فإن عملية الحفظ تُثير استثناء [PptxException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بصيغة Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مع حجم الملف باستخدام طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). توفر فئة [CompressionLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/) هذه القيم:

- [None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#None) يخزن البيانات دون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط.
- [Level2](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level2) إلى [Level5](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level5) يفضِّل تدريجيًا حجمًا أصغر على سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level8) يفضِّلان حجمًا أصغر أكثر على سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أطول وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا دون ضغط:

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

المثال التالي يستخدم أعلى مستوى ضغط:

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

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) في صورة المستند المصغرة:

- `true` يعيد إنشاء الصورة المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `false` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، فإن Aspose.Slides لا ينشئ واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث صورته المصغرة:

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

{{% alert color="info" title="Note" %}}
تعطيل تحديث الصورة المصغرة يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

لرصد عملية حفظ، نفّذ واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprogresscallback/) ومرّر التنفيذ إلى طريقة [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). ثم تستدعي Aspose.Slides طريقة [IProgressCallback.reporting](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) بقيم التقدم أثناء التصدير.

المثال التالي يُبلغ عن تقدم تصدير PDF إلى وحدة التحكم:

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

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية تُدعى [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على API الخاص بـ Aspose.Slides. تقوم هذه الأداة بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides الحفظ المتدرج أو “الحفظ السريع”？**

لا. كل عملية حفظ تكتب ملفًا كاملاً بدلاً من تحديث الأجزاء المتغيّرة فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) غير آمن للمتعدد الخيوط. يجب الوصول إلى كل كائن وحفظه من خيط واحد في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عندما أحفظ عرضًا تقديميًا؟**

[Hyperlinks](/slides/ar/androidjava/manage-hyperlinks/) تبقى في العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يتمكن العرض المحفوظ من الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف، العنوان، الشركة، وتاريخ الإنشاء؟**

نعم. اضبط [document properties](/slides/ar/androidjava/presentation-properties/) قبل الحفظ، وستكتب Aspose.Slides هذه القيم إلى ملف الإخراج.