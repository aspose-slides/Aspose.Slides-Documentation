---
title: 安裝
type: docs
weight: 70
url: /zh-hant/nodejs-net/installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "在 Windows 或 Linux 上，透過 npm 安裝 Aspose.Slides for Node.js via .NET：先決條件、edge-js 覆寫、一次性的 NuGet 還原，以及建立簡報的第一個程式。"
---
## **概述**

Aspose.Slides for Node.js via .NET 是 npm 套件 `aspose.slides.via.net`。它透過 [edge-js](https://github.com/agracio/edge-js) 橋接在 Node.js 中執行 Aspose.Slides .NET 函式庫，因此完整的安裝需要同時具備 Node.js 與 .NET。

本文將帶您從全新機器開始，建立第一個產生簡報的程式。共有四個步驟：建立包含 edge-js 覆寫的專案、從 npm 安裝套件、一次還原套件的 .NET 相依性，以及從專案資料夾執行您的腳本。

## **先決條件**

- **Node.js 22 或 24 LTS**，x64 版本，請自 [nodejs.org](https://nodejs.org/en/download) 下載。
- **.NET SDK 8 或更新版本**，請自 [dotnet.microsoft.com](https://dotnet.microsoft.com/download) 下載。僅有 .NET 執行階段不足以運作：以下的還原步驟需要 SDK，腳本執行時橋接也需要。請執行 `dotnet --list-sdks` 以檢查已安裝的 SDK。
- **僅限 Linux**：
  - 建置工具 `python3`、`make` 與 `g++`，因為 npm 在 Linux 上安裝時會編譯 edge-js；
  - fontconfig 函式庫，Aspose.Slides 本機繪圖函式庫會載入它。

  在 Debian 上，這些套件為 `python3`、`make`、`g++` 以及 `libfontconfig1`。

本文件中的步驟已在以下平台上測試：

| 平台 | 結果 |
|---|---|
| Windows x64 with Node.js 22 or 24 | 可執行。已安裝 Microsoft Visual C++ 可再發行套件，測試通過。 |
| Linux x64 with Node.js 22 or 24，系統 OpenSSL 與 Node.js 內建的 OpenSSL 為相同發布系列（例如 Debian 13） | 可執行。 |
| Linux 兩個 OpenSSL 版本不同的情況（例如 Debian 12） | 建立簡報時 Node.js 會因段錯誤（segmentation fault）而崩潰。 |
| macOS | 尚未驗證。 |

在 Linux 上，開始前請先比較兩個版本。第一個指令會印出內建於 Node.js 的 OpenSSL 版本；第二個則印出系統版本。請使用兩者主要與次要版本號相同的系統，例如 `3.5`：

```sh
node -p process.versions.openssl
openssl version
```

如果找不到 `openssl` 指令，請先安裝 `openssl` 套件。

## **建立專案**

為您的專案建立資料夾、初始化，並加入一個覆寫，指定 npm 安裝哪個 edge-js 版本：

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

此套件要求較舊的 edge-js 版本，而其預建的 Windows 二進位檔僅支援至 Node.js 20。因此若未使用此覆寫，Windows 上執行第一個腳本時會出現「The edge module has not been pre-compiled for node.js version」的錯誤。此指令會將覆寫寫入 `package.json` 的 `overrides` 部分；請在安裝套件之前先加入它。

## **安裝套件**

從 npm 安裝 Aspose.Slides for Node.js via .NET：

```sh
npm install aspose.slides.via.net
```

安裝過程中，套件會將其本機繪圖函式庫（檔名含 `aspose.slides.drawing.capi` 的檔案）複製到專案資料夾，與 `package.json` 同層。

此套件亦以 ZIP 壓縮檔形式發佈於 [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/)。本文僅說明從 npm 安裝的方式。

## **還原 .NET 相依性**

套件內含 Aspose.Slides .NET 組件，但不包含這些組件所依賴的 20 個 NuGet 套件。執行時，.NET 會在 NuGet 套件快取中尋找它們：Windows 為 `%USERPROFILE%\.nuget\packages`，Linux 為 `~/.nuget/packages`，或 `NUGET_PACKAGES` 環境變數所指定的資料夾。若快取中缺少這些套件，第一個腳本會顯示「assembly specified in the dependencies manifest was not found」錯誤。

為了填滿快取，請在專案資料夾建立名為 `deps` 的資料夾，並將以下檔案儲存為 `deps.csproj`。每個 `PackageDownload` 項目會下載括號中指定版本的套件；不會進行編譯。

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

然後在專案資料夾執行還原：

```sh
dotnet restore deps/deps.csproj
```

此步驟只需在每台機器執行一次，而非每個專案一次：套件會保留在 NuGet 快取中，同一機器上的其他專案可直接使用。還原完成後，可刪除 `deps` 資料夾。

## **執行第一個程式**

在專案資料夾建立名為 `hello.js` 的檔案，內容如下。程式會建立簡報、在第一張投影片加入寫有「Hello, World!」的矩形，並將結果儲存為 `hello.pptx`：

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新的簡報包含一張空白投影片。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置與大小以點 (1/72 英吋) 為單位：x、y、寬度、高度。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 釋放支援簡報的 .NET 物件。
    presentation.dispose();
}
```

在專案資料夾執行它：

```sh
node hello.js
```

腳本會輸出 `Saved hello.pptx`。開啟 `hello.pptx` 可看到一張投影片，內有填滿顏色且包含文字的矩形。若未取得授權，Aspose.Slides 會加上評估浮水印；請參閱 [Evaluate Aspose.Slides](/slides/zh-hant/nodejs-net/evaluate-aspose-slides/) 與 [Licensing](/slides/zh-hant/nodejs-net/licensing/)。

{{% alert color="info" title="Note" %}}
從專案資料夾（即包含 `package.json` 的資料夾）執行您的腳本。相對路徑（例如 `hello.pptx`）會相對於當前資料夾解析，且在某些機器上，若從其他資料夾啟動腳本，可能無法建立簡報。
{{% /alert %}}

JavaScript API 與 Aspose.Slides for .NET 保持一致：類別保留 .NET 名稱，屬性與方法使用 camelCase（`Slides` 變為 `slides`，`AddAutoShape` 變為 `addAutoShape`），集合項目則透過 `get(index)` 取得。此套件沒有單獨的 API 參考文件，請使用 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 來查閱類別與成員細節，例如 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 與 [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)。

## **常見問題**

**「The edge module has not been pre-compiled for node.js version」意指什麼？**

npm 安裝了套件要求的較舊 edge-js 版本。請依照 [Create a Project](#create-a-project) 加入覆寫，然後再次執行 `npm install`。

**「assembly specified in the dependencies manifest was not found」意指什麼？**

.NET 相依性未在 NuGet 快取中。相同的執行也會顯示「edge.initializeClrFunc is not a function」。請先依照 [Restore the .NET Dependencies](#restore-the-net-dependencies) 執行一次，然後再次執行腳本。

**在 Linux 上「The edge native module is not available」意指什麼？**

在 `npm install` 時未編譯 edge-js，例如缺少 `python3`、`make` 或 `g++`。npm 不會將此視為錯誤。請安裝上述建置工具，然後在專案資料夾執行 `npm rebuild edge-js`。

**為何建立簡報時會失敗且僅顯示空的「Error」？**

在 Linux 上，請確認已安裝 fontconfig 函式庫（Debian 為 `libfontconfig1`）；若缺少，則本機繪圖函式庫無法載入。無論哪個系統，也請確保從專案資料夾執行腳本。

**為何 Node.js 在 Linux 上會因段錯誤（segmentation fault）而當機？**

系統的 OpenSSL 與 Node.js 內建的 OpenSSL 來自不同的發行系列。請如同在 [Prerequisites](#prerequisites) 中所示進行比較，並使用版本相符的發行版或 Node.js 建置。

**我需要為每個專案都重複 NuGet 還原嗎？**

不需要。還原會為您的使用者帳號填入 NuGet 快取，該機器上的所有專案皆會共用此快取。