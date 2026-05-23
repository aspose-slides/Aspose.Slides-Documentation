---
title: Управление слайд‑мастерами презентаций на Android
linktitle: Слайд‑мастер
type: docs
weight: 70
url: /ru/androidjava/slide-master/
keywords:
- слайд‑мастер
- мастер‑слайд
- PPT мастер‑слайд
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте слайд‑мастерами в Aspose.Slides for Android via Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фон, стили текста, параметры темы и настройки колонтитулов. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Android via Java поддерживает ту же модель. Презентация может содержать один или несколько слайд‑мастеров, и каждый слайд‑мастер может содержать несколько слайдов‑макетов. Обычные слайды обычно не ссылаются непосредственно на слайд‑мастер. Вместо этого обычный слайд использует слайд‑макет, а этот макет принадлежит слайд‑мастеру.

Иерархия выглядит так:

1. **Слайд‑мастер** — определяет общий дизайн и тему.
1. **Слайд‑макет** — определяет конкретное расположение заполнителей и форматирование уровня макета.
1. **Обычный слайд** — содержит фактическое содержимое презентации и использует один слайд‑макет.

![Иерархия слайд‑мастеров, макетов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представляется интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/). Все слайд‑мастера в презентации доступны через коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getMasters--) , реализующую [IMasterSlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/). Полный набор API для Android via Java см. в [com.aspose.slides API reference](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/).

{{% alert color="info" title="Наследование" %}}
Когда одно и то же свойство определено на нескольких уровнях, победу получает более специфичный уровень. Например, если слайд‑мастер и слайд‑макет оба задают фон, слайды, основанные на этом макете, используют фон макета. Подробнее о слайдах‑макетах см. в статье [Apply or Change Slide Layouts](/slides/ru/androidjava/slide-layout/).
{{% /alert %}}

## **Доступ к слайд‑мастерам**

В PowerPoint вы можете открыть представление **Slide Master** из **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()`для доступа к слайд‑мастерам:

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

Также можно получить слайд‑мастер, используемый обычным слайдом, через его макет:

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

Слайд‑мастер — это объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/), поэтому предоставляет многие из тех же свойств, что и обычные и макетные слайды.

Часто используемые члены слайд‑мастера:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Устанавливает фон слайда уровня мастера. |
| `getShapes()` | Сохраняет формы, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Сохраняет слайды‑макеты, принадлежащие мастеру. |
| `getThemeManager()` | Обеспечивает доступ к API тем мастера. |
| `getHeaderFooterManager()` | Управляет колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавить изображение в слайд‑мастер**

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

Подробнее о рамках изображений см. в статье [Picture Frame](/slides/ru/androidjava/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на слайдах‑макетах. Слайд‑мастер предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Slide Master.

![Команда Insert Placeholder в представлении Slide Master PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетом, принадлежащим мастеру:

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

Вы также можете отформатировать уже существующие формы заполнителей на слайде‑мастере. В следующем примере найден заполнитель заголовка и к нему применён линейный градиентный залив:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Отформатированный заполнитель заголовка, наследуемый обычными слайдами](slide-master_8.png)

Больше вариантов форматирования заполнителей и текста см. в статьях [Set Prompt Text in Placeholder](/slides/ru/androidjava/manage-placeholder/) и [Text Formatting](/slides/ru/androidjava/text-formatting/).

## **Изменить фон слайд‑мастера**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Пример ниже задаёт сплошной цвет фона для первого слайд‑мастера:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

См. также темы [Presentation Background](/slides/ru/androidjava/presentation-background/) и [Presentation Theme](/slides/ru/androidjava/presentation-theme/).

## **Клонировать слайд‑мастер в другую презентацию**

Используйте [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) для копирования слайд‑мастера в другую презентацию. Скопированный мастер затем можно использовать в макетах и слайдах целевой презентации.

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

Если нужно клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/androidjava/clone-slides/).

## **Добавить несколько слайд‑мастеров**

Презентация может содержать несколько слайд‑мастеров. Это полезно, когда разные разделы требуют разных брендов, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления слайд‑мастерами](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону другой фон, создаёт макет под этим клонированным мастером и добавляет новый слайд на основе этого макета:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

Слайд‑мастера можно сравнивать методом `equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

Подробности см. в статье [Compare Presentation Slides](/slides/ru/androidjava/compare-slides/).

## **Установить представление Слайд‑мастер как представление по умолчанию**

Используйте метод `setLastView` класса [ViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/) для управления тем, какое представление PowerPoint открывает первым. В следующем примере презентация открывается в представлении Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Больше настроек представления см. в статье [Save Presentation](/slides/ru/androidjava/save-presentation/).

## **Удалить неиспользуемые слайд‑мастера**

Иногда презентации содержат слайд‑мастера, которые больше не используются ни одним обычным слайдом. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблона.

Используйте `removeUnused` для удаления неиспользуемых мастеров из коллекции `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Также можно воспользоваться низкокодовым методом [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

**В чем разница между слайд‑мастером и слайдом‑макетом?**

Слайд‑мастер определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Слайд‑макет принадлежит слайд‑мастеру и определяет конкретное расположение заполнителей. Обычный слайд использует слайд‑макет, поэтому наследует свойства как макета, так и мастера.

**Может ли одна презентация содержать несколько слайд‑мастеров?**

Да. Презентация может содержать несколько слайд‑мастеров. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в слайд‑мастер или в слайд‑макет?**

В большинстве случаев заполнять заполнителями следует слайды‑макеты. Общие визуальные элементы и общее форматирование помещайте на слайд‑мастер, а заполнители контента — на макеты, которые будут использовать обычные слайды.

**Можно ли удалить слайд‑мастер, который всё ещё используется?**

Нет. Слайд‑мастер, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты под другим мастером или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастера, которые не задействованы.