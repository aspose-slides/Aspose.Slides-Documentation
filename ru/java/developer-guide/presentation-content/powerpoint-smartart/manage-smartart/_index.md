---
title: Управление SmartArt в презентациях PowerPoint с использованием Java
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Свойство скрытия
- Организационная диаграмма
- Организационная диаграмма с изображением
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Java, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, фигур узлов и макета. С помощью Aspose.Slides for Java вы можете создавать SmartArt, считывать текст из его узлов, изменять его макет, просматривать скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы прочитать видимый текст, пройдите по всем узлам с помощью [ISmartArt.getAllNodes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartart/#getAllNodes--), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) , возвращаемый [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, затем изменяется на `BasicProcess` и презентация сохраняется.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить, скрыт ли узел SmartArt**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartartnode/#isHidden--) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle`, добавляется узел, и проверяется его скрытое состояние.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) и [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) определяют, как дочерние узлы располагаются под родительским узлом. Например, можно задать размещение дочерних узлов слева, справа или с обеих сторон в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OrganizationChartLayoutType).

В следующем примере создаётся организационная диаграмма, и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создать организационную диаграмму с изображением**

Организационная диаграмма с изображением — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Поддерживает ли SmartArt зеркальное отображение или обратное направление для языков RTL?**

Да. Метод [ISmartArt.setReversed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartart/#setReversed-boolean-) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратное направление.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать фигуру SmartArt](/slides/ru/java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) , либо [клонировать весь слайд](/slides/ru/java/clone-slides/) , содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отобразить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерьте слайд](/slides/ru/java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отрисовывается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Установите уникальное значение [Shape.getAlternativeText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getAlternativeText--) или [Shape.getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getName--) для фигуры SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseslide/#getShapes--) , а затем убедитесь, что найденная фигура является [ISmartArt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartart/).