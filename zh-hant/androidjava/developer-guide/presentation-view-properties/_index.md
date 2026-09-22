---
title: 在 Android 上檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/androidjava/presentation-view-properties/
keywords:
- 檢視屬性
- 正常檢視
- 大綱內容
- 大綱圖示
- 吸附垂直分割條
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
description: "探索 Aspose.Slides for Android via Java 的檢視屬性，客製化 PPT、PPTX 與 ODP 格式的簡報──調整版面配置、縮放等級與顯示設定。"
---
## **簡介**

正常檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。相關屬性用於定位不同內容區域。此資訊讓應用程式能將檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持與上次儲存時相同的狀態。

已新增方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)，以提供存取簡報的正常檢視屬性。

已新增介面[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties)以及其衍生類別，並新增列舉[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType)。

## **關於 INormalViewProperties**

代表正常檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)與[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定當在正常檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)與[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--)與[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定使用者是否較喜好在全視窗單一內容區域中檢視，而非標準的三區域正常檢視。若啟用，應用程式可能會選擇在整個視窗顯示其中一個內容區域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割條的顯示狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值為[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)以及[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)與[getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)在[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SplitterBarStateType#Restored)應用於[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)時，指定正常檢視之側邊或上方投影片區域的尺寸。

## **關於還原 INormalViewProperties**

指定正常檢視中投影片區域的尺寸（作為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)的子項時為寬度，作為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)的子項時為高度），當區域處於可變還原大小（既非最小化亦非最大化）時的尺寸。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在調整包含檢視之視窗大小時，側邊內容區域的尺寸是否應自動補償新尺寸。

以下範例說明如何存取[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)屬性，以取得簡報的相關設定。

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

Aspose.Slides for Android via Java 現已支援為簡報設定預設縮放值，使簡報開啟時即已套用縮放。這可以透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)來完成。可程式化設定[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)。本主題將示範如何在 Aspose.Slides 中以範例設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性請依照以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)類別的實例。
1. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ViewProperties)。
1. 將簡報寫入[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。以下範例同時設定投影片檢視與備註檢視的縮放值。

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

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--)存取全簡報的檢視設定。方法[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--)與[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-)可讀取或變更基礎編輯格線的間距。此設定套用於整份簡報，而非單一投影片。格線間距以點為單位，72 點等於一英寸。請使用正值，符合 API 文件的要求。

以下範例開啟現有 `demo.pptx`，印出目前的格線間距，將間距設為四分之一英吋，然後儲存結果。

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

格線與[drawing guides](/slides/zh-hant/androidjava/drawing-guides/)不同。格線間距控制規則的間隔，而繪圖參考線是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助工具，於 PDF、影像、SVG 或投影片放映時不會作為投影片內容呈現。儲存格線間距並不保證編輯器會顯示格線：其可見性亦取決於檢視器或編輯器的設定。

## **常見問題**

**為何重新開啟簡報後格線不可見？**

檔案會儲存格線間距，但是否顯示格線由編輯器自行控制。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會影響已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--) 只在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)），不會針對各章節分別設定，因此同一組參數會套用於整份文件的開啟。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。這些設定儲存在檔案中，為所有使用者共用。檢視應用程式可能會依使用者偏好調整，但檔案本身僅包含一組檢視屬性。

**我能否製作含有預先定義檢視屬性的範本，讓新簡報以相同方式開啟？**

可以。由於[view properties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getViewProperties--)儲存在簡報層級，您可以將它們嵌入範本，然後以該範本建立新文件，取得相同的初始檢視配置。