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
- مسار الهندسة
- نقاط المسار
- نقاط التحرير
- PowerPoint
- عرض تقديمي
- C#
- Aspose.Slides for .NET
description: "إضافة شكل مخصص إلى عرض تقديمي PowerPoint في .NET"
---

## **تغيير شكل باستخدام نقاط التحرير**

اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء للزاوية أو النقطة
* إضافة نقاط جديدة إلى المربع
* تعديل النقاط على المربع، إلخ. 

بشكل أساسي، يمكنك تنفيذ المهام الموصوفة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود. 

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.  
* جميع الأشكال تتكون من نقطتين ارتكاز على الأقل مرتبطتين ببعضهما بواسطة خطوط  
* يمكن أن يكون الخط مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز طبيعة الخط.  
* نقاط الارتكاز توجد كنقاط زاوية أو نقاط مستقيمة أو نقاط ناعمة:
  * نقطة الزاوية هي النقطة التي يلتقي فيها خطان مستقيران بزاوية.  
  * نقطة ناعمة هي النقطة التي يوجد فيها مقبضان على خط مستقيم وتلتقي مقاطع الخط في منحنى ناعم. في هذه الحالة، يتم فصل جميع المقابض عن نقطة الارتكاز بمسافة متساوية.  
  * نقطة مستقيمة هي النقطة التي يوجد فيها مقبضان على خط مستقيم وتلتقي مقاطع الخط في منحنى ناعم. في هذه الحالة، لا يلزم أن تكون المقابض منفصلة عن نقطة الارتكاز بمسافة متساوية.  
* عن طريق تحريك أو تحرير نقاط الارتكاز (التي تغير زاوية الخطوط)، يمكنك تغيير مظهر الشكل.  

لتحرير أشكال PowerPoint عبر نقاط التحرير، **Aspose.Slides** توفر الفئة [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) والواجهة [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).  

* تمثّل مثال **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)** مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).  
* لاسترجاع `GeometryPath` من مثال `IGeometryShape`، يمكنك استخدام طريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).  
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) للأشكال الصلبة و[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) للأشكال المركبة.  
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).  
* باستخدام خاصيتي [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) و[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode)، يمكنك تعيين مظهر المسار الهندسي.  
* باستخدام خاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata)، يمكنك استرجاع مسار الهندسة لكائن `GeometryShape` كمصفوفة من مقاطع المسار.  
* للوصول إلى خيارات تخصيص إضافية لهندسة الشكل، يمكنك تحويل **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)** إلى **[GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)**.  
* استخدم طرق **GeometryPathToGraphicsPath** و**GraphicsPathToGeometryPath** (من فئة **[ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)**) لتحويل **[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)** إلى **[GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)** والعكس.  

## **عمليات تحرير بسيطة**

هذا الكود C# يوضح لك كيفية

**إضافة خط** إلى نهاية مسار  
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
  
**إضافة خط** إلى موضع محدد على المسار:  
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
  
**إضافة منحنى بيزيه مكعب** إلى نهاية مسار:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
  
**إضافة منحنى بيزيه مكعب** إلى موضع محدد على المسار:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
  
**إضافة منحنى بيزيه رباعي** إلى نهاية مسار:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
  
**إضافة منحنى بيزيه رباعي** إلى موضع محدد على المسار:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
  
**إلحاق قوس معين** إلى مسار:  
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
  
**إغلاق الشكل الحالي** للمسار:  
``` csharp
void CloseFigure();
```
  
**تعيين الموضع للنقطة التالية**:  
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
  
**إزالة مقطع المسار** عند فهرس معين:  
``` csharp
void RemoveAt(int index);
```
  

## **إضافة نقاط مخصصة إلى الشكل**

1. أنشئ مثالًا من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) وحدد النوع [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. احصل على مثال من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.  
3. أضف نقطة جديدة بين النقطتين العلويتين على المسار.  
4. أضف نقطة جديدة بين النقطتين السفليتين على المسار.  
5. طبّق المسار على الشكل.  

هذا الكود C# يوضح لك كيفية إضافة نقاط مخصصة إلى شكل:  
``` csharp
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

## **إزالة نقاط من الشكل**

1. أنشئ مثالًا من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) وحدد النوع [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. احصل على مثال من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.  
3. أزل المقطع للمسار.  
4. طبّق المسار على الشكل.  

هذا الكود C# يوضح لك كيفية إزالة نقاط من شكل:  
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
  

![example2_image](custom_shape_2.png)  

## **إنشاء شكل مخصص**

1. احسب النقاط اللازمة للشكل.  
2. أنشئ مثالًا من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. عبّئ المسار بالنقاط.  
4. أنشئ مثالًا من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
5. طبّق المسار على الشكل.  

هذا الكود C# يوضح لك كيفية إنشاء شكل مخصص:  
``` csharp
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

1. أنشئ مثالًا من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. أنشئ المثال الأول من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. أنشئ المثال الثاني من فئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
4. طبّق المسارات على الشكل.  

هذا الكود C# يوضح لك كيفية إنشاء شكل مخصص مركب:  
``` csharp
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

## **إنشاء شكل مخصص بزوايا منحنية**

هذا الكود C# يوضح لك كيفية إنشاء شكل مخصص بزوايا منحنية (متجهة إلى الداخل);  
```c#
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
  

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكونًا حدًا واحدًا دون فجوات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح المثال البرمجي التالي كيفية فحص ما إذا كانت هندسة الشكل مغلقة:  
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```
  

## **تحويل GeometryPath إلى GraphicsPath (System.Drawing.Drawing2D)**

1. أنشئ مثالًا من فئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. أنشئ مثالًا من فئة [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) من مساحة الأسم [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. حوّل مثال **GraphicsPath** إلى مثال **GeometryPath** باستخدام **ShapeUtil**.  
4. طبّق المسارات على الشكل.  

هذا الكود C#—تنفيذ للخطوات أعلاه—يظهر عملية تحويل **GeometryPath** إلى **GraphicsPath**:  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
  

![example5_image](custom_shape_5.png)  

## **الأسئلة المتداولة**

**ماذا سيحدث للملء والمحيط بعد استبدال الهندسة؟**  

يظل النمط مرتبطًا بالشكل؛ فقط الحدود تتغير. يتم تطبيق الملء والمحيط تلقائيًا على الهندسة الجديدة.  

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**  

استخدم خاصية [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) للشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.  

**هل يمكنني تحويل الشكل المخصص إلى صورة “لإغلاق” النتيجة؟**  

نعم. صدّر المنطقة المطلوبة من [الشريحة](/slides/ar/net/convert-powerpoint-to-png/) أو الشكل نفسه [من الشريحة](/slides/ar/net/create-shape-thumbnails/) إلى تنسيق نقطي؛ هذا يبسط العمل اللاحق مع الهندسات الثقيلة.