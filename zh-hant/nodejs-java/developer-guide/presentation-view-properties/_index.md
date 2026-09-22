---
title: 在 JavaScript 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/nodejs-java/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 貼齊垂直分割條
- 單一檢視
- 條狀狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式—調整版面配置、縮放等級與顯示設定。"
---
## **簡介**

正常檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。屬性涉及不同內容區域的位置設定。此資訊使應用程式能將檢視狀態儲存至檔案，讓重新開啟時檢視保持在上次儲存時的相同狀態。

已新增方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 以提供對簡報正常檢視屬性的存取。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties) 類別及其衍生類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType) 列舉。

## **關於 NormalViewProperties**

代表正常檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) 與 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) 指定應用程式在正常檢視模式的任何內容區域顯示大綱內容時，是否顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) 與 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) 指定側邊區域足夠小時，垂直分割條是否應自動貼齊至最小化狀態。

屬性 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) 與 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準正常檢視。若啟用，應用程式可能會選擇在整個視窗中顯示其中一個內容區域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分隔，垂直分割條則將投影片與側邊內容區域分隔。可能的值為：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) 與 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 指定正常檢視中頂部或側邊投影片區域的尺寸，當 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 值套用於 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 時。

## **關於還原 NormalViewProperties**

指定正常檢視中投影片區域的尺寸（當為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 的子項時為寬度，當為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 的子項時為高度），當區域處於可變的還原大小（非最小化亦非最大化）時。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) 指定投影片區域的大小（當為 restoredTop 的子項時為寬度，當為 restoredLeft 的子項時為高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) 指定在調整應用程式內包含檢視的視窗大小時，側邊內容區域的大小是否應自動調整以補償新的尺寸。

以下範例示範如何存取簡報的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java 現已支援為簡報設定預設縮放值，使簡報開啟時即已設定縮放。這可透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties) 來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) 均可以程式方式設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

若要設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。
1. 將簡報寫入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。以下範例展示了我們如何同時為投影片檢視和備註檢視設定縮放值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **設定格線間距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getViewProperties--) 可存取整個簡報的檢視設定。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) 與 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) 方法讀取或變更底層編輯格線的間距。此設定套用於整個簡報，而非單一投影片。格線間距以點 (point) 為單位，72 點等於一英吋。請使用正值，符合 API 文件的要求。

以下範例開啟現有的 `demo.pptx`，列印其目前的格線間距，將間距設定為四分之一英吋，並儲存結果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

格線不同於 [drawing guides](/slides/zh-hant/nodejs-java/drawing-guides/)。格線間距控制的是規則的間隔，而繪圖指引則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖指引不會改變格線間距。

格線與繪圖指引皆為編輯輔助工具。它們不會在 PDF、影像、SVG 或投影片放映中以投影片內容呈現。即使儲存了格線間距，也無法保證編輯器會顯示格線；其可見性同時取決於檢視者或編輯器的偏好設定。

## **常見問題**

**為何重新開啟簡報後格線未顯示？**

檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可見性設定。

**清除繪圖指引會改變格線間距嗎？**

不會。繪圖指引與格線間距是獨立的設定。清除指引不會改變已儲存的格線間距。

**我能為簡報的不同章節設定不同的檢視設定嗎？**

檢視設定 ([View settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/)) 只在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)、[Slide View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)），而非依章節。因此在簡報開啟時，整個文件只會套用同一組參數。

**我能為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，所有使用者皆共享。檢視應用程式可能會遵從使用者偏好，但檔案本身僅包含一組檢視屬性。

**我能製作含有預先定義檢視屬性的範本，以讓新簡報以相同方式開啟嗎？**

可以。由於 [view properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/) 儲存在簡報層級，您可將其嵌入範本，並從該範本建立新文件，以取得相同的初始檢視設定。