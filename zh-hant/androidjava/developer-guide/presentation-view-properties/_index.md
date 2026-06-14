---
title: 在 Android 上檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/androidjava/presentation-view-properties/
keywords:
- 檢視屬性
- 一般檢視
- 大綱內容
- 大綱圖示
- 垂直分割條貼齊
- 單一檢視
- 條狀狀態
- 維度大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java 的檢視屬性，以自訂 PPT、PPTX 和 ODP 投影片格式——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

一般檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。屬性與不同內容區域的定位相關。此資訊讓應用程式能將檢視狀態儲存至檔案，從而在重新開啟時，檢視保持在最後一次儲存時的相同狀態。

已新增方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供對簡報一般檢視屬性的存取。

已新增[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties)介面及其衍生類別，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType)列舉。

## **關於 INormalViewProperties**

代表一般檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)與[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定在一般檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)與[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定當側邊區域足夠小時，垂直分割條是否應自動縮到最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--)與[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定使用者是否傾向於在整個視窗顯示單一內容區域，而非具有三個內容區域的標準一般檢視。若啟用，應用程式可能會選擇在整個視窗中顯示其中一個內容區域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值包括：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)以及[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)與[getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)在對應的[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)應用[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored)值時，指定一般檢視的側邊或上方投影片區域的大小。

## **關於還原 INormalViewProperties**

指定一般檢視中投影片區域的尺寸（若為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子項則為寬度，若為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子項則為高度），當該區域以可變的還原大小（既非最小化也非最大化）呈現時。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定投影片區域的大小（在 restoredTop 為子項時為寬度，在 restoredLeft 為子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動補償新的大小。

以下範例說明如何存取簡報的[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)屬性。

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // 恢復簡報的檢視屬性
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

Aspose.Slides for Android via Java 現已支援為簡報設定預設縮放值，使簡報開啟時即已設定縮放。這可以透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)來完成。可程式化設定[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)。在本主題中，我們將透過範例說明如何在[Aspose.Slides](/slides/zh-hant/) 中設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性的方法如下，請依序執行以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)類別的實例。
1. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。
1. 將簡報寫入[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。以下範例示範了如何同時為投影片檢視與備註檢視設定縮放值。

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

## **常見問答**

**我能為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--)是在簡報層級（[一般檢視](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)／[投影片檢視](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)）定義的，而非針對各章節。因此，單一套參數會套用於整個文件的開啟時。

**我能為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，所有使用者共用同一組檢視屬性。檢視程式可能會遵循使用者個人偏好，但檔案本身僅包含一組檢視屬性。

**我能建立包含預先定義檢視屬性的範本，以便新簡報以相同方式開啟嗎？**

可以。因為[檢視屬性](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--)儲存在簡報層級，您可以將其嵌入範本，並以該範本建立新文件，以保持相同的初始檢視配置。