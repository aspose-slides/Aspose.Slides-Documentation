---
title: تصدير العروض التقديمية إلى XAML في Java
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في Java باستخدام Aspose.Slides—حل سريع وخالي من Office يحافظ على تنسيقك دون تغيير."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة موجزة عن XAML، وتظهر طريقة حفظ عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية، وتوضح كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الطوارئ، وتوافق XAML مع أطر العمل المختلفة، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هو لغة توصيف مبنية على XML تُستخدم لوصف واجهات المستخدم في أطر مثل WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتعديل العلامات مباشرة.

## **تصدير العروض إلى XAML باستخدام الخيارات الافتراضية**

يوضح المثال التالي بلغة Java كيف يمكن تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:

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

بشكل افتراضي، يتم حفظ الشرائح المصدَّرَة في مجلد فرعي باسم `pres` داخل دليل العمل الحالي للعملية، ويتم حل المسار الفارغ باستخدام [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). يُنشأ المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُستمد اسم مجلد الإخراج من اسم ملف المصدر بدون الامتداد. بالنسبة للملف `pres.pptx`، تكون أسماء ملفات الإخراج `pres/Slide_1.xaml` و`pres/Slide_2.xaml` وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المدخل، يُنشأ مجلد الإخراج نسبياً إلى دليل العمل الحالي، وليس بجوار الملف المدخل.

## **تصدير العروض إلى XAML باستخدام خيارات مخصصّة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides للعرض إلى XAML.

لحفظ الناتج في موقع مخصَّص، نفّذ [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) ومرّر مثيل تنفيذك إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) في [XamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/).

لإدراج الشرائح المخفية في ناتج XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) مع القيمة `true`، كما هو موضح في المثال التالي بلغة Java:

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

## **التقاط جميع العناصر الناتجة عن XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة مُصدَّرة بالإضافة إلى صور منفصلة وموارد داعمة. عيّن [IXamlOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/) مخصَّصًا إلى [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) لتلقي هذه العناصر بدلاً من استخدام الحافظ الافتراضي لنظام الملفات. ابدأ التصدير باستخدام التحميل المخصَّص لـ XAML عبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) الذي يقبل خيارات XAML.

### **فهم دورة حياة رد الاتصال**

يقوم المُصدِّر باستدعاء [IXamlOutputSaver.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) بشكل منفصل لكل عنصر ناتج:

- `path` يحدد العنصر وقد يتضمن مسارات نسبية. احتفظ بهذه المعلومات لأن XAML قد يُشير إلى الموارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات العنصر. لا يجب فك تشفير الصور والموارد الثنائية الأخرى كنص.
- يتحمل الحافظ مسؤولية الاحتفاظ بالبيانات أو حفظها قبل الإرجاع. تنسخ الأمثلة كل مصفوفة بايتات إلى ذاكرة مملوكة للتطبيق.
- اعتبر عملية التصدير ناجحة فقط عندما تُعيد عملية حفظ العرض التقديمي وتكتمل كل ردود الاتصال بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث الحفظ لاحقًا، أبلغ عن النجاح العام فقط بعد أن ينجح ذلك الخط أيضًا.

يطبق [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) أيضًا على الحافظ المخصَّص. الإعداد الافتراضي `false` يستثني مستندات XAML للشرائح المخفية. تمرير القيمة `true` يضمن تضمينها وأي موارد مطلوبة لتصديرها. يعتمد عدد الموارد على العرض التقديمي؛ لا تفترض وجود رد اتصال واحد لكل شريحة أو ترتيب ثابت للردود.

### **التصدير إلى الذاكرة وفحص العناصر**

يقوم هذا المثال الكامل بتحميل `pres.pptx`، يجمع كل عنصر في [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)، ويطبع اسمه ونوعه وعدد بايتاته. يحافظ على الأسماء كما هي بالضبط. تُعلَّم الأسماء المكررة المجموعة كغير صالحة بدلاً من الكتابة فوق العنصر بصمت. يتحقق المثال من ذلك قبل استخدام النتائج.

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

    // فك ترميز XAML فقط، وفقط عندما تكون فحص النص مطلوبًا.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

تُعد فحوصات الامتداد مفيدة للتفتيش؛ احتفظ بجميع العناصر، بما في ذلك أنواع الموارد غير المألوفة. اترك البايتات دون تغيير عند التخزين أو النقل. استخدم مُنشئ [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) مع UTF-8 فقط للـ XAML الذي يحتاج إلى معالجة نصية.

### **تعبئة العناصر المجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من صحة أسمائه، ويكتب البايتات الأصلية في أرشيف ZIP. يميّز اسم الأرشيف الفريد بين وظائف التصدير المتزامنة. تستخدم إدخالات ZIP شرطة مائلة للأمام وتحتفظ بالدلائل النسبية. تُرفض الأسماء غير الآمنة أو المتصادمة بعد التطبيع قبل كتابة الحزمة بالكامل.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // تم الانتهاء من دليل ZIP بإغلاقه قبل الإبلاغ عن النجاح.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

يستخدم المثال [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) لكتابة أرشيف محلي واحد؛ المُصدِّر نفسه لا يكتب ملفات XAML أو صور منفصلة. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف برفع المصفوفات البايتية المجمعة. استخدم معرف وظيفة التصدير مع اسم العنصر النسبي الكامل كمفتاح للـ blob، أو خزن معرف الوظيفة والاسم النسبي والبيانات الثنائية في صفّ قاعدة بيانات. انشر الوظيفة فقط بعد اكتمال جميع الرفع أو بعد تأكيد المعاملة في قاعدة البيانات. نظّف المخرجات الجزئية إذا فشل الحفظ.

بالنسبة للعروض الكبيرة، يمكن للحافظ المخصَّص حفظ كل عنصر مباشرةً في تخزين التطبيق لتجنب الاحتفاظ بنسخة إضافية من التصدير الكامل في ذاكرة التطبيق. حافظ على تنفيذ كل رد اتصال بشكل متزامن من منظور المُصدِّر: لا تُعيد إلا بعد أن تقبل الوجهة البايتات، والسماح بالأخطاء للوصول إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من المراجع**

- طوّع فواصل المسارات عند الحاجة في الوجهة، لكن احتفظ بالدلائل النسبية. لا تستخدم [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) إلا إذا كان كل اسم مُولَّد معروفًا بأنه فريد وتبقى مراجع الموارد صالحة.
- طبّق تحققًا من صحة الاسم حسب الوجهة. عند كتابة ملفات منفصلة، رفض المسارات الجذرية ومقاطع الانتقال، حل الوجهة باستخدام [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--)، وتأكد من بقائها داخل دليل التصدير المقصود، بما في ذلك فاصل الدليل في فحص الاحتواء. استخدم دليلًا يتحكم به التطبيق دون روابط رمزية قد تُعيد توجيه الكتابة.
- استخدم حافظة ونطاق تخزين منفصل لكل وظيفة تصدير. اكتشف التصادمات بعد تطبيع الفواصل ووفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وتفحص مراجع الموارد القائمة على الملفات، مثل السمة `Source` أو `ImageSource` للصور. احل كل URI نسبيًا بالنسبة للدليل الذي يحتوي العنصر XAML، وطوّع الاسم الناتج، وتأكد من وجود المفتاح المقابل في الخريطة أو إدخال ZIP أو الكائن المخزن. عالج URIs الخارجية وتعابير XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذه العلاقة. بالنسبة للتخزين ككائن، احفظ نفس البنية تحت بادئة الوظيفة وجعل عناوين URL للموارد هذه متاحة للمستهلك XAML. أعد فتح ملف ZIP المكتمل للتحقق من أسماء الإدخالات وبيانات الموارد، وحمّل شرائح تمثيلية في بيئة XAML المستهدفة للتأكد من أن الصور تُحَلّ بشكل صحيح.

## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط ثابتة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في [XamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الأصلي مفقودًا. لا يضمن هذا أن الـ XAML المُولَّد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من أن الخطوط المشار إليها في XAML متوفرة في البيئة التي يُعرض فيها.

**هل الـ XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

تُصدِّر Aspose.Slides XAML الخاص بـ WPF عبر واجهتها العامة. لا يُضمن التوافق مع أطر XAML أخرى مثل UWP وXamarin.Forms. اختبر العلامات المُولَّدة في البيئة المستهدفة الخاصة بك.

**هل تُدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بحسب الإعداد الافتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) في [XamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xamloptions/) — أبقِها مُعطَّلة إذا لم تحتاج إلى تصديرها.