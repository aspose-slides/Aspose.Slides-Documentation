---
title: 在 Android 上管理演示文稿中的 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt 节点
- 子节点
- 添加节点
- 节点位置
- 访问节点
- 删除节点
- 自定义位置
- 助理节点
- 填充格式
- 渲染节点
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 管理 PPT 和 PPTX 中的 SmartArt 形状节点。获取清晰的 Java 示例代码和技巧，以简化您的演示文稿。"
---
## **概述**

PowerPoint 演示文稿中的 SmartArt 图形通过包含文本并定义图表结构的节点进行组织。Aspose.Slides 允许您以编程方式操作这些 SmartArt 节点：添加新节点及其子节点，在特定位置插入子节点，访问现有节点，并读取它们的文本、层级和位置。

本文介绍如何管理 SmartArt 形状节点。它展示了如何删除节点、按索引或位置处理子节点、将助理节点更改为普通节点、调整 SmartArt 节点形状的位置、大小和旋转、设置节点填充格式，以及为 SmartArt 节点生成缩略图。

## **添加 SmartArt 节点**
Aspose.Slides for Android via Java 提供了最简洁的 API，以最容易的方式管理 SmartArt 形状。下面的示例代码演示如何在 SmartArt 形状中添加节点和子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 在 SmartArt 形状的 [**NodeCollection**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) 中 [Add a new Node](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) 并在 TextFrame 中设置文本。  
6. 现在，使用 [Add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) 在新添加的 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 节点中添加一个 [**Child Node**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) 并在 TextFrame 中设置文本。  
7. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // 添加一个新的 SmartArt 节点
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 添加文本
            TemNode.getTextFrame().setText("Test");
    
            // 在父节点中添加新的子节点。它将被添加到集合的末尾
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // 添加文本
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // 保存演示文稿
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置添加 SmartArt 节点**
以下示例代码说明如何在特定位置向 SmartArt 形状的相应节点添加子节点。

1. 创建一个 Presentation 类的实例。  
2. 使用索引获取第一张幻灯片的引用。  
3. 在已访问的幻灯片中添加一个 [**StackedList**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) 类型的 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArt) 形状。  
4. 访问已添加 SmartArt 形状的第一个节点。  
5. 为选中的 [**Node**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtNode) 在位置 2 添加 [**Child Node**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) 并设置其文本。  
6. 保存演示文稿。

```java
import com.aspose.slides.*;

// 创建演示文稿实例
Presentation pres = new Presentation();
try {
    // 访问演示文稿幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加 Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 访问索引为 0 的 SmartArt 节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 在父节点中于位置 2 添加新子节点
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // 添加文本
    chNode.getTextFrame().setText("Sample Text Added");

    // 保存演示文稿
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问 SmartArt 节点**
下面的示例代码帮助您访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 在添加形状时已确定；稍后使用 **setLayout** 更改会重新构建整个图表，从而重新计算您可能已经设置的节点位置和大小。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状内部的所有 [**Nodes**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArt#getAllNodes--)。  
6. 访问并显示 SmartArt 节点的位置、层级和文本等信息。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历 SmartArt 内的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引 i 的 SmartArt 节点
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // 打印 SmartArt 节点的参数
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问 SmartArt 子节点**
下面的示例代码帮助您访问 SmartArt 形状中各节点对应的子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状内部的所有 [**Nodes**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArt#getAllNodes--)。  
6. 对于每个选中的 SmartArt 形状 [**Node**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtNode)，遍历该节点内部的所有 [**Child Nodes**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--)。  
7. 访问并显示子节点的位置、层级和文本等信息。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历 SmartArt 内的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引 i 的 SmartArt 节点
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍历索引 i 的 SmartArt 节点中的子节点
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // 访问 SmartArt 节点中的子节点
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // 打印 SmartArt 子节点的参数
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置访问 SmartArt 子节点**
本示例演示如何在特定位置访问属于 SmartArt 形状各节点的子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。  
2. 使用索引获取第一张幻灯片的引用。  
3. 添加一个 [**StackedList**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) 类型的 SmartArt 形状。  
4. 访问已添加的 SmartArt 形状。  
5. 访问该 SmartArt 形状索引为 0 的节点。  
6. 现在，使用 **get_Item()** 方法在该节点的子节点集合中访问位置为 1 的 [**Child Node**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)。  
7. 访问并显示子节点的位置、层级和文本等信息。

```java
import com.aspose.slides.*;

// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在第一张幻灯片中添加 SmartArt 形状
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // 访问索引为 0 的 SmartArt 节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 在父节点中访问位置为 1 的子节点
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // 打印 SmartArt 子节点的参数
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **删除 SmartArt 节点**
本示例演示如何删除 SmartArt 形状内的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 检查该 SmartArt 是否拥有超过 0 个节点。  
6. 选中要删除的 SmartArt 节点。  
7. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法删除选中的节点。  
8. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引为 0 的 SmartArt 节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 删除选中的节点
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

## **从特定位置删除 SmartArt 节点**
本示例演示如何在特定位置删除 SmartArt 形状内的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 选中索引为 0 的 SmartArt 形状节点。  
6. 检查选中的 SmartArt 节点是否拥有超过 2 个子节点。  
7. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法删除 **Position 1** 的节点。  
8. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引为 0 的 SmartArt 节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 删除位置为 1 的子节点
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

## **为 SmartArt 对象中的子节点设置自定义位置**
现在 Aspose.Slides for Android via Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShape#setX-float-) 和 [Y](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShape#setY-float-) 属性。以下代码片段展示了如何自定义 SmartArtShape 的位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。通过自定义位置设置，用户可以根据需求自行安放节点。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // 将 SmartArt 形状移动到新位置
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // 更改 SmartArt 形状的宽度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // 更改 SmartArt 形状的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // 更改 SmartArt 形状的旋转
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **检查助理节点**
{{% alert color="info" %}} 

在本文中，我们将进一步探讨使用 Aspose.Slides for Android via Java 以编程方式向演示文稿幻灯片中添加的 SmartArt 形状的功能。

{{% /alert %}} 

我们将在本文的各个章节中使用以下源 SmartArt 形状进行研究。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图 1：幻灯片中的源 SmartArt 形状**|

在以下示例代码中，我们将研究如何在 SmartArt 节点集合中识别 **Assistant Nodes** 并对其进行更改。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 类型，如果是，则将选中的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状中的所有节点，并检查它们是否为 [**Assistant Nodes**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)。  
6. 将助理节点的状态更改为普通节点。  
7. 保存演示文稿。

```java
import com.aspose.slides.*;

// 创建演示文稿实例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍历第一张幻灯片中的所有形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // 遍历 SmartArt 形状的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 检查节点是否为助理节点
                if (node.isAssistant()) 
                {
                    // 将助理节点设为 false 并将其改为普通节点
                    node.setAssistant(false);
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
|**图 2：幻灯片中 SmartArt 形状的助理节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for Android via Java 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文说明如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for Android via Java 为其设置填充格式。

请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 通过设置其 [**LayoutType**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 添加一个 [SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArt) 形状。  
4. 为 SmartArt 形状的节点设置 [**FillFormat**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShape#getFillFormat--)。  
5. 将修改后的演示文稿写入为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加 SmartArt 形状和节点
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
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

## **生成 SmartArt 节点的缩略图**
开发者可以按照以下步骤生成 SmartArt 节点的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。  
2. [Add SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)。  
3. 使用索引获取节点的引用。  
4. 获取缩略图图像。  
5. 将缩略图以任意所需的图像格式保存。

```java
import com.aspose.slides.*;

// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 添加 SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 通过索引获取节点的引用
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

## **常见问题**

### 是否支持 SmartArt 动画？

是的。SmartArt 被视为普通形状，您可以 [apply standard animations](/slides/zh/androidjava/shape-animation/)（进入、退出、强调、运动路径）并调整时间。如果需要，还可以为 SmartArt 节点内部的形状单独添加动画。

### 如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？

通过设置并搜索 [alternative text](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getAlternativeText--) 来实现。为 SmartArt 指定唯一的 AltText，可在不依赖内部标识符的情况下程序化定位它。

### 将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？

会。Aspose.Slides 在 [PDF export](/slides/zh/androidjava/convert-powerpoint-to-pdf/) 期间以高视觉保真度渲染 SmartArt，保留布局、颜色和效果。

### 能否提取整个 SmartArt 的图像（用于预览或报告）？

可以。您可以将 SmartArt 形状渲染为 [raster formats](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 或 [SVG](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。