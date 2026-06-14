---
title: 使用 JavaScript 管理簡報中的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/nodejs-java/manage-smartart-shape-node/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 PPT 與 PPTX 中管理 SmartArt 形狀節點。取得清晰的 JavaScript 程式碼範例與技巧，簡化您的簡報製作。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式處理這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取它們的文字、層級與位置。

本文章說明如何管理 SmartArt 形狀節點。內容包括移除節點、依索引或位置操作子節點、將助理節點變更為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點填充格式，以及為 SmartArt 子節點產生縮圖。

## **使用 JavaScript 在 PowerPoint 簡報中新增 SmartArt 節點**
Aspose.Slides for Node.js via Java 提供最簡易的 API 來管理 SmartArt 形狀。以下範例程式碼說明如何在 SmartArt 形狀內新增節點與子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 在 SmartArt 形狀的 **[NodeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt#getAllNodes--)** 中[新增節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)，並於 TextFrame 設定文字。  
1. 接著[新增](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)一個**[子節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)**於剛剛新增的 SmartArt 節點，並於 TextFrame 設定文字。  
1. 儲存簡報。

```javascript
// 載入所需的簡報
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 遍歷第一張投影片內的所有圖形
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            // 新增一個 SmartArt 節點
            var TemNode = smart.getAllNodes().addNode();
            // 新增文字
            TemNode.getTextFrame().setText("Test");
            // 在父節點新增子節點。它將被加入到集合的末尾
            var newNode = TemNode.getChildNodes().addNode();
            // 新增文字
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // 儲存簡報
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在特定位置新增 SmartArt 節點**
以下範例說明如何在 SmartArt 形狀的相應節點中於特定位置新增子節點。

1. 建立 Presentation 類別的實例。  
1. 使用索引取得第一張投影片的參考。  
1. 在該投影片中加入一個 **[StackedList](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList)** 類型的 SmartArt 形狀。  
1. 取得已加入 SmartArt 形狀的第一個節點。  
1. 為所選的 **節點** 在位置 2 處[新增子節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)，並設定其文字。  
1. 儲存簡報。

```javascript
// 建立簡報實例
var pres = new aspose.slides.Presentation();
try {
    // 存取簡報投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增 Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 取得索引 0 的 SmartArt 節點
    var node = smart.getAllNodes().get_Item(0);
    // 在父節點的第 2 位置新增子節點
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // 新增文字
    chNode.getTextFrame().setText("Sample Text Added");
    // 儲存簡報
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用 JavaScript 在 PowerPoint 簡報中存取 SmartArt 節點**
以下範例說明如何存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在加入形狀時設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 遍歷 SmartArt 形狀內的所有 **[節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt#getAllNodes--)**。  
1. 存取並顯示 SmartArt 節點的位置、層級與文字資訊。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 遍歷第一張投影片內的所有圖形
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            // 遍歷 SmartArt 內的所有節點
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // 存取索引 i 的 SmartArt 節點
                var node = smart.getAllNodes().get_Item(j);
                // 輸出 SmartArt 節點參數
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

## **存取 SmartArt 子節點**
以下範例說明如何存取 SmartArt 形狀中各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 遍歷 SmartArt 形狀內的所有 **[節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt#getAllNodes--)**。  
1. 對於每個選取的 SmartArt **節點**，遍歷其內的所有 **[子節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)**。  
1. 存取並顯示子節點的位置、層級與文字資訊。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 遍歷第一張投影片內的所有圖形
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            // 遍歷 SmartArt 內的所有節點
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // 存取索引 i 的 SmartArt 節點
                var node0 = smart.getAllNodes().get_Item(i);
                // 遍歷索引 i 的 SmartArt 節點中的子節點
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // 存取 SmartArt 節點中的子節點
                    var node = node0.getChildNodes().get_Item(j);
                    // 輸出 SmartArt 子節點參數
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

## **在特定位置存取 SmartArt 子節點**
本範例示範如何在特定位置存取屬於各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。  
1. 使用索引取得第一張投影片的參考。  
1. 加入一個 **[StackedList](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList)** 類型的 SmartArt 形狀。  
1. 取得已加入的 SmartArt 形狀。  
1. 取得該 SmartArt 形狀的索引為 0 的節點。  
1. 使用 **get_Item()** 方法，取得該節點索引為 1 的 **[子節點](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)**。  
1. 存取並顯示子節點的位置、層級與文字資訊。

```javascript
// 實例化簡報
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 在第一張投影片中新增 SmartArt 形狀
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 取得索引 0 的 SmartArt 節點
    var node = smart.getAllNodes().get_Item(0);
    // 在父節點的第 1 個位置取得子節點
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // 輸出 SmartArt 子節點參數
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用 JavaScript 在 PowerPoint 簡報中移除 SmartArt 節點**
本範例說明如何移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 檢查該 SmartArt 是否擁有超過 0 個節點。  
1. 選取欲刪除的 SmartArt 節點。  
1. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) 方法移除選取的節點。  
1. 儲存簡報。

```javascript
// 載入所需的簡報
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的所有圖形
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 存取索引 0 的 SmartArt 節點
                var node = smart.getAllNodes().get_Item(0);
                // 移除選取的節點
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // 儲存簡報
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在特定位置移除 SmartArt 節點**
本範例說明如何在特定位置移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 取得索引為 0 的 SmartArt 形狀節點。  
1. 檢查所選 SmartArt 節點是否擁有超過 2 個子節點。  
1. 使用 [**RemoveNode**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) 方法移除 **位置 1** 的節點。  
1. 儲存簡報。

```javascript
// 載入所需的簡報
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // 遍歷第一張投影片內的所有圖形
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 存取索引 0 的 SmartArt 節點
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // 移除位置 1 的子節點
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // 儲存簡報
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **為 SmartArt 子節點設定自訂位置**
現在 Aspose.Slides for Node.js via Java 支援設定 [SmartArtShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#setX-float-) 與 [Y](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#setY-float-) 屬性。以下程式碼示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，並請注意新增節點會重新計算所有節點的大小與位置。使用自訂位置設定，使用者可依需求調整節點。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // 將 SmartArt 形狀移動到新位置
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // 更改 SmartArt 形狀的寬度
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // 更改 SmartArt 形狀的高度
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // 更改 SmartArt 形狀的旋轉
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **檢查助理節點**
{{% alert color="primary" %}} 

在本篇文章中，我們將進一步探討使用 Aspose.Slides for Node.js via Java 以程式方式在簡報投影片中加入的 SmartArt 形狀功能。

{{% /alert %}} 

我們將在本文的不同章節中使用以下來源 SmartArt 形狀作為範例。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**圖：投影片中的來源 SmartArt 形狀**|

在以下範例程式碼中，我們將探討如何在 SmartArt 節點集合中識別 **助理節點** 並進行變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入包含 SmartArt Shape 的簡報。  
1. 使用索引取得第二張投影片的參考。  
1. 遍歷第一張投影片內的所有圖形。  
1. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt)。  
1. 遍歷 SmartArt 形狀內的所有節點，並檢查它們是否為 [**Assistant Nodes**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNode#isAssistant--)。  
1. 將助理節點的狀態變更為普通節點。  
1. 儲存簡報。

```javascript
// 建立簡報實例
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // 遍歷第一張投影片內的所有圖形
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查圖形是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將圖形型別轉換為 SmartArt
            var smart = shape;
            // 遍歷 SmartArt 形狀的所有節點
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // 檢查節點是否為助理節點
                if (node.isAssistant()) {
                    // 將助理節點設為 false 並轉為普通節點
                    node.isAssistant();
                }
            }
        }
    }
    // 儲存簡報
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**圖：已在投影片中變更的助理節點**|

## **設定節點的填充格式**
Aspose.Slides for Node.js via Java 允許新增自訂 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for Node.js via Java 設定其填充格式。

請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。  
1. 使用索引取得投影片的參考。  
1. 透過設定 **[LayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)**，新增一個 SmartArt 形狀。  
1. 為 SmartArt 形狀的節點設定 **[FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getFillFormat--)**。  
1. 將修改後的簡報寫入為 PPTX 檔案。

```javascript
// 實例化簡報
var pres = new aspose.slides.Presentation();
try {
    // 取得投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增 SmartArt 形狀與節點
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // 設定節點填充顏色
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // 儲存簡報
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **產生 SmartArt 子節點的縮圖**
開發人員可依照以下步驟產生 SmartArt 子節點的縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。  
1. [新增 SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)。  
1. 使用索引取得節點的參考。  
1. 取得縮圖影像。  
1. 將縮圖影像儲存為任意欲選的影像格式。

```javascript
// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 新增 SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // 透過索引取得節點的參考
    var node = smart.getNodes().get_Item(1);
    // 取得縮圖
    var slideImage = node.getShapes().get_Item(0).getImage();
    // 儲存縮圖
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

## **常見問題**

**支援 SmartArt 動畫嗎？**

是的。SmartArt 被視為一般形狀，您可以[套用標準動畫](/slides/zh-hant/nodejs-java/shape-animation/)（進入、退出、強調、移動路徑）並調整時間。必要時也可以對 SmartArt 節點內的形狀進行動畫設定。

**如果不知道內部 ID，如何可靠地在投影片上定位特定 SmartArt？**

可透過[替代文字](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getalternativetext/)設定與搜尋。為 SmartArt 設定唯一的 AltText，即可在不依賴內部識別碼的情況下找到它。

**將簡報轉為 PDF 時會保留 SmartArt 外觀嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)時以高視覺相似度渲染 SmartArt，保持版面、色彩與效果。

**我能擷取整個 SmartArt 的影像（用於預覽或報告）嗎？**

可以。您能將 SmartArt 形狀渲染為[點陣圖格式](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/)，以產生可用於縮圖、報告或網頁的向量或點陣圖輸出。