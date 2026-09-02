---
title: حفظ العروض التقديمية في جافا
linktitle: حفظ العرض
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
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تيار
- نوع عرض محدد مسبقًا
- تنسيق Strict Office Open XML
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Java
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في جافا باستخدام Aspose.Slides — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

يصف [العروض المفتوحة في جافا](/slides/ar/java/open-presentation/) كيفية استخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) لفتح عرض تقديمي. يوضح هذا المقال كيفية إنشاء العروض وتخزينها. تحتوي فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) على محتويات العرض. سواءً كنت تنشئ عرضًا من الصفر أو تعدّل عرضًا موجودًا، فستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides for Java، يمكنك الحفظ إلى **ملف** أو **تيار**. يوضح هذا المقال الطرق المختلفة لحفظ العرض.

## **حفظ العروض إلى ملفات**

احفظ عرضًا إلى ملف عن طريق استدعاء طريقة `save` للفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). مرّر اسم الملف وصيغة الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض باستخدام Aspose.Slides.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // قم ببعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض إلى تيارات**

يمكنك حفظ عرض إلى تيار عن طريق تمرير تيار خروج إلى طريقة `save` للفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يمكن كتابة العرض إلى أنواع متعددة من التيارات. في المثال أدناه، نقوم بإنشاء عرض جديد وحفظه إلى تيار ملف.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // احفظ العرض التقديمي إلى التيار.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **حفظ العروض بنوع عرض محدد مسبقًا**

تتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المولّد عبر الفئة [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/). استخدم الطريقة [setLastView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة من تعدد [ViewType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewtype/).

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

## **حفظ العروض بالتنسيق الصارم Office Open XML**

تتيح لك Aspose.Slides حفظ عرض بتنسيق Strict Office Open XML. استخدم الفئة [PptxOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/) واضبط خاصية التوافق عند الحفظ. إذا قمت بتعيين [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)، سيتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا ويحفظه بتنسيق Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، كما يحد عدد الملفات في الأرشيف إلى 65 535 (2^16‑1) ملف. تمديدات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح طريقة [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) لك اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة بالأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Never) لا يستخدم امتدادات تنسيق ZIP64 أبدًا.
- [Always](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Always) يستخدم دائمًا امتدادات تنسيق ZIP64.

يوضح الشيفرة التالية كيفية حفظ عرض كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

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
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/java/com.aspose.slides/zip64mode/#Never)، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxexception/) إذا تعذر حفظ العرض بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض بتنسيق Office Open XML مع مستويات الضغط**

عند العمل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق توازن بين حجم الملف ووقت المعالجة. وفقًا لاحتياجاتك، قد تفضّل معالجة أسرع أو ملفات ناتجة أصغر.

توفر Aspose.Slides الطريقة [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) التي تتيح لك تحديد مستوى الضغط المستخدم عند حفظ عرض بتنسيق Office Open XML.

المستويات التالية للضغط متاحة:

- [**None**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#None): لا يتم تطبيق أي ضغط. تُحفظ الملفات كما هي.
- [**Level1**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level1): أسرع ضغط بأقل نسبة ضغط.
- [**Level2**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level2): ضغط أسرع مع نسبة ضغط أفضل قليلاً من **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level3): يوفر ضغطًا أفضل من **Level2** مع تأثير متوسط على وقت المعالجة.
- [**Level4**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level4): يوفر ضغطًا أفضل من **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level5): يوفر تحسينًا في الضغط مقارنةً **Level4** مع وقت معالجة إضافي.
- [**Level6**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level6): ضغط قياسي يقدم توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- [**Level7**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level7): يوفر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- [**Level8**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level8): يوفر ضغطًا أفضل من **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compressionlevel/#Level9): الضغط الأقصى. ينتج أصغر حجم ملف على حساب أطول وقت معالجة.

يوضح المثال التالي كيفية حفظ عرض كملف PPTX *بدون ضغط*:

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

يظهر هذا المثال كيفية حفظ عرض كملف PPTX مع *أقصى ضغط*:

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

## **حفظ العروض دون تحديث الصورة المصغرة**

تتحكم الطريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) في توليد الصورة المصغرة عند حفظ عرض إلى PPTX:

- إذا تم تعيينه إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم تعيينه إلى `false`، تُحفظ الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يتم إنشاء أي صورة.

في الشيفرة أدناه، يتم حفظ العرض إلى PPTX دون تحديث صورته المصغرة.

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
يساعد هذا الخيار في تقليل الوقت المطلوب لحفظ عرض بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/) عبر طريقة `setProgressCallback` التي تعرضها واجهة [ISaveOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isaveoptions/) والفئة التجريدية [SaveOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/) باستخدام `setProgressCallback` لتلقي تحديثات حفظ النسبة المئوية.

يوضح مقتطف الشيفرة التالي كيفية استخدام `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير [تطبيق مجاني لتقسيم PowerPoint](https://products.aspose.app/slides/ar/splitter) باستخدام API الخاص بها. يتيح لك التطبيق تقسيم عرض إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم دعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**  
لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ الحفظ التزايدي "السريع" غير مدعوم.

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بأمان؟**  
لا. كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) [ليس آمنًا ضد الخيوط المتعددة](/slides/ar/java/multithreading/); احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**  
[الروابط التشعبية](/slides/ar/java/manage-hyperlinks/) تُحفظ. الملفات المرتبطة خارجيًا (مثال: مقاطع الفيديو عبر مسارات نسبية) لا تُنسخ تلقائيًا — تأكّد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**  
نعم. يتم دعم [خصائص المستند القياسية](/slides/ar/java/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.