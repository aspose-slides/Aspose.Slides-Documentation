---
title: Ограничение редактирования презентаций с помощью блокировок фигур в Node.js
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/nodejs-java/applying-protection-to-presentation/
keywords:
- предотвращать редактирование
- защищать от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выделение
- блокировать изменение размеров
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX-презентациях с помощью Aspose.Slides for Node.js via Java, чтобы ограничить выделение, перемещение, изменение размеров и группировку."
---
## **Обзор**

Обычное применение Aspose.Slides for Node.js via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматического процесса. Когда пользователи получают эти презентации, ограничение изменений фигур может помочь сохранить предполагаемое расположение и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, кадры изображений, видеокадры, соединители и другие элементы, используемые для создания презентации. В Aspose.Slides for Node.js via Java каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Разные типы фигур предоставляют разные варианты блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Node.js via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) блокирует сгруппированные фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) блокирует кадры изображений.  

Чтобы применить блокировки к всей [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), пройдитесь по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [настройки защиты презентации](/slides/ru/nodejs-java/password-protected-presentation/) .

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Node.js via Java предоставляет класс [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `true` для автоконтуров, аналогичные блокировки применяются к сгруппированным фигурам, соединителям и кадрам изображений. Соединители используют [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группирования.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

Чтобы удалить блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размеров посредством [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Также ограничение группировки удаляется, передавая `false` в [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), и сохраняется копия презентации. Другие настройки блокировок остаются без изменений.

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

### **Сохранение обрезки изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. В примере обрезается 12 % слева и 8 % справа, затем вызывается [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) у блокировки кадра изображения. Передача `true` ограничивает дальнейшую обрезку и сохраняет существующую обрезку.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` сохраняет блокировку обрезки как `true`. В PowerPoint команда **Crop** отключена, когда фотография выбрана.

### **Сохранение диаграммы в группе**

В примере прямоугольник и стрелка объединяются в группу, затем вызывается [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) у блокировки группы, чтобы сохранить компоненты диаграммы вместе. Другие правки, такие как перемещение группы или изменение заливки компонента, остаются доступными.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` сохраняет блокировку разгруппировки как `true`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчёт о существующих блокировках фигур**

Чтобы просмотреть шаблон, откройте его и прочитайте объект блокировки для каждой фигуры. Метод [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) возвращает `true`, когда все флаги в этом объекте отключены, и `false`, когда хотя бы один включён. У группы и её дочерних элементов есть отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение автоконтуров, кадров изображений и групп. Также проверяется обрезка изображений и разгруппировка групп. Отчёт перечисляет включённые флаги, которые он распознаёт, и помечает типы фигур, которые он не проверяет.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Предположим, что слайд 1 в `Sample.pptx` содержит группу под названием `Layout` с заблокированной разгруппировкой, изображение под названием `Photo` внутри неё с заблокированной обрезкой и разблокированный прямоугольник под названием `Free`. Отчёт пропускает `Free` и выводит две следующие строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт считывает сохранённые флаги редактирования на уровне фигур, не изменяя их и не сохраняя презентацию. Защита записи на уровне документа является отдельной настройкой, и применение каждого флага зависит от редактора.

### **Заключение**

Aspose.Slides for Node.js via Java позволяет ограничивать определённые операции редактирования отдельных фигур или применять одни и те же ограничения к нескольким слайдам. Выбирайте блокировки, поддерживаемые каждым типом фигур, и устанавливайте их значения в `false`, когда требуется снять ограничения.

## **FAQ**

**Можно ли комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, в то время как [защита паролем](/slides/ru/nodejs-java/password-protected-presentation/) может ограничить открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Можно ли ограничить редактирование на конкретных слайдах, не затрагивая другие?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдите по коллекции, возвращаемой методом группы [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes), и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для всех вложенных групп, следуя обходу, показанному в примере отчёта.