---
title: 取得與更新 Java 中的簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/java/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 吸附垂直分割條
- 單一檢視
- 分割條狀態
- 維度大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放等級與顯示設定。"
---
## **簡介**

正常檢視由三個內容區域組成：投影片本身、側邊內容區域，以及底部內容區域。這些屬性與不同內容區域的定位相關。此資訊允許應用程式將檢視狀態儲存至檔案，從而在重新開啟時，檢視保持與上次儲存時相同的狀態。

已新增方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供對簡報的正常檢視屬性的存取。

已新增[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties)介面及其衍生類別，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType)列舉。

## **關於 INormalViewProperties**

代表正常檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)與[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定當在正常檢視模式的任何內容區域顯示大綱內容時，應用程式是否應顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)與[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定當側邊區域足夠小時，垂直分割條是否應自動貼齊至最小化狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--)與[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定使用者是否偏好在整個視窗顯示單一內容區域，而非具有三個內容區域的標準正常檢視。若啟用，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與下方內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值有[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Maximized)以及[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)與[getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)指定正常檢視中頂部或側邊投影片區域的尺寸，當對[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)應用[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored)值時。

## **關於還原 INormalViewProperties**

指定正常檢視中投影片區域的尺寸（若為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子項則為寬度，若為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子項則為高度），當該區域為可變的還原大小（非最小化亦非最大化）時。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定投影片區域的大小（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動調整以補償新的大小。

以下範例說明如何存取簡報的[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getNormalViewProperties--)屬性。

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // 復原簡報的檢視屬性
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **設定預設縮放值**

{{% alert color="primary" %}} 

Aspose.Slides for Java 現已支援設定簡報的預設縮放值，使得開啟簡報時即已設定縮放。這可以透過設定簡報的[ViewProperties]來完成。[getSlideViewProperties]與[getNotesViewProperties]也能以程式方式設定。在本主題中，我們將透過範例說明如何在[Aspose.Slides](/slides/zh-hant/)中設定[Presentation]的[檢視屬性]。 

{{% /alert %}} 

要設定檢視屬性，請依照以下步驟操作：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation)類別的實例。  
2. 設定[Presentation]的[View Properties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)。  
3. 將簡報寫入[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。以下範例中，我們已設定投影片檢視與備註檢視的縮放值。

```java
Presentation presentation = new Presentation();
try {
    // 設定簡報的檢視屬性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 投影片檢視的縮放值（百分比）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 備註檢視的縮放值（百分比） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

**檢視設定**位於簡報層級（[正常檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[投影片檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而非每個章節。因此在開啟文件時，整個文件只會套用單一組參數。

**我能為不同使用者預先定義不同的檢視狀態嗎？**

**不能。**設定儲存在檔案中，且為共用。檢視程式可遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以準備一個已預設檢視屬性的範本，使新簡報以相同方式開啟嗎？**

**可以。**因為**檢視屬性**儲存在簡報層級，您可以將它們嵌入範本，並以此建立新文件，讓其具有相同的初始檢視設定。