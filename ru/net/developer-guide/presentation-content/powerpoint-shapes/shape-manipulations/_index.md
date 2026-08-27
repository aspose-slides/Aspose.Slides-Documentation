---
title: Управление формами презентации в .NET
linktitle: Манипуляция формами
type: docs
weight: 40
url: /ru/net/shape-manipulations/
keywords:
- Форма PowerPoint
- Форма презентации
- Форма на слайде
- Поиск формы
- Клонирование формы
- Удаление формы
- Скрытие формы
- Изменение порядка форм
- Получение interop ID формы
- Альтернативный текст формы
- Точка регулировки формы
- Регулировка предустановленной формы
- Геометрия формы
- Форматы макета формы
- Форма в SVG
- Экспорт формы в SVG
- Выравнивание формы
- Отражение формы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать формы презентации с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/). Коллекция является как местом, где вы находите и изменяете фигуры, так и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала она объясняет, как надёжно определить фигуру и изменить предустановленные точки регулировки, затем показывает, как клонировать, удалять, скрывать и переупорядочивать фигуры. В завершающих разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые требуются вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры могут изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/name/) полезно для шаблонов, управляемых разработчиком, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать и они не гарантируют уникальность, поэтому при зависимости кода от них следует установить соглашение об именовании.
- [AlternativeText](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/alternativetext/) удобно, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или переписано для доступности и также не гарантирует уникальность. Не используйте осмысленный текст доступности в качестве ключа базы данных без явного согласования.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/officeinteropshapeid/) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный ориентир на протяжении жизни фигуры. Клонированная или заново созданная фигура — это другая фигура и получает собственный ID.

Связанное свойство [UniqueId](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/uniqueid/) имеет область действия презентации, но предназначено для надстроек и может быть переassigned. Его не следует рассматривать как постоянный внешний ключ. Если требуется долгосрочная идентичность, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по `Name` с ординарным сравнением и выводит ID interop, ограниченный слайдом. Когда шаблон не содержит ожидаемую фигуру, код сообщает об этом результате вместо продолжения с неверным объектом.

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

Когда операция специфична для типа фигуры, проверьте интерфейс перед использованием членов, специфичных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/).

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

## **Определение и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут предоставлять точки регулировки, управляющие такими особенностями, как размер угла, пропорции стрелки или угол дуги. Доступ к ним осуществляется через коллекцию только для чтения [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ru/net/aspose.slides/igeometryshape/adjustments/). Коллекция поставляется фигурой, но каждый [IAdjustValue](https://reference.aspose.com/slides/ru/net/aspose.slides/iadjustvalue/) содержит изменяемое значение.

Не полагайтесь исключительно на фиксированный индекс коллекции. Итеративно обходите регулировки и проверяйте только для чтения свойство [Type](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/type/), значение которого — [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/net/aspose.slides/shapeadjustmenttype/) — описывает, что регулирует данная настройка. Свойство только для чтения [Name](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/name/) предоставляет дополнительную информацию об идентификации и особенно полезно, когда в предустановке более одной регулировки с одинаковым семантическим типом.

Используйте свойство значения, соответствующее смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер скруглённого угла | [RawValue](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `RawValue` |
| `ArrowheadLength` | Длина наконечника стрелки | `RawValue` |
| `ArrowheadWidth` | Ширина наконечника стрелки | `RawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [AngleValue](https://reference.aspose.com/slides/ru/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Конечный угол сектора или дуги | `AngleValue` |

`Type` и `Name` назначить нельзя. `RawValue` — целое число чтение/запись в родных единицах геометрии предустановки, тогда как `AngleValue` — угол в градусах чтение/запись. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановки [ShapeType](https://reference.aspose.com/slides/ru/net/aspose.slides/igeometryshape/shapetype/). Значение, валидное для одной предустановки, может быть недопустимым или иметь иной эффект для другой.

Когда `Type` равно `ShapeAdjustmentType.Custom`, API не распознаёт стандартный семантический смысл. Проверьте `Name`, тип предустановки и текущее значение, оставляя регулировку без изменений, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверьте, не встречается ли один и тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/net/connector/) демонстрирует эту ситуацию с регулировками изгиба коннектора.

Следующий полный пример создаёт стандартные и модифицированные версии трёх предустановленных фигур. Он перебирает каждую регулировку, выводит её `Name` и `Type`, изменяет значения, связанные с размером, через `RawValue`, меняет углы через `AngleValue` и сохраняет результат. Левая колонка сохраняет геометрию по умолчанию; правая показывает откорректированный закруглённый прямоугольник, четырёхстрелку и сектор.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Добавляет заголовки для столбцов фигур по умолчанию и изменённых значений регулировки.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Проверка семантического типа перед изменением значения делает код явным в отношении его намерения и избегает предположения, что определённый индекс коллекции имеет одинаковый смысл в разных предустановленных фигурах.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией немедленно. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addclone/) создаёт независимую копию и добавляет её в целевую коллекцию. [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/insertclone/) также создаёт копию, но размещает её по указанному индексу Z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размера; перегрузки с шириной и высотой могут также изменить размер.

Пример создаёт целевой слайд, клонирует помеченный прямоугольник на передний план и вставляет второй клон в заднюю часть. Изменения любого из клонов не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, управляются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/remove/) удаляет конкретный объект фигуры из его коллекции. При удалении нескольких совпадений в ходе итерации по индексам обходите коллекцию с конца, чтобы каждый оставшийся индекс оставался валидным.

В этом примере удаляются все фигуры с определённым именем. Он читает `slide.Shapes[i]`, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

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

После удаления количество фигур и индексы последующих фигур изменяются. Ссылки на неизменённые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте коннекторы, анимацию и другие элементы презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/hidden/) в `true` оставляет фигуру в коллекции, но препятствует её отображению в обычном показе слайдов. Её индекс, форматирование и содержание остаются доступными коду, поэтому скрытие уместно для необязательных элементов, которые могут быть восстановлены позже.

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

Скрытие — не удаление и не защита. Объект всё ещё может быть обнаружен и сделан видимым пользователем или кодом, и остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры рисуются в порядке коллекции. [Reorder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `Count - 1` — передний.

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

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к последнему индексу помещает его спереди. Завершайте настройку Z‑порядка после добавления или клонирования всех связанных фигур, потому что эти операции добавляют или вставляют новые элементы коллекции и могут изменить желаемый стек.

## **Просмотр фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогичная позиция на обычном слайде. Просматривайте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример читает для каждой фигуры макета её [FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/fillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/lineformat/) без предположения, что каждая фигура является `AutoShape`.

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

Редактирование макета может затронуть несколько слайдов, использующих его. Прежде чем изменить фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и проверьте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/writeassvg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только эту фигуру, без фонового изображения всего слайда или соседних фигур.

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

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если требуется вся композиция, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и должна его освободить.

## **Выравнивание фигур**

Перегрузки [SlideUtil.AlignShapes](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/net/aspose.slides/shapesalignmenttype/) указывает край, центр или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; в `false` — чтобы выровнять выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Возвращаемые ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

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

Выравнивание изменяет позиции, а не Z‑порядок. Относительное выравнивание обычно требует как минимум двух фигур, в то время как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения промежутков. Перепроверьте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его значения `FlipH` и `FlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает его, а `NotDefined` сохраняет неустановленное/по‑умолчанию состояние.

Исходная презентация ниже содержит одну неотражённую фигуру.

![The shape before flipping](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только две настройки отражения. Это важно, поскольку присвоение нового [Frame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/frame/) заменяет полностью кадр.

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

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом сохраняет свою позицию, размер и вращение.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для краткосрочной обработки, когда коллекция не изменится до использования индекса. Для шаблонов, созданных вручную, предпочтительнее проверенная конвенция `Name` или `AlternativeText`, а для работы с interop — `OfficeInteropShapeId`.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно находить, переупорядочивать, редактировать или снова сделать видимой.

**Почему клонированная фигура оказалась спереди другой фигуры?**

`AddClone` добавляет клон в конец коллекции, что является передним слоем Z‑порядка. Используйте `InsertClone`, чтобы задать начальный индекс, или `Reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации предустановленной регулировки фигуры?**

Только после подтверждения точного типа предустановки и расположения коллекции. Предпочтительно обходить `IGeometryShape.Adjustments` и проверять `IAdjustValue.Type`; используйте `IAdjustValue.Name` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.