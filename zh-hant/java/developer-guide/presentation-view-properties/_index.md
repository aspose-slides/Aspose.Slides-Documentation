---
title: 在 Java 中檢索和更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/java/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 貼齊垂直分割條
- 單一檢視
- 列狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放等級與顯示設定。"
---
## **介紹**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。此處的屬性與各內容區域的定位相關。此資訊讓應用程式得以將檢視狀態儲存至檔案，從而在重新開啟時，檢視會保持在上次儲存時的相同狀態。

已新增方法[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)，提供對簡報普通檢視屬性的存取。

已新增[INormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties)介面及其衍生類別，與[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType)列舉。

## **關於 INormalViewProperties**

表示普通檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)與[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)指定當在普通檢視模式的任一內容區域顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)與[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)指定當側邊區域縮小到足以時，垂直分割條是否應自動縮至最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--)與[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)指定使用者是否偏好在完整視窗中只顯示單一內容區域，而非標準的三區域普通檢視。若啟用，應用程式可能會在整個視窗中顯示其中一個內容區域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值包括[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Maximized)以及[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)與[getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)指定普通檢視中側邊或上方投影片區域的尺寸，當[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)分別為[SplitterBarStateType.Restored](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SplitterBarStateType#Restored)時的設定。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域的尺寸（作為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 的子項時為寬度，作為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 的子項時為高度），當區域處於可變的還原大小（既非最小化也非最大化）時使用。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)指定投影片區域的大小（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)指定在調整包含檢視的視窗大小時，側邊內容區域是否應自動補償新尺寸。

以下範例示範如何存取[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getNormalViewProperties--)屬性以取得簡報的普通檢視設定。

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

Aspose.Slides for Java 現已支援設定簡報的預設縮放值，使簡報開啟時即已套用縮放。這可透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)達成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getSlideViewProperties--)以及[getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)皆可以程式方式設定。本主題將以範例說明如何為[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation)設定[View Properties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性的步驟如下：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation)類別的實例。  
1. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ViewProperties)。  
1. 將簡報寫出為[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。  

以下範例同時設定投影片檢視與備註檢視的縮放值。

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

使用[Presentation.getViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--)以存取整份簡報的檢視設定。透過[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#getGridSpacing--)與[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-)方法，可讀取或變更底層編輯格線的間距。此設定適用於整個簡報，而非單一投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，依 API 文件之要求。

以下範例會開啟既有的 `demo.pptx`，列印目前的格線間距，設定為四分之一英吋的間隔，並儲存結果。

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

格線與[繪圖參考線](/slides/zh-hant/java/drawing-guides/)不同。格線間距控制規則的等距間隔，而繪圖參考線則是單獨定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆屬於編輯輔助功能。它們不會在 PDF、影像、SVG 或幻燈片放映中呈現為投影片內容。儲存格線間距並不保證編輯器會顯示格線：其可見性亦取決於檢視器或編輯器的偏好設定。

## **常見問題**

**為什麼重新開啟簡報後格線不見了？**

檔案會儲存格線間距，但由編輯器決定是否顯示格線。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會影響已存的格線間距。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[檢視設定](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--)是在簡報層級定義（[普通檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [投影片檢視](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)），而非依章節。因此，同一組參數會套用於整個文件的開啟。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，且為共享的。檢視器應用程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我能否製作帶有預先定義檢視屬性的範本，以便新簡報以相同方式開啟？**

可以。由於[檢視屬性](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getViewProperties--)儲存在簡報層級，您可以將它們嵌入範本中，然後以此範本建立新文件，讓它們具備相同的初始檢視配置。