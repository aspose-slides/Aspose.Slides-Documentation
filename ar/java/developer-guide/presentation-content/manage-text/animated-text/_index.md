---
title: النص المتحرك
type: docs
weight: 60
url: /ar/java/animated-text/
keywords: "النص المتحرك في PowerPoint"
description: "النص المتحرك في PowerPoint مع Java"
---

## إضافة تأثيرات الرسوم المتحركة إلى الفقرات

لقد أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى فصول [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) و [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يظهر لك هذا الرمز المثال كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تحديد الفقرة لإضافة التأثير 
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // إضافة تأثير الرسوم المتحركة Fly إلى الفقرة المحددة
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## الحصول على تأثيرات الرسوم المتحركة في الفقرات

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة—على سبيل المثال، في سيناريو واحد، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تسمح Aspose.Slides لـ Java بالحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). يظهر لك هذا الرمز المثال كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("الفقرة \"" + paragraph.getText() + "\" تحتوي على تأثير " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```