---
title: Ограничение редактирования презентаций с помощью блокировок фигур в PHP
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/php-java/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- блокировать фигуру
- блокировать положение
- блокировать выбор
- блокировать изменение размера
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for PHP via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Обзор**

Распространённое применение Aspose.Slides for PHP via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур может помочь сохранить предполагаемое расположение и содержание.

Эта статья объясняет, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничивать определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, объекты OLE, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for PHP via Java каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Разные типы фигур предоставляют разные варианты блокировки. Класс [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for PHP via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) блокирует сгруппированные фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применить и удалить защиту**

Блокировки фигур ограничивают такие операции, как выбор, перемещение и изменение размера фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for PHP via Java предоставляет класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `true` для автоконтуров, а также аналогичные блокировки для сгруппированных фигур, соединителей и рамок изображений. Для соединителей используется [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; для групп также используется [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked), чтобы ограничить группировку.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не входящие в четыре обработанных типа, остаются без изменений. Цикл не обходит дочерние фигуры внутри группы.

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

### **Удалить защиту**

Чтобы удалить блокировку фигуры, установите её значение в `false`. Ниже приведён пример, который загружает презентацию с блокировками фигур и снимает ограничения выбора, перемещения и изменения размера через [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Он также снимает ограничение группировки, передав `false` в [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked), и сохраняет копию презентации. Другие настройки блокировок остаются без изменений.

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

### **Заключение**

Aspose.Slides for PHP via Java позволяет ограничивать конкретные операции редактирования отдельных фигур или применять те же ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые типом фигуры, и устанавливайте их значения в `false`, когда необходимо снять ограничения.

## **Часто задаваемые вопросы**

**Могу ли я комбинировать блокировки фигур и парольную защиту в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, тогда как [парольная защита](/slides/ru/php-java/password-protected-presentation/) может ограничить открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Могу ли я ограничить редактирование на отдельных слайдах без влияния на остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдите по коллекции, возвращаемой методом [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) группы, и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для всех вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки для отдельных членов группы.