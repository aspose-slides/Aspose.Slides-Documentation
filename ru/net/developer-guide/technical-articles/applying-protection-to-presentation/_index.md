---
title: Ограничение редактирования презентаций с помощью блокировок фигур в .NET
linktitle: Ограничить редактирование презентаций
type: docs
weight: 70
url: /ru/net/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защита от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выбор
- блокировать изменение размера
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX-презентациях с помощью Aspose.Slides for .NET, чтобы ограничить выбор, перемещение, изменение размеров и группировку."
---
## **Обзор**

Распространённое применение Aspose.Slides for .NET — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить предполагаемое расположение и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования для отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из таких компонентов, как автофигуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеорamки, соединители и другие элементы, используемые при создании презентации. В Aspose.Slides for .NET каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или наследующим класс, который его реализует.

Разные типы фигур предоставляют различные варианты блокировок. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) является базовым интерфейсом для блокировок фигур. Aspose.Slides for .NET предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) блокирует автофигуры.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) блокирует сгруппированные фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки к всей [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Блокировки фигур ограничивают операции, такие как выбор, перемещение и изменение размера фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к фигурам PPTX**

Aspose.Slides for .NET предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для работы с фигурами на слайде.

В примере свойства [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) и [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) устанавливаются в `true` для автофигур, аналогичные блокировки применяются к сгруппированным фигурам, соединителям и рамкам изображений. Соединители используют [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) для перемещения; группы также используют [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) для ограничения группировки.

В примере загружается существующая PPTX‑презентация, проверяются фигуры в коллекции фигур каждого слайда и сохраняется копия с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

### **Удаление защиты**

Чтобы снять блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размера с помощью [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), и [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Также сбрасывается [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) и сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

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

### **Заключение**

Aspose.Slides for .NET позволяет ограничить определённые операции редактирования отдельных фигур или применить одинаковые ограничения ко всем слайдам. Выберите блокировки, поддерживаемые типом каждой фигуры, и установите их значения в `false`, когда необходимо снять эти ограничения.

## **FAQ**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, тогда как [защиту паролем](/slides/ru/net/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Могу ли я ограничить редактирование на конкретных слайдах, не влияя на остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдите по коллекции [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) группы и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки для отдельных элементов группы.