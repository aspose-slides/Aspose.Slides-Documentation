---
title: 在 Java 中擷取與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/java/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 對齊垂直分割線
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式 - 調整版面配置、縮放層級與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域與底部內容區域。與不同內容區域定位相關的屬性允許應用程式將檢視狀態儲存至檔案，讓重新開啟時檢視仍保持在上次儲存時的狀態。

已新增方法 [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供對簡報普通檢視屬性的存取。

已新增介面 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties) 以及其衍生類別，還有列舉型別 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType)。

## **關於 INormalViewProperties**

表示普通檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 與 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 指定當在普通檢視模式的任何內容區域顯示大綱內容時，應用程式是否應顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 與 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 指定當側邊區域足夠變小時，垂直分割桿是否應自動縮至最小狀態。

屬性 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 與 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 指定使用者是否偏好在整個視窗中只顯示單一內容區域，而非以三個內容區域的標準普通檢視。啟用後，應用程式可能會選擇在整個視窗中顯示其中一個內容區域。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值為 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Maximized) 與 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 指定普通檢視中側邊或上方投影片區域的大小，當 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 皆採用 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored) 時的尺寸。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域（作為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子項時以寬度計算，作為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子項時以高度計算）的大小，當該區域為可變的還原尺寸（既非最小化亦非最大化）時使用。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 指定投影片區域的尺寸（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 指定在調整包含檢視的視窗大小時，側邊內容區域的大小是否應自動補償新尺寸。

以下範例說明如何存取簡報的 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) 屬性。

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

Aspose.Slides for Java 現已支援為簡報設定預設縮放值，使簡報開啟時即已套用縮放。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties) 來完成。可程式化設定 [getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)。在本主題中，我們將以範例說明如何在 Aspose.Slides 中為 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 設定 [View Properties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性的步驟如下：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)。
1. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。以下範例同時設定了投影片檢視與備註檢視的縮放值。

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

## **設定格線間距**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--) 取得整份簡報的檢視設定。透過 [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#getGridSpacing--) 與 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 方法，可讀取或變更底層編輯格線的間隔。此設定套用於整份簡報，而非單一投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，符合 API 文件的要求。

以下範例會開啟現有的 `demo.pptx`，列印目前的格線間距，將間隔設定為四分之一英吋，然後儲存結果。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

格線不同於 [drawing guides](/slides/zh-hant/java/drawing-guides/)。格線間距控制的是規則的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助工具，並不會在 PDF、圖像、SVG 或投影片放映中以投影片內容呈現。即使儲存格線間距，也不保證編輯器會顯示格線：其可見性還取決於檢視器或編輯器的偏好設定。

## **開啟簡報時顯示或隱藏批註**

使用 [Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--) 取得整份簡報的檢視設定。使用 [IViewProperties.getShowComments](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#getShowComments--) 與 [IViewProperties.setShowComments](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) 讀取或變更是否在 PowerPoint 或其他相容編輯器開啟簡報時顯示批註的預設偏好。

此設定僅控制儲存的檢視偏好，並不會新增、移除、編輯或解決批註。隱藏批註會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/java/presentation-comments/) 了解變更批註本身的操作。

以下範例需要一個已存在、包含批註的 `comments.pptx`。它會列印目前的可見性設定、要求隱藏批註，並儲存新的 PPTX 檔案而不移除任何批註。範例同時使用 [IViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#setLastView-int-) 搭配 [ViewType.SlideView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewtype/#SlideView) 以在設定批註可見性時配置初始編輯檢視。

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此設定不會決定批註是否會在 PDF、HTML、圖像、備註或講義匯出時包含。請分別設定相關的匯出選項。

## **常見問題**

**為什麼重新開啟簡報後格線不見了？**

檔案會儲存格線間距，但編輯器決定是否顯示格線。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會改變已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--) 僅在簡報層級定義（[普通檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[投影片檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），不會依章節分開，因此同一組參數會套用於整份文件的開啟。

**我可以預先為不同使用者定義不同的檢視狀態嗎？**

不行。這些設定儲存在檔案中且為共用。雖然檢視程式可能會遵循使用者個人偏好，但檔案本身只包含一套檢視屬性。

**我可以建立含有預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [檢視屬性](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--) 儲存在簡報層級，您可以將它們嵌入範本，然後以該範本建立新文件，讓它們擁有相同的初始檢視設定。