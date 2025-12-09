---
title: Применить или изменить макет слайда в JavaScript
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/nodejs-java/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользованный макет
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять и настраивать макеты слайдов в Aspose.Slides для Node.js. Изучите типы макетов, управление заполнителями, видимость нижних колонтитулов и манипулирование макетами с помощью примеров кода на JavaScript."
---

## **Обзор**

Макет слайда определяет расположение полей‑заполнителей и форматирование содержимого на слайде. Он контролирует, какие заполнители доступны и где они отображаются. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, простую вы делаете или более сложную. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Макет титульного слайда** – Включает два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Макет «Заголовок и содержимое»** – Содержит меньший заполнитель заголовка вверху и более крупный ниже для основного содержания (например, текста, маркеров, диаграмм, изображений и т.д.).

**Пустой макет** – Не содержит заполнителей, давая вам полный контроль над созданием слайда с нуля.

Макеты слайдов являются частью мастер‑слайда, который является верхнеуровневым слайдом, определяющим стили макетов для презентации. Вы можете получить доступ к макетам слайдов и изменять их через мастер‑слайд — по типу, имени или уникальному идентификатору. Кроме того, можно редактировать конкретный макет слайда непосредственно в презентации.

Чтобы работать с макетами слайдов в Aspose.Slides for Node.js, вы можете использовать:

- Методы, такие как [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) и [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) в классе [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
- Типы, такие как [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) и [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с мастер‑слайдами, ознакомьтесь со статьей [Мастер слайдов](/slides/ru/nodejs-java/slide-master/).
{{% /alert %}}

## **Добавление макетов слайдов в презентацию**

Чтобы настроить внешний вид и структуру ваших слайдов, возможно, потребуется добавить новые макеты слайдов в презентацию. Aspose.Slides for Node.js позволяет проверить, существует ли уже конкретный макет, при необходимости добавить новый и использовать его для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите доступ к [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/).
3. Проверьте, существует ли требуемый макет в коллекции. Если нет, добавьте нужный макет.
4. Добавьте пустой слайд на основе нового макета.
5. Сохраните презентацию.

Следующий код JavaScript демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```js
// Создать экземпляр класса Presentation, представляющего файл PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Пройти по типам макетов слайдов, чтобы выбрать макет слайда.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Ситуация, когда презентация не содержит все типы макетов.
        // В файле презентации присутствуют только макеты Blank и Custom.
        // Однако макеты с пользовательскими типами могут иметь узнаваемые имена,
        // такие как "Title", "Title and Content" и т.д., которые можно использовать для выбора макета слайда.
        // Также можно опираться на набор типов фигур-заполнителей.
        // Например, слайд Title должен содержать только заполнитель типа Title и т.д.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Добавить пустой слайд, используя добавленный макет слайда.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Сохранить презентацию на диск.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) из класса [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) для удаления нежелательных и неиспользуемых макетов слайдов.

Следующий код JavaScript показывает, как удалить макет слайда из презентации PowerPoint:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Добавление заполнителей в макеты слайдов**

Aspose.Slides предоставляет метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), который позволяет добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint              | Метод [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Содержимое](content.png)          | addContentPlaceholder(float x, float y, float width, float height) |
| ![Содержимое (вертикальное)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Текст](text.png)                  | addTextPlaceholder(float x, float y, float width, float height) |
| ![Текст (вертикальный)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Изображение](picture.png)         | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Диаграмма](chart.png)             | addChartPlaceholder(float x, float y, float width, float height) |
| ![Таблица](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Медиа](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Онлайн‑изображение](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Следующий код JavaScript демонстрирует, как добавить новые фигуры‑заполнители к пустому макету слайда:
```js
let presentation = new aspose.slides.Presentation();
try {
    // Получить пустой макет слайда.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Получить менеджер заполнителей макета слайда.
    let placeholderManager = layout.getPlaceholderManager();

    // Добавить различные заполнители к пустому макету слайда.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Добавить новый слайд с пустым макетом.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Заполнители на макете слайда](add_placeholders.png)

## **Установка видимости нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides for Node.js позволяет управлять видимостью этих заполнителей нижнего колонтитула. Это полезно, когда вы хотите, чтобы определённые макеты показывали информацию нижнего колонтитула, а другие оставались чистыми и минимальными.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на макет слайда по его индексу.
3. Установите видимость заполнителя нижнего колонтитула слайда.
4. Установите видимость заполнителя номера слайда.
5. Установите видимость заполнителя даты‑времени.
6. Сохраните презентацию.

Следующий код JavaScript показывает, как установить видимость нижнего колонтитула слайда и выполнить связанные задачи:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Установка видимости нижнего колонтитула у дочерних слайдов**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут управляться на уровне мастер‑слайда для обеспечения согласованности во всех макетах. Aspose.Slides for Node.js позволяет задать видимость и содержание этих заполнителей нижнего колонтитула на мастер‑слайде и распространить эти настройки на все дочерние макеты слайдов. Такой подход обеспечивает единообразную информацию нижнего колонтитула по всей презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на мастер‑слайд по его индексу.
3. Установите видимость заполнителей нижнего колонтитула мастера и всех дочерних макетов.
4. Установите видимость заполнителей номеров слайдов мастера и всех дочерних макетов.
5. Установите видимость заполнителей даты‑времени мастера и всех дочерних макетов.
6. Сохраните презентацию.

Следующий код JavaScript демонстрирует эту операцию:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**В чём разница между мастер‑слайдом и макетом слайда?**

Мастер‑слайд определяет общую тему и форматирование по умолчанию, тогда как макеты слайдов задают конкретное расположение заполнителей для разных типов содержимого.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да, вы можете клонировать макет слайда из коллекции макетов одной презентации, доступной через метод [getLayoutSlides], и вставить его в другую презентацию, используя метод `addClone`.

**Что происходит, если удалить макет слайда, который всё ещё используется другим слайдом?**

Если попытаться удалить макет слайда, на который ссылается хотя бы один слайд презентации, Aspose.Slides выбросит исключение [PptxEditException]. Чтобы избежать этого, используйте [removeUnusedLayoutSlides], который безопасно удалит только те макеты, которые не используются.