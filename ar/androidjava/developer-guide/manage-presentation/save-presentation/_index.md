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
- عرض تقديمي إلى ملف
- عرض تقديمي إلى تدفق
- نوع عرض مسبق التعريف
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في Java باستخدام Aspose.Slides لأجهزة Android — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والمؤثرات."
---
## **نظرة عامة**

[فتح العروض التقديمية على Android](/slides/ar/androidjava/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواء كنت تنشئ عرضًا من الصفر أو تعدل عرضًا موجودًا، ستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides for Android، يمكنك الحفظ إلى **ملف** أو **تدفق**. يوضح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عبر استدعاء طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). مرّر اسم الملف وصيغة الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```java
import com.aspose.slides.*;

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // قم ببعض العمل هنا...

    // حفظ العرض التقديمي إلى ملف.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق بتمرير تدفق إخراج إلى طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى أنواع عديدة من التدفقات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // حفظ العرض التقديمي إلى التدفق.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يتيح Aspose.Slides لك ضبط العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي المُنشأ عبر فئة [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/). استخدم الطريقة [setLastView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بصيغة Office Open XML الصارمة**

يتيح Aspose.Slides لك حفظ عرض تقديمي بصيغة Office Open XML الصارمة. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/) واضبط خاصية `conformance` عند الحفظ. إذا ضبطت [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)، يتم حفظ الملف الناتج بصيغة Office Open XML الصارمة.

يوضح المثال أدناه إنشاء عرض تقديمي وحفظه بصيغة Office Open XML الصارمة.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // حفظ العرض التقديمي بصيغة Office Open XML الصارمة.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدًا قدره 4 غى ب (2^32 بايت) لحجم أي ملف غير مضغوط، وحجم أي ملف مضغوط، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65 535 (2^16‑1). تمتد تنسيقات ZIP64 هذه الحدود إلى 2^64.

تتيح طريقة [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو النمط الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Never) لا يستخدم امتدادات ZIP64 أبدًا.
- [Always](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Always) يستخدم امتدادات ZIP64 دائمًا.

يعرض الكود التالي كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/zip64mode/#Never)، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بصيغة ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بصيغة Office Open XML مع مستويات الضغط**

عند التعامل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق التوازن بين حجم الملف ووقت المعالجة. وفقًا لمتطلباتك، قد تفضل معالجة أسرع أو ملفات أصغر حجمًا.

توفر Aspose.Slides طريقة [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) التي تسمح بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بصيغة Office Open XML.

المستويات المتاحة هي:

- [**None**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#None): لا يتم تطبيق ضغط. تُحفظ الملفات كما هي.
- [**Level1**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level1): أسرع ضغط بأقل نسبة ضغط.
- [**Level2**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level2): ضغط أسرع مع نسبة ضغط أفضل قليلًا من **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level3): يوفر ضغطًا أفضل من **Level2** مع تأثير متوسط على وقت المعالجة.
- [**Level4**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level4): يوفر ضغطًا أفضل من **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level5): تحسين إضافي في الضغط مقارنةً **Level4** مع وقت معالجة إضافي.
- [**Level6**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level6): ضغط قياسي يوفّر توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- [**Level7**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level7): ضغط أفضل من **Level6** مع معالجة أبطأ.
- [**Level8**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level8): ضغط أفضل من **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compressionlevel/#Level9): أقصى ضغط. ينتج أصغر حجم ملف لكن بأطول وقت معالجة.

يوضح المثال التالي كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

هذا المثال يوضح كيفية حفظ عرض تقديمي كملف PPTX *بأقصى ضغط*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم الطريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) في توليد الصورة المصغرة عند حفظ العرض التقديمي بصيغة PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، فلن تُنشأ أي صورة.

في الشيفرة أدناه، يُحفظ العرض التقديمي بصيغة PPTX دون تحديث صورته المصغرة.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
هذا الخيار يساعد على تقليل الوقت اللازم لحفظ العرض التقديمي بصيغة PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يُستخدم الواجهة [IProgressCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprogresscallback/) عبر طريقة `setProgressCallback` التي تُ exposé من خلال الواجهة [ISaveOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprogresscallback/) باستخدام `setProgressCallback` لتلقي تحديثات حفظ التقدم كنسبة مئوية.

يعرض المقتطفان التاليان كيفية استخدام `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // استخدم قيمة نسبة التقدم هنا.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
طورت Aspose تطبيقًا مجانيًا لتقطيع PowerPoint عبر [free PowerPoint Splitter app](https://products.aspose.app/slides/ar/splitter) باستخدام واجهتها البرمجية. يسمح التطبيق بتقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم دعم "الحفظ السريع" (الحفظ التدريجي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف الكامل؛ لا يُدعم الحفظ التدريجي "السريع".

**هل من الآمن من الناحية المتعددة الخيوط حفظ نفس كائن Presentation من عدة خيوط؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) غير آمن للاستخدام المتعدد الخيوط؛ احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [Hyperlinks](/slides/ar/androidjava/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تدعم خصائص المستند القياسية [document properties](/slides/ar/androidjava/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.