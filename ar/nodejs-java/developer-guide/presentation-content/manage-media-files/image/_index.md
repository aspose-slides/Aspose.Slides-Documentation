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
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام JavaScript وAspose.Slides لـ Node.js، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارةً للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. بالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية عبر إجراءات مختلفة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خاصةً إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها أو إضافة تأثيرات وغيرها—راجع [Picture Frame](/slides/ar/nodejs-java/picture-frame/).

{{% /alert %}} 

يدعم Aspose.Slides عمليات مع الصور في هذه الصيغ الشائعة: JPEG, PNG, GIF، وغيرها.

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر إلى شريحة في عرض تقديمي. يوضح لك عينة الشيفرة هذه بلغة JavaScript كيفية إضافة صورة إلى شريحة:
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


## **إضافة الصور من الدفق إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافتها مباشرةً من الويب.

تُظهر لك عينة الشيفرة هذه كيفية إضافة صورة من الويب إلى شريحة بلغة JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // تحميل ملف Excel إلى التدفق
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


## **إضافة الصور إلى أسس الشرائح (Slide Masters)**

أساس الشريحة هو الشريحة العليا التي تخزن وتتحكم في معلومات (السمة، التخطيط، إلخ) عن جميع الشرائح التي تحته. لذلك، عندما تضيف صورة إلى أساس الشريحة، تظهر تلك الصورة على كل شريحة تحت ذلك الأساس.

تُظهر لك عينة الشيفرة هذه بلغة JavaScript كيفية إضافة صورة إلى أساس شريحة:
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


## **إضافة الصور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام الطريقة [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) التابعة للفئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection  
2. إنشاء كائن PPImage من ISvgImage  
3. إنشاء كائن PictureFrame باستخدام فئة PPImage  

تُظهر لك عينة الشيفرة هذه كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
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
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه للوظيفة الموجودة في PowerPoint للعمل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة أحد التحميلات الزائدة للطريقة [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) للفئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) التي تأخذ كائن [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) كوسيطة أولى.

تُظهر لك عينة الشيفرة هذه كيفية استخدام الطريقة الموضحة لتحويل ملف SVG إلى مجموعة من الأشكال:
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
    // تحويل صورة SVG إلى مجموعة من الأشكال مع تحجيمها إلى حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // حفظ العرض التقديمي بتنسيق PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إضافة الصور كـ EMF في الشرائح**
يسمح Aspose.Slides for Node.js via Java بإنشاء صور EMF من جداول Excel وإضافة هذه الصور كـ EMF في الشرائح باستخدام Aspose.Cells.

تُظهر لك عينة الشيفرة هذه كيفية تنفيذ المهمة الموصوفة:
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

يتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة طرق لتحديث الصور في المجموعة. توفر واجهة API طرقًا بسيطة لاستبدال صورة باستخدام بيانات البايت الخام، أو كائن [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) ، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات أدناه:

1. تحميل ملف العرض التقديمي الذي يحتوي على صور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.  
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.  
4. في النهج الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) واستبدال الصورة المستهدفة بذلك الكائن.  
5. في النهج الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.  
6. كتابة العرض التقديمي المعدل كملف PPTX.  
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


{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص وإنشاء ملفات GIF من النصوص، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يبقى دقة الصورة الأصلية دون تغيير بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [picture](/slides/ar/nodejs-java/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على تخطيط، واستبدله في مجموعة صور العرض التقديمي—سيتم نشر التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتعديل؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتعديل باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/nodejs-java/presentation-background/) على الشريحة الرئيسية أو التخطيط المعني—سيتم وراثة الخلفية من قبل أي شرائح تستخدم تلك الشريحة/التخطيط.

**كيف أمنع تضخم حجم العرض التقديمي بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من التكرار، اختر دقة معقولة، طبّق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة في الشريحة الرئيسية حيثما كان ذلك مناسبًا.