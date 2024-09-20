---
title: Анимированный текст
type: документация
weight: 60
url: /androidjava/animated-text/
keywords: "Анимированный текст в PowerPoint"
description: "Анимированный текст в PowerPoint с использованием Java"
---

## Добавление эффектов анимации к абзацам

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). Этот метод позволяет добавлять эффекты анимации к отдельному абзацу. Этот пример кода показывает, как добавить эффект анимации к одному абзацу:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // выберите абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // добавьте эффект анимации "Лететь" к выбранному абзацу
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## Получение эффектов анимации в абзацах

Вы можете решить выяснить, какие эффекты анимации добавлены к абзацу — например, в одном сценарии вы хотите получить эффекты анимации в абзаце, потому что планируете применить эти эффекты к другому абзацу или форме.

Aspose.Slides для Android через Java позволяет вам получать все эффекты анимации, примененные к абзацам, содержащимся в текстовом фрейме (форме). Этот пример кода показывает, как получить эффекты анимации в абзаце:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Абзац \"" + paragraph.getText() + "\" имеет эффект " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```