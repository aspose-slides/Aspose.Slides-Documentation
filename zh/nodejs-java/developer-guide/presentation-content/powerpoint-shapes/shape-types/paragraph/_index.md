---
title: 段落
type: docs
weight: 60
url: /zh/nodejs-java/paragraph/
---

## **获取 TextFrame 中段落和部分的坐标**
使用 Aspose.Slides for Node.js via Java，开发人员现在可以获取 TextFrame 中段落集合里 Paragraph 的矩形坐标。它还允许您获取[段落中部分的坐标](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--)。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部分的位置。
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **获取段落的矩形坐标**
使用[**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--)方法，开发人员可以获取段落的边界矩形。
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取表格单元格文本框中段落和部分的大小**
要获取表格单元格文本框中[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph)的大小和坐标，您可以使用[Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--)和[Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--)方法。

以下示例代码演示了上述操作：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**段落和文本部分的坐标以什么单位返回？**

使用点（points）单位，1 英寸 = 72 点。这适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

是的。如果在[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)中启用了[wrapping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用以下公式将点转换为像素：pixels = points × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取“实际”的段落格式参数，并考虑样式继承？**

使用[effective paragraph formatting data structure](/slides/zh/nodejs-java/shape-effective-properties/);它返回缩进、间距、换行、RTL 等的最终合并值。