---
title: Управление SmartArt в презентациях PowerPoint с помощью JavaScript
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- скрытое свойство
- организационная диаграмма
- организационная диаграмма с изображением
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Node.js, используя понятные примеры кода JavaScript, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides для Node.js через Java вы можете создавать SmartArt, считывать текст из его узлов, изменять его макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы считать текст из форм узла, пройдитесь по [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), затем прочитайте [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), возвращаемый методом [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Для примера требуется презентация как минимум с одним слайдом и объектом SmartArt в виде первой формы на этом слайде. Он выводит каждый доступный текстовый кадр в консоль.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он изменяется на `BasicProcess` и презентация сохраняется. Позиция и размер, передаваемые в [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/), измеряются в пунктах. Для изменения макета используйте [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить, скрыт ли узел SmartArt**

Метод [SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`, и проверяется состояние скрытости добавленного узла. При обнаружении скрытого узла выводится сообщение, после чего диаграмма сохраняется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, методы [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) и [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) определяют, как дочерние узлы располагаются под родительским узлом. Например, вы можете задать развешивание дочерних узлов слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Индекс `0` (нумерация с нуля) выбирает первый узел верхнего уровня; его дочерние узлы используют выбранную схему размещения. Затем изменённая презентация сохраняется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создать организационную диаграмму с изображением**

Диаграмма организации с изображением — это макет SmartArt, предназначенный для иерархических диаграмм, содержащих резервные места для изображений. При добавлении объекта SmartArt на слайд используйте тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с резервными местами для изображений; он не заполняет эти места изображениями.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Преобразовать наследованные диаграммы в группы фигур**

При модернизации существующей презентации может потребоваться обновить организационную диаграмму, изначально созданную в PowerPoint 97–2003. Aspose.Slides представляет такие наследованные диаграммы как объекты [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Используйте [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) для преобразования диаграммы в группу фигур, чтобы можно было редактировать отдельные визуальные элементы. Подробности см. в [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур без удаления исходной диаграммы. После успешного преобразования удалите оригинал с помощью [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/), чтобы избежать дублирования контента. Сначала соберите наследованные диаграммы в список, а затем преобразуйте их, чтобы добавление и удаление фигур не нарушало процесс итерации.

В следующем примере открывается презентация, перебираются все слайды, диаграммы преобразуются в группы фигур, и обновлённая презентация сохраняется в формате PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных наследованных диаграмм, при этом оригинальные диаграммы полностью удалены. Откройте PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или положение.

## **Вопросы и ответы**

**Поддерживает ли SmartArt зеркалирование или инверсию для RTL‑языков?**

Да. Метод [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы слева направо на право‑налево и обратно, если выбранный макет SmartArt поддерживает инверсию.

**Как я могу скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/nodejs-java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/nodejs-java/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отобразить SmartArt в растровом изображении для предварительного просмотра или веб‑экспорта?**

[Отобразите слайд](/slides/ru/nodejs-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отображается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Используйте [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) или [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) для назначения отличительного альтернативного текста или имени форме SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), а затем проверьте, является ли найденная форма [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).