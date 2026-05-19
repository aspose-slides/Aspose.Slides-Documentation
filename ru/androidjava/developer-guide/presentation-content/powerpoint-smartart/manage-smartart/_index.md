---
title: Управление SmartArt в презентациях PowerPoint на Android
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/androidjava/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- свойство скрытия
- организационная диаграмма
- организационная диаграмма с изображением
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Android, используя понятные примеры кода на Java, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Android via Java вы можете создавать SmartArt, считывать текст из его узлов, менять его макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, переберите [ISmartArt.getAllNodes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartart/#getAllNodes--), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/), возвращаемый [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

Макет SmartArt определяет, как расположены и соединены узлы. В следующем примере создается объект SmartArt с значением [SmartArtLayoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, затем меняется на значение `BasicProcess` и сохраняется презентация.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartartnode/#isHidden--) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут существовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle`, и проверяется состояние скрытия узла.

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

## **Получить или установить макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) и [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) определяют, как дочерние узлы располагаются под родительским узлом. Например, вы можете установить дочерние узлы так, чтобы они висели слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OrganizationChartLayoutType).

В следующем примере создаётся организационная диаграмма, и для первого узла устанавливается макет со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

Организационная диаграмма с изображением — это макет SmartArt, предназначенный для иерархических диаграмм с размещёнными изображениями. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`.

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

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркальное отображение или обратное отображение для RTL-языков?**

Да. Метод [ISmartArt.setReversed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) переключает направление диаграммы с слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратное отображение.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/androidjava/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) или [клонировать весь слайд](/slides/ru/androidjava/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, положение и форматирование.

**Как отобразить SmartArt в растровое изображение для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/androidjava/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Установите уникальное значение [Shape.getAlternativeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getAlternativeText--) или [Shape.getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getName--) для формы SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslide/#getShapes--), а затем проверьте, что найденная форма является [ISmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartart/).