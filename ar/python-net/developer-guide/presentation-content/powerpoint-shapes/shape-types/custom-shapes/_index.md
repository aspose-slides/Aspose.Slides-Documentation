---
title: شكل مخصص
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "شكل PowerPoint، شكل مخصص، عرض PowerPoint، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "إضافة شكل مخصص في عرض PowerPoint باستخدام بايثون"
---

# تغيير شكل باستخدام نقاط تحرير

اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك 

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التلاعب بالنقاط على المربع، إلخ.

بشكل أساسي، يمكنك إجراء المهام الموضحة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## نصائح تحرير الشكل

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint من خلال نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، فإنه يفتقر إلى نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، فإنه يحتوي على بداية ونهاية. 
* تتكون جميع الأشكال من 2 نقطة تثبيت على الأقل مرتبطة ببعضها بخطوط.
* الخط إما مستقيم أو منحني. تحدد نقاط التثبيت طبيعة الخط. 
* توجد نقاط التثبيت كنقاط زاوية، نقاط مستقيمة، أو نقاط سلسة:
  * نقطة الزاوية هي نقطة تلتقي فيها خطان مستقيمان بزاوية. 
  * النقطة السلسة هي نقطة حيث توجد مقبضان في خط مستقيم وتلتقي مقاطع الخط في منحنى سلس. في هذه الحالة، تكون جميع المقابض متباعدة عن نقطة التثبيت بنفس المسافة. 
  * النقطة المستقيمة هي نقطة حيث توجد مقبضان في خط مستقيم وتلتقي مقاطع ذلك الخط في منحنى سلس. في هذه الحالة، لا تحتاج المقابض إلى أن تكون متباعدة عن نقطة التثبيت بنفس المسافة. 
* من خلال تحريك أو تحرير نقاط التثبيت (التي تغير زاوية الخطوط)، يمكنك تغيير مظهر الشكل.

لتحرير أشكال PowerPoint من خلال نقاط التحرير، توفر **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) وواجهة [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/). 

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسار الهندسة لكائن [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/).
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام طريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/). 
* لتعيين `GeometryPath` لشكل ما، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) لأشكال *صلبة* و [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) لأشكال *تركيبية*.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).
* باستخدام الخاصيتين [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) و [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) ، يمكنك تعيين مظهر لمسار الهندسة.
* باستخدام خاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata)، يمكنك استرداد مسار الهندسة لشكل `GeometryShape` كمصفوفة من مقاطع المسار. 
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) إلى [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* استخدم طريقتي `GeometryPathToGraphicsPath` و `GraphicsPathToGeometryPath` (من فئة [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/)) لتحويل `GeometryPath` إلى `GraphicsPath` والعكس.

## **عمليات تحرير بسيطة**

هذا الكود بلغة البايثون يوضح لك كيفية

**إضافة خط** إلى نهاية مسار:

```py
line_to(point)
line_to(x, y)
```
**إضافة خط** إلى موضع محدد على مسار:

```py    
line_to(point, index)
line_to(x, y, index)
```
**إضافة منحنى بيزيه مكعب** في نهاية مسار:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**إضافة منحنى بيزيه مكعب** إلى الموضع المحدد على مسار:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**إضافة منحنى بيزيه رباعي** في نهاية مسار:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**إضافة منحنى بيزيه رباعي** إلى موضع محدد على مسار:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**إضافة قوس محدد** إلى مسار:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```
**إغلاق الشكل الحالي** لمسار:
```py
close_figure()
```
**تعيين الموضع للنقطة التالية**:
```py
move_to(point)
move_to(x, y)
```
**إزالة مقطع المسار** عند مؤشر معين:

```py
remove_at(index)
```
## إضافة نقاط مخصصة إلى الشكل
1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) واضبط [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. أضف نقطة جديدة بين نقطتين علويتين على المسار.
4. أضف نقطة جديدة بين نقطتين سفليتين على المسار.
6. طبق المسار على الشكل.

هذا الكود بلغة البايثون يوضح لك كيفية إضافة نقاط مخصصة إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## إزالة نقاط من الشكل

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) واضبط نوع [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/). 
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. قم بإزالة المقطع من المسار.
4. طبق المسار على الشكل.

هذا الكود بلغة البايثون يوضح لك كيفية إزالة نقاط من شكل:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

	path = shape.get_geometry_paths()[0]
	path.remove_at(2)
	shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## إنشاء شكل مخصص

1. احسب النقاط للشكل.
2. أنشئ مثيلًا من فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). 
3. قم بملء المسار بالنقاط.
4. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/). 
5. طبق المسار على الشكل.

هذا الكود بلغة البايثون يوضح لك كيفية إنشاء شكل مخصص:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)

## إنشاء شكل مخصص مركب

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
2. أنشئ مثيلًا أول من فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
3. أنشئ مثيلًا ثاني من فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
4. طبق المسارات على الشكل.

هذا الكود بلغة البايثون يوضح لك كيفية إنشاء شكل مخصص مركب:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بأركان منحنيه**

هذا الكود بلغة البايثون يوضح لك كيفية إنشاء شكل مخصص بأركان منحنيه (داخلية):

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## تحويل GeometryPath إلى GraphicsPath (System.Drawing.Drawing2D) 

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
2. أنشئ مثيلًا من فئة [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) من مساحة الاسم [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. قم بتحويل مثيل [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) باستخدام [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/).
4. طبق المسارات على الشكل.

هذا الكود بلغة البايثون — وهو تطبيق للخطوات أعلاه — يوضح عملية تحويل **GeometryPath** إلى **GraphicsPath**:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("النص في الشكل", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)