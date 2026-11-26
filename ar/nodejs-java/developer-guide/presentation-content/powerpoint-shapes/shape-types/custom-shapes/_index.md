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
- نقاط التحرير
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

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل باستخدام نقاط التحرير ومسارات الهندسة. وتظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال ذات زوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل، وتحويل مخططات النص في Java AWT إلى مسارات هندسة.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تسمح لك نقاط التحرير بتعديل حدود الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط تثبيت متصلة بقطع.
* يمكن أن يكون القطع مستقيمًا أو منحنيًا. تحدد نقاط التثبيت ومقابض التحكم شكله.
* توجد نقاط التثبيت كـنقاط زاوية، أو نقاط مستقيمة، أو نقاط سلسة:
  * في نقطة الزاوية، يمكن للقطع المتجاورة أن تلتقي بزاوية.
  * في نقطة سلسة، تكون مقبضا التحكم محاذيين ومتساويي البعد عن نقطة التثبيت.
  * في نقطة مستقيمة، يكون مقبضا التحكم محاذيين لكنهما قد يكونان على مسافات مختلفة عن نقطة التثبيت.
* تحريك نقاط التثبيت أو تعديل مقبضاتها يغيّر حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، **Aspose.Slides** يوفر الفئة [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* تمثّل كائن [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) مسار هندسي لكائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) من كائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات المسار الواحد و[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات المسارات المتعددة.
* لإضافة قطع، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* باستخدام طريقتي [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)، يمكنك ضبط المظهر لمسار الهندسة.
* باستخدام طريقة [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرداد مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) كمصفوفة من قطع المسار.
* للوصول إلى خيارات تخصيص هندسة إضافية، يمكنك قراءة كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل القطع على [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار الهندسة. المتجاوزات التي تقبل فهرس تُدرج قطعة في ذلك الموضع الصفري‑الأساسي في مصفوفة قطع المسار.

| العملية | الطريقة |
| --- | --- |
| إضافة أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| إضافة أو إدراج منحنى بيزيه مكعب بنقطتين تحكمية ونقطة نهائية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إضافة أو إدراج منحنى بيزيه رباعي بنقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إضافة قوس إهليلجي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| تحديد نقطة البداية للشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| إزالة مقطع عند فهرس يبدأ من الصفر. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يدرج نقطتين في شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) ويطبق المسار المعدل مع [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية للشكل: كلتا النقطتين الجديدتين في مركزه، على بُعد 100 نقطة من اليسار و50 نقطة من الأعلى. المؤشرات 1 و4 للقطعة تضعهما على الحافتين العلوية والسفلية، مما يجذب هاتين الحافتين إلى الداخل.

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

## **إزالة نقاط من الشكل**

هذا المثال يغيّر مخطط شكل قلب عن طريق إزالة القطعة عند الفهرس الصفري‑الأساسي 2 باستخدام [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدل مع [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) يُحدّث محيط الشكل.

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

هذا المثال يبني نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). تحدد نصف القطر الخارجي والداخلي المتناوبين 100 و50 نقطة رؤوسًا وانخفاضًا؛ خطوة 72 درجة توزع الرؤوس الخمسة بالتساوي. يُغلق المسار باستخدام [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) ويطبق على شكل مستطيل باستخدام [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلًا مخططه.

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

## **إنشاء شكل مخصص مركب**

هذا المثال يعرّف عنصرين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. تطبيق المسارين معًا عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر منتصفه.

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

هذا المثال يجمع قطعًا مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل بزوايا منحنية إلى الداخل. كل حجم زاوية يحدد عرض وارتفاع القوس بالنقاط، ويمرّ sweep بزاوية -90 درجة لرسم ربع إهليلج عكس اتجاه عقرب الساعة. يُطبق المسار المكتمل باستخدام [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)، ويتم حفظ العرض التقديمي بصيغة PPTX.

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

## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

المساعد التالي يتحقق مما إذا كان كل مسار هندسي غير فارغ ينتهي بقطعة إغلاق. يقرأ [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) ويقارن أمر القطعة الأخيرة من خلال [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) مع [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). تُعيد false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ لا يُفحص كل فرعي داخل المسار. المثال يطبع `true` لمستطيل.

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

## **فحص أوامر مسار الهندسة**

حمّل الملف [contour.pptx](contour.pptx) وضعه في دليل عمل التطبيق. الشكل الأول على الشريحة الأولى يحتوي على حافة علوية مستقيمة، ومنحنى بيزيه مكعب، وحافة إغلاق مستقيمة. استخدم [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) لقراءة مسارات الشكل و[ getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) لقراءة كل قطع المسار بترتيب الرسم. لكل قطعة، يحدد [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) الأمر ويحدد كيفية تفسير القيم التي تُعيدها [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

يقع الشكل عند (200, 100) نقطة على الشريحة. الإحداثيات المُبلَغ عنها محلية للشكل، بحيث يكون (0, 0) في الزاوية العليا اليسرى، وتزيد x إلى اليمين وتزيد y إلى الأسفل. تُعيد القطعة المغلقة إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![شكل PowerPoint له حافة علوية مستقيمة، وحافة منحنية من الأعلى اليمين إلى الأسفل اليسار، وحافة يسرى مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. استخدم كل كائن [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) مسترجع للحصول على مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). هذا التمثيل مفيد لتحليل المخطط أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال ملف input.pptx، يجد أول شكل هندسي مباشرة على الشريحة الأولى، ويطبع قطع مساره. استخدم عرضًا يحتوي على شكل بقطع مستقيمة ومنحنية لترى كلا النوعين من النتائج. لا يبحث داخل المجموعات.

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
                        i += 2; // استهلك كل من نقطتي التحكم ونقطة النهاية.
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

المصفوفات متطابقة بحسب الفهرس: `points[i]` هو نقطة و`types[i]` يصف دوره. النوع `0` يبدأ الشكل، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ القطع المكعب عند نقطة النهاية السابقة ويستخدم ثلاثة إدخالات من النوع `3` المتتالية: نقطتين تحكميتين ثم نقطة النهاية الجديدة. يستهلك الحلقة هذه الإدخالات الثلاثة معًا ويفحص نقطة النهاية للإغلاق.

أنواع النقاط تحتوي أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع القطعة، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزيه تغلق واحدًا. تخزن Java هذه الأعلام في بايتات موقعة؛ القناع يحافظ على قيم البت المقصودة. مقارنة القيمة الخام فقط بـ`1` أو `3` سيفتقد هذه الحالات. الأعلام الأخرى، مثل الشرط (`0x10`) والعلامة (`0x20`)، لا تغير نوع القطعة الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجموع، تشمل الإحداثيات المستخرجة بالفعل الموضع الذي تُعيده [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مدوّر عند `(100, 200)` بحجم `120 × 80` له حدود مخطط `(100, 200)`‑`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المدوّر.

النقاط المستخرجة لا تُطبق دوران الشكل التي تُعيده [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation)، ولا الانعكاسات الأفقية والرأسية. لتعيد إنتاج المخطط الظاهر، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمّعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تطبق ترجمة أو مقياسًا مرتين إذا كان مُعكسًا بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المخطط؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج تحليلاتك أو كود الرسم إلى مصفوفات نقطة/نوع. استخدم [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

يجمع هذا المثال مخططًا مستطيلاً مع نص تم تحويله إلى هندسة. تُعطّل طريقة [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) ملء المخطط. تُنشئ كائن [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يُزوّد [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) الخاص به بحركات، خطوط، قطع رباعية، مكعبة، وإغلاق، والتي يُعيد المثال تشغيلها على [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

يستخدم الجسر Java قيمًا صريحة من نوع float وbyte للمعاملات Java المقابلة. يكتب المت iterator الإحداثيات إلى مصفوفة float في Java؛ يقرأ الانعكاس القيم المحدثة مرة أخرى إلى JavaScript. يستخدم النص خط Arial بحجم 40 نقطة. يُزاح المخطط 20 نقطة أفقياً ويُوضَع بحيث يكون حافته العلوية البصرية 10 نقاط أسفل حافة أعلى الشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا. تطبيق كلا المسارين معًا عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) يُنتج شكلًا واحدًا يحتوي على المستطيل والنص.

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
            case 2: // منحنى بيزيه رباعي.
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

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ فقط يتغيّر المخطط. يُطبق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص بشكل صحيح مع هندسته؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر منطقة [slide](/slides/ar/nodejs-java/convert-powerpoint-to-png/) المطلوبة أو [shape](/slides/ar/nodejs-java/create-shape-thumbnails/) نفسها إلى صيغة نقطية؛ يبسط ذلك العمل اللاحق مع الهندسات المعقّدة.