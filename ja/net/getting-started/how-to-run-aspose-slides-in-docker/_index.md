---
title: Docker で Aspose.Slides for .NET を実行する
linktitle: Docker
type: docs
weight: 140
url: /ja/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker コンテナ
- マルチステージ ビルド
- コンテナ イメージ
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- フォント
- PDF 変換
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Docker で Aspose.Slides for .NET のコンソール アプリケーションをビルドして実行します: 公式 .NET イメージ上のマルチステージ Dockerfile、必要な Linux ライブラリとフォント、そして生成されたファイルをマシンにコピーする方法です。"
---
## **概要**

この記事では、Docker コンテナ内で Aspose.Slides for .NET を実行する方法を示します。テキスト ボックスを持つプレゼンテーションを作成し PDF に変換する小さなコンソール アプリケーションをビルドし、Microsoft の公式 .NET イメージ上のマルチステージ Dockerfile でパッケージ化し、実行して生成されたファイルをローカルマシンにコピーします。記事では、コンテナ内で Aspose.Slides が必要とする Linux ライブラリとフォントも一覧にし、最後に Alpine Linux 用のバリアントを紹介します。

Docker がマシンにインストールされていればそれだけで十分です。.NET SDK はビルドイメージに含まれるため別途インストールする必要はありません。Docker のインストール方法は [Dockerを取得](https://docs.docker.com/get-started/get-docker/) を参照してください。

## **パッケージとベースイメージの選択**

デフォルトの .NET 10 コンテナイメージは Ubuntu 24.04 をベースにしています。これらのイメージでは [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) パッケージを使用します。このパッケージは `fontconfig` ライブラリを必要としますが、.NET ランタイムイメージにはそのライブラリもフォントも含まれていないため、この記事の Dockerfile で両方をインストールします。

Aspose.Slides.NET6.CrossPlatform は Alpine Linux では動作しません。Alpine ベースのイメージの場合は、`libgdiplus` を使用する [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) パッケージを使用してください（[Alpine Linuxでの実行](#run-on-alpine-linux) を参照）。[インストール](/slides/ja/net/installation/) では 2 つのパッケージを比較しています。

## **プロジェクトの作成**

*HelloSlidesDocker* というフォルダーを作成し、以下の 3 ファイルを追加します。

*HelloSlidesDocker.csproj* は .NET 10 のコンソール アプリケーションを示し、下記のコンテナイメージのバージョンを使用し、Aspose.Slides.NET6.CrossPlatform を参照します。パッケージ バージョンは [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) に一覧されている最新のものに設定してください。

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

*Program.cs* は [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、最初のスライドにテキスト付きの長方形を追加し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドで PPTX と PDF の 2 つの形式で保存します。両ファイルは作業ディレクトリ配下の *output* フォルダーに出力されます。アプリケーションは PDF の描画中に置換されたフォントを [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) で一覧表示し、コンテナにプレゼンテーションで使用されるフォントがあるかどうかを確認できます。

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

*.dockerignore* はローカルビルドで生成される *bin* と *obj* フォルダー、そして過去の実行結果を Docker のビルドコンテキストから除外し、イメージはソース ファイルだけから構築されるようにします。

```text
bin/
obj/
output/
```

## **Dockerfileの作成**

同じフォルダーに *Dockerfile* という名前のファイルを追加します。

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

このファイルは 2 つのステージから構成されています。

- **The build stage** は .NET SDK イメージから開始します。まずプロジェクト ファイルをコピーし NuGet パッケージを復元することで、プロジェクト ファイルが変更されない限り Docker がそのレイヤーを再利用できるようにします。その後ソースコードをコピーし、アプリケーションを */app* に公開します。
- **The runtime stage** は SDK が含まれていない小さな .NET ランタイム イメージから開始し、公開されたアプリケーションだけをコピーします。次の 2 つのパッケージをインストールします。
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform が起動時にこのライブラリをロードします。無い場合は `DllNotFoundException` がスローされ、`libfontconfig.so.1` が見つからない旨が表示されます。
  - `fonts-dejavu-core`: ランタイム イメージにはフォントが含まれていないため、少なくとも 1 つのフォントがインストールされていないとテキスト描画ができず、`InvalidOperationException: Cannot find any fonts installed on the system.` が発生します。DejaVu フォントはテキスト描画に最低限必要な小セットで、元のフォントで正確にレンダリングしたい場合は [フォントのデプロイ](/slides/ja/net/deploy-fonts/) を参照してください。

`--no-install-recommends` とパッケージリストの削除によりイメージは小さく保たれます。最後の行では *output* フォルダーを作成し、公式 .NET イメージが定義する非 root ユーザー `app`（ユーザー ID は `APP_UID` 変数に格納）に所有権を付与し、そのユーザーでアプリケーションを実行します。

ASP.NET Core アプリケーションの場合は、ランタイムステージを `mcr.microsoft.com/dotnet/aspnet:10.0` から開始してください。こちらも同じ Ubuntu イメージをベースにしているため、同様のパッケージが必要です。

## **コンテナのビルドと実行**

*HelloSlidesDocker* フォルダーでターミナルを開きます。イメージをビルドし、続いてコンテナを実行します。

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

最初のビルドではベースイメージと NuGet パッケージをダウンロードするため、以降のビルドより時間がかかります。コンテナはアプリケーションを実行して停止し、次のように出力します。

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

最初の行はテキストが新規プレゼンテーションのデフォルト フォントである Calibri を使用していること、そしてイメージに Calibri がインストールされていないため Aspose.Slides が DejaVu Sans で描画したことを示しています。PDF のテキストは実際の選択可能な文字列で、そのフォントは DejaVu Sans です。ライセンスが無い場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを付加します（[ライセンス](/slides/ja/net/licensing/) を参照）。

## **出力をローカルマシンにコピー**

停止したコンテナの */app/output* フォルダーにファイルが格納されています。これらをローカルマシンの *output* フォルダーにコピーし、コンテナを削除します。

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

これらのコマンドは Bash、PowerShell、Windows コマンド プロンプトのいずれでも同じように動作します。

Linux の場合は、マシン上のフォルダーをコンテナにマウントして、アプリケーションが直接その場所にファイルを書き込むようにすることもできます。

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` オプションにより、ユーザー ID とグループ ID が現在のユーザーに設定されるため、作成したフォルダーに書き込め、ファイルの所有者も自分になります。`--rm` はコンテナ停止時に自動で削除します。

## **Alpine Linuxでの実行**

Alpine ベースのイメージでアプリケーションを実行するには、Aspose.Slides.NET パッケージに切り替え、ランタイムステージを変更します。ビルドステージはそのままです。

1. *HelloSlidesDocker.csproj* でパッケージ参照を次のように置き換えます。

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. *Program.cs* の `using` ディレクティブの後、最初の Aspose.Slides 呼び出しの前に次のステートメントを追加します。これにより、Aspose.Slides.NET が Linux で使用する System.Drawing サポートが有効になります。

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. *Dockerfile* のランタイムステージ（2 番目の `FROM` 行以降）を次の内容に置き換えます。

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

Alpine ステージでは 3 つのパッケージをインストールし、1 つの設定を変更します。

- `libgdiplus` は Aspose.Slides.NET が Linux で使用するグラフィック ライブラリです。
- `font-dejavu` はフォントを提供します。フォントが無いと `System.ArgumentException: Font '?' cannot be found` で変換が失敗します。
- `icu-libs` と `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` はカルチャ データを提供します。Alpine の .NET イメージはデフォルトでグローバリゼーション非依存モードで動作し、そのモードでは Aspose.Slides が `en-US` の `CultureNotFoundException` をスローします。

ビルド、実行、出力のコピーは上記と同じコマンドで行えてください。このイメージではアプリケーションは `Saved` 行だけを出力します。Linux 版 Aspose.Slides.NET では fontconfig が欠損フォントの置換を自動で選択し、[GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) には表示されません。[フォントのデプロイ](/slides/ja/net/deploy-fonts/) で実際に使用されたフォントを確認する方法が解説されています。

## **FAQ**

**The application stops with "Unable to load shared library 'libaspose.slides.drawing.capi…'". What is missing?**  
Ubuntu や Debian イメージでは `libfontconfig1` パッケージが不足しています。エラーメッセージに `libfontconfig.so.1` が開けないと表示されます。Alpine Linux では Aspose.Slides.NET6.CrossPlatform が使用されていることを意味し、[Alpine Linuxでの実行](#run-on-alpine-linux) に記載のとおり Aspose.Slides.NET に切り替えてください。

**Why is the text in the PDF in a different font than in PowerPoint?**  
プレゼンテーションで使用されているフォントがイメージにインストールされていないため、Aspose.Slides は代替フォントで描画します。アプリケーションの出力には置換されたフォント名が列挙されます。[フォントのデプロイ](/slides/ja/net/deploy-fonts/) でイメージにフォントをインストールする方法や、アプリケーション フォルダーからロードする方法が説明されています。

**Do I need the .NET SDK on my machine?**  
いいえ。ビルドステージは SDK イメージ内でアプリケーションをコンパイルします。SDK が必要になるのは、Docker 以外でアプリケーションをビルド・実行したい場合だけです（[インストール](/slides/ja/net/installation/) を参照）。