---
title: تخصيص أشكال العروض التقديمية في JavaScript
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/nodejs-java/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام JavaScript و Aspose.Slides لـ Node.js: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، إجراء عمليات تحرير أساسية للمسار، إضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال ذات زوايا منحنية، تحديد ما إذا كانت هندسة الشكل مغلقة، فحص عناصر الشكل، وتحويل مخططات النص في Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل حدود الشكل أو استخدام شكل موجود كأساس لآخر جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، ضع في اعتبارك المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتساء متصلة بقطاعات.
* يمكن أن تكون القطعة مستقيمة أو منحنية. تحدد نقاط الارتساء ومقابض التحكم شكلها.
* توجد نقاط الارتساء كالنقاط الزاوية، أو النقاط المستقيمة، أو النقاط السلسة:
  * في نقطة زاوية، يمكن للقطاعات المتجاورة أن تلتقي بزاوية.
  * في نقطة سلسة، تكون مقابض التحكم محاذية ومتساوية البعد عن نقطة الارتساء.
  * في نقطة مستقيمة، تكون مقابض التحكم محاذية لكن يمكن أن تكون بأبعاد مختلفة عن نقطة الارتساء.
* تحريك نقاط الارتساء أو تعديل مقبضاتها يغير حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** فئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* تمثل إحدى حالات [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) مسار هندسي لكائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) من كائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات المسار الواحد و[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات المسارات المتعددة.
* لإضافة قطاعات، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* باستخدام الطريقتين [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)، يمكنك تحديد مظهر مسار الهندسة.
* باستخدام طريقة [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرجاع مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.
* للوصول إلى خيارات تخصيص إضافية لهندسة الشكل، يمكنك قراءة كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر ما يعرف بـ [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل القطاعات على [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرسًا تُدرج قطاعًا في ذلك الموضع الصفري‑الأساس في مصفوفة قطاعات المسار.

| عملية | طريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| إلحاق أو إدراج منحنى بيزيه مكعب مع نقطتي تحكم ونقطة نهاية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إلحاق أو إدراج منحنى بيزيه تربيعي مع نقطة تحكم واحدة ونقطة نهاية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجة. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطة النهاية بالنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| تعيين نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| إزالة قطاع عند فهرس صفري‑الأساس. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يدرج نقطتين في شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) ويطبق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية بالنسبة للشكل: كلا النقطتين الجديدتين في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. الفهارس 1 و4 للقطاعات تضعهما على الحافتين العليا والسفلى، مما يسحب هاتين الحافتين إلى الداخل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

هذا المثال يغير مخطط شكل على شكل قلب بإزالة القطاع عند الفهرس الصفري‑الأساس 2 عبر [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) يحدث حدود الشكل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

هذا المثال يبني نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). نصفا القطر المتناوبين 100 و50 نقطة يحددان رؤوس الشكل وتعريجاته؛ خطوة 72 درجة توزع الرؤوس الخمسة بالتساوي. يُغلق المسار باستخدام [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) ويطبق على شكل مستطيل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلاً مخططه الأصلي.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **إنشاء شكل مدمج مخصص**

هذا المثال يعرّف مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. تطبيق المسارين معًا عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

هذا المثال يجمع قطاعات مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل ذو زوايا منحنية للداخل. كل حجم زاوية يحدد عرض وارتفاع القوس بالنقاط، والالتفاف -90 درجة يرسم ربع إهليلجية في الاتجاه العكسى لعقارب الساعة. يُطبق المسار المكتمل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)، ثم يُحفظ العرض التقديمي بصيغة PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

تتحقق الدالة المساعدة التالية مما إذا كان كل مسار هندسي غير فارغ ينتهي بقطاع إغلاق. تقرأ [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) وتقارن أمر القطاع الأخير عبر [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) مع [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). تُعيد false عندما لا توجد مسارات غير فارغة. يتحقق من الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. يطبع المثال `true` لمستطيل.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي نقاط المسار وأنواع النقاط. استخدم كل [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) مُسترد للحصول على مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). هذا التمثيل مفيد لتحليل الحدود أو لتمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال ملف input.pptx، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع قطاعات مساره. استخدم عرضًا يحتوي على شكل به قطاعات مستقيمة ومنحنية لرؤية كلا النوعين من الإخراج. لا يبحث داخل المجموعات.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // احتفظ بنوع القطعة، مستثنياً العلامات.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // استهلك نقطتي التحكم والنقطة النهاية.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

المصفوفات تتطابق حسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ الشكل، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ قطاع بيزيه مكعب من النقطة السابقة ويستخدم ثلاث مداخل من النوع `3` متتالية: نقطتا تحكم ثم نقطة النهاية الجديدة. يستهلك الحلقة هذه المداخل الثلاثة معًا ويفحص نقطة النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على علامات. استخدم القناع `0x07` لتحديد نوع القطاع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزيه تغلق واحدًا. تخزن Java هذه العلامات في بايتات موقعة؛ القناع يحافظ على قيم البت المقصودة. مقارنة القيمة الخام فقط بـ `1` أو `3` سيغفل هذه الحالات. العلامات الأخرى، مثل الشرط (`0x10`) والعلامة (`0x20`)، لا تغير نوع القطاع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، حيث X يزداد نحو اليمين وY يزداد نحو الأسفل. بالنسبة لشكل غير مجموعة، تتضمن الإحداثيات المستخرجة بالفعل الموقع المرجع من [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، مستطيل غير مدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود ` (100, 200)`–`(220, 280)`. لا تُضيف موقع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المدوَّر.

لا تُطبق النقاط المستخرجة دوران الشكل المُسترجع عبر [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) أو الانعكاس الأفقي والعمودي. لإعادة إنتاج الحد المعروض، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو أن تُطبق ترجمة أو مقياسًا مرتين إذا كان ذلك مُعكسًا بالفعل في إطار العنصر.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحد؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج إلى مصفوفات نقطة/نوع في تحليل أو كود رسم. استخدم [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

هذا المثال يجمع مخططًا مستطيلًا مع نص محوَّل إلى هندسة. تُعطل طريقة [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) ملء المخطط. يُنشئ كائن [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يزود [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) المتحرك بقطاعات move وline وquadratic وcubic وإغلاق، التي يُعيد المثال تشغيلها على [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

يستخدم الجسر Java قيم float وbyte صريحة للمعلمات المقابلة في Java. يكتب المكرِّر الإحداثيات في مصفوفة float Java؛ يقرأ الانعكاس قيمها المحدثة مرة أخرى إلى JavaScript. يستخدم النص خط Arial بحجم 40 نقطة. يُزاح المخطط 20 نقطة أفقيًا ويُوضَع أعلىه البصري 10 نقاط أسفل الحافة العلوية للشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا. تطبيق المسارين معًا عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ينتج شكلًا واحدًا يحتوي على المستطيل والنص.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // تحريك إلى.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // خط إلى.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // منحنى بيزيه تربيعي.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // منحنى بيزيه مكعب.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // إغلاق الشكل.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **الأسئلة المتداولة**

**ماذا يحدث للملء والحد بعد استبدال الهندسة؟**

يبقى النمط مرتبطًا بالشكل؛ يتغير الحد فقط. يُطبق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) الخاصة بالشكل؛ الهندسة تدور مع الشكل لأنها مرتبطة بنظام إحداثياته.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر الـ[الشريحة](/slides/ar/nodejs-java/convert-powerpoint-to-png/) أو الـ[الشكل](/slides/ar/nodejs-java/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل مع الهندسات المعقدة لاحقًا.