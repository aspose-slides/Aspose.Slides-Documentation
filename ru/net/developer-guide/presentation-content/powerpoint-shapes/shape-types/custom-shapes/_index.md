---
title: Настройка форм презентаций в .NET
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/net/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
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
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для .NET: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

В этой статье объясняется, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии к форме.

Также продемонстрировано, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, является ли геометрия формы замкнутой, и использовать устаревшее преобразование между [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) для дополнительных сценариев настройки геометрии.

## **Изменение формы с помощью точек редактирования**

В PowerPoint можно использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменить контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint имейте в виду следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из опорных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Опорные точки и управляющие рукоятки определяют его форму.
* Опорные точки существуют в виде угловых точек, прямых точек или плавных точек:
  * В угловой точке соединяющие её сегменты могут встречаться под углом.
  * В плавной точке две управляющие рукоятки выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке две управляющие рукоятки выровнены, но могут иметь разное расстояние от опорной точки.
* Перемещение опорных точек или настройка их рукояток изменяет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) представляет собой путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), можно воспользоваться методом [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) для формы, используйте методы: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) для форм с одним путём и [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) для форм с несколькими путями.
* Чтобы добавить сегменты, используйте методы из [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* С помощью свойств [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) и [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) можно задать внешний вид пути геометрии.
* Через свойство [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) в виде массива сегментов пути.
* В наследуемых версиях, поддерживающих указанные ниже методы преобразования, можно конвертировать [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) в [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Используйте методы [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) и [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (из класса [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) для преобразования между [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) и [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Установить начальную точку фигуры. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Удалить сегмент по индексу (нумерация с нуля). | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Добавление пользовательских точек к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) и применяется отредактированный путь через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Координаты относятся к локальной системе формы: обе новые точки находятся в её центре, на 100 пунктов от левой границы и 50 пунктов от верхней. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, притягивая эти края внутрь.

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

## **Удаление точек из формы**

В этом примере меняется контур формы в виде сердца, удаляя сегмент с индексом 2 (нумерация с нуля) с помощью [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Применение изменённого пути через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) обновляет контур формы.

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

## **Создание пользовательской формы**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов задают вершины и выемки; шаг в 72 градуса равномерно распределяет пять вершин. Путь замыкается методом [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) и применяется к прямоугольной форме через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), заменяя её контур.

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

## **Создание составной пользовательской формы**

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) создаёт одну составную форму с разрывом в средней трети.

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

## **Создание пользовательской формы со скруглёнными углами**

В этом примере прямые сегменты комбинируются с [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) для создания формы со внутрёно‑изогнутыми углами. Каждый размер угла задаёт ширину и высоту дуги в пунктах, а разворот ‑90 градусов рисует дугу против часовой стрелки — четверть эллипса. Завершённый путь применяется через [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), и презентация сохраняется в формате PPTX.

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

## **Определение, является ли геометрия формы замкнутой**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она читает [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) и сравнивает последнюю команду сегмента [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) с [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Функция возвращает false, если нет непустых путей. Проверяется только конечная команда каждого пути; отдельные подфигуры внутри пути не анализируются. Пример выводит `True` для прямоугольника.

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

## **Исследование команд пути геометрии**

Скачайте [contour.pptx](contour.pptx) и поместите его в рабочий каталог приложения. На первом слайде находится форма с прямым верхним краем, кубической кривой Безье и прямым замыкающим краем. Используйте [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) для чтения её путей. Каждый путь перечисляет свои сегменты в порядке рисования в свойстве [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Команда [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) каждого сегмента определяет, как читать его [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

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

Форма расположена в точке (200, 100) пунктов на слайде. Сообщаемые точки локальны для формы, при этом (0, 0) находится в её левом верхнем углу, ось X растёт вправо, а ось Y — вниз. Замыкающий сегмент возвращается к стартовой точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Извлечение и исследование элементов формы**

Используйте [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) для получения существующей формы в виде элементов, содержащих точки пути и типы точек. Приведите каждый возвращённый [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) к типу [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) для чтения его массивов [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) и [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Такое представление удобно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается презентация, находят первую форму геометрии непосредственно на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

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
        var pointType = types[i] & 0x07; // Сохранить тип сегмента, исключая флаги.
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
                i += 2; // Потреблять обе контрольные точки и конечную точку.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Массивы соответствуют по индексу: `points[i]` — точка, а `types[i]` описывает её роль. Тип `0` начинает фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кусок кубической Безье начинается в предыдущей конечной точке и использует три подряд идущих типа `3`: две управляющие точки и новую конечную точку. Цикл обрабатывает эти три записи совместно и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` позволяет определить тип сегмента, а отдельная проверка `0x80` обнаруживает закрытый подпуть. Например, `129` (`0x81`) означает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую его. Сравнение сырого значения только с `1` или `3` упустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), ось X растёт вправо, ось Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают её позиции [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) и [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/), а также текущие ширину и высоту. Например, несмещённый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её невращённого кадра.

Извлечённые точки не учитывают свойства [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) формы и горизонтальные/вертикальные отражения. Чтобы восстановить отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте отображение координат группы и её преобразования; не предполагайте, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштабирование дважды, если они уже учтены в кадре дочерней формы.

**Исследование vs редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет исходную форму. Используйте этот подход, когда ваш анализ или код рисования требуют массивов точек/типов. Применяйте [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/), когда нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) или [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Преобразование GeometryPath в GraphicsPath (System.Drawing.Drawing2D)**

Следующий пример требует устаревшей сборки Aspose.Slides for .NET, поддерживающей [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), например версии 25.10, и Windows‑окружения с `System.Drawing.Common`. Методы преобразования были удалены в [версии 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

В примере комбинируется прямоугольный контур с текстом, преобразованным в геометрию. Свойство [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) контура отключает заливку. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) хранит контур текста, который [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) преобразует в заполненный путь геометрии. Применение обоих путей через [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) создаёт одну форму, содержащую прямоугольник и текст. Для обратного преобразования используйте [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

**Что произойдёт с заливкой и контурами после замены геометрии?**

Стиль сохраняется у формы; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Используйте свойство [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) формы; геометрия поворачивается вместе с формой, поскольку привязана к её собственной системе координат.

**Могу ли я преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте требуемую [slide](/slides/ru/net/convert-powerpoint-to-png/) область или саму [shape](/slides/ru/net/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу со сложными геометриями.