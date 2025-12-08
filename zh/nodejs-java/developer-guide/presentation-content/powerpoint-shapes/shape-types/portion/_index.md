---
title: Portion
type: docs
weight: 70
url: /zh/nodejs-java/portion/
---

## **获取部分的位置坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) 方法已添加到 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 类，允许检索该部分起始位置的坐标。
```javascript
// 实例化表示 PPTX 的 Prseetation 类
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 重塑演示文稿的上下文
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以仅对单段落中的文本部分应用超链接吗？**

是的，您可以[assign a hyperlink](/slides/zh/nodejs-java/manage-hyperlinks/)到单个部分；只有该片段可点击，而不是整个段落。

**样式继承如何工作：Portion 覆盖什么，哪些来自 Paragraph/TextFrame？**

Portion 级别的属性具有最高优先级。如果属性未在 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 上设置，引擎会从 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 获取；如果在那里也未设置，则从 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/) 样式中获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体，会发生什么？**

将应用[Font substitution rules](/slides/zh/nodejs-java/font-selection-sequence/)。文本可能会重新换行：度量、连字符和宽度可能会变化，这会影响精确定位。

**我可以为特定 Portion 设置文本填充透明度或渐变，而不影响段落的其余部分吗？**

是的，位于 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 级别的文本颜色、填充和透明度可以与相邻片段不同。