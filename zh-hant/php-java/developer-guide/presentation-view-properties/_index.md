---
title: 在 PHP 中擷取與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/php-java/presentation-view-properties/
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
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。此資訊涉及不同內容區域的定位屬性，允許應用程式將檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持在上次儲存時的相同狀態。

已新增方法[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)以提供對簡報的普通檢視屬性的存取。

已新增[NormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties)類別及其衍生類別，以及[SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType)列舉。

## **關於 INormalViewProperties**

代表普通檢視屬性。

方法[getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons)和[setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons)指定在普通檢視模式的任何內容區域中顯示大綱內容時，應否顯示圖示。

方法[getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter)和[setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter)指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小狀態。

屬性[getPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView)和[setPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView)指定使用者是否偏好在整個視窗中僅顯示單一內容區域，而非標準的三個內容區域的普通檢視。若啟用，應用程式可選擇將其中一個內容區域擴展至整個視窗。

方法[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)和[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)指定水平或垂直分割條應呈現的狀態。水平分割條將投影片與下方內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值為[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Maximized)以及[SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored)。

方法[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)和[getRestoredTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties#getRestoredTop)指定在對應的[getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState)與[getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)返回[SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored)時，普通檢視之上方或側邊投影片區域的大小。

## **關於 Restoring INormalViewProperties**

指定普通檢視中投影片區域的尺寸（作為[getRestoredTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)的子項時為寬度，作為[getRestoredLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)的子項時為高度），當該區域處於可變的已還原尺寸（既非最小化亦非最大化）時。

方法[getDimensionSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize)指定投影片區域的大小（作為restoredTop的子項時為寬度，作為restoredLeft的子項時為高度）。

方法[getAutoAdjust](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust)指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動補償新尺寸。

以下範例說明如何存取[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)屬性以取得簡報資訊。

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

Aspose.Slides for PHP via Java 現在支援為簡報設定預設縮放值，使得簡報開啟時即已設定縮放。可透過設定簡報的[ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)來完成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)與[getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)皆可程式化設定。在本主題中，我們將示範如何為 Aspose.Slides 中的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)設定[View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)。

{{% /alert %}} 

設定檢視屬性的步驟如下：

1. 建立一個[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)類別的實例。
1. 設定[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation)的[View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)。
1.將簡報寫入為[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。以下範例同時設定了投影片檢視與註解檢視的縮放值。

```php
  $presentation = new Presentation();
  try {
    # 設定簡報的檢視屬性
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 以百分比表示的投影片檢視縮放值
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 以百分比表示的備註檢視縮放值

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **設定格線間距**

使用[Presentation::getViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getViewProperties)存取簡報層級的檢視設定。[ViewProperties::getGridSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#getGridSpacing)與[ViewProperties::setGridSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#setGridSpacing)方法可讀取或變更底層編輯格線的間距。此設定套用於整份簡報，而非單一投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，符合 API 文件之要求。

以下範例開啟現有的 `demo.pptx`，列印其當前格線間距，將間距設為四分之一英吋，並儲存結果。

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

格線不同於[drawing guides](/slides/zh-hant/php-java/drawing-guides/)。格線間距控制規則的間隔，而繪製指引則是個別定位的水平或垂直對齊線。新增、移動或清除繪製指引不會改變格線間距。

格線與繪製指引皆為編輯輔助工具，並不會在 PDF、影像、SVG 或簡報放映中渲染為投影片內容。儲存格線間距並不保證編輯器會顯示格線：其可見性亦取決於檢視器或編輯器的偏好設定。

## **開啟簡報時顯示或隱藏註解**

使用[Presentation::getViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/)存取簡報層級的檢視設定。使用[ViewProperties::getShowComments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getshowcomments/)與[ViewProperties::setShowComments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/setshowcomments/)讀取或變更儲存的偏好，以決定在 PowerPoint 或其他相容編輯器開啟簡報時是否顯示註解。

此設定僅控制儲存的檢視偏好，並不會新增、移除、編輯或解決註解。隱藏註解會保留其內容、作者、位置、回覆與狀態。請參閱[Presentation Comments](/slides/zh-hant/php-java/presentation-comments/)以取得變更註解本身的操作說明。

以下範例需要一個包含註解的現有 `comments.pptx`。範例會列印目前的可見性設定、將註解隱藏，並將結果儲存為新的 PPTX，而不會移除任何註解。同時使用[ViewProperties::setLastView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/setlastview/)搭配[ViewType::SlideView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewtype/#SlideView)設定初始編輯檢視以及註解可見性。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此設定不會決定註解是否會包含於 PDF、HTML、影像、註解頁或講義匯出中。請分別設定相關的匯出專屬選項。

## **常見問題**

**為什麼重新開啟簡報後格線不可見？**

檔案會儲存格線間距，但編輯器負責決定是否顯示格線。請檢查編輯器的格線可見性設定。

**清除繪製指引會改變格線間距嗎？**

不會。繪製指引與格線間距是獨立的設定。清除指引不會影響已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/)僅在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getslideviewproperties/))，不會針對章節。開啟文件時，整份文件共用同一組參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，供所有使用者共用。檢視應用程式可能會遵循使用者偏好，但檔案本身僅包含一組檢視屬性。

**我可以製作一個預先設定好 View Properties 的範本，使新簡報以相同方式開啟嗎？**

可以。因為[view properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/)儲存在簡報層級，您可以將它們嵌入範本，並以此範本建立新文件，以取得相同的初始檢視配置。