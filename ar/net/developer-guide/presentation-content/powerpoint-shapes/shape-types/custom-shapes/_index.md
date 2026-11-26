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
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على الشكل.

كما تُظهر كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال بزوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، واستخدام التحويل القديم بين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) لسيناريوهات تخصيص هندسة إضافية.

## **تغيير الشكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل مخطط الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![صورة نظرة عامة](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) إما مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتكاز مترابطة بواسطة قطاعات.
* يمكن أن تكون القطاعات مستقيمة أو منحنية. تحدد نقاط الارتكاز ومقابض التحكم شكلها.
* توجد نقاط الارتكاز كـ:
  * نقاط زاوية، حيث يمكن للقطاعات المتجاورة أن تلتقي بزاوية.
  * نقاط ناعمة، حيث تكون مقابضي التحكم محاذيتين ومساويتين في المسافة من نقطة الارتكاز.
  * نقاط مستقيمة، حيث تكون مقابضي التحكم محاذيتين لكن قد تكون المسافات مختلفة عن نقطة الارتكاز.
* تحريك نقاط الارتكاز أو تعديل مقابضها يغيّر مخطط الشكل.

لتعديل أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) والواجهة [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* تمثل مثيلة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) مسار هندسة كائن [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) من مثيلة [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)، يمكنك استخدام الطريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) للأشكال ذات المسار الواحد و[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) للأشكال ذات المسارات المتعددة.
* لإضافة قطاعات، يمكنك استخدام الطرق المتاحة تحت [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* باستخدام الخاصيتين [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) و[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/)، يمكنك تحديد مظهر مسار الهندسة.
* باستخدام الخاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)، يمكنك استرجاع مسار هندسة [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.
* في الإصدارات القديمة التي تدعم طرق التحويل أدناه، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) إلى [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* استخدم طريقتي [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) و[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (من الفئة [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) للتحويل بين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار الهندسة. تُدرج المتجاوزات التي تقبل فهرسًا قطعةً في الموضع الصفري‑الأساسي داخل مصفوفة قطاعات المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| إلحاق أو إدراج منحنى بيزير مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| إلحاق أو إدراج منحنى بيزير رباعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| تعيين نقطة البداية لشكل. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| إزالة قطاع عند فهرس صفري‑الأساس. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يدخل نقطتين إلى شكل مستطيل باستخدام [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) ويطبق المسار المعدل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). الإحداثيات محلية بالنسبة للشكل: كلا النقطتين الجديدتين في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. الفهارس 1 و4 للقطاعات تضعهما على الحافتين العلوية والسفلية، مما يسحب هاتين الحافتين إلى الداخل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![صورة مثال 1](custom_shape_1.png)

## **إزالة نقاط من شكل**

هذا المثال يغيّر مخطط شكل على شكل قلب بإزالة القطاع عند الفهرس الصفري‑الأساسي 2 باستخدام [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). تطبيق المسار المعدل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) يحدث مظهر الشكل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![صورة مثال 2](custom_shape_2.png)

## **إنشاء شكل مخصص**

هذا المثال يبني نجمة بخمس نقاط باستخدام [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). تُحدد الأنصاف القطرية الخارجية والداخلية التي قيمتها 100 و50 نقطة لتُكوّن البُرُوج والفتحات؛ خطوة 72 درجة توزع الخمس بُرُوج بالتساوي. يُغلق المسار باستخدام [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) ويُطبق على شكل مستطيل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)، مستبدلاً مخططه.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![صورة مثال 3](custom_shape_3.png)

## **إنشاء شكل مركب مخصص**

هذا المثال يعرّف مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) للثُلثين العلوي والسفلي من الشكل. تطبيق كلا المسارين عبر [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2, 0);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![صورة مثال 4](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

هذا المثال يجمع قطاعات مستقيمة مع [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) لإنشاء شكل بزوايا منحنية إلى الداخل. تحدد كل زاوية حجم القوس بالعرض والارتفاع بالنقاط، وتُرسم القطعة ذات الزاوية -90 درجة قوسًا ربعيًا مضادًا لعقارب الساعة. يُطبق المسار المكتمل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)، وتُحفظ العروض بصيغة PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

المساعد التالي يتحقق مما إذا كان كل مسار هندسي غير فارغ ينتهي بقطاع إغلاق. يقرأ [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) ويقارن أمر القطاع الأخير [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) مع [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). يُعيد false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. المثال يطبع `True` لمستطيل.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **فحص أوامر مسار الهندسة**

حمّل الملف [contour.pptx](contour.pptx) وضعه في دليل العمل الخاص بالتطبيق. الشريحة الأولى تحتوي على شكل بحافة علوية مستقيمة، ومنحنى بيزير مكعب، وحافة إغلاق مستقيمة. استخدم [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) لقراءة مساراته. كل مسار يسرد قطاعاته بترتيب الرسم في [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). يحدّد [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) لكل قطاع كيفية قراءة [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

الشكل يقع عند النقاط (200, 100) على الشريحة. النقاط المُبلغ عنها محلية بالنسبة للشكل، حيث (0, 0) هو الزاوية العلوية اليسرى، x يزداد إلى اليمين، وy يزداد إلى الأسفل. يُعيد القطاع الختامي إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من اليمين العلوي إلى اليسار السفلي، وحافة يسارية مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. حول كل [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) إلى [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) لقراءة مصفوفتي [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) و[PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). هذا التمثيل مفيد لتحليل المخطط أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال عرضًا تقديميًا، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع قطاعاته. استخدم عرضًا يحتوي على شكل بقطاعات مستقيمة ومنحنية لرؤية كلا النوعين من الناتج. لا يبحث داخل المجموعات.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // احتفظ بنوع القطاع، مستثنياً العلامات.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

المصفوفات متطابقة حسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ قطاع بيزير مكعب عند النهاية السابقة ويستخدم ثلاثة مدخلات من النوع `3` المتتالية: نقطتي تحكم ثم النهاية الجديدة. يستهلك الحلقة هذه الثلاثة مدخلات معًا ويتحقق من النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع القطاع، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزير تغلق مسارًا. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى مثل الشرط (`0x10`) والعلامة (`0x20`) لا تغير النوع الأساسي للقطاع.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجموعة، تضم الإحداثيات المستخرجة بالفعل موضعه [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، مستطيل غير مدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود مخطط `(100, 200)`–`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار غير مدوَّر.

النقاط المستخرجة لا تُطبق خاصية [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) أو الانعكاسات الأفقية والعمودية للشكل. لتكرار المخطط المعروض، طَبِّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمَّعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياسًا مرتين إذا كان قد تم تضمينه بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المخطط؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج إلى مصفوفات نقطة/نوع للتحليل أو الرسم. استخدم [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) عندما تحتاج إلى أوامر هندسة في نظام إحداثيات الشكل المحلي أو ترغب في تحرير هندسته. طبّق المسارات المعدلة عبر [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) أو [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **تحويل GeometryPath إلى GraphicsPath (System.Drawing.Drawing2D)**

يتطلب المثال التالي تجميعًا قديمًا من Aspose.Slides for .NET يدعم [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)، مثل الإصدار 25.10، وبيئة Windows مع `System.Drawing.Common`. أُزيلت طرق التحويل في [النسخة 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

يجمع هذا المثال مخططًا مستطيلاً مع نص محوَّل إلى هندسة. تُحدد خاصية [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) لإلغاء تعبئة الخط. يخزن [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) مخطط النص، ثم يحوله [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) إلى مسار هندسة مُعبَّأ. تطبيق كلا المسارين عبر [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ينتج شكلاً واحدًا يحتوي على المستطيل والنص. للتحويل في الاتجاه المعاكس، استخدم [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![صورة مثال 5](custom_shape_5.png)

## **الأسئلة الشائعة**

**ماذا يحدث للملء والمخطط بعد استبدال الهندسة؟**

يبقى النمط مرتبطًا بالشكل؛ فقط المخطط يتغير. يُطبق الملء والمخطط تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) للشكل؛ الهندسة تدور مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر شريحة [slide](/slides/ar/net/convert-powerpoint-to-png/) المطلوبة أو [shape](/slides/ar/net/create-shape-thumbnails/) نفسها إلى تنسيق نقطي؛ هذا يبسط العمل اللاحق مع الهندسات المعقدة.