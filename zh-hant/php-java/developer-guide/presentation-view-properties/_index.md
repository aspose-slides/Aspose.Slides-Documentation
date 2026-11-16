---
title: 在 PHP 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/php-java/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 對齊垂直分割條
- 單一檢視
- 分隔條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 來設定 PowerPoint 簡報的普通檢視版面配置、投影片與備註的縮放比例、格線間距以及註解可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視中，投影片位於左側的縮圖或大綱窗格以及下方的備註窗格之間。Aspose.Slides for PHP via Java 透過 [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) 透露演示檔儲存的編輯偏好設定。這些設定包括窗格佈局、縮放比例、格線間距以及註解可見性。

## **關於 NormalViewProperties**

使用 [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) 取得 [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) 類別。[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) 控制大綱中投影片標題旁是否顯示圖示。[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) 讓使用者縮小側窗格時自動貼齊至最小化狀態。[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) 表示偏好在整個視窗中僅顯示一個窗格。

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) 控制側窗格與投影片之間的分隔條。[setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) 控制備註窗格上方的分隔條。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) 的 `Minimized`、`Maximized` 或 `Restored` 值。

## **關於還原 NormalViewProperties**

當分隔條被還原時，[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) 會提供側窗格的已保存寬度，而 [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) 會提供上方投影片區域的已保存高度。兩者皆會公開 [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/)。其 [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) 方法接受 0 到 100 的百分比，而 [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) 則控制在視窗大小變更時編輯器是否自動調整尺寸。

此範例會更新既有的演示檔。它還原水平分隔條，將由 [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) 取得的尺寸設定為 80%，並啟用自動調整，之後將垂直分隔條最大化。它同時呼叫 [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) 以在大綱檢視中顯示圖示。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定預設縮放值**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) 與 [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) 會為編輯器分別保存獨立的縮放設定。這些設定不會影響投影片尺寸、投影片放映播放或圖像匯出解析度。

此範例開啟一個既有的演示檔，並呼叫 [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) 以將投影片調整至編輯視窗大小。對於備註頁面，它會停用自動縮放，並呼叫 [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) 設定固定的 80% 縮放。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定格線間距**

[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) 的 `setGridSpacing` 方法會設定整個演示檔中編輯格線之間的距離。它接受以點 (point) 為單位的正值，1 英吋等於 72 點。此範例會列印既有演示檔的目前間距，並透過將間隔設為 18 點來儲存四分之一英吋的格線。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

格線會以固定間隔重複。 [Drawing guides](/slides/zh-hant/php-java/drawing-guides/) 會標示個別的水平或垂直位置。兩者皆為編輯輔助工具，僅在顯示它們的編輯器中出現。投影片放映以及匯出為 PDF、圖像或 SVG 時皆不會包含它們。

## **開啟演示檔時顯示或隱藏註解**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) 會儲存相容編輯器在開啟演示檔時使用的偏好設定。對於含有註解的既有演示檔，此範例會列印目前設定，並儲存一個隱藏註解的副本。它同時使用 [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) 並傳入 [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) 使該副本以投影片檢視方式開啟。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

隱藏註解會保留其文字、作者、位置、回覆與狀態。若要變更註解本身，請參閱 [Presentation Comments](/slides/zh-hant/php-java/presentation-comments/)。匯出設定會控制註解是否出現在 PDF、HTML、圖像、備註或講義中。

## **常見問題集**

**為什麼重新開啟演示檔時格線會消失？**

演示檔會儲存格線間隔。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖指南會改變格線間距嗎？**

不會。新增、移動或清除指南皆不會影響格線間隔。

**演示檔的不同區段可以有不同的檢視設定嗎？**

不能。[Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) 會套用於整個演示檔。

**我可以為不同使用者儲存不同的檢視設定嗎？**

檔案僅儲存一套檢視屬性，供所有人使用。編輯器也可能套用使用者本機的偏好設定。

**我可以在範本中儲存檢視設定嗎？**

可以。從範本建立的演示檔會繼承其已儲存的檢視設定。