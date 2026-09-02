---
title: 在 PHP 中檢索與更新投影片資訊
linktitle: 投影片資訊
type: docs
weight: 30
url: /zh-hant/php-java/examine-presentation/
keywords:
- 投影片格式
- 投影片屬性
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
- 投影片
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 探索 PowerPoint 與 OpenDocument 投影片中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中檢視投影片資訊。它說明如何在不載入完整檔案的情況下判斷投影片的目前格式、讀取文件屬性，以及在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) API，展示了處理投影片中繼資料的典型操作。

## **檢查投影片格式**

在對投影片進行操作之前，您可能想要先了解目前投影片的格式（PPT、PPTX、ODP 等）。

您可以在不載入投影片的情況下檢查其格式。請參考以下 PHP 程式碼：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **取得投影片屬性**

以下 PHP 程式碼示範如何取得投影片屬性（投影片的資訊）：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

您可能想要查看 [DocumentProperties 類別下的屬性](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#DocumentProperties--)。

## **更新投影片屬性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，使您能夠變更投影片屬性。

假設我們有一個 PowerPoint 投影片，其文件屬性如下所示。

![PowerPoint 投影片的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部分投影片屬性：

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 投影片的變更後文件屬性](output_properties.png)

## **相關連結**

若要取得更多關於投影片及其安全屬性的資訊，您可能會發現以下連結有用：

- [密碼保護投影片](/slides/zh-hant/php-java/password-protected-presentation/)
- [寫入保護投影片](/slides/zh-hant/php-java/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及嵌入了哪些字型？**

在投影片層級尋找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getembeddedfonts/)，然後將這些條目與 [實際在內容中使用的字型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getfonts/) 進行比對，即可判斷哪些字型對呈現至關重要。

**如何快速判斷檔案是否有隱藏投影片以及其數量？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/gethidden/)。

**我能偵測是否使用自訂投影片大小與方向，且是否與預設值不同嗎？**

可以。將目前的 [slide size](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getslidesize/) 與方向與標準預設值進行比較；這有助於預測列印與匯出的行為。

**是否有快速方法查看圖表是否引用外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)，檢查它們的 [data source](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/)，並註明資料是內部還是連結型式，包括任何失效的連結。

**如何評估可能導致渲染或 PDF 匯出緩慢的「大型」投影片？**

對每張投影片，統計物件數量，並檢查是否有大型影像、透明度、陰影、動畫與多媒體；依此給予粗略的複雜度分數，以標示可能的效能瓶頸。