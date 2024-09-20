---
title: Макет слайдов
type: docs
weight: 60
url: /androidjava/slide-layout/
keyword: "Установить размер слайда, установить параметры слайда, указать размер слайда, видимость нижнего колонтитула, дочерний нижний колонтитул, масштабирование содержимого, размер страницы, Java, Aspose.Slides"
description: "Установить размер и параметры слайда PowerPoint на Java"
---

Макет слайда содержит временные рамки и информацию о форматировании для всего содержимого, которое появляется на слайде. Макет определяет доступные временные рамки содержимого и их расположение.

Макеты слайдов позволяют быстро создавать и разрабатывать презентации (независимо от того, простые они или сложные). Вот некоторые из самых популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет титульного слайда**. Этот макет состоит из двух текстовых временных рамок. Одна временная рамка предназначена для заголовка, а другая — для подзаголовка.
* **Макет заголовка и содержимого**. Этот макет содержит относительно небольшую временную рамку вверху для заголовка и более крупную временную рамку для основного содержимого (графика, абзацы, маркированный список, нумерованный список, изображения и т. д.).
* **Пустой макет**. Этот макет не имеет временных рамок, поэтому позволяет создавать элементы с нуля.

Поскольку мастер-слайд является верхним иерархическим слайдом, который хранит информацию о макетах слайдов, вы можете использовать мастер-слайд, чтобы получить доступ к макетам и внести в них изменения. Макет слайда можно получить по типу или имени. Аналогично, у каждого слайда есть уникальный id, который можно использовать для доступа к нему.

В качестве альтернативы вы можете вносить изменения непосредственно в конкретный макет слайда в презентации.

* Чтобы предоставить вам возможность работать с макетами слайдов (включая те, что в мастер-слайдах), Aspose.Slides предоставляет свойства, такие как [getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) и [getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) в классе [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения дополнительной информации о работе с мастер-слайдами, в частности, см. статью [Макет слайда](https://docs.aspose.com/slides/androidjava/slide-master/).

{{% /alert %}}

## **Добавление макета слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите доступ к коллекции [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Просмотрите существующие макеты слайдов, чтобы удостовериться, что необходимый макет слайда уже существует в коллекции макетов слайдов. В противном случае добавьте нужный макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код на Java демонстрирует, как добавить макет слайда в презентацию PowerPoint:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
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
        // Файл презентации содержит только пустые и пользовательские типы макетов.
        // Но слайды макетов с пользовательскими типами имеют разные имена слайдов,
        // такие как "Заголовок", "Заголовок и содержимое" и т. д. И можно использовать эти
        // названия для выбора макета слайда.
        // Вы также можете использовать набор временных рамок типов форм. Например,
        // Титульный слайд должен иметь только тип временной рамки Заголовка и т. д.
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

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) для удаления нежелательных и неиспользуемых макетов слайдов. Этот код на Java демонстрирует, как удалить макет слайда из презентации PowerPoint:

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

Чтобы установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) и [getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--) (из класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)). Этот Java-код демонстрирует операцию:

```java
// Создает экземпляр объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Устанавливает размер слайда для созданной презентации в соответствии с размером источника
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Клонирует нужный слайд
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Установите видимость временной рамки нижнего колонтитула слайда.
1. Установите видимость временной рамки даты и времени.
1. Сохраните презентацию.

Этот код на Java показывает, как установить видимость нижнего колонтитула слайда (и выполнить связанные задачи):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // Метод isFooterVisible используется для указания, что временная рамка нижнего колонтитула слайда отсутствует
    {
        headerFooterManager.setFooterVisibility(true); // Метод setFooterVisibility используется для установки временной рамки нижнего колонтитула слайда как видимой
    }
    if (!headerFooterManager.isSlideNumberVisible()) // Метод isSlideNumberVisible используется для указания, что временная рамка номера страницы слайда отсутствует
    {
        headerFooterManager.setSlideNumberVisibility(true); // Метод setSlideNumberVisibility используется для установки временной рамки номера страницы слайда как видимой
    }
    if (!headerFooterManager.isDateTimeVisible()) // Метод isDateTimeVisible используется для указания, что временная рамка даты и времени слайда отсутствует
    {
        headerFooterManager.setDateTimeVisibility(true); // Метод SetFooterVisibility используется для установки временной рамки даты и времени слайда как видимой
    }
    headerFooterManager.setFooterText("Текст нижнего колонтитула"); // Метод SetFooterText используется для установки текста для временной рамки нижнего колонтитула слайда.
    headerFooterManager.setDateTimeText("Текст даты и времени"); // Метод SetDateTimeText используется для установки текста для временной рамки даты и времени слайда.
} finally {
    presentation.dispose();
}
```

## **Установить видимость дочернего нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на мастер-слайд через его индекс. 
1. Установите видимость главного слайда и всех дочерних временных рамок нижнего колонтитула.
1. Установите текст для главного слайда и всех дочерних временных рамок нижнего колонтитула. 
1. Установите текст для главного слайда и всех дочерних временных рамок даты и времени. 
1. Сохраните презентацию. 

Этот код на Java демонстрирует операцию:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // Метод setFooterAndChildFootersVisibility используется для установки главного слайда и всех дочерних временных рамок нижнего колонтитула как видимых
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Метод setSlideNumberAndChildSlideNumbersVisibility используется для установки главного слайда и всех дочерних временных рамок номеров страниц как видимых
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Метод setDateTimeAndChildDateTimesVisibility используется для установки главного слайда и всех дочерних временных рамок даты и времени как видимых

    headerFooterManager.setFooterAndChildFootersText("Текст нижнего колонтитула"); // Метод setFooterAndChildFootersText используется для установки текстов для главного слайда и всех дочерних временных рамок нижнего колонтитула
    headerFooterManager.setDateTimeAndChildDateTimesText("Текст даты и времени"); // Метод setDateTimeAndChildDateTimesText используется для установки текста для главного слайда и всех дочерних временных рамок даты и времени
} finally {
    presentation.dispose();
}
```

## **Установить размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию, содержащую слайд, размер которого вы хотите установить.
1. Создайте другой экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) для генерации новой презентации.
1. Получите ссылку на слайд (из первой презентации) по его индексу.
1. Установите видимость временной рамки нижнего колонтитула слайда. 
1. Установите видимость временной рамки даты и времени. 
1. Сохраните презентацию.

Этот код на Java демонстрирует операцию:

```java
// Создает экземпляр объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation("demo.pptx");
try {
    // Устанавливает размер слайда для сгенерированных презентаций в соответствии с источником
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // Метод SetSize используется для установки размера слайда с масштабированием содержимого для обеспечения соответствия
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Метод SetSize используется для установки размера слайда с максимальным размером содержимого

    // Сохраняет презентацию на диск
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить размер страницы при генерации PDF**

Некоторые презентации (такие как плакаты) часто конвертируются в PDF-документы. Если вы хотите конвертировать свою PowerPoint-презентацию в PDF, чтобы получить лучшие варианты печати и доступности, вы хотите установить размеры слайдов, которые подходят для PDF-документов (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/), чтобы позволить вам указать предпочитаемые настройки для слайдов. Этот код на Java демонстрирует, как использовать свойство [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) (из класса `SlideSize`), чтобы установить определенный размер бумаги для слайдов в презентации:

```java
// Создает экземпляр объекта Presentation, представляющего файл презентации 
Presentation presentation = new Presentation();
try {
    // Устанавливает свойство SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Устанавливает различные свойства для параметров PDF
    PdfOptions opts = new PdfOptions();
    opts.setSufficientResolution(600);
    
    // Сохраняет презентацию на диск
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```