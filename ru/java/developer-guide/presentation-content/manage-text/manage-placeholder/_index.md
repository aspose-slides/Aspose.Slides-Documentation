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
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Java."
---
## **Обзор**

Заполнитель — это фигура, резервирующая позицию для определённого типа содержимого в шаблоне презентации. Часто встречающиеся примеры — заполнители заголовка, основного текста, изображения, диаграммы и универсального содержимого. В отличие от обычной фигуры, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от слайда‑макета или главного слайда.

Aspose.Slides предоставляет информацию о заполнителе через метод [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), чтобы определить, какой тип содержимого ожидает заполнитель.

Интерфейс фигуры остаётся важным после того, как вы узнали тип заполнителя:

- Пустой текстовый, графический, диаграммный или универсальный заполнитель обычно представлен объектом [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Заполненный графический заполнитель может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Универсальный заполнитель может содержать несколько типов содержимого. Проверяйте как [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), так и интерфейс фигуры во время выполнения, а не предполагаете, что каждый заполнитель — это [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Предупреждение" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) описывает роль заполнителя; он не гарантирует тип формы во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Главный слайд определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от мастера.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать от своего макета.

Вызовите [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), чтобы перейти на один уровень выше в этой иерархии. Заполнитель обычного слайда обычно возвращает заполнитель своего макета; заполнитель макета может вернуть заполнитель мастера. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

Следующий пример перечисляет заполнители на первом слайде и выводит их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или мастера может повлиять на все слайды, которые продолжают наследовать этот параметр. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать только потому, что занимает те же координаты.

## **Удалить статус заполнителя**

При адаптации шаблона используйте [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) — чтобы сохранить существующий объект как обычную фигуру. Его метод [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) возвращает `null`, но фигура остаётся в коллекции слайда. В отличие от этого, [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) удаляет фигуру из этой коллекции.

Следующий пример требует файл `template.pptx` с минимум одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, наследованным от его макета или мастера, чтобы увидеть эффект удаления этой связи. Пример проверяет, что та же фигура остаётся, снова вызывает метод на теперь уже обычной фигуре и сохраняет результат.

{{% alert color="warning" title="Предупреждение" %}}
Удаление статуса заполнителя не сохраняет автоматически унаследованные параметры внешнего вида. Пример ниже умышленно оставляет эти параметры без изменений, поэтому итоговый файл может выглядеть иначе. Фигура, чьё положение и размер полностью унаследованы, может получить нулевые координаты и размеры после вызова и стать невидимой, хотя остаётся в коллекции.
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

Для соответствующего заполнителя все три проверки выводят `true`. Текст сохраняется, но унаследованные положение, размер, поворот, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальная привязка, заливка и параметры линии могут измениться после удаления связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. Смотрите [Макет слайда](/slides/ru/java/slide-layout/) для более подробной информации о макетах.

Чтобы сохранить желаемый внешний вид, зафиксируйте разрешённые положение, размер и поворот до вызова и скопируйте необходимые эффективные значения форматирования в отдельные переменные. Получать их можно через [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), и [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Не полагайтесь только на объекты эффективного форматирования, потому что их значения могут измениться после удаления связи. Явно примените зафиксированные значения к обычной фигуре после этого, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заливку и линию, используемые в вашем шаблоне.

Унаследованная геометрия фигуры также может потребовать явного назначения через [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Для прямоугольного текстового заполнителя это означает назначить [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); восстановление только заливки и линии может не вернуть видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют обработки и этих параметров.

## **Изменить текст в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и обычного текста обычно поддерживают текст. Перед использованием метода [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) проверьте, является ли фигура [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

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

Такой подход избегает приведения заполнителей изображения, диаграммы, таблицы или медиа к [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установить текст‑подсказку в макете**

Текст‑подсказка — это сообщение, отображаемое в пустом заполнителе в режиме проектирования, например *Щёлкните, чтобы добавить заголовок*. Задавайте собственный текст‑подсказку в заполнителе макета, а не пытаясь достать его через обычную коллекцию фигур слайда. Доступ к макету получаете через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) и перебираете коллекцию, возвращаемую [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

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

Текст‑подсказка — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в приложениях редактирования, таких как PowerPoint. Как только пользователь или программа добавляют реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет уже существующий текст на слайдах, использующих этот макет.

## **Обновить графический заполнитель**

Существуют два варианта обработки:

- Если графический заполнитель уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) и [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Если это всё ещё пустой заполнитель, добавьте графический кадр в координаты заполнителя с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) и удалите пустой заполнитель.

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

Замена, созданная для пустого заполнителя, представляет собой локальный графический кадр, а не новый заполнитель, потому что [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) не предоставляет сеттер. Он сохраняет зарезервированную позицию, но больше не наследует поведение заполнителя. Если сохранение связи заполнителя критично, подготовьте и заполните заполнитель в PowerPoint заранее, затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для картинок, см. [Управление рамками изображений](/slides/ru/java/picture-frame/). Эти операции относятся к графическому кадру или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Этот пример ищет такую диаграмму по типу заполнителя и интерфейсу во время выполнения, меняет её заголовок и сохраняет файл:

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

Универсальный заполнитель содержимого обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). В PowerPoint он служит запуском для разных типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте реальный интерфейс фигуры, чтобы понять, что она содержит. Специальные макеты могут также раскрывать типы [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), или [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) лишь изменением [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); тип нельзя изменить через интерфейс. Чтобы программно заполнить пустую диаграмму или область содержимого, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует параметры от макета заполнителя. Для замены её категорий, рядов или данных рабочей книги используйте специальные [статьи по управлению диаграммами](/slides/ru/java/powerpoint-charts/).

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заполнитель заголовка, либо графический, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример сознательно избегает предположений о индексе фигуры или приведения всех заполнителей к одному интерфейсу.

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

Базовый заполнитель — это соответствующая фигура на макете или в мастере, от которой другой заполнитель наследует параметры. Используйте [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), чтобы получить его. Обычная локальная фигура возвращает `null`, потому что она не является частью иерархии заполнителей.

**Можно ли изменить все заголовки слайдов, редактируя заполнитель макета?**

Можно изменить унаследованное форматирование или текст‑подсказку через макет, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовка во всей презентации, переберите слайды и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, заголовка и колонтитула?**

Используйте менеджеры заголовков и колонтитулов на соответствующем уровне — слайда, макета, мастера, заметок или раздаточного листа. Смотрите [Управление заголовками и колонтитулами презентации](/slides/ru/java/presentation-header-and-footer/) для полных примеров.