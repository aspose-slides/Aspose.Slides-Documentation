---
title: تحسين إدارة الصور في العروض التقديمية باستخدام JavaScript
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/nodejs-java/image/
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
- صور SVG المرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java، مع تحسين الأداء وأتمتة سير عملك."
---
## **مقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالًا بصريًا. في Microsoft PowerPoint، يمكنك إدراج صور على الشرائح من ملفات أو من الإنترنت أو من مصادر أخرى. وبالمثل، تتيح لك Aspose.Slides إضافة الصور إلى شرائح العرض بطرق عديدة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا أردت إضافة صورة كإطار صورة—خاصةً إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى—اطلع على [إطار الصورة](/slides/ar/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك تحويل الصور من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/nodejs-java/conversion/image-to-jpg/)، [JPG إلى صورة](https://products.aspose.com/slides/ar/nodejs-java/conversion/jpg-to-image/)، [JPG إلى PNG](https://products.aspose.com/slides/ar/nodejs-java/conversion/jpg-to-png/)، [PNG إلى JPG](https://products.aspose.com/slides/ar/nodejs-java/conversion/png-to-jpg/)، [PNG إلى SVG](https://products.aspose.com/slides/ar/nodejs-java/conversion/png-to-svg/)، و[SVG إلى PNG](https://products.aspose.com/slides/ar/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

تدعم Aspose.Slides الصور بالتنسيقات الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهازك إلى شريحة عرض. يعرض مثال JavaScript التالي كيفية إضافة صورة إلى شريحة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة التي تريد إضافتها إلى شريحة مخزنة على جهازك، يمكنك إضافتها مباشرة من الويب. 

يعرض مثال JavaScript التالي كيفية إضافة صورة من الويب إلى شريحة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إضافة صور إلى أسلاف الشرائح**

يخزن أسلاف الشرائح معلومات مثل السمة وتخطيط الشرائح التي تستخدمه. عند إضافة صورة إلى أسلاف الشريحة، تظهر الصورة على كل شريحة تعتمد على هذا الأساس. 

يعرض مثال JavaScript التالي كيفية إضافة صورة إلى أسلاف الشريحة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إضافة صور كخلفيات للشرائح**

يمكنك استخدام صورة كخلفية لشريحة أو أكثر. للتفاصيل، انظر *[تعيين الصور كخلفيات للشرائح](/slides/ar/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى العرض باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن صورة SVG الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة.

يعرض مثال JavaScript التالي استيراد سلسلة SVG متكاملة ذاتيًا. يتم تضمين جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا SVG مباشرة في محتوى SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استيراد محتوى SVG مع موارد خارجية**

قد تحتوي ملفات SVG المصدرة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط أنابيب الويب على مراجع لموارد مخزنة خارج مستند SVG. على سبيل المثال، قد يحتوي SVG على رابط صورة مثل `images/photo.png` أو قيمة CSS `url(...)` أو عنوان URL للخط.

لاستيراد مثل هذا المحتوى، قدم محلًّا للموارد الخارجية ومرره مع URI أساسي إلى منشئ [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/) المناسب. يحدد الـ URI الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية.

توفر فئة `SvgImage` الوصول إلى معلومات حول SVG المستورد:

- `getSvgContent()` تُعيد شفرة SVG كسلسلة نصية.
- `getSvgData()` تُعيد محتوى SVG كمصفوفة بايت.
- `getBaseUri()` تُعيد الـ URI الأساسي المستخدم للروابط النسبية.
- `getExternalResourceResolver()` تُعيد المُحَلِّل المُعين لصورة SVG.

### **تنفيذ محلّ للموارد الخارجية**

المحلّ له طريقتان:

- `resolveUri` يجمع الـ URI الأساسي ورابط المورد النسبي ويُعيد URI مطلق. أرجع `null` عندما لا يمكن حل الرابط أو يكون غير مسموح به.
- `getEntity` تُعيد تدفق Java قابل للقراءة لمورد URI مطلق. أرجع `null` عندما يكون المورد مفقودًا أو محظورًا أو غير متاح. يمكن أيضًا إرجاع تدفق احتياطي عندما يكون ذلك مناسبًا.

ينشئ المساعد التالي محلًّا يحمل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحظر الموارد الشبكية والمسارات خارج الدليل المسموح. تُرجع صورة احتياطية اختيارية للروابط غير المحلولة.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // هذا المحلّل يسمح بشكل متعمد بالملفات المحلية فقط.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // استخدم نسخة احتياطية فقط لموارد الصور. إرجاع تدفق صورة
                // لمورد خط أو ورقة أنماط مفقودة لن تكون صالحة.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **حل الموارد المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على إشارة نسبية مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

يمرر المثال التالي في JavaScript ملف SVG كـ URI أساسي ويوفر محلًّا مخصصًا. يحول المحلّل رابط الصورة النسبي إلى URI مطلق ويُعيد تدفقًا يحتوي على المورد المرتبط بينما تقوم Aspose.Slides بمعالجة SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// محدد URI الأساسي يمثل موقع مستند SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// تُظهر SvgImage محتوى المصدر والبيانات الثنائية ومحدد URI الأساسي والمُحلل.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

توفر فئة `SvgImage` أيضًا إصدارات مفرطة تقبل بيانات SVG كمصفوفة بايت، بالإضافة إلى طرق إنشاء مبنية على التدفق، مع محلّ موارد خارجية وURI أساسي.

{{% alert title="هام" color="warning" %}}

يجعل محلّ الموارد الخارجية الموارد المتاحة أثناء معالجة وعرض SVG بواسطة Aspose.Slides. لا يغيّر شفرة SVG الأصلية ولا يدمج الموارد المحلولة تلقائيًا فيها.

عند إضافة صورة SVG إلى مجموعة صور العرض، قد يحتوي ملف PPTX على تمثيل SVG الأصلي وصورة نقطية احتياطية. يمكن أن يظهر مورد مرتبط في الصورة الاحتياطية المُولدة بينما تبقى الإشارة النسبية مثل `images/photo.png` بدون تغيير في SVG المخزن. لذلك قد تتجاهل تطبيقات عرض تمثيل SVG الأصلي المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متوفر.

{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل SVG متكاملًا ذاتيًا قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URIs من نوع `data:` تحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد تضمين جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما هو موضح في المثال السابق.

### **معالجة الموارد المفقودة أو المحظورة**

أرجع `null` من `resolveUri` عندما يكون URI المورد غير صالح أو محظور أو لا يمكن حله. أرجع `null` من `getEntity` عندما لا يمكن قراءة المورد. تستمر Aspose.Slides في معالجة SVG بدون ذلك المورد عندما يكون ذلك ممكنًا.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن محتواه يجب أن يكون متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أرجع تدفق صورة فقط لمورد صورة مفقود، وليس للخط أو ورقة الأنماط.

{{% alert title="أمان" color="warning" %}}

لا تحل مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد المخططات المسموح بها، الأدلة، والمضيفين. بالنسبة للموارد الشبكية، طبق أيضًا مهلات اتصال، حدود حجم الاستجابة، والتحقق من صحة المحتوى.

{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مشابهًا للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

تُقدم هذه الوظيفة عبر نسخة مفرطة من طريقة [addGroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) في فئة [ShapeCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection) التي تستقبل كائن صورة SVG كوسيط أول.

يعرض مثال JavaScript التالي كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// اسم ملف SVG المصدر.
const svgFileName = "sample.svg";

// اسم ملف العرض الناتج.
const outPptxPath = "presentation.pptx";

// إنشاء عرض تقديمي جديد.
const presentation = new aspose.slides.Presentation();
try {
    // قراءة محتوى ملف SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // إنشاء كائن SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // الحصول على حجم الشريحة.
    const slideSize = presentation.getSlideSize().getSize();

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتناسب حجم الشريحة.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // حفظ العرض التقديمي بصيغة PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة صور كـ EMF إلى الشرائح**

يتيح Aspose.Slides for Node.js via Java إنشاء صور EMF من أوراق عمل Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض.

يعرض مثال JavaScript التالي كيفية القيام بذلك:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// احفظ دفتر العمل إلى تدفق.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // أضف الملف كما هو بحيث يبقى الصورة كـ EMF متجه بدلاً من تحويلها إلى نقطية.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استبدال الصور في مجموعة الصور**

تتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. يصف هذا القسم عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات التالية:

1. حمّل ملف العرض الذي يحتوي على صور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
1. في الطريقة الثانية، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.
1. في الطريقة الثالثة، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
1. احفظ العرض المعدل كملف PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // الطريقة الثانية.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // الطريقة الثالثة.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // احفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/ar/text-to-gif)، يمكنك بسهولة تحريك النص وإنشاء ملفات GIF من النص. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يبقى دقة الصورة الأصلية كما هي بعد الإدراج؟**

نعم. تُحفظ بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم الـ[picture](/slides/ar/nodejs-java/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على شريحة الأساس أو التخطيط واستبدله في مجموعة صور العرض—سيتماشى التحديث مع جميع العناصر التي تستخدم ذلك المورد.

**هل يمكن تحويل SVG مدخَل إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة أشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكن تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/nodejs-java/presentation-background/) على شريحة الأساس أو التخطيط الملائم—ستورث جميع الشرائح التي تستخدم ذلك الأساس/التخطيط الخلفية.

**كيف أُجنب أن يصبح العرض التقديمي كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتعددة، اختر دقة معقولة، طبق ضغطًا عند الحفظ، وحافظ على الرسومات المتكررة على الأساس حيثما كان ذلك مناسبًا.