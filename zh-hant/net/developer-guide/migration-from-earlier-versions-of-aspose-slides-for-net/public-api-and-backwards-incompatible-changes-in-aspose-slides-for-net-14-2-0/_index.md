---
title: Aspose.Slides for .NET 14.2.0 的公共 API 與向後相容性變更
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
## **公共 API 與向後相容性變更**
{{% alert color="primary" %}} 

我們在 Aspose.Slides for .NET 14.2.0 API 中做了一些變更。某些屬性與方法已被移除，部分已移至其他命名空間。

{{% /alert %}} 
### **已移除 Aspose.Slides.IPresentation.Write(…) 方法**
這些方法僅將 Presentation 物件寫入 PPTX 格式檔案。於新版 API 中，Presentation 類別可用於處理所有格式。您可以使用 Presentation.Save(…) 方法將 Presentation 物件儲存為所有支援的格式。
### **與主題樣式相關的類別已移至 Aspose.Slides.Theme 命名空間**
以下類別已從 Aspose.Slides 命名空間移至 Aspose.Slides.Theme 命名空間。

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **自 Aspose.Slides for .NET 8.X.0 起的變更**
Aspose.Slides for .NET 8.4 的功能已加入至 Aspose.Slides for .NET 14.2.0