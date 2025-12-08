---
title: 管理 SmartArt
type: docs
weight: 10
url: /zh/nodejs-java/manage-smartart/
---

## **获取 SmartArt 文本**
现在已在 [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) 类和 [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) 类中添加了 TextFrame 方法。此属性允许您获取 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 中的所有文本，即使它不仅仅是节点文本。以下示例代码将帮助您获取 SmartArt 节点的文本。
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改 SmartArt 的布局类型**
为了更改 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 的布局类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList。
- 将 [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) 更改为 BasicProcess。
- 将演示文稿写入 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接线。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // 将 LayoutType 更改为 BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // 保存演示文稿
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **检查 SmartArt 的隐藏属性**
请注意：方法 [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) 如果此节点在数据模型中是隐藏节点，则返回 true。为了检查任意 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 节点的隐藏属性，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) 属性。
- 将演示文稿写入 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接线。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // 在 SmartArt 上添加节点
    var node = smart.getAllNodes().addNode();
    // 检查 isHidden 属性
    var hidden = node.isHidden();// 返回 true
    if (hidden) {
        // 执行一些操作或通知
    }
    // 保存演示文稿
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取或设置组织结构图类型**
方法 [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) 允许获取或设置与当前节点关联的组织结构图类型。为了获取或设置组织结构图类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)。
- 获取或 [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-)。
- 将演示文稿写入 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接线。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // 获取或设置组织结构图类型
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // 保存演示文稿
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **创建图片组织结构图**
Aspose.Slides for Node.js via Java 提供了一个简单的 API，能够轻松创建 PictureOrganization 图表。要在幻灯片上创建图表：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据且类型为 ChartType.PictureOrganizationChart 的图表。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建图表。
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取或设置 SmartArt 状态**
为了更改 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 的布局类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)。
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) 或 [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) SmartArt 图表的状态。
1. 将演示文稿写入 PPTX 文件。

以下代码用于创建图表。
```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // 获取或设置 SmartArt 图表的状态
    smart.setReversed(true);
    var flag = smart.isReversed();
    // 保存演示文稿
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。若所选 SmartArt 类型支持反转，`[setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/)` 方法会切换图表方向（LTR/RTL）。

**如何在同一幻灯片或另一个演示文稿中复制 SmartArt 并保留格式？**

您可以通过形状集合的 `[ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)` 克隆 SmartArt 形状，或克隆包含该形状的整个幻灯片（/slides/nodejs-java/clone-slides/）。两种方式都能保留大小、位置和样式。

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**

通过 API 将幻灯片（或整个演示文稿）转换为 PNG/JPEG（/slides/nodejs-java/convert-powerpoint-to-png/），SmartArt 将作为幻灯片的一部分被绘制出来。

**如果幻灯片上有多个 SmartArt，如何以编程方式选中特定的一个？**

常用做法是使用[替代文本](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/)（Alt Text）或 `[setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/)` 并通过 `[Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)` 根据该属性搜索形状，然后检查类型以确认它是 `[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)`。文档中描述了查找和使用形状的常见技术。