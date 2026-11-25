---
title: Ограничить редактирование презентаций с помощью блокировок фигур в .NET
linktitle: Ограничить редактирование презентаций
type: docs
weight: 70
url: /ru/net/applying-protection-to-presentation/
keywords:
- предотвращение редактирования
- защита от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выбор
- блокировать изменение размеров
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в презентациях PPTX с помощью Aspose.Slides for .NET, чтобы ограничить выбор, перемещение, изменение размеров и группировку."
---
## **Фон**

Распространенный сценарий использования Aspose.Slides for .NET — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить предполагаемое размещение и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, OLE‑объекты, группированные фигуры, рамки изображений, видеокадры, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for .NET каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или наследующимся от класса, который его реализует.

Разные типы фигур предоставляют разные варианты блокировки. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) — базовый интерфейс для блокировок фигур. Aspose.Slides for .NET предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) — блокирует автофигуры.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) — блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) — блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) — блокирует групповые фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) — блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки на каждой поддерживаемой фигуре.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [presentation protection settings](/slides/ru/net/password-protected-presentation/).

### **Применить защиту к фигурам PPTX**

Aspose.Slides for .NET предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для работы с фигурами на слайде.

В примере устанавливаются свойства [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) и [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) = `true` для автофигур, а аналогичные блокировки — для групповых фигур, соединителей и рамок изображений. Для соединителей используется [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) — блокировка перемещения; группы также используют [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) — ограничение группировки.

Пример загружает существующую презентацию PPTX, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не попадающие в четыре обработанных типа, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Удалить защиту**

Чтобы снять блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размера через [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Также очищается [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) и сохраняется копия презентации. Остальные параметры блокировок остаются без изменений.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Сохранить обрезку изображения**

Поместите фотографию `photo.jpg` в рабочий каталог. Пример обрезает 12 % слева и 8 % справа, затем устанавливает [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) для рамки изображения. Этот флаг запрещает дальнейшую обрезку и сохраняет текущую обрезку.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` сохраняет блокировку обрезки со значением `true`. В PowerPoint команда **Crop** недоступна, когда изображение выбрано.

### **Сохранить группировку диаграммы**

Пример группирует прямоугольник и стрелку, затем устанавливает [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) для самой группы, чтобы удержать компоненты диаграммы вместе. Другие правки, такие как перемещение группы или изменение заливки компонента, остаются доступными.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` сохраняет блокировку разгруппировки со значением `true`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчёт о существующих блокировках фигур**

Чтобы изучить шаблон, откройте его и прочитайте объект блокировки каждой фигуры. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) = `true`, когда все флаги в этом объекте отключены, и `false`, когда включён хотя бы один. У группы и её дочерних элементов отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение для автофигур, рамок изображений и групп, обрезка для изображений и разгруппировка для групп. Выводятся распознанные флаги и помечаются типы фигур, которые не проверяются.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Допустим, слайд 1 презентации `Sample.pptx` содержит группу `Layout` с включённым `UngroupingLocked`, изображение `Photo` внутри группы с включённым `CropLocked` и разблокированный прямоугольник `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт читает сохранённые флаги редактирования на уровне фигур без их изменения или сохранения презентации. Защита записи на уровне документа — отдельная настройка, а применение каждого флага зависит от редактора.

### **Заключение**

Aspose.Slides for .NET позволяет ограничивать конкретные операции редактирования отдельных фигур или применять одинаковые ограничения ко всем слайдам. Выбирайте поддерживаемые каждой фигурой блокировки и устанавливайте их значения в `false`, когда необходимо снять ограничения.

## **FAQ**

**Можно ли комбинировать блокировки фигур и паролную защиту в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, тогда как [password protection](/slides/ru/net/password-protected-presentation/) может ограничивать открытие или изменение презентации. Оба метода можно использовать в одном файле.

**Можно ли ограничить редактирование только на определённых слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам выбранных слайдов. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдите по коллекции [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) группы и примените соответствующие блокировки к каждой дочерней фигуре. Повторите процесс для вложенных групп, следуя обходу, показанному в примере отчёта.