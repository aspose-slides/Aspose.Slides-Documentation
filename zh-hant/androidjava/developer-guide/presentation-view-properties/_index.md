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
- 貼齊垂直分割條
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
description: "使用 Aspose.Slides for Android via Java 來設定 PowerPoint 簡報的普通檢視版面配置、投影片與備註的縮放、格線間距，以及註解的可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視模式中，投影片位於左側的縮圖或大綱窗格與下方的備註窗格之間。Aspose.Slides for Android via Java 透過 [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) 讓您存取已保存的編輯偏好設定，這些設定包括窗格佈局、縮放比例、格線間距以及註解可見性。

## **關於 INormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) 取得 [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) 介面。[setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) 會控制在大綱中是否於投影片標題旁顯示圖示。[setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) 讓側邊窗格在使用者縮小時自動貼合至最小化狀態。[setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) 表示偏好在整個視窗中只顯示單一窗格。

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) 控制側邊窗格與投影片之間的分隔條。[setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) 控制備註窗格上方的分隔條。兩者皆接受 `Minimized`、`Maximized` 或 `Restored` 之 [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) 值。

## **關於還原 INormalViewProperties**

當分隔條被還原時，[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) 會提供側邊窗格的已保存大小，而 [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) 則提供上方投影片區域的已保存大小。兩者皆公開 [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) 則控制編輯器在視窗大小變更時是否自動調整尺寸。

此範例會更新現有簡報，還原水平分隔條，將由 [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) 取得的尺寸設定為 80%，並啟用自動調整，最後將垂直分隔條最大化。程式碼也會呼叫 [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) 以在大綱檢視中顯示圖示。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設縮放值**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) 與 [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) 分別儲存編輯器的獨立縮放設定。這些設定不會影響投影片尺寸、投影片放映播放或影像匯出解析度。

此範例開啟現有簡報，呼叫 [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) 讓投影片自動適應編輯視窗。對於備註頁面，則關閉自動縮放，並呼叫 [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) 設定固定的 80% 縮放。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定格線間距**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 設定整個簡報編輯格線之間的距離。它接受以點 (points) 為單位的正值，1 英吋等於 72 點。此範例會列印現有簡報的格線間距，並將間距設定為 18 點（相當於四分之一英吋）以建立四分之一英吋的格線。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

格線會以固定間隔重複。[繪圖參考線](/slides/zh-hant/androidjava/drawing-guides/) 用於標示單一的水平或垂直位置。兩者皆為編輯輔助工具，只會在顯示它們的編輯器中出現。投影片放映以及匯出為 PDF、影像或 SVG 時都不會包含這些參考線。

## **在開啟簡報時顯示或隱藏註解**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) 儲存相容編輯器在開啟簡報時使用的偏好設定。對於含有註解的現有簡報，此範例會列印目前設定，並儲存一份隱藏註解的副本。程式碼同時會使用 [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) 並傳入 [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) 讓副本以投影片檢視模式開啟。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隱藏註解會保留其文字、作者、位置、回覆與狀態。若要變更註解本身，請參閱 [Presentation Comments](/slides/zh-hant/androidjava/presentation-comments/)。匯出設定則決定註解是否出現在 PDF、HTML、影像、備註或講義中。

## **常見問題**

**為什麼重新開啟簡報時格線會消失？**

簡報會儲存格線的間距。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖參考線會改變格線間距嗎？**

不會。新增、移動或清除參考線不會改變格線的間距設定。

**簡報的不同章節可以有不同的檢視設定嗎？**

不能。[Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) 會套用至整個簡報。

**我可以為不同使用者保存不同的檢視設定嗎？**

檔案僅儲存一套檢視屬性，供所有使用者共用。編輯器可能會套用使用者本機的偏好設定。

**我可以在範本中保存檢視設定嗎？**

可以。從範本建立的簡報會繼承範本中已保存的檢視設定。