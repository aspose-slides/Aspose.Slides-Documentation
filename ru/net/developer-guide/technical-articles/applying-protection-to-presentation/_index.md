---
title: Предотвращение редактирования презентаций с помощью блокировки фигур в .NET
linktitle: Предотвращение редактирования презентаций
type: docs
weight: 70
url: /ru/net/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выбор
- блокировать размер
- блокировать группировку
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для .NET блокирует и разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая безопасность презентаций при разрешённом контролируемом редактировании."
---

## **Обзор**

Распространённое применение Aspose.Slides — создание, обновление и сохранение презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, имеют доступ к сгенерированным презентациям, поэтому защита от редактирования является актуальной проблемой. Важно, чтобы автоматически сгенерированные презентации сохраняли своё исходное форматирование и содержание.

В этой статье объясняется, как устроены презентации и слайды, а также как Aspose.Slides for .NET может применить защиту к презентации и позже её снять. Она предоставляет разработчикам способ контролировать использование презентаций, генерируемых их приложениями.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for .NET каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) или наследующим класс, реализующий этот интерфейс.

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать общий замок для всех типов фигур, разные типы фигур требуют разных замков. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) является общим классом блокировки для PPTX. В Aspose.Slides for .NET для PPTX поддерживаются следующие типы замков:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) блокирует фигуры‑соединители.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) блокирует сгруппированные фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Любое действие, выполненное над всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), применяется ко всей презентации.

## **Применение и удаление защиты**

Применение защиты гарантирует, что презентацию нельзя будет редактировать. Это полезный приём для защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for .NET предоставляет интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для работы с фигурами на слайде.

Как упоминалось ранее, каждый класс фигуры имеет соответствующий класс блокировки фигуры для защиты. В этой статье рассматриваются замки NoSelect, NoMove и NoResize. Эти замки гарантируют, что фигуры нельзя будет выбрать (щелчком мыши или другими методами выбора) и что их нельзя будет переместить или изменить их размер.

Пример кода ниже применяет защиту ко всем типам фигур в презентации.
```cs
// Создайте экземпляр класса Presentation, представляющего файл PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Перебор всех слайдов в презентации.
foreach (ISlide slide in presentation.Slides)
{
    // Перебор всех фигур на слайде.
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

// Сохранение файла презентации.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **Снять защиту**

Чтобы разблокировать фигуру, установите значение соответствующего замка в `false`. Приведённый ниже пример кода показывает, как разблокировать фигуры в заблокированной презентации.
```cs
// Создать экземпляр класса Presentation, представляющего файл PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Перебор всех слайдов в презентации.
foreach (ISlide slide in presentation.Slides)
{
    // Перебор всех фигур на слайде.
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

// Сохранение файла презентации.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **Заключение**

Aspose.Slides предоставляет несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, чтобы эффективно защитить весь файл. Защиту можно снять, установив значение замка в `false`.

## **FAQ**

**Можно ли сочетать блокировку фигур и защиту паролем в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, тогда как [защита паролем](/slides/ru/net/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Можно ли ограничить редактирование на отдельных слайдах, не влияя на остальные?**

Да. Применяйте блокировки к фигурам на выбранных слайдах; остальные слайды останутся редактируемыми.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Для групп, соединителей, графических объектов и других типов фигур поддерживаются отдельные типы блокировок.