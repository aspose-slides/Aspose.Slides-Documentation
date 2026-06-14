---
title: 在 JavaScript 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/nodejs-java/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 垂直分割條自動對齊
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js via Java 的檢視屬性，客製化 PPT、PPTX 與 ODP 格式的投影片——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

普通檢視包含三個內容區域：投影片本身、側邊內容區以及底部內容區。相關的屬性描述了不同內容區域的定位方式。此資訊允許應用程式將檢視狀態儲存至檔案，讓重新開啟時檢視保持在上次保存時的狀態。

已新增方法[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)，以提供對簡報的普通檢視屬性的存取。

已新增[NormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties)類別及其衍生類別，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType)列舉。

## **關於 NormalViewProperties**

代表普通檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--)與[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-)指出在普通檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--)與[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-)指出當側邊區域足夠小時，垂直分割條是否應自動縮至最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--)與[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-)指定使用者是否偏好在整個視窗中僅顯示單一內容區域，而非標準的三區域普通檢視。若啟用，應用程式可能會選擇將其中一個內容區域佔滿整個視窗。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)指定水平或垂直分割條應呈現的狀態。水平分割條將投影片與其下方的內容區分開，垂直分割條則將投影片與側邊內容區分開。可能的值有[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)以及[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)與[getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)指定普通檢視中側邊或上方投影片區域的尺寸，當[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)皆為[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored)時使用。

## **關於 Restoring NormalViewProperties** 

指定普通檢視中投影片區域的尺寸（作為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)的子項時為寬度，作為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)的子項時為高度），當該區域處於可變的還原大小（既非最小化亦非最大化）時。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--)指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--)指定在調整包含此檢視的視窗大小時，側邊內容區的尺寸是否應自動補償新的大小。

以下範例說明如何存取[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)屬性以取得簡報的相關資訊。

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // 還原簡報的檢視屬性
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **設定預設縮放值**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 現在支援為簡報設定預設縮放值，讓簡報開啟時即已套用縮放。這可透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)來實現。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--)皆可程式化設定。本主題將示範如何為[Aspose.Slides](/slides/zh-hant/)中的[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation)設定[View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性的步驟如下：

1. 建立一個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation)類別的實例。  
2. 設定該[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。  
3. 將簡報寫入[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。  
   在下方範例中，我們同時設定了投影片檢視與備註檢視的縮放值。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 設定簡報的檢視屬性
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 投影片檢視的縮放值（百分比）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 備註檢視的縮放值（百分比）
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/)是以簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)）定義，而非針對單一章節。因此，在簡報開啟時，整份文件會套用同一套參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。這些設定儲存在檔案中，所有使用者共用。同時，檢視程式可自行遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以建立包含預先定義檢視屬性的範本，讓新簡報以相同方式開啟嗎？**

可以。由於[view properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/)儲存在簡報層級，您可以將它們嵌入範本，然後以此範本建立新文件，便能保有相同的初始檢視設定。