---
title: Настройка фигур презентаций в .NET
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/net/custom-shape/
keywords:
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
- геометрический путь
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для .NET: геометрические пути, скруглённые углы, составные фигуры."
---

## **Изменить форму с помощью точек редактирования**

Рассмотрим квадрат. В PowerPoint, используя **точки редактирования**, вы можете

* переместить угол квадрата внутрь или наружу
* указать кривизну для угла или точки
* добавить новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные действия с любой фигурой. С помощью точек редактирования вы можете изменять форму или создавать новую форму из существующей.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать фигуры PowerPoint с помощью точек редактирования, вам может быть полезно учесть следующие моменты о фигурах:

* Фигура (или её контур) может быть закрытой или открытой.
* Все фигуры состоят минимум из 2 якорных точек, соединённых линиями.
* Линия может быть прямой или изогнутой. Якорные точки определяют характер линии. 
* Якорные точки бывают угловыми, прямыми или плавными:
  * Угловая точка — это точка, где два прямых отрезка соединяются под углом. 
  * Плавная точка — это точка, где два рычага находятся на одной прямой и сегменты линии соединяются в плавную кривую. В этом случае все рычаги находятся на одинаковом расстоянии от якорной точки. 
  * Прямая точка — это точка, где два рычага находятся на одной прямой и сегменты этой линии соединяются в плавную кривую. В этом случае рычаги не обязаны находиться на одинаковом расстоянии от якорной точки. 
* Перемещая или редактируя якорные точки (что изменяет угол линий), вы можете изменить внешний вид фигуры. 

Для редактирования фигур PowerPoint с помощью точек редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) представляет геометрический контур объекта [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Чтобы установить `GeometryPath` для фигуры, вы можете использовать следующие методы: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) для *сплошных фигур* и [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) для *композитных фигур*.
* Для добавления сегментов вы можете использовать методы из [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).
* Используя свойства [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) и [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), вы можете задать внешний вид геометрического контура.
* С помощью свойства [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) можно получить геометрический контур `GeometryShape` в виде массива сегментов контура.
* Чтобы получить дополнительные параметры настройки геометрии фигур, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) в [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (из класса [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) для преобразования [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) в [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) и обратно. 

## **Простые операции редактирования**

Этот код C# показывает, как

**Добавить линию** в конец контура
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Добавить линию** в указанную позицию контура:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**Добавить кубическую кривую Безье** в конец контура:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Добавить кубическую кривую Безье** в указанную позицию контура:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**Добавить квадратичную кривую Безье** в конец контура:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Добавить квадратичную кривую Безье** в указанную позицию контура:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**Добавить заданную дугу** к контуру:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Замкнуть текущую фигуру** контура:
``` csharp
void CloseFigure();
```

**Установить позицию для следующей точки**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Удалить сегмент контура** по заданному индексу:
``` csharp
void RemoveAt(int index);
```


## **Добавить пользовательские точки к фигуре**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) и задайте тип [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) из фигуры.
3. Добавьте новую точку между двумя верхними точками контура.
4. Добавьте новую точку между двумя нижними точками контура.
5. Примените контур к фигуре.

Этот код C# показывает, как добавить пользовательские точки к фигуре:
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

##  **Удалить точки из фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) и задайте тип [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) из фигуры.
3. Удалите сегмент контура.
4. Примените контур к фигуре.

Этот код C# показывает, как удалить точки из фигуры:
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

##  **Создать пользовательскую фигуру**

1. Вычислите точки для фигуры.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Заполните контур точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
5. Примените контур к фигуре.

Этот код C# показывает, как создать пользовательскую фигуру:
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

## **Создать составную пользовательскую фигуру**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
4. Примените контуры к фигуре.

Этот код C# показывает, как создать составную пользовательскую фигуру:
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

## **Создать пользовательскую фигуру со скруглёнными углами**

Этот код C# показывает, как создать пользовательскую фигуру со скруглёнными углами (внутрь);
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


## **Узнать, закрыта ли геометрия фигуры**

Закрытая фигура определяется как фигура, у которой все стороны соединены, образуя единую границу без разрывов. Такая фигура может быть простой геометрической формой или сложным пользовательским контуром. Приведённый пример кода показывает, как проверить, закрыта ли геометрия фигуры:
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


## **Преобразовать GeometryPath в GraphicsPath (System.Drawing.Drawing2D)** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Создайте экземпляр класса [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) из пространства имён [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Преобразуйте экземпляр [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) в экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) с помощью [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. Примените контуры к фигуре.

Этот код C# — реализация указанных выше шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
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

## **FAQ**

**Что произойдёт с заливкой и контурами после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контуры автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую фигуру вместе с её геометрией?**

Используйте свойство [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) фигуры; геометрия вращается вместе с фигурой, так как привязана к её собственной системе координат.

**Могу ли я преобразовать пользовательскую фигуру в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте нужную область [слайда](/slides/ru/net/convert-powerpoint-to-png/) или саму [фигуру](/slides/ru/net/create-shape-thumbnails/) в растровый формат; это упрощает последующую работу с тяжёлыми геометриями.