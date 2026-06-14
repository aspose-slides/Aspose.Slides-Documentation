---
title: 在 JavaScript 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/nodejs-java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件──使用 Aspose.Slides for Node.js 建立、編輯與樣式化數位墨跡。取得 JavaScript 代碼範例，以示範軌跡、筆刷顏色與大小。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您能夠繪製非標準圖形，可用於突出其他物件、顯示連接與流程，並吸引投影片中特定項目的注意。

Aspose.Slides 提供了所有所需的 Ink 類型（例如 [Ink](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ink/) 類別），您可以用來建立與管理墨跡物件。

## **一般物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀物件呈現。形狀物件在最簡單的形式下是一個容器，定義了物件本身的區域（即框架）以及其屬性。後者包括容器區域的大小、容器的形狀、容器的背景等。相關資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略框架（容器）的所有屬性，僅保留其大小。容器區域的大小由標準的 `width` 和 `height` 值決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 軌跡**

軌跡是用於記錄使用者書寫數位墨跡時筆尖軌跡的基本元素或標準。軌跡是描述連續點序列的錄製。

最簡單的編碼形式會指定每個取樣點的 X 與 Y 座標。當所有連接點被繪製時，會產生如下圖所示的圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## 繪圖用的筆刷屬性

您可以使用筆刷來繪製連接軌跡元素點的線條。筆刷具有自己的顏色與大小，分別對應 `Brush.setColor` 與 `Brush.setSize` 方法。

### **設定墨跡筆刷顏色**

此 JavaScript 程式碼示範如何設定筆刷的顏色：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **設定墨跡筆刷大小**

此 JavaScript 程式碼示範如何設定筆刷的大小：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

一般而言，筆刷的寬度與高度不相同，PowerPoint 會將筆刷大小的資料區段呈現為灰色，亦即不顯示筆刷大小。但當筆刷的寬度與高度相同時，PowerPoint 會以如下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚說明，讓我們將墨跡物件的高度提高，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條的粗細為零（見最後一張圖）。

因此，若要判斷整個墨跡物件的可見範圍，必須考慮軌跡物件的筆刷大小。在此，目標物件（手寫文字軌跡物件）已依容器（框架）大小進行縮放。當容器（框架）尺寸變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會呈現相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/nodejs-java/powerpoint-shapes/) 章节。
* 有關有效值的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-effective-properties/#getting-effective-font-height-value)。