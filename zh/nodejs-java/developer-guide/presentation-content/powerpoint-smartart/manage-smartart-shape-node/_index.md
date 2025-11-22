---
title: 在 JavaScript 中创建或管理 PowerPoint SmartArt 形状节点
linktitle: 管理 SmartArt 形状节点
type: docs
weight: 30
url: /zh/nodejs-java/manage-smartart-shape-node/
keywords: SmartArt PowerPoint, SmartArt 节点, SmartArt 位置, 删除 SmartArt, 添加 SmartArt 节点, PowerPoint 演示文稿, PowerPoint Java, PowerPoint JavaScript API
description: 在 JavaScript 中管理 PowerPoint 演示文稿的 SmartArt 节点及子节点
---

## **使用 JavaScript 在 PowerPoint 演示文稿中添加 SmartArt 节点**
Aspose.Slides for Node.js via Java 提供了最简洁的 API，以最容易的方式管理 SmartArt 形状。以下示例代码将帮助在 SmartArt 形状中添加节点和子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. [在 SmartArt 形状中添加新节点](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) 于 [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--)，并在 TextFrame 中设置文本。
1. 现在，使用 [Add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) 在新添加的 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 节点中添加一个 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)，并在 TextFrame 中设置文本。
1. 保存演示文稿。

```javascript
// 加载所需的演示文稿
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            // 添加新的 SmartArt 节点
            var TemNode = smart.getAllNodes().addNode();
            // 添加文本
            TemNode.getTextFrame().setText("Test");
            // 在父节点中添加新的子节点。它将被添加到集合的末尾
            var newNode = TemNode.getChildNodes().addNode();
            // 添加文本
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // 保存演示文稿
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在特定位置添加 SmartArt 节点**
在以下示例代码中，我们说明了如何在特定位置向 SmartArt 形状的相应节点添加子节点。

1. 创建 Presentation 类的实例。
1. 使用索引获取第一张幻灯片的引用。
1. 在访问的幻灯片中添加一个 [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 形状。
1. 访问已添加 SmartArt 形状中的第一个节点。
1. 现在，在位置 2 为选定的 [**节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) 添加 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)，并设置其文本。
1. 保存演示文稿。

```javascript
// 创建演示文稿实例
var pres = new aspose.slides.Presentation();
try {
    // 访问演示文稿幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加 Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 在索引 0 处访问 SmartArt 节点
    var node = smart.getAllNodes().get_Item(0);
    // 在父节点的第 2 位置添加新的子节点
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // 添加文本
    chNode.getTextFrame().setText("Sample Text Added");
    // 保存演示文稿
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **使用 JavaScript 访问 PowerPoint 演示文稿中的 SmartArt 节点**
以下示例代码将帮助访问 SmartArt 形状内部的节点。请注意，SmartArt 的 LayoutType 是只读的，仅在添加 SmartArt 形状时设置，无法更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. 遍历 SmartArt 形状内部的所有 [**节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--)。
1. 访问并显示 SmartArt 节点的位置、层级和文本等信息。

```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            // 遍历 SmartArt 中的所有节点
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // 访问索引 i 处的 SmartArt 节点
                var node = smart.getAllNodes().get_Item(j);
                // 打印 SmartArt 节点参数
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **访问 SmartArt 子节点**
以下示例代码将帮助访问 SmartArt 形状的相应节点所属的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. 遍历 SmartArt 形状内部的所有 [**节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--)。
1. 对于每个选中的 SmartArt 形状的 [**节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode)，遍历该节点内的所有 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) 的位置、层级和文本等信息。

```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 遍历第一张幻灯片中的每个形状
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            // 遍历 SmartArt 中的所有节点
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // 访问索引 i 处的 SmartArt 节点
                var node0 = smart.getAllNodes().get_Item(i);
                // 遍历索引 i 处 SmartArt 节点的子节点
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // 访问 SmartArt 节点中的子节点
                    var node = node0.getChildNodes().get_Item(j);
                    // 打印 SmartArt 子节点参数
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在特定位置访问 SmartArt 子节点**
在以下示例代码中，我们将学习在特定位置访问 SmartArt 形状的相应节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取第一张幻灯片的引用。
1. 添加一个 [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 SmartArt 形状。
1. 访问已添加的 SmartArt 形状。
1. 访问该 SmartArt 形状中索引为 0 的节点。
1. 现在，使用 **get_Item()** 方法访问该 SmartArt 节点中位置为 1 的 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示 [**子节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) 的位置、层级和文本等信息。

```javascript
// 实例化演示文稿
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 在第一张幻灯片中添加 SmartArt 形状
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 访问索引 0 处的 SmartArt 节点
    var node = smart.getAllNodes().get_Item(0);
    // 访问父节点中位置 1 的子节点
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // 打印 SmartArt 子节点参数
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **使用 JavaScript 在 PowerPoint 演示文稿中删除 SmartArt 节点**
在本示例中，我们将学习删除 SmartArt 形状内部的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. 检查 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 是否包含超过 0 个节点。
1. 选择要删除的 SmartArt 节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) 方法删除选中的节点。
1. 保存演示文稿。

```javascript
// 加载所需的演示文稿
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 访问索引 0 处的 SmartArt 节点
                var node = smart.getAllNodes().get_Item(0);
                // 删除选中的节点
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // 保存演示文稿
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在特定位置删除 SmartArt 节点**
在本示例中，我们将学习在特定位置删除 SmartArt 形状内部的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. 选择索引为 0 的 SmartArt 形状节点。
1. 现在，检查所选 SmartArt 节点是否拥有超过 2 个子节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) 方法删除 **位置 1** 的节点。
1. 保存演示文稿。

```javascript
// 加载所需的演示文稿
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 访问索引 0 处的 SmartArt 节点
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // 删除位置 1 的子节点
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // 保存演示文稿
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **为 SmartArt 子节点设置自定义位置**
现在 Aspose.Slides for Node.js via Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) 和 [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-) 属性。下面的代码片段展示了如何自定义 SmartArtShape 的位置、大小和旋转，请注意，添加新节点会重新计算所有节点的位置和大小。通过自定义位置设置，用户可以根据需求设置节点。

```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // 将 SmartArt 形状移动到新位置
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // 更改 SmartArt 形状的宽度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // 更改 SmartArt 形状的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // 更改 SmartArt 形状的旋转角度
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **检查助理节点**
{{% alert color="primary" %}} 
在本文中，我们将进一步研究使用 Aspose.Slides for Node.js via Java 以编程方式向演示文稿幻灯片中添加的 SmartArt 形状的功能。
{{% /alert %}} 

我们将在本文的不同章节中使用以下来源 SmartArt 形状进行研究。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图示：幻灯片中的源 SmartArt 形状**|

在以下示例代码中，我们将研究如何识别 SmartArt 节点集合中的 **助理节点** 并对其进行更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第二张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)。
1. 遍历 SmartArt 形状内部的所有节点，并检查它们是否为 [**助理节点**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--)。
1. 将助理节点的状态更改为普通节点。
1. 保存演示文稿。

```javascript
// 创建演示文稿实例
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArt
            var smart = shape;
            // 遍历 SmartArt 形状的所有节点
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // 检查节点是否为助理节点
                if (node.isAssistant()) {
                    // 将助理节点设为 false 并将其设为普通节点
                    node.isAssistant();
                }
            }
        }
    }
    // 保存演示文稿
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**图示：幻灯片中 SmartArt 形状的助理节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for Node.js via Java 能够添加自定义 SmartArt 形状并设置其填充格式。本文阐述了如何使用 Aspose.Slides for Node.js via Java 创建和访问 SmartArt 形状以及设置其填充格式。

请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 通过设置其 [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 添加一个 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 形状。
1. 为 SmartArt 形状节点设置 [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--)。
1. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
// 实例化演示文稿
var pres = new aspose.slides.Presentation();
try {
    // 访问幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加 SmartArt 形状和节点
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // 设置节点填充颜色
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // 保存演示文稿
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **生成 SmartArt 子节点的缩略图**
开发者可以通过以下步骤生成 SmartArt 子节点的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)。
1. 使用索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // 通过索引获取节点的引用
    var node = smart.getNodes().get_Item(1);
    // 获取缩略图
    var slideImage = node.getShapes().get_Item(0).getImage();
    // 保存缩略图
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**支持 SmartArt 动画吗？**

是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/nodejs-java/shape-animation/)（进入、退出、强调、运动路径）并调整时间。必要时也可以对 SmartArt 节点内部的形状进行动画设置。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**

通过[替代文本](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/)进行分配和搜索。为 SmartArt 设置唯一的 AltText，即可在不依赖内部标识符的情况下找到它。

**将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

是的。Aspose.Slides 在[PDF 导出](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)过程中以高视觉保真度呈现 SmartArt，保留布局、颜色和效果。

**我可以提取整个 SmartArt 的图像吗（用于预览或报告）？**

可以。您可以将 SmartArt 形状渲染为[栅格格式](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。