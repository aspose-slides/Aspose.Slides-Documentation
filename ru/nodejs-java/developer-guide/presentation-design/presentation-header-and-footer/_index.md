---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/nodejs-java/presentation-header-and-footer/
keywords: "Заголовок и нижний колонтитул PowerPoint в JavaScript"
description: "Заголовок и нижний колонтитул PowerPoint в JavaScript"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/nodejs-java/) предоставляет поддержку работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически хранятся на уровне шаблона слайда.

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/ru/nodejs-java/) предоставляет возможность управления заголовками и нижними колонтитулами внутри презентационных слайдов. На самом деле они управляются на уровне мастер-презентации.

## **Управление заголовками и нижними колонтитулами в презентации**
Примечания некоторых конкретных слайдов можно удалить, как показано в примере ниже:
```javascript
// Загрузка презентации
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Установка нижнего колонтитула
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Доступ и обновление заголовка
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Сохранить презентацию
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Управление заголовками и нижними колонтитулами в раздаточных материалах и слайдах заметок**
Aspose.Slides for Node.js via Java поддерживает заголовки и нижние колонтитулы в раздаточных материалах и слайдах заметок. Пожалуйста, выполните следующие шаги:

- Загрузите [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок.
- Сделайте видимыми плейсхолдеры нижнего колонтитула в мастер-слайде заметок и во всех дочерних слайдах.
- Сделайте видимыми плейсхолдеры даты и времени в мастер-слайде заметок и во всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым плейсхолдер заголовка в слайде заметок.
- Задайте текст в плейсхолдере заголовка слайда заметок.
- Задайте текст в плейсхолдере даты и времени слайда заметок.
- Сохраните изменённый файл презентации.

Пример кода приведён ниже.
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Изменить настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// сделать мастер‑слайд заметок и все дочерние заполнители нижнего колонтитула видимыми
        headerFooterManager.setFooterAndChildFootersVisibility(true);// сделать мастер‑слайд заметок и все дочерние заполнители заголовка видимыми
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// сделать мастер‑слайд заметок и все дочерние заполнители номеров слайдов видимыми
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// сделать мастер‑слайд заметок и все дочерние заполнители даты и времени видимыми
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// установить текст в мастер‑слайд заметок и все дочерние заполнители заголовка
        headerFooterManager.setFooterAndChildFootersText("Footer text");// установить текст в мастер‑слайд заметок и все дочерние заполнители нижнего колонтитула
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// установить текст в мастер‑слайд заметок и все дочерние заполнители даты и времени
    }
    // Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// сделать заполнитель заголовка этого слайда заметок видимым
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// сделать заполнитель нижнего колонтитула этого слайда заметок видимым
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// сделать заполнитель номера слайда этого слайда заметок видимым
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// сделать заполнитель даты и времени этого слайда заметок видимым
        headerFooterManager.setHeaderText("New header text");// установить текст в заполнитель заголовка слайда заметок
        headerFooterManager.setFooterText("New footer text");// установить текст в заполнитель нижнего колонтитула слайда заметок
        headerFooterManager.setDateTimeText("New date and time text");// установить текст в заполнитель даты и времени слайда заметок
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Могу ли я добавить «заголовок» к обычным слайдам?**

В PowerPoint «заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул, дата/время и номер слайда.

**Что делать, если макет не содержит области нижнего колонтитула — можно ли «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API разработаны для случаев, когда плейсхолдер отсутствует или скрыт.

**Как задать начальное значение номера слайда, отличное от 1?**

Установите [первый номер слайда](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) презентации; после этого нумерация пересчитывается. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.