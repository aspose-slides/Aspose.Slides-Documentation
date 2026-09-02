---
title: تحويل عروض PowerPoint إلى Markdown في Java
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في Java والتحكم في مكان حفظ الصور المصدرة بتنسيق bitmap و metafile و SVG وكيفية الإشارة إليها."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java تحويل عروض PPT و PPTX إلى Markdown للتوثيق، المواقع الساكنة، ترحيل المحتوى، وسير عمل التحكم بالإصدار. يمكنك اختيار نكهة Markdown، التحكم في كيفية تصيير محتوى الشريحة، وتحديد مكان حفظ الصور المصدرة وكيفية إشارة Markdown المُنشأة إليها.

بشكل افتراضي، يستخدم تصدير Markdown ناتج نصي فقط. لتصدير المحتوى البصري، اضبط نوع التصدير باستخدام طريقة [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) إلى القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownexporttype/). يُظهر `Sequential` عناصر الشريحة بشكل منفصل وفي الترتيب، بينما يجمع `Visual` العناصر المجمعة معًا للحفاظ على علاقاتها البصرية. قيمة `TextOnly` لا تُصدر موارد الصور، لذا لا تُستدعى ردود نداء حفظ الصور في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

قم بتحميل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/).

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

## **اختيار نكهة Markdown**

تتحكم طريقة [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) في مواصفة Markdown المستخدمة للإخراج. يتضمن تعداد [Flavor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/flavor/) CommonMark و GitHub Flavored Markdown وغيرها من المتغيّرات المدعومة.

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

## **تصدير الصور باستخدام السلوك الافتراضي لحفظ محلي**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) طريقتين لتكوين الصور المحفوظة محليًا:

- طريقة [setBasePath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) تحدد الدليل الأساسي لوثيقة Markdown ومواردها.
- طريقة [setImagesSaveFolderName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) تحدد المجلد الفرعي للصور. القيمة الافتراضية هي `Images`.

المثال التالي يصيغ المحتوى البصري، يكتب الصور إلى `output/assets`، ويخلق إشارات صورة نسبية في وثيقة Markdown:

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

يعمل هذا السلوك أيضًا كاحتياط عندما تُعيد معالج حفظ الصورة المخصص القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم طريقة [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) لتسجيل رد نداء للموارد غير SVG من نوع bitmap وmetafile التي تُصدر أثناء تصدير Markdown. يتلقى رد نداء `MarkdownImageSavingHandler` كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/)، قيمة [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/)، ورابط Markdown المُولد كمصفوفة عنصر واحد `String[]`. احفظ أو حمّل الصورة بالتنسيق المُزود، واستبدل `link[0]` بالإشارة التي يجب أن تظهر في ناتج Markdown.

الموارد المُصدرة بصيغة SVG تُعالج بشكل منفصل. سجل رد نداء باستخدام طريقة [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/). يتلقى رد نداء `MarkdownSvgImageSavingHandler` كائن [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) ومصفوفة عنصر واحد `String[] link`. لا يحتوي SVG على معامل `ImageFormat`؛ اكتب أو حمّل بيانات XML الخاصة به من طريقة [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) بدلاً من ذلك. اعتمادًا على وضع التصدير وتجميع العناصر البصرية، قد يُحول SVG في العرض المصدر إلى نقطة بيانات raster أو يُدمج مع محتوى آخر؛ ثم تُمرّر المورد غير SVG إلى رد نداء حفظ الصورة. سجّل كلا ردِّي النداء عندما يتطلب كل مورد بصري مُصدر معالجة مخصصة.

قيمة الإرجاع للمعالج تحدد من يُعالج الصورة:

- إرجاع `true` بعد أن يكون المعالج قد حفظ، حمّل، حول أو عالج الصورة بأي طريقة وعين قيمة صالحة إلى `link[0]`. يكتب Aspose.Slides هذه القيمة إلى وثيقة Markdown ولا يقوم بالحفظ المحلي الافتراضي.
- إرجاع `false` للسماح لـ Aspose.Slides بحفظ الصورة محليًا وتوليد رابطها وفق القيم التي تم ضبطها بواسطة [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="مهم" %}}
معالج يُرجع `true` يتحمل مسؤولية الصورة. إذا أرجع `true` دون تعيين رابط صالح غير فارغ، سيفشل التصدير مع استثناء `InvalidOperationException`.
{{% /alert %}}

### **حفظ الصور إلى دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يتعامل مع `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مُركب أو مُزامن. يستخرج كل معالج اسم الملف المُولد، ويحفظ الصورة إلى ذلك الدليل المخصص، ويستبدل الإشارة المحلية المُولدة بعنوان URL عام على CDN. لا يُجري العينة نفسها تحميلًا عبر الشبكة: يصبح الـ URL صالحًا فقط بعد تركيب الدليل كأصل CDN أو نشر ملفاته إلى CDN. لتخزين الكائنات، استبدل كتابة نظام الملفات بعملية رفع SDK التخزينية وعين `link[0]` فقط بعد نجاح الرفع.

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

معالج bitmap يُعيد عمدًا `false` للصور أصغر من 128 × 128 بكسل، لذلك يحفظ Aspose.Slides تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد bitmap وmetafile الأكبر، بالإضافة إلى موارد SVG، بواسطة الكود المخصص. على سبيل المثال، يتحول مرجع محلي مُولد مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ الروابط المكتوبة إلى Markdown تستخدم الشرط المائل للأمام وأسماء ملفات مُشفرة URL. طبق القاعدة نفسها عند بناء الروابط النسبية: استخدم `/`، وليس الفاصل الخاص بالنظام.

## **الأسئلة المتكررة**

**هل يمكن لمعالج واحد معالجة كلّ من الصور النقطية وSVG؟**

لا. استخدم [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) للموارد bitmap وmetafile المُصدرة و[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) للموارد المُصدرة كـ SVG. يوفر الأول كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/); يوفر الثاني كائن [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) يمكن قراءة بيانات SVG الخاصة به عبر [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/). يُعالج SVG المصدر الذي يُحول إلى raster أثناء التصدير عبر رد نداء حفظ الصورة بدلاً من ذلك.

**ماذا يحدث عندما يُرجع معالج حفظ الصورة `false`؟**

يستخدم Aspose.Slides سلوكه الافتراضي لحفظ محلي. يتحكم موقع الصورة والإشارة المولدة بالقيم التي تم ضبطها عبر [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/markdownsaveoptions/).

**هل يمكن للمعالج تقديم URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمعالج رفع الصورة إلى تخزين الكائنات أو تمريرها إلى خدمة أخرى، تعيين URL الناتج إلى `link[0]`، وإرجاع `true`. يجب أن يُكمل المعالج المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يُطلق تصدير Markdown استثناء `InvalidOperationException` من معالج؟**

يحدث هذا الاستثناء عندما يُرجع المعالج `true` لكنه لا يوفر رابطًا صالحًا. عيّن المسار النسبي أو URL الخارجي الذي يجب كتابته إلى Markdown قبل إرجاع `true`.

**أي فاصل مسار يجب أن تستخدمه روابط الصور؟**

استخدم الشرط المائل للأمام في روابط Markdown وعناوين URL. استخدم `Path.resolve` فقط لمسارات نظام الملفات، ثم أنشئ أو عدّل إشارة Markdown بشكل منفصل.

**هل تُحافظ الروابط التشعبية أثناء تصدير Markdown؟**

نعم. تُحافظ النصوص [hyperlinks](/slides/ar/java/manage-hyperlinks/) كروابط Markdown قياسية. لا تُحول [transitions](/slides/ar/java/slide-transition/) و[animations](/slides/ar/java/powerpoint-animation/) إلى Markdown.

**هل يمكن تحويل العروض التقديمية إلى Markdown بالتوازي؟**

يمكنك معالجة ملفات عروض تقديمية مختلفة بالتوازي، لكن لا تشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/java/multithreading/) واستخدم كائنًا منفصلًا لكل ملف.