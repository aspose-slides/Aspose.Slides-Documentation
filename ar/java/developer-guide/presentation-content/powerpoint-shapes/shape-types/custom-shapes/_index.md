---
title: تخصيص أشكال العروض التقديمية في Java
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/java/custom-shape/
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
- Java
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تحرير هندسة الشكل باستخدام نقاط التحرير ومسارات الهندسة. وهي تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على الشكل.

كما تُظهر أيضًا كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال ذات زوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل، وتحويل مخططات نص Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint يمكنك استخدام **Edit Points** لتعديل مربع:

* تحريك الزاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل مخطط الشكل أو استخدام شكل موجود كأساس لآخر جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احتفظ بهذه المفاهيم في الاعتبار:

* يمكن أن يكون الشكل (أو مساره) إما مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط تثبيت مربوطة بواسطة مقاطع.
* يمكن أن يكون المقطع مستقيمًا أو منحنيًا. تحدد نقاط التثبيت ومقابض التحكم شكله.
* نقاط التثبيت موجودة كنقاط زاوية أو نقاط مستقيمة أو نقاط ناعمة:
  * في نقطة زاوية، يمكن أن تلتقي المقاطع المتجاورة بزاوية.
  * في نقطة ناعمة، تكون مقبضا التحكم محاذيين وعلى بعد متساوٍ من نقطة التثبيت.
  * في نقطة مستقيمة، تكون مقبضا التحكم محاذيين ولكن يمكن أن تكون المسافات مختلفة عن نقطة التثبيت.
* تحريك نقاط التثبيت أو تعديل مقابضها يغيّر مخطط الشكل.

لتحرير أشكال PowerPoint من خلال نقاط التحرير، **Aspose.Slides** يوفر فئة [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) وواجهة [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* مثيل [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) يمثل مسار هندسي لكائن [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) .
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) من مثيل [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) ، يمكنك استخدام طريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* لتعيين [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال ذات المسار الواحد و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) للأشكال ذات المسارات المتعددة.
* لإضافة مقاطع، يمكنك استخدام الطرق ضمن [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) .
* باستخدام الطرق [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) ، يمكنك تعيين مظهر مسار هندسي.
* باستخدام طريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) ، يمكنك استرجاع مسار هندسي لـ[GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص إضافية لهندسة الشكل، يمكنك قراءة [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل المقاطع على [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرسًا تُدرج مقطعًا في ذلك الموضع الصفري في مصفوفة مقاطع المسار.

| العملية | الطريقة |
| --- | --- |
| إضافة أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| إضافة أو إدراج منحنى بيزييه مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| إضافة أو إدراج منحنى بيزييه تربيعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| إضافة قوس إهليلجي بالأبعاد والزوايا المحددة بالدرجة. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| تحديد نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| إزالة مقطع عند فهرس صفري. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يُدخل نقطتين في شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) ويطبق المسار المعدل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) . الإحداثيات محلية للشكل: كلتا النقطتين الجديدتين في مركزه، على بعد 100 نقطة من اليسار و50 نقطة من الأعلى. مؤشرات المقاطع 1 و4 تضعهما على الحافتين العلوية والسفلية، مما يسحب تلك الحافات إلى الداخل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

هذا المثال يغيّر مخطط شكل على شكل قلب بإزالة المقطع عند الفهرس الصفري 2 باستخدام [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) . تطبيق المسار المعدل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) يحدث تحديثًا في حدود الشكل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

هذا المثال يبني نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) . نصفا القطر الخارجي والداخلي المتناوبين بقيم 100 و50 نقطة يحددان أطراف وشقوق النجمة؛ خطوة 72 درجة تباعد الأطراف الخمسة بالتساوي. يُغلق المسار باستخدام [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) ويُطبق على شكل مستطيل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ، مستبدلًا مخططه.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **إنشاء شكل مركب مخصص**

هذا المثال يعرّف كائنين [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) مغلقين للثلث العلوي والسفلي من الشكل. تطبيق كلا المسارين باستخدام [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

هذا المثال يجمع مقاطع مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) لإنشاء شكل بزوايا منحنية إلى الداخل. كل حجم زاوية يحدد عرض وارتفاع القوس بالنقاط، واللف بـ -90 درجة يرسم ربع إهليلج عكس عقارب الساعة. يُطبق المسار المكتمل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ، وتُحفظ العرض التقديمي بصيغة PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

المساعد التالي يتحقق مما إذا كان كل مسار هندسي غير فارغ ينتهي بمقطع إغلاق. يقرأ [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) ويقارن الأمر النهائي للمقطع [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) مع [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). يعيد false عندما لا توجد مسارات غير فارغة. هذا يفحص الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. المثال يطبع `true` لمستطيل.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **فحص أوامر مسار الهندسة**

قم بتحميل [contour.pptx](contour.pptx) وضعه في دليل تشغيل التطبيق. الشكل الأول في الشريحة الأولى يملك حافة علوية مستقيمة، ومنحنى بيزييه مكعب، وحافة إغلاق مستقيمة. استخدم [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) لقراءة مسارات الشكل و[getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) لقراءة مقاطع كل مسار بترتيب الرسم. لكل مقطع، [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) يحدد الأمر ويقرر كيفية تفسير القيم التي تُرجعها [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) .

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

الشكل يقع عند (200, 100) نقطة على الشريحة. الإحداثيات المبلغ عنها محلية للشكل، بحيث يكون (0, 0) في زاويته العلوية اليسرى، ويزداد x إلى اليمين، ويزداد y إلى الأسفل. المقطع الإغلاق يعود إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```
![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من أعلى اليمين إلى أسفل اليسار، وحافة يسرى مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) لفحص شكل موجود كعناصر تحتوي على نقاط مسار وأنواع نقاط. حوّل كل [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) مُرجع إلى [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) لاسترجاع مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) و[getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) . هذا التمثيل مفيد لتحليل الحدود أو لتمرير الهندسة إلى أدوات رسم مخصصة.

المثال يفتح input.pptx، يجد أول شكل هندسي مباشرةً في الشريحة الأولى، ويطبع مقاطع مساره. استخدم عرضًا تقديميًا يحتوي على شكل بمقاطع مستقيمة ومنحنية لرؤية كلا النوعين من الناتج. لا يبحث داخل المجموعات.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // احتفظ بنوع المقطع، مستثنياً العلامات.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // استهلك نقطتي التحكم والنقطة النهائية.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

المصفوفات تتطابق حسب الفهرس: `points[i]` هو نقطة و`types[i]` يصف دوره. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. مقطع بيزييه مكعب يبدأ من النقطة النهائية السابقة ويستخدم ثلاث مدخلات من النوع `3` متتابعة: نقطتا تحكم ثم النقطة النهائية الجديدة. الحلقة تستهلك هذه الثلاث مدخلات معًا وتفحص النقطة النهائية للإغلاق.

أنواع النقاط تحتوي أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع المقطع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزييه تُغلق واحدًا. Java تخزن هذه الأعلام في بايتات موقعة؛ القناع يحافظ على القيم المقصودة. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل الشرطية (`0x10`) والعلامة (`0x20`) لا تغير نوع المقطع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وY إلى الأسفل. بالنسبة لشكل غير مجموع، تشمل الإحداثيات المستخرجة بالفعل الموقع المرجع عبر [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) و[getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مدور عند `(100, 200)` بحجم `120 × 80` له حدود حدودية `(100, 200)`–`(220, 280)`. لا تضف موقع الشكل مرة أخرى. اطرح قيم X وY للحصول على إحداثيات relative إلى إطاره غير المدور.

النقاط المستخرجة لا تطبق دوران الشكل، المرجع عبر [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--)، أو الانعكاسات الأفقية والرأسية. لإعادة إنتاج الحدود المعروضة، نفّذ تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية المُصوَّرة أو أن تطبق ترجمة أو مقياسًا مرتين إذا كانت بالفعل مُعكسة في إطار الطفل.

**الفحص مقابل التحرير.** المصفوفات المستخرجة تصف الحدود؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج تحليلك أو شفرة الرسم إلى مصفوفات نقطة/نوع. استخدم [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) عندما تحتاج أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تعديل هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) أو [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **تحويل شكل Java AWT إلى GeometryPath**

هذا المثال يجمع مخططًا مستطيليًا مع نص مُحوّل إلى هندسة. تُعطّل طريقة [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) تعبئة المخطط. تُنشئ [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) . يوفر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) حركات، خطوط، مقاطع تربيعية، مكعبة، وإغلاق، والتي يُعيد المثال تشغيلها على [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

النص يستخدم خط Arial بحجم 40 نقطة. يُبعد المخطط 20 نقطة أفقياً ويُوضَع بارتفاع بصري 10 نقاط أسفل حافة أعلى الشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا فقط. تطبيق كلا المسارين باستخدام [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ينتج شكلًا واحدًا يضم المستطيل والنص.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // إنشاء شكل جديد
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // الحصول على مسار الهندسة للشكل
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // إنشاء مسار رسومي جديد بالنص
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // تحويل المسار الرسومي إلى مسار هندسي
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // تعيين مزيج من مسار الهندسة الجديد والمسار الأصلي للشكل
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحد الخارجي بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغير الحد فقط. يتم تطبيق الملء والحد الخارجي تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من [slide](/slides/ar/java/convert-powerpoint-to-png/) أو الـ[shape](/slides/ar/java/create-shape-thumbnails/) نفسها إلى تنسيق نقطي؛ هذا يبسّط العمل اللاحق مع الهندسات المعقدة.