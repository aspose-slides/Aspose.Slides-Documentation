---
title: Макет слайдов
type: docs
weight: 60
url: /ru/java/slide-layout/
keyword: "Установить размер слайда, задать параметры слайда, указать размер слайда, Видимость нижнего колонтитула, Дочерний нижний колонтитул, Масштабирование содержимого, размер страницы, Java, Aspose.Slides"
description: "Установить размер и параметры слайдов PowerPoint на Java"
---

Макет слайда содержит заполнители и информацию о форматировании для всего контента, который появляется на слайде. Макет определяет доступные заполнители контента и место, где они расположены.

Макеты слайдов позволяют быстро создавать и разрабатывать презентации (независимо от того, простые они или сложные). Вот некоторые из самых популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет титульного слайда**. Этот макет состоит из двух текстовых заполнителей. Один заполнитель предназначен для заголовка, а другой — для подзаголовка.
* **Макет "Заголовок и содержание"**. Этот макет содержит относительно маленький заполнитель вверху для заголовка и более крупный заполнитель для основного содержания (график, параграфы, маркированный список, нумерованный список, изображения и т.д.).
* **Пустой макет**. Этот макет не имеет заполнителей, поэтому позволяет создавать элементы с нуля.

Поскольку мастер-слайд является верхним иерархическим слайдом, который хранит информацию о макетах слайдов, вы можете использовать мастер-слайд для доступа к макетам слайдов и внесения в них изменений. Макет слайда можно получить по типу или имени. Аналогично, каждый слайд имеет уникальный идентификатор, который может быть использован для его доступа.

В качестве альтернативы вы можете напрямую вносить изменения в конкретный макет слайда в презентации.

* Чтобы дать вам возможность работать с макетами слайдов (включая макеты на мастер-слайдах), Aspose.Slides предоставляет такие свойства, как [getLayoutSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) и [getMasters()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) в классе [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения дополнительной информации о работе с мастер-слайдами в частности, см. статью [Мастер слайда](https://docs.aspose.com/slides/java/slide-master/).

{{% /alert %}}

## **Добавить макет слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите доступ к коллекции [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Пройдите через существующие макеты слайдов, чтобы подтвердить, что требуемый макет слайда уже существует в коллекции макетов. В противном случае добавьте нужный макет.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить макет слайда в презентацию PowerPoint:

```java
// Создает экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Проходит через типы макетов слайдов
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Ситуация, когда презентация не содержит некоторых типов макетов.
        // Файл презентации содержит только пустые и настраиваемые типы макетов.
        // Но макеты слайдов с настраиваемыми типами имеют разные названия слайдов,
        // такие как "Заголовок", "Заголовок и содержание" и т.д. Можно использовать эти
        // имена для выбора макета слайда.
        // Вы также можете использовать набор типов заполнителей фигур. Например,
        // Титульный слайд должен иметь только тип заполнителя "Заголовок" и т.д.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
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

    // Добавляет пустой слайд с добавленным макетом слайда
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Сохраняет презентацию на диск
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), чтобы вы могли удалить ненужные и неиспользуемые макеты слайдов. Этот код на Java показывает, как удалить макет слайда из презентации PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить размер и тип для макета слайда**

Чтобы позволить вам установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) и [getSize()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getSize--) (из класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)). Этот код на Java демонстрирует операцию:

```java
// Создает экземпляр объекта Presentation, который представляет файл презентации
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Устанавливает размер слайда для сгенерированной презентации таким же, как для исходной
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Клонирует требуемый слайд
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // Сохраняет презентацию на диск
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Установить видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Установите заполнитель нижнего колонтитула слайда как видимый.
1. Установите заполнитель даты и времени как видимый.
1. Сохраните презентацию.

Этот код на Java показывает, как установить видимость нижнего колонтитула слайда (и выполнить связанные задачи):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // Метод isFooterVisible используется для указания, что заполнитель нижнего колонтитула слайда отсутствует
    {
        headerFooterManager.setFooterVisibility(true); // Метод setFooterVisibility используется для установки видимости заполнителя нижнего колонтитула слайда
    }
    if (!headerFooterManager.isSlideNumberVisible()) // Метод isSlideNumberVisible используется для указания, что заполнитель номера слайда отсутствует
    {
        headerFooterManager.setSlideNumberVisibility(true); // Метод setSlideNumberVisibility используется для установки видимости заполнителя номера слайда
    }
    if (!headerFooterManager.isDateTimeVisible()) // Метод isDateTimeVisible используется для указания, что заполнитель даты и времени отсутствует
    {
        headerFooterManager.setDateTimeVisibility(true); // Метод SetFooterVisibility используется для установки видимости заполнителя даты и времени слайда
    }
    headerFooterManager.setFooterText("Текст нижнего колонтитула"); // Метод SetFooterText используется для установки текста для заполнителя нижнего колонтитула слайда.
    headerFooterManager.setDateTimeText("Текст даты и времени"); // Метод SetDateTimeText используется для установки текста для заполнителя даты и времени слайда.
} finally {
    presentation.dispose();
}
```

## **Установить видимость дочернего нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на мастер-слайд через его индекс.
1. Установите видимость основного слайда и всех дочерних заполнителей нижнего колонтитула.
1. Установите текст для основного слайда и всех дочерних заполнителей нижнего колонтитула.
1. Установите текст для основного слайда и всех дочерних заполнителей даты и времени.
1. Сохраните презентацию.

Этот код на Java демонстрирует операцию:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // Метод setFooterAndChildFootersVisibility используется для установки видимости основного слайда и всех дочерних заполнителей нижнего колонтитула
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Метод setSlideNumberAndChildSlideNumbersVisibility используется для установки видимости основного слайда и всех дочерних заполнителей номера страницы
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Метод setDateTimeAndChildDateTimesVisibility используется для установки видимости основного слайда и всех дочерних заполнителей даты и времени

    headerFooterManager.setFooterAndChildFootersText("Текст нижнего колонтитула"); // Метод setFooterAndChildFootersText используется для установки текстов для основного слайда и всех дочерних заполнителей нижнего колонтитула
    headerFooterManager.setDateTimeAndChildDateTimesText("Текст даты и времени"); // Метод setDateTimeAndChildDateTimesText используется для установки текста для основного слайда и всех дочерних заполнителей даты и времени
} finally {
    presentation.dispose();
}
```

## **Установить размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, содержащую слайд, размер которого вы хотите установить.
1. Создайте другой экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), чтобы создать новую презентацию.
1. Получите ссылку на слайд (из первой презентации) через его индекс.
1. Установите заполнитель нижнего колонтитула слайда как видимый.
1. Установите заполнитель даты и времени как видимый.
1. Сохраните презентацию.

Этот код на Java демонстрирует операцию:

```java
// Создает экземпляр объекта Presentation, который представляет файл презентации
Presentation presentation = new Presentation("demo.pptx");
try {
    // Устанавливает размер слайда для созданных презентаций таким же, как для исходной
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // Метод SetSize используется для установки размера слайда с масштабированием содержимого, чтобы обеспечить соответствие
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Метод SetSize используется для установки размера слайда с максимальным размером содержимого

    // Сохраняет презентацию на диск
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить размер страницы при генерации PDF**

Некоторые презентации (например, постеры) часто конвертируются в PDF-документы. Если вы хотите конвертировать свою PowerPoint-презентацию в PDF, чтобы получить лучшие варианты печати и доступности, вам необходимо установить размеры слайдов, подходящие для PDF-документов (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/), чтобы вы могли указать свои предпочтительные настройки для слайдов. Этот код на Java показывает, как использовать свойство [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) (из класса `SlideSize`), чтобы установить конкретный размер бумаги для слайдов в презентации:

```java
// Создает экземпляр объекта Presentation, который представляет файл презентации 
Presentation presentation = new Presentation();
try {
    // Устанавливает свойство SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Устанавливает различные свойства для опций PDF
    PdfOptions opts = new PdfOptions();
    opts.setSufficientResolution(600);
    
    // Сохраняет презентацию на диск
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```