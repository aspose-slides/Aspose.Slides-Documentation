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
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. توضح كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، إجراء عمليات تحرير مسار أساسية، إضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال بزوايا منحنية، تحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل باستخدام مصفوفات نقاط Android.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل مخطط الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة هذه المفاهيم:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتكاز متصلة بقطاعات.
* يمكن أن تكون القطعة مستقيمة أو منحنية. تحدد نقاط الارتكاز ومقابض التحكم شكلها.
* توجد نقاط الارتكاز ك نقاط زاوية، نقاط مستقيمة، أو نقاط ناعمة:
  * في نقطة الزاوية، يمكن للقطاعات المتجاورة أن تلتقي بزاوية.
  * في النقطة الناعمة، يتماشى مقبضا التحكم وتكونان على مسافة متساوية من نقطة الارتكاز.
  * في النقطة المستقيمة، يتماشى مقبضا التحكم لكن يمكن أن تكون المسافتان مختلفتين عن نقطة الارتكاز.
* يتحرك نقاط الارتكاز أو تعديل مقابضها يغيّر مخطط الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) والواجهة [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* تمثل مثيلة [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) مسار هندسة كائن [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) من مثيلة [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)، يمكنك استخدام الطريقة [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* لتعيين [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) للأشكال ذات مسار واحد و[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) للأشكال ذات مسارات متعددة.
* لإضافة قطاعات، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* باستخدام الطريقتين [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) و[IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-)، يمكنك تعيين مظهر مسار الهندسة.
* باستخدام الطريقة [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--)، يمكنك استرداد مسار الهندسة لـ[GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرس تُدرج قطعة في ذلك الموضع الصفري في مصفوفة قطاعات المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| إلحاق أو إدراج منحنى بيزييه مكعب مع نقطتي تحكم ونقطة نهاية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| إلحاق أو إدراج منحنى بيزييه رباعي مع نقطة تحكم واحدة ونقطة نهاية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| إغلاق الشكل الحالي بربط نقطة النهاية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| تعيين نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| إزالة قطاع عند فهرس صفري. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يُدرج نقطتين في شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) ويطبق المسار المُعدل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). الإحداثيات محلية للشكل: كلا النقطتين الجديدتين في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. مؤشرات القطاعات 1 و4 تضعهما على الحافتين العلوية والسفلية، ساحبًا تلك الحافات إلى الداخل.

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

هذا المثال يغيّر مخطط قلب الشكل بإزالة القطاع عند الفهرس الصفري 2 باستخدام [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). تطبيق المسار المعدل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) يُحدّث محيط الشكل.

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

هذا المثال يبني نجمة خماسية القمم باستخدام [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). تُحدّد أنصاف الأقطار الخارجية والداخلية المتبادلة 100 و50 نقطة لتحديد القمم والإنقامات؛ خطوة 72 درجة تفرق بين الخمس قمم بالتساوي. يُغلق المسار باستخدام [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) ويُطبق على شكل مستطيل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)، مستبدلاً مخططه.

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
![example3_image](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

هذا المثال يعرّف اثنين من مسارات [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) المغلقة للثلث العلوي والسفلي من الشكل. تطبيق كلا المسارين باستخدام [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

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

هذا المثال يجمع قطاعات مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) لإنشاء شكل بزوايا منحنية إلى الداخل. كل حجم زاوية يحدد عرض وارتفاع القوس بالنقاط، واللف بزاوية -90 درجة يرسم ربع إهليلج عكس اتجاه عقارب الساعة. يُطبق المسار المكتمل باستخدام [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)، ويتم حفظ العرض التقديمي بصيغة PPTX.

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

يتحقق المساعد التالي مما إذا كان كل مسار هندسي غير فارغ ينتهي بقطاع إغلاق. يقرأ [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) ويقارن أمر القطاع النهائي [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) مع [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). يُعيد false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ ولا يفحص كل شكل فرعي داخل المسار. المثال يطبع `true` لمستطيل.

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

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. حوِّل كل [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) مُعاد إلى [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) لاسترداد مصفوفات النقاط والأنواع عبر [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) و[getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . هذا التمثيل مفيد لتحليل المخطط أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال input.pptx، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع قطاعات مساره. استخدم عرضًا تقديميًا يحتوي على شكل بقطاعات مستقيمة ومنحنية لرؤية كلا النوعين من الناتج. لا يبحث داخل المجموعات.

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
                int pointType = types[i] & 0x07; // احتفظ بنوع القطعة، مستبعدًا الأعلام.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // استهلك كل نقطتي التحكم ونقطة النهاية.
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

المصفوفات تتطابق بحسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ قطاع بيزييه مكعب عند نقطة النهاية السابقة ويستخدم ثلاثة إدخالات من النوع `3` متتابعة: نقطتا تحكم ثم نقطة النهاية الجديدة. الحلقة تستهلك هذه الإدخالات الثلاثة معًا وتفحص نقطة النهاية للإغلاق.

أنواع النقاط تحتوي أيضًا على أعلام. قم بالقناع بـ `0x07` لتحديد نوع القطاع، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) تعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) تعني نقطة نهاية بيزييه تُغلق واحدة. تخزن Java هذه الأعلام في بايتات موقعة؛ القناع يحافظ على قيم البت المطلوبة. مقارنة القيمة الخام فقط بـ `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل الشرط (`0x10`) والعلامة (`0x20`)، لا تغير نوع القطاع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بالنقاط (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجمع، تشمل الإحداثيات المستخرجة بالفعل الموضع الذي تُرجعه [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) و[getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مُدوَّر في `(100, 200)` بحجم `120 × 80` له حدود مخطط `(100, 200)`–`(220, 280)`. لا تُضفِ موضع الشكل مرة أخرى. اطرح قيم X وY للحصول على إحداثيات نسبية لإطار غير مُدوَّر.

النقاط المستخرجة لا تطبق دوران الشكل، الذي تُرجعه [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--)، ولا انعكاسات أفقية أو رأسية. لإعادة إنتاج المخطط الظاهر، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياسًا مرتين إذا كان قد انعكس بالفعل في إطار العنصر الفرعي.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المخطط؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج تحليلاتك أو شيفرة الرسم إلى مصفوفات النقاط/الأنواع. استخدم [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) أو [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **الأسئلة المتكررة**

**ماذا يحدث للملء والمحيط بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغير فقط المخطط. يُطبق الملء والمحيط تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثياته الخاص.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من [الشريحة](/slides/ar/androidjava/convert-powerpoint-to-png/) أو الـ[شكل](/slides/ar/androidjava/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ يُسهّل ذلك العمل اللاحق مع الهندسات المعقدة.