---
title: تحويل عروض PowerPoint إلى Markdown على Android
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/androidjava/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown على Android عبر Java والتحكم في مكان حفظ الصور المصدرة من نوع bitmap و metafile و SVG وكيفية الإشارة إليها."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android via Java تحويل عروض PPT و PPTX إلى Markdown للتوثيق، المواقع الثابتة، ترحيل المحتوى، وسير عمل التحكم بالإصدارات. يمكنك اختيار نسخة Markdown، التحكم في طريقة عرض محتوى الشريحة، وتحديد مكان تخزين الصور المصدرة وكيفية إشارة Markdown إليها.

بشكل افتراضي، تصدير Markdown يستخدم إخراج نصي فقط. لتصدير المحتوى البصري، اضبط نوع التصدير باستخدام طريقة [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) إلى القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` يعرض عناصر الشريحة بشكل منفصل وعلى الترتيب، بينما `Visual` يبقي العناصر المجمعة معًا للحفاظ على علاقتها البصرية. القيمة `TextOnly` لا تُصدر موارد الصور، لذا لا تُستدعى ردود استدعاء حفظ الصورة في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **اختيار نسخة Markdown**

طريقة [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) تتحكم في مواصفة Markdown المستخدمة للإخراج. تعداد [Flavor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/flavor/) يتضمن CommonMark، GitHub Flavored Markdown، وغيرها من المتغيرات المدعومة.

المثال التالي يصدر عرضًا تقديميًا كـ CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) توفر طريقتين لتكوين الصور المحفوظة محليًا:

- [setBasePath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) يحدد الدليل الأساسي لمستند Markdown وموارده.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) يحدد المجلد الفرعي للصور. قيمته الافتراضية هي `Images`.

المثال التالي يعرض المحتوى البصري، يكتب الصور إلى `output/assets`، وينشئ إشارات صور نسبية في مستند Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

هذا السلوك يعمل أيضًا كحل احتياطي عندما تُعيد معالج حفظ الصور المخصص القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم طريقة [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) لتسجيل رد استدعاء للموارد bitmap و metafile غير SVG التي تُصدر أثناء تصدير Markdown. رد الاستدعاء `MarkdownImageSavingHandler` يتلقى كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/)، قيمته [ImageFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/)، ورابط Markdown المُولد كمعامل `String[]` من عنصر واحد. احفظ أو ارفع الصورة بالصيغة المقدَّمة، واستبدل `link[0]` بالإشارة التي يجب أن تظهر في ناتج Markdown.

الموارد التي تُصدر بصيغة SVG تُعالج بشكل منفصل. سجّل رد استدعاء باستخدام طريقة [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/). رد الاستدعاء `MarkdownSvgImageSavingHandler` يتلقى كائن [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) ومعامل `String[] link` من عنصر واحد. لا يحتوي SVG على معامل `ImageFormat`؛ اكتب أو ارفع بيانات XML الخاصة به من طريقة [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) بدلاً من ذلك. اعتمادًا على وضع التصدير وتجميع العناصر البصرية، قد يتم تحويل SVG في العرض المصدر إلى نقطية أو دمجها مع محتوى آخر؛ ثم يُمرَّر المورد غير SVG إلى رد استدعاء حفظ الصورة. سجِّل كلا الردين عندما يتطلب كل مورد بصري مصدر معالجة مخصصة.

قيمة الإرجاع للمعالج تحدد من يعالج الصورة:

- إرجاع `true` بعد أن يحفظ المعالج الصورة أو يرفعها أو يُحوِّلها أو يعالجها بأي طريقة أخرى ويعيّن قيمة صالحة إلى `link[0]`. تقوم Aspose.Slides بكتابة تلك القيمة إلى مستند Markdown ولا تُجري الحفظ المحلي الافتراضي.
- إرجاع `false` لترك Aspose.Slides تحفظ الصورة محليًا وتولد رابطها وفق القيم المحددة بواسطة [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

معالج يُرجع `true` يتحمل مسؤولية الصورة. إذا أرجع `true` دون تعيين رابط صالح غير فارغ، سيفشل التصدير مع استثناء `InvalidOperationException`.

{{% /alert %}}

### **حفظ الصور إلى دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يعامل `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مركب أو متزامن. كل معالج يستخرج اسم الملف المُولد، يحفظ الصورة إلى ذلك الدليل المخصص، ويستبدل الإشارة المحلية المُولدة بعنوان URL عام لـ CDN. العينة نفسها لا تُجري رفعًا شبكيًا: يصبح عنوان URL صالحًا فقط بعد أن يُركّب الدليل كأصل CDN أو تُنشر ملفاته إلى CDN. لتخزين الكائنات، استبدل كتابة نظام الملفات بعملية الرفع من SDK التخزين وعيّن `link[0]` فقط بعد نجاح الرفع.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

معالج bitmap يُعيد عمدًا `false` للصور أصغر من 128 × 128 بكسل، لذا تقوم Aspose.Slides بحفظ تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد bitmap و metafile الأكبر، بالإضافة إلى موارد SVG، بواسطة الكود المخصص. على سبيل المثال، تُصبح الإشارة المحلية المُولدة مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ الروابط المكتوبة إلى Markdown تستخدم شرطات مائلة للأمام وأسماء ملفات مُهربة في URL. طبّق القاعدة نفسها عند بناء الروابط النسبية: استخدم `/`، لا الفاصل الخاص بالمنصة.

## **الأسئلة المتكررة**

**هل يمكن لمعالج واحد معالجة كل من الصور النقطية وصور SVG؟**

لا. استخدم [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) للموارد bitmap و metafile المُصدرة و[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) للموارد المُصدرة كـ SVG. الأول يوفّر كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/)، والثاني يوفّر كائن [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) يمكن قراءة بيانات SVG الخاصة به عبر [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/). يُعالج SVG المصدر الذي يتحول إلى نقطية أثناء التصدير عبر رد استدعاء حفظ الصورة بدلاً من ذلك.

**ماذا يحدث عندما يُعيد معالج حفظ الصورة القيمة `false`؟**

تستخدم Aspose.Slides سلوك الحفظ المحلي الافتراضي. يتم التحكم في موقع الصورة والإشارة المُولدة بالقيم التي تم ضبطها بواسطة [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/markdownsaveoptions/).

**هل يمكن للمعالج تقديم عنوان URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمعالج رفع الصورة إلى تخزين الكائنات أو تمريرها إلى خدمة أخرى، تعيين عنوان URL الناتج إلى `link[0]`، وإرجاع `true`. يجب أن يُكمِل المعالج المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يلقي تصدير Markdown استثناء `InvalidOperationException` من معالج؟**

يحدث هذا الاستثناء عندما يُعيد المعالج `true` لكنه لا يقدم رابطًا صالحًا. عيّن المسار النسبي أو عنوان URL الخارجي الذي يجب كتابةه إلى Markdown قبل إرجاع `true`.

**ما هو الفاصل الذي يجب أن تستخدمه روابط الصور؟**

استخدم الشرطات المائلة للأمام في روابط Markdown وعناوين URL. استخدم `Path.resolve` فقط لمسارات نظام الملفات، ثم كوّن أو عيّن مرجع Markdown بشكل منفصل.

**هل يتم الحفاظ على الروابط التشعبية أثناء تصدير Markdown؟**

نعم. تُحافظ الروابط النصية [hyperlinks](/slides/ar/androidjava/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل انتقالات الشرائح [transitions](/slides/ar/androidjava/slide-transition/) ولا الرسوم المتحركة [animations](/slides/ar/androidjava/powerpoint-animation/).

**هل يمكن تحويل العروض التقديمية إلى Markdown بشكل متوازي؟**

يمكنك معالجة ملفات عرض تقديمي مختلفة بشكل متوازي، لكن لا تُشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/androidjava/multithreading/) واستخدم نسخة منفصلة لكل ملف.