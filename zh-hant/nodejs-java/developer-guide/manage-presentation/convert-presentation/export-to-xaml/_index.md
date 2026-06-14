---
title: 在 JavaScript 中將簡報匯出為 XAML
linktitle: 簡報匯出至 XAML
type: docs
weight: 30
url: /zh-hant/nodejs-java/export-to-xaml/
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
- 儲存 PPT 為 XAML
- 儲存 PPTX 為 XAML
- 儲存 ODP 為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js 將 PowerPoint 與 OpenDocument 簡報轉換為 XAML——快速、免安裝 Office 的解決方案，保持版面完整。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、示範如何以預設設定將簡報儲存為 XAML，並展示如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 自訂匯出，包括匯出隱藏投影片。本文亦回答有關備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種描述性的程式語言，可讓您為應用程式建立或編寫使用者類別，尤其是使用 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）與 Xamarin Forms 的應用程式。

XAML 為基於 XML 的語言，是 Microsoft 用於描述 GUI 的變體。您大多會使用設計師來處理 XAML 檔案，但仍然可以自行撰寫與編輯 GUI。

## **以預設選項匯出簡報為 XAML**

以下 JavaScript 程式碼示範如何以預設設定將簡報匯出為 XAML：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **以自訂選項匯出簡報為 XAML**

您可以從 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/XamlOptions) 類別中選取控制匯出流程的選項，決定 Aspose.Slides 如何將簡報匯出為 XAML。

例如，若您希望 Aspose.Slides 在匯出為 XAML 時包含簡報中的隱藏投影片，可將 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) 方法設定為 true。以下為示範 JavaScript 程式碼：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 中使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 當原始字型缺失時，它會作為備援字型使用，這有助於避免意外的字型替換。

**匯出的 XAML 是否僅供 WPF 使用，或也可用於其他 XAML 堆疊？**

XAML 是一種通用的 UI 標記語言，適用於 WPF、UWP 與 Xamarin.Forms。匯出目標相容於 Microsoft 的 XAML 堆疊；具體行為與對特定構造的支援取決於目標平台。請在您的環境中測試標記。

**是否支援隱藏投影片，且預設如何防止匯出它們？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) 方法來控制此行為——如果不需要匯出，請保持該設定為停用。