---
title: 使用 Java 在簡報中管理 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/java/manage-smartart-shape-node/
keywords:
- SmartArt 節點
- 子節點
- 新增節點
- 節點位置
- 存取節點
- 移除節點
- 自訂位置
- 助理節點
- 填充格式
- 渲染節點
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理 PPT 與 PPTX 中的 SmartArt 形狀節點。獲得清晰的程式範例與技巧，簡化您的簡報。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取其文字、層級與位置。

本文說明如何管理 SmartArt 形狀節點。內容包括移除節點、透過索引或位置操作子節點、將助理節點變更為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點填充格式，以及為 SmartArt 子節點產生縮圖。

## **新增 SmartArt 節點**
Aspose.Slides for Java 提供了最簡單的 API 以最容易的方式管理 SmartArt 形狀。以下範例程式碼說明如何在 SmartArt 形狀中新增節點與子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 在 SmartArt 形狀的 [**NodeCollection**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt#getAllNodes--) 中[新增節點](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)，並於 TextFrame 中設定文字。
1. 接著，於剛剛新增的 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 節點中[新增](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)一個[**子節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNode#getChildNodes--)，並於 TextFrame 中設定文字。
1. 儲存簡報。

```java
// 載入所需的簡報
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof SmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // 新增一個 SmartArt 節點
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 新增文字
            TemNode.getTextFrame().setText("Test");
    
            // 在父節點中新增子節點。它將被加入至集合的末端
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // 新增文字
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // 儲存簡報
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置新增 SmartArt 節點**
以下範例程式碼說明如何在 SmartArt 形狀的各個節點下的子節點於特定位置新增。

1. 建立 Presentation 類別的執行個體。
1. 依索引取得第一張投影片的參照。
1. 在取得的投影片中加入一個 [**StackedList**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType#StackedList) 類型的 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 形狀。
1. 取得已加入 SmartArt 形狀的第一個節點。
1. 為選取的 [**節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtNode) 在位置 2 新增 [**子節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNode#getChildNodes--)，並設定其文字。
1. 儲存簡報。

```java
// 建立簡報實例
Presentation pres = new Presentation();
try {
    // 存取簡報投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增 Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 取得索引 0 的 SmartArt 節點
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 在父節點的第 2 個位置新增子節點
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // 新增文字
    chNode.getTextFrame().setText("Sample Text Added");

    // 儲存簡報
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取 SmartArt 節點**
以下範例程式碼說明如何存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在加入 SmartArt 形狀時設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 逐一遍歷 SmartArt 形狀內的所有 [**節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt#getAllNodes--)。
1. 存取並顯示 SmartArt 節點的位置、層級與文字等資訊。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍歷 SmartArt 內的所有節點
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 取得索引 i 的 SmartArt 節點
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // 輸出 SmartArt 節點參數
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取 SmartArt 子節點**
以下範例程式碼說明如何存取屬於 SmartArt 形狀各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 逐一遍歷 SmartArt 形狀內的所有 [**節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt#getAllNodes--)。
1. 對每個選取的 SmartArt 形狀 [**節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtNode)，再遍歷其內的所有 [**子節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtNode#getChildNodes--)。
1. 存取並顯示子節點的位置、層級與文字等資訊。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍歷 SmartArt 內的所有節點
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 取得索引 i 的 SmartArt 節點
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍歷索引 i 的 SmartArt 節點內的子節點
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // 取得 SmartArt 節點的子節點
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // 輸出 SmartArt 子節點參數
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在特定位置存取 SmartArt 子節點**
本範例說明如何在特定位置存取屬於 SmartArt 形狀各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。
1. 依索引取得第一張投影片的參照。
1. 新增一個 [**StackedList**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType#StackedList) 類型的 SmartArt 形狀。
1. 取得已加入的 SmartArt 形狀。
1. 取得該 SmartArt 形狀索引為 0 的節點。
1. 使用 **get_Item()** 方法，於索引為 0 的節點中取得位置 1 的 [**子節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNode#getChildNodes--)。
1. 存取並顯示子節點的位置、層級與文字等資訊。

```java
// 實例化簡報
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在第一張投影片中加入 SmartArt 形狀
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // 取得索引 0 的 SmartArt 節點
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 取得父節點中位置 1 的子節點
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // 輸出 SmartArt 子節點參數
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除 SmartArt 節點**
本範例說明如何移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 檢查該 SmartArt 是否有超過 0 個節點。
1. 選取要刪除的 SmartArt 節點。
1. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法移除所選節點。
1. 儲存簡報。

```java
// 載入所需的簡報
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 取得索引 0 的 SmartArt 節點
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 移除所選節點
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // 儲存簡報
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **從特定位置移除 SmartArt 節點**
本範例說明如何在特定位置移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 選取索引為 0 的 SmartArt 形狀節點。
1. 檢查所選 SmartArt 節點是否有超過 2 個子節點。
1. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法，移除 **位置 1** 的子節點。
1. 儲存簡報。

```java
// 載入所需的簡報
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof SmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 取得索引 0 的 SmartArt 節點
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 移除位置 1 的子節點
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // 儲存簡報
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **為 SmartArt 物件中的子節點設定自訂位置**
現在 Aspose.Slides for Java 支援設定 [SmartArtShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#setX-float-) 與 [Y](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#setY-float-) 屬性。以下程式碼片段示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，且請注意新增節點會重新計算所有節點的位置與大小。使用自訂位置設定時，使用者可依需求調整節點。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // 將 SmartArt 形狀移動到新位置
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // 更改 SmartArt 形狀的寬度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // 更改 SmartArt 形狀的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // 更改 SmartArt 形狀的旋轉
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **檢查助理節點**
{{% alert color="primary" %}} 

在本文中，我們將進一步探討使用 Aspose.Slides for Java 以程式方式向簡報投影片中加入 SmartArt 形狀的功能。

{{% /alert %}} 

我們將在本文的不同章節中使用下列來源 SmartArt 形狀進行測試。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**圖示：投影片中的來源 SmartArt 形狀**|

以下範例程式碼說明如何辨識 SmartArt 節點集合中的 **助理節點**，以及如何變更它們。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第二張投影片的參照。
1. 逐一遍歷第一張投影片內的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt)。
1. 逐一遍歷 SmartArt 形狀內的所有節點，並檢查它們是否為 [**助理節點**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtNode#isAssistant--)。
1. 將助理節點的狀態變更為普通節點。
1. 儲存簡報。

```java
// 建立簡報實例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀類型轉換為 SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // 遍歷 SmartArt 形狀的所有節點
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 檢查節點是否為助理節點
                if (node.isAssistant()) 
                {
                    // 將助理節點設為 false，變為普通節點
                    node.isAssistant();
                }
            }
        }
    }
    
    // 儲存簡報
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**圖示：已在投影片中的 SmartArt 形狀內變更助理節點**|

## **設定節點的填充格式**
Aspose.Slides for Java 讓您能夠新增自訂 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for Java 設定其填充格式。

請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 以設定其 [**LayoutType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 的方式加入 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArt) 形狀。
1. 為 SmartArt 形狀的節點設定 [**FillFormat**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getFillFormat--)。
1. 將修改後的簡報寫出為 PPTX 檔案。

```java
// 實例化簡報
Presentation pres = new Presentation();
try {
    // 取得投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增 SmartArt 形狀和節點
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // 設定節點填充顏色
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // 儲存簡報
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **產生 SmartArt 子節點的縮圖**
開發人員可依照以下步驟產生 SmartArt 子節點的縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。
1. [新增 SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 依索引取得節點的參照。
1. 取得縮圖影像。
1. 以任意想要的影像格式儲存縮圖。

```java
// 實例化代表 PPTX 檔案的 Presentation 類別 
Presentation pres = new Presentation();
try {
    // 新增 SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 依索引取得節點的參照  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // 取得縮圖
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // 儲存縮圖
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問答**

**是否支援 SmartArt 動畫？**

是。SmartArt 被視為一般形狀，您可以套用[標準動畫](/slides/zh-hant/java/shape-animation/)（進場、退場、強調、移動路徑）並調整時間。必要時也可為 SmartArt 節點內的形狀設定動畫。

**如果不知道內部 ID，如何在投影片中可靠定位特定 SmartArt？**

透過[替代文字](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getAlternativeText--) 進行指派與搜尋。為 SmartArt 設定唯一的 AltText 後，便可在程式中直接找到它，而不必依賴內部識別碼。

**將簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 時會高忠實度呈現 SmartArt，保留版面、顏色與效果。

**我可以擷取完整 SmartArt 的影像（供預覽或報告使用）嗎？**

可以。您可將 SmartArt 形狀渲染為[點陣格式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-)或[SVG](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，以取得可縮放的向量輸出，適用於縮圖、報告或網頁使用。