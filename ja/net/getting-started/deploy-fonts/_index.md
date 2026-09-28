---
title: Linux と Docker で Aspose.Slides のフォントをデプロイ
linktitle: フォントをデプロイ
type: docs
weight: 145
url: /ja/net/deploy-fonts/
keywords:
- フォントデプロイ
- フォントインストール
- Docker のフォント
- Linux のフォント
- 欠落フォント
- フォント置換
- Microsoft コアフォント
- ttf-mscorefonts-installer
- カスタムフォント
- デフォルトフォント
- サーバー
- コンテナ
- PDF 変換
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Linux サーバーや Docker コンテナ上で .NET 用 Aspose.Slides のフォントをデプロイします。置き換えられるフォントの確認、Debian、Ubuntu、Alpine へのフォントパッケージのインストール、独自フォントファイルの追加、デフォルトフォントの設定が可能です。"
---
## **概要**

Aspose.Slides は、プレゼンテーションをレンダリングする際に使用可能なフォントでテキストを描画します。たとえばスライドを PDF や画像に変換する場合です。Windows デスクトップには通常、プレゼンテーションが使用するフォントが揃っています。Linux サーバーやコンテナにはフォントがほとんどないか全くないため、Aspose.Slides は代替フォントでテキストを描画します。代替フォントは文字形状や幅が異なるため、行の折り返しが変わったりテキストがシェイプからはみ出したり、代替フォントに存在しない文字は正しく描画されません。フォントがまったくインストールされていない場合、変換はエラーで停止します。

この記事では、Aspose.Slides が置き換えるフォントの確認方法、Debian、Ubuntu、Alpine Linux へのフォントのインストール方法、独自のフォント ファイルの追加方法、およびフォントが見つからない場合に使用するフォントの設定方法を示します。例は公式 .NET イメージ上の Docker で実行され、[Run Aspose.Slides for .NET in Docker](/slides/ja/net/how-to-run-aspose-slides-in-docker/) と同様です。パッケージコマンドは Dockerfile の指示です。Linux サーバーでは、同じコマンドを root で実行してください。

フォント API 自体（プレゼンテーションへのフォント埋め込みやフォールバック・置換ルールなど）については、[PowerPoint Fonts](/slides/ja/net/powerpoint-fonts/) を参照してください。

## **置き換えられるフォントの確認**

以下のコンソール アプリケーションは、現在の環境で Aspose.Slides が置き換えるフォントを報告します。*FontCheck* という名前のフォルダーを作成し、以下のファイルをその中に追加してください。

*FontCheck.csproj* は Debian および Ubuntu 用のパッケージである [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) を参照しています。また、オプションの *fonts* フォルダーのファイルをアプリケーションの出力にコピーします。[Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) セクションで使用します。

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

*Program.cs* はフォント名ごとにスライドにテキスト ボックスを 1 つ追加し、[LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/) プロパティでフォントを設定します。フォント名はコマンドラインから取得します。引数がない場合、アプリケーションは Calibri、Arial、Times New Roman をチェックします。Aspose.Slides がフォントを検索するフォルダー（[FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)）を表示し、スライドを *output/fonts.pdf* にレンダリングし、[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) が報告する置き換えを出力します。冒頭のオプションの 2 つの手順（*fonts* フォルダーのロードと `DEFAULT_FONT` 変数の読み取り）については、この記事の後半で説明します。

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// 確認するフォント: コマンドライン引数、または一般的な Office フォント 3 つ。
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// アプリケーションの隣にある fonts フォルダーからフォントファイルをロードします（存在する場合）。
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// 環境変数 DEFAULT_FONT に設定されたフォント名を、フォントが見つからないテキストに使用します（設定されている場合）。
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

*.dockerignore* はローカルのビルド結果をビルド コンテキストから除外します:

```text
bin/
obj/
output/
```

*Dockerfile* は .NET SDK イメージでアプリケーションをビルドし、.NET ランタイム イメージで実行します。ランタイム ステージでは、Aspose.Slides.NET6.CrossPlatform が必要とする `libfontconfig1` と DejaVu フォントをインストールします。[Run Aspose.Slides for .NET in Docker](/slides/ja/net/how-to-run-aspose-slides-in-docker/) が各指示を解説しています。

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

イメージをビルドし、チェックを実行します:

```bash
docker build -t font-check .
docker run --rm font-check
```

イメージには DejaVu フォントしかないため、3 つのフォントすべてが DejaVu Sans に置き換えられます:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

自分のプレゼンテーションのフォントを確認するには、フォント名を引数として渡します。例: `docker run --rm font-check "Segoe UI" Consolas`。コンテナから *output/fonts.pdf* をコピーするには、[Copy the Output to Your Machine](/slides/ja/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) のコマンドを使用してください。

## **Debian と Ubuntu へのフォントのインストール**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` パッケージは、Web 用の Microsoft のコア フォント（Arial、Times New Roman、Courier New、Verdana、Georgia、Trebuchet MS など）をダウンロードしてインストールします。これらのフォントは Microsoft のエンドユーザー ライセンス契約（EULA）に基づいてライセンスされており、パッケージは EULA が承認された後にのみインストールします。Docker ビルドではプロンプトに答えることができないため、インストーラは EULA を拒否し、フォントはインストールされませんが `apt-get install` は成功を報告します。パッケージをインストールする **前に** `debconf-set-selections` で EULA を承認してください。

*Dockerfile* では、ランタイム ステージでパッケージをインストールする `RUN` 命令を次のように置き換えます:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

イメージをビルドし、同じ 2 つのコマンドでチェックを再実行します。Arial と Times New Roman がインストールされました:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri は Aspose.Slides が作成するプレゼンテーションのデフォルトフォントですが、コア フォントには含まれないため、依然として置き換えられます。[Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts) を参照してください。

Debian では、パッケージは `contrib` リポジトリ コンポーネントにありますが、Debian イメージでは有効になっていません。デフォルトの .NET 8 と .NET 9 イメージは Debian 12 をベースにしています。同じ命令で `contrib` を有効にします:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

.NET 10 の Ubuntu ベース イメージはすでに `multiverse`（パッケージが含まれる Ubuntu コンポーネント）を有効にしています。

### **その他のフォント パッケージ**

Debian と Ubuntu でも、自由に使用できるフォントがパッケージ化されています。例:

| パッケージ | フォント |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans、DejaVu Serif、DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans、Serif、Mono（Arial、Times New Roman、Courier New と同じメトリック） |
| `fonts-crosextra-carlito` | Carlito（Calibri と同じメトリック） |
| `fonts-crosextra-caladea` | Caladea（Cambria と同じメトリック） |

同じ `RUN` 命令で `apt-get install` を使用してインストールします。Aspose.Slides.NET6.CrossPlatform は Linux のフォント設定のエイリアスを適用しません。`fonts-liberation` をインストールしても、Arial のテキストは一般的な代替フォントで描画され、Liberation Sans にはなりません。欠如したフォントの代わりにメトリック互換フォントを使用するには、[default font](#set-a-default-font-for-missing-fonts) として設定するか、[font substitution rule](/slides/ja/net/font-substitution/) を追加してください。

## **独自のフォント ファイルの追加**

ディストリビューションでパッケージ化されていないフォント（組織のフォントやサーバーで使用許諾を受けているその他のフォントなど）は、フォント ファイルとして追加できます。フォント ファイル（例: *.ttf* ファイル）を *FontCheck* フォルダー内の *fonts* フォルダーに配置します。以下の例では、Calibri と同じメトリックを持つフォントである Carlito のファイルを使用しています。Carlito は [Google Fonts](https://fonts.google.com/specimen/Carlito) からダウンロードできます。

### **システム フォント フォルダーにフォントをインストール**

Aspose.Slides は `Font folders` 行に表示されるフォルダー内のフォントを読み取ります。イメージ内のすべてのアプリケーションでフォントを使用できるようにするには、ローカル インストール用フォルダーである */usr/local/share/fonts* にコピーします。この指示を *Dockerfile* のランタイム ステージに、パッケージをインストールする `RUN` 命令の後に追加してください:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **アプリケーション フォルダーからフォントをロード**

イメージにフォントをインストールする代わりに、アプリケーションと一緒にフォントを配布し、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) でロードできます。この場合、フォントは Aspose.Slides のみが使用可能で、アプリケーションと共にデプロイされます。*FontCheck* はこの方法を使用しています。*FontCheck.csproj* は *fonts* フォルダーをアプリケーション出力にコピーし、*Program.cs* はプレゼンテーション作成前にそのフォルダーを `LoadExternalFonts` に渡します。[Custom Font](/slides/ja/net/custom-font/) では、メモリからのロードなど、他のフォント提供方法について説明しています。

イメージを再ビルドし、Calibri と Carlito を確認します:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

アプリケーション フォルダーがフォント フォルダーに表示され、Carlito はもはや置き換えられなくなります:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **欠如フォント用デフォルト フォントの設定**

フォントが見つからない場合、Aspose.Slides は自動的に代替フォントを使用します。自分で指定したい場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) プロパティを設定し、そのオプションを [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) コンストラクターに渡します。*FontCheck* は `DEFAULT_FONT` 環境変数からフォント名を取得します。Carlito をロードした状態で、欠如フォントにそれを使用します:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri は現在 Carlito で描画され、文字幅が Calibri と同じなので、テキストは改行位置を保持します:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

デフォルト フォントはすべての欠如フォントを置き換えます。個別のフォント（例: Arial を Liberation Sans、Calibri を Carlito にマップ）を設定するには、[font substitution rules](/slides/ja/net/font-substitution/) を使用してください。ルールはレンダリング結果を変えますが、`GetSubstitutions` には反映されないため、代わりに出力ファイル内のフォントを確認してください。アジア文字の場合は、[DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/) も設定します。詳しくは [Default Font](/slides/ja/net/default-font/) を参照してください。

## **Alpine Linux へのフォントインストール**

Alpine Linux では Aspose.Slides.NET パッケージを使用します。[Run on Alpine Linux](/slides/ja/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) にプロジェクトの変更点が記載されています。*FontCheck* でも同様の変更を行います：パッケージ参照を置き換え、*Program.cs* に `SetSwitch` 文を追加し、Microsoft Core フォントもインストールするこのランタイム ステージを使用します:

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

`update-ms-fonts` は Debian や Ubuntu 用パッケージと同様の Microsoft Core フォントをダウンロードしてインストールし、同じ方法で EULA が適用されます。`fc-cache` はフォントキャッシュを更新します。

Linux 上で Aspose.Slides.NET を使用すると、フォント設定ライブラリ（fontconfig）が欠如フォントの代替フォントを選択し、`GetSubstitutions` はそれを報告しないため、*FontCheck* は `No font substitutions.` と出力します。コンテナ内で fontconfig に問い合わせると、フォント名に対して使用されるフォントが確認できます:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Microsoft Core フォントがインストールされている場合、Arial は Arial として使用されます:

```text
Arial.ttf: "Arial" "Regular"
```

それらがない場合、`RUN` 命令で `icu-libs libgdiplus font-dejavu` のみをインストールすると、同じコマンドは次のように出力します:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **よくある質問**

**サーバーで変換するとプレゼンテーションの見た目が変わるのはなぜですか？**

サーバーにはプレゼンテーションで使用されているフォントがないため、Aspose.Slides は文字幅が異なる代替フォントでテキストを描画します。*FontCheck* をプレゼンテーションのフォント名で実行し、どのフォントが置き換えられているか確認してから、フォントをインストールするかアプリケーション フォルダーからロードしてください。

**ビルドで ttf-mscorefonts-installer はインストールされたが、Arial がまだ置き換えられるのはなぜですか？**

EULA がパッケージインストール前に受諾されていなかったため、インストーラはフォントのインストールをスキップしました。[Microsoft Core Fonts](#microsoft-core-fonts) に示すように、`apt-get install` の前に `debconf-set-selections` コマンドを追加し、イメージを再ビルドしてください。

**PDF を開くコンピューターにフォントは必要ですか？**

いいえ。これらの例では、PDF にテキスト描画に使用されたフォントが埋め込まれているため、どのコンピューターでも同じ表示になります。フォントは Aspose.Slides がプレゼンテーションをレンダリングする環境でのみ必要です。