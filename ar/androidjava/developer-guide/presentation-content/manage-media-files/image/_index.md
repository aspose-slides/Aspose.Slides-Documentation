---
title: تحسين إدارة الصور في العروض التقديمية على Android
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/androidjava/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة بت ماب
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- موارد SVG الخارجية
- محلل SVG
- صور SVG المرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قُم بتبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، مع تحسين الأداء وأتمتة سير عملك."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالًا بصريًا. في Microsoft PowerPoint، يمكنك إدراج صور على الشرائح من الملفات أو الإنترنت أو مصادر أخرى. بشكل مماثل، يتيح Aspose.Slides إضافة الصور إلى شرائح العرض بطرق متعددة.

{{% alert title="نصيحة" color="info" %}} 
توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt) — والتي تتيح لك إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}
إذا كنت ترغب في إضافة صورة كإطار صورة — خاصةً إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى — راجع [إطار الصورة](/slides/ar/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}
يمكنك تحويل الصور من صيغة إلى أخرى. راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/androidjava/conversion/image-to-jpg/)، [JPG إلى صورة](https://products.aspose.com/slides/ar/androidjava/conversion/jpg-to-image/)، [JPG إلى PNG](https://products.aspose.com/slides/ar/androidjava/conversion/jpg-to-png/)، [PNG إلى JPG](https://products.aspose.com/slides/ar/androidjava/conversion/png-to-jpg/)، [PNG إلى SVG](https://products.aspose.com/slides/ar/androidjava/conversion/png-to-svg/)، و[SVG إلى PNG](https://products.aspose.com/slides/ar/androidjava/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides الصور بالصيغ الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهازك إلى شريحة عرض. يوضح رمز Java التالي كيفية إضافة صورة إلى شريحة:

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

إذا لم تكن الصورة التي تريد إضافتها إلى شريحة مخزنة على جهازك، يمكنك إضافتها مباشرةً من الويب. 

يوضح رمز Java التالي كيفية إضافة صورة من الويب إلى شريحة:

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

## **إضافة صور إلى قالب الشريحة**

يخزن قالب الشريحة ويسيطر على معلومات مثل السمة وتخطيط الشرائح التي تستخدمه. عند إضافة صورة إلى قالب الشريحة، تظهر الصورة على كل شريحة تعتمد على ذلك القالب. 

يوضح رمز Java التالي كيفية إضافة صورة إلى قالب الشريحة:

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

يمكنك استخدام صورة كخلفية لشريحة أو أكثر. للتفاصيل، راجع *[ضبط الصور كخلفيات للشرائح](/slides/ar/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة. 

يستورد مثال Java التالي سلسلة SVG متكاملة ذاتيًا. يتم تضمين جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا SVG مباشرةً في محتوى SVG.

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

قد تُشير ملفات SVG المُصدَّرة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط الأنابيب الويب إلى موارد مخزنة خارج مستند SVG. على سبيل المثال، قد يحتوي SVG على رابط صورة مثل `images/photo.png`، أو قيمة CSS `url(...)`، أو رابط خط. 

لإستيراد مثل هذا المحتوى، أنشئ تنفيذًا لـ[IExternalResourceResolver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iexternalresourceresolver/) ومرره، مع URI أساسي، إلى مُنشيء مناسب لـ[SvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgimage/). يحدد URI الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية. 

توفر واجهة [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) إمكانية الوصول إلى معلومات حول SVG المستورد:
- `getSvgContent()` تعيد ترميز SVG كسلسلة.
- `getSvgData()` تعيد محتوى SVG كمصفوفة بايت.
- `getBaseUri()` تعيد الـ URI الأساسي المستخدم للروابط النسبية.
- `getExternalResourceResolver()` تعيد المفسر المعين لصورة SVG.

### **تنفيذ مفسر موارد خارجية**

للمفسر طريقتان:
- `resolveUri` يجمع بين الـ URI الأساسي ورابط المورد النسبي ويعيد URI مطلق. أعد `null` عندما لا يمكن حل الرابط أو غير مسموح به.
- `getEntity` يعيد تدفقًا قابلًا للقراءة لمورد URI مطلق. أعد `null` عندما يكون المورد مفقودًا أو محظورًا أو غير متاح. يمكن أيضًا إرجاع تدفق احتياطي عند الاقتضاء.

يقوم المفسر التالي بتحميل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحظَر الموارد الشبكية والمسارات خارج الدليل المسموح به. يُعاد صورة احتياطية اختيارية للروابط غير المحلولة.

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

            // يسمح هذا المفسر عمدًا بملفات محلية فقط.
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

            // استخدم الاحتياطي فقط للموارد الصورة. إرجاع تدفق صورة
            // للخط أو ورقة الأنماط المفقودة لن يكون ذلك صالحًا.
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

يوضح مثال Java التالي تمرير URI ملف SVG كـ URI أساسي وتوفير مفسر مخصص. يحول المفسر رابط الصورة النسبي إلى URI مطلق ويعيد تدفقًا يحتوي على المورد المرتبط بينما تعالج Aspose.Slides الـ SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// يمثل معرف الـ URI الأساسي موقع مستند SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// تعرض ISvgImage المحتوى الأصلي، البيانات الثنائية، المعرف الأساسي، والمفسّر.
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

توفر فئة `SvgImage` أيضًا إصدارات تتقبل بيانات SVG كمصفوفة بايت أو تدفق إدخال، مع مفسر موارد خارجية وURI أساسي.

{{% alert title="مهم" color="warning" %}}
يجعل مفسر الموارد الموارد الخارجية متاحة أثناء معالجة Aspose.Slides وعرض SVG. لا يغيّر الترميز الأصلي للـ SVG ولا يضمّن الموارد المحلولة تلقائيًا فيه.

عند إضافة `ISvgImage` إلى مجموعة صور العرض، قد يحتوي ملف PPTX على كل من تمثيل SVG الأصلي وصورة نقطية احتياطية. يمكن للمورد المرتبط أن يظهر في الصورة الاحتياطية المُولَّدة بينما يبقى الرابط النسبي مثل `images/photo.png` دون تغيير في الـ SVG المخزن. لذلك قد يتجاهل التطبيق الذي يعرض تمثيل SVG الأصلي المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متاح.
{{% /alert %}}

### **إنشاء صورة SVG قابلة للنقل**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل الـ SVG متكاملًا ذاتيًا قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URIs من نوع `data:` تحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد تضمين جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما هو موضح في المثال السابق.

### **معالجة الموارد المفقودة أو المحجوبة**

أعد `null` من `resolveUri` عندما يكون URI المورد غير صالح أو محظور أو لا يمكن حله. أعد `null` من `getEntity` عندما لا يمكن قراءة المورد. تستمر Aspose.Slides في معالجة الـ SVG بدون ذلك المورد عندما يكون ذلك ممكنًا.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن يجب أن يكون محتواه متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أعد تدفق صورة فقط لمورد صورة مفقود، وليس لخط أو ورقة أنماط.

{{% alert title="الأمان" color="warning" %}}
لا تحل مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد المخططات، الدلائل، والمضيفين المسموح بهم. بالنسبة للموارد الشبكية، طبق أيضًا مهلات الاتصال، حدود حجم الاستجابة، والتحقق من صحة المحتوى.
{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مشابهًا للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة عبر نسخة overload من طريقة [addGroupShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) لواجهة [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISvgImage) كوسيطها الأول.

يوضح رمز Java التالي كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

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

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوجيهها لتناسب حجم الشريحة.
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

يتيح Aspose.Slides for Android عبر Java توليد صور EMF من أوراق Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض.

يوضح رمز Java التالي كيفية القيام بذلك:

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

// حفظ المصنف إلى تيار.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // إضافة الملف كما هو بحيث يبقى الصورة كمتجه EMF بدلاً من تحويلها إلى نقطية.
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

يتيح Aspose.Slides لك استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. يصف هذا القسم عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايت خام، أو مثيل [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات التالية:
1. حمّل ملف العرض الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.
5. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
6. اكتب العرض المعدل كملف PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
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

    // حفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="معلومات" color="info" %}}
مع محول Aspose المجاني [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif)، يمكنك بسهولة تحريك النص وإنشاء GIFs من النص. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يظل دقة الصورة الأصلية محفوظة بعد الإدراج؟**  
نعم. تُحافظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم الـ[picture](/slides/ar/androidjava/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح مرة واحدة؟**  
ضع الشعار على القالب الرئيسي أو تخطيط معين واستبدله في مجموعة صور العرض—ستنتشر التحديثات إلى جميع العناصر التي تستخدم ذلك المورد.

**هل يمكن تحويل SVG المدخلة إلى أشكال قابلة للتحرير؟**  
نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير بخصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح مرة واحدة؟**  
[عيّن الصورة كخلفية](/slides/ar/androidjava/presentation-background/) على القالب الرئيسي أو التخطيط المعني—ستورث جميع الشرائح التي تستخدم ذلك القالب/التخطيط الخلفية.

**كيف يمكنني منع العرض من أن يصبح كبيرًا جدًا بسبب العديد من الصور؟**  
أعد استخدام مورد صورة واحد بدلًا من تكراره، اختر دقات معقولة، طبق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة على القالب حيثما كان ذلك مناسبًا.