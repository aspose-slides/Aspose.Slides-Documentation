---
title: Слайд
type: docs
weight: 10
url: /ru/nodejs-java/examples/elements/slide/
keywords:
- пример кода
- слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте слайдами в Aspose.Slides for Node.js: создавайте, клонируйте, переупорядочивайте, меняйте размер, задавайте фоны и применяйте переходы для презентаций PPT, PPTX и ODP."
---
В этой статье представлены примеры, демонстрирующие работу со слайдами с помощью **Aspose.Slides for Node.js via Java**. Вы узнаете, как добавлять, получать доступ, клонировать, переупорядочивать и удалять слайды, используя класс `Presentation`.

Каждый пример ниже включает краткое объяснение и фрагмент кода на JavaScript.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание:** Каждый макет слайда наследуется от мастер‑слайда, который определяет общий дизайн и структуру заполнителей. Ниже изображение показывает, как мастер‑слайды и их связанные макеты организованы в PowerPoint.

![Связь мастер‑слайда и макета](master-layout-slide.png)

## **Получить слайды по индексу**

Вы можете получать доступ к слайдам по их индексу. Это полезно для перебора или изменения конкретных слайдов.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Доступ к слайду по индексу.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Клонировать слайд**

В этом примере показано, как клонировать существующий слайд. Клонированный слайд автоматически добавляется в конец коллекции слайдов.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Переупорядочить слайды**

Вы можете изменить порядок слайдов, переместив один на новый индекс. В данном случае мы перемещаем слайд на первую позицию.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Переупорядочить слайды, переместив второй слайд на первую позицию.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить слайд**

Чтобы удалить слайд, просто укажите его и вызовите `remove`. В этом примере добавляется второй слайд, после чего оригинальный удаляется, оставляя только новый.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```