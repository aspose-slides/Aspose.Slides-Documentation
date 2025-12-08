---
title: صورة
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
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- EMF
- SVG
- Node.js
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى إلى الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية عبر إجراءات مختلفة. 

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
إذا كنت ترغب في إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها، أو إضافة تأثيرات، وما إلى ذلك—انظر إلى [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides عمليات الصور بهذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يعرض لك هذا المثال البرمجي بجافاسكريبت كيفية إضافة صورة إلى شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة صور من الدفق إلى الشرائح**

إذا كانت الصورة التي ترغب في إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرة من الويب.

يعرض لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة باستخدام جافاسكريبت:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // تحميل ملف إكسل إلى تدفق
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // إنشاء كائن بيانات للتضمين
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // إضافة شكل إطار كائن Ole
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // كتابة ملف PPTX إلى القرص
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة صور إلى ماستر الشرائح**

ماستر الشريحة هو الشريحة العليا التي تخزن وتتحكم في معلومات (المظهر، التخطيط، إلخ) حول جميع الشرائح تحته. لذا، عندما تضيف صورة إلى ماستر الشريحة، تظهر تلك الصورة على كل شريحة تحت ذلك الماستر.

يعرض لك هذا المثال البرمجي بجافاسكريبت كيفية إضافة صورة إلى ماستر الشريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة صور كخلفية للشريحة**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) التي تنتمي إلى فئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام فئة PPImage

يعرض لك هذا المثال البرمجي كيفية تنفيذ الخطوات المذكورة أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل SVG إلى مجموعة من الأشكال**

تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للعمل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة أحد التجاوزات لطريقة [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) من فئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) التي تأخذ كائن [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) كمعامل أول.

يعرض لك هذا المثال البرمجي كيفية استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
```javascript
// إنشاء عرض تقديمي جديد
var presentation = new aspose.slides.Presentation();
try {
    // قراءة محتوى ملف SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // إنشاء كائن SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // الحصول على حجم الشريحة
    var slideSize = presentation.getSlideSize().getSize();
    // تحويل صورة SVG إلى مجموعة من الأشكال وتعديل حجمها لتناسب حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // حفظ العرض التقديمي بصيغة PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إضافة صور كـ EMF في الشرائح**

يتيح Aspose.Slides لـ Node.js عبر Java إمكانية إنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

يعرض لك هذا المثال البرمجي كيفية تنفيذ المهمة الموصوفة:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
    // حفظ المصنف إلى تدفق
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **استبدال الصور في مجموعة الصور**

يتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر الواجهة البرمجية طرقًا بسيطة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات التالية:

1. تحميل ملف العرض التقديمي الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، قم بتحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن.
5. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
6. احفظ العرض التقديمي المعدل كملف PPTX.
```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // الطريقة الثانية.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // الطريقة الثالثة.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // حفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، وإنشاء ملفات GIF من النصوص، وغيرها. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تبقى دقة الصورة الأصلية سليمة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، ولكن المظهر النهائي يعتمد على كيفية تحجيم الـ [picture](/slides/ar/nodejs-java/picture-frame/) في الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح مرة واحدة؟**

ضع الشعار على ماستر الشريحة أو التخطيط واستبدله في مجموعة صور العرض التقديمي—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المُدرج إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في وقت واحد؟**

قم [Assign the image as the background](/slides/ar/nodejs-java/presentation-background/) على ماستر الشريحة أو التخطيط المناسب—ستورث أي شريحة تستخدم ذلك الماستر/التخطيط الخلفية.

**كيف أمنع ازدياد حجم العرض التقديمي بسبب كثرة الصور؟**

أعد استخدام مصدر صورة واحد بدلاً من النسخ المتعددة، اختر دقات معقولة، طبق الضغط عند الحفظ، واحتفظ بالرسومات المتكررة في الماستر حيثما كان ذلك مناسبًا.