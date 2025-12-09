---
title: تخصيص أشكال العروض التقديمية في .NET
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/net/custom-shape/
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
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---

## **تغيير شكل باستخدام نقاط التحرير**

تخيل مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك

* تحريك زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التعامل مع النقاط على المربع، إلخ.

بشكل أساسي، يمكنك تنفيذ المهام الموصوفة على أي شكل. باستخدام نقاط التحرير، يمكنك تعديل شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في مراعاة هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* جميع الأشكال تتكون من نقطتي تثبيت على الأقل مرتبطتين ببعضهما عبر خطوط.
* الخط إما مستقيم أو منحني. تحدد نقاط التثبيت طبيعة الخط.
* نقاط التثبيت توجد كزوايا، أو نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي النقطة التي يلتقي فيها خطان مستقيران بزاوية.
  * النقطة الناعمة هي النقطة التي يوجد فيها مقبضان على خط مستقيم وتلتقي قطاعات الخط بانحناء ناعم. في هذه الحالة، تكون المسافة بين المقابض ونقطة التثبيت متساوية.
  * النقطة المستقيمة هي النقطة التي يوجد فيها مقبضان على خط مستقيم وتلتقي قطاعات الخط بانحناء ناعم. في هذه الحالة، لا يجب أن تكون المسافة بين المقابض ونقطة التثبيت متساوية.
* من خلال تحريك أو تحرير نقاط التثبيت (التي تغير زاوية الخطوط)، يمكنك تغيير مظهر الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) والواجهة [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* تمثل نسخة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) مسار الهندسة لكائن [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).
* لاسترجاع `GeometryPath` من نسخة `IGeometryShape`، يمكنك استخدام الطريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) للأشكال الصلبة و[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) للأشكال المركبة.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).
* باستخدام الخاصيتين [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) و[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode)، يمكنك ضبط مظهر مسار الهندسة.
* باستخدام الخاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata)، يمكنك استرجاع مسار الهندسة لـ `GeometryShape` كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص إضافية لهندسة الشكل، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) إلى [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* استخدم طريقتي [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) و[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (من الفئة [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) لتحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) إلى [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) والعكس.

## **عمليات تحرير بسيطة**

هذا الكود C# يوضح لك كيفية

**إضافة خط** إلى نهاية مسار
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**إضافة خط** إلى موضع محدد على مسار:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**إضافة منحنى بيزيه مكعب** في نهاية مسار:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**إضافة منحنى بيزيه مكعب** إلى موضع محدد على مسار:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**إضافة منحنى بيزيه رباعي** في نهاية مسار:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**إضافة منحنى بيزيه رباعي** إلى موضع محدد على مسار:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**إلحاق قوس محدد** إلى مسار:
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

1. أنشئ نسخة من الفئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) واضبط النوع إلى [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. احصل على نسخة من الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.
3. أضف نقطة جديدة بين النقطتين العلويتين على المسار.
4. أضف نقطة جديدة بين النقطتين السفلية على المسار.
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

1. أنشئ نسخة من الفئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) واضبط النوع إلى [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. احصل على نسخة من الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) من الشكل.
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

1. احسب النقاط للشكل.
2. أنشئ نسخة من الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. عبّئ المسار بالنقاط.
4. أنشئ نسخة من الفئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
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

1. أنشئ نسخة من الفئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. أنشئ النسخة الأولى من الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. أنشئ النسخة الثانية من الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
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

## **إنشاء شكل مخصص بزوايا منحنى**

هذا الكود C# يوضح لك كيفية إنشاء شكل مخصص بزوايا منحنى (متجهة إلى الداخل);
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

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكوّناً حدًا واحدًا دون فجوات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يُظهر المثال التالي كيفية التحقق مما إذا كانت هندسة الشكل مغلقة:
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

1. أنشئ نسخة من الفئة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. أنشئ نسخة من الفئة [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) ضمن مساحة الاسم [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. حوّل نسخة [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) إلى نسخة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) باستخدام [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. طبّق المسارات على الشكل.

هذا الكود C#—تنفيذ للخطوات أعلاه—يوضح عملية تحويل **GeometryPath** إلى **GraphicsPath**:
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

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ تتغير فقط القاعدة. يتم تطبيق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف أقوم بتدوير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من [slide](/slides/ar/net/convert-powerpoint-to-png/) أو الشكل نفسه [shape](/slides/ar/net/create-shape-thumbnails/) إلى صيغة نقطية؛ هذا يبسط العمل اللاحق مع الهندسات المعقدة.