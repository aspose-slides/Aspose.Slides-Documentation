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
- 貼齊垂直分割線
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
description: "了解 Aspose.Slides for Node.js via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。屬性與不同內容區域的定位相關。此資訊允許應用程式將檢視狀態儲存至檔案，因而在重新開啟時檢視會保持與最後一次儲存投影片時相同的狀態。

已新增方法 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 以提供存取簡報的普通檢視屬性。  

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties) 類別及其衍生類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType) 列舉。

## **關於 NormalViewProperties**

代表普通檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) 和 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) 指定當在普通檢視模式的任何內容區域顯示大綱內容時，應用程式是否應顯示圖示。  

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) 和 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) 指定當側邊區域足夠小時，垂直分割線是否應自動貼合至最小化狀態。  

屬性 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) 和 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準普通檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。  

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 和 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值有：[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) 和 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored)。  

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 和 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 指定在對應的 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 使用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 時，普通檢視中上方或側邊投影片區域的尺寸。

## **關於還原 NormalViewProperties**

指定普通檢視中投影片區域的尺寸（作為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 的子項時為寬度，作為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 的子項時為高度），當區域處於可變的還原尺寸（既非最小化亦非最大化）時。  

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) 指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。  

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動調整以補償新尺寸。  

以下範例說明如何存取簡報的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 屬性。

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

Aspose.Slides for Node.js via Java 現在支援設定簡報的預設縮放值，讓簡報開啟時即已套用縮放。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties) 來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) 都可以以程式方式設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。 

{{% /alert %}} 

為了設定檢視屬性，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。  
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ViewProperties)。  
1. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。以下範例中，我們已設定投影片檢視與備註檢視的縮放值。  

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

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getViewProperties--) 以存取簡報全域的檢視設定。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) 與 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) 方法讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點 (point) 為單位，72 點等於一英吋。請使用正值，如 API 文件所要求。  

以下範例會開啟已存在的 `demo.pptx`，輸出其目前的格線間距，設定為四分之一英吋的間隔，並儲存結果。  

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

格線與 [drawing guides](/slides/zh-hant/nodejs-java/drawing-guides/) 不同。格線間距控制的是固定的間隔，而繪圖指南則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖指南不會改變格線間距。  

格線與繪圖指南皆為編輯輔助工具。它們不會在 PDF、影像、SVG 或投影片放映中以投影片內容呈現。儲存格線間距並不保證編輯器會顯示格線；其可見性亦取決於檢視器或編輯器的偏好設定。  

## **開啟簡報時顯示或隱藏註解**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getViewProperties--) 以存取簡報全域的檢視設定。使用 [ViewProperties.getShowComments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#getShowComments--) 與 [ViewProperties.setShowComments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) 讀取或變更儲存的偏好，以決定在 PowerPoint 或其他相容編輯器開啟簡報時是否顯示註解。  

此設定僅控制儲存的檢視偏好，並不會新增、移除、編輯或解決註解。隱藏註解會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/nodejs-java/presentation-comments/) 了解會變更註解本身的操作。  

以下範例需要一個已包含註解的 `comments.pptx`。它會列印目前的可見性設定，請求隱藏註解，並儲存新的 PPTX 而不移除任何註解。同時使用 [ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) 搭配 [ViewType.SlideView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewtype/#SlideView) 來設定初始編輯檢視與註解可見性。  

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此設定不會決定註解是否包含在 PDF、HTML、影像、備註或講義的匯出中。請分別設定相關的匯出選項。  

## **常見問題**

**為何重新開啟簡報後格線無法顯示？**  
檔案會儲存格線間距，但顯示與否由編輯器控制。請檢查編輯器的格線可見性設定。  

**清除繪圖指南會改變格線間距嗎？**  
不會。繪圖指南與格線間距是獨立的設定。清除指南不會更改已儲存的格線間隔。  

**我可以為簡報的不同章節設定不同的檢視設定嗎？**  
[View settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/) 於簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)），而非每個章節，因此在開啟時整份文件僅套用單一組參數。  

**我可以為不同使用者預先定義不同的檢視狀態嗎？**  
不能。設定儲存在檔案中且為共用。檢視程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。  

**我能製作帶有預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**  
可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getviewproperties/) 於簡報層級儲存，您可以將其嵌入範本，並以此建立新文件，使其具備相同的初始檢視設定。