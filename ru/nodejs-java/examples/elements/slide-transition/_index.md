---
title: Переход слайда
type: docs
weight: 110
url: /ru/nodejs-java/examples/elements/slide-transition/
keywords:
- пример кода
- переход слайда
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте переходы слайдов в Aspose.Slides для Node.js: добавляйте, настраивайте и упорядочивайте эффекты и длительности с примерами для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется применение эффектов переходов слайдов и таймингов с помощью **Aspose.Slides for Node.js via Java**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Применить плавный переход.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к переходу слайда**

Прочитайте тип перехода, в данный момент назначенный слайду.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Доступ к типу перехода.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить переход слайда**

Очистите любой эффект перехода, установив тип в `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Удалить переход, установив None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается перед автоматическим переходом.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // в миллисекундах.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```