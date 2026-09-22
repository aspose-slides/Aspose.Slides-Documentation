---
title: 檢索並更新 PHP 中的簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/php-java/presentation-view-properties/
keywords:
- 檢視屬性
- 一般檢視
- 大綱內容
- 大綱圖示
- 自動貼齊垂直分割線
- 單一檢視
- 條狀狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 格式的投影片 —— 調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

一般檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。與不同內容區域位置相關的屬性。此資訊允許應用程式將檢視狀態儲存至檔案，以便重新開啟時檢視保持與上次儲存簡報時相同的狀態。

已新增方法[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)以提供對簡報一般檢視屬性的存取。  
已新增[NormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties) 類別及其衍生類別，還有[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType) 列舉。

## **關於 INormalViewProperties**

表示一般檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 與 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) 指定當在一般檢視模式的任何內容區域顯示大綱內容時，應用程式是否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 與 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) 指定當側邊區域足夠小時，垂直分割線是否應自動貼齊至最小化狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 與 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) 指定使用者是否偏好以全螢幕單一內容區域取代具有三個內容區域的標準一般檢視。啟用後，應用程式可能會在整個視窗顯示其中一個內容區域。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值包括：[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Maximized) 和 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties#getRestoredTop) 指定在 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored) 用於 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 時，一般檢視之側邊或上方投影片區域的大小。

## **關於還原 INormalViewProperties**

指定當區域為可變還原大小（既非最小化亦非最大化）時，一般檢視中投影片區域（若為 [getRestoredTop] 的子項則為寬度，若為 [getRestoredLeft] 的子項則為高度）的大小。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) 指定投影片區域的尺寸（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) 指定在調整包含檢視的視窗大小時，側邊內容區域的大小是否應自動調整以配合新尺寸。

以下範例說明如何存取簡報的[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)屬性。

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # 還原簡報的檢視屬性
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **設定預設縮放值**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java 現已支援為簡報設定預設縮放值，讓簡報開啟時即已套用縮放。這可以透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)與 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)皆可以程式方式設定。在本主題中，我們將以範例說明如何在 Aspose.Slides 中為[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)設定[View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

若要設定檢視屬性，請依照以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)類別的實例。
2. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)。
3. 將簡報寫入為[PPTX ](https://docs.fileformat.com/presentation/pptx/)檔案。以下範例示範了如何同時設定投影片檢視與註解檢視的縮放值。

```php
  $presentation = new Presentation();
  try {
    # 設定簡報的檢視屬性
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 投影片檢視的縮放值（百分比）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 註解檢視的縮放值（百分比）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **設定格線間距**

使用[Presentation::getViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getViewProperties)以存取整份簡報的檢視設定。[ViewProperties::getGridSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#getGridSpacing) 與 [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#setGridSpacing) 方法可讀取或變更底層編輯格線的間距。此設定適用於整個簡報，而非單一投影片。格線間距以點 (point) 為單位，72 點等於一英吋。請使用正值，符合 API 文件的要求。

以下範例會開啟現有的 `demo.pptx`，輸出其目前的格線間距，設定為四分之一英吋的間距，並儲存結果。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

格線與[繪圖參考線](/slides/zh-hant/php-java/drawing-guides/)不同。格線間距控制的是規則的間隔，而繪圖參考線則是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助功能。它們不會在 PDF、影像、SVG 或投影片放映中以投影片內容呈現。即使儲存了格線間距，也不保證編輯器會顯示格線：其可見性亦取決於檢視或編輯程式的設定。

## **常見問題**

**為何重新開啟簡報後格線仍不可見？**  
檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**  
不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會改變已儲存的格線間距。

**我能為簡報的不同章節設定不同的檢視設定嗎？**  
[View settings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/) 定義於簡報層級（[Normal View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getslideviewproperties/)），而非各章節，故在開啟文件時，整個文件僅使用一組參數。

**我能預先為不同使用者定義不同的檢視狀態嗎？**  
不能。設定儲存在檔案中，且為共用的。檢視程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我能製作預先設定檢視屬性的範本，使新的簡報以相同方式開啟嗎？**  
可以。由於[view properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/) 儲存在簡報層級，您可以將其嵌入範本，並以該範本建立新文件，讓它們擁有相同的初始檢視設定。