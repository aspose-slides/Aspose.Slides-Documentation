---
title: У管理 SmartArt в презентациях PowerPoint на Android
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/androidjava/manage-smartart/
keywords:
- SmartArt
- текст SmartArt
- тип макета
- скрытое свойство
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

SmartArt – это диаграмма PowerPoint, состоящая из узлов, фигур узлов и макета. С помощью Aspose.Slides for Android via Java вы можете создавать SmartArt, считывать текст из его узлов, изменять его макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы считать текст из фигур узла, пройдитесь по [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), возвращаемый [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Пример требует презентацию, содержащую хотя бы один слайд, и объект SmartArt в виде первой фигуры на этом слайде. Он выводит каждый доступный текстовый кадр в консоль.

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

Макет SmartArt определяет, как узлы расположены и соединены. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и презентация сохраняется. Позиция и размер, передаваемые в [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-), измеряются в пунктах. Используйте [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-), чтобы изменить макет.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle`, и проверяется скрытое состояние добавленного узла. Если узел скрыт, выводится сообщение, и диаграмма сохраняется.

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

Для диаграмм SmartArt, использующих макет организационной схемы, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) и [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) определяют, как дочерние узлы располагаются под родительским узлом. Например, вы можете установить зависание дочерних узлов слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная схема и задаётся макет для первого узла со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Индекс `0`, начинающийся с нуля, выбирает первый узел верхнего уровня; его дочерние узлы используют выбранное расположение. Затем изменённая презентация сохраняется.

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

## **Создать организационную схему с изображениями**

Организационная схема с изображениями – это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с заполнителями изображений; он не заполняет заполнители изображениями.

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

При модернизации существующей презентации может потребоваться обновить организационную схему, изначально созданную в PowerPoint 97–2003. Aspose.Slides представляет эти устаревшие диаграммы как объекты [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). Используйте [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) , чтобы преобразовать диаграмму в группу фигур для последующего редактирования отдельных визуальных элементов. Подробности см. в [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур без удаления исходной диаграммы. После успешного преобразования удалите оригинал с помощью [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) , чтобы избежать дублирования содержимого. Сначала соберите устаревшие диаграммы в список до их преобразования, чтобы добавление и удаление фигур не нарушали итерацию.

В следующем примере открывается презентация, просматриваются все слайды, диаграммы преобразуются в группы фигур, и обновлённая презентация сохраняется как PPTX.

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

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оставшихся оригинальных диаграмм рядом с ними. Откройте PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или позиция.

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркальное отражение или обратную ориентацию для RTL‑языков?**

Да. Метод [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратную ориентацию.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать фигуру SmartArt](/slides/ru/androidjava/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) , либо [клонировать весь слайд](/slides/ru/androidjava/clone-slides/) , содержащий SmartArt. Оба метода сохраняют размер, позицию и форматирование.

**Как отрисовать SmartArt в растровое изображение для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/androidjava/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Используйте [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) или [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) , чтобы задать уникальный альтернативный текст или имя фигуре SmartArt, ищите это значение в [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) , а затем проверьте, что найденная фигура является [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).