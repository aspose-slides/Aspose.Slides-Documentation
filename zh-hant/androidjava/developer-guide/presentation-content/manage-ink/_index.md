---
title: 在 Android 上管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/androidjava/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡追蹤
- 管理墨跡
- 繪製墨跡
- 繪圖
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件——使用 Aspose.Slides for Android 建立、編輯與樣式化數位墨跡。取得針對追蹤、筆刷顏色與大小的 Java 程式碼範例。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您可以繪製非標準圖形，這些圖形可用於強調其他物件、顯示連接與流程，並吸引觀眾注意投影片上的特定項目。

Aspose.Slides 提供了所有 Ink 類型（例如 [Ink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ink/) 類別），讓您能夠建立和管理墨跡物件。

## **常規物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件表示。形狀物件在最簡單的形式下是一個容器，定義了物件本身的區域（其框架）以及相關屬性。後者包括容器區域大小、容器形狀、容器背景等。相關資訊請參閱 [形狀版面配置格式](https://docs.aspose.com/slides/zh-hant/androidjava/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，它會忽略除尺寸之外的所有框架（容器）屬性。容器區域的大小由標準的 `width` 和 `height` 值決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 追蹤**

Trace 是用於記錄使用者書寫數位墨跡時筆尖軌跡的基本元素或標準。Trace 為描述相連點序列的錄製。

最簡單的編碼形式指定每個取樣點的 X 與 Y 座標。當所有相連點被渲染時，就會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

您可以使用筆刷繪製連接 Trace 元素點的線條。筆刷具有自己的顏色與大小，分別對應 `Brush.Color` 與 `Brush.Size` 屬性。

### **設定墨跡筆刷顏色**

此 Java 程式碼示範如何設定筆刷的顏色：

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

此 Java 程式碼示範如何設定筆刷的大小：

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

一般而言，筆刷的寬度與高度不相等，因此 PowerPoint 不會顯示筆刷大小（資料區段為灰色）。但當寬度與高度相等時，PowerPoint 會以如下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚說明，我們將增加墨跡物件的高度，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的尺寸——它始終假設線條的粗細為零（請參閱最後一張圖）。

因此，若要決定整個墨跡物件的可見區域，必須考慮 Trace 物件的筆刷大小。此處，目標物件（手寫文字的 Trace 物件）已被縮放至容器（框架）大小。當容器（框架）尺寸變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會呈現相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要一般性閱讀形狀，請參閱 [PowerPoint 形狀](https://docs.aspose.com/slides/zh-hant/androidjava/powerpoint-shapes/) 部分。
* 如需取得有效值的更多資訊，請參閱 [形狀有效屬性](https://docs.aspose.com/slides/zh-hant/androidjava/shape-effective-properties/#getting-effective-font-height-value)。