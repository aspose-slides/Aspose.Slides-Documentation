---
title: 在 PHP 中擷取與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/php-java/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 探索 PowerPoint 與 OpenDocument 簡報的投影片、結構與中繼資料，以便更快速洞察與更智慧的內容稽核。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中檢視簡報資訊。它說明如何在不載入完整檔案的情況下判斷簡報目前的格式、讀取其文件屬性，以及在需要時更新這些屬性。

這些範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) API，展示處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先瞭解目前簡報的格式（PPT、PPTX、ODP 等）為何。

您可以在不載入簡報的情況下檢查其格式。請參考以下 PHP 程式碼：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **取得簡報屬性**

以下 PHP 程式碼示範如何取得簡報屬性（簡報的資訊）：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#DocumentProperties--) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，讓您可以修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

更改文件屬性的結果如下所示。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **相關連結**

若要取得有關簡報及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [檢查簡報是否已加密](https://docs.aspose.com/slides/zh-hant/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [檢查簡報是否為寫入保護（唯讀）](https://docs.aspose.com/slides/zh-hant/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [載入前檢查簡報是否受密碼保護](https://docs.aspose.com/slides/zh-hant/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [確認用於保護簡報的密碼](https://docs.aspose.com/slides/zh-hant/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **常見問題**

**如何檢查是否嵌入字型以及哪些字型被嵌入？**

請在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getembeddedfonts/)，然後將這些條目與 [實際在內容中使用的字型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getfonts/) 做比較，以辨識哪些字型對渲染至關重要。

**如何快速判斷檔案是否有隱藏投影片以及有多少？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/gethidden/)。

**我能偵測是否使用自訂投影片大小與方向，且是否與預設不同嗎？**

可以。比較目前的 [slide size](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getslidesize/) 與方向是否與標準預設相同，這有助於預測列印與匯出的行為。

**有沒有快速方法查看圖表是否參考外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/)，並記錄資料是內部還是連結型式，亦包括任何斷開的連結。

**我如何評估可能導致渲染或 PDF 匯出緩慢的「重量級」投影片？**

對每張投影片統計物件數量，留意大型影像、透明度、陰影、動畫與多媒體等，給予粗略的複雜度分數，以標示潛在的效能瓶頸。