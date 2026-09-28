---
title: Управление шаблонами слайдов презентации на Android
linktitle: Шаблон слайда
type: docs
weight: 70
url: /ru/androidjava/slide-master/
keywords:
- шаблон слайда
- шаблон слайда
- шаблон слайда PPT
- несколько шаблонов слайдов
- сравнение шаблонов слайдов
- фон
- заполнитель
- клонирование шаблона слайда
- копирование шаблона слайда
- дублирование шаблона слайда
- неиспользуемый шаблон слайда
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте шаблонами слайдов в Aspose.Slides для Android через Java: доступ, редактирование, клонирование, сравнение и удаление шаблонов слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Шаблон слайда** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фон, стили текста, настройки темы и нижних колонтитулов. В PowerPoint редактирование шаблона слайда — обычный способ поддерживать единообразие презентации без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Android via Java поддерживает такую же модель. Презентация может содержать один или несколько шаблонов слайдов, и каждый шаблон может содержать несколько макетов слайдов. Обычные слайды обычно не ссылаются напрямую на шаблон слайда. Вместо этого обычный слайд использует макет слайда, а этот макет принадлежит шаблону слайда.

Иерархия выглядит так:

1. **Шаблон слайда** – определяет общий дизайн и тему.  
1. **Макет слайда** – определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** – содержит фактическое содержимое презентации и использует один макет слайда.

![Иерархия шаблонов слайдов, макетов слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides шаблон слайда представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/). Все шаблоны слайдов в презентации доступны через коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getMasters--) , реализующую [IMasterSlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/). Полный список API Android via Java см. в [com.aspose.slides API reference](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/).

{{% alert color="info" title="Наследование" %}}
Когда одно и то же свойство определено на нескольких уровнях, выигрывает более конкретный уровень. Например, если шаблон слайда и макет слайда оба задают фон, слайды, основанные на этом макете, используют фон макета. Подробнее о макетах слайдов см. [Применить или изменить макет слайда](/slides/ru/androidjava/slide-layout/).
{{% /alert %}}

## **Доступ к шаблонам слайдов**

В PowerPoint вы можете открыть представление шаблона слайдов из **View** > **Slide Master**.

![Команда Шаблон слайда на вкладке Просмотр PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к шаблонам слайдов:

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

Вы также можете получить шаблон слайда, используемый обычным слайдом, через его макет:

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

## **Что содержит шаблон слайда**

Шаблон слайда — объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/), поэтому предоставляет многие свойства слайдов, используемые обычными и макетными слайдами.

Часто используемые члены шаблона слайда:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Задает фон слайда уровня шаблона. |
| `getShapes()` | Сохраняет фигуры, размещённые на шаблоне, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Сохраняет макетные слайды, принадлежащие шаблону. |
| `getThemeManager()` | Предоставляет доступ к API темы шаблона. |
| `getHeaderFooterManager()` | Управляет заголовками, нижними колонтитулами, датами и номерами слайдов для шаблона и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от шаблона через их макеты. |

## **Добавление изображения в шаблон слайда**

Когда вы добавляете изображение в шаблон слайда, оно появляется на слайдах, использующих макеты этого шаблона. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип к первому шаблону слайда:

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

Для получения более подробной информации о рамках изображений см. [Рамка изображения](/slides/ru/androidjava/picture-frame/).

## **Управление видимостью графики шаблона**

Используйте [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) для скрытия унаследованной графики шаблона, такой как логотипы или декоративные фигуры, без их удаления из шаблона. Передайте `false` методу [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) на слайде, где нужно скрыть эту графику, и оставьте `true` на слайдах, где её нужно отобразить.

Следующий автономный пример создаёт синюю декоративную полосу на шаблоне и двух слайдах, использующих одинаковый пустой макет. Полоса видима на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнители начального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой шаблон через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getLayoutSlide--) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Установка свойства на отдельном слайде влияет только на этот слайд. Передача `false` в [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) скрывает графику шаблона для всех слайдов, использующих общий макет, даже если их собственная настройка `true`. Чтобы скрыть графику только на одном слайде, измените свойство слайда и оставьте общий макет без изменений.

Настройка не поддерживается как управление видимостью непосредственно на шаблоне слайда. На шаблоне метод [getShowMasterShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) всегда возвращает `false`, а передача `true` в [setShowMasterShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) вызывает исключение. Применяйте её к обычному слайду или к макету.

### **Отличие графики от фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику шаблона | Управляет видимостью унаследованных фигур шаблона без их удаления или изменения собственных фигур слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика шаблона — отдельные фигуры и могут оставаться видимыми поверх этого фона. См. [Фон презентации](/slides/ru/androidjava/presentation-background/). |
| Удалить фигуру из шаблона | Удаляет общую исходную фигуру, поэтому она больше недоступна ни одному слайду, использующему данный шаблон. |

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Шаблон слайда предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Шаблон слайда.

![Команда Вставить заполнитель в представлении Шаблон слайда PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим шаблону:

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

Вы также можете форматировать фигуры заполнителей, уже существующие на шаблоне слайда. Следующий пример находит заполнитель заголовка и применяет к нему линейную градиентную заливку:

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

Для получения дополнительных вариантов форматирования заполнителей и текста см. [Установить текст подсказки в заполнителе](/slides/ru/androidjava/manage-placeholder/) и [Форматирование текста](/slides/ru/androidjava/text-formatting/).

## **Изменение фона шаблона слайда**

Фон шаблона наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого шаблона слайда:

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

Связанные темы см. [Фон презентации](/slides/ru/androidjava/presentation-background/) и [Тема презентации](/slides/ru/androidjava/presentation-theme/).

## **Клонирование шаблона слайда в другую презентацию**

Используйте [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) для копирования шаблона слайда в другую презентацию. Скопированный шаблон потом можно использовать в макетах и слайдах целевой презентации.

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

Если нужно клонировать обычные слайды вместе с их шаблоном, см. [Клонировать слайды](/slides/ru/androidjava/clone-slides/).

## **Добавление нескольких шаблонов слайдов**

Презентация может содержать несколько шаблонов слайдов. Это удобно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления шаблонами слайдов](slide-master_9.jpg)

Следующий пример клонирует шаблон по умолчанию, задаёт клону другой фон, создаёт макет под этим клонированным шаблоном и добавляет новый слайд на основе этого макета:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **Сравнение шаблонов слайдов**

Шаблоны слайдов можно сравнивать методом `equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимации и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

Для получения дополнительной информации см. [Сравнение слайдов презентации](/slides/ru/androidjava/compare-slides/).

## **Установка представления Шаблон слайда как представления по умолчанию**

Используйте метод `setLastView` у [ViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/) для управления тем представлением, которое PowerPoint открывает первым. Следующий пример открывает презентацию в представлении Шаблон слайда:

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

Для получения дополнительных параметров представления см. [Сохранить презентацию](/slides/ru/androidjava/save-presentation/).

## **Удаление неиспользуемых шаблонов слайдов**

Иногда в презентациях присутствуют шаблоны слайдов, которые больше не использует ни один обычный слайд. Удаление неиспользуемых шаблонов может уменьшить размер файла и упростить обслуживание шаблона.

Используйте `removeUnused` для удаления неиспользуемых шаблонов из коллекции `getMasters()`:

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

Можно также воспользоваться методом низкого кода [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

**В чём разница между шаблоном слайда и макетом слайда?**

Шаблон слайда определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макет слайда принадлежит шаблону и определяет конкретное расположение заполнителей. Обычный слайд использует макет, поэтому наследует свойства и от макета, и от шаблона.

**Можно ли в одной презентации иметь несколько шаблонов слайдов?**

Да. Презентация может содержать несколько шаблонов слайдов. Используйте несколько шаблонов, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в шаблон слайда или в макет слайда?**

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общие форматы размещайте в шаблоне слайда, а заполнители контента — в макетах, которые будут использовать обычные слайды.

**Можно ли удалить шаблон слайда, который всё ещё используется?**

Нет. Шаблон слайда, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды к макетам другого шаблона или используйте метод очистки неиспользуемых шаблонов, который удаляет только те шаблоны, которые не задействованы.