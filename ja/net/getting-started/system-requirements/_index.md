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
description: "Aspose.Slides for .NET のシステム要件を確認してください。Windows、Linux、macOS での PowerPoint および OpenDocument のシームレスなサポートを保証します。"
---
## **導入**

Aspose.Slides for .NET は、Microsoft PowerPoint をインストールする必要がありません。Aspose.Slides は、Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングのための独立したエンジンです。

## **サポートされているオペレーティングシステム**

Aspose.Slides for .NET は、.NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステムであれば、以下を含む（ただしこれに限定されない）すべてで使用できます。

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

### **Mac**

- Mac OS X

## **サポートされているフレームワーク**

Aspose.Slides for .NET は .NET と Mono フレームワークをサポートします。

### **.NET フレームワーク**

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
- COM Interop support (COM, C++, VBScript)

### **Mono フレームワーク**

- MONO Support in MAC and Linux platforms

## **開発環境**

Aspose.Slides for .NET は .NET プラットフォームを対象とする任意の開発環境で使用できますが、以下の環境は明示的にサポートされています。

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides の主なビルド**

現在、Aspose.Slides には 2 つの主なビルドがあります — Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

これは製品のメインバージョンです。標準の .NET グラフィックエンジンを使用します。
- 非 Windows プラットフォームでは、`libgdiplus` ライブラリとその依存関係をインストールする必要がある場合があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム用に Aspose.Slides ZIP パッケージの .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、NuGet パッケージを非 Windows システムでも直接使用できます。
- 非 Windows システムで実行する場合、アプリケーションの起動時に次の行を追加する必要があります:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **バージョン 25.3 以降、Linux aarch64（ARM64）など .NET をサポートするプラットフォームでもこのパッケージを使用できます。**

#### **Linux Alpine 用の追加パッケージ**

Alpine Linux コンテナで Aspose.Slides for .NET を実行する場合、`libgdiplus` だけでは不十分なことがあります。Alpine コンテナはデフォルトでフォントが含まれていないことが多く、フォントが利用できないとレンダリングや変換が次のようなエラーで失敗することがあります:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine で Aspose.Slides を使用するには、`libgdiplus` と少なくとも 1 つのフォントパッケージをインストールしてください。

**オプション 1: DejaVu フォント**

推奨オプションは `ttf-dejavu` パッケージをインストールすることです:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` パッケージは `fontconfig`、`encodings`、`mkfontscale`、`mkfontdir` などの必要なフォント関連依存関係を自動的にインストールします。ほとんどのユースケースで追加のフォントパッケージは不要です。

**オプション 2: Microsoft Core Fonts**

プレゼンテーションで Arial、Times New Roman、Courier New、Verdana などの Microsoft 固有フォントを使用している場合は、代わりに Microsoft Core Fonts をインストールしてください:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

このオプションは、処理対象のプレゼンテーションが Microsoft フォントを必要とする場合にのみ使用してください。ほとんどのシナリオでは `ttf-dejavu` のインストールがシンプルで信頼性が高いです。

**グローバリゼーションの追加要件**

Alpine で適切なグローバリゼーションサポートを有効にするには、`icu-libs` パッケージをインストールし、インバリアントモードを無効にしてください:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

これは Aspose.Slides チームが開発したカスタムクロスプラットフォームグラフィックエンジンを使用したバージョンです。  
非 Windows プラットフォームでは `fontconfig` ライブラリが必要になる場合があります。

**サポートプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**サポートされていないプラットフォーム**
- *Windows 11 ARM* (ARM64) — *現在検討中ではありません*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 では GLIBC 2.23 以上が必要です。Linux ARM64 では GLIBC 2.39 以上が必要です。CentOS 7 (GLIBC 2.14) などはサポートされません。CentOS 7 や他の非互換システム（例: Alpine）で Aspose.Slides を実行する必要がある場合は、標準パッケージ [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET) を使用してください。  
{{% /alert %}} 

## **FAQ**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は不要です。Aspose.Slides は、プレゼンテーションの[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および[レンダリング](/slides/ja/net/convert-powerpoint-to-png/) を行うスタンドアロンエンジンです。

**正しいレンダリングのために必要なフォントは何ですか？**

プレゼンテーションで使用されているフォント、または適切な代替フォントが OS にインストールされている必要があります。Linux と macOS では、一般的なフォントパッケージをインストールしてレンダリングの一貫性を確保してください。

Alpine Linux コンテナの場合、`libgdiplus` に加えて少なくとも 1 つのフォントパッケージをインストールする必要があります。推奨の最小構成は `libgdiplus` と `ttf-dejavu` です。Arial、Times New Roman、Courier New、Verdana などの Microsoft フォントが必要な場合は、`msttcorefonts-installer` と `fontconfig` を併用してください。

**Linux でカスタムフォントがフォールバックまたは欠落テキストとして表示されるのはなぜですか？**

フォントファイルの name-table エントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できません。修正された name-table を持つフォントバージョンを使用するか、一貫した代替フォントをインストールすると問題が解決します。