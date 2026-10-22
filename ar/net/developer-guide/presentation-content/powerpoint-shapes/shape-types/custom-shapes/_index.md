---
title: تخصيص أشكال العرض التقديمي في .NET
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
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العرض التقديمي في Aspose.Slides عن طريق تحرير هندسة الشكل عبر نقاط التحرير ومسارات الهندسة. تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على شكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال ذات زوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، واستخدام التحويل القديم بين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) لمزيد من سيناريوهات تخصيص الهندسة.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:
* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل مخطط الشكل أو استخدام شكل موجود كأساس لخلق شكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على هذه المفاهيم:
* الشكل (أو مساره) يمكن أن يكون مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ربط متصلة بقطاعات.
* يمكن أن تكون القطاعات مستقيمة أو منحنية. تحدد نقاط الربط ومقابض التحكم شكلها.
* توجد نقاط الربط كنقاط زاوية أو نقاط مستقيمة أو نقاط ناعمة:
  * عند نقطة زاوية، يمكن للقطاعات المتجاورة أن تلتقي بزاوية.
  * عند نقطة ناعمة، يكون مقبضان التحكم محاذيين وعلى مسافة متساوية من نقطة الربط.
  * عند نقطة مستقيمة، يكون مقبضان التحكم محاذيين لكن قد تكون المسافة منهما إلى نقطة الربط مختلفة.
* تحريك نقاط الربط أو تعديل مقابضها يغيّر مخطط الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) والواجهة [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* تمثل نسخة [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) من نسخة [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) يمكنك استخدام طريقة [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) للأشكال ذات المسار الواحد و[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) للأشكال التي تحتوي على مسارات متعددة.
* لإضافة قطاعات، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* باستخدام خاصيتي [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) و[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) يمكنك تعيين مظهر لمسار الهندسة.
* باستخدام خاصية [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) يمكنك استرجاع مسار الهندسة لـ[GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.
* في الإصدارات القديمة التي تدعم طرق التحويل أدناه، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) إلى [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* استخدم طرق [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) و[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (من فئة [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) للتحويل بين [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرس تُدرج قطاعًا في ذلك الموضع الصفري في مصفوفة قطاعات المسار.

| العملية | الطريقة |
| --- | --- |
| إضافة أو إدراج خط مستقيم. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| إضافة أو إدراج منحنى بيزير مكعّب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| إضافة أو إدراج منحنى بيزير رباعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| إضافة قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| تحديد نقطة البداية للشكل. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| إزالة قطاع عند فهرس يبدأ من الصفر. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **إضافة نقاط مخصصة إلى شكل**

يوضح هذا المثال إدراج نقطتين في شكل مستطيل باستخدام [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) وتطبيق المسار المعدل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). الإحداثيات محلية للشكل: النقطتان الجديدتان في مركزه، على بعد 100 نقطة من اليسار و50 نقطة من الأعلى. مؤشرات القطاعات 1 و4 تضعهما على الحافتين العلوية والسفلية، سحباً لتلك الحواف إلى الداخل.

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

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

يغيّر هذا المثال مخطط شكل على شكل قلب بإزالة القطاع عند الفهرس الصفري 2 باستخدام [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). تطبيق المسار المعدل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) يحدث حدود الشكل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

يبني هذا المثال نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). تحدد أنصاف الأقطار الخارجية والداخلية 100 و50 نقطة لتحديد الأطراف والفتحات؛ خطوة 72 درجة تفرق الأطراف الخمسة بالتساوي. يُغلق المسار باستخدام [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) ويُطبق على شكل مستطيل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)، مستبدلاً مخططه.

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
![example3_image](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

يعّرف هذا المثال مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. تطبيق المسارين عبر [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) يخلق شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

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
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

يجمع هذا المثال قطاعات مستقيمة مع [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) لإنشاء شكل بزوايا منحنية للداخل. يحدد كل حجم زاوية عرض وارتفاع القوس بالنقاط، وتدور القطعة -90 درجة لترسم ربع إهليلج عكس اتجاه عقارب الساعة. يطبق المسار المكتمل عبر [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)، ويحفظ العرض التقديمي بصيغة PPTX.

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

## **اكتشاف ما إذا كانت هندسة الشكل مغلقة**

يتحقق المساعد التالي ما إذا كان كل مسار هندسي غير فارغ ينتهي بقطاع إغلاق. يقرأ [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) ويقارن أمر القطاع النهائي [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) بـ[PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). يُعيد false عندما لا توجد مسارات غير فارغة. يتحقق من الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. يطبع المثال `True` لمستطيل.

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

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. حول كل [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) إلى [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) لقراءة مصفوفات [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) و[PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). هذا التمثيل مفيد لتحليل الحدود أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال عرضًا تقديميًا، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع قطاعات مساره. استخدم عرضًا يحتوي على شكل بقطاعات مستقيمة ومنحنية لتشهد كلا النوعين من المخرجات. لا يبحث داخل المجموعات.

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
        var pointType = types[i] & 0x07; // احتفظ بنوع القطعة، مع استبعاد العلامات.
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
                i += 2; // استهلك كل من نقاط التحكم والنقطة النهائية.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

المصفوفات متطابقة وفق الفهرس: `points[i]` هي نقطة و`types[i]` يصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ قطاع بيزير مكعّب من النقطة السابقة ويستخدم ثلاثة مدخلات نوع `3` متتالية: نقطتي تحكم ثم النقطة النهائية الجديدة. يستهلك الحلقة هذه الثلاث مدخلات معًا ويفحص النقطة النهائية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع القطاع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهائية لخط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهائية لبيزير تغلق واحدًا. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى مثل الشرط (`0x10`) والعلامة (`0x20`) لا تغير النوع الأساسي للقطاع.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجمع، تشمل الإحداثيات المستخرجة موقعه [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مدوّر عند `(100, 200)` بحجم `120 × 80` له حدود الحد الخارجي `(100, 200)`–`(220, 280)`. لا تُضف موقع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار غير مدوّر.

النقاط المستخرجة لا تُطبق دوران الشكل [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) أو الانعكاسات الأفقية والرأسية. لت reproducing الشكل المعروض، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياس مرتين إذا كان قد تم تضمينه بالفعل في إطار العنصر الفرعي.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحد؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما يحتاج تحليلك أو كود الرسم إلى مصفوفات النقاط/الأنواع. استخدم [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبق المسارات المعدلة عبر [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) أو [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **تحويل GeometryPath إلى GraphicsPath (System.Drawing.Drawing2D)**

يتطلب المثال التالي تجميعة قديمة لـ Aspose.Slides for .NET تدعم [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)، مثل الإصدار 25.10، وبيئة Windows مع `System.Drawing.Common`. أُزيلت طرق التحويل في [الإصدار 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

يجمع هذا المثال مخططًا مستطيليًا مع نص محوّل إلى هندسة. يُضبط [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) الخاص بالمخطط لإلغاء تعبئته. يخزن [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) مخطط النص، والذي يحوله [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) إلى مسار هندسي مُعبأ. تطبيق كلا المسارين عبر [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ينتج شكلًا واحدًا يحتوي على المستطيل والنص. للتحويل في الاتجاه المعاكس، استخدم [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![example5_image](custom_shape_5.png)

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحد بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغير الحد فقط. يُطبق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة "لتثبيت" النتيجة؟**

نعم. صدّر الـ[الشريحة](/slides/ar/net/convert-powerpoint-to-png/) المطلوبة أو الـ[الشكل](/slides/ar/net/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل الإضافي مع الهندسات المعقدة.