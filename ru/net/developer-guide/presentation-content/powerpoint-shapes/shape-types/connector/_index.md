---
title: Управление соединителями в презентациях на .NET
linktitle: Соединитель
type: docs
weight: 10
url: /ru/net/connector/
keywords:
- соединитель
- тип соединителя
- точка соединителя
- линия соединителя
- угол соединителя
- точка соединения
- точка регулировки
- соединять фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять, присоединять, переопределять маршрут, регулировать и исследовать прямые, изгибные и изогнутые соединители PowerPoint с помощью Aspose.Slides для .NET."
---
## **Обзор**

Соединитель — это линия, которая может оставаться прикреплённой к двум фигурам, когда любая из фигур перемещается. Его концы привязываются к точкам соединения, отображаемым зелёными точками в PowerPoint. Некоторые изогнутые и изгибные соединители также имеют точки регулировки, отображаемые оранжевыми точками, которые управляют положением отдельных сегментов соединителя.

Aspose.Slides представляет соединители через интерфейс [IConnector](https://reference.aspose.com/slides/ru/net/aspose.slides/iconnector/). Вы можете создавать их, привязывать их концы к фигурам, выбирать точки соединения, переопределять их маршрут и изменять геометрию соединителей, имеющих точки регулировки.

## **Типы соединителей**

Перечисление [ShapeType](https://reference.aspose.com/slides/ru/net/aspose.slides/shapetype/) включает предустановки прямых, изгибных и изогнутых соединителей. В таблице ниже показаны доступные геометрии соединителей и количество точек регулировки, определяемое каждой предустановкой.

| Соединитель | Изображение | Количество точек регулировки |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Количество и назначение точек регулировки являются частью выбранной предустановки соединителя. Не следует предполагать, что два разных типа соединителей используют одинаковую структуру коллекции.

## **Соединение двух фигур**

Для добавления соединителя используйте [IShapeCollection.AddConnector](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addconnector/) и задайте свойства [StartShapeConnectedTo](https://reference.aspose.com/slides/ru/net/aspose.slides/connector/startshapeconnectedto/) и [EndShapeConnectedTo](https://reference.aspose.com/slides/ru/net/aspose.slides/connector/endshapeconnectedto/). После того как оба конца будут прикреплены, метод [IConnector.Reroute](https://reference.aspose.com/slides/ru/net/aspose.slides/iconnector/reroute/) выбирает короткий маршрут между фигурами.

В следующем примере соединяется эллипс и прямоугольник изгибным соединителем:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

Вызов `Reroute` может изменить значения [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/net/aspose.slides/connector/startshapeconnectionsiteindex/) и [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/net/aspose.slides/connector/endshapeconnectionsiteindex/). После переопределения маршрута присвойте конкретные точки соединения, если они должны оставаться фиксированными.

{{% /alert %}}

## **Выбор точки соединения**

Каждая соединяемая фигура сообщает количество доступных точек через [ConnectionSiteCount](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/connectionsitecount/). Перед тем как присвоить точку соединения концу соединителя, проверьте, что выбранный нулевой индекс находится в допустимом диапазоне; количество точек различается в зависимости от геометрии фигуры.

В этом примере соединитель привязывается к конкретной точке на эллипсе, если такая точка существует:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Регулировка точки соединителя**

Соединители с точками регулировки раскрывают их через [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ru/net/aspose.slides/igeometryshape/adjustments/). Перед изменением значения проверьте каждый [IAdjustValue](https://reference.aspose.com/slides/ru/net/aspose.slides/iadjustvalue/) и его [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/type/). Общие правила идентификации предустановленных регулировок фигур описаны в разделе [Shape Manipulation](/slides/ru/net/shape-manipulations/).

Количество, порядок, назначение и допустимый диапазон значений регулировок зависят от предустановки соединителя. Свойство `Type` только для чтения, а значение регулировки можно записать. Свойство только для чтения [Name](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/name/) дает дополнительную идентификацию, когда у соединителя более одной регулировки с одинаковым семантическим типом.

### **Обход препятствия**

На следующем макете соединитель `BentConnector5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт такой соединитель:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Перемещение вертикального изгиба меняет маршрут так, что соединитель обход

![connector-obstruction-fixed](connector-obstruction-fixed.png)

вместо препятствия:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо предположения, что индекс коллекции `1` всегда соответствует вертикальному изгибу, данный пример ищет `ConnectorBendPositionY` и изменяет его только тогда, когда присутствует ожидаемый семантический тип:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

У `BentConnector5` два регулирования `ConnectorBendPositionX` и одно `ConnectorBendPositionY`. Если нужный тип встречается более одного раза, проверьте `Name` и известную геометрию предустановки перед выбором. Если регулирование имеет тип `ShapeAdjustmentType.Custom`, рассматривайте его значение и диапазон как специфичные для предустановки и не меняйте его, пока не будет известен соответствующий контракт.

## **Связь значений регулировки с геометрией соединителя**

Для изгибных соединителей значения регулировок можно использовать для оценки положения отдельных сегментов. Эти вычисления зависят от предустановки соединителя:

- `BentConnector4` обычно предоставляет одну регулировку `ConnectorBendPositionX` и одну `ConnectorBendPositionY`.
- Для этих позиций `RawValue / 100000f` даёт долю ширины или высоты кадра соединителя, используемую в примерах ниже.
- Кадр соединителя может быть повернут или отражён, поэтому координаты кадра необходимо преобразовать перед сравнением с координатами слайда.

В следующих примерах сначала используется `Type` для идентификации регулировок. Индексы коллекции не рассматриваются как переносимые идентификаторы.

### **Не повернутый соединитель**

Исходный макет содержит две текстовые фигуры, соединённые `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример проверяет соединитель и получает его горизонтальные и вертикальные регулировки изгиба:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

В результате получаем соединитель, у которого горизонтальный и вертикальный сегменты сместились:

![connector-adjusted-1](connector-adjusted-1.png)

После того как семантические типы известны, их значения можно преобразовать в координаты кадра соединителя. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, управляемым двумя регулировками изгиба:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Фигура‑направляющая отмечает рассчитанный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый соединитель**

Когда та же геометрия соединителя ориентирована вертикально, её свойства [Frame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/ru/net/aspose.slides/shapeframe/fliph/) и [FlipV](https://reference.aspose.com/slides/ru/net/aspose.slides/shapeframe/flipv/) влияют на преобразование координат кадра соединителя в координаты слайда.

Этот пример создаёт и регулирует вертикально ориентированный соединитель:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Отрегулированный соединитель отображается вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла вращения `alpha` поворачиваем точку кадра соединителя `(x, y)` вокруг центра кадра `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает ориентацию 90°, использованную в примере, и рисует красную направляющую над соответствующим сегментом соединителя:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Красная направляющая отмечает рассчитанный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель соединителя. Перед применением тех же вычислений к другой предустановке проверьте типы регулировок, ориентацию кадра и диапазоны значений.

## **Определение угла направления соединителя**

Направление прямого соединителя можно вычислить из его ширины и высоты с учётом горизонтального и вертикального отражения. В следующем примере выводится угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **FAQ**

**Как узнать, может ли соединитель быть прикреплён к фигуре?**

Проверьте значение `ConnectionSiteCount` у фигуры. Положительное значение означает, что фигура предоставляет точки соединения. Перед присвоением индекса проверьте его корректность.

**Можно ли определить регулировку соединителя по индексу в коллекции?**

Индекс имеет смысл только для известной предустановки соединителя и известного расположения коллекции. Проверяйте `IAdjustValue.Type` перед изменением значения и используйте `IAdjustValue.Name` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.

**Что происходит, когда соединённая фигура удаляется?**

Соответствующий конец соединителя открепляется. Соединитель остаётся на слайде и может быть удалён, перемещён как свободная линия или прикреплён к другой фигуре.

**Сохраняются ли привязки соединителей при копировании слайда?**

Привязки обычно сохраняются, когда копируются соединённые фигуры вместе со слайдом. Если соединитель копируется без одной из целевых фигур, необходимо заново прикрепить затронутый конец.