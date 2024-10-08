---
title: 动画文本
type: docs
weight: 60
url: /java/animated-text/
keywords: "PowerPoint中的动画文本"
description: "使用Java在PowerPoint中创建动画文本"
---

## 为段落添加动画效果

我们向[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence)和[**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence)类添加了[**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-)方法。该方法允许您为单个段落添加动画效果。以下示例代码演示了如何为单个段落添加动画效果：

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 选择要添加效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 为选定的段落添加飞入动画效果
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## 获取段落中的动画效果

您可能想要查找添加到段落的动画效果——例如，在某种情况下，您希望获取段落中的动画效果，因为您计划将这些效果应用到另一个段落或形状上。

Aspose.Slides for Java允许您获取应用于文本框（形状）中包含的段落的所有动画效果。以下示例代码展示了如何获取段落中的动画效果：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("段落 \"" + paragraph.getText() + "\" 具有 " + effects[0].getType() + " 效果。");
    }
} finally {
    pres.dispose();
}
```