---
title: 使用 JavaScript 在 PowerPoint 演示文稿中管理 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "学习使用 Aspose.Slides for Node.js 通过清晰的 JavaScript 代码示例构建和编辑 PowerPoint SmartArt，从而加快幻灯片设计和自动化。"
---

## **获取 SmartArt 文本**
现在已在 [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) 类中加入 TextFrame 方法。此属性允许您获取 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 中的所有文本，即使它不仅限于节点文本。以下示例代码将帮助您获取 SmartArt 节点的文本。
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

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList。
- 将 [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) 更改为 BasicProcess。
- 将演示文稿写为 PPTX 文件。

以下示例中，我们在两个形状之间添加了连接线。
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


## **检查 SmartArt 的可见性属性**
请注意：方法 [SmartArtNode.isHidden()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) 若该节点在数据模型中为隐藏节点则返回 true。为了检查 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 任意节点的隐藏属性，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 [visibility](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) 属性。
- 将演示文稿写为 PPTX 文件。

以下示例中，我们在两个形状之间添加了连接线。
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


## **获取或设置组织图表类型**
方法 [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) 允许获取或设置与当前节点关联的组织图表类型。为了获取或设置组织图表类型，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)。
- 获取或 [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-)。
- 将演示文稿写为 PPTX 文件。

以下示例中，我们在两个形状之间添加了连接线。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加 SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // 获取或设置组织图表类型
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // 保存演示文稿
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **创建图片组织图表**
Aspose.Slides for Node.js via Java 提供了一个简易 API，可轻松创建 PictureOrganization 图表。要在幻灯片上创建图表，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据并指定类型 (ChartType.PictureOrganizationChart) 的图表。
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
为了更改 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 的状态，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)。
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) 或 [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) SmartArt 图表的状态。
1. 将演示文稿写为 PPTX 文件。

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


## **FAQ**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。如果所选 SmartArt 类型支持反转，[setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) 方法会切换图表方向（LTR/RTL）。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以通过形状集合 [clone the SmartArt shape](/slides/zh/nodejs-java/shape-manipulations/)（[ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)）或 [clone the entire slide](/slides/zh/nodejs-java/clone-slides/) 来复制包含此形状的整张幻灯片。两种方式都能保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[Render the slide](/slides/zh/nodejs-java/convert-powerpoint-to-png/)（或整个演示文稿）为 PNG/JPEG，通过将幻灯片/演示文稿转换为图像的 API 实现——SmartArt 将作为幻灯片的一部分绘制。

**如果幻灯片上有多个 SmartArt，如何以编程方式选择特定的一个？**

常用做法是使用 [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/)（Alt Text）或 [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/)，然后使用 [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 按该属性搜索形状，再检查类型以确认是 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)。文档中描述了查找和操作形状的典型技术。