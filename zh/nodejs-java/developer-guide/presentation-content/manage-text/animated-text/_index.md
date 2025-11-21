---
title: 动画文字
type: docs
weight: 60
url: /zh/nodejs-java/animated-text/
keywords: "PowerPoint 中的动画文字"
description: "使用 Java 的 PowerPoint 动画文字"
---

## **向段落添加动画效果**

我们在 [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) 和 [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) 类中添加了 [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) 方法。此方法允许您向单个段落添加动画效果。下面的示例代码演示了如何向单个段落添加动画效果：
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 选择要添加效果的段落
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // 为选定的段落添加 Fly 动画效果
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **获取段落中的动画效果**

您可能需要查找已添加到段落的动画效果——例如，在某些情况下，您想获取段落中的动画效果，因为您计划将这些效果应用于其他段落或形状。  
Aspose.Slides for Node.js via Java 允许您获取应用于文本框（形状）中段落的所有动画效果。下面的示例代码演示了如何获取段落中的动画效果：
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


## **常见问题**

**文本动画与幻灯片切换有何区别，是否可以组合使用？**  
文本动画控制对象在幻灯片上的随时间行为，而 [transitions](/slides/zh/nodejs-java/slide-transition/) 控制幻灯片之间的切换方式。它们相互独立，但可以一起使用；播放顺序由动画时间轴和切换设置决定。

**导出为 PDF 或图像时，文本动画会被保留吗？**  
不会。PDF 和光栅图像是静态的，您只能看到幻灯片的单一状态而没有动画。若要保留动画，请使用 [video](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 或 [HTML](/slides/zh/nodejs-java/export-to-html5/) 导出。

**文本动画在布局和幻灯片母版中有效吗？**  
应用于布局/母版对象的效果会被幻灯片继承，但其时间安排和与幻灯片级动画的交互取决于幻灯片上的最终顺序。