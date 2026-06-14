---
title: 匯出簡報為 XAML（PHP）
linktitle: 簡報轉 XAML
type: docs
weight: 30
url: /zh-hant/php-java/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）將 PowerPoint 與 OpenDocument 投影片轉換為 XAML —— 快速、無需 Office 的解決方案，保持版面完整。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包含對 XAML 的簡要介紹、展示如何使用預設設定將簡報儲存為 XAML，以及說明如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 自訂匯出行為，包含匯出隱藏投影片。本文亦回答關於備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種描述性程式語言，可讓您為應用程式構建或撰寫使用者介面，特別是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin Forms 的應用程式。  

XAML 作為基於 XML 的語言，是 Microsoft 用於描述 GUI 的變體。您大部分時間可能會使用設計工具來處理 XAML 檔案，但仍然可以自行編寫與編輯 GUI。 

## **使用預設選項將簡報匯出為 XAML**

以下 PHP 程式碼示範如何使用預設設定將簡報匯出為 XAML：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用自訂選項將簡報匯出為 XAML**

您可以從 XamlOptions 類別中選取選項，以控制匯出過程並決定 Aspose.Slides 如何將您的簡報匯出為 XAML。

例如，若希望 Aspose.Slides 在匯出為 XAML 時包含簡報中的隱藏投影片，您可以將 setExportHiddenSlides 方法設為 `true`。請參考以下 PHP 程式碼範例：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 中設定 [預設一般字型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) — 當原始字型缺失時，會使用此字型作為備援字型。這有助於避免意外的字型替換。

**匯出的 XAML 僅適用於 WPF，還是也可用於其他 XAML 架構？**

XAML 是一種在 WPF、UWP 與 Xamarin.Forms 中使用的通用 UI 標記語言。匯出的目標是與 Microsoft XAML 堆疊相容；具體行為與對特定結構的支援取決於目標平台。請於您的環境中測試此標記。

**是否支援隱藏投影片？以及如何預設防止它們被匯出？**

預設情況下，隱藏投影片不會被包含。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/setexporthiddenslides/) 來控制此行為 — 若不需要匯出隱藏投影片，請保持其為關閉狀態。