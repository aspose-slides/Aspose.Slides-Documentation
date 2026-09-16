---
title: تصدير العروض التقديمية إلى XAML على أندرويد
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/androidjava/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- عرض تقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- أندرويد
- جافا
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في جافا باستخدام Aspose.Slides لأندرويد—حل سريع وخالٍ من Office يحافظ على تنسيقك كما هو."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides for Android عبر Java. تتضمن مقدمة موجزة عن XAML، وتظهر كيفية حفظ عرض تقديمي إلى XAML بإعدادات افتراضية، وتوضح كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الاستبدال، توافق XAML stack، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هي لغة توصيف قائمة على XML تُستخدم لوصف واجهات المستخدم في أطر مثل WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتحرير العلامات مباشرة.

## **تصدير العروض إلى XAML بإعدادات افتراضية**

يوضح مثال Java التالي كيفية تصدير عرض تقديمي إلى XAML بإعدادات افتراضية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

بشكل افتراضي، تُحفظ الشرائح المُصدَّرة في مجلد فرعي `pres` داخل دليل العمل الحالي للعملية. يتم إنشاء المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُؤخذ اسم مجلد الإخراج من اسم ملف المصدر دون امتداده. بالنسبة لـ `pres.pptx`، تُسمَّى ملفات الإخراج `pres/Slide_1.xaml`، `pres/Slide_2.xaml`، وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المدخل، يُنشأ مجلد الإخراج بالنسبة إلى دليل العمل الحالي، وليس بجوار ملف الإدخال.

على Android، استخدم ملف إدخال يمكن الوصول إليه من قبل تطبيقك. قد لا يكون دليل العمل الحالي قابلًا للكتابة؛ استخدم Saver مخرجات مخصص للاحتفاظ بالتصدير في الذاكرة أو كتابته إلى تخزين التطبيق، كما هو موضح أدناه. XAML المُولد لـ WPF مخصص لمستهلك متوافق وليس مورد تخطيط Android.

## **تصدير العروض إلى XAML بإعدادات مخصصة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides لعرض تقديمي إلى XAML.

لحفظ الناتج إلى موقع مخصص، نفّذ [IXamlOutputSaver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ixamloutputsaver/) ومرّر مثيلًا لتنفيذه إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) في [XamlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/).

لضم الشرائح المخفية إلى ناتج XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) بالقيمة `true`، كما هو موضح في مثال Java التالي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **التقاط جميع القطع الناتجة من XAML**

قد ينتج تصدير XAML مستند XAML لكل شريحة مُصدَّرة بالإضافة إلى صور منفصلة وموارد داعمة. عيّن [IXamlOutputSaver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ixamloutputsaver/) مخصصًا إلى [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) لاستلام هذه القطع بدلًا من استخدام الحفظ الافتراضي على نظام الملفات. ابدأ التصدير باستخدام التحميل المتخصص لـ XAML في طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) التي تقبل XamlOptions.

### **فهم دورة حياة النداءات الراجعية**

يقوم المُصدر باستدعاء [IXamlOutputSaver.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) بصورة منفصلة لكل قطعة ناتجة:

- `path` يُعرّف القطعة وقد يشمل دلائل نسبية. احتفظ بهذه المعلومة لأن XAML قد يشار إلى الموارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات القطعة. لا يجب فك تشفير الصور والموارد الثنائية الأخرى كنص.
- الـ Saver مسؤول عن الاحتفاظ بالبيانات أو حفظها قبل الإرجاع. تُنسخ الأمثلة كل مصفوفة بايتات إلى الذاكرة الخاصة بالتطبيق.
- اعتبر عملية التصدير ناجحة فقط عندما تُعيد عملية حفظ العرض التقديمي وتُكمل كل نداء راجعي بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث الحفظ لاحقًا، أبلغ عن النجاح الكلي فقط بعد أن ينجح هذا الخطوة أيضًا.

يطبق [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) أيضًا على Saver مخصص. الإعداد الافتراضي `false` يستبعد مستندات XAML للشرائح المخفية. تمرير `true` يضمّها وأي موارد مطلوبة لتصديرها. عدد الموارد يعتمد على العرض التقديمي؛ لا تفترض وجود نداء راجعي واحد لكل شريحة أو ترتيب ثابت للنداءات.

### **التصدير إلى الذاكرة وفحص القطع**

هذا المثال الكامل يحمل `pres.pptx`، يجمع كل قطعة في [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)، ويطبع اسمها ونوعها وعدد البايتات. يحافظ على الأسماء المقدَّمة تمامًا. الأسماء المكررة تجعل التجميع غير صالح بدلًا من الكتابة الصامتة على قطعة. يتحقق المثال من ذلك قبل استخدام النتائج.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // فك ترميز XAML فقط، وفقط عندما يكون الفحص النصي مطلوبًا.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

تُعد فحوصات الامتداد مفيدة للتفتيش؛ احتفظ بجميع القطع، بما في ذلك أنواع الموارد غير المألوفة. اترك البايتات دون تغيير عند التخزين أو النقل. استخدم المُنشئ [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) مع UTF-8 فقط لـ XAML الذي يحتاج إلى معالجة نصية.

### **حزم القطع المجمّعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من أسمائه، ويكتب البايتات الأصلية إلى أرشيف ZIP. استبدل `/path/to/app/files` بالمسار الذي تُرجعه طريقة [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) في سياق Android الخاص بك. اسم الأرشيف الفريد يفصل بين وظائف التصدير المتزامنة. تستخدم إدخالات ZIP الشرط المائل إلى الأمام وتحتفظ بالدلائل النسبية. تُرفض الأسماء غير الآمنة أو المتصادمّة بعد التطبيع قبل كتابة الحزمة بالكامل.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // تم إتمام دليل ZIP بإغلاقه قبل الإبلاغ عن النجاح.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

يستخدم المثال [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) لكتابة أرشيف محلي واحد؛ لا يكتب المُصدر ملفات XAML أو صور منفصلة بمفردها. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بتحميل المصفوفات البايتيّة المجمعة. استخدم معرف مهمة التصدير زائد الاسم النسبي الكامل للقطعة كمفتاح blob، أو خزن معرف المهمة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر المهمة فقط بعد إكمال جميع التحميلات أو ارتكاب معاملة قاعدة البيانات. نظّف المخرجات الجزئية إذا فشل الحفظ.

للعروض الكبيرة، يمكن لـ Saver مخصص حفظ كل قطعة مباشرة إلى تخزين التطبيق لتفادي حفظ نسخة إضافية من كامل التصدير في الذاكرة. اجعل كل نداء راجعي متزامنًا من منظور المُصدر: ارجع فقط بعد أن تقبل الوجهة البايتات، واسمح للأخطاء بالوصول إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من المراجع**

- طوّع فواصل المسار عندما يتطلب الوجهة ذلك، لكن حافظ على الدلائل النسبية. لا تستخدم [File.getName](https://developer.android.com/reference/java/io/File#getName()) إلا إذا عُرفت كل أسماء القطع بأنها فريدة وأن مراجع الموارد لا تزال صالحة.
- طبّق تدقيق أسماء خاص بالوجهة. عند كتابة ملفات منفصلة، ارفض المسارات الجذرية وأقسام العبور، حل الوجهة باستخدام [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath())، وتأكد من بقائها داخل دليل التصدير المستهدف، بما في ذلك فاصل الدليل في اختبار الاحتواء. استخدم دليلًا يتحكم به التطبيق دون روابط رمزية قد تعيد توجيه الكتابة.
- استخدم Saver ومساحة أسماء تخزين منفصلة لكل مهمة تصدير. اكتشف التضاربات بعد تطبيع الفواصل وفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وتفقد مراجع الموارد القائمة على الملفات، مثل سمة `Source` أو `ImageSource` في الصورة. حل كل URI نسبي ضد دليل القطعة XAML الحاوية، طوّع الاسم الناتج، وتأكد من وجود المفتاح المقابل في الخريطة أو إدخال ZIP أو الكائن المخزن. عالج الـ URIs الخارجية وتعابير XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذه العلاقة. بالنسبة للتخزين الكائني، احفظ نفس البنية تحت بادئة المهمة واجعل عناوين URL لتلك الموارد متاحة للمستهلك XAML. أعد فتح ZIP المكتمل للتحقق من أسماء الإدخالات وبايتات الموارد، وحمّل شرائح تمثيلية في بيئة XAML الهدف لتأكيد أن الصور تُحَل بصورة صحيحة.

## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متنبأة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في [XamlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الخط الأصلي مفقودًا. هذا لا يضمن أن XAML المُولد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من توفر الخطوط التي يشار إليها في XAML في البيئة التي يُعرض فيها.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

يصدِّر Aspose.Slides XAML لـ WPF عبر API العامة له. التوافق مع أطر XAML أخرى مثل UWP وXamarin.Forms غير مضمون. اختبر العلامات المُولَّدة في البيئة المستهدفة.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

افتراضيًا، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) في [XamlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xamloptions/) — أبقِها معطَّلة إذا لم تحتاج لتصديرها.