---
title: 使用 Python 匯出簡報為 XAML
linktitle: 匯出為 XAML
type: docs
weight: 30
url: /zh-hant/python-net/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出 簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保持版面不變。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、展示如何使用預設設定將簡報儲存為 XAML，以及說明如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 自訂匯出行為，包含匯出隱藏的投影片。本文亦回答了有關備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種描述性程式語言，可讓您為應用程式建立或撰寫使用者介面，特別是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin Forms 的應用程式。

XAML 是基於 XML 的語言，是 Microsoft 用於描述 GUI 的變體。大多數時候您會使用設計師來處理 XAML 檔案，但仍然可以自行編寫與編輯介面。

## **使用預設選項匯出簡報至 XAML**

以下 Python 程式碼示範如何使用預設設定將簡報匯出為 XAML：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **使用自訂選項匯出簡報至 XAML**

您可以從 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 類別中選取各種選項，這些選項會控制匯出過程並決定 Aspose.Slides 如何將簡報匯出為 XAML。

例如，若希望 Aspose.Slides 在匯出為 XAML 時加入隱藏的投影片，您可以將 [export_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 屬性設定為 `True`。請參考下列 Python 範例程式碼：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 中設定 [default_regular_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/)，該字型在找不到原始字型時會作為備援字型使用，可避免意外的字型替換。

**匯出的 XAML 只適用於 WPF，還是也可在其他 XAML 堆疊中使用？**

XAML 是在 WPF、UWP 與 Xamarin.Forms 中使用的通用 UI 標記語言。匯出目標是與 Microsoft XAML 堆疊相容；具體行為與對特定結構的支援取決於目標平台。請在您的環境中測試該標記。

**是否支援隱藏投影片，且預設如何防止它們被匯出？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 中的 [export_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 屬性來控制此行為——若不需要匯出隱藏投影片，請保持該屬性為停用狀態。