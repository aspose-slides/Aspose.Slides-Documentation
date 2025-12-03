---
title: Анимировать текст PowerPoint в Java
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/java/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- эффект анимации
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Создайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Java, используя простые и оптимизированные примеры кода на Java."
---

## **Добавление анимационных эффектов к абзацам**

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence). Этот метод позволяет добавить анимационный эффект к отдельному абзацу. Ниже приведён пример кода, показывающий, как добавить анимационный эффект к отдельному абзацу:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // выбрать абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // добавить эффект анимации Fly к выбранному абзацу
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Получение анимационных эффектов абзацев**

Вы можете захотеть узнать, какие анимационные эффекты были добавлены к абзацу — например, в одном случае вам нужно получить эффекты в абзаце, чтобы применить их к другому абзацу или фигуре.

Aspose.Slides for Java позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовой рамке (фигуре). Ниже приведён пример кода, показывающий, как получить анимационные эффекты в абзаце:
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

**Чем отличаются текстовые анимации от переходов слайдов и можно ли их комбинировать?**

Текстовые анимации управляют поведением объектов во времени на слайде, тогда как [transitions](/slides/ru/java/slide-transition/) управляют тем, как меняются слайды. Они независимы и могут использоваться вместе; порядок воспроизведения определяется временной шкалой анимации и настройками перехода.

**Сохраняются ли текстовые анимации при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения статичны, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [video](/slides/ru/java/convert-powerpoint-to-video/) или [HTML](/slides/ru/java/export-to-html5/).

**Работают ли текстовые анимации в макетах и в образце слайда?**

Эффекты, применённые к объектам макета/образца, наследуются слайдами, но их тайминг и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на слайде.