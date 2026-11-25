---
title: Ограничить редактирование презентаций с блокировками фигур на Android
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/androidjava/applying-protection-to-presentation/
keywords:
- предотвращать редактирование
- защищать от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выбор
- блокировать изменение размера
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for Android via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Обзор**

Распространённое применение Aspose.Slides for Android via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманное расположение и содержание.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировку фигур в презентации PPTX. Эти блокировки позволяют ограничить конкретные операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, объекты OLE, группированные фигуры, рамки изображений, видеокадры, соединители и другие элементы, используемые для создания презентации. В Aspose.Slides for Android via Java каждый элемент на слайде представлен объектом, реализующим интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) или наследующим класс, реализующий его.

Разные типы фигур предоставляют разные варианты блокировок. Интерфейс [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) является базовым для блокировок фигур. Aspose.Slides for Android via Java предоставляет следующие интерфейсы блокировок:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) блокирует автоконтуры.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) блокирует соединительные фигуры.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) блокирует графические объекты.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) блокирует групповые фигуры.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [presentation protection settings](/slides/ru/androidjava/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Android via Java предоставляет интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) и [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) со значением `true` для автоконтуров, а также аналогичные блокировки для групповых фигур, соединителей и рамок изображений. Соединители используют [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не попадающие в четыре рассматриваемых типа, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

Чтобы снять блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и снимаются ограничения выбора, перемещения и изменения размеров через [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) и [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Также снимается ограничение группировки, передавая `false` в [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), и сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

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

Поместите фотографию с именем `photo.jpg` в рабочий каталог. Пример обрезает 12 % слева и 8 % справа, затем вызывает [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) у блокировки рамки изображения. Установка `true` ограничивает дальнейшую обрезку и сохраняет существующую обрезку.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` сохраняет блокировку обрезки со значением `true`. В PowerPoint команда **Crop** отключена, когда изображение выбрано.

### **Сохранение группировки диаграммы**

Пример группирует прямоугольник и стрелку, затем вызывает [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) у блокировки группы, чтобы сохранить компоненты диаграммы вместе. Другие правки, такие как перемещение группы или изменение заливки компонента, остаются доступными.

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

`DiagramLocked.pptx` сохраняет блокировку разгруппировки со значением `true`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчет о существующих блокировках фигур**

Чтобы просмотреть шаблон, откройте его и прочитайте объект блокировки для каждой фигуры. Метод [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) возвращает `true`, когда все флаги в этом объекте отключены, и `false`, когда хотя бы один включён. У группы и её дочерних элементов есть отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение автоконтуров, рамок изображений и групп. Также проверяется обрезка изображений и разгруппировка групп. Отчёт перечисляет включённые флаги, которые он распознаёт, и отмечает типы фигур, которые он не проверяет.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

Предположим, что слайд 1 файла `Sample.pptx` содержит группу с именем `Layout`, у которой заблокирована разгруппировка, изображение `Photo` внутри неё с заблокированной обрезкой и разблокированный прямоугольник `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт читает сохранённые флаги редактирования на уровне фигур без их изменения и без сохранения презентации. Защита записи на уровне документа — отдельная настройка, а применение каждого флага зависит от редактора.

### **Заключение**

Aspose.Slides for Android via Java позволяет ограничить конкретные операции редактирования отдельных фигур или применить одинаковые ограничения ко всей презентации. Выбирайте поддерживаемые каждой фигурой блокировки и устанавливайте их значения в `false`, когда требуется снять ограничения.

## **Вопросы и ответы**

**Могу ли я совместить блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, а [защиту паролем](/slides/ru/androidjava/password-protected-presentation/) может ограничить открытие или изменение презентации. Вы можете использовать оба варианта в одном файле.

**Могу ли я ограничить редактирование конкретных слайдов без влияния на остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на других слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Итерируйте коллекцию, возвращаемую методом группы [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--), и применяйте соответствующие блокировки к каждой дочерней фигуре. Повторяйте процесс для любых вложенных групп, следуя обходу, показанному в примере отчёта.