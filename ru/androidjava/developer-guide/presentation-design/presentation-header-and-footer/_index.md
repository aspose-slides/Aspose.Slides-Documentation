---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/androidjava/presentation-header-and-footer/
keywords: "Заголовок и нижний колонтитул PowerPoint на Java"
description: "Заголовок и нижний колонтитул PowerPoint на Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/androidjava/) предоставляет поддержку работы с текстом заголовков и нижних колонтитов слайдов, которые фактически управляются на уровне главного слайда.

{{% /alert %}} 

[Aspose.Slides для Android через Java](/slides/ru/androidjava/) предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Эти элементы действительно управляются на уровне главной презентации.

## **Управление заголовком и нижним колонтитом в презентации**
Заметки некоторых конкретных слайдов могут быть удалены, как показано в примере ниже:

```java
// Загрузка презентации
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Установка нижнего колонтитула
    pres.getHeaderFooterManager().setAllFootersText("Мой текст нижнего колонтитула");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Доступ и обновление заголовка
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Сохранение презентации
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Метод для установки текста заголовка/нижнего колонтитула
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("Привет, новый заголовок");
            }
        }
    }
}
```

## **Управление заголовком и нижним колонтитом на раздаточных материалах и заметках к слайдам**
Aspose.Slides для Android через Java поддерживает заголовки и нижние колонтитулы на раздаточных материалах и заметках к слайдам. Пожалуйста, следуйте шагам ниже:

- Загрузите [Презентацию](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащую видео.
- Измените настройки заголовков и нижних колонтитулов для главных заметок и всех заметок к слайдам.
- Сделайте видимыми главные заметки и все дочерние заполнители нижнего колонтитула.
- Сделайте видимыми главные заметки и все дочерние заполнители даты и времени.
- Измените настройки заголовков и нижних колонтитулов только для первого слайда заметок.
- Сделайте видимым заполнитель заголовка слайда заметок.
- Установите текст для заполнителя заголовка слайда заметок.
- Установите текст для заполнителя даты и времени слайда заметок.
- Запишите модифицированный файл презентации.

Код, приведенный в следующем примере.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Измените настройки заголовков и нижних колонтитула для главных заметок и всех заметок к слайдам
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // сделать видимыми главные заметки и все дочерние заполнители нижнего колонтитула
        headerFooterManager.setFooterAndChildFootersVisibility(true); // сделать видимыми главные заметки и все дочерние заполнители заголовка
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // сделать видимыми главные заметки и все дочерние заполнители номера слайда
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // сделать видимыми главные заметки и все дочерние заполнители даты и времени

        headerFooterManager.setHeaderAndChildHeadersText("Текст заголовка"); // установить текст для главных заметок и всех дочерних заполнителей заголовка
        headerFooterManager.setFooterAndChildFootersText("Текст нижнего колонтитула"); // установить текст для главных заметок и всех дочерних заполнителей нижнего колонтитула
        headerFooterManager.setDateTimeAndChildDateTimesText("Текст даты и времени"); // установить текст для главных заметок и всех дочерних заполнителей даты и времени
    }

    // Измените настройки заголовков и нижних колонтитулов только для первого слайда заметок
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // сделать этот заполнитель заголовка слайда заметок видимым

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // сделать этот заполнитель нижнего колонтитула слайда заметок видимым

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // сделать этот заполнитель номера слайда видимым

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // сделать этот заполнитель даты и времени видимым

        headerFooterManager.setHeaderText("Новый текст заголовка"); // установить текст для заполнителя заголовка слайда заметок
        headerFooterManager.setFooterText("Новый текст нижнего колонтитула"); // установить текст для заполнителя нижнего колонтитула слайда заметок
        headerFooterManager.setDateTimeText("Новый текст даты и времени"); // установить текст для заполнителя даты и времени слайда заметок
    }
    pres.save("testresult.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```