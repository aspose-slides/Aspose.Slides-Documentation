---
title: 在 JavaScript 中檢索與更新投影片檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/nodejs-java/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 垂直分割條自動貼齊
- 單一檢視
- 分隔條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 投影片
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 來設定 PowerPoint 投影片的正常檢視佈局、投影片與備註的縮放、格線間距以及註解可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視模式中，投影片位於側邊面板（顯示縮圖或大綱）與下方的備註面板之間。Aspose.Slides for Node.js via Java 透過 [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) 公開投影片儲存的編輯偏好設定。這些設定包括面板佈局、縮放等級、格線間距以及註解的可見性。

## **關於 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) 取得 [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) 類別。[setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 控制是否在大綱中於投影片標題旁顯示圖示。[setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 允許使用者縮小側邊面板時，使其自動貼齊至最小化狀態。[setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) 表示在全螢幕視窗中偏好僅顯示單一面板。

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) 控制側邊面板與投影片之間的分隔條。[setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) 控制備註面板上方的分隔條。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **關於 還原 NormalViewProperties**

當分隔條被還原時，[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) 提供側邊面板的儲存大小，而 [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) 提供上方投影片區域的儲存大小。兩者皆公開 [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 方法接受 0 到 100 之間的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) 控制編輯器在視窗大小變更時是否自動調整尺寸。

此範例會更新現有的投影片。它還原水平分隔條，將 [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) 回傳的大小設定為 80% 並啟用自動調整，並將垂直分隔條最大化。它亦呼叫 [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 以在大綱檢視中顯示圖示。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **設定預設縮放值**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) 與 [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) 為編輯器儲存獨立的縮放設定。這些設定不會影響投影片尺寸、投影片放映播放或影像匯出的解析度。

此範例開啟現有的投影片，並呼叫 [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) 以將投影片符合編輯視窗。對於備註頁面，它停用自動縮放，並呼叫 [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) 設定固定的 80% 縮放。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **設定格線間距**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) 設定整個投影片中編輯格線之間的距離。它接受以點為單位的正值，1 英吋等於 72 點。此範例列印現有投影片的目前間距，並將間隔設定為 18 點，以儲存四分之一英吋的格線。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

格線以固定間隔重複。[繪圖參考線](/slides/zh-hant/nodejs-java/drawing-guides/) 標示個別的水平或垂直位置。兩者皆為編輯輔助工具，僅在顯示該功能的編輯器中出現。投影片放映以及匯出為 PDF、影像或 SVG 時不會包含它們。

## **開啟投影片時顯示或隱藏註解**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) 儲存相容編輯器在開啟投影片時會使用的偏好設定。對於含有註解的現有投影片，此範例會列印目前設定，並儲存一個隱藏註解的副本。它亦呼叫 [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) 並傳入 [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView)，使副本以投影片檢視方式開啟。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隱藏註解會保留其文字、作者、位置、回覆與狀態。若要變更註解本身，請參閱 [投影片註解](/slides/zh-hant/nodejs-java/presentation-comments/)。匯出設定會決定註解是否出現在 PDF、HTML、影像、備註或講義中。

## **常見問題**

**為什麼重新開啟投影片時格線會被隱藏？**

投影片會儲存格線間隔。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖參考線會改變格線間距嗎？**

不會。新增、移動或清除參考線都不會改變格線間隔。

**投影片的不同章節可以有不同的檢視設定嗎？**

不會。[Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) 會套用於整個投影片。

**我可以為不同使用者儲存不同的檢視設定嗎？**

檔案僅儲存一套檢視屬性供所有使用者使用。編輯器可能會同時套用使用者的本機偏好設定。

**我可以在範本中儲存檢視設定嗎？**

可以。從該範本建立的投影片會繼承其已儲存的檢視設定。