---
title: 在 Java 中创建或管理 PowerPoint 智能图形形状节点
linktitle: 管理智能图形形状节点
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
keywords: 智能图形 powerpoint, 智能图形节点, 智能图形位置, 移除智能图形, 添加智能图形节点, PowerPoint 演示文稿, powerpoint java, powerpoint java api
description: 在 Java 中管理 PowerPoint 演示文稿中的智能艺术节点和子节点
---

## **使用 Java 在 PowerPoint 演示文稿中添加智能图形节点**
Aspose.Slides for Java 提供了最简单的 API，以最容易的方式管理智能图形形状。以下示例代码将帮助您在智能图形形状中添加节点和子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 在智能图形形状的 [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) 中 [添加新节点](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) 并在文本框中设置文本。
1. 现在，向新添加的 [**智能图形**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 节点中 [添加](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) 并在文本框中设置文本。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof SmartArt) 
        {
            // 将形状转换为智能图形
            SmartArt smart = (SmartArt) shape;
    
            // 添加新的智能图形节点
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 添加文本
            TemNode.getTextFrame().setText("测试");
    
            // 在父节点中添加新子节点. 它将被添加到集合的末尾
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // 添加文本
            newNode.getTextFrame().setText("新节点已添加");
        }
    }
    
    // 保存演示文稿
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置添加智能图形节点**
在以下示例代码中，我们解释了如何在特定位置添加属于智能图形形状的各自节点的子节点。

1. 创建一个 Presentation 类的实例。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 在访问的幻灯片中添加类型为 [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) 的 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 形状。
1. 访问已添加智能图形形状中的第一个节点。
1. 现在，在选择的 [**节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) 的位置 2 中添加 [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) 并设置其文本。
1. 保存演示文稿。

```java
// 创建演示文稿实例
Presentation pres = new Presentation();
try {
    // 访问演示文稿幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加智能图形 IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 访问添加的智能图形形状中的第一个节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 在父节点的第 2 个位置添加新子节点
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // 添加文本
    chNode.getTextFrame().setText("添加的示例文本");

    // 保存演示文稿
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用 Java 访问 PowerPoint 演示文稿中的智能图形节点**
以下示例代码将帮助您访问智能图形形状内部的节点。请注意，您无法更改智能图形的 LayoutType，因为它是只读的，并且在添加智能图形形状时设置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 遍历智能图形形状内部的所有 [**节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--)。
1. 访问并显示信息，如智能图形节点位置、级别和文本。

```java
// 实例化演示文稿类
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 获取第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状转换为智能图形
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历智能图形内部的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引为 i 的智能图形节点
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // 打印智能图形节点参数
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问智能图形子节点**
以下示例代码将帮助您访问属于智能图形形状的各自节点的子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 遍历智能图形形状内部的所有 [**节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--)。
1. 对于每个选定的智能图形形状 [**节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode)，遍历特定节点内部的所有 [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示信息，如 [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) 的位置、级别和文本。

```java
// 实例化演示文稿类
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 获取第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状转换为智能图形
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历智能图形内部的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引为 i 的智能图形节点
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍历索引为 i 的智能图形节点中的子节点
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // 访问智能图形节点中的子节点
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // 打印智能图形子节点参数
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置访问智能图形子节点**
在此示例中，我们将学习如何访问属于各自智能图形形状节点的子节点在某个特定位置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 添加类型为 [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) 的智能图形形状。
1. 访问添加的智能图形形状。
1. 访问智能图形形状中索引为 0 的节点。
1. 现在，使用 **get_Item()** 方法访问智能图形节点的职位 1 的 [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--)。
1. 访问并显示信息，如 [**子节点**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) 的位置、级别和文本。

```java
// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在第一个幻灯片中添加智能图形形状
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // 访问索引为 0 的智能图形节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 在父节点的职位 1 中访问子节点
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // 打印智能图形子节点参数
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用 Java 移除 PowerPoint 演示文稿中的智能图形节点**
在此示例中，我们将学习如何移除智能图形形状内部的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 检查 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 是否有超过 0 个节点。
1. 选择要删除的智能图形节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法移除所选节点。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状转换为智能图形
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引为 0 的智能图形节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 移除所选节点
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // 保存演示文稿
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置移除智能图形节点**
在此示例中，我们将学习如何在特定位置移除智能图形形状内部的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 选择索引为 0 的智能图形形状节点。
1. 现在，检查所选智能图形节点是否有超过 2 个子节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法移除位置 **1** 的节点。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof SmartArt) 
        {
            // 将形状转换为智能图形
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引为 0 的智能图形节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 移除位置 1 的子节点
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // 保存演示文稿
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为智能图形中的子节点设置自定义位置**
现在 Aspose.Slides for Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) 和 [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-) 属性。代码片段如下，展示了如何设置自定义智能图形位置、大小和旋转，同时请注意，添加新节点会导致所有节点的位置和大小重新计算。使用自定义位置设置，用户可以根据需要设置节点。

```java
// 实例化演示文稿类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // 将智能图形形状移动到新位置
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // 改变智能图形形状的宽度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // 改变智能图形形状的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // 改变智能图形形状的旋转
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **检查助手节点**
{{% alert color="primary" %}} 

在本文中，我们将进一步研究使用 Aspose.Slides for Java 程序化添加到演示文稿幻灯片中的智能图形形状的特性。

{{% /alert %}} 

我们将在本文的不同部分中使用以下源智能图形形状进行调查。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图：幻灯片中的源智能图形形状**|

在以下示例代码中，我们将研究如何识别智能图形节点集合中的 **助手节点** 并对其进行更改。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载包含智能图形形状的演示文稿。
1. 通过使用其索引获取第二个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 类型，并在其为智能图形时将所选形状转换为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt)。
1. 遍历智能图形形状内部的所有节点，并检查它们是否为 [**助手节点**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--)。
1. 将助手节点的状态更改为普通节点。
1. 保存演示文稿。

```java
// 创建演示文稿实例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为智能图形类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状转换为智能图形
            ISmartArt smart = (SmartArt) shape;
    
            // 遍历智能图形形状的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 检查节点是否为助手节点
                if (node.isAssistant()) 
                {
                    // 将助手节点设置为 false，变为普通节点
                    node.isAssistant();
                }
            }
        }
    }
    
    // 保存演示文稿
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**图：智能图形形状内的助手节点更改**|

## **设置节点的填充格式**
Aspose.Slides for Java 使添加自定义智能图形形状并设置其填充格式成为可能。本文将解释如何创建和访问智能图形形状以及如何使用 Aspose.Slides for Java 设置其填充格式。

请按照以下步骤进行操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 通过设置其 [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) 形状。
1. 为智能图形形状的节点设置 [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--)。
1. 将修改后的演示文稿写入 PPTX 文件。

```java
// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加智能图形形状和节点
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("一些文本");
    
    // 设置节点填充颜色
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // 保存演示文稿
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **生成智能图形子节点的缩略图**
开发人员可以通过按照以下步骤生成智能图形子节点的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. [添加智能图形](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 通过使用其索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像保存为所需的任何图像格式。

```java
// 实例化表示 PPTX 文件的演示文稿类 
Presentation pres = new Presentation();
try {
    // 添加智能图形 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 通过使用其索引获取节点的引用  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // 获取缩略图
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // 保存缩略图
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```