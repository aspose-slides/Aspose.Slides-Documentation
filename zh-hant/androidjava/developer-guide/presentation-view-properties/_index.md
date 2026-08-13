---
title: 在 Android 上檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/androidjava/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 垂直分割條自動貼齊
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java 的檢視屬性，以自訂 PPT、PPTX 和 ODP 投影片格式——調整版面配置、縮放倍率與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。此處的屬性與各內容區域的定位有關。此資訊讓應用程式能將檢視狀態儲存至檔案，從而在重新開啟時，檢視會保持與上次儲存時相同的狀態。

已加入方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供對簡報的普通檢視屬性的存取。

已加入[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties) 介面及其衍生類別，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType) 列舉。

## **關於 INormalViewProperties**

代表普通檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定當在普通檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準普通檢視。若啟用，應用程式可能會將其中一個內容區域顯示於整個視窗。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 與 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 和 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定普通檢視中上方或側邊投影片區域的大小，當對[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 分別套用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 時的尺寸。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域（當作為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子項時為寬度，作為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子項時為高度）的大小，當區域處於可變還原尺寸（既非最小化亦非最大化）時使用。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在調整包含檢視的視窗大小時，側邊內容區域的大小是否應自動補償新尺寸。

以下範例說明如何存取[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 以取得簡報的相關屬性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // 還原簡報的檢視屬性
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **設定預設縮放值**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java 現已支援為簡報設定預設縮放值，以便在開啟簡報時即已設定縮放。這可以透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties) 來實現。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) 都可以以程式方式設定。在本主題中，我們將透過範例說明如何在[Aspose.Slides](/slides/zh-hant/) 中設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性請遵循以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
1. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。
1. 將簡報寫入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。以下範例示範如何同時設定投影片檢視與備註檢視的縮放值。

```java
import com.aspose.slides.*;

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

### 我可以為簡報的不同章節設定不同的檢視設定嗎？

[View settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--) 於簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [Slide View](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)）定義，而非每個章節各自設定；因此單一組參數會套用於整份文件的開啟狀態。

### 我可以為不同使用者預先定義不同的檢視狀態嗎？

不能。設定會儲存在檔案中且為共用。檢視應用程式可以遵從使用者偏好，但檔案本身僅包含一組檢視屬性。

### 我可以建立含有預先定義檢視屬性的範本，以便新簡報以相同方式開啟嗎？

可以。因為[view properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--) 儲存在簡報層級，您可以將它們嵌入範本，然後以該範本建立新文件，便能保有相同的初始檢視配置。