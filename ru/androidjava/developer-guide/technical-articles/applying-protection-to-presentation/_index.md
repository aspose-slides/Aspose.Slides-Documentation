---
title: Ограничьте редактирование презентаций с помощью блокировок фигур на Android
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/androidjava/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- заблокировать фигуру
- заблокировать позицию
- заблокировать выбор
- заблокировать изменение размера
- заблокировать группировку
- PowerPoint
- PPTX
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в презентациях PPTX с помощью Aspose.Slides для Android через Java, чтобы ограничить выбор, перемещение, изменение размеров и группировку."
---
## **Обзор**

Обычным применением Aspose.Slides for Android via Java является создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур может помочь сохранить предполагаемую компоновку и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, кадры изображения, видеокадры, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Android via Java каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) или наследующим класс, его реализующий.

Разные типы фигур предоставляют различные варианты блокировок. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) является базовым интерфейсом для блокировок фигур. Aspose.Slides for Android via Java предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) блокирует сгруппированные фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) блокирует кадры изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), переберите её слайды и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Блокировки фигур ограничивают операции, такие как выбор, перемещение и изменение размеров фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к объектам PPTX**

В Aspose.Slides for Android via Java предоставляется интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) и [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) со значением `true` для автоконтуров, с аналогичными блокировками для сгруппированных фигур, соединителей и кадров изображений. Соединители используют [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) чтобы ограничить группировку.

Пример загружает существующую презентацию PPTX, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём рассматриваемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Удаление защиты**

Чтобы удалить блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и снимаются ограничения выбора, перемещения и изменения размеров через [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Также удаляется ограничение группировки, передавая `false` методу [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), и сохраняется копия презентации. Другие настройки блокировок остаются без изменений.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Заключение**

Aspose.Slides for Android via Java позволяет ограничивать определённые операции редактирования отдельных фигур или применять те же ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые каждым типом фигур, и устанавливайте их значения в `false`, когда необходимо снять эти ограничения.

## **Часто задаваемые вопросы**

**Можно ли сочетать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, тогда как [защита паролем](/slides/ru/androidjava/password-protected-presentation/) может ограничить открытие или изменение презентации. Оба механизма можно использовать в одном файле.

**Можно ли ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Переберите коллекцию, возвращаемую методом [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) группы, и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для всех вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки для отдельных членов группы.