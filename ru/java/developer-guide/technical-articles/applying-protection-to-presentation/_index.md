---
title: Ограничение редактирования презентаций с помощью блокировок фигур в Java
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX-презентациях с помощью Aspose.Slides для Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Общие сведения**

Распространённое применение Aspose.Slides for Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманную раскладку и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничивать определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, объекты OLE, сгруппированные фигуры, рамки изображений, видеокадры, соединительные линии и другие элементы, используемые для построения презентации. В Aspose.Slides for Java каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) или наследующимся от класса, реализующего его.

Разные типы фигур предоставляют разные варианты блокировок. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) является базовым интерфейсом для блокировок фигур. Aspose.Slides for Java предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) — блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) — блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) — блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) — блокирует групповые фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) — блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), пройдитесь по её слайдам и задайте соответствующие блокировки каждой поддерживаемой фигуре.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа — это отдельные [presentation protection settings](/slides/ru/java/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Java предоставляет интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) и [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) со значением `true` для автоконтуров, а также эквивалентные блокировки для групповых фигур, соединителей и рамок изображений. Для соединителей используется [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) — разрешение перемещения; для групп — [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) — ограничение группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обработанным типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

Чтобы снять блокировку фигуры, задайте её значение `false`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размера через [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Также снимается ограничение группировки, передавая `false` в [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), и сохраняется копия презентации. Другие настройки блокировок остаются без изменений.

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

### **Сохранение обрезки изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. Пример обрезает 12 % слева и 8 % справа, затем вызывает [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) у блокировки рамки изображения. Передача `true` запрещает дальнейшую обрезку и сохраняет текущую обрезку.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` сохраняет блокировку обрезки как `true`. В PowerPoint команда **Crop** отключена, когда выбранное изображение.

### **Сохранение группы диаграммы**

Пример группирует прямоугольник и стрелку, затем вызывает [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) у блокировки группы, чтобы удержать компоненты диаграммы вместе. Другие операции, такие как перемещение группы или изменение заливки компонента, остаются доступными.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` сохраняет блокировку разгруппировки как `true`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчет о существующих блокировках фигур**

Чтобы просмотреть шаблон, откройте его и прочитайте объект блокировки для каждой фигуры. Метод [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) возвращает `true`, когда все флаги в этом объекте отключены, и `false`, когда включён хотя бы один. У группы и её дочерних элементов есть отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение автоконтуров, рамок изображений и групп. Также проверяется обрезка изображений и разгруппировка групп. Отчёт перечисляет включённые флаги, которые он распознаёт, и помечает типы фигур, которые он не проверяет.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Предположим, что слайд 1 файла `Sample.pptx` содержит группу с именем `Layout`, у которой запрещена разгруппировка, внутри неё фотографию `Photo` с запрещённой обрезкой и разблокированный прямоугольник `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт читает сохранённые флаги редактирования на уровне фигур без их изменения или сохранения презентации. Защита записи на уровне документа — отдельная настройка, а применение каждого флага зависит от редактора.

### **Вывод**

Aspose.Slides for Java позволяет ограничивать конкретные операции редактирования отдельных фигур или применять те же ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые конкретным типом фигуры, и устанавливайте их значения в `false`, когда необходимо снять ограничения.

## **FAQ**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, тогда как [password protection](/slides/ru/java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать обе возможности в одном файле.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом группы [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--), и примените соответствующие блокировки к каждой дочерней фигуре. Повторяйте процесс для всех вложенных групп, следуя обходу, показанному в примере отчёта.