---
title: Управляйте SmartArt в презентациях PowerPoint с помощью JavaScript
linktitle: Управляйте SmartArt
type: docs
weight: 10
url: /ru/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- свойство скрытия
- организационная диаграмма
- организационная диаграмма с изображением
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Node.js, используя понятные примеры кода на JavaScript, которые ускоряют разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Node.js via Java вы можете создавать SmartArt, читать текст из его узлов, изменять его макет, просматривать скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

## **Получение текста из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, пройдитесь по [SmartArt.getAllNodes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/#getAllNodes--), затем прочитайте [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/), возвращаемый [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Изменение типа макета объекта SmartArt**

Макет SmartArt определяет, как узлы размещаются и соединяются. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он изменяется на значение `BasicProcess` и сохраняется презентация.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверка, скрыт ли узел SmartArt**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartnode/ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут существовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`, и проверяется состояние скрытия узла.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получение или установка макета организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, методы [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) и [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) определяют, как дочерние узлы располагаются под родительским узлом. Например, вы можете установить, чтобы дочерние узлы висели слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и задаётся макет для первого узла со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создание организационной диаграммы с изображением**

Организационная диаграмма с изображением — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Поддерживает ли SmartArt зеркальное отражение или обратное отображение для RTL‑языков?**

Да. Метод [SmartArt.setReversed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы с слева направо на справа налево или обратно, если выбранный макет SmartArt поддерживает обратное отображение.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/nodejs-java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/nodejs-java/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрендерить SmartArt в растр‑изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/nodejs-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Установите отличительное значение с помощью [Shape.setAlternativeText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/setalternativetext/) или [Shape.setName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/setname/) для формы SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getShapes) и затем проверьте, что найденная форма является [SmartArt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/).