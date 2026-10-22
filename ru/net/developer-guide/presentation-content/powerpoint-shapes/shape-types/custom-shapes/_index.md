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
- путь геометрии
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
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для .NET: пути геометрии, скруглённые углы, составные фигуры."
---
## **Обзор**

Эта статья объясняет, как настраивать фигуры презентаций в Aspose.Slides путем редактирования геометрии фигур через точки редактирования и пути геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) для изменения существующих фигур, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии к фигуре.

Также демонстрируется, как создавать пользовательские и составные фигуры, строить фигуры со скруглёнными углами, определять, закрыта ли геометрия фигуры, и использовать устаревшее преобразование между [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) для дополнительных сценариев настройки геометрии.

## **Изменение фигуры с помощью точек редактирования**

В PowerPoint можно использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур фигуры или использовать существующую фигуру в качестве основы для новой.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

При редактировании фигур PowerPoint учитывайте следующие концепции:

* Фигура (или её путь) может быть закрытой или открытой.
* Путь фигуры состоит из контрольных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Контрольные точки и ручки управления определяют его форму.
* Контрольные точки бывают угловыми, прямыми или гладкими:
  * В угловой точке смежные сегменты могут соединяться под углом.
  * В гладкой точке две ручки управления выровнены и находятся на одинаковом расстоянии от контрольной точки.
  * В прямой точке две ручки управления выровнены, но могут находиться на разном расстоянии от контрольной точки.
* Перемещение контрольных точек или изменение их ручек меняет контур фигуры.

Для редактирования фигур PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) представляет путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), можно использовать метод [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) для фигуры, можно использовать методы: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) для фигур с одним путем и [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) для фигур с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* С помощью свойств [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) и [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) можно задать внешний вид пути геометрии.
* Свойство [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) позволяет получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) в виде массива сегментов пути.
* В устаревших версиях, поддерживающих методы конвертации, можно преобразовать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) в [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (из класса [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) для преобразования между [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Простые операции редактирования**

Используйте перечисленные методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в позицию с нулевым базовым индексов в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавление или вставка прямой линии. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Добавление или вставка кубической кривой Безье с двумя контрольными точками и конечной точкой. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Добавление или вставка квадратичной кривой Безье с одной контрольной точкой и конечной точкой. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Добавление эллиптической дуги с указанными размерами и углами в градусах. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Замыкание текущей фигуры соединением её конечной точки с начальной. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Установка начальной точки фигуры. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Удаление сегмента по нулевому базовому индексу. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Добавление пользовательских точек к фигуре**

Этот пример вставляет две точки в прямоугольную фигуру с помощью [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) и применяет отредактированный путь с помощью [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Координаты локальны для фигуры: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, притягивая эти края внутрь.

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

## **Удаление точек из фигуры**

Этот пример изменяет контур в виде сердца, удаляя сегмент с нулевым базовым индексом 2 с помощью [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Применение изменённого пути через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) обновляет контур фигуры.

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

## **Создание пользовательской фигуры**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и впадины; шаг 72 градуса равномерно распределяет пять вершин. Путь замыкается с помощью [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) и применяется к прямоугольной фигуре через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), заменяя её контур.

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

## **Создание составной пользовательской фигуры**

В этом примере определяются два закрытых [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) для верхней и нижней трети фигуры. Применение обоих путей через [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) создаёт одну составную фигуру с разрывом в средней трети.

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
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Создание пользовательской фигуры со скруглёнными углами**

Этот пример комбинирует прямые сегменты с [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) для создания фигуры со скруглёнными внутреннями углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а sweep -90 градус записывает против часовой стрелки четверть эллипса. Завершённый путь применяется через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), а презентация сохраняется в формате PPTX.

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

## **Определение, закрыта ли геометрия фигуры**

Следующий вспомогательный метод проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Он читает [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) и сравнивает конечный сегмент’s [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) с [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Проверка осуществляется только по финальной команде каждого пути; субфигуры внутри пути не просматриваются. Пример выводит `True` для прямоугольника.

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

## **Извлечение и инспекция элементов фигуры**

Используйте [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) для инспекции существующей фигуры как набора элементов, содержащих точки пути и типы точек. Приведите каждый возвращённый [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) к типу [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) для чтения его массивов [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) и [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Такое представление удобно для анализа контура или передачи геометрии пользовательским инструментам рисования.

Пример открывает презентацию, находит первую геометрическую фигуру непосредственно на первом слайде и выводит её сегменты пути. Используйте презентацию, содержащую фигуру с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

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
        var pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
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

Массивы сопоставляются по индексу: `points[i]` — точка, `types[i]` — её роль. Тип `0` начинается фигура, тип `1` — линия от предыдущей точки к текущей. Кубический сегмент Безье начинается в предыдущей конечной точке и использует три последовательных типа `3`: два контрольных пункта и новую конечную точку. Цикл обрабатывает эти три записи вместе и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` выделяет тип сегмента, а `0x80` проверяется отдельно для обнаружения закрытого подпотока. Например, `129` (`0x81`) означает конечную точку линии, закрывающую подпоток, а `131` (`0x83`) — конечную точку Безье, закрывающую подпоток. Сравнение «сырого» значения только с `1` или `3` упустит такие случаи. Другие флаги, такие как тире (`0x10`) и маркер (`0x20`), базовый тип сегмента не меняют.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для не сгруппированной фигуры извлечённые координаты уже включают её [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) и отражают текущую ширину и высоту. Например, не вращённый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию фигуры повторно. Вычтите её X и Y, чтобы получить координаты относительно её ненавёрнутой рамки.

Извлечённые точки не учитывают [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) фигуры и горизонтальное/вертикальное отражения. Чтобы восстановить отображаемый контур, примените эти преобразования вокруг центра фигуры. Для сгруппированных фигур также учитывайте преобразования координат группы; не предполагайте, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштаб дважды, если они уже учтены в рамке дочернего объекта.

**Инспекция против редактирования.** Извлечённые массивы описывают контур; их изменение не обновит оригинальную фигуру. Выбирайте такой подход, когда нужен анализ точек/типов или пользовательский код рисования. Используйте [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/), когда нужны команды геометрии в локальной системе координат фигуры или требуется редактировать её геометрию. Применяйте отредактированные пути через [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) или [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Преобразование GeometryPath в GraphicsPath (System.Drawing.Drawing2D)**

Следующий пример требует устаревшей сборки Aspose.Slides for .NET, поддерживающей [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), например версии 25.10, и Windows‑окружения с `System.Drawing.Common`. Методы конвертации были удалены в [версии 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Пример комбинирует прямоугольный контур с текстом, преобразованным в геометрию. Для контура устанавливается [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) — отключён заливка. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) хранит контур текста, который [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) преобразует в заполненный путь геометрии. Применение обеих фигур через [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) создаёт одну фигуру, содержащую прямоугольник и текст. Для обратного преобразования используйте [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

## **FAQ**

**Что происходит с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую фигуру совместно с её геометрией?**

Используйте свойство [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) фигуры; геометрия вращается вместе с фигурой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужный [slide](/slides/ru/net/convert-powerpoint-to-png/) или саму [shape](/slides/ru/net/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.