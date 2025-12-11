---
title: Анимировать текст PowerPoint на Android
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/androidjava/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- эффект анимации
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android, используя простые и оптимизированные примеры кода на Java."
---

## **Добавление эффектов анимации к абзацам**

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). Этот метод позволяет добавить эффекты анимации к отдельному абзацу. В этом примере кода показано, как добавить эффект анимации к одному абзацу:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // выбрать абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // добавить анимационный эффект Fly к выбранному абзацу
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Получение эффектов анимации абзацев**

Возможно, вам понадобится определить, какие эффекты анимации были добавлены к абзацу — например, в одном сценарии вы хотите получить эффекты анимации из абзаца, чтобы применить их к другому абзацу или фигуре.

Aspose.Slides for Android via Java позволяет получить все эффекты анимации, применённые к абзацам, содержащимся в текстовом фрейме (фигуре). В этом примере кода показано, как получить эффекты анимации в абзаце:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**Чем анимация текста отличается от переходов между слайдами и можно ли их комбинировать?**

Анимация текста управляет поведением объектов во времени на слайде, тогда как [transitions](/slides/ru/androidjava/slide-transition/) управляют тем, как меняются слайды. Они независимы и могут использоваться вместе; порядок воспроизведения определяется временной шкалой анимации и настройками переходов.

**Сохраняются ли анимации текста при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения статичны, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [video](/slides/ru/androidjava/convert-powerpoint-to-video/) или [HTML](/slides/ru/androidjava/export-to-html5/).

**Работают ли анимации текста в шаблонах и мастере слайдов?**

Эффекты, применённые к объектам шаблона/мастера, наследуются слайдами, но их тайминг и взаимодействие с анимацией уровня слайда зависят от окончательной последовательности на слайде.