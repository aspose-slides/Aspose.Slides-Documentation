---
title: 在 Docker 中執行 Aspose.Slides for .NET
linktitle: Docker
type: docs
weight: 140
url: /zh-hant/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 容器
- 多階段建置
- 容器映像
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- 字型
- PDF 轉換
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Docker 中建置並執行 Aspose.Slides for .NET 主控台應用程式：使用官方 .NET 映像的多階段 Dockerfile、所需的 Linux 函式庫與字型，以及如何將產生的檔案複製到您的機器上。"
---
## **概述**

本文說明如何在 Docker 容器中執行 Aspose.Slides for .NET。您會建立一個小型主控台應用程式，該程式會建立含文字方塊的簡報並將其轉換為 PDF，使用多階段 Dockerfile 以 Microsoft 官方的 .NET 映像封裝、執行，然後將產生的檔案複製到您的機器。本文亦列出 Aspose.Slides 在容器中所需的 Linux 函式庫與字型，最後提供 Alpine Linux 的變體。

您只需要在機器上安裝 Docker。 .NET SDK 已包含在建置映像中，您無需自行安裝。若要安裝 Docker，請參閱[取得 Docker](https://docs.docker.com/get-started/get-docker/)。

## **選擇套件與基礎映像**

預設的 .NET 10 容器映像是以 Ubuntu 24.04 為基礎。在這些映像上，請使用[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 套件。它需要 `fontconfig` 函式庫，且 .NET 執行時映像既不包含該函式庫也不包含任何字型，因此本文的 Dockerfile 會安裝兩者。

Aspose.Slides.NET6.CrossPlatform 無法在 Alpine Linux 上執行。對於基於 Alpine 的映像，請改用[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 套件並安裝 `libgdiplus`，如[在 Alpine Linux 上執行](#run-on-alpine-linux)所述。[安裝](/slides/zh-hant/net/installation/) 會比較這兩個套件。

## **建立專案**

建立一個名為 *HelloSlidesDocker* 的資料夾，並將以下三個檔案加入其中。

*HelloSlidesDocker.csproj* 描述一個針對 .NET 10 的主控台應用程式（即下方所使用的容器映像版本），並參考 Aspose.Slides.NET6.CrossPlatform。將套件版本設定為 [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 上列出的最新版本。

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* 會建立一個[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，在第一張投影片上加入帶文字的矩形，並使用[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法將簡報分別儲存為 PPTX 與 PDF。兩個檔案皆會寫入工作目錄下的 *output* 資料夾。接著，程式會列出 PDF 產生過程中被取代的字型，使用[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)，讓您得以確認容器是否擁有簡報所使用的字型。

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* 會將本機建置產生的 *bin* 與 *obj* 資料夾，以及先前執行的輸出，排除在 Docker 建置上下文之外，確保映像僅由原始檔案建構。

```text
bin/
obj/
output/
```

## **編寫 Dockerfile**

在同一資料夾加入名為 *Dockerfile* 的檔案：

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

此檔案包含兩個階段：

- **建置階段** 以 .NET SDK 映像為起點。它會先拷貝專案檔並還原 NuGet 套件，讓 Docker 只要專案檔未變動就能重複使用該層。之後拷貝原始碼並將應用程式發佈到 */app*。
- **執行階段** 以較小的 .NET 執行時映像為起點（該映像不含 SDK），僅拷貝已發佈的應用程式。它會安裝兩個套件：
  - `libfontconfig1`：Aspose.Slides.NET6.CrossPlatform 在啟動時會載入此函式庫。若缺少，應用程式會因找不到 `libfontconfig.so.1` 而拋出 `DllNotFoundException`。
  - `fonts-dejavu-core`：執行時映像沒有任何字型，而 Aspose.Slides 至少需要一個已安裝的字型才能繪製文字；若沒有字型，轉換會因 `InvalidOperationException: Cannot find any fonts installed on the system.` 而中止。未安裝的字型會使用替代字型繪製。DejaVu 字型是一組小型字型，足以讓文字呈現；若要使用簡報設計時的原始字型，請參閱[部署字型](/slides/zh-hant/net/deploy-fonts/)。

  `--no-install-recommends` 以及套件清單的移除可讓映像保持小體積。最後幾行建立 *output* 資料夾，將其所有權指派給官方 .NET 映像中定義的非 root `app` 使用者（其使用者 ID 位於 `APP_UID` 變數），並以該使用者身分執行應用程式。

對於 ASP.NET Core 應用程式，請將執行階段的基礎映像改為 `mcr.microsoft.com/dotnet/aspnet:10.0`。此映像同樣基於 Ubuntu，所需套件相同。

## **建置並執行容器**

在 *HelloSlidesDocker* 資料夾內開啟終端機。先建置映像，然後從映像執行容器：

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

首次建置會下載基礎映像與 NuGet 套件，因而較後續建置花費更長時間。容器會執行應用程式後結束，並輸出：

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

第一行顯示文字使用的是 Calibri（新簡報的預設字型），但 Calibri 未安裝於映像中，於是 Aspose.Slides 以 DejaVu Sans 作為替代字型繪製。PDF 中的文字是真正的、可選取的文字，且使用該替代字型。若未取得授權，Aspose.Slides 仍會在每張投影片上加上評估水印；請參閱[授權](/slides/zh-hant/net/licensing/)。

## **將輸出複製到本機**

這些檔案位於已停止容器的 */app/output* 資料夾。將它們複製到本機的 *output* 資料夾，接著移除容器：

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

上述兩個指令在 Bash、PowerShell 與 Windows 命令提示字元中皆以相同方式運作。

在 Linux 上，您也可以將本機資料夾掛載到容器，讓應用程式直接寫入該資料夾：

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 選項會以您的使用者與群組 ID 執行應用程式，讓它能寫入您建立的資料夾，且檔案屬於您。`--rm` 則會在容器停止時將其移除。

## **在 Alpine Linux 上執行**

若要在基於 Alpine 的映像中執行應用程式，請改用 Aspose.Slides.NET 套件並調整執行階段。建置階段保持不變。

1. 在 *HelloSlidesDocker.csproj* 中，將套件參考改為：

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. 在 *Program.cs* 中，於 `using` 指令之後、第一次呼叫 Aspose.Slides 之前加入以下敘述，以啟用 Aspose.Slides.NET 在 Linux 上使用的 System.Drawing 支援：

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. 在 *Dockerfile* 中，將執行階段（從第二個 `FROM` 行起的全部內容）替換為：

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine 階段會安裝三個套件並變更一項設定：

- `libgdiplus` 為 Aspose.Slides.NET 在 Linux 上使用的圖形函式庫。
- `font-dejavu` 提供字型。若沒有任何字型，轉換會因 `System.ArgumentException: Font '?' cannot be found` 而中止。
- `icu-libs` 與 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` 提供語系資料。Alpine .NET 映像預設以全球化不變模式執行，在此模式下 Aspose.Slides 會因缺少 `en-US` 的文化資訊而拋出 `CultureNotFoundException`。

使用與前述相同的指令建置、執行並複製輸出。於此映像中，應用程式僅會列印 `Saved` 行：在 Linux 上使用 Aspose.Slides.NET 時，fontconfig 會自行選擇缺失字型的替代字型，而 [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 不會列出它。請參閱[部署字型](/slides/zh-hant/net/deploy-fonts/) 以了解如何檢查實際使用的字型。

## **常見問題集**

**應用程式因「Unable to load shared library 'libaspose.slides.drawing.capi…'」而停止。缺少什麼？**

在 Ubuntu 與 Debian 映像上，需要安裝 `libfontconfig1` 套件；訊息會列出找不到的檔案 `libfontconfig.so.1`。在 Alpine Linux 上，訊息表示仍在使用 Aspose.Slides.NET6.CrossPlatform；請改用 Aspose.Slides.NET，方法請見[在 Alpine Linux 上執行](#run-on-alpine-linux)。

**為什麼 PDF 中的文字字型與 PowerPoint 不同？**

簡報使用的字型未安裝於映像中，導致 Aspose.Slides 使用替代字型繪製文字。程式的輸出會列出每一個被替換的字型。請參閱[部署字型](/slides/zh-hant/net/deploy-fonts/)，了解如何在映像中安裝字型或從應用程式資料夾載入字型。

**我需要在機器上安裝 .NET SDK 嗎？**

不需要。建置階段會在 SDK 映像內編譯應用程式。只有在您想在 Docker 之外自行建置與執行應用程式時才需要 SDK；請參閱[安裝](/slides/zh-hant/net/installation/)。