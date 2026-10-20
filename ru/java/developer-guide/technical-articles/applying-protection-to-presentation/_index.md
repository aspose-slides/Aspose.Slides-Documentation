---
title: Ограничение редактирования презентаций с помощью блокировок фигур в Java
linktitle: Ограничение редактирования презентаций
type: docs
weight: 60
url: /ru/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Фон**

Обычное применение Aspose.Slides for Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманную компоновку и содержимое.

В этой статье объясняется, как фигуры упорядочены на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования для отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, OLE‑объекты, группы фигур, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Java каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) или наследующим класс, реализующий его.

Разные типы фигур предоставляют разные варианты блокировок. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) является базовым для блокировок фигур. Aspose.Slides for Java предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) блокирует автофигуры.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) блокирует группы фигур.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки к [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), пройдитесь по её слайдам и задайте соответствующие блокировки каждому поддерживаемому типу фигур.

## **Применение и удаление защиты**

Блокировки фигур ограничивают такие операции, как выбор, перемещение и изменение размера фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к объектам PPTX**

Aspose.Slides for Java предоставляет интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) и [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) со значением `true` для автофигур, аналогичные блокировки применяются к группам, соединителям и рамкам изображений. Для соединителей используется [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по вложенным фигурам внутри группы.

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

Чтобы снять блокировку с фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и снимаются ограничения выбора, перемещения и изменения размера через [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Также удаляется ограничение группировки путем передачи `false` в [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) и сохраняется копия презентации. Другие настройки блокировок остаются без изменения.

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

Aspose.Slides for Java позволяет ограничивать конкретные операции редактирования для отдельных фигур или применять одинаковые ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые конкретным типом фигуры, и устанавливайте их значение в `false`, когда необходимо снять ограничения.

## **Часто задаваемые вопросы**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, тогда как [password protection](/slides/ru/java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба механизма в одном файле.

**Могу ли я ограничить редактирование только на определённых слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Итерируйте коллекцию, возвращаемую методом группы [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) и задавайте соответствующие блокировки каждой дочерней фигуре. Повторите процесс для вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки отдельным членам группы.