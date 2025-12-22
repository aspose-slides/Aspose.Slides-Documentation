---
title: Применение или изменение макетов слайдов на Android
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/androidjava/slide-layout/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте и настраивайте макеты слайдов в Aspose.Slides for Android. Изучайте типы макетов, управление заполнителями и видимость нижнего колонтитула с помощью примеров кода на Java."
---

## **Обзор**

Макет слайда определяет расположение блоков заполнителей и форматирование содержимого на слайде. Он контролирует, какие заполнители доступны и где они располагаются. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, создаёте ли вы что‑то простое или более сложное. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Макет титульного слайда** – Включает два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Макет «Заголовок и содержание»** – Содержит меньший заполнитель заголовка вверху и более крупный ниже для основного содержимого (например, текста, маркеров, диаграмм, изображений и т.д.).

**Пустой макет** – Не содержит заполнителей, предоставляя вам полный контроль для создания слайда с нуля.

Макеты слайдов являются частью шаблона слайда (slide master), который является слайдом верхнего уровня и определяет стили макетов для презентации. Вы можете получать доступ к макетам слайдов и изменять их через шаблон слайда — по типу, имени или уникальному идентификатору. Кроме того, можно отредактировать конкретный макет слайда непосредственно в презентации.

Для работы с макетами слайдов в Aspose.Slides for Android вы можете использовать:
- Методы, такие как [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) и [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) в классе [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 
- Типы, такие как [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), и [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с шаблонами слайдов, ознакомьтесь со статьёй [Slide Master](/slides/ru/androidjava/slide-master/) .
{{% /alert %}}

## **Добавление макетов слайдов в презентации**

Чтобы настроить внешний вид и структуру ваших слайдов, возможно, потребуется добавить новые макеты слайдов в презентацию. Aspose.Slides for Android позволяет проверить, существует ли уже конкретный макет, добавить новый при необходимости и использовать его для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите доступ к [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/) .
3. Проверьте, существует ли желаемый макет слайда в коллекции. Если нет, добавьте необходимый макет слайда.
4. Добавьте пустой слайд на основе нового макета слайда.
5. Сохраните презентацию.

Следующий код Java демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```java
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Пройдите по типам макетных слайдов, чтобы выбрать макетный слайд.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Ситуация, когда презентация не содержит всех типов макетов.
        // Файл презентации содержит только типы макетов Blank и Custom.
        // Однако макетные слайды с пользовательскими типами могут иметь узнаваемые имена,
        // такие как "Title", "Title and Content" и т.д., которые могут быть использованы для выбора макетного слайда.
        // Вы также можете опираться на набор типов заполнителей формы.
        // Например, слайд Title должен иметь только заполнитель Title и т.д.
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

    // Добавьте пустой слайд, используя добавленный макетный слайд.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Сохраните презентацию на диск.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) из класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) для удаления нежелательных и неиспользуемых макетов слайдов.

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

Aspose.Slides предоставляет метод [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , который позволяет добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Метод |
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

Следующий код Java демонстрирует, как добавить новые формы заполнителей к пустому макету слайда:
```java
Presentation presentation = new Presentation();
try {
    // Получить пустой макет слайда.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Получить менеджер заполнителей для макетного слайда.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Добавить различные заполнители в пустой макет слайда.
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

![Заполнители на макете слайда](add_placeholders.png)

## **Установка видимости нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides for Android позволяет управлять видимостью этих заполнителей нижнего колонтитула. Это полезно, когда вы хотите, чтобы определённые макеты отображали информацию нижнего колонтитула, а другие оставались чистыми и минимальными.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на макет слайда по его индексу.
3. Установите видимость заполнителя нижнего колонтитула слайда.
4. Установите видимость заполнителя номера слайда.
5. Установите видимость заполнителя даты и времени.
6. Сохраните презентацию.

Следующий код Java показывает, как установить видимость нижнего колонтитула слайда и выполнить связанные задачи:
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


## **Установка видимости нижнего колонтитула у дочерних слайдов**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут контролироваться на уровне шаблона слайда, чтобы обеспечить согласованность во всех макетах слайдов. Aspose.Slides for Android позволяет установить видимость и содержимое этих заполнителей нижнего колонтитула на шаблоне слайда и распространить эти настройки на все дочерние макеты слайдов. Этот подход обеспечивает одинаковую информацию нижнего колонтитула во всей презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на шаблон слайда (master slide) по его индексу.
3. Установите видимость заполнителей нижнего колонтитула шаблона и всех дочерних макетов.
4. Установите видимость заполнителей номеров слайдов шаблона и всех дочерних макетов.
5. Установите видимость заполнителей даты и времени шаблона и всех дочерних макетов.
6. Сохраните презентацию.

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

Шаблон слайда определяет общую тему и форматирование по умолчанию, тогда как макеты слайдов определяют конкретные расположения заполнителей для разных типов содержимого.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да, вы можете клонировать макет слайда из коллекции макетов слайдов одной презентации, доступной через метод [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), и вставить его в другую презентацию, используя метод `addClone`.

**Что произойдёт, если удалить макет слайда, который всё ещё используется другим слайдом?**

Если попытаться удалить макет слайда, который всё ещё используется хотя бы одним слайдом в презентации, Aspose.Slides выбросит исключение [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). Чтобы избежать этого, используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), который безопасно удаляет только неиспользуемые макеты слайдов.