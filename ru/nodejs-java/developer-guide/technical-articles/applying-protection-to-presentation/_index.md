---
title: Ограничить редактирование презентаций с помощью блокировок фигур в Node.js
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/nodejs-java/applying-protection-to-presentation/
keywords:
- предотвращение редактирования
- защита от редактирования
- блокировка фигуры
- блокировка положения
- блокировка выбора
- блокировка изменения размера
- блокировка группировки
- PowerPoint
- PPTX
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в презентациях PPTX с помощью Aspose.Slides for Node.js via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Обзор**

Распространённое применение Aspose.Slides for Node.js via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают эти презентации, ограничение изменений фигур может помочь сохранить задний макет и содержание.

Эта статья объясняет, как фигурки организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничивать определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автовставки, таблицы, объекты OLE, группы фигур, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Node.js via Java каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Разные типы фигур предоставляют разные параметры блокировки. Класс [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Node.js via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) блокирует автовставки.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) блокирует группы фигур.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Блокировки фигур ограничивают операции, такие как выбор, перемещение и изменение размера фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Node.js via Java предоставляет класс [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `true` для автовставок, а также эквивалентные блокировки для групп фигур, соединителей и рамок изображений. Для соединителей используется [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обработанным типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Удаление защиты**

Чтобы удалить блокировку фигуры, установите её значение в `false`. Ниже приведён пример, который загружает презентацию с блокировками фигур и снимает ограничения выбора, перемещения и изменения размера через [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Он также удаляет ограничение группировки, передавая `false` в [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), и сохраняет копию презентации. Другие настройки блокировок остаются без изменений.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Заключение**

Aspose.Slides for Node.js via Java позволяет ограничивать определённые операции редактирования отдельных фигур или применять одинаковые ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые типом каждой фигуры, и устанавливайте их значения в `false`, когда необходимо снять ограничения.

## **FAQ**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, тогда как [защита паролем](/slides/ru/nodejs-java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Итерируйте коллекцию, возвращаемую методом группы [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes), и применяйте соответствующие блокировки к каждой дочерней фигуре. Повторяйте процесс для любых вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки отдельным членам группы.