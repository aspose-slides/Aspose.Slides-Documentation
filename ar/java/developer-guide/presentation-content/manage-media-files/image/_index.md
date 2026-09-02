---
title: تحسين إدارة الصور في العروض التقديمية باستخدام Java
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/java/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة صورة نقطية
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- موارد SVG الخارجية
- محلل SVG
- صور SVG مرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java، تحسين الأداء وأتمتة سير العمل الخاص بك."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالاً بصرياً. في Microsoft PowerPoint، يمكنك إدراج صور على الشرائح من ملفات أو الإنترنت أو مصادر أخرى. وبالمثل، يسمح Aspose.Slides لك بإضافة صور إلى شرائح العرض بطرق عدة.

{{% alert  title="Tip" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

إذا رغبت في إضافة صورة كإطار صورة—خاصة إذا كنت تخطط لتغيير حجمها أو تطبيق مؤثرات أو استخدام خيارات تنسيق قياسية أخرى—اطّلع على [إطار الصورة](/slides/ar/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

يمكنك تحويل الصور من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/java/conversion/image-to-jpg/)، [JPG إلى صورة](https://products.aspose.com/slides/ar/java/conversion/jpg-to-image/)، [JPG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/jpg-to-png/)، [PNG إلى JPG](https://products.aspose.com/slides/ar/java/conversion/png-to-jpg/)، [PNG إلى SVG](https://products.aspose.com/slides/ar/java/conversion/png-to-svg/)، و[SVG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides الصور بالتنسيقات الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهازك إلى شريحة عرض. يوضح مثال كود Java التالي كيفية إضافة صورة إلى شريحة:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة التي تريد إضافتها مخزنة على جهازك، يمكنك إضافتها مباشرة من الويب. 

يعرض مثال كود Java التالي كيفية إضافة صورة من الويب إلى شريحة:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **إضافة صور إلى القوالب الرئيسية للشرائح**

القالب الرئيسي للشرائح يخزن ويتحكم في معلومات مثل السمة والتخطيط للشرائح التي تستخدمه. عند إضافة صورة إلى القالب الرئيسي، تظهر الصورة على كل شريحة تعتمد على ذلك القالب. 

يعرض مثال كود Java التالي كيفية إضافة صورة إلى القالب الرئيسي للشرائح:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إضافة صور كخلفيات للشرائح**

يمكنك استخدام صورة كخلفية لشريحة أو أكثر. للحصول على تفاصيل، راجع *[تعيين الصور كخلفيات للشرائح](/slides/ar/java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgimage/). يمكن بعد ذلك إضافة الكائن [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة.

يعرض مثال Java التالي استيراد سلسلة SVG مستقلة. جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا SVG مدمجة مباشرة في محتوى SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استيراد محتوى SVG مع موارد خارجية**

قد تشير ملفات SVG المستخرجة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط أنابيب الويب إلى موارد مخزنة خارج مستند SVG. على سبيل المثال، يمكن أن يحتوي SVG على رابط صورة مثل `images/photo.png` أو قيمة CSS `url(...)` أو عنوان URL للخط.

لاستيراد مثل هذا المحتوى، أنشئ تنفيذًا لـ [IExternalResourceResolver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iexternalresourceresolver/) ومرره، مع URI أساسي، إلى مُنشئ مناسب لـ [SvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgimage/). يحدد الـ URI الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية.

توفر واجهة [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) إمكانية الوصول إلى معلومات حول SVG المستورد:

- `getSvgContent()` تُرجع ترميز SVG كسلسلة نصية.
- `getSvgData()` تُرجع محتوى SVG كمصفوفة بايت.
- `getBaseUri()` تُرجع الـ URI الأساسي المستخدم للروابط النسبية.
- `getExternalResourceResolver()` تُرجع المحلل المعيّن لصورة SVG.

### **تنفيذ محلل موارد خارجية**

للمحلل طريقتان:

- `resolveUri` يجمع الـ URI الأساسي وروابط الموارد النسبية ويُرجع URI مطلق. أرجع `null` عندما لا يمكن حل الرابط أو غير مسموح به.
- `getEntity` تُرجع تدفقًا قابلًا للقراءة للـ URI المطلق للموارد. أرجع `null` عندما تكون الموارد مفقودة أو محجوبة أو غير متاحة. يمكن أيضًا إرجاع تدفق احتياطي عندما يكون ذلك مناسبًا.

يعرض المثال التالي محللًا يحمل الموارد المرتبطة فقط من دليل محلي مسموح. تُحظر الموارد الشبكية والمسارات خارج الدليل المسموح. يُرجع صورة احتياطية اختيارية للروابط غير المحلولة.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // هذا المحلل يسمح بملفات محلية فقط عن قصد.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // استخدم نسخة احتياطية فقط لموارد الصور. إرجاع تدفق صورة
            // لخط مفقود أو ورقة أنماط لن يكون صالحًا.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **حل الموارد المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على إشارة نسبية مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

يعرض مثال Java التالي تمرير URI ملف SVG كـ URI أساسي وتوفير محلل مخصص. يقوم المحلل بتحويل رابط الصورة النسبي إلى URI مطلق ويُرجع تدفقًا يحتوي على المورد المرتبط بينما يعالج Aspose.Slides الـ SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// تمثل URI الأساسية موقع مستند SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage تعرض المحتوى الأصلي والبيانات الثنائية وURI الأساسي والمحلل.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر فئة `SvgImage` أيضًا تحميلات إضافية تقبل بيانات SVG كمصفوفة بايت أو تدفق إدخال، إلى جانب محلل موارد خارجية وURI أساسي.

{{% alert title="Important" color="warning" %}}

يُتيح محلل الموارد توفير الموارد الخارجية أثناء معالجة Aspose.Slides للـ SVG وعرضه. لا يقوم بتعديل ترميز SVG الأصلي ولا يدمج الموارد المحلولة تلقائيًا فيه.

عند إضافة `ISvgImage` إلى مجموعة صور العرض، قد يحتوي ملف PPTX على تمثيل SVG الأصلي وصورة نقطية احتياطية. قد تظهر المورد المرتبط في الصورة الاحتياطية المولدة بينما يبقى الرابط النسبي مثل `images/photo.png` دون تغيير في SVG المخزن. وبالتالي قد يتجاهل التطبيق الذي يعرض تمثيل SVG الأصلي المحتوى المرتبط عندما تكون الموارد الخارجية غير متوفرة.

{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل SVG ذاتية المحتوى قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URI من نوع `data:` يحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد دمج جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، وأضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما هو موضح في المثال السابق.

### **معالجة الموارد المفقودة أو المحجوبة**

أرجع `null` من `resolveUri` عندما يكون URI المورد غير صالح أو محظور أو لا يمكن حله. أرجع `null` من `getEntity` عندما لا يمكن قراءة المورد. يستمر Aspose.Slides في معالجة SVG دون ذلك المورد عندما يكون ذلك ممكنًا.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن محتواه يجب أن يكون متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أرجع تدفق صورة فقط لمورد صورة مفقودة، وليس للخط أو ورقة الأنماط.

{{% alert title="Security" color="warning" %}}

لا تحلّ مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد المخططات المسموح بها، الدلائل، والمضيفين. بالنسبة للموارد الشبكية، طبّق أيضًا مهلات اتصال، حدود حجم الاستجابة، وتحقق من محتوى الموارد.

{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مشابهًا للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة من خلال تحميلة طريقة [addGroupShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) في واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISvgImage) كمعامل أول.

يعرض مثال كود Java التالي كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// اسم ملف SVG المصدر.
String svgFileName = "sample.svg";

// اسم ملف العرض الناتج.
String outPptxPath = "presentation.pptx";

// إنشاء عرض تقديمي جديد.
IPresentation presentation = new Presentation();
try {
    // قراءة محتوى ملف SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // إنشاء كائن SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // الحصول على حجم الشريحة.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتناسب حجم الشريحة.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // حفظ العرض بصيغة PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **إضافة صور كـ EMF إلى الشرائح**

يسمح Aspose.Slides for Java لك بإنشاء صور EMF من أوراق Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض.

يعرض مثال كود Java التالي كيفية القيام بذلك:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// احفظ مصنف العمل إلى تدفق.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // أضف الملف كما هو بحيث يبقى الصورة كـ EMF متجهة بدلاً من تحويلها إلى نقطية.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides لك استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. يصف هذا القسم عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايتية خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/)، أو صورة أخرى موجودة مسبقًا في المجموعة.

اتبع الخطوات التالية:

1. حمّل ملف العرض الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
1. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن.
1. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة مسبقًا في مجموعة صور العرض.
1. احفظ العرض المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // الطريقة الثانية.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // الطريقة الثالثة.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // حفظ العرض إلى ملف.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

باستخدام محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/ar/text-to-gif)، يمكنك تحريك النص بسهولة وإنشاء ملفات GIF من النص. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل تبقى دقة الصورة الأصلية كما هي بعد الإدراج؟**

نعم. يتم الحفاظ على بيكسلات المصدر، لكن المظهر النهائي يعتمد على طريقة تحجيم [الصورة](/slides/ar/java/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو التخطيط واستبدله في مجموعة صور العرض—ستنتشر التغييرات إلى جميع العناصر التي تستخدم ذلك المورد.

**هل يمكن تحويل SVG المُدرج إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكن تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/java/presentation-background/) على الشريحة الرئيسية أو التخطيط المعني—ستُورث جميع الشرائح التي تستخدم ذلك القالب/التخطيط الخلفية.

**كيف أمنع أن يصبح العرض كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من تكرارها، اختر دقة معقولة، طبّق ضغطًا عند الحفظ، واحتفظ بالرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.