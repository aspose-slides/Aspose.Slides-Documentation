---
title: تخصيص أشكال العروض التقديمية على Android
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لأجهزة Android عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. تُظهر كيف يمكن العمل مع [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير المسار الأساسية، وإضافة أو إزالة النقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال بزوائد منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل باستخدام مصفوفات النقاط في Android.

## **تعديل شكل باستخدام نقاط التحرير**

في PowerPoint يمكنك استخدام **Edit Points** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك نقاط التحرير تعديل مخطط الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![صورة_نظرة_عامة](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة هذه المفاهيم:

* يمكن أن يكون الشكل (أو مساره) إما مغلقًا أو مفتوحًا.
* يتألف مسار الشكل من نقاط ارتكاز متصلة بقطع.
* يمكن أن يكون المقطع مستقيمًا أو منحنٍ. تحدد نقاط الارتكاز ومقابض التحكم شكله.
* توجد نقاط الارتكاز كالنقاط الزاوية أو النقاط المستقيمة أو النقاط السلسة:
  * في نقطة زاوية، يمكن للقطع المتجاورة أن تلتقي بزاوية.
  * في نقطة سلسة، يتم محاذاة مقبضَي التحكم وتكونان على بعد متساوٍ من نقطة الارتكاز.
  * في نقطة مستقيمة، يتم محاذاة مقبضَي التحكم لكن قد يكونان على مسافات مختلفة من نقطة الارتكاز.
* تحريك نقاط الارتكاز أو ضبط مقابضها يغيّر مخطط الشكل.

لتحرير أشكال PowerPoint من خلال نقاط التحرير، توفر **Aspose.Slides** فئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) وواجهة [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) من مثيل [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)، يمكنك استخدام طريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* لتعيين [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال ذات المسار الواحد و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) للأشكال ذات المسارات المتعددة.
* لإضافة قطع، يمكنك استخدام الطرق الموجودة تحت [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) .
* باستخدام الطريقتين [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-)، يمكنك ضبط مظهر مسار الهندسة.
* باستخدام طريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--)، يمكنك استرداد مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار الهندسة. التحميلات التي تقبل فهرسًا تقوم بإدراج قطعة في ذلك الموضع الصفري‑الأساسي في مصفوفة قطع المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| إلحاق أو إدراج منحنى بيزيه مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| إلحاق أو إدراج منحنى بيزيه تربيعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| إلحاق قوس إهليلجي بالأبعاد والزوايا المحددة بالدرجة. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| تعيين نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| إزالة قطعة في فهرس صفري‑الأساس. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **إضافة نقاط مخصصة إلى شكل**

تُدرج هذه الأمثلة نقطتين داخل شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) وتطبق المسار المُعدَّل عبر [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). الإحداثيات محلية بالنسبة للشكل: كلتا النقطتين الجديدتين في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. الفهارس 1 و4 تضعهما على الحافتين العلوية والسفلية، مما يسحب الحافتين إلى الداخل.

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

![مثال_1](custom_shape_1.png)

## **إزالة نقاط من شكل**

تُغيّر هذه الأمثلة مخطط الشكل على شكل قلب بإزالة القطعة في الفهرس الصفري‑الأساسي 2 عبر [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). تطبيق المسار المعدَّل عبر [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) يحدث تحديثًا لحدود الشكل.

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
![مثال_2](custom_shape_2.png)

## **إنشاء شكل مخصص**

تنشئ هذه الأمثلة نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). تحدد نصف القطرين الخارجي والداخلي المتناوبين بـ 100 و50 نقطة لتشكيل القمم والقطوع؛ خطوة قدرها 72 درجة تُقسم القمم الخمسة بالتساوي. يُغلق المسار عبر [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) ويُطبق على شكل مستطيل عبر [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)، مستبدلاً مخططه.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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
![مثال_3](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

تعرّف هذه الأمثلة مسارين [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) مغلقين للثلث العلوي والسفلي من الشكل. تطبيق كلا المسارين عبر [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

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
![مثال_4](custom_shape_4.png)

## **إنشاء شكل مخصص بزوائد منحنية**

تجمع هذه الأمثلة بين القطع المستقيمة و[GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) لإنشاء شكل بزوائد منحنية إلى الداخل. يحدد حجم كل زاوية عرض وارتفاع القوس بالنقاط، وتُرسم المدى −90 درجة قوسًا نصف بيضاويًا عكس اتجاه الشمس. يُطبق المسار المكتمل عبر [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)، وتُحفظ العروض التقديمية بصيغة PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

يتحقق المساعد التالي ما إذا كان كل مسار هندسي غير فارغ ينتهي بقطعة إغلاق. يقرأ [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) ويقارن أمر القطعة النهائية [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) مع [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). يُعيد false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ ولا يفحص كل شكل فرعي داخل المسار. تُظهر الأمثلة القيمة `true` لمستطيل.

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

حمّل [contour.pptx](contour.pptx) واستبدل اسم الملف النموذجي بمساره على الجهاز. الشكل الأول في الشريحة الأولى يحتوي على حافة علوية مستقيمة، ومنحنى بيزيه مكعب، وحافة إغلاق مستقيمة. استخدم [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) لقراءة مسارات الشكل و[getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) لقراءة قطاعات كل مسار بترتيب الرسم. لكل قطاع، يحدد [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) الأمر ويحدد طريقة تفسير القيم التي تُرجعها [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) .

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

يقع الشكل عند (200, 100) نقطة على الشريحة. الإحداثيات المُبلغ عنها محلية بالنسبة للشكل، بحيث (0, 0) في الزاوية العليا اليسرى، وتزداد x إلى اليمين وy إلى الأسفل. تُعيد القطعة الختامية إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من اليمين العلوي إلى اليسار السفلي، وحافة يسرى مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. حوّل كل [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) مُرجع إلى [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) لاسترداد مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) و[getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . يُعد هذا التمثيل مفيدًا لتحليل الحدود أو لتمرير الهندسة إلى أدوات رسم مخصصة.

تفتح الأمثلة ملف input.pptx، وتجد أول شكل هندسي مباشرةً على الشريحة الأولى، وتطبع قطاعات مساره. استخدم عرضًا يحتوي على شكل بقطاعات مستقيمة ومنحنية لرؤية كلا النوعين من المخرجات. لا يبحث داخل المجموعات.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // احتفظ بنوع القطعة مع استبعاد العلامات.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // استهلك كلًا من نقطتي التحكم ونقطة النهاية.
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

المصفوفات متطابقة بحسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلاً، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ قطاع بيزيه مكعب عند النقطة النهائية السابقة ويستخدم ثلاث إدخالات من النوع `3` متتالية: نقطتا تحكم ثم النقطة النهائية الجديدة. يستهلك الحلقة هذه الثلاثة إدخالات معًا ويفحص النقطة النهائية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. اكشف القناع بـ `0x07` لتحديد نوع القطعة، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة بيزيه تُغلق واحدة. تخزن Java هذه الأعلام في بايتات موقعة؛ القناع يحافظ على القيم الفعلية للبتات. مقارنة القيمة الخام فقط بـ `1` أو `3` سيغفل هذه الحالات. الأعلام الأخرى، مثل الشرط (`0x10`) والعلامة (`0x20`)، لا تغير نوع القطعة الأساسي.

**إحداثيات وتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، بحيث يزيد X إلى اليمين وY إلى الأسفل. بالنسبة لشكل غير مجموع، تشمل الإحداثيات المستخرجة بالفعل الموضع الذي تُرجعه [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) و[getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مدوَّر عند `(100, 200)` بحجم `120 × 80` يمتلك حدودًا `(100, 200)`–`(220, 280)`. لا تُضف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المدور.

النقاط المستخرجة لا تُطبق دوران الشكل الذي تُرجعه [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--)، ولا انعكاسات أفقية أو رأسية. لتكرار الحدود المعروضة، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمَّعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو أنَّك تُضيف ترجمة أو مقياسًا مرتين إذا كان ذلك مُعكسًا بالفعل في إطار العنصر الفرعي.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحدود؛ تعديلها لا يحدّث الشكل الأصلي. اختر هذا الأسلوب عندما يحتاج تحليلك أو كود الرسم إلى مصفوفات نقطة/نوع. استخدم [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المعدَّلة عبر [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) أو [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **الأسئلة المتكررة**

**ماذا سيحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مرتبطًا بالشكل؛ يتغير فقط المخطط. يُطبق الملء والحد بشكل تلقائي على الهندسة الجديدة.

**كيف يمكنني تدوير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة “لتثبيت” النتيجة؟**

نعم. صدّر منطقة [slide](/slides/ar/androidjava/convert-powerpoint-to-png/) المطلوبة أو [shape](/slides/ar/androidjava/create-shape-thumbnails/) نفسها إلى تنسيق نقطي؛ يُسهل ذلك العمل اللاحق مع الهندسات المعقدة.