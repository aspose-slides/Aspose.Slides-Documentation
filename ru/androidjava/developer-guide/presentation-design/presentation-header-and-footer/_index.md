---
title: Управление заголовками и нижними колонтитулами презентаций на Android
linktitle: Заголовок & Нижний колонтитул
type: docs
weight: 140
url: /ru/androidjava/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный материал
- заметки
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides for Android via Java для добавления и настройки заголовков и нижних колонтитулов в презентациях PowerPoint и OpenDocument, чтобы придать им профессиональный вид."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/androidjava/) предоставляет возможность работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически управляются на уровне шаблона слайда.

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/ru/androidjava/) предоставляет функцию управления заголовками и нижними колонтитулами внутри презентационных слайдов. Они действительно управляются на уровне мастер‑презентации.

## **Управление заголовками и нижними колонтитулами в презентации**
Примечания отдельного слайда могут быть удалены, как показано в примере ниже:
```java
// Загрузка презентации
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Установка нижнего колонтитула
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
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
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Управление заголовками и нижними колонтитулами в раздаточных материалах и слайдах заметок**
Aspose.Slides for Android via Java поддерживает заголовки и нижние колонтитулы в раздаточных материалах и слайдах заметок. Пожалуйста, выполните следующие шаги:

- Загрузите [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастер‑страницы заметок и всех слайдов заметок.
- Сделайте видимыми плейсхолдеры нижнего колонтитула на мастере слайдов заметок и всех дочерних слайдах.
- Сделайте видимыми плейсхолдеры даты и времени на мастере слайдов заметок и всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым плейсхолдер заголовка на слайде заметок.
- Установите текст в плейсхолдер заголовка слайда заметок.
- Установите текст в плейсхолдер даты‑времени слайда заметок.
- Запишите изменённый файл презентации.

Ниже приведён пример с кодом.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Изменить настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // сделать видимыми мастер‑слайд заметок и все дочерние заполнительные элементы нижнего колонтитула
        headerFooterManager.setFooterAndChildFootersVisibility(true); // сделать видимыми мастер‑слайд заметок и все дочерние заполнительные элементы заголовка
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // сделать видимыми мастер‑слайд заметок и все дочерние заполнительные элементы номера слайда
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // сделать видимыми мастер‑слайд заметок и все дочерние заполнительные элементы даты и времени

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // установить текст в мастер‑слайд заметок и все дочерние заполнительные элементы заголовка
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // установить текст в мастер‑слайд заметок и все дочерние заполнительные элементы нижнего колонтитула
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // установить текст в мастер‑слайд заметок и все дочерние заполнительные элементы даты и времени
    }

    // Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // сделать видимым заполнительный элемент заголовка этого слайда заметок

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // сделать видимым заполнительный элемент нижнего колонтитула этого слайда заметок

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // сделать видимым заполнительный элемент номера слайда этого слайда заметок

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // сделать видимым заполнительный элемент даты‑времени этого слайда заметок

        headerFooterManager.setHeaderText("New header text"); // установить текст в заполнительный элемент заголовка слайда заметок
        headerFooterManager.setFooterText("New footer text"); // установить текст в заполнительный элемент нижнего колонтитула слайда заметок
        headerFooterManager.setDateTimeText("New date and time text"); // установить текст в заполнительный элемент даты‑времени слайда заметок
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Могу ли я добавить «заголовок» на обычные слайды?**

В PowerPoint «заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides такие же ограничения: заголовок только для заметок/раздаточных, а на слайдах — нижний колонтитул, дата/время и номер слайда.

**Что делать, если в макете нет области нижнего колонтитула — можно ли включить её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API разработаны для ситуаций, когда плейсхолдер отсутствует или скрыт.

**Как задать начальный номер слайда, отличный от 1?**

Установите [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); после этого нумерация пересчитывается. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они рендерятся как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.