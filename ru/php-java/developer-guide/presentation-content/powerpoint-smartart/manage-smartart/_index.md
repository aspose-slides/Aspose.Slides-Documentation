---
title: Управление SmartArt в презентациях PowerPoint с помощью PHP
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/php-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная схема
- Организационная схема с изображениями
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for PHP via Java, используя понятные примеры кода, ускоряющие дизайн слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, построенная из узлов, форм узлов и макета. С помощью Aspose.Slides for PHP via Java вы можете создавать SmartArt, считывать текст из его узлов, менять макет, просматривать скрытые узлы, настраивать макеты организационных схем и создавать организационные схемы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, пройдите по всем узлам с помощью [SmartArt::getAllNodes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/#getAllNodes), затем получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/), возвращаемый методом [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы размещаются и соединяются. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и презентация сохраняется.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Проверить, скрыт ли узел SmartArt**

Метод [SmartArtNode::isHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartnode/ishidden/) сообщает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`, добавляется узел и проверяется состояние его скрытости.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить или задать макет организационной схемы**

Для диаграмм SmartArt, использующих макет организационной схемы, методы [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) и [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) определяют, как дочерние узлы располагаются относительно родительского узла. Например, можно установить, чтобы дочерние узлы «висели» слева, справа или с обеих сторон, в зависимости от выбранного типа [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная схема и для первого узла устанавливается значение макета [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Создать организационную схему с изображениями**

Организационная схема с изображениями — это макет SmartArt, предназначенный для иерархических диаграмм, содержащих заполнители изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркалирование или инвертирование для RTL‑языков?**

Да. Метод [SmartArt::setReversed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы слева направо на справа налево (и обратно), если выбранный макет SmartArt поддерживает обратный порядок.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Можно [клонировать форму SmartArt](/slides/ru/php-java/shape-manipulations/) с помощью [ShapeCollection::addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/php-java/clone-slides/), содержащий SmartArt. Оба метода сохраняют размер, положение и форматирование.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/php-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt будет отрендерен как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Задайте уникальное значение свойств [Shape::getAlternativeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getalternativetext/) или [Shape::getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getname/) для формы SmartArt, выполните поиск этого значения через [BaseSlide::getShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getShapes) и проверьте, что найденная форма является [SmartArt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/).