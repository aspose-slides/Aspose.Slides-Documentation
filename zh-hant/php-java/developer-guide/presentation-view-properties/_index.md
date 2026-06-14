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
- 垂直分割條自動對齊
- 單一檢視
- 分割列狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 的檢視屬性，以自訂 PPT、PPTX 和 ODP 格式的投影片——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。相關於不同內容區域位置的屬性。這些資訊允許應用程式將其檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持在上次儲存簡報時的相同狀態。

已新增方法 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 以提供對簡報的普通檢視屬性的存取。

已新增 [NormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties) 類別及其衍生類別，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType) 列舉。

## **關於 INormalViewProperties**

代表普通檢視屬性。

方法 [getShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 與 [setShowOutlineIcons](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) 指定當在普通檢視模式的任何內容區域顯示大綱內容時，應用程式是否應顯示圖示。

方法 [getSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 與 [setSnapVerticalSplitter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) 指定側邊區域足夠小時，垂直分割條是否應自動縮至最小化狀態。

屬性 [getPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 與 [setPreferSingleView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) 指定使用者是否偏好以單一全視窗內容區域取代具有三個內容區域的標準普通檢視。如果啟用，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

方法 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 指定水平或垂直分割條應顯示的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條將投影片與側邊內容區域分開。可能的值為 [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Maximized) 和 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored)。

方法 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 與 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties#getRestoredTop) 指定當 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SplitterBarStateType/#Restored) 值套用於 [getVerticalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 與 [getHorizontalBarState](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 時，普通檢視的上方或側邊投影片區域的大小。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域的尺寸（作為 [getRestoredTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) 的子項時以寬度為準，作為 [getRestoredLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 的子項時以高度為準），當區域為可變的還原大小（既非最小化亦非最大化）時的大小。

方法 [getDimensionSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) 指定投影片區域的尺寸（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

方法 [getAutoAdjust](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) 指定在調整包含檢視的視窗大小時，側邊內容區域的大小是否應自動補償新尺寸。

以下範例示範如何存取簡報的 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 屬性。

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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 現已支援為簡報設定預設縮放值，讓簡報開啟時即已套用縮放。可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties) 來達成。[getSlideViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) 以及 [getNotesViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) 都能以程式方式設定。在本主題中，我們將示範如何以範例設定 [View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties) 於 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) ，並使用 [Aspose.Slides](/slides/zh-hant/)。

{{% /alert %}} 

為了設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
1. 設定 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 的 [View Properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ViewProperties)。
1. 將簡報寫入為 [PPTX ](https://docs.fileformat.com/presentation/pptx/)檔案。  
   在下面的範例中，我們已設定投影片檢視與備註檢視的縮放值。

```php
  $presentation = new Presentation();
  try {
    # 設定簡報的檢視屬性
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 投影片檢視的縮放值（百分比）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 逐稿檢視的縮放值（百分比）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/) 於簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/getslideviewproperties/)），而非每個章節，所以在開啟文件時，整份文件會套用同一組參數。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

否。設定儲存在檔案中，為所有使用者共用。檢視程式可能會遵循使用者偏好，但檔案本身僅包含一套檢視屬性。

**我可以製作含有預先定義檢視屬性的範本，以使新簡報以相同方式開啟嗎？**

可以。由於 [view properties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getviewproperties/) 儲存在簡報層級，您可以將它們嵌入範本，之後以該範本建立新文件，即可擁有相同的初始檢視設定。