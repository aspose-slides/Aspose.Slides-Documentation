---
title: システム要件
type: docs
weight: 60
url: /ja/net/system-requirements/
keywords:
- システム要件
- オペレーティングシステム
- インストール
- 依存関係
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のシステム要件をご確認ください。Windows、Linux、macOS での PowerPoint と OpenDocument のシームレスなサポートを実現します。"
---
## **はじめに**

Aspose.Slides for .NET は Microsoft PowerPoint のインストールを必要としません。Aspose.Slides は、Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングを行う独立したエンジンです。

## **サポートされているオペレーティングシステム**

Aspose.Slides for .NET は .NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステムであればすべてサポートします（ただしこれに限定されません）。

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu、OpenSUSE、CentOS、Alpine、その他)

### **Mac**

- Mac OS X

## **サポートされているフレームワーク**

Aspose.Slides for .NET は .NET と Mono フレームワークをサポートします。

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop のサポート (COM、C++、VBScript)

### **Mono フレームワーク**

- MONO のサポート（Mac および Linux プラットフォーム）

## **開発環境**

Aspose.Slides for .NET は .NET プラットフォームを対象とした任意の開発環境で使用できますが、以下の環境は明示的にサポートされています。

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides の主要ビルド**

現在、Aspose.Slides には主に 2 つのビルドがあります — Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

これは製品のメインバージョンです。標準の .NET グラフィックエンジンを使用します。
- 非 Windows プラットフォームでは、`libgdiplus` ライブラリとその依存関係をインストールする必要がある場合があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォームで Aspose.Slides ZIP パッケージから .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、NuGet パッケージを非 Windows システムでも直接使用できます。
- 非 Windows システムで実行する場合、起動時に次の行をアプリケーションに含める必要があります:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **バージョン 25.3 から、Linux aarch64 (ARM64) など .NET をサポートするプラットフォームでもこのパッケージが使用可能です。**

#### **Linux Alpine 用の追加パッケージ**

Alpine Linux コンテナ内で Aspose.Slides for .NET を実行する場合、`libgdiplus` だけでは不十分なことがあります。Alpine コンテナはデフォルトでフォントを含まないことが多く、フォントが無いとレンダリングや変換が以下のようなエラーで失敗する可能性があります:
```text
System.ArgumentException: Font '?' cannot be found
```
Alpine で Aspose.Slides を使用するには、`libgdiplus` に加えて少なくとも 1 つのフォントパッケージをインストールしてください。

**Option 1: DejaVu フォント**

推奨オプションは `ttf-dejavu` パッケージをインストールすることです:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` パッケージは `fontconfig`、`encodings`、`mkfontscale`、`mkfontdir` などの必要なフォント関連依存関係を自動的にインストールします。ほとんどの使用ケースで追加のフォントパッケージは不要です。

**Option 2: Microsoft Core Fonts**

プレゼンテーションで Arial、Times New Roman、Courier New、Verdana などの Microsoft 固有フォントを使用している場合は、代わりに Microsoft Core Fonts をインストールしてください:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

このオプションは、処理対象のプレゼンテーションが Microsoft フォントを必要とする場合のみ使用してください。ほとんどのシナリオでは `ttf-dejavu` のインストールが簡単で信頼性が高いです。

**グローバリゼーションの追加要件**

Alpine で適切なグローバリゼーションサポートを有効にするには、`icu-libs` パッケージをインストールし、インバリアントモードを無効にしてください:
```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

これは Aspose.Slides チームが開発したカスタムクロスプラットフォームグラフィックエンジンを使用したバージョンです。非 Windows プラットフォームでは `fontconfig` ライブラリが必要になることがあります。

**サポートされているプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**サポートされていないプラットフォーム**
- *Windows 11 ARM* (ARM64) — *現在は検討されていません*

{{%  alert  title="Notes"  color="info"  %}}  
Linux x64 では GLIBC 2.23 以上が必要です。Linux ARM64 では GLIBC 2.39 以上が必要です。CentOS 7 (GLIBC 2.14) などのシステムはサポートされていません。CentOS 7 やその他の非対応システム（例: Alpine）で Aspose.Slides を実行する必要がある場合は、標準パッケージ [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET) を使用してください。  
{{% /alert %}} 

## **よくある質問**

### 変換やレンダリングに Microsoft PowerPoint のインストールは必要ですか？

いいえ、PowerPoint は不要です。Aspose.Slides は、プレゼンテーションの[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および[レンダリング](/slides/ja/net/convert-powerpoint-to-png/) を行うスタンドアロンエンジンです。

### 正しいレンダリングに必要なフォントは何ですか？

プレゼンテーションで使用されているフォント、または適切な代替フォントが OS にインストールされている必要があります。Linux および macOS では、一般的なフォントパッケージをインストールして一貫したレンダリングを確保してください。

Alpine Linux コンテナの場合、`libgdiplus` に加えて少なくとも 1 つのフォントパッケージをインストールする必要があります。最小構成としては `libgdiplus` と `ttf-dejavu` の組み合わせが推奨されます。Arial、Times New Roman、Courier New、Verdana などの Microsoft フォントが必要な場合は、`msttcorefonts-installer` と `fontconfig` を併用してください。

### カスタムフォントが Linux でフォールバックまたは欠落テキストとして表示されるのはなぜですか？

フォントファイルの name テーブルに不整合や破損があると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなることがあります。name テーブルが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすることで解決できます。