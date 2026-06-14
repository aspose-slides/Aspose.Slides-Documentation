---
title: 在 Java 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件——使用 Aspose.Slides for Java 建立、編輯與設定數位墨跡樣式。取得軌跡、筆刷顏色與大小的程式碼範例。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您可以繪製非標準圖形，可用於突顯其他物件、顯示連接與流程，並吸引投影片中特定項目的注意。

Aspose.Slides 提供了全部的 Ink 類型（例如 [Ink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ink/) 類別），讓您能建立和管理墨跡物件。

## **一般物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件（shape）表示。形狀物件在最簡單的形式下是一個容器，定義了物件本身的區域（即它的框架）以及其屬性。後者包括容器區域的大小、容器的形狀、容器的背景等。欲了解更多資訊，請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，除了大小之外，它會忽略框架（容器）的所有屬性。容器區域的大小是由標準的 `width` 和 `height` 值決定的：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 軌跡**

軌跡（Trace）是一種基本元素或標準，用於記錄使用者書寫數位墨跡時筆的軌跡。軌跡是描述連接點序列的錄製。

最簡單的編碼方式是指定每個取樣點的 X 與 Y 座標。當所有連接點被呈現時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖的筆刷屬性**

您可以使用筆刷來繪製連接軌跡元素點的線條。筆刷有自己的顏色與大小，分別對應 `Brush.Color` 與 `Brush.Size` 屬性。

### **設定墨跡筆刷顏色**

以下 Java 程式碼示範如何設定筆刷的顏色：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **設定墨跡筆刷大小**

以下 Java 程式碼示範如何設定筆刷的大小：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

一般而言，筆刷的寬度與高度不相同，PowerPoint 不會顯示筆刷大小（資料區段為灰色）。但當筆刷的寬度與高度相同時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，我們將提升墨跡物件的高度，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條的粗細為零（見最後一張圖片）。

因此，要判斷整個墨跡物件的可見區域，必須考慮軌跡物件的筆刷大小。此處，目標物件（手寫文字軌跡物件）已依容器（框架）大小縮放。當容器（框架）的大小變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會表現出相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/java/powerpoint-shapes/) 章節。 
* 若需取得有效值的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/java/shape-effective-properties/#getting-effective-font-height-value)。