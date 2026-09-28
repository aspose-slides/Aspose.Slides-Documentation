---
title: Управление слайд‑мастерами презентации в Java
linktitle: Слайд‑мастер
type: docs
weight: 70
url: /ru/java/slide-master/
keywords:
- слайд‑мастер
- мастер‑слайд
- PPT мастер‑слайд
- множество мастер‑слайдов
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
- Java
- Aspose.Slides
description: "Управление слайд‑мастерами в Aspose.Slides для Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фон, стили текста, параметры темы и настройки нижних колонтитулов. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать согласованность презентации без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Java поддерживает ту же модель. Презентация может содержать один или несколько мастер‑слайдов, каждый из которых может включать несколько слайдов‑макетов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует слайд‑макет, который принадлежит мастер‑слайду.

Иерархия:

1. **Слайд‑мастер** — определяет общий дизайн и тему.  
1. **Слайд‑макет** — определяет конкретное размещение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** — содержит фактическое содержимое презентации и использует один слайд‑макет.

![Иерархия мастер‑слайдов, слайдов‑макетов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представляется интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) . Все мастер‑слайды в презентации доступны через коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getMasters--) , которая реализует [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Наследование" %}}
Когда одно и то же свойство определено на более чем одном уровне, более специфичный уровень имеет приоритет. Например, если мастер‑слайд и слайд‑макет оба задают фон, слайды, основанные на этом макете, используют фон макета. Для получения дополнительной информации о слайдах‑макетах см. [Apply or Change Slide Layouts](/slides/ru/java/slide-layout/) .
{{% /alert %}}

## **Доступ к слайд‑мастерам**

В PowerPoint можно открыть режим слайд‑мастер из **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к мастер‑слайдам:

```java
import com.aspose.slides.*;

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

Вы также можете получить мастер‑слайд, используемый обычным слайдом, через его макет:

```java
import com.aspose.slides.*;

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

## **Содержимое слайд‑мастера**

Мастер‑слайд — это объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/) , поэтому предоставляет многие из тех же свойств слайдов, которые используются обычными и макетными слайдами. Специфические для мастера члены перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) .

Часто используемые члены мастер‑слайда включают:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Устанавливает фон слайда уровня мастер. |
| `getShapes()` | Сохраняет фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Сохраняет слайды‑макеты, принадлежащие мастеру. |
| `getThemeManager()` | Предоставляет доступ к API темы мастера. |
| `getHeaderFooterManager()` | Управляет заголовками, нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавление изображения в слайд‑мастер**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих макеты этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип к первому мастер‑слайду:

```java
import com.aspose.slides.*;

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

Для получения дополнительной информации о кадрах изображений см. [Picture Frame](/slides/ru/java/picture-frame/) .

## **Управление видимостью графики мастера**

Используйте [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) , чтобы скрыть унаследованную графику мастера, например логотипы или декоративные фигуры, не удаляя их из мастера. Передайте `false` в [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) на слайде, где графика должна быть скрыта, и оставьте `true` на слайдах, где она должна отображаться.

Следующий автономный пример создает синюю декоративную полосу на мастере и два слайда, использующие тот же пустой макет. Полоса видна на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнительные элементы начального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой мастер через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getLayoutSlide--) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) . Установка свойства на отдельном слайде влияет только на этот слайд. Передача `false` в [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) скрывает графику мастера для всех слайдов, использующих этот общий макет, даже если их собственная настройка `true`. Чтобы скрыть графику только на одном слайде, измените свойство самого слайда и оставьте общий макет без изменения.

Эта настройка не поддерживается как управление видимостью на самом мастер‑слайде. На мастере [getShowMasterShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterslide/#getShowMasterShapes--) всегда возвращает `false`, а передача `true` в [setShowMasterShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) вызывает исключение. Применяйте её к обычному слайду или к макету.

### **Различие графики и фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику мастера | Управляет видимостью унаследованных фигур мастера без их удаления или изменения собственных фигур слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные фигуры и может оставаться видимой поверх этого фона. См. [Presentation Background](/slides/ru/java/presentation-background/) . |
| Удалить форму из мастера | Удаляет общую исходную форму, поэтому она больше недоступна ни одному слайду, использующему этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на слайдах‑макетах. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти макеты, тогда как каждый макет решает, какие заполнители доступны и где они размещаются.

В PowerPoint команды заполнителей доступны в режиме Slide Master.

![Команда Insert Placeholder на вкладке Slide Master в PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетом, принадлежащим мастеру:

```java
import com.aspose.slides.*;

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

Вы также можете форматировать фигуры‑заполнители, уже существующие в мастер‑слайде. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для получения дополнительных вариантов форматирования заполнителей и текста см. [Set Prompt Text in Placeholder](/slides/ru/java/manage-placeholder/) и [Text Formatting](/slides/ru/java/text-formatting/) .

## **Изменение фона слайд‑мастера**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задает сплошной цвет фона для первого мастер‑слайда:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Для смежных тем см. [Presentation Background](/slides/ru/java/presentation-background/) и [Presentation Theme](/slides/ru/java/presentation-theme/) .

## **Клонирование слайд‑мастера в другую презентацию**

Используйте [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) , чтобы скопировать мастер‑слайд в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```java
import com.aspose.slides.*;

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

Если требуется клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/java/clone-slides/) .

## **Добавление нескольких слайд‑мастеров**

Презентация может содержать несколько мастер‑слайдов. Это удобно, когда разные разделы требуют разного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления мастер‑слайдами](slide-master_9.jpg)

Следующий пример клонирует мастер‑слайд по умолчанию, задаёт клону другой фон, создаёт макет под этим клоном и добавляет новый слайд на основе этого макета:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Мастер‑слайды можно сравнивать методом `equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/) . Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```java
import com.aspose.slides.*;

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

Для получения дополнительной информации см. [Compare Presentation Slides](/slides/ru/java/compare-slides/) .

## **Установка режима слайд‑мастера как представления по умолчанию**

Используйте метод `setLastView` на [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/) , чтобы управлять представлением, которое PowerPoint открывает первым. Следующий пример открывает презентацию в режиме Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для дополнительных настроек представлений см. [Save Presentation](/slides/ru/java/save-presentation/) .

## **Удаление неиспользуемых слайд‑мастеров**

Иногда презентации содержат мастер‑слайды, которые больше не используются никакими обычными слайдами. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить поддержку шаблонов.

Используйте `removeUnused` для удаления неиспользуемых мастеров из коллекции `getMasters()` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете воспользоваться методом низкого кода [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между слайд‑мастером и слайдом‑макетом?**

Слайд‑мастер определяет общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Слайд‑макет принадлежит мастер‑слайду и определяет конкретное расположение заполнителей. Обычный слайд использует слайд‑макет, поэтому наследует свойства как от макета, так и от мастера.

**Можно ли в одной презентации иметь несколько слайд‑мастеров?**

Да. Презентация может содержать несколько мастер‑слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в мастер‑слайд или в слайд‑макет?**

В большинстве случаев заполняйте заполнители в слайдах‑макетах. Общие визуальные элементы и общие настройки размещайте в мастер‑слайде, а места для контента — в заполнителях макетов, которые будут использовать обычные слайды.

**Можно ли удалить мастер‑слайд, если он ещё используется?**

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды к макетам другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастера, которые не задействованы.