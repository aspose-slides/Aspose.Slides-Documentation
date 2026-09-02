---
title: Управление заполнителями презентаций в Java
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель контента
- подсказка текста
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать заполнители текста, изображения, диаграмм и контента, а также понять наследование заполнителей с помощью Aspose.Slides для Java."
---
## **Обзор**

Заполнитель — это объект, который резервирует позицию для определённого типа содержимого в шаблоне презентации. Часто встречающиеся примеры — заполнители заголовка, основного текста, изображения, диаграммы и универсального контента. В отличие от обычного объекта, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от слайда‑разметки или главного слайда.

Aspose.Slides предоставляет информацию о заполнителе через метод [IShape.getPlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholder/) или `null` для обычного объекта. Используйте [IPlaceholder.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholder/) для определения того, какой контент предполагается в заполнителе.

Интерфейс объекта всё равно важен после того, как вы узнали тип заполнителя:

- Пустой заполнитель текста, изображения, диаграммы или контента обычно представлен объектом [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/).
- Заполненный заполнитель изображения может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/).
- Заполненный заполнитель диаграммы может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/).
- Заполнитель контента может содержать несколько видов контента. Проверяйте как [IPlaceholder.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholder/), так и интерфейс объекта во время выполнения, вместо того чтобы предполагать, что каждый заполнитель — это [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholder/) описывает роль заполнителя; он не гарантирует тип объекта во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Главный слайд определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑разметка определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать его от мастера.
3. Обычный слайд содержит заполнители для этого слайда и может наследовать их от своей разметки.

Вызовите [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) для перехода на один уровень выше в этой иерархии. Заполнитель обычного слайда, как правило, возвращает свой заполнитель разметки; заполнитель разметки может вернуть заполнитель мастера. Метод возвращает `null`, когда объект не имеет базового заполнителя.

Ниже приведён пример, перечисляющий заполнители на первом слайде и выводящий их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Изменение связанной разметки или мастера может повлиять на все слайды, которые продолжают наследовать эту настройку. Обычный локальный объект не имеет базового заполнителя и не начинает наследовать просто потому, что занимает те же координаты.

## **Изменение текста в заполнителе**

Заполнители заголовка, централизованного заголовка, подзаголовка, основного текста и текста обычно поддерживают текст. Проверьте, является ли объект [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/), перед тем как использовать его метод [getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

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

Такой подход избегает приведения заполнителей изображений, диаграмм, таблиц или медиа к объекту [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/). Он также определяет заполнитель по назначению, а не полагается на хрупкий индекс объекта.

## **Установка текста‑подсказки в разметке**

Текст‑подсказка — это инструктивный текст, отображаемый в пустом заполнителе во время разработки, например *Click to add title*. Устанавливайте пользовательский текст‑подсказки в заполнителе разметки, а не пытаясь получить его через коллекцию объектов обычного слайда. Доступ к разметке осуществляется через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/), после чего перебирайте коллекцию, возвращаемую [ILayoutSlide.getShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/).

В примере ниже меняются подсказки заголовка и подзаголовка в разметке, используемой первым слайдом:

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

Текст‑подсказка — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих эту разметку.

## **Обновление заполнителя изображения**

Есть два сценария:

- Если заполнитель изображения уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) и [ISlidesPicture.setImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidespicture/).
- Если это ещё пустой заполнитель, добавьте объект изображения по координатам заполнителя через [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Созданная замена для пустого заполнителя представляет собой локальный объект изображения, а не новый заполнитель, поскольку [IShape.getPlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) не предоставляет сеттер. Он сохраняет зарезервированную позицию, но более не наследует поведение, специфичное для заполнителя. Если важно сохранить связь с заполнителем, сначала подготовьте и заполните заполнитель в PowerPoint, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) через Aspose.Slides.

Для изменения прозрачности изображения, обрезки и других эффектов, специфичных для изображения, смотрите раздел [Manage Picture Frames](/slides/ru/java/picture-frame/). Эти операции относятся к объекту изображения или его заливке, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и контента**

Заполненный заполнитель диаграммы может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/). В этом примере поиск такой диаграммы осуществляется как по типу заполнителя, так и по интерфейсу во время выполнения, меняется её заголовок и сохраняется файл:

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

Общий заполнитель контента обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/). В PowerPoint он выступает в роли запуска для нескольких типов контента, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте фактический интерфейс объекта, чтобы узнать, что он содержит. Специализированные разметки могут также использовать [PlaceholderType.Chart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/), или [PlaceholderType.Diagram](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) в объект [IChart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/) простым изменением [IPlaceholder.getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/placeholder/); тип изменить через интерфейс нельзя. Чтобы программно заполнить пустую диаграмму или область контента, добавьте необходимый объект по координатам заполнителя и затем удалите пустой заполнитель. В следующем примере показано, как это сделать для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует её из разметки. При необходимости заменять категории, серии или данные книги используйте специализированные статьи по управлению [диаграммами](/slides/ru/java/powerpoint-charts/).

## **Полный пример: обновление текста или изображения**

Ниже приведён сквозной пример, который открывает шаблон, ищет на первом слайде заполнитель заголовка или изображения, проверяет типы заполнителя и объекта, обновляет соответствующее содержимое и сохраняет результат. Пример преднамеренно избегает предположений о индексе объекта и приведения всех заполнителей к одному интерфейсу.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

Базовый заполнитель — это соответствующий объект на разметке или мастере, от которого наследуется другой заполнитель. Используйте [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) для его получения. Обычный локальный объект возвращает `null`, поскольку он не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, редактируя заполнитель разметки?**

Вы можете изменить наследуемое форматирование или текст‑подсказку через разметку, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, переберите слайды и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов в соответствующей области — слайд, разметка, мастер, заметки или раздача. См. раздел [Manage Presentation Header and Footer](/slides/ru/java/presentation-header-and-footer/) для полных примеров.