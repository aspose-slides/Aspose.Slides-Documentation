---
title: تحسين إدارة الصور في العروض التقديمية باستخدام JavaScript
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/nodejs-java/image/
keywords:
- إضافة صورة
- إضافة صورة
- استبدال صورة
- مجموعة الصور
- إطار صورة
- صورة مرتبطة
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- تحويل SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرّف على كيفية إضافة، وإعادة استخدام، وربط، واستبدال، وإدارة الصور النقطية و SVG في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

توفر Aspose.Slides لـ Node.js عبر Java عدة طرق للعمل مع الصور، وكل طريقة تخدم غرضًا مختلفًا. يمكنك تخزين صورة في العرض التقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، الربط بصورة خارجية، استبدال مورد صورة مشاركة، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

تتركز هذه المقالة على موارد الصور وكيفية استخدامها عبر العرض التقديمي. لمعالجة القص، الشفافية، التأثيرات، التمدد، وغيرها من التنسيقات المطبقة على إطار صورة منفرد، راجع [إطار الصورة](/slides/ar/nodejs-java/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم البرمجية التالية مرتبطة ارتباطًا وثيقًا ولكنها ليست قابلة للاستبدال:

- تخزن [مجموعة صور العرض التقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/) موارد الصور المستخدمة في العرض التقديمي. استخدم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/) لإضافة بيانات الصورة والحصول على مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).
- [إطار الصورة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) هو شكل يعرض صورة على شريحة أو تخطيط أو رئيس. استخدم [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة بدلاً من كشكل. لذلك لا تتصرف كإطار صورة.
- [PPImage.replaceImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يستبدل مورد صورة. إذا استخدمت عدة عناصر في العرض التقديمي ذلك المورد، فإنها جميعًا ستستخدم البديل.
- تحويل SVG إلى أشكال ينشئ أشكال شريحة قابلة للتحرير. بعد التحويل، لا يُدار المحتوى بعد الآن كصورة واحدة.

وبالتالي يكون سير العمل النموذجي: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/)، ثم استخدام ذلك المورد في إطار صورة أو تعبئة واحدة أو أكثر.

## **إضافة صورة مدمجة**

لإدراج صورة محلية، حمِّل الملف، أضفه إلى مجموعة الصور، وأنشئ إطار صورة يستخدم مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الذي تم إرجاعه.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الصورة المضافة بهذه الطريقة مدمجة في العرض التقديمي، لذا لا يعتمد الملف الناتج على توفر ملف الصورة الأصلي.

### **إضافة صورة من الويب**

عندما تكون الصورة متاحة عبر HTTP أو HTTPS، قم بتحميل بايتاتها، أضفها إلى مجموعة صور العرض التقديمي، واستخدم مورد الصورة المرجع بنفس الطريقة التي تُستعمل بها الصورة المحلية.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

في التطبيقات طويلة الأمد، أعد استخدام عميل HTTP أو استراتيجية إدارة الاتصالات المناسبة للتطبيق بدلاً من إنشاء بنية شبكة غير ضرورية مرارًا وتكرارًا. كما يجب التحقق من صحة عناوين URL البعيدة، أحجام الاستجابات، وأنواع المحتوى عندما لا يكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا كانت الصورة نفسها مطلوبة أكثر من مرة، أضفها إلى العرض التقديمي مرة واحدة وأعد استخدام [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الذي تم إرجاعه عند إنشاء إطارات صورة إضافية. هذا يجنّب تحميل نفس البيانات المصدرية مرارًا ويجعل العلاقة بين مصدر الصورة المشترك واستخداماته صريحة.

للرسوم التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، ضع إطار الصورة على [قالب الشريحة](/slides/ar/nodejs-java/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

يُعيّن صورة الخلفية إلى تعبئة الشريحة؛ لا تُضاف كشكل إطار صورة. يكون هذا مفيدًا عندما يجب أن تغطي الصورة خلفية الشريحة ولا ينبغي تعديلها ككائن شريحة عادي.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لخيارات خلفية إضافية، بما في ذلك خلفيات القالب والتخطيط، راجع [خلفية العرض التقديمي](/slides/ar/nodejs-java/presentation-background/).

## **الصور المدمجة والصور المرتبطة**

للصور المدمجة والمرتبطة مقايضات مختلفة من حيث القابلية للنقل وحجم الملف:

- **صورة مدمجة:** تُخزن بيانات الصورة داخل العرض التقديمي. يكون العرض التقديمي مستقلاً، لكن حجم الملف يضم بيانات الصورة.
- **صورة مرتبطة:** يخزن العرض التقديمي مسارًا أو عنوان URL لصورة خارجية. يمكن لهذا أن يقلل من حجم العرض، لكن المورد الخارجي يجب أن يظل متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) بدلاً من دمج بيانات الصورة.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم الصور المرتبطة فقط عندما يمكن لبيئة النشر الوصول بشكل موثوق إلى المورد الخارجي. بالنسبة للعروض التي يجب أن تعمل بدون اتصال أو تُنقل بين الأنظمة، تكون الصور المدمجة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجهي، لذا يمكن أن يكون مفيدًا للأيقونات، المخططات، وغيرها من الرسوم التي يجب أن تُقاس بدون فقدان التفاصيل كما يحدث مع الصور النقطية. تدعم Aspose.Slides SVG كموارد صورة وكمصدر لأشكال شريحة قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ملفات SVG مع موارد خارجية**

يمكن أن يشير SVG إلى صور، أوراق أنماط، أو خطوط خارجية. في هذه الحالات، توفر [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/) مُنشئات تقبل [ExternalResourceResolver](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/externalresourceresolver/) وعنوان URI أساسي. يمكن للمُحلِّل ربط URI نسبي بـ URI مطلق مسموح وإرجاع تدفق للمورد المطلوب.

يسمح المُحلِّل بالوصول إلى الموارد الخارجية أثناء معالجة Aspose.Slides لملف SVG، لكنه لا يعيد كتابة SVG إلى مستند مستقل. إذا كان يجب أن يبقى SVG قابلًا للنقل، قم بدمج موارده المطلوبة داخل SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند جلب ملفات SVG من مصادر غير موثوقة، قيّد المخططات، مواقع الملفات، والمضيفين التي يمكن للمُحلِّل الوصول إليها. يجب أن تطبق المُحَلِّلات الشبكية أيضًا مهلات، حدود حجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال شريحة قابلة للتحرير، مماثلة للأمر المقابل في PowerPoint.

![قائمة منبثقة في PowerPoint](img_01_01.png)

استخدم النسخة الزائدة من [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/) التي تقبل صورة SVG لإجراء التحويل.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم تحويل SVG إلى أشكال عندما تحتاج عناصر المتجه الفردية إلى تعديلها كأشكال PowerPoint. إذا كان الهدف فقط عرض SVG، فالإبقاء عليه كصورة أبسط ويتجنّب إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [PPImage.replaceImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) عندما ترغب في استبدال مورد صورة موجود. يكون هذا مفيدًا خاصةً للرسوم المشتركة مثل الشعارات.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا استخدمت إطارات صور متعددة، أو خلفيات، أو قوالب، أو تخطيطات نفس المورد، فإن استبدال ذلك المورد يحدّث جميع الاستخدامات. إذا كان يجب تغيير إطار صورة واحد فقط، عيّن صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

[PPImage.replaceImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يوفر أيضًا نسخًا زائدة تقبل مصفوفة بايت أو [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن للصور النقطية الكبيرة أن تجعل العرض التقديمي كبيرًا بصورة غير مبررة. استخدم صورًا مصدرية بأبعاد مناسبة لحجم العرض المقصود، وأعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنب دمج نسخ مكررة من نفس الرسوم بدقة كاملة.

للصور النقطية التي تم وضعها بالفعل في إطارات صورة، يمكن لـ [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) تقليل بيانات الصورة وفقًا للدقة المحددة وإعدادات القص. هذا معالجة لإطار الصورة وليس إدارة مجموعة الصور، لذا راجع [إطار الصورة](/slides/ar/nodejs-java/picture-frame/) للعمليات التنسيقية ذات الصلة.

### **اختر بين المحتوى المدمج والمرتبط**

يجعل الدمج العرض التقديمي قابلًا للنقل لأن جميع بيانات الصور المطلوبة تسافر مع الملف. يمكن للربط أن يقلل من حجم الملف، لكنه يُدخل اعتمادًا خارجيًا. استخدم الروابط فقط عندما تكون هذه الاعتمادية مقبولة ومستقرة.

### **إعادة استخدام العلامة التجارية المشتركة**

لشعارات متكررة، علامات مائية، أو رسومات زخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كان الرسم جزءًا من تصميم العرض التقديمي بدلاً من محتوى الشريحة، ضعه على قالب أو تخطيط ليُورث إلى الشرائح المناسبة.

### **حافظ على موارد SVG قابلة للنقل**

يكون SVG المستقل أسهل في النقل والعرض المتسق مقارنةً بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. عندما يكون ذلك ممكنًا، دمج الموارد المطلوبة قبل استيراد SVG. حوّل SVG إلى أشكال فقط عندما تحتاج عناصر المتجه الفردية إلى تعديل.

### **استخدام واجهة برمجة تطبيقات الصور الحديثة عبر الأنظمة**

للكود الجديد لـ Node.js عبر Java، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) و[Images](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/images/) بدلاً من واجهة برمجة التطبيقات العامة القديمة المستندة إلى `java.awt.image.BufferedImage`. راجع [واجهة برمجة التطبيقات الحديثة](/slides/ar/nodejs-java/modern-api/) للحصول على إرشادات الترحيل.

تتطلب صيغ WMF وEMF اعتبارًا خاصًا. عندما تُمرّر هذه الصيغ عبر [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/)، تقوم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/) بتحويل ملف الميتا إلى تمثيل PNG نقطي قبل الإدراج. إذا كان حفظ بيانات الميتا مهمًا، استخدم النسخة الزائدة القائمة على الدفق من [ImageCollection.addImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/). إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل وهو خارج نطاق هذه المقالة.

## **الأسئلة المتكررة**

**ما هو الفرق بين مجموعة الصور وإطار الصورة؟**

تخزن مجموعة الصور موارد الصور القابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات خاصة بالصورة مثل القص والتأثيرات.

**ما هي الطريقة المثلى لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مُشاركًا كمورد صورة واحد، استبدل ذلك المورد باستخدام [PPImage.replaceImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/). بالنسبة للعلامة التجارية على مستوى العرض، يمكن أيضًا وضع الشعار على قالب أو تخطيط لتقليل محتوى الشرائح المتكرر.

**لماذا تختفي الصورة المرتبطة على كمبيوتر آخر؟**

تعتمد الصورة المرتبطة على ملفها الخارجي أو URL. إذا تعذر الوصول إلى ذلك المورد من الكمبيوتر الآخر، فقد تصبح الصورة غير متاحة. دمج الصورة عندما يجب أن يكون العرض مستقلاً.

**هل يمكن تعديل SVG مُدرج كأشكال PowerPoint؟**

نعم. حوّل SVG باستخدام [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكنني الحفاظ على عروض تقديمية تحتوي على العديد من الصور أصغر حجمًا؟**

أعد استخدام موارد الصور المشتركة، تجنّب مصادر نقطية كبيرة غير ضرورية، اضغط الصور النقطية المناسبة عندما يلزم، ضع العلامات المتكررة على القوالب أو التخطيطات، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.