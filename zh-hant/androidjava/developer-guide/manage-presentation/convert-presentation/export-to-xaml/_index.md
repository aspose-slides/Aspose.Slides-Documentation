---
title: 在 Android 上將簡報匯出為 XAML
linktitle: 簡報轉 XAML
type: docs
weight: 30
url: /zh-hant/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "使用適用於 Android 的 Aspose.Slides，在 Java 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、免 Office 的解決方案，保持您的版面配置完整。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。它包含對 XAML 的簡要介紹，展示如何以預設設定將簡報儲存為 XAML，並示範如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/) 進行匯出自訂，包括匯出隱藏投影片。本文亦回答幾個與備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為相關的常見問題。

## **關於 XAML**

XAML 是一種描述性程式語言，可讓您為應用程式建立或撰寫使用者介面，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin Forms 的應用程式。  
XAML 基於 XML，是微軟用於描述圖形使用者介面的變體。您大多會使用設計工具來處理 XAML 檔案，但仍然可以自行撰寫與編輯介面。

## **以預設選項將簡報匯出為 XAML**

以下 Java 程式碼示範如何以預設設定將簡報匯出為 XAML：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **以自訂選項將簡報匯出為 XAML**

您可以從 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IXamlOptions) 介面中選取控制匯出過程的選項，以決定 Aspose.Slides 如何將您的簡報匯出為 XAML。  

例如，若您希望 Aspose.Slides 在匯出為 XAML 時加入簡報中的隱藏投影片，您可以將 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 屬性設為 true。請參考以下範例 Java 程式碼：

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

**如果原始字型在機器上不可用，如何確保字型的可預測性？**  
在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/) 中設定[預設常規字型](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)，當原始字型缺失時會作為備援字型使用。這可避免意外的字型替換。

**匯出的 XAML 僅適用於 WPF，還是也可以在其他 XAML 堆疊中使用？**  
XAML 是在 WPF、UWP 與 Xamarin.Forms 中使用的一般 UI 標記語言。匯出旨在與 Microsoft 的 XAML 堆疊相容；具體行為與對特定結構的支援取決於目標平台。請於您的環境中測試該標記。

**是否支援隱藏投影片，且如何防止它們在預設情況下被匯出？**  
預設情況下，不會包含隱藏投影片。您可以透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 來控制此行為——若不需要匯出隱藏投影片，請保持其停用。