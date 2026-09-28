---
title: 為 Aspose.Slides 在 Linux 與 Docker 部署字型
linktitle: 部署字型
type: docs
weight: 145
url: /zh-hant/net/deploy-fonts/
keywords:
- 部署字型
- 安裝字型
- Docker 中的字型
- Linux 上的字型
- 缺少的字型
- 字型替代
- Microsoft 核心字型
- ttf-mscorefonts-installer
- 自訂字型
- 預設字型
- 伺服器
- 容器
- PDF 轉換
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Linux 伺服器與 Docker 容器上為 Aspose.Slides for .NET 部署字型：檢查哪些字型被替代、在 Debian、Ubuntu 與 Alpine 上安裝字型套件、加入自訂字型檔案，並設定預設字型。"
---
## **概覽**

Aspose.Slides 在呈現投影片時會使用可用的字型來繪製文字，例如在將投影片轉換為 PDF 或影像時。Windows 桌面通常已安裝投影片所使用的字型。Linux 伺服器與容器通常只有少量或根本沒有字型，因此 Aspose.Slides 會使用替代字型來繪製文字。替代字型的字形與寬度不同，導致換行方式改變、文字可能溢出其形狀，且替代字型缺少的字元無法正確繪製。若根本未安裝任何字型，轉換會因錯誤而停止。

本文說明如何檢查 Aspose.Slides 替代了哪些字型、如何在 Debian、Ubuntu 與 Alpine Linux 上安裝字型、如何加入自己的字型檔案，以及如何設定缺少字型時使用的字型。範例在官方 .NET 映像的 Docker 環境中執行，請參考 [在 Docker 中執行 Aspose.Slides for .NET](/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/)。套件指令為 Dockerfile 指令；在 Linux 伺服器上，請以 root 身份執行相同的指令。

若要了解字型 API 本身，例如在簡報中嵌入字型以及備援與替換規則，請參閱 [PowerPoint 字型](/slides/zh-hant/net/powerpoint-fonts/)。

## **檢查哪些字型被替代**

以下的主控臺應用程式會報告在目前環境中 Aspose.Slides 替代的字型。建立一個名為 *FontCheck* 的資料夾，並將下列檔案加入其中。

*FontCheck.csproj* 參考 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)，此套件適用於 Debian 與 Ubuntu。它同時會將可選的 *fonts* 資料夾檔案複製到應用程式輸出；[從應用程式資料夾載入字型](#load-fonts-from-the-application-folder) 章節會使用它。

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* 為每個字型名稱在投影片上新增一個文字方塊，並透過 [LatinFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/latinfont/) 屬性指定字型。字型名稱來自命令列；若未提供參數，應用程式會檢查 Calibri、Arial 與 Times New Roman。它會列印 Aspose.Slides 搜尋字型的資料夾（[FontsLoader.GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/)），將投影片渲染至 *output/fonts.pdf*，並列印由 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/) 回報的替代情況。文章稍後會說明兩個可選的起始步驟：載入 *fonts* 資料夾以及讀取 `DEFAULT_FONT` 變數。

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// 要檢查的字型：命令列參數，或三個常見的 Office 字型。
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Load the font files from the fonts folder next to the application, if there is one.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Use the font named in the DEFAULT_FONT environment variable, if it is set, for text whose font is missing.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* 可將本機建置結果排除於建置上下文之外：

```text
bin/
obj/
output/
```

*Dockerfile* 使用 .NET SDK 映像建置應用程式，並於 .NET 執行階段映像執行。執行階段會安裝 `libfontconfig1`（Aspose.Slides.NET6.CrossPlatform 所需）以及 DejaVu 字型。[在 Docker 中執行 Aspose.Slides for .NET](/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/) 會說明每個指令。

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

建置映像並執行檢查：

```bash
docker build -t font-check .
docker run --rm font-check
```

此映像僅包含 DejaVu 字型，故三種字型皆被替換為 DejaVu Sans：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

若要檢查您自己的簡報所使用的字型，請將其名稱作為參數傳遞，例如 `docker run --rm font-check "Segoe UI" Consolas`。若要將 *output/fonts.pdf* 從容器中複製出來，請使用 [將輸出複製到您的機器](/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) 中的指令。

## **在 Debian 與 Ubuntu 上安裝字型**

### **Microsoft 核心字型**

`ttf-mscorefonts-installer` 套件會下載並安裝 Microsoft 的網頁核心字型，包括 Arial、Times New Roman、Courier New、Verdana、Georgia 與 Trebuchet MS。這些字型受 Microsoft 最終使用者授權合約 (EULA) 之約束，套件僅在接受 EULA 後才會安裝。Docker 建置無法回應提示，導致安裝程式拒絕 EULA 並未安裝任何字型，儘管 `apt-get install` 仍顯示成功。請在安裝套件之前使用 `debconf-set-selections` 接受 EULA。

在 *Dockerfile* 中，將執行階段安裝套件的 `RUN` 指令取代為以下內容：

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

重新建置映像並使用相同的兩個指令再次執行檢查。Arial 與 Times New Roman 現已安裝：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri 為 Aspose.Slides 建立的簡報之預設字型，並非核心字型之一，仍會被替代。請參閱 [設定缺少字型時的預設字型](#set-a-default-font-for-missing-fonts)。

在 Debian 上，此套件位於 `contrib` 套件庫元件中，而 Debian 映像預設未啟用此元件；預設的 .NET 8 與 .NET 9 映像基於 Debian 12。請在相同指令中啟用 `contrib`：

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

基於 Ubuntu 的 .NET 10 映像已預設啟用 `multiverse`，即包含此套件的 Ubuntu 元件。

### **其他字型套件**

Debian 與 Ubuntu 亦提供自由授權的字型套件，例如：

| 套件 | 字型 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

在相同的 `RUN` 指令中使用 `apt-get install` 安裝它們。Aspose.Slides.NET6.CrossPlatform 不會套用 Linux 字型設定的別名：即使安裝了 `fonts-liberation`，Arial 文字仍會以一般的替代字型繪製，而不是 Liberation Sans。若要以度量相容的字型替代缺少的字型，請將其設定為 [預設字型](#set-a-default-font-for-missing-fonts) 或加入 [字型替代規則](/slides/zh-hant/net/font-substitution/)。

## **新增自訂字型檔案**

發行版未提供的字型（例如貴組織的字型或您有授權在伺服器上使用的其他字型），可直接以字型檔案方式加入。將字型檔案（例如 *.ttf* 檔）放入 *FontCheck* 資料夾內名為 *fonts* 的子資料夾。以下範例使用 Carlito 字型檔案，該字型與 Calibri 具有相同的度量，您可從 [Google Fonts](https://fonts.google.com/specimen/Carlito) 下載。

### **將字型安裝至系統字型資料夾**

Aspose.Slides 會讀取 `Font folders` 行列印出的資料夾內的字型。若要為映像中的所有應用程式安裝字型，請將它們複製到 */usr/local/share/fonts*（本機安裝字型的資料夾）。在 *Dockerfile* 的執行階段，於安裝套件的 `RUN` 指令之後加入以下指令：

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **從應用程式資料夾載入字型**

不必將字型安裝至映像中，您可以將它們隨應用程式一起部署，並透過 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 載入。此方式僅讓 Aspose.Slides 可使用這些字型，且會與應用程式一同部署。*FontCheck* 便是這樣做：*FontCheck.csproj* 會將 *fonts* 資料夾複製到應用程式輸出，而 *Program.cs* 在建立簡報之前將該資料夾傳遞給 `LoadExternalFonts`。[自訂字型](/slides/zh-hant/net/custom-font/) 說明了提供字型的其他方式，例如從記憶體載入。

重新建置映像，然後檢查 Calibri 與 Carlito：

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

應用程式資料夾現在出現在字型資料夾列表中，且 Carlito 不再被替代：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **設定缺少字型時的預設字型**

當缺少字型時，Aspose.Slides 會自行選擇替代字型。若要自行指定，請設定 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 的 [DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaultregularfont/) 屬性，並將該選項傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 建構式。*FontCheck* 會從 `DEFAULT_FONT` 環境變數讀取字型名稱。載入 Carlito 後，將其用於缺少的字型：

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri 現在以 Carlito 繪製，Carlito 的字元寬度與 Calibri 相同，故文字保持原有換行：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

預設字型會取代所有缺少的字型。若要為個別字型映射，例如將 Arial 映射至 Liberation Sans、Calibre 映射至 Carlito，請使用 [字型替代規則](/slides/zh-hant/net/font-substitution/)。規則會改變渲染結果，但 `GetSubstitutions` 不會顯示這些變更，故請改以檢查輸出檔案中的字型。對於亞洲文字，亦需設定 [DefaultAsianFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaultasianfont/)，詳情請見 [預設字型](/slides/zh-hant/net/default-font/)。

## **在 Alpine Linux 上安裝字型**

在 Alpine Linux 上，使用 Aspose.Slides.NET 套件；[在 Alpine Linux 上執行](/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) 列出對專案的變更。對 *FontCheck* 進行相同的調整：取代套件參考、在 *Program.cs* 中加入 `SetSwitch` 陳述式，並使用此執行階段，它同時會安裝 Microsoft 核心字型：

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` 會下載並安裝與 Debian 與 Ubuntu 套件相同的 Microsoft 核心字型，其 EULA 以相同方式適用。`fc-cache` 會更新字型快取。

在 Linux 上使用 Aspose.Slides.NET 時，字型設定函式庫 (fontconfig) 會為缺少的字型選擇替代字型，且 `GetSubstitutions` 不會回報此情況，故 *FontCheck* 會顯示 `No font substitutions.` 若要查看字型名稱實際使用的字型，可在容器中詢問 fontconfig：

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

安裝 Microsoft 核心字型後，Arial 會使用 Arial：

```text
Arial.ttf: "Arial" "Regular"
```

若未安裝，且 `RUN` 指令僅安裝 `icu-libs libgdiplus font-dejavu`，相同的指令會輸出：

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **常見問題**

**為何簡報在伺服器上轉換後會顯示不同？**

伺服器缺少簡報所使用的字型，導致 Aspose.Slides 使用字形寬度不同的替代字型繪製文字。使用 *FontCheck* 並傳入簡報的字型名稱即可查看哪些字型被替代，然後安裝這些字型或從應用程式資料夾載入。

**建置已安裝 ttf-mscorefonts-installer，但 Arial 仍被替代。為什麼？**

EULA 沒有在套件安裝前被接受，導致安裝程式跳過字型。請在 `apt-get install` 之前加入 `debconf-set-selections` 指令，如同 [Microsoft 核心字型](#microsoft-core-fonts) 所示，然後重新建置映像。

**開啟 PDF 的電腦需要安裝這些字型嗎？**

不需要。以上範例的 PDF 已內嵌用於繪製文字的字型，故在任何電腦上顯示皆相同。字型僅在 Aspose.Slides 渲染簡報的環境中需要。