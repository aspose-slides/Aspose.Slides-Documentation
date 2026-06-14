---
title: 在 C++ 中將簡報匯出為 XAML
linktitle: 簡報轉 XAML
type: docs
weight: 30
url: /zh-hant/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML - 快速、無需 Office 的解決方案，保持版面完整。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、示範如何以預設設定將簡報儲存為 XAML，以及如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 自訂匯出，包括匯出隱藏投影片。本文亦回答有關備援字型、XAML 堆疊相容性與隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種描述性程式語言，可讓您為應用程式建立或編寫使用者介面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin Forms 的應用。  
XAML 是基於 XML 的語言，是 Microsoft 用於描述圖形使用者介面的變體。您大多會使用設計工具來處理 XAML 檔案，但仍然可以自行撰寫與編輯 GUI。

## **使用預設選項將簡報匯出為 XAML**

以下 C++ 程式碼示範如何以預設設定將簡報匯出為 XAML：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **使用自訂選項將簡報匯出為 XAML**

您可以從 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.xaml.i_xaml_options) 介面選擇控制匯出過程的選項，決定 Aspose.Slides 如何將您的簡報匯出為 XAML。  

例如，若您希望 Aspose.Slides 在匯出為 XAML 時將簡報中的隱藏投影片一併加入，可對 [set_ExportHiddenSlides()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) 方法傳入 true。請參考以下 C++ 範例程式碼：

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **常見問題**

**如果原始字型在機器上不可用，如何確保字型的可預測性？**  
使用 [set_DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) 於 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/)——當原始字型缺失時，它會作為備援字型使用。這有助於避免意外的字型替換。

**匯出的 XAML 只適用於 WPF，還是也能在其他 XAML 堆疊中使用？**  
XAML 是在 WPF、UWP 以及 Xamarin.Forms 中使用的一般 UI 標記語言。匯出旨在與 Microsoft 的 XAML 堆疊相容；具體行為與對特定結構的支援取決於目標平台。請在您的環境中測試該標記。

**是否支援隱藏投影片，預設情況下如何防止它們被匯出？**  
預設情況下，隱藏投影片不會被包含。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/) 中使用 [set_ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 來控制此行為──若不需要匯出隱藏投影片，請保持其為停用狀態。