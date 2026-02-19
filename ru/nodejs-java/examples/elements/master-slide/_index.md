---
title: Мастер‑слайд
type: docs
weight: 30
url: /ru/nodejs-java/examples/elements/master-slide/
keywords:
- пример кода
- мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучите примеры мастер‑слайдов Aspose.Slides для Node.js: создание, редактирование и стилизацию мастеров, заполнителей и тем в форматах PPT, PPTX и ODP с понятным кодом."
---
Мастер‑слайды образуют верхний уровень иерархии наследования слайдов в PowerPoint. **Мастер‑слайд** определяет общие элементы оформления, такие как фон, логотипы и форматирование текста. **Слайды‑макеты** наследуются от мастер‑слайдов, а **обычные слайды** наследуются от слайдов‑макетов.

В этой статье показано, как создавать, изменять и управлять мастер‑слайдами с помощью Aspose.Slides for Node.js через Java.

## **Добавить мастер‑слайд**

В этом примере показано, как создать новый мастер‑слайд, клонировав стандартный. Затем он добавляет баннер с названием компании ко всем слайдам через наследование макетов.

```js
function addMasterSlide() {
        let presentation = new aspose.slides.Presentation();
        try {
                // Клонировать стандартный мастер‑слайд.
                let defaultMasterSlide = presentation.getMasters().get_Item(0);
                let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

                let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

                // Добавить баннер с названием компании в верхней части мастер‑слайда.
                let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
                textBox.getTextFrame().setText("Company Name");
                textBox.getFillFormat().setFillType(textBoxFillType);

                let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
                let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

                let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
                paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
                paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

                // Присвоить новый мастер‑слайд слайду‑макету.
                let layoutSlide = presentation.getLayoutSlides().get_Item(0);
                layoutSlide.setMasterSlide(newMasterSlide);

                // Присвоить слайд‑макет первому слайду презентации.
                presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

                presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
        } finally {
                presentation.dispose();
        }
}
```

> 💡 **Примечание 1:** Мастер‑слайды позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения, сделанные в мастер‑слайде, автоматически отразятся на зависимых макетах и обычных слайдах.  
> 
> 💡 **Примечание 2:** Все фигуры или форматирование, добавленные в мастер‑слайд, наследуются слайдами‑макетами и, в свою очередь, всеми обычными слайдами, использующими эти макеты.  
> Изображение ниже иллюстрирует, как текстовое поле, добавленное в мастер‑слайд, автоматически отображается на конечном слайде.

![Пример наследования мастер‑слайда](master-slide-banner.png)

## **Доступ к мастер‑слайду**

Вы можете получить доступ к мастер‑слайдам через коллекцию мастеров презентации. Ниже показано, как извлечь их и работать с ними:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Изменить тип фона.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить мастер‑слайд**

Мастер‑слайды можно удалить либо по индексу, либо по ссылке.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Удалить мастер‑слайд по индексу.
        presentation.getMasters().removeAt(0);

        // Удалить мастер‑слайд по ссылке.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить неиспользуемые мастер‑слайды**

Некоторые презентации содержат мастер‑слайды, которые не используются. Удаление этих слайдов может помочь уменьшить размер файла.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Удалить все неиспользуемые мастер‑слайды (включая помеченные как Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```