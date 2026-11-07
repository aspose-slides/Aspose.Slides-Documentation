---
title: Aspose.Slides for .NET 中的字型選擇序列
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/net/font-selection-sequence/
keywords:
- 字型選擇
- 字型置換
- 字型替換
- 置換規則
- 可用字型
- 缺少字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的字型清晰且一致—立即提升您的簡報。"
---
## **概觀**

當載入、呈現或轉換為其他格式時，Aspose.Slides 會考慮投影片中內嵌的字型以及應用程式可用的字型。如果所需的字型不可用，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 會使用的替代字型。

可用的字型可以包括系統字型、應用程式載入的字型以及投影片內嵌的字型。對於匹配的內嵌與已註冊字型，以下描述的 .NET 26.11 偏好控制哪一個優先。透過 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) 定義的字型置換規則是另一種機制。

您也可以在應用程式執行時加入字型、使用投影片內嵌的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

文字可以參照主題字型，例如 `+mn-lt`，而不是明確的字型族名稱。請參閱 [解析主題字型參照](/slides/zh-hant/net/presentation-theme/#resolve-theme-font-references) 以取得適用主題指定的字型族。解析此參照與檢查字型是否可用以及套用呈現時的置換或字形回退是分開的程序；它不會識別最終用來呈現文字的字型檔案。

在呈現投影片或轉換投影片時，請檢查所請求的字型是否已內嵌或可從已註冊來源取得。缺少的字型可能需要替換或置換；請參閱 [**字型替換**](/slides/zh-hant/net/font-replacement/) 和 [**字型置換**](/slides/zh-hant/net/font-substitution/)。

在調查字型選擇時：
1. 解析請求的字型族與樣式，包括任何主題參照。
2. 檢查內嵌字型與已註冊來源，包括系統字型與應用程式載入的字型。如果內嵌與已註冊版本相衝突，請使用以下偏好設定。
3. 檢閱 [字型置換規則](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) 並在請求的字型或字元不可用時使用字形回退。

Aspose.Slides 允許您在應用程式執行時加入字型，然後使用這些字型。請參閱 [**自訂字型**](/slides/zh-hant/net/custom-font/)。

當在投影片中加入額外的字型時，稱為 [**內嵌字型**](/slides/zh-hant/net/embedded-font/)。

Aspose.Slides 允許您加入僅套用於 *輸出文件* 的字型。例如，若您要轉換為 PDF 的投影片缺少系統與內嵌字型，您可以將所需的字型加入或載入為 **外部字型**。

{{% alert title="Note" color="info" %}} 
我們不提供任何字型的分發，無論是付費或免費。我們的 API 允許您載入外部字型並將其內嵌於文件，但此操作須由您自行斟酌與負責。
{{% /alert %}}

## **在內嵌字型之上優先使用已註冊字型**

自 .NET 26.11 開始，[IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) 允許在匯出時讓匹配的已註冊字型優先於內嵌字型。預設為 `false`。匹配使用字型名稱與樣式；不同的字型族名稱不視為替代匹配。已註冊字型可以來自系統或 [明確載入的字型來源](/slides/zh-hant/net/custom-font/)。

以下範例在 .NET 8 上使用 **Aspose.Slides.NET6.CrossPlatform 26.11** 套件。請依照您的環境參考 [安裝指南](/slides/zh-hant/net/installation/)。提供含有內嵌字型的 `embedded-fonts.pptx` 與具有相同字型族名稱與樣式的 `preferred.ttf`。如果要比較輸出結果，這兩個字型檔案應在外觀上有所差異。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

此設定會在匯出時變更字型優先順序；它不會重新命名文字的字型、移除內嵌字型資料或重新內嵌已註冊檔案。它是執行時設定：在重新開啟投影片後需要再次設置。若沒有匹配的已註冊字型，啟用此偏好亦不會提供字型；請在目標環境中驗證最終的字型與版面配置。

已使用明確載入的常規字型檢查上述配置的 PNG 與 PDF 輸出。請在依賴相同結果之前，檢查您自己的字型檔案、樣式、SDK 版本與輸出格式。字型度量可能會改變換行與定位。當需要不同字型族時，請使用 [字型替換](/slides/zh-hant/net/font-replacement/) 或 [字型置換](/slides/zh-hant/net/font-substitution/)；當需要變更投影片中儲存的字型時，請使用 [內嵌字型操作](/slides/zh-hant/net/embedded-font/)。

## **常見問題**

**如何判斷在轉換前投影片實際使用了哪些字型？**

Aspose.Slides 讓您透過 [字型管理員](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 檢視使用的字型，從而決定是否要 [內嵌](/slides/zh-hant/net/embedded-font/)、[替換](/slides/zh-hant/net/font-replacement/) 或加入 [外部來源](/slides/zh-hant/net/custom-font/)。這有助於防止在呈現與匯出過程中發生不希望的置換。

**我可以在不將字型安裝到作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊如資料夾或記憶體串流等 [外部字型來源](/slides/zh-hant/net/custom-font/) 供呈現與匯出使用。此方式消除對主機系統字型的依賴，並使版面配置保持可預測。

**當字形缺失時，如何防止靜默回退到不適合的字型？**

事先定義明確的 [字型替換](/slides/zh-hant/net/font-replacement/) 與字型 [回退規則](/slides/zh-hant/net/fallback-font/) 。透過分析使用的字型並為替代字型設定受控的優先順序，您可以確保排版一致，避免意外結果。