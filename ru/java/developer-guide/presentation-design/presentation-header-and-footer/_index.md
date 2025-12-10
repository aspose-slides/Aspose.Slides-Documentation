---
title: Управление заголовками и нижними колонтитулами презентаций на Java
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides для Java, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument, обеспечивая профессиональный вид."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/java/) предоставляет возможность работать с текстом заголовков и нижних колонтитулов слайдов, которые фактически управляются на уровне шаблона слайда.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/ru/java/) предоставляет возможность управления заголовками и нижними колонтитулами внутри презентационных слайдов. На самом деле они управляются на уровне мастер‑шаблона презентации.

## **Управление заголовками и нижними колонтитулами в презентации**
Примечания отдельного слайда могут быть удалены, как показано в примере ниже:
```java
// Загрузить презентацию
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

    // Сохранить презентацию
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
Aspose.Slides for Java поддерживает заголовки и нижние колонтитулы в раздаточных материалах и слайдах заметок. Пожалуйста, выполните следующие шаги:

- Загрузите [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) содержащий видео.
- Измените настройки заголовка и нижнего колонтитула для мастер‑страницы заметок и всех слайдов заметок.
- Сделайте видимыми заполнители нижних колонтитулов на мастер‑слайде заметок и всех дочерних слайдах.
- Сделайте видимыми заполнители даты и времени на мастер‑слайде заметок и всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым заполнитель заголовка на слайде заметок.
- Установите текст в заполнитель заголовка слайда заметок.
- Установите текст в заполнитель даты и времени слайда заметок.
- Сохраните изменённый файл презентации.

Пример кода приведён ниже.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Изменить настройки заголовка и нижнего колонтитула для мастер‑страницы заметок и всех слайдов заметок
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители нижних колонтитулов видимыми
        headerFooterManager.setFooterAndChildFootersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители заголовков видимыми
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители номеров слайдов видимыми
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители даты и времени видимыми

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // задать текст мастер‑слайду заметок и всем дочерним заполнителям заголовков
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // задать текст мастер‑слайду заметок и всем дочерним заполнителям нижних колонтитулов
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // задать текст мастер‑слайду заметок и всем дочерним заполнителям даты и времени
    }

    // Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // сделать этот заполнитель заголовка слайда заметок видимым

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // сделать этот заполнитель нижнего колонтитула слайда заметок видимым

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // сделать этот заполнитель номера слайда заметок видимым

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // сделать этот заполнитель даты и времени слайда заметок видимым

        headerFooterManager.setHeaderText("New header text"); // задать текст заполнителю заголовка слайда заметок
        headerFooterManager.setFooterText("New footer text"); // задать текст заполнителю нижнего колонтитула слайда заметок
        headerFooterManager.setDateTimeText("New date and time text"); // задать текст заполнителю даты и времени слайда заметок
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я добавить "заголовок" на обычные слайды?**

В PowerPoint "заголовок" существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаемыми элементами являются нижний колонтитул, дата/время и номер слайда. В Aspose.Slides эти ограничения такие же: заголовок доступен только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Что если в макете нет области нижнего колонтитула — могу ли я включить её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как установить начальный номер слайда, отличный от 1?**

Установите у презентации [первый номер слайда](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если эти элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержанием.