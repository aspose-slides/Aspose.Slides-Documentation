---
title: Заголовок и Подвал Презентации
type: docs
weight: 140
url: /java/presentation-header-and-footer/
keywords: "Заголовок и подвал PowerPoint в Java"
description: "Заголовок и подвал PowerPoint в Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/java/) предоставляет поддержку работы с текстом заголовков и подвалов слайдов, которые фактически поддерживаются на уровне мастера слайдов.

{{% /alert %}} 

[Aspose.Slides для Java](/slides/java/) предоставляет возможность управления заголовками и подвалами внутри слайдов презентации. Эти настройки фактически управляются на уровне мастера презентации.

## **Управление заголовком и подвалом в презентации**
Заметки некоторых конкретных слайдов могут быть удалены, как показано в примере ниже:

```java
// Загрузка презентации
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Установка подвала
    pres.getHeaderFooterManager().setAllFootersText("Мой текст подвала");
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
// Метод для установки текста заголовка/подвала
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

## **Управление заголовком и подвалом в раздаточных материалах и слайдах заметок**
Aspose.Slides для Java поддерживает заголовки и подмалы в раздаточных материалах и слайдах заметок. Пожалуйста, следуйте следующим шагам:

- Загрузите [Презентацию](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащую видео.
- Измените настройки заголовка и подвала для мастера заметок и всех слайдов заметок.
- Сделайте мастер-заметок и все дочерние заполнители подвала видимыми.
- Сделайте мастер-заметок и все дочерние заполнители даты и времени видимыми.
- Измените настройки заголовка и подвала только для первого слайда заметок.
- Сделайте заполнитель заголовка слайда заметок видимым.
- Установите текст в заполнителе заголовка слайда заметок.
- Установите текст в заполнителе даты и времени слайда заметок.
- Запишите измененный файл презентации.

Код представлен в следующем примере.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Измените настройки заголовка и подвала для мастера заметок и всех слайдов заметок
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // сделайте мастер-заметок и все дочерние заполнители подвала видимыми
        headerFooterManager.setFooterAndChildFootersVisibility(true); // сделайте мастер-заметок и все дочерние заполнители заголовка видимыми
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // сделайте мастер-заметок и все дочерние заполнители номера слайда видимыми
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // сделайте мастер-заметок и все дочерние заполнители даты и времени видимыми

        headerFooterManager.setHeaderAndChildHeadersText("Текст заголовка"); // установите текст для мастера заметок и всех дочерних заполнителей заголовка
        headerFooterManager.setFooterAndChildFootersText("Текст подвала"); // установите текст для мастера заметок и всех дочерних заполнителей подвала
        headerFooterManager.setDateTimeAndChildDateTimesText("Текст даты и времени"); // установите текст для мастера заметок и всех дочерних заполнителей даты и времени
    }

    // Измените настройки заголовка и подвала только для первого слайда заметок
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // сделайте видимым этот заполнитель заголовка слайда заметок

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // сделайте видимым этот заполнитель подвала слайда заметок

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // сделайте видимым этот заполнитель номера слайда слайда заметок

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // сделайте видимым этот заполнитель даты и времени слайда заметок

        headerFooterManager.setHeaderText("Новый текст заголовка"); // установите текст для заполнителя заголовка слайда заметок
        headerFooterManager.setFooterText("Новый текст подвала"); // установите текст для заполнителя подвала слайда заметок
        headerFooterManager.setDateTimeText("Новый текст даты и времени"); // установите текст для заполнителя даты и времени слайда заметок
    }
    pres.save("testresult.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```