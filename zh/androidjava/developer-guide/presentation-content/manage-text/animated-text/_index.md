---
title: 在 Android 上为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/androidjava/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android，在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于遵循的优化 Java 代码示例。"
---

## **向段落添加动画效果**

我们在 [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) 和 [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence) 类中添加了 [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法允许您为单个段落添加动画效果。以下示例代码演示如何为单个段落添加动画效果：
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 选择要添加效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 为选定的段落添加 Fly 动画效果
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **获取段落的动画效果**

您可能想要了解已添加到段落的动画效果——例如，在某些场景下，您想获取段落中的动画效果，以便将这些效果应用到另一个段落或形状。

Aspose.Slides for Android via Java 允许您获取包含在文本框（形状）中的段落所应用的所有动画效果。以下示例代码演示如何获取段落中的动画效果：
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


## **常见问题**

**文本动画与幻灯片切换有何区别，能否组合使用？**

文本动画控制对象在幻灯片上的随时间变化，而[切换](/slides/zh/androidjava/slide-transition/)控制幻灯片之间的切换方式。它们是独立的，可以一起使用；播放顺序由动画时间轴和切换设置决定。

**导出为 PDF 或图像时，文本动画会被保留吗？**

不会。PDF 和光栅图像是静态的，您只能看到幻灯片的单一状态，无法显示动画。若要保留动画，请导出为[视频](/slides/zh/androidjava/convert-powerpoint-to-video/)或[HTML](/slides/zh/androidjava/export-to-html5/)。

**文本动画在布局和母版中有效吗？**

应用于布局/母版对象的效果会被幻灯片继承，但其时间安排和与幻灯片级动画的交互取决于幻灯片上的最终顺序。