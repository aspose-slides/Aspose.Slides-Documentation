---
title: Управление фигурами презентации в .NET
linktitle: Манипулирование фигурами
type: docs
weight: 40
url: /ru/net/shape-manipulations/
keywords:
- фигура PowerPoint
- фигура презентации
- фигура на слайде
- поиск фигуры
- клонирование фигуры
- удаление фигуры
- скрытие фигуры
- изменение порядка фигур
- получение интероп ID фигуры
- альтернативный текст фигуры
- форматы макета фигуры
- фигура как SVG
- фигура в SVG
- выравнивание фигуры
- отражение фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как идентифицировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/). Коллекция одновременно является местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала она объясняет, как надёжно идентифицировать фигуру, затем показывает, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование уровня макета, экспорт в SVG, выравнивание и параметры отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются устойчивыми идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/name/) полезно для шаблонов, контролируемых разработчиком, и его легко просмотреть в панели выбора PowerPoint. Имена можно редактировать, они не гарантированно уникальны, поэтому установите конвенцию именования, если код от них зависит.
- [AlternativeText](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/alternativetext/) удобно, когда доступное описание или метка автора уже идентифицируют фигуру. Текст видим пользователям, может быть локализован или переписан для доступности и также не гарантирует уникальности. Не используйте значимый текст доступности в качестве ключа базы данных без явного согласования.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/officeinteropshapeid/) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий идентификатору фигуры, используемому в interop PowerPoint. Применяйте его при интеграции с PowerPoint или когда нужен однозначный объект в течение жизни фигуры. Клонированная или воссозданная фигура — это другая фигура с собственным идентификатором.

Связанное свойство [UniqueId](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/uniqueid/) имеет область действия презентации, но предназначено для надстроек и может быть переназначено. Не рассматривайте его как постоянный внешний ключ. Если требуется долговременная идентификация, храните сопоставление во внешних данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по `Name` с ординарным сравнением и сообщает межоперационный ID уровня слайда. Когда шаблон не содержит ожидаемой фигуры, код выводит этот результат вместо продолжения работы с неверным объектом.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Когда операция специфична для типа фигуры, проверьте интерфейс перед использованием членов, характерных для типа. Пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания воздействуют на коллекцию немедленно. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, полученные до этой операции.

### **Клонирование фигуры**

[AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/insertclone/) также создаёт копию, но размещает её по указанному индексу z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения размеров; перегрузки с шириной и высотой могут изменить размер.

Пример создаёт слайд‑назначение, клонирует помеченный прямоугольник в переднюю часть и вставляет второй клон в заднюю часть. Изменения любого клона не затрагивают исходную фигуру.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обслуживает презентация, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений в ходе обхода по индексам, перебирайте элементы с конца, чтобы каждый оставшийся индекс оставался валидным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает `slide.Shapes[i]`, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

После удаления меняются количество фигур и индексы последующих фигур. Ссылки на незатронутые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимации и другие элементы презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/hidden/) в `true` оставляет фигуру в коллекции, но препятствует её отображению в обычном показе слайдов. Её индекс, форматирование и содержание остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Скрытие — не удаление и не защита. Объект всё ещё может быть найден и расскрыт пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение порядка наложения**

Наложенные фигуры отрисовываются в порядке коллекции. [Reorder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `Count - 1` — передний.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Сначала создаётся прямоугольник, который изначально находится за эллипсом. Перемещение его к конечному индексу помещает его спереди. Завершайте упорядочивание после добавления или клонирования всех связанных фигур, потому что эти операции добавляют новые элементы в коллекцию и могут изменить предполагаемый стек.

## **Проверка фигур на макетных слайдах**

Обычные слайды, макетные слайды и мастер‑слайды имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Проверяйте фигуры макета, когда нужно понять или изменить форматирование, поставляемое макетом.

Следующий пример читает у каждой фигуры макета её [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/fillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/lineformat/) без предположения, что каждая фигура является `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Редактирование макета может затронуть несколько слайдов, использующих его. Прежде чем менять фигуру макета, определите, наследует её обычный слайд или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/writeassvg/) записывает отрендеренное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не весь фон слайда или соседние фигуры.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и должна его освободить.

## **Выровнять фигуры**

Перегрузки [SlideUtil.AlignShapes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/net/aspose.slides/shapesalignmenttype/) задаёт край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Выравнивание меняет позиции, а не порядок наложения. Относительное выравнивание обычно требует как минимум две фигуры, а горизонтальное или вертикальное распределение — достаточного количества фигур для определения промежутков. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отразить фигуру**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `FlipH` и `FlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает, а `NotDefined` сохраняет неуказанное/значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что присвоение нового [Frame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/frame/) заменяет весь кадр.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом её позиция, размер и вращение остаются без изменений.

![Фигура после отражения](flipped_shape.png)

## **Вопросы и ответы**

**Должен ли я использовать индекс коллекции в качестве идентификатора фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенную конвенцию `Name` или `AlternativeText` для шаблонов, либо `OfficeInteropShapeId` для межоперационных задач в пределах слайда.

**Удаляет ли скрытие фигуры её из порядка наложения?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клон фигуры появился перед другой фигурой?**

`AddClone` добавляет клон в конец коллекции, что соответствует переднему краю z‑порядка. Используйте `InsertClone`, чтобы задать начальный индекс, или `Reorder` после добавления всех фигур.