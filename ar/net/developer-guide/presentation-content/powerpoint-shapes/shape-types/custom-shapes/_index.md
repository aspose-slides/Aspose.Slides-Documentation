---
title: شكل مخصص
type: docs
weight: 20
url: /ar/net/custom-shape/
keywords: 
- شكل
- شكل مخصص
- إنشاء شكل
- هندسة
- هندسة الشكل
- مسار هندسي
- نقاط المسار
- تحرير النقاط
- PowerPoint
- عرض تقديمي
- C#
- Aspose.Slides for .NET
description: "إضافة شكل مخصص إلى عرض PowerPoint في .NET"
---

## تغيير شكل باستخدام نقاط التحرير

اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك

* نقل زاوية المربع للداخل أو للخارج
* تحديد انحناء الزاوية أو النقطة
* إضافة نقاط جديدة إلى المربع
* تحريك النقاط على المربع، إلخ.

أساسًا، يمكنك أداء المهام الموضحة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint من خلال نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* تتكون جميع الأشكال من نقطتي تثبيت على الأقل مرتبطة ببعضها بواسطة خطوط.
* تكون الخطوط إما مستقيمة أو منحنية. تحدد نقاط التثبيت طبيعة الخط.
* توجد نقاط التثبيت كنقاط ركن، نقاط مستقيمة، أو نقاط أملس:
  * نقطة ركن هي نقطة حيث تلتقي خطان مستقيمان بزاوية.
  * نقطة أملس هي نقطة حيث توجد مقبضان في خط مستقيم وتتصل قطع خط المقابلة في منحنى سلس. في هذه الحالة، تكون جميع المقبضات مفصولة عن نقطة التثبيت بمسافة متساوية.
  * نقطة مستقيمة هي نقطة حيث توجد مقبضان في خط مستقيم وتتصل قطع الخط في منحنى سلس. في هذه الحالة، لا تحتاج المقبضات إلى أن تكون مفصولة عن نقطة التثبيت بمسافة متساوية.
* من خلال تحريك أو تحرير نقاط التثبيت (مما يغير زاوية الخطوط)، يمكنك تغيير شكل الشكل.

لتحرير أشكال PowerPoint من خلال نقاط التحرير، توفر **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) وواجهة [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) مسار هندسي كائن [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).
* لاسترجاع `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام الطريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) لـ *الأشكال الصلبة* و[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) لـ *الأشكال المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).
* باستخدام خصائص [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) و[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode)، يمكنك تعيين مظهر لمسار هندسي.
* باستخدام خاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata)، يمكنك استرجاع المسار الهندسي لـ `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) إلى [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* استخدم طرق [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) و[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (من فئة [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) إلى [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) ذهابًا وإيابًا.

## **عمليات التحرير البسيطة**

هذا الكود بلغة C# يوضح لك كيفية

**إضافة خط** إلى نهاية مسار

```csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**إضافة خط** إلى موقع محدد على مسار:

```csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**إضافة منحنى بيزير مكعب** في نهاية المسار:

```csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**إضافة منحنى بيزير مكعب** إلى الموقع المحدد على مسار:

```csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**إضافة منحنى بيزير رباعي** في نهاية المسار:

```csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**إضافة منحنى بيزير رباعي** إلى موقع محدد على مسار:

```csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**إضافة قوس معين** إلى المسار:

```csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**إغلاق الشكل الحالي** لمسار:

```csharp
void CloseFigure();
```
**تعيين الموقع للنقطة التالية**:

```csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**إزالة مقطع المسار** عند فهرس معين:

```csharp
void RemoveAt(int index);
```

## **إضافة نقاط مخصصة إلى الشكل**

1. قم بإنشاء مثيل من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) وتعيين نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.
3. أضف نقطة جديدة بين نقطتي القمة العلوية على المسار.
4. أضف نقطة جديدة بين نقطتي القاع السفليتين على المسار.
5. قم بتطبيق المسار على الشكل.

هذا الكود بلغة C# يوضح لك كيفية إضافة نقاط مخصصة إلى شكل:

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **إزالة النقاط من الشكل**

1. قم بإنشاء مثيل من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) وتعيين نوع [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.
3. أزل الجزء الخاص بالمسار.
4. قم بتطبيق المسار على الشكل.

هذا الكود بلغة C# يوضح لك كيفية إزالة النقاط من الشكل:

```csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

##  **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. قم بإنشاء مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. املأ المسار بالنقاط.
4. قم بإنشاء مثيل من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
5. قم بتطبيق المسار على الشكل.

هذا الكود بلغة C# يوضح لك كيفية إنشاء شكل مخصص:

```csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

  1. قم بإنشاء مثيل من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
  2. قم بإنشاء مثيل أول من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
  3. قم بإنشاء مثيل ثانٍ من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
  4. قم بتطبيق المسارات على الشكل.

هذا الكود بلغة C# يوضح لك كيفية إنشاء شكل مخصص مركب:

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص مع زوايا منحنية**

هذا الكود بلغة C# يوضح لك كيفية إنشاء شكل مخصص مع زوايا منحنية (داخليًا):

```csharp
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

التحقق مما إذا كان شكل في عرض PowerPoint مغلقًا يمكن أن يكون أمرًا حاسمًا لعرض وتحرير العناصر بشكل صحيح على الشرائح. يُعرف الشكل المغلق بأنه الشكل الذي تتصل فيه جميع جوانبه، مما يشكل حدودًا واحدة دون فجوات. يمكن أن يكون هذا الشكل شكلاً هندسياً بسيطاً أو إطاراً مخصصاً معقداً.

تعتبر مغلقة الشكل مهمة لأداء مختلف العمليات، مثل التعبئة باللون أو التدرج، وتطبيق التأثيرات والتحولات، وضمان التفاعل الصحيح مع عناصر الشريحة الأخرى.

للتحقق مما إذا كانت هندسة الشكل مغلقة، تحتاج إلى القيام بما يلي:
1. الحصول على الوصول إلى هندسة الشكل.
2. عد مسارات الهندسة في الشكل.
    2.1. احصل على الجزء الأخير من المسار التالي.
    2.2. تحقق مما إذا كان الجزء الأخير هو أمر `CLOSE`.

يُظهر المثال البرمجي التالي كيفية القيام بذلك:

```csharp
if (shape is GeometryShape geometryShape)
{
    for (int i = 0; i < geometryShape.GetGeometryPaths().Length; i++)
    {
        IGeometryPath path = geometryShape.GetGeometryPaths()[i];

        if (path.PathData.Length == 0) continue;

        IPathSegment lastSegment = path.PathData[path.PathData.Length - 1];
        bool isClosed = lastSegment.PathCommand == PathCommandType.Close;
        
        Console.WriteLine($"Path {i} is closed: {isClosed}");
    }
}
```

## **تحويل GeometryPath إلى GraphicsPath (System.Drawing.Drawing2D)** 

1. قم بإنشاء مثيل من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. قم بإنشاء مثيل من فئة [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) من مساحة اسم [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. تحويل مثيل [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. قم بتطبيق المسارات على الشكل.

هذا الكود بلغة C# — وهو تنفيذ للخطوات المذكورة أعلاه — يوضح لك عملية تحويل **GeometryPath** إلى **GraphicsPath**:

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("نص في الشكل", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)