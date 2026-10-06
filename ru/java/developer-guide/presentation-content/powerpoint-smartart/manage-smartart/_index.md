---
title: Управление SmartArt в презентациях PowerPoint с использованием Java
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/java/manage-smartart/
keywords:
- SmartArt
- текст SmartArt
- тип макета
- скрытое свойство
- организационная диаграмма
- организационная диаграмма с изображением
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Java, используя понятные примеры кода, которые ускоряют разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С Aspose.Slides for Java вы можете создавать SmartArt, читать текст из его узлов, менять его макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы прочитать текст из фигур узла, переберите [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) , возвращаемый [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt управляет тем, как узлы расположены и соединены. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, затем меняется на значение `BasicProcess` и сохраняется презентация. Позиция и размер, передаваемые в [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-), измеряются в пунктах. Используйте [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) для изменения макета.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить, скрыт ли узел SmartArt**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) со значением `RadialCycle`, и проверяется состояние скрытости добавленного узла. При скрытом узле выводится сообщение, и диаграмма сохраняется.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) и [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) определяют, как дочерние узлы располагаются под родительским узлом. Например, вы можете задать подвешивание дочерних узлов слева, справа или с обеих сторон в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и задаётся макет для первого узла со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Индекс `0` (нумерация с нуля) выбирает первый узел верхнего уровня; его дочерние узлы используют выбранную расстановку. Затем изменённая презентация сохраняется.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создать организационную диаграмму с изображением**

Организационная диаграмма с изображением — это макет SmartArt, предназначенный для иерархических диаграмм, включающих заполняемые места для изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с заполняемыми местами для изображений; он не заполняет эти места изображениями.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Преобразовать устаревшие диаграммы в группы фигур**

При модернизации существующей презентации может потребоваться обновить организационную диаграмму, изначально созданную в PowerPoint 97–2003. Aspose.Slides представляет эти устаревшие диаграммы как объекты [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/). Используйте [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) для преобразования диаграммы в группу фигур, чтобы можно было редактировать отдельные визуальные элементы. Подробнее смотрите в [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур, не удаляя оригинальную диаграмму. После успешного преобразования удалите оригинал с помощью [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) , чтобы избежать дублирования контента. Сначала соберите устаревшие диаграммы в список, а затем преобразуйте их, чтобы добавление и удаление фигур не нарушало итерацию.

В следующем примере открывается презентация, просматриваются все слайды, диаграммы преобразуются в группы фигур и сохраняется обновлённая презентация в формате PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оставшихся оригинальных диаграмм рядом с ними. Откройте файл PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или положение.

## **Вопросы и ответы**

**Поддерживает ли SmartArt зеркалирование или обратное отображение для RTL-языков?**

Да. Метод [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) переключает направление диаграммы с слева направо на справа налево (и обратно), если выбранный макет SmartArt поддерживает обратное отображение.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) или [клонировать весь слайд](/slides/ru/java/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрисовать SmartArt в растровое изображение для предварительного просмотра или веб-экспорта?**

Вы можете [Отрисовать слайд](/slides/ru/java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отображается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Используйте [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) или [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) для присвоения отличительного альтернативного текста или имени фигуре SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) и затем проверьте, что найденная фигура является [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).