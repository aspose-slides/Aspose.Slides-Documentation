---
title: Применение или изменение макетов слайдов в Java
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/java/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержимое
- заголовок раздела
- два содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте и настраивайте макеты слайдов в Aspose.Slides for Java. Изучите типы макетов, управление заполнителями и видимость нижних колонтитулов через примеры кода на Java."
---

## **Обзор**

Макет слайда определяет расположение областей‑заполнителей и форматирование содержимого на слайде. Он контролирует, какие заполнители доступны и где они находятся. Макеты слайдов помогают быстро и последовательно разрабатывать презентации — независимо от того, создаёте ли вы что‑то простое или более сложное. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Title Slide layout** – Содержит два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Title and Content layout** – Имеет меньший заполнитель заголовка вверху и более крупный ниже для основного содержания (текст, маркированные списки, диаграммы, изображения и др.).

**Blank layout** – Не содержит заполнителей, предоставляя полный контроль над проектированием слайда с нуля.

Макеты слайдов являются частью шаблона слайда (slide master), который находится на верхнем уровне и определяет стили макетов для всей презентации. Вы можете получать доступ к макетам и изменять их через шаблон слайда — по типу, имени или уникальному идентификатору. Также можно редактировать конкретный макет непосредственно в презентации.

Для работы с макетами слайдов в Aspose.Slides for Java можно использовать:

- Методы, такие как [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) и [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
- Типы, такие как [ILayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) и [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с шаблонами слайдов, ознакомьтесь со статьёй [Slide Master](/slides/ru/java/slide-master/).
{{% /alert %}}

## **Добавление макетов слайдов в презентацию**

Чтобы настроить внешний вид и структуру ваших слайдов, иногда необходимо добавить новые макеты в презентацию. Aspose.Slides for Java позволяет проверить, существует ли уже нужный макет, при необходимости добавить его и использовать для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите доступ к [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Проверьте, существует ли уже требуемый макет в коллекции. Если нет — добавьте нужный макет.
1. Добавьте пустой слайд на основе нового макета.
1. Сохраните презентацию.

Следующий код Java демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```java
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Пройдитесь по типам макетов слайдов, чтобы выбрать макет слайда.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Ситуация, когда презентация не содержит все типы макетов.
        // Файл презентации содержит только типы макетов Blank и Custom.
        // Однако макеты с пользовательскими типами могут иметь узнаваемые имена,
        // такие как "Title", "Title and Content" и т.д., которые можно использовать для выбора макета слайда.
        // Вы также можете полагаться на набор типов фигур‑заполнителей.
        // Например, титульный слайд должен иметь только тип заполнителя Title и т.д.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Добавьте пустой слайд, используя добавленный макет слайда.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Сохраните презентацию на диск.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) класса [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/), который позволяет удалять нежелательные и неиспользуемые макеты слайдов.

Следующий код Java показывает, как удалить макет слайда из презентации PowerPoint:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Добавление заполнителей в макеты слайдов**

Aspose.Slides предоставляет метод [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , позволяющий добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint              | Метод [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Следующий код Java демонстрирует, как добавить новые формы‑заполнители в макет Blank:
```java
Presentation presentation = new Presentation();
try {
    // Получить пустой макет слайда.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Получить менеджер заполнителей макетного слайда.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Добавить разные заполнители к пустому макету слайда.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Добавить новый слайд с пустым макетом.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The placeholders on the layout slide](add_placeholders.png)

## **Установка видимости колонтитула для макета слайда**

В презентациях PowerPoint элементы колонтитула, такие как дата, номер слайда и пользовательский текст, могут быть отображены или скрыты в зависимости от макета слайда. Aspose.Slides for Java позволяет управлять видимостью этих заполнителей‑колонтитулов. Это полезно, когда требуется отображать информацию в некоторых макетах, а в остальных оставлять чистый вид.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на макет слайда по его индексу.
1. Установите видимость заполнителя колонтитула слайда.
1. Установите видимость заполнителя номера слайда.
1. Установите видимость заполнителя даты и времени.
1. Сохраните презентацию.

Следующий код Java показывает, как установить видимость колонтитула слайда и выполнить сопутствующие действия:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Установка видимости дочерних колонтитулов для слайда**

​В презентациях PowerPoint элементы колонтитула, такие как дата, номер слайда и пользовательский текст, можно управлять на уровне шаблона слайда, чтобы обеспечить согласованность во всех макетах. Aspose.Slides for Java позволяет задавать видимость и содержание этих заполнителей‑колонтитулов в шаблоне и распространять эти настройки на все дочерние макеты слайдов, обеспечивая единообразную информацию о колонтитулах во всей презентации.​

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на шаблон слайда по его индексу.
1. Сделайте видимыми все заполнители колонтитула в шаблоне и во всех дочерних макетах.
1. Сделайте видимыми все заполнители номеров слайдов в шаблоне и во всех дочерних макетах.
1. Сделайте видимыми все заполнители даты и времени в шаблоне и во всех дочерних макетах.
1. Сохраните презентацию.

Следующий код Java демонстрирует эту операцию:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**В чём разница между шаблоном слайда и макетом слайда?**

Шаблон слайда задаёт общую тему и форматирование по умолчанию, тогда как макеты слайдов определяют конкретное расположение заполнителей для разных типов содержимого.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да, можно клонировать макет слайда из коллекции макетов одной презентации (доступно через метод [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--)) и вставить его в другую презентацию с помощью метода `addClone`.

**Что происходит, если удалить макет слайда, который всё ещё используется другим слайдом?**

Если попытаться удалить макет, на который ссылается хотя бы один слайд, Aspose.Slides выбросит исключение [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/). Чтобы этого избежать, используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), который безопасно удалит только неиспользуемые макеты.