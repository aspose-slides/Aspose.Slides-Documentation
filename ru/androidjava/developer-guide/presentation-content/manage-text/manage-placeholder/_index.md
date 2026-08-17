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
- заполнитель контента
- текст подсказки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как инспектировать и редактировать текстовые, рисунковые, диаграммные и контентные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Заполнитель — это фигура, зарезервирующая позицию для определённого типа содержимого в шаблоне презентации. Типичными примерами являются заголовок, основной текст, рисунок, диаграмма и универсальные заполнитель‑контент. В отличие от обычной фигуры, заполнитель может наследовать позицию, размер, форматирование и другие параметры от макетного или мастер‑слайда.

Aspose.Slides предоставляет информацию о заполняющих элементах через метод [IShape.getPlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [IPlaceholder.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/), чтобы определить, какое содержимое предполагается в заполнителе.

Интерфейс фигуры всё равно важен после того, как известен тип заполнителя:

- Пустой текстовый, рисунковый, диаграммный или контентный заполнитель обычно представлен объектом [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).
- Заполненный рисунковый заполнитель может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/).
- Контентный заполнитель может содержать несколько типов содержимого. Проверяйте как [IPlaceholder.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/), так и интерфейс фигуры во время выполнения, вместо предположения, что каждый заполнитель — это [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/) описывает роль заполнителя; она не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к текстовым, рисунковым, диаграммным, табличным или медиа‑специфичным членам.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Мастер‑слайд определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от мастера.
3. Обычный слайд содержит заполнители для этого слайда и может наследовать от своего макета.

Вызовите [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), чтобы подняться на один уровень вверх по этой иерархии. Заполнитель обычного слайда обычно возвращает заполнитель своего макета; заполнитель макета может вернуть заполнитель мастера. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

Ниже приведён пример, который перечисляет заполнители на первом слайде и выводит их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или мастера может затронуть все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать лишь потому, что занимает те же координаты.

## **Изменение текста в заполнителе**

Заполнители заголовков, центрированных заголовков, подзаголовков, основного текста и текста обычно поддерживают текст. Проверьте, является ли фигура [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/), прежде чем использовать её метод [getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).

Этот пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

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

Такой подход позволяет избежать приведения рисунков, диаграмм, таблиц или медиа‑заполнителей к типу [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установление текста‑подсказки в макете**

Текст‑подсказка — это инструкционная надпись, отображаемая в пустом заполнителе в режиме дизайна, например *Click to add title*. Устанавливайте пользовательскую подсказку в заполнителе макета, а не через коллекцию фигур обычного слайда. Доступ к макету получайте через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/) и перебирайте коллекцию, возвращаемую [ILayoutSlide.getShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/).

Следующий пример изменяет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Текст‑подсказка — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа задают реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполнителя рисунка**

Существуют два варианта обработки:

- Если рисунковый заполнитель уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) и [ISlidesPicture.setImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/).
- Если это всё ещё пустой заполнитель, добавьте рисунковый кадр в координатах заполнителя с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/) и удалите пустой заполнитель.

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

Созданная замена для пустого заполнителя — это локальный рисунковый кадр, а не новый заполнитель, поскольку [IShape.getPlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) не предоставляет сеттера. Он сохраняет зарезервированную позицию, но больше не наследует поведение заполнителя. Если сохранение связи с заполнителем критично, сначала подготовьте и заполните заполнитель в PowerPoint, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для рисунка, смотрите статью [Manage Picture Frames](/slides/ru/androidjava/picture-frame/). Эти операции относятся к рисунковому кадру или заливке, а не к метаданным заполнителя.

## **Работа с диаграммными и контентными заполнителями**

Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/). Пример ниже находит такую диаграмму по типу заполнителя и интерфейсу во время выполнения, меняет её заголовок и сохраняет файл:

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

Общий контентный заполнитель обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/). В PowerPoint он выступает как средство запуска для нескольких типов содержимого, включая диаграммы, таблицы, схемы, рисунки и медиа. После заполнения исследуйте реальный интерфейс фигуры, чтобы узнать, что именно она содержит. Специализированные макеты могут также раскрывать типы [PlaceholderType.Chart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/), или [PlaceholderType.Diagram](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/) простым изменением [IPlaceholder.getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/placeholder/); тип нельзя изменить через интерфейс. Чтобы программно заполнить пустую диаграмму или область контента, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Пример ниже делает это для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует от заполнителя макета. При необходимости заменить категории, серии или данные книги используйте специализированные статьи по управлению [диаграммами](/slides/ru/androidjava/powerpoint-charts/).

## **Полный пример: обновление текста или изображения**

Ниже приведён сквозной пример, который открывает шаблон, ищет на первом слайде заполнитель заголовка или рисунка, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример намеренно избегает предположений о индексе фигуры или приведения всех заполнителей к единому интерфейсу.

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

Базовый заполнитель — это соответствующая фигура на макете или мастер‑слайде, от которой наследуется другой заполнитель. Используйте [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) для получения его. Обычная локальная фигура возвращает `null`, поскольку она не входит в иерархию заполнителей.

**Могу ли я изменить все заголовки слайдов, отредактировав заполнитель в макете?**

Вы можете изменить наследуемое форматирование или текст‑подсказку через макет, но фактическое содержимое заголовков хранится в обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, переберите слайды и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов в контексте соответствующего слайда, макета, мастера, заметок или раздаточного листа. См. статью [Manage Presentation Header and Footer](/slides/ru/androidjava/presentation-header-and-footer/) для полных примеров.