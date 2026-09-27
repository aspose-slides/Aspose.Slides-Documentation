---
title: インストール
type: docs
weight: 70
url: /ja/nodejs-net/installation/
keywords:
- Aspose.Slides をダウンロード
- Aspose.Slides をインストール
- Aspose.Slides のインストール
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Windows または Linux 上で npm から .NET 経由の Aspose.Slides for Node.js をインストールする方法：前提条件、edge-js のオーバーライド、一度だけ実行する NuGet 復元、そしてプレゼンテーションを作成する最初のプログラム。"
---
## **概要**

Aspose.Slides for Node.js via .NET は npm パッケージ `aspose.slides.via.net` です。これは [edge-js](https://github.com/agracio/edge-js) ブリッジを介して Node.js 内で Aspose.Slides .NET ライブラリを実行するため、動作するインストールには Node.js と .NET の両方が必要です。

この記事では、クリーンなマシンからプレゼンテーションを作成する最初のプログラムまでの手順を示します。手順は 4 つです: edge-js のオーバーライドでプロジェクトを作成、npm からパッケージをインストール、.NET 依存関係を一度復元、プロジェクト フォルダーからスクリプトを実行。

## **前提条件**

- **Node.js 22 または 24 LTS**、x64 ビルド、[nodejs.org](https://nodejs.org/en/download) から取得。
- **.NET SDK 8 以上**、[dotnet.microsoft.com](https://dotnet.microsoft.com/download) から取得。ランタイムだけでは不十分です。以下の復元手順やブリッジ実行時に SDK が必要です。`dotnet --list-sdks` でインストール済み SDK を確認してください。
- **Linux のみ**:
  - ビルド ツール `python3`、`make`、`g++`。npm が Linux でインストール時に edge-js をコンパイルするためです。
  - フォント設定ライブラリ `fontconfig`。Aspose.Slides のネイティブ描画ライブラリがロードします。

  Debian ではこれらはパッケージ `python3`、`make`、`g++`、`libfontconfig1` です。

この記事の手順は以下のプラットフォームでテスト済みです:

| プラットフォーム | 結果 |
|---|---|
| Windows x64 (Node.js 22 または 24) | 動作します。Microsoft Visual C++ 再頒布可能パッケージがインストールされている環境でテスト済み。 |
| Linux x64 (Node.js 22 または 24、システム OpenSSL が Node.js に組み込まれた OpenSSL と同じリリース系統、例: Debian 13) | 動作します。 |
| Linux (OpenSSL のバージョンが異なる環境、例: Debian 12) | プレゼンテーション作成時に Node.js がセグメンテーションフォルトでクラッシュします。 |
| macOS | 未確認。 |

Linux では開始前に 2 つのバージョンを比較してください。最初のコマンドは Node.js に組み込まれた OpenSSL のバージョンを表示し、2 番目はシステム版を表示します。メジャーとマイナーが同じ (`3.5` など) ものを使用してください:

```sh
node -p process.versions.openssl
openssl version
```

`openssl` コマンドが見つからない場合は、まず `openssl` パッケージをインストールしてください。

## **プロジェクトの作成**

プロジェクト用フォルダーを作成し、初期化して、npm がインストールする edge-js のリリースを指定するオーバーライドを追加します:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

パッケージは Windows の Node.js 20 までしか事前ビルドされていない古い edge-js リリースを要求するため、オーバーライドが無いと Windows で最初のスクリプトが「The edge module has not been pre-compiled for node.js version」で停止します。コマンドは `package.json` の `overrides` セクションにオーバーライドを書き込みます。パッケージをインストールする前に追加してください。

## **パッケージのインストール**

npm から Aspose.Slides for Node.js via .NET をインストールします:

```sh
npm install aspose.slides.via.net
```

インストール中に、パッケージはネイティブ描画ライブラリ（名前に `aspose.slides.drawing.capi` を含むファイル）を `package.json` と同じフォルダーにコピーします。

パッケージは [releases.aspose.com](https://releases.aspose.com/slides/ja/nodejs-net/) でも ZIP アーカイブとして公開されていますが、この記事では npm からのインストールのみを扱います。

## **.NET 依存関係の復元**

パッケージには Aspose.Slides .NET アセンブリが含まれていますが、これらが依存する 20 個の NuGet パッケージは含まれていません。実行時に .NET はそれらを NuGet キャッシュから探します: Windows の場合 `%USERPROFILE%\.nuget\packages`、Linux の場合 `~/.nuget/packages`、または `NUGET_PACKAGES` 環境変数で指定されたフォルダーです。キャッシュに無い場合、最初のスクリプトは「assembly specified in the dependencies manifest was not found」で停止します。

キャッシュを埋めるために、プロジェクト フォルダーに `deps` フォルダーを作成し、以下のファイルを `deps.csproj` として保存します。各 `PackageDownload` 項目は括弧内の正確なバージョンのパッケージをダウンロードします。ビルドは行われません。

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

次にプロジェクト フォルダーから復元します:

```sh
dotnet restore deps/deps.csproj
```

この手順はマシンごとに一度だけ実行すればよく、プロジェクトごとに行う必要はありません。パッケージは NuGet キャッシュに残り、同一マシン上の他のプロジェクトでも使用できます。復元後は `deps` フォルダーを削除して構いません。

## **最初のプログラムの実行**

プロジェクト フォルダーに `hello.js` という名前のファイルを作成し、以下のコードを貼り付けます。これはプレゼンテーションを作成し、最初のスライドに「Hello, World!」というテキストを含む矩形を追加し、`hello.pptx` として保存します:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新しいプレゼンテーションには空のスライドが1枚含まれています。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置とサイズはポイント（1/72インチ）で指定します: x, y, 幅, 高さ。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // プレゼンテーションを支える .NET オブジェクトを解放します。
    presentation.dispose();
}
```

プロジェクト フォルダーから実行します:

```sh
node hello.js
```

スクリプトは `Saved hello.pptx` と出力します。`hello.pptx` を開くと、テキストを含む塗りつぶし矩形が表示されたスライドが 1 枚あります。ライセンスがない場合、Aspose.Slides は評価用の透かしを追加します。詳細は [Evaluate Aspose.Slides](/slides/ja/nodejs-net/evaluate-aspose-slides/) と [Licensing](/slides/ja/nodejs-net/licensing/) を参照してください。

{{% alert color="info" title="Note" %}}
スクリプトは `package.json` があるプロジェクト フォルダーから実行してください。`hello.pptx` のような相対パスはカレント フォルダーを基準に解決され、別のフォルダーから開始したスクリプトはプレゼンテーションを作成できないことがあります。
{{% /alert %}}

JavaScript API は Aspose.Slides for .NET を鏡像化しています。クラス名は .NET 名のままで、プロパティとメソッドは camelCase になります（例: `Slides` は `slides`、`AddAutoShape` は `addAutoShape`）。コレクション アイテムは `get(index)` で取得します。このパッケージ用の別個の API リファレンスはありませんので、クラスやメンバーの詳細は [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ja/net/)（例: [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) と [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/shapecollection/addautoshape/)）をご利用ください。

## **FAQ**

**「The edge module has not been pre-compiled for node.js version」とは何ですか？**

npm がパッケージが要求する古い edge-js リリースをインストールしました。[Create a Project](#create-a-project) のオーバーライドを追加し、`npm install` を再度実行してください。

**「assembly specified in the dependencies manifest was not found」とは何ですか？**

.NET 依存関係が NuGet キャッシュにありません。同時に「edge.initializeClrFunc is not a function」も表示されます。[Restore the .NET Dependencies](#restore-the-net-dependencies) を一度実行し、スクリプトを再度実行してください。

**Linux で「The edge native module is not available」と表示されるのは何故ですか？**

`npm install` 時に edge-js がコンパイルされていません。例: `python3`、`make`、`g++` が欠如している場合です。npm はエラーとして報告しません。ビルド ツールをインストールし、プロジェクト フォルダーで `npm rebuild edge-js` を実行してください。

**プレゼンテーション作成時に空の「Error」で失敗するのは何故ですか？**

Linux では `fontconfig` ライブラリ（Debian の場合 `libfontconfig1`）がインストールされているか確認してください。これが無いとネイティブ描画ライブラリがロードできません。いずれのシステムでも、スクリプトをプロジェクト フォルダーから実行しているか確認してください。

**Linux で Node.js がセグメンテーション フォルトでクラッシュするのは何故ですか？**

システム OpenSSL と Node.js に組み込まれた OpenSSL が異なるリリース系統です。[Prerequisites](#prerequisites) に示した方法でバージョンを比較し、両者が一致するディストリビューションまたは Node.js ビルドを使用してください。

**各プロジェクトで NuGet の復元を繰り返す必要がありますか？**

いいえ。復元はユーザー アカウントの NuGet キャッシュを埋めるだけで、同一マシン上のすべてのプロジェクトが同じキャッシュを利用します。