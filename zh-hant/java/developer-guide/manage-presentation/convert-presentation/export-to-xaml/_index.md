---
title: 在 Java 中將簡報匯出為 XAML
linktitle: 簡報 轉 XAML
type: docs
weight: 30
url: /zh-hant/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保持版面完整。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。它包括對 XAML 的簡要介紹，展示如何使用預設設定將簡報儲存為 XAML，並示範如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 自訂匯出，包括匯出隱藏投影片。本文亦回答了幾個常見問題，涵蓋備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為。

## **關於 XAML**

XAML 是一種描述性的程式語言，允許您為應用程式建立或編寫使用者介面，特別是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin Forms 的應用程式。

XAML 是基於 XML 的語言，是 Microsoft 用於描述 GUI 的變體。大多數情況下您會使用設計師來編輯 XAML 檔案，但仍然可以自行撰寫與編輯 GUI。

## **使用預設選項匯出簡報為 XAML**

以下 Java 程式碼示範如何使用預設設定將簡報匯出為 XAML：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用自訂選項匯出簡報為 XAML**

您可以從 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IXamlOptions) 介面中選擇控制匯出過程的選項，並決定 Aspose.Slides 如何將您的簡報匯出為 XAML。

例如，若您希望 Aspose.Slides 在將簡報匯出為 XAML 時加入隱藏投影片，您可以將 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 屬性設為 true。請參考以下 Java 程式碼範例：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 中設定 [預設一般字型](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) —— 當原始字型缺失時，它會作為備援字型使用。這有助於避免意外的字型取代。

**匯出的 XAML 只適用於 WPF，還是也可用於其他 XAML 堆疊？**

XAML 是在 WPF、UWP 以及 Xamarin.Forms 中使用的一般 UI 標記語言。匯出的目標是相容於 Microsoft 的 XAML 堆疊；具體行為與對特定結構的支援取決於目標平台。請在您的環境中測試此標記。

**是否支援隱藏投影片，且預設情況下如何防止匯出它們？**

預設情況下不會包含隱藏投影片。您可以透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 來控制此行為 —— 若不需匯出隱藏投影片，請保持其關閉狀態。