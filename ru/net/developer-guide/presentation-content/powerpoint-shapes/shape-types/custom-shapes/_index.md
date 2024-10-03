---
title: Пользовательская Форма
type: docs
weight: 20
url: /ru/net/custom-shape/
keywords: 
- форма
- пользовательская форма
- создать форму
- геометрия
- геометрия формы
- геометрический путь
- точки пути
- редактировать точки
- PowerPoint
- презентация
- C#
- Aspose.Slides для .NET
description: "Добавьте пользовательскую форму в презентацию PowerPoint на .NET"
---

## Изменение формы с помощью редактируемых точек

Рассмотрим квадрат. В PowerPoint с помощью **редактируемых точек** вы можете 

* переместить угол квадрата внутрь или наружу
* задать кривизну для угла или точки
* добавить новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные задачи с любой формой. С помощью редактируемых точек вы можете изменить форму или создать новую форму на основе существующей.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

Перед тем как начать редактировать формы PowerPoint через редактируемые точки, вам стоит учесть следующие моменты о формах:

* Форма (или ее путь) может быть закрытой или открытой.
* Все формы состоят как минимум из 2 опорных точек, связанных между собой линиями
* Линия может быть прямой или кривой. Опорные точки определяют характер линии. 
* Опорные точки могут быть угловыми, прямыми или гладкими:
  * Угловая точка — это точка, где соединяются 2 прямые линии под углом. 
  * Гладкая точка — это точка, где 2 ручки находятся на одной прямой линии, и сегменты этой линии соединяются плавной кривой. В этом случае все ручки отделены от опорной точки на равное расстояние. 
  * Прямая точка — это точка, где 2 ручки находятся на одной прямой линии, и сегменты этой линии соединяются плавной кривой. В этом случае ручки не обязательно отделены от опорной точки на равное расстояние. 
* Перемещая или редактируя опорные точки (что изменяет угол линий), вы можете изменить внешний вид формы. 

Чтобы редактировать формы PowerPoint через редактируемые точки, **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) представляет собой геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape). 
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths). 
* Чтобы установить `GeometryPath` для формы, вы можете использовать эти методы: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) для *сплошных форм* и [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) для *композитных форм*.
* Чтобы добавить сегменты, вы можете использовать методы под [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 
* Используя свойства [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) и [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), вы можете задать внешний вид для геометрического пути.
* Используя свойство [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata), вы можете получить геометрический путь `GeometryShape` как массив сегментов пути. 
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) в [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (из класса [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)), чтобы преобразовать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) в [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) и обратно. 

## **Простые операции редактирования**

Этот код C# показывает, как

**Добавить линию** в конец пути

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Добавить линию** в заданную позицию на пути:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Добавить кубическую кривую Безье** в конец пути:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Добавить кубическую кривую Безье** в указанную позицию на пути:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Добавить квадратичную кривую Безье** в конце пути:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Добавить квадратичную кривую Безье** в заданную позицию на пути:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Добавить заданную дугу** к пути:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Закрыть текущую фигуру** пути:

``` csharp
void CloseFigure();
```
**Установить позицию для следующей точки**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Удалить сегмент пути** по заданному индексу:

``` csharp
void RemoveAt(int index);
```

## **Добавить пользовательские точки к форме**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) и установите тип [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) из формы.
3. Добавьте новую точку между двумя верхними точками на пути.
4. Добавьте новую точку между двумя нижними точками на пути.
5. Примените путь к форме.

Этот код C# показывает, как добавить пользовательские точки к форме:

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

##  **Удалить точки из формы**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) и установите тип [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype). 
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) из формы.
3. Удалите сегмент пути.
4. Примените путь к форме.

Этот код C# показывает, как удалить точки из формы:

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

##  **Создать пользовательскую форму**

1. Рассчитайте точки для формы.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath). 
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape). 
5. Примените путь к форме.

Этот C# показывает, как создать пользовательскую форму:

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

## **Создать композитную пользовательскую форму**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
4. Примените пути к форме.

Этот код C# показывает, как создать композитную пользовательскую форму:

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

## **Создать пользовательскую форму с закруглёнными углами**

Этот код C# показывает, как создать пользовательскую форму с закруглёнными углами (внутрь);

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

## **Узнать, является ли геометрия формы закрытой**

Проверка того, является ли форма в презентации PowerPoint закрытой, может быть важна для корректного отображения и редактирования объектов на слайдах. Закрытая форма определяется как такая, у которой все стороны соединены, образуя одну границу без зазоров. Такая форма может быть простой геометрической фигурой или сложным пользовательским контуром.

Закрытость формы важна для выполнения различных операций, таких как заливка цветом или градиентом, применение эффектов и трансформаций, а также обеспечение корректного взаимодействия с другими элементами слайда.

Чтобы проверить, является ли геометрия формы закрытой, вам нужно сделать следующее:
1. Получите доступ к геометрии формы.
2. Перечислите геометрические пути в форме.
    2.1. Получите последний сегмент следующего пути.
    2.2. Проверьте, является ли последний сегмент командой `CLOSE`.

Следующий пример кода показывает, как это сделать:

```cs
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

## **Преобразовать GeometryPath в GraphicsPath (System.Drawing.Drawing2D)** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Создайте экземпляр класса [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) из пространства имен [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Преобразуйте экземпляр [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) в экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) с помощью [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. Примените пути к форме.

Этот код C# — реализация вышеуказанных шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:

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