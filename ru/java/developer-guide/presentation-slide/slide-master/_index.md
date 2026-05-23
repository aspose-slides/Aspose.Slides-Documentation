---
title: У管理 презентации слайд‑мастеров в Java
linktitle: Слайд‑мастер
type: docs
weight: 70
url: /ru/java/slide-master/
keywords:
- слайд‑мастер
- мастер‑слайд
- PPT‑мастер‑слайд
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонировать мастер‑слайд
- копировать мастер‑слайд
- дублировать мастер‑слайд
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте слайд‑мастерами в Aspose.Slides для Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, параметры темы и настройки нижних колонтитулов. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать согласованность презентации без необходимости повторять одинаковое форматирование на каждом слайде.

Aspose.Slides for Java поддерживает ту же модель. Презентация может содержать один или несколько слайд‑мастеров, а каждый слайд‑мастер может включать несколько макетных слайдов. Обычные слайды обычно не ссылаются напрямую на слайд‑мастер. Вместо этого обычный слайд использует макетный слайд, а этот макетный слайд принадлежит слайд‑мастеру.

Иерархия выглядит так:

1. **Slide master** — определяет общий дизайн и тему.  
2. **Layout slide** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
3. **Normal slide** — содержит реальное содержание презентации и использует один макетный слайд.

![Иерархия слайд‑мастеров, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/). Все слайды‑мастера в презентации доступны через коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getMasters--) , которая реализует [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Наследование" %}}

Когда одно и то же свойство определено на нескольких уровнях, приоритет имеет более конкретный уровень. Например, если слайд‑мастер и макетный слайд оба определяют фон, слайды, основанные на этом макете, используют фон макета. Для получения дополнительной информации о макетных слайдах см. [Apply or Change Slide Layouts](/slides/ru/java/slide-layout/).

{{% /alert %}}

## **Доступ к слайд‑мастерам**

В PowerPoint вы можете открыть представление Слайд‑мастер через **Вид** > **Слайд‑мастер**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к слайд‑мастерам:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Вы также можете получить слайд‑мастер, используемый обычным слайдом, через его макет:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Что содержит слайд‑мастер**

Слайд‑мастер — объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/), поэтому предоставляет многие те же свойства, что и обычные и макетные слайды. Специфичные для мастера члены перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/).

Часто используемые члены слайд‑мастера включают:

| Член | Описание |
| --- | --- |
| `getBackground()` | Устанавливает фон уровня мастера. |
| `getShapes()` | Содержит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Содержит макетные слайды, принадлежащие мастеру. |
| `getThemeManager()` | Предоставляет доступ к API темы мастера. |
| `getHeaderFooterManager()` | Управляет верхними/нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от мастера через свои макеты. |

## **Добавление изображения в слайд‑мастер**

Когда вы добавляете изображение в слайд‑мастер, оно появляется на слайдах, использующих макеты этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый слайд‑мастер:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для получения дополнительной информации о рамках изображений см. [Picture Frame](/slides/ru/java/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Слайд‑мастер предоставляет общий стиль и тему, которые наследуются макетами, тогда как каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Слайд‑мастер.

![Команда Insert Placeholder в представлении Slide Master PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим мастер‑слайду:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете отформатировать уже существующие фигуры‑заполнители на слайд‑мастере. В следующем примере ищется заполнитель заголовка и применяется линейный градиентный залив:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для получения дополнительных параметров заполнителей и форматирования текста см. [Set Prompt Text in Placeholder](/slides/ru/java/manage-placeholder/) и [Text Formatting](/slides/ru/java/text-formatting/).

## **Изменение фона слайд‑мастера**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример устанавливает сплошной цвет фона для первого слайд‑мастера:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

См. также темы: [Presentation Background](/slides/ru/java/presentation-background/) и [Presentation Theme](/slides/ru/java/presentation-theme/).

## **Клонирование слайд‑мастера в другую презентацию**

Используйте [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) для копирования слайд‑мастера в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/java/clone-slides/).

## **Добавление нескольких слайд‑мастеров**

Презентация может содержать несколько слайд‑мастеров. Это полезно, когда разные разделы требуют разного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления слайд‑мастерами](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону другой фон, создаёт макет под этим клоном и добавляет новый слайд на основе этого макета:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сравнение слайд‑мастеров**

Слайд‑мастера можно сравнивать методом `equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/). Сравнение проверяет структуру и статическое содержание, такие как фигуры, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например IDs слайдов, или динамические значения заполнителей, такие как текущая дата.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Для получения дополнительной информации см. [Compare Presentation Slides](/slides/ru/java/compare-slides/).

## **Установка представления Слайд‑мастер по умолчанию**

Используйте метод `setLastView` у [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/) для управления тем представлением, которое PowerPoint открывает первым. В следующем примере презентация открывается в представлении Слайд‑мастер:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для более подробных настроек представления см. [Save Presentation](/slides/ru/java/save-presentation/).

## **Удаление неиспользуемых слайд‑мастеров**

Иногда в презентациях остаются слайд‑мастера, которые больше не используются обычными слайдами. Их удаление может уменьшить размер файла и упростить обслуживание шаблона.

Вызовите `removeUnused` для удаления неиспользуемых мастеров из коллекции `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Можно также воспользоваться методом низкоуровневого кода [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между слайд‑мастером и макетным слайдом?**

Слайд‑мастер определяет общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит слайд‑мастеру и задаёт конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует параметры как от макета, так и от мастера.

**Можно ли в одной презентации иметь несколько слайд‑мастеров?**

Да. Презентация может содержать несколько слайд‑мастеров. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Куда лучше добавлять заполнители — в слайд‑мастер или в макетный слайд?**

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общие форматы помещайте на слайд‑мастер, а заполнители контента — в макеты, которые будут использовать обычные слайды.

**Можно ли удалить слайд‑мастер, который все ещё используется?**

Нет. Слайд‑мастер, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те, которые не задействованы.