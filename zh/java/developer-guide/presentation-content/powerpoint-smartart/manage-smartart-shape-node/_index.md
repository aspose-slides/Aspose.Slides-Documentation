---
title: 使用 Java 管理演示文稿中的 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/java/manage-smartart-shape-node/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理 PPT 和 PPTX 中的 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---
## **概述**

PowerPoint 演示文稿中的 SmartArt 图形通过包含文本并定义图表结构的节点组织。Aspose.Slides 允许您以编程方式操作这些 SmartArt 节点：添加新节点和子节点、在特定位置插入子节点、访问现有节点以及读取它们的文本、层级和位置。

本文说明了如何管理 SmartArt 形状节点。它展示了如何删除节点、按索引或位置操作子节点、将助理节点更改为普通节点、调整 SmartArt 节点形状的位置、大小和旋转、设置节点填充格式，以及为 SmartArt 子节点生成缩略图。

## **添加 SmartArt 节点**
Aspose.Slides for Java 提供了最简易的 API 来管理 SmartArt 形状。以下示例代码演示了如何在 SmartArt 形状中添加节点和子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 在 SmartArt 形状的 **NodeCollection** 中[添加新节点](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)，并在 TextFrame 中设置文本。  
6. 现在，在新添加的 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 节点中[添加](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)一个 **子节点**，并在 TextFrame 中设置文本。  
7. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // 添加新的 SmartArt 节点
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
下面的示例代码说明了如何在 SmartArt 形状的相应节点下的特定位置添加子节点。

1. 创建 Presentation 实例。  
2. 使用索引获取第一张幻灯片的引用。  
3. 在获取的幻灯片中添加一种 **StackedList** 类型的 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArt) 形状。  
4. 访问刚添加的 SmartArt 形状中的第一个节点。  
5. 现在，为所选 **节点**在位置 2 处[添加子节点](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNode#getChildNodes--)并设置其文本。  
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

    // 访问索引 0 处的 SmartArt 节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 在父节点的第 2 位置添加新子节点
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
以下示例代码演示了如何访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且只能在添加 SmartArt 形状时设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状内部的所有 **节点**([SmartArt#getAllNodes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArt#getAllNodes--))。  
6. 访问并显示 SmartArt 节点的位置、层级和文本等信息。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历 SmartArt 中的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引 i 处的 SmartArt 节点
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // 打印 SmartArt 节点参数
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问 SmartArt 子节点**
以下示例代码演示了如何访问 SmartArt 形状中各节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状内部的所有 **节点**。  
6. 对于每个选定的 SmartArt **节点**，遍历该节点内的所有 **子节点**([SmartArtNode#getChildNodes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtNode#getChildNodes--))。  
7. 访问并显示子节点的位置、层级和文本等信息。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历 SmartArt 中的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引 i 处的 SmartArt 节点
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍历索引 i 处的 SmartArt 节点的子节点
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // 访问 SmartArt 节点中的子节点
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // 打印 SmartArt 子节点参数
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
本示例演示如何在特定位置访问属于相应节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例。  
2. 使用索引获取第一张幻灯片的引用。  
3. 添加一种 **StackedList** 类型的 SmartArt 形状。  
4. 访问已添加的 SmartArt 形状。  
5. 访问该 SmartArt 形状中索引为 0 的节点。  
6. 现在，使用 **get_Item()** 方法在该节点的子节点集合中访问位置 1 的 **子节点**([ISmartArtNode#getChildNodes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNode#getChildNodes--))。  
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
    
    // 访问索引 0 处的 SmartArt 节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 在父节点中访问位置 1 的子节点
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // 打印 SmartArt 子节点参数
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **删除 SmartArt 节点**
本示例演示如何删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 检查该 SmartArt 是否拥有大于 0 的节点。  
6. 选中要删除的 SmartArt 节点。  
7. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法删除选中的节点。  
8. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引 0 处的 SmartArt 节点
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
本示例演示如何在特定位置删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第一张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 选中索引为 0 的 SmartArt 形状节点。  
6. 检查选中的 SmartArt 节点是否拥有多于 2 个子节点。  
7. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法删除 **位置 1** 的子节点。  
8. 保存演示文稿。

```java
import com.aspose.slides.*;

// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引 0 处的 SmartArt 节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 删除位置 1 的子节点
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
现在 Aspose.Slides for Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShape#setX-float-) 和 [Y](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShape#setY-float-) 属性。下面的代码片段展示了如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意，添加新节点会重新计算所有节点的位置和大小。使用自定义位置设置，用户可以根据需求放置节点。

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

在本文中，我们将进一步探讨使用 Aspose.Slides for Java 以编程方式向演示文稿幻灯片添加 SmartArt 形状的功能。

{{% /alert %}} 

我们将在本文的不同章节中使用以下源 SmartArt 形状进行实验。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图 1: 幻灯片中的源 SmartArt 形状**|

在下面的示例代码中，我们将研究如何在 SmartArt 节点集合中识别 **助理节点** 并对其进行更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例并加载包含 SmartArt 形状的演示文稿。  
2. 使用索引获取第二张幻灯片的引用。  
3. 遍历第一张幻灯片中的所有形状。  
4. 判断形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt)。  
5. 遍历 SmartArt 形状中的所有节点，并检查它们是否为 **助理节点**([SmartArtNode#isAssistant--](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtNode#isAssistant--))。  
6. 将助理节点的状态更改为普通节点。  
7. 保存演示文稿。

```java
import com.aspose.slides.*;

// 创建演示文稿实例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
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
                    // 将助理节点设为 false，使其成为普通节点
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
|**图 2: 幻灯片中 SmartArt 形状的助理节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for Java 使添加自定义 SmartArt 形状并设置其填充格式成为可能。本文说明了如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for Java 设置其填充格式。

请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 通过设置其 **LayoutType**([ClosedChevronProcess](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)) 添加一个 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArt) 形状。  
4. 为 SmartArt 形状的节点设置 [**FillFormat**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShape#getFillFormat--)。  
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

## **生成 SmartArt 子节点的缩略图**
开发人员可以按照以下步骤生成 SmartArt 子节点的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例。  
2. [添加 SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)。  
3. 使用索引获取节点的引用。  
4. 获取缩略图图像。  
5. 将缩略图图像保存为任意所需的图像格式。

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

## **常见问答**

### 支持 SmartArt 动画吗？

是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/java/shape-animation/)（进入、退出、强调、运动路径）并调整时间。需要时也可以为 SmartArt 节点内部的形状添加动画。

### 如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？

使用[替代文本](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getAlternativeText--)进行标记并搜索。为 SmartArt 设置唯一的 AltText 可让您在不依赖内部标识符的情况下以编程方式定位它。

### 将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？

会。Aspose.Slides 在[PDF 导出](/slides/zh/java/convert-powerpoint-to-pdf/)期间以高视觉保真度渲染 SmartArt，保持布局、颜色和效果。

### 我能提取整个 SmartArt 的图像用于预览或报告吗？

可以。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getImage-int-float-float-)或[SVG](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。