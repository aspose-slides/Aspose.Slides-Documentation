---
title: 在 Android 上管理簡報中的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/androidjava/manage-smartart-shape-node/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 管理 PPT 與 PPTX 中的 SmartArt 形狀節點。取得清晰的 Java 程式碼範例與技巧，以簡化您的簡報。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形是透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式處理這些 SmartArt 節點：新增節點和子節點、在特定位置插入子節點、存取現有節點，以及讀取它們的文字、層級和位置。

本文說明如何管理 SmartArt 形狀節點。它展示了如何移除節點、以索引或位置處理子節點、將助理節點變更為一般節點、調整 SmartArt 節點形狀的位置、大小與旋轉角度、設定節點的填充格式，以及產生 SmartArt 節點的縮圖影像。

## **新增 SmartArt 節點**
Aspose.Slides for Android via Java 已提供最簡易的 API 以最簡單的方式管理 SmartArt 形狀。以下範例程式碼說明如何在 SmartArt 形狀內部新增節點與子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 在 SmartArt 形狀的 **NodeCollection** 中[新增新節點](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)，並在 TextFrame 中設定文字。
1. 現在，於剛新增的 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 節點中[新增](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) **子節點**，並在 TextFrame 中設定文字。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 載入所需的簡報
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof SmartArt) 
        {
            // 將形狀型別轉換為 SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // 新增一個 SmartArt 節點
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 新增文字
            TemNode.getTextFrame().setText("Test");
    
            // 在父節點中新增子節點。它將被添加到集合的末尾
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
以下範例程式碼說明如何在特定位置為 SmartArt 形狀的對應節點新增子節點。

1. 建立 Presentation 類別的執行個體。
1. 以 Index 取得第一張投影片的參照。
1. 在存取的投影片中加入 **StackedList** 類型的 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 形狀。
1. 存取已加入的 SmartArt 形狀中的第一個節點。
1. 現在，於選取的 **節點** 在位置 2 新增 **子節點**，並設定其文字。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 建立簡報實例
Presentation pres = new Presentation();
try {
    // 取得簡報投影片
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
以下範例程式碼說明如何存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 是在加入形狀時決定的；之後使用 **setLayout** 變更會重新建構整個圖表，因而會重新計算先前設定的節點位置與大小。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 走訪 SmartArt 形狀內的所有 **節點**。
1. 存取並顯示 SmartArt 節點的位置、層級與文字等資訊。

```java
import com.aspose.slides.*;

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
            // 將形狀型別轉換為 SmartArt
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
以下範例程式碼說明如何存取 SmartArt 形狀中各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 走訪 SmartArt 形狀內的所有 **節點**。
1. 對每個選取的 SmartArt 形狀 **節點**，走訪其內所有 **子節點**。
1. 存取並顯示 **子節點** 的位置、層級與文字等資訊。

```java
import com.aspose.slides.*;

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
            // 將形狀型別轉換為 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // 遍歷 SmartArt 內的所有節點
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 取得索引 i 的 SmartArt 節點
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 遍歷索引 i 的 SmartArt 節點中的子節點
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

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體。
1. 以 Index 取得第一張投影片的參照。
1. 加入 **StackedList** 類型的 SmartArt 形狀。
1. 存取已加入的 SmartArt 形狀。
1. 存取該 SmartArt 形狀中索引 0 的節點。
1. 現在，使用 **get_Item()** 方法存取該節點在位置 1 的 **子節點**。
1. 存取並顯示 **子節點** 的位置、層級與文字等資訊。

```java
import com.aspose.slides.*;

// 實例化簡報
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在第一張投影片中新增 SmartArt 形狀
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

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 檢查該 SmartArt 是否有超過 0 個節點。
1. 選取要刪除的 SmartArt 節點。
1. 現在，使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法移除選取的節點。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 載入所需的簡報
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀型別轉換為 SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 取得索引 0 的 SmartArt 節點
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 移除選取的節點
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

## **在特定位置移除 SmartArt 節點**
本範例說明如何在特定位置移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 選取索引 0 的 SmartArt 形狀節點。
1. 現在，檢查該選取的 SmartArt 節點是否有超過 2 個子節點。
1. 現在，使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法移除位置 **1** 的節點。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 載入所需的簡報
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof SmartArt) 
        {
            // 將形狀型別轉換為 SmartArt
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
現在 Aspose.Slides for Android via Java 支援設定 [SmartArtShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#setX-float-) 與 [Y](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#setY-float-) 屬性。以下程式碼片段示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，請注意，新增節點會重新計算所有節點的位置與大小。使用自訂位置設定，使用者可依需求調整節點。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // 將 SmartArt 形狀移動到新位置
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // 變更 SmartArt 形狀的寬度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // 變更 SmartArt 形狀的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // 變更 SmartArt 形狀的旋轉角度
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **檢查助理節點**
{{% alert color="info" %}} 

在本文中，我們將進一步探討使用 Aspose.Slides for Android via Java 以程式方式在簡報投影片中加入 SmartArt 形狀的功能。

{{% /alert %}} 

我們將在本文的各個章節中使用下列來源 SmartArt 形狀作為研究對象。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**圖示：投影片中的來源 SmartArt 形狀**|

在以下範例程式碼中，我們將探討如何在 SmartArt 節點集合中識別 **Assistant Nodes**，並對其進行變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體，並載入包含 SmartArt 形狀的簡報。
1. 以 Index 取得第一張投影片的參照。
1. 走訪第一張投影片內的每一個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 類型，若是則將選取的形狀類型轉型為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt)。
1. 走訪 SmartArt 形狀內的所有節點，並檢查它們是否為 [**Assistant Nodes**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)。
1. 將 Assistant Node 的狀態變更為一般節點。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 建立簡報實例
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀型別轉換為 SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // 遍歷 SmartArt 形狀的所有節點
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 檢查節點是否為助理節點
                if (node.isAssistant()) 
                {
                    // 設定助理節點為 false 並將其轉為一般節點
                    node.setAssistant(false);
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
|**圖示：已變更為一般節點的 Assistant Nodes**|

## **設定節點的填充格式**
Aspose.Slides for Android via Java 讓您可以新增自訂 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for Android via Java 為其設定填充格式。

請依下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體。
1. 以索引取得投影片的參照。
1. 透過設定 **LayoutType** 加入 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArt) 形狀。
1. 為 SmartArt 形狀的節點設定 [**FillFormat**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getFillFormat--)。
1. 將修改後的簡報寫入為 PPTX 檔案。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **產生 SmartArt 節點的縮圖**
開發人員可依照下列步驟產生 SmartArt 節點的縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體。
1. [新增 SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 以 Index 取得節點的參照。
1. 取得縮圖影像。
1. 以任意影像格式儲存縮圖影像。

```java
import com.aspose.slides.*;

// 實例化代表 PPTX 檔案的 Presentation 類別 
Presentation pres = new Presentation();
try {
    // 加入 SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 取得節點參考，使用其索引  
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

## **常見問題**

### 是否支援 SmartArt 動畫？

是的。SmartArt 被視為普通形狀，您可以套用[標準動畫](/slides/zh-hant/androidjava/shape-animation/)(進入、離開、強調、路徑動畫)並調整時間。必要時也可為 SmartArt 節點內的形狀加入動畫。

### 若不知道內部 ID，如何可靠地在投影片上定位特定的 SmartArt？

請使用[替代文字](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getAlternativeText--)進行標記與搜尋。為 SmartArt 設定唯一的 AltText，即可在程式中無需依賴內部識別碼即可找到它。

### 轉換簡報為 PDF 時，SmartArt 的外觀會被保留嗎？

會的。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)過程中會以高視覺相似度渲染 SmartArt，保留版面、顏色與效果。

### 我能匯出整個 SmartArt 的影像（用於預覽或報告）嗎？

可以。您可以將 SmartArt 形狀渲染為[點陣圖格式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)或[SVG](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，以取得可縮放的向量輸出，適合用於縮圖、報告或 web 使用。