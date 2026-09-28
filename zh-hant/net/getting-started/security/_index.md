---
title: 安全性
type: docs
weight: 160
url: /zh-hant/net/security/
keywords:
- 安全
- 相依性
- 第三方元件
- NuGet
- 漏洞掃描
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 處理簡報的方式、它在每個目標框架下所依賴的 NuGet 套件，以及它所包含的第三方元件。"
---
## **Aspose.Slides 的安全性**

Aspose 在開發其產品時遵循最佳實務。

* Aspose.Slides for .NET 用於操作簡報並將其轉換為其他格式。它不會在簡報中執行腳本。Aspose.Slides 會解析簡報結構，讓最終使用者的程式碼以方便的方式操作物件模型。
* Aspose.Slides 作為一個函式庫，解析並解釋文件而不執行遠端程式碼。所有 Aspose 產品都在您的機器上執行。它們不會將任何資料傳送至 Aspose。唯一的例外是[計量授權](https://purchase.aspose.com/faqs/licensing/metered): 如果您使用計量授權，僅會處理您的 API 使用資訊。
* Aspose 元件在與一般應用程式相同的使用者上下文中執行。因此，Aspose 元件不會對重要系統資源構成風險。此外，當 Aspose 元件開啟文件時，巨集不會自動執行。
* Microsoft Office 套件本身或相關的風險不會套用於 Aspose 元件，因此 Aspose 產品相當安全。

## **NuGet 相依性**

Aspose.Slides for .NET 依賴 Microsoft 在 NuGet 上發布的套件。相依性依套件與目標框架而異：

| 套件 | 目標框架 | 相依套件 |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

NuGet 上的 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 與 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 頁面的 **相依套件** 區段列出了每個版本的每項相依套件的最低版本。

將 Aspose.Slides 加入專案時，NuGet 也會還原這些套件的相依性。若要列出專案還原的所有套件（包括這些傳遞相依性），請在專案資料夾中執行以下指令：

```bash
dotnet list package --include-transitive
```

若要檢查相同套件集合是否存在已知漏洞，請執行：

```bash
dotnet list package --vulnerable --include-transitive
```

欲了解其他審核 NuGet 套件的方法，請參閱[審核套件相依性以偵測安全漏洞](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages)。

## **第三方元件**

Aspose.Slides 包含來自第三方開放原始碼元件的程式碼。它們是產品的一部份，而非獨立的 NuGet 套件，因此僅讀取 NuGet 相依性的工具不會列出它們。兩個套件皆包含檔案 *thirdpartylicenses.Aspose.Slides.for.NET.pdf*，列出元件及其授權資訊：

| 元件 | 授權聲明 |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **常見問題**

**使用什麼系統來監控 Aspose 程式碼的漏洞？**

我們對每個 Aspose.Slides 版本執行靜態程式碼分析。我們可提供安全報告，證明 Aspose.Slides 程式碼符合 OWASP Top 10。

**Aspose.Slides 是否使用外部套件？**

是的。它依賴於在 [NuGet 相依性](#nuget-dependencies) 中列出的 Microsoft NuGet 套件，並且包含在 [第三方元件](#third-party-components) 中列出的第三方元件。請在安全性評估中同時考慮兩者，並使用 `dotnet list package --vulnerable --include-transitive` 來檢查專案還原的 NuGet 套件。