---
title: 在Java中创建或管理PowerPoint SmartArt形状节点
linktitle: 管理SmartArt形状节点
type: docs
weight: 30
url: /androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint java api
description: 在Java中管理PowerPoint演示文稿中的智能艺术节点和子节点
---

## **在PowerPoint演示文稿中使用Java添加SmartArt节点**
Aspose.Slides for Android via Java提供了最简单的API，以最容易的方式管理SmartArt形状。以下示例代码将帮助添加SmartArt形状内的节点和子节点。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例，并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型，并在其为SmartArt时将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 在SmartArt形状的[**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--)中[添加新节点](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)并在TextFrame中设置文本。
1. 现在，在新添加的[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)节点中[添加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)一个[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)并在TextFrame中设置文本。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // 添加新SmartArt节点
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 添加文本
            TemNode.getTextFrame().setText("Test");
    
            // 在父节点中添加新子节点。它将被添加到集合的末尾
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

## **在特定位置添加SmartArt节点**
在下面的示例代码中，我们解释了如何在特定位置添加属于SmartArt形状各自节点的子节点。

1. 创建Presentation类的实例。
1. 使用索引获取第一个幻灯片的引用。
1. 在访问的幻灯片中添加一种[**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)类型的[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)形状。
1. 访问添加的SmartArt形状中的第一个节点。
1. 现在，为选定的[**节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)在位置2处添加[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)并设置其文本。
1. 保存演示文稿。

```java
// 创建演示文稿实例
Presentation pres = new Presentation();
try {
    // 访问演示文稿幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 访问添加的SmartArt形状中的第一个节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 在父节点中位置2添加新子节点
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // 添加文本
    chNode.getTextFrame().setText("Sample Text Added");

    // 保存演示文稿
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用Java访问PowerPoint演示文稿中的SmartArt节点**
以下示例代码将帮助访问SmartArt形状内的节点。请注意，您无法更改SmartArt的LayoutType，因为它是只读的，并且仅在添加SmartArt形状时设置。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例，并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型，并在其为SmartArt时将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 遍历SmartArt形状内的所有[**节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--)。
1. 访问并显示信息，如SmartArt节点的位置、级别和文本。

```java
// 实例化Presentation类
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 获取第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历SmartArt内的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引i处的SmartArt节点
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // 打印SmartArt节点参数
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问SmartArt子节点**
以下示例代码将帮助访问属于SmartArt形状各自节点的子节点。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例，并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型，并在其为SmartArt时将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 遍历SmartArt形状内的所有[**节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--)。
1. 对于每个选定的SmartArt形状[**节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode)，遍历特定节点内部的所有[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示信息，如[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)的位置、级别和文本。

```java
// 实例化Presentation类
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 获取第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍历SmartArt内的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 访问索引i的SmartArt节点
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍历索引i的SmartArt节点中的子节点
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // 访问SmartArt节点中的子节点
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // 打印SmartArt子节点参数
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置访问SmartArt子节点**
在这个例子中，我们将学习如何访问属于SmartArt形状各自节点中特定位置的子节点。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 使用索引获取第一个幻灯片的引用。
1. 添加一[种**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)类型的SmartArt形状。
1. 访问添加的SmartArt形状。
1. 访问索引0处的节点。
1. 现在，使用**get_Item()**方法访问访问的SmartArt节点的[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)在位置1。
1. 访问并显示信息，如[**子节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)的位置、级别和文本。

```java
// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在第一个幻灯片中添加SmartArt形状
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // 访问索引0处的SmartArt节点
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 在父节点中访问位置1处的子节点
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // 打印SmartArt子节点参数
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用Java删除PowerPoint演示文稿中的SmartArt节点**
在这个例子中，我们将学习如何删除SmartArt形状中的节点。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例，并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型，并在其为SmartArt时将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 检查[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)是否有超过0个节点。
1. 选择要删除的SmartArt节点。
1. 现在，使用[**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)方法删除所选节点。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引0处的SmartArt节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 删除所选节点
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

## **在特定位置删除SmartArt节点**
在这个例子中，我们将学习如何在特定位置删除SmartArt形状中的节点。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第一个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型并将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 选择索引0处的SmartArt形状节点。
1. 现在，检查所选的SmartArt节点是否有超过2个子节点。
1. 现在，使用[**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)方法删除**位置1**处的节点。
1. 保存演示文稿。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof SmartArt) 
        {
            // 将形状强制转换为SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 访问索引0的SmartArt节点
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 删除位置1的子节点
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

## **为SmartArt中的子节点设置自定义位置**
现在，Aspose.Slides for Android via Java支持设置[SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape)的[X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-)和[Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-)属性。 以下代码段展示了如何设置自定义SmartArtShape的位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。并且通过自定义位置设置，用户可以根据需求设置节点。

```java
// 实例化Presentation类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // 将SmartArt形状移动到新位置
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // 更改SmartArt形状的宽度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // 更改SmartArt形状的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // 更改SmartArt形状的旋转
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

在本文中，我们将进一步调查使用Aspose.Slides for Android via Java以编程方式在演示文稿幻灯片中添加的SmartArt形状的功能。

{{% /alert %}} 

我们将使用以下源SmartArt形状进行不同部分的调查。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图：幻灯片中的源SmartArt形状**|

在以下示例代码中，我们将调查如何在SmartArt节点集合中识别**助手节点**并对其进行更改。

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例，并加载带有SmartArt形状的演示文稿。
1. 使用索引获取第二个幻灯片的引用。
1. 遍历第一个幻灯片中的每个形状。
1. 检查形状是否为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)类型，并在其为SmartArt时将所选形状强制转换为[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)。
1. 遍历SmartArt形状内的所有节点，并检查它们是否为[**助手节点**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)。
1. 将助手节点的状态更改为普通节点。
1. 保存演示文稿。

```java
// 创建演示文稿实例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍历第一个幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 检查形状是否为SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // 遍历SmartArt的所有节点
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 检查节点是否为助手节点
                if (node.isAssistant()) 
                {
                    // 设置助手节点为false，变为普通节点
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
|**图：幻灯片中SmartArt形状的助手节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for Android via Java使添加自定义SmartArt形状并设置其填充格式成为可能。本文解释了如何使用Aspose.Slides for Android via Java创建和访问SmartArt形状并设置其填充格式。

请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 使用其索引获取幻灯片的引用。
1. 通过设置其[**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)来添加一个[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt)形状。
1. 为SmartArt形状节点设置[**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--)。
1. 将修改后的演示文稿写入PPTX文件。

```java
// 实例化演示文稿
Presentation pres = new Presentation();
try {
    // 访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加SmartArt形状和节点
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

## **生成SmartArt子节点的缩略图**
开发人员可以通过按照以下步骤生成SmartArt的子节点缩略图：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. [添加SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 使用其索引获取节点的引用。
1. 获取缩略图图像。
1. 以所需的图像格式保存缩略图。

```java
// 实例化表示PPTX文件的Presentation类 
Presentation pres = new Presentation();
try {
    // 添加SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 使用其索引获取节点的引用  
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