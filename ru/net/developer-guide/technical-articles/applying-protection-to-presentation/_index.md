---
title: Запрет редактирования презентации с помощью блокировки фигур
linktitle: Запрет редактирования презентации
type: docs
weight: 70
url: /ru/net/applying-protection-to-presentation/
keywords:
- запрет редактирования
- защита от редактирования
- блокировка фигуры
- блокировка позиции
- блокировка выбора
- блокировка размера
- блокировка группировки
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for .NET блокирует и разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая безопасность презентаций, позволяя контролировать редактирование и ускоряя доставку."
---

## **Предыстория**

Aspose.Slides часто используется для создания, обновления и сохранения презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, имеют доступ к сгенерированным презентациям, поэтому защита их от редактирования является распространённой проблемой. Важно, чтобы автоматически создаваемые презентации сохраняли исходное форматирование и содержание.

В этой статье объясняется, как построены презентации и слайды, а также как Aspose.Slides for .NET может применить защиту к презентации и позже её снять. Статья предоставляет разработчикам способ контролировать использование презентаций, создаваемых их приложениями.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные объекты, рамки изображений, видеорамки, соединители и другие элементы, используемые при создании презентации. В Aspose.Slides for .NET каждый элемент на слайде представляется объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или наследующим класс, реализующий его.

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать общий замок для всех типов фигур, разные типы фигур требуют разных замков. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) является общим классом блокировки для PPTX. В Aspose.Slides for .NET для PPTX поддерживаются следующие типы замков:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) блокирует группы фигур.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Любое действие, выполненное над всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), применяется ко всей презентации.

## **Применение и снятие защиты**

Применение защиты гарантирует, что презентацию нельзя отредактировать. Это полезный приём для защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for .NET предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для работы с фигурами на слайде.

Как упоминалось ранее, каждый класс фигуры имеет соответствующий класс блокировки для защиты. В этой статье рассматриваются замки NoSelect, NoMove и NoResize. Эти замки гарантируют, что фигуры нельзя выбрать (щелчком мыши или другими способами) и что их нельзя перемещать или изменять их размер.

Ниже приведён пример кода, который применяет защиту ко всем типам фигур в презентации.
```cs
// Создайте объект класса Presentation, который представляет файл PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Перебираем все слайды в презентации.
foreach (ISlide slide in presentation.Slides)
{
    // Перебираем все фигуры на слайде.
    foreach (IShape shape in slide.Shapes)
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

// Сохраняем файл презентации.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **Снять защиту**

Чтобы разблокировать фигуру, установите значение соответствующего замка в `false`. Ниже приведён пример кода, показывающий, как разблокировать фигуры в заблокированной презентации.
```cs
// Создайте объект класса Presentation, который представляет файл PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Перебираем все слайды в презентации.
foreach (ISlide slide in presentation.Slides)
{
    // Перебираем все фигуры на слайде.
    foreach (IShape shape in slide.Shapes)
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

// Сохраняем файл презентации.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **Заключение**

Aspose.Slides предлагает несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, эффективно защищая весь файл. Защиту можно снять, установив значение замка в `false`.

## **FAQ**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, в то время как [защита паролем](/slides/ru/net/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Примените блокировки к фигурам на выбранных слайдах; остальные слайды останутся доступными для редактирования.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Для групп, соединителей, графических объектов и других типов фигур поддерживаются специальные типы блокировок.