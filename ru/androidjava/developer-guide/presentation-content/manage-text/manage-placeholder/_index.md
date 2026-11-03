---
title: Управление заполнителями презентаций на Android
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/androidjava/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, рисунковые, диаграммные и содержательные заполнители, а также понять наследование заполнителей с Aspose.Slides для Android на Java."
---
## **Обзор**

Заполнитель — это фигура, которая резервирует позицию для определённого типа содержимого в шаблоне презентации. Частыми примерами являются заголовок, основной текст, рисунок, диаграмма и универсальные заполняющие элементы содержимого. В отличие от обычной фигуры, заполнитель может наследовать своё положение, размер, форматирование и другие настройки от слайда‑макета или слайда‑образца.

Aspose.Slides раскрывает информацию о заполнителях через метод [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/), чтобы определить, что заполнитель предназначен содержать.

Интерфейс фигуры всё ещё имеет значение после того, как вы узнали тип заполнителя:

- Пустой текстовый, рисунковый, диаграммный или заполняющий элемент обычно представляется как [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Заполненный заполнитель рисунка может быть представлен как [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Заполненный заполнитель диаграммы может быть представлен как [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Заполнитель содержимого может содержать несколько видов контента. Проверяйте как [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/), так и интерфейс фигуры во время выполнения, вместо того чтобы предполагать, что каждый заполнитель является [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) описывает роль заполнителя; он не гарантирует тип фигуры во время выполнения. Всегда выполняйте проверку типа перед обращением к членам, специфичным для текста, рисунка, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑образец определяет переиспользуемые стили и, в некоторых случаях, заполняющие элементы уровня образца.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от образца.
3. Обычный слайд содержит заполнители для этого слайда и может наследовать их от своего макета.

Вызовите [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), чтобы подняться на один уровень вверх по этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель макета; заполнитель макета может возвращать свой заполнитель образца. Метод возвращает `null`, если у фигуры нет базового заполнителя.

Следующий пример выводит список заполнителей на первом слайде и сообщает их базовые заполнители:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или образца может повлиять на все слайды, которые всё ещё наследуют данную настройку. Локальная обычная фигура не имеет базового заполнителя и не начинает наследовать только потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--), чтобы оставить существующий объект как обычную фигуру. Его метод [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) возвращает `null`, но фигура остаётся в коллекции слайда. В отличие от этого, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) удаляет фигуру из этой коллекции.

Следующий пример требует `template.pptx` с как минимум одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, унаследованным от его макета или образца, чтобы увидеть эффект удаления этой связи. Пример проверяет, что та же фигура остаётся, вновь вызывает метод для теперь уже обычной фигуры и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Removing placeholder status does not automatically preserve inherited appearance settings. The example below deliberately leaves those settings unchanged, so the output may look different. A shape whose position and size are entirely inherited can have zero coordinates and dimensions after the call and become invisible even though it remains in the collection.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Вызов метода на обычной фигуре не имеет эффекта.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Для соответствующего заполнителя все три проверки выводят `true`. Текст остаётся, но унаследованные положение, размер, вращение, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальная привязка, заливка и параметры линии могут измениться после удаления связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. Смотрите [Макет слайда](/slides/ru/androidjava/slide-layout/) для получения дополнительной информации о макетах.

Чтобы сохранить задуманное отображение, зафиксируйте вычисленные позицию, размер и вращение до вызова и скопируйте необходимые эффективные значения форматирования в отдельные переменные. Получайте эти значения через [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), и [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Не полагайтесь только на объекты эффективного форматирования, потому что их значения текстового форматирования могут измениться после удаления связи. Явно примените зафиксированные значения к обычной фигуре после этого, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заливку и линию, используемые в вашем шаблоне.

Унаследованную геометрию фигур также может потребоваться явно задать через [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Для прямоугольного текстового заполнителя это означает назначить [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); восстановление только заливки и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют обработки этих настроек тоже.

## **Изменение текста в заполнителе**

Заголовки, центрированные заголовки, подзаголовки, основной текст и текстовые заполнители обычно поддерживают текст. Проверяйте наличие [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) перед использованием его метода [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

Следующий пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Этот шаблон избегает приведения типов у заполнителей рисунков, диаграмм, таблиц или медиа к [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста подсказки в макете**

Текст подсказки — это инструкция, отображаемая в пустом заполнителе во время проектирования, например *Click to add title*. Устанавливайте пользовательскую подсказку в заполнителе макета, а не пытаясь достать её через коллекцию фигур обычного слайда. Получите доступ к макету через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) и пройдите по коллекции, возвращаемой [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

Следующий пример меняет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых заполнителей в приложениях редактирования, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполнителя рисунка**

Существует два случая, которые нужно обработать:

- Если заполнитель рисунка уже заполнен и представлен как [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) и [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Если это всё ещё пустой заполнитель, добавьте рамку рисунка в координатах заполнителя с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Созданная замена для пустого заполнителя представляет собой локальную рамку рисунка, а не новый заполнитель, поскольку [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) не предоставляет сеттера. Она сохраняет зарезервированную позицию, но более не наследует поведение, характерное для заполнителей. Если сохранение связи заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для рисунка, смотрите [Управление рамками изображений](/slides/ru/androidjava/picture-frame/). Эти операции относятся к рамке рисунка или заполнению рисунка, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный заполнитель диаграммы может быть представлен как [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Этот пример находит такую диаграмму по типу заполнителя и интерфейсу во время выполнения, меняет её заголовок и сохраняет файл:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Обычный заполнитель содержимого обычно имеет [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). В PowerPoint он служит запускателем для нескольких типов содержимого, включая диаграммы, таблицы, схемы, рисунки и медиа. После заполнения изучите фактический интерфейс фигуры, чтобы понять, что она содержит. Специализированные макеты могут также раскрывать [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), или [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) заполнитель в [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) лишь изменением [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); тип нельзя изменить через интерфейс. Чтобы программно заполнить пустую диаграмму или область содержимого, добавьте необходимый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от заполнителя макета. Используйте специализированные [статьи по управлению диаграммами](/slides/ru/androidjava/powerpoint-charts/), когда нужно заменить её категории, серии или данные книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заполнитель заголовка, либо заполнитель рисунка, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример преднамеренно избегает предположений о индексе фигуры или приведения каждого заполнителя к одному и тому же интерфейсу.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура на макете или образце, от которой наследуется другой заполнитель. Используйте [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), чтобы получить его. Обычная локальная фигура возвращает `null`, поскольку она не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, редактируя заполнитель макета?**

Вы можете изменить унаследованное форматирование или текст подсказки через макет, но фактическое содержимое заголовков хранится в обычных слайдах. Чтобы заменить реальный текст заголовка во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, колонтитула и нижнего колонтитула?**

Используйте менеджеры колонтитулов и нижних колонтитулов в соответствующем слайде, макете, образце, заметках или раздаточных материалах. Смотрите [Manage Presentation Header and Footer](/slides/ru/androidjava/presentation-header-and-footer/) для полных примеров.