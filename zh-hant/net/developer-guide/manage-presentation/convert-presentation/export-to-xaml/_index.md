---
title: 在 .NET 中將簡報匯出為 XAML
linktitle: 簡報匯出為 XAML
type: docs
weight: 30
url: /zh-hant/net/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中將 PowerPoint 和 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保持版面不變。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。它包括對 XAML 的簡要介紹，示範如何使用預設設定將簡報保存為 XAML，並演示如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 自訂匯出，包括匯出隱藏投影片。本文還回答了有關替代字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種描述性的程式語言，可讓您為應用程式建立或編寫使用者介面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin Forms 的應用程式。

XAML 作為基於 XML 的語言，是 Microsoft 用於描述圖形使用者介面的變體。您大多數時候會使用設計工具來處理 XAML 檔案，但仍然可以自行編寫與編輯 GUI。

## **使用預設選項將簡報匯出為 XAML**

以下 C# 程式碼示範如何使用預設設定將簡報匯出為 XAML：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **使用自訂選項將簡報匯出為 XAML**

您可以從 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloptions) 介面選取選項，以控制匯出過程並決定 Aspose.Slides 如何將您的簡報匯出為 XAML。

例如，若您希望 Aspose.Slides 在匯出為 XAML 時將簡報中的隱藏投影片一起加入，可將 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) 屬性設為 true。請參閱以下 C# 範例程式碼：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **常見問題**

**如果原始字型在機器上不存在，我該如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 中設定 [DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/defaultregularfont/) ——當原始字型缺失時，會使用此字型作為備援字型。這可避免意外的替代。

**匯出的 XAML 只適用於 WPF，還是也可以在其他 XAML 堆疊中使用？**

XAML 是在 WPF、UWP 與 Xamarin.Forms 中使用的一般 UI 標記語言。匯出旨在與 Microsoft XAML 堆疊相容；具體行為以及對特定結構的支援取決於目標平台。請在您的環境中測試此標記。

**是否支援隱藏投影片？以及預設情況下如何防止它們被匯出？**

預設情況下，隱藏投影片不會被包含。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 來控制此行為 ——若不需要匯出，請保持其停用。