---
title: .NET 6 支援
type: docs
weight: 235
url: /zh-hant/net/net6/
keywords:
- .NET 6 支援
- 雲端解決方案
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "將 Aspose.Slides for .NET 6 設定為在現代跨平台 C# 應用程式中建立、編輯與轉換 PowerPoint PPT、PPTX 與 ODP 簡報。"
---
## **簡介**

從 [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) 開始，已實作對 .NET6 的支援。此支援的特殊之處在於 .NET6 不再支援 Linux 上的 System.Drawing.Common（[重大變更](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），且 Slides 自行以 C++ 元件實作此圖形子系統。

Aspose.Slides for .NET 現在在以下平台上無需依賴 GDI/libgdiplus：
* Windows
* Linux

_MacOS_ 支援正在進行中。

## **在 AWS 與 Azure 上使用 .NET 6 版 Slides**

.NET6 是在雲端（AWS、Azure 或其他雲端解決方案）使用 Aspose.Slides 的首選版本。

先前，若在 Linux 主機上使用 Aspose.Slides，必須安裝額外的相依性（libgdiplus），這常常不便或不實際（例如在使用 [AWS Lambda](https://aws.amazon.com/lambda) 時）。使用 .NET6 版 Slides 後，這些依賴不再需要，部署變得更簡單。

另一個需要考慮的問題是，當在 Windows 主機的雲端方案上使用 Aspose.Slides 時會發生的問題。例如，[Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) 針對處理程序有限制，導致 PDF 匯出作業時出現問題（參見[此處](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)）。使用 .NET6 版 Aspose.Slides 可解決此問題。

## **使用 System.Drawing.Common 套件與 .NET 6 版 Slides 類別（CS0433：類型同時存在於 Slides 與 System.Drawing.Common 中的錯誤）**

有時，專案中必須同時使用 System.Drawing 與 .NET6 版 Slides 的相依性（例如，.NET6 專案依賴其他套件，而這些套件又依賴 System.Drawing）。這可能導致以下衝突錯誤：

* CS0433: 類型 'Image' 同時存在於 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' 與 'System.Drawing.Common, Version=6.0.0.0' 中
* CS0433: 類型 'Graphics' 同時存在於 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' 與 'System.Drawing.Common, Version=6.0.0.0' 中

在此情況下，您可以使用 [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) 針對 Aspose.Slides（版本低於 24.8）：
1) 從專案的相依性中選取 Aspose.Slides 程式集，然後點選 **Properties**。
  ![Aspose Slides 套件屬性](package_properties.png)
2) 設定別名（例如，「Slides」）。
  ![Aspose Slides 別名](set_alias.png)

現在，預設會使用 System.Drawing.Common 中的類型。需要 Aspose.Slides 類型的地方，應指定外部組件別名。

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

完整範例：

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

自 24.8 版起，已移除依賴 System.Drawing 的已棄用公開 API。針對上述程式碼範例，您可以如下取得投影片影像。

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
新的 API 已於 [Modern API](/slides/zh-hant/net/modern-api/) 中有更詳細的說明。