---
title: Анимированный текст
type: docs
weight: 60
url: /androidjava/animated-text/
keywords: "Анимированный текст в PowerPoint"
description: "Анимированный текст в PowerPoint с помощью Java"
---

## Добавление эффектов анимации к параграфам

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). Этот метод позволяет добавлять эффекты анимации к одному параграфу. Этот пример кода показывает, как добавить эффект анимации к одному параграфу:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // выберите параграф для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // добавьте эффект анимации "Летящий" к выбранному параграфу
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## Получение эффектов анимации в параграфах

Вы можете решить узнать эффекты анимации, добавленные к параграфу — например, в одном сценарии вы хотите получить эффекты анимации в параграфе, потому что планируете применить эти эффекты к другому параграфу или фигуре.

Aspose.Slides для Android через Java позволяет вам получить все эффекты анимации, примененные к параграфам, содержащимся в текстовом фрейме (фигуре). Этот пример кода показывает, как получить эффекты анимации в параграфе:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Параграф \"" + paragraph.getText() + "\" имеет эффект " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```