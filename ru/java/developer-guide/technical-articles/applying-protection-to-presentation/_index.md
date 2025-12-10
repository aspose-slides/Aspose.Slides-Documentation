---
title: Предотвращение редактирования презентаций с помощью блокировок фигур
linktitle: Предотвращение редактирования презентаций
type: docs
weight: 60
url: /ru/java/applying-protection-to-presentation/
keywords:
- предотвращение редактирования
- защита от редактирования
- блокировка фигуры
- блокировка положения
- блокировка выбора
- блокировка размера
- блокировка группировки
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Java блокирует или разблокирует фигуры в файлах PPT, PPTX и ODP, защищая презентации и позволяя контролировать редактирование и ускорять поставку."
---

## **Предыстория**

Распространённое применение Aspose.Slides — создание, обновление и сохранение презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, имеют доступ к сгенерированным презентациям, поэтому защита их от редактирования является актуальной задачей. Важно, чтобы автоматически созданные презентации сохраняли исходное форматирование и содержимое.

В этой статье объясняется, как устроены презентации и слайды, а также как Aspose.Slides for Java может применить защиту к презентации и впоследствии снять её. Это даёт разработчикам возможность контролировать использование презентаций, генерируемых их приложениями.

## **Составляющие слайда**

Слайд презентации состоит из таких компонентов, как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеокадры, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Java каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) или наследующим класс, реализующий его.

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать общий замок для всех типов фигур, различные типы фигур требуют разных замков. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) является универсальным классом блокировки для PPTX. В Aspose.Slides for Java для PPTX поддерживаются следующие типы замков:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) блокирует группы фигур.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Любое действие, выполненное со всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), применяется ко всей презентации.

## **Применение и снятие защиты**

Применение защиты гарантирует, что презентацию нельзя редактировать. Это полезный приём для защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for Java предоставляет интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для работы с фигурами на слайде.

Как упомянуто ранее, каждый класс фигуры имеет сопутствующий класс‑замок для защиты. В этой статье рассматриваются блокировки NoSelect, NoMove и NoResize. Эти замки гарантируют, что фигуры нельзя выбрать (кликнув мышью или другими способами) и что их нельзя перемещать или изменять размер.

Пример кода ниже применяет защиту ко всем типам фигур в презентации.
```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Перебор всех слайдов в презентации.
for (ISlide slide : presentation.getSlides()) {

    // Перебор всех фигур на слайде.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Приведение типа фигуры к автоконтурной и получение её блокировки.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Приведение типа фигуры к группе фигур и получение её блокировки.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Приведение типа фигуры к соединителю и получение её блокировки.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Приведение типа фигуры к рамке изображения и получение её блокировки.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Сохранение файла презентации.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Снять защиту**

Чтобы разблокировать фигуру, установите значение соответствующего замка в `false`. Следующий пример кода показывает, как разблокировать фигуры в защищённой презентации.
```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Перебор всех слайдов в презентации.
for (ISlide slide : presentation.getSlides()) {

    // Перебор всех фигур на слайде.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Приведение типа фигуры к автоконтурной и получение её блокировки.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Приведение типа фигуры к группе фигур и получение её блокировки.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Приведение типа фигуры к соединителю и получение её блокировки.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Приведение типа фигуры к рамке изображения и получение её блокировки.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Сохранение файла презентации.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Заключение**

Aspose.Slides предлагает несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, эффективно защищая весь файл. Защиту можно снять, установив значение замка в `false`.

## **FAQ**

**Можно ли сочетать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, тогда как [password protection](/slides/ru/java/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Можно ли ограничить редактирование отдельных слайдов, не влияя на остальные?**

Да. Применяйте блокировки к фигурам на выбранных слайдах; остальные слайды останутся редактируемыми.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Для групп, соединителей, графических объектов и других типов фигур поддерживаются специальные типы блокировок.