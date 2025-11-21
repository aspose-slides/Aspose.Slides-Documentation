---
title: Анимированный текст
type: docs
weight: 60
url: /ru/nodejs-java/animated-text/
keywords: "Анимированный текст в PowerPoint"
description: "Анимированный текст в PowerPoint с Java"
---

## **Добавление анимационных эффектов к абзацам**

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) и [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence). Этот метод позволяет добавить анимационные эффекты к отдельному абзацу. Пример кода показывает, как добавить анимационный эффект к отдельному абзацу:
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // выбрать абзац для добавления эффекта
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // добавить анимационный эффект Fly к выбранному абзацу
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Получение анимационных эффектов в абзацах**

Возможно, вам понадобится узнать, какие анимационные эффекты добавлены к абзацу — например, в одном случае вы хотите получить анимационные эффекты абзаца, чтобы применить их к другому абзацу или фигуре.

Aspose.Slides for Node.js via Java позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовом фрейме (shape). Пример кода показывает, как получить анимационные эффекты в абзаце:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**Чем анимация текста отличается от переходов слайдов, и можно ли их комбинировать?**

Анимация текста управляет поведением объекта во времени на слайде, тогда как [переходы](/slides/ru/nodejs-java/slide-transition/) управляют тем, как меняются слайды. Они независимы и могут использоваться вместе; порядок воспроизведения определяется временной шкалой анимации и настройками перехода.

**Сохраняются ли анимации текста при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения являются статичными, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/) или [HTML](/slides/ru/nodejs-java/export-to-html5/).

**Работают ли анимации текста в макетах и шаблоне слайда?**

Эффекты, применённые к объектам макета/шаблона, наследуются слайдами, однако их время и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на слайде.