---
title: نص متحرك
type: docs
weight: 60
url: /ar/androidjava/animated-text/
keywords: "نص متحرك في PowerPoint"
description: "نص متحرك في PowerPoint باستخدام Java"
---

## إضافة تأثيرات الحركة إلى الفقرات

أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى فئات [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). تتيح لك هذه الطريقة إضافة تأثيرات حركة إلى فقرة واحدة. يعرض لك هذا الكود النموذجي كيفية إضافة تأثير حركة إلى فقرة واحدة:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اختيار الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // إضافة تأثير الحركة الطيران إلى الفقرة المحددة
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## الحصول على تأثيرات الحركة في الفقرات

يمكنك أن تقرر معرفة تأثيرات الحركة المضافة إلى فقرة ما - على سبيل المثال، في سيناريو واحد، تريد الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تتيح لك Aspose.Slides for Android عبر Java الحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). يعرض لك هذا الكود النموذجي كيفية الحصول على تأثيرات الحركة في فقرة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("الفقرة \"" + paragraph.getText() + "\" لديها تأثير " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```