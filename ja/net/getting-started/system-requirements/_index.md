---
title: システム要件
type: docs
weight: 60
url: /ja/net/system-requirements/
keywords:
- システム要件
- 対応プラットフォーム
- 対象フレームワーク
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET をインストールする前に必要なものを確認します: 各 NuGet パッケージが対象とするフレームワーク、対応するオペレーティングシステムとプロセッサ、そして Linux が必要とするライブラリとフォントです。"
---
## **はじめに**

Aspose.Slides for .NET はスタンドアロンのライブラリであり、Microsoft PowerPoint や Microsoft Office は必要ありません。2 つの NuGet パッケージとして公開されています。[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) と [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) です。両方とも同じ Aspose.Slides 名前空間とクラスを提供しますが、対象とするフレームワークとスライドの描画方法が異なるため、実行環境と必要条件が変わります。

この記事では、各パッケージがサポートする .NET バージョンとプラットフォーム、Linux に必要なシステム ライブラリとフォントを一覧にし、セットアップを確認する簡単なプログラムを示します。プロジェクトにパッケージを追加する方法は、[インストール](/slides/ja/net/installation/) を参照してください。

## **サポートされている .NET バージョン**

各パッケージは対象フレームワークごとに 1 つのビルドを含み、NuGet はプロジェクトの対象フレームワークに一致するビルドを選択します。

| Package | パッケージ内のターゲットフレームワーク | プロジェクトで対象にできる |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 以降、.NET 6 以降（.NET 8、.NET 9、.NET 10 を含む） |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 以降（.NET 8、.NET 9、.NET 10 を含む） |

`netstandard2.0` ビルドにより、.NET Standard 2.0 のクラス ライブラリから Aspose.Slides.NET を参照できます。そのようなライブラリを使用するアプリケーションは、アプリケーション自身の対象フレームワークに一致するビルドで実行されます。たとえば .NET 8 アプリケーションは `net6.0` ビルドで動作します。

## **サポートされているオペレーティングシステムとプロセッサ**

**Aspose.Slides.NET** はプロセッサに依存しない (AnyCPU) マネージド コードだけで構成されているため、ロードする .NET ランタイムのプロセッサ アーキテクチャ上で動作します。スライドの描画は Microsoft の System.Drawing.Common ライブラリを使用しますが、Microsoft はこのライブラリを [Windows のみでサポート]((https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) しています。Linux では Aspose.Slides.NET は `libgdiplus` ライブラリと起動スイッチが必要です（[Linux](#linux) を参照）。`libgdiplus` を提供する Debian、Ubuntu、Alpine Linux などのディストリビューションで動作します。

**Aspose.Slides.NET6.CrossPlatform** は独自のグラフィック エンジンでスライドを描画します。このエンジンはプラットフォームごとに 1 ビルドずつパッケージに含まれるネイティブ ライブラリであるため、以下のプラットフォームでのみ動作します。

| Operating system | Processors | Notes |
|---|---|---|
| Windows | x86, x64 | ARM64 上の Windows はサポートされていません。 |
| Linux | x64, ARM64 | x64 では glibc 2.23 以降、ARM64 では glibc 2.39 以降が必要です。 |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform は musl ベースの Alpine Linux や、古い glibc を使用する CentOS 7 などのディストリビューションでは動作しません。そのような環境では Aspose.Slides.NET を使用してください。

Windows 上では、Aspose.Slides.NET6.CrossPlatform のネイティブ ライブラリが Microsoft Visual C++ ランタイム（*MSVCP140.dll* と *VCRUNTIME140.dll*、x64 の場合は *VCRUNTIME140_1.dll*）を使用します。これらのファイルがターゲット マシンに無い場合は、[Microsoft Visual C++ 再頒布可能パッケージ](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) をインストールしてください。

## **Linux**

両パッケージとも Linux では追加のシステム ライブラリが必要です。これらが無いと、[プレゼンテーションの作成](/slides/ja/net/create-presentation/) の最初のサンプルが例外で失敗し、ファイルが保存されません。以下のコマンドは Debian と Ubuntu 用です。これらのディストリビューションでは各ライブラリが `fonts-dejavu-core` も同時にインストールするため、フォントが別途必要になることはありません。

### **Aspose.Slides.NET6.CrossPlatform**

このパッケージの Linux 用ライブラリは `fontconfig` が必要です：

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

`fontconfig` が無いと、[プレゼンテーション]((https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/)) の作成時に `TypeInitializationException` がスローされ、その内部 `DllNotFoundException` が `libfontconfig.so.1` を開けない旨を報告します。

最小ベース イメージには `fontconfig` が含まれないことがあります。たとえば .NET 8 用の AWS Lambda ベースイメージは `fontconfig` もフォントも含んでいません。そのようなコンテナイメージで構築する場合は、`dnf install -y fontconfig` を実行すると同時に Noto Sans フォントもインストールされます。

### **Aspose.Slides.NET**

Linux では次の 2 つが必要です。

1. `libgdiplus` ライブラリ：

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport` スイッチ。Aspose.Slides の呼び出しの前に、アプリケーションの開始時に有効にします。トップレベルステートメントを使用した *Program.cs* では、`using` ディレクティブの後に次のように記述します：

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

`libgdiplus` が無いとプレゼンテーションの保存時に `TypeInitializationException` がスローされ、その内部 `DllNotFoundException` が `libgdiplus` をロードできないことを報告します。スイッチが無い場合は内部例外が `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms` になります。

{{% alert color="warning" title="Warning" %}}
このスイッチは Aspose.Slides.NET が依存している System.Drawing.Common 6 のみで機能します。Microsoft は System.Drawing.Common 7 でこの機能を削除しました。プロジェクトが System.Drawing.Common 7 以降を直接または他のパッケージ経由で参照している場合、`libgdiplus` がインストールされスイッチが有効でも Linux 上で Aspose.Slides.NET は `PlatformNotSupportedException` で失敗します。その場合は Aspose.Slides.NET6.CrossPlatform を使用してください。
{{% /alert %}}

### **Alpine Linux**

Alpine Linux では、上記のスイッチを使用した Aspose.Slides.NET を利用してください。Alpine イメージは通常フォントを含まず、`libgdiplus` だけではフォントがインストールされません。したがって、`libgdiplus` と少なくとも 1 つのフォント パッケージを同時にインストールする必要があります。フォントが無いとプレゼンテーションの保存時に次のエラーが発生します：

```text
System.ArgumentException: Font '?' cannot be found.
```

**オプション 1: DejaVu フォント**

推奨は `ttf-dejavu` パッケージです：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

現在の Alpine リリースでは、`ttf-dejavu` が `font-dejavu` パッケージをインストールし、これに `fontconfig` とフォント ツールが含まれます。

**オプション 2: Microsoft コア フォント**

プレゼンテーションで Arial、Times New Roman、Courier New、Verdana などの Microsoft フォントを使用する場合は、代わりに Microsoft コア フォントをインストールします。`update-ms-fonts` 手順はイメージのビルド時にフォントをダウンロードするため、ビルド時にインターネット接続が必要です：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **グローバリゼーション サポート**

両パッケージとも .NET のグローバリゼーション サポートが必要です。Linux 上の .NET は ICU ライブラリを通じてこれを提供します。[globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) で実行すると、[プレゼンテーション]((https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/)) の作成時に `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` がスローされます。

一部のコンテナ イメージはこのモードを有効にしています。たとえば Alpine Linux 用の .NET ランタイム イメージ（`runtime-deps`、`runtime`、`aspnet`）は `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` を設定し、ICU が含まれていません。これらのイメージ上でビルドする場合は ICU をインストールし、モードをオフにしてください：

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

また、プロジェクト ファイルで `InvariantGlobalization` プロパティが `true` に設定されていないことを確認してください。

## **セットアップの確認**

パッケージとその要件が正しく配置されているか確認するには、プレゼンテーションを保存しスライドを画像にレンダリングするプログラムを実行します。保存とレンダリングはグラフィック ライブラリとフォントを使用するため、上記の Linux 要件が満たされていることが前提です。

コンソール アプリケーションを作成し、[インストール](/slides/ja/net/installation/) の手順に従ってパッケージを追加し、*Program.cs* の内容を以下のコードに置き換えて `dotnet run` を実行してください。Linux で Aspose.Slides.NET を使用する場合は、[Linux](#linux) で示した `System.Drawing.EnableUnixSupport` スイッチ文を `using` ディレクティブの後に追加します。このプログラムはトップレベルステートメントと `using` 宣言を使用しており、C# 9 以降が必要です。.NET 6 以降を対象とするプロジェクトはデフォルトで新しい C# バージョンが使用されます。 .NET Framework を対象とする場合は、プロジェクト ファイルの `PropertyGroup` に `<LangVersion>latest</LangVersion>` を追加してください。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

プログラムは最初のスライドにテキスト付きの矩形を追加し、[Save]((https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/)) メソッドで *hello.pptx* として保存します。その後 [GetImage]((https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/)) でスライドを画像化し、[IImage.Save]((https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/)) と [ImageFormat.Png]((https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/)) を使用して *hello.png* として保存します。スケールファクタ 1 はポイントあたり 1 ピクセルを意味し、デフォルトの 720 × 540 ポイントのスライドは 720 × 540 ピクセルの画像になります。テキストは矩形内に表示されます。ライセンスが無い場合、両ファイルには評価版の透かしが入ります。詳細は [ライセンス](/slides/ja/net/licensing/) を参照してください。要件が欠けていると、[Linux](#linux) で説明した例外のいずれかでプログラムが停止します。

## **開発ツール**

対象フレームワークをサポートする任意のツールで Aspose.Slides を使用したアプリケーションを構築できます。Windows、Linux、macOS 上の .NET SDK と `dotnet` CLI、または Windows の Visual Studio が利用可能です。[インストール](/slides/ja/net/installation/) では両方の方法を説明しています。

## **FAQ**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は不要です。Aspose.Slides はプレゼンテーションの[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および[レンダリング](/slides/ja/net/convert-powerpoint-to-png/) 用のスタンドアロン エンジンです。

**どのパッケージを使用すべきですか？**

Windows では Aspose.Slides.NET、Linux と macOS では Aspose.Slides.NET6.CrossPlatform を使用してください。Alpine Linux、glibc が古い Linux システム、または .NET Framework を対象とするプロジェクトでは Aspose.Slides.NET を使用します。プロジェクトには 2 つのパッケージのうちどちらか一方だけを追加してください。

**正しいレンダリングのために必要なフォントは何ですか？**

プレゼンテーションで使用するフォント、または適切な代替フォントが OS にインストールされている必要があります。Linux と macOS では、プレゼンテーションが必要とするフォント パッケージをインストールして一貫したレンダリングを実現してください。Alpine Linux では `libgdiplus` に加えて少なくとも 1 つのフォント パッケージをインストールする必要があります（[Alpine Linux](#alpine-linux) を参照）。

**Linux でカスタム フォントがフォールバックや欠落テキストとして表示されるのはなぜですか？**

フォント ファイルの名前テーブル エントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。名前テーブルが修正されたフォント バージョンを使用するか、一貫した代替フォントをインストールすれば問題は解消されます。