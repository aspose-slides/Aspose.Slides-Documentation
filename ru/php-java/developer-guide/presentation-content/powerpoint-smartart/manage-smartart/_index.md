---
title: Управление SmartArt в презентациях PowerPoint с помощью PHP
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/php-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- свойство скрытия
- организационная схема
- организационная схема с изображением
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Научитесь создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for PHP via Java, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for PHP via Java вы можете создавать SmartArt, получать текст из его узлов, изменять макет, проверять скрытые узлы, настраивать макеты организационных схем и создавать организационные схемы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы считать текст из фигур узла, пройдите по [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), затем прочитайте [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), возвращаемый через [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Пример требует презентацию, содержащую хотя бы один слайд, и объект SmartArt в качестве первой формы на этом слайде. Он выводит каждый доступный текстовый кадр в консоль.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt управляет расположением и связями узлов. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он изменяется на значение `BasicProcess` и сохраняется презентация. Позиция и размер, передаваемые в [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/), измеряются в пунктах. Для изменения макета используйте [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Проверить, скрыт ли узел SmartArt**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут существовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`, добавляется узел, после чего проверяется его состояние скрытия. При обнаружении скрытого узла выводится сообщение, а диаграмма сохраняется.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить или задать макет организационной схемы**

Для диаграмм SmartArt, использующих макет организационной схемы, методы [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) и [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) определяют расположение дочерних узлов относительно родительского узла. Например, вы можете задать подвешивание дочерних узлов слева, справа или с обеих сторон, используя тип [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная схема и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Индекс `0` (нумерация с нуля) выбирает первый узел верхнего уровня; его дочерние узлы используют выбранное расположение. Затем изменённая презентация сохраняется.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Создать организационную схему с изображениями**

Организационная схема с изображениями — это макет SmartArt, предназначенный для иерархических диаграмм с размещением изображений. При добавлении объекта SmartArt на слайд используйте тип [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с заполнителями изображений; заполнители не заполняются изображениями.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Преобразовать устаревшие диаграммы в группы фигур**

При модернизации существующей презентации может потребоваться обновить организационную схему, созданную в PowerPoint 97–2003. Aspose.Slides представляет такие устаревшие диаграммы как объекты [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Используйте [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/), чтобы преобразовать диаграмму в группу фигур, что позволяет редактировать отдельные визуальные элементы. Подробности см. в [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур, не удаляя исходную диаграмму. После успешного преобразования удалите оригинал с помощью [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/), чтобы избежать дублирования содержимого. Сначала соберите устаревшие диаграммы в список, а затем преобразуйте их, чтобы добавление и удаление фигур не нарушало итерацию.

В следующем примере открывается презентация, выполняется поиск по каждому слайду, диаграммы преобразуются в группы фигур, и обновлённая презентация сохраняется в формате PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оригинальных диаграмм рядом с ними. Откройте PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или позиция.

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или обратный порядок для RTL‑языков?**

Да. Метод [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратный порядок.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/php-java/shape-manipulations/) с помощью [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/php-java/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрисовать SmartArt в растровое изображение для превью или веб‑экспорта?**

[Отрисуйте слайд](/slides/ru/php-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отрисовывается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Используйте [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) или [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/), чтобы задать отличающийся альтернативный текст или имя форме SmartArt, выполните поиск этого значения в [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), а затем проверьте, что найденная форма является [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).