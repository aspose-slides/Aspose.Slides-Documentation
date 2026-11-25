---
title: Ограничить редактирование презентаций с помощью блокировок фигур в PHP
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for PHP via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Обзор**

Распространённое использование Aspose.Slides for PHP via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур может помочь сохранить предполагаемое расположение и содержание.

Эта статья объясняет, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить конкретные операции редактирования для отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, объекты OLE, сгруппированные фигуры, кадры изображений, видеокадры, соединители и другие элементы, используемые при создании презентации. В Aspose.Slides for PHP via Java каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Разные типы фигур предоставляют разные параметры блокировки. Класс [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for PHP via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) блокирует автофигуры.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) блокирует сгруппированные фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) блокирует кадры изображений.  

Чтобы применить блокировки к каждому слайду в [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), пройдитесь по его слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа — отдельные [настройки защиты презентации](/slides/ru/php-java/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for PHP via Java предоставляет класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `true` для автофигур, а также эквивалентные блокировки для сгруппированных фигур, соединителей и кадров изображений. Для перемещения соединители используют [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove); группы также используют [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группировки.

Пример загружает существующую презентацию PPTX, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Удаление защиты**

Чтобы удалить блокировку фигуры, установите её значение в `false`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размеров через [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Также удаляется ограничение группировки, передавая `false` в [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked), после чего сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Сохранение обрезки изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. Пример обрезает 12 % слева и 8 % справа, затем вызывает [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) для блокировки кадра изображения. Установка `true` ограничивает дальнейшую обрезку и сохраняет существующую обрезку.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` сохраняет блокировку обрезки как `true`. В PowerPoint команда **Crop** отключена, когда выбран фото.

### **Сохранение диаграммы сгруппированной**

Пример группирует прямоугольник и стрелку, затем вызывает [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) для блокировки разгруппировки, чтобы компоненты диаграммы оставались вместе. Другие редактирования, такие как перемещение группы или изменение заливки компонента, остаются доступными.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` сохраняет блокировку разгруппировки как `true`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчет о существующих блокировках фигур**

Чтобы проанализировать шаблон, откройте его и прочитайте объект блокировки для каждой фигуры. Метод [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) возвращает `true`, когда все флаги в этом объекте отключены, и `false`, если хотя бы один включён. У группы и её дочерних элементов свои объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

Этот пример проверяет перемещение для автофигур, кадров изображений и групп. Он также проверяет обрезку для изображений и разгруппировку для групп. Отчёт перечисляет включённые флаги, которые он распознаёт, и помечает типы фигур, которые он не проверяет.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Предположим, что слайд 1 файла `Sample.pptx` содержит группу с именем `Layout`, у которой включена блокировка разгруппировки, изображение с именем `Photo` внутри неё с блокировкой обрезки и разблокированный прямоугольник с именем `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт читает сохранённые флаги редактирования на уровне фигур без их изменения или сохранения презентации. Защита записи на уровне документа — отдельный параметр, а применение каждого флага зависит от редактора.

## **Заключение**

Aspose.Slides for PHP via Java позволяет ограничить конкретные операции редактирования для отдельных фигур или применить одинаковые ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые типом каждой фигуры, и устанавливайте их значения в `false`, когда необходимо снять ограничения.

## **FAQ**

**Могу ли я сочетать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, а [защита паролем](/slides/ru/php-java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Могу ли я ограничить редактирование только на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) группы, и примените соответствующие блокировки к каждой дочерней фигуре. Повторите процесс для вложенных групп, следуя обходу, показанному в примере отчёта.