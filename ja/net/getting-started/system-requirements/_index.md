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
description: "Aspose.Slides for .NET のシステム要件をご確認ください。Windows、Linux、macOS での PowerPoint および OpenDocument のシームレスなサポートを実現します。"
---
## **はじめに**

Aspose.Slides for .NET は Microsoft PowerPoint をインストールする必要はありません。Aspose.Slides は独立した Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングエンジンです。

## **サポートされているオペレーティングシステム**

Aspose.Slides for .NET は .NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステムであれば、以下（ただしこれに限定されません）をサポートします。

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

Aspose.Slides for .NET は .NET プラットフォームをターゲットにした任意の開発環境で使用できますが、以下の環境は明示的にサポートされています。

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
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム向けに Aspose.Slides ZIP パッケージから .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、NuGet パッケージを非 Windows システムでも直接使用できます。
- 非 Windows システム上で実行する場合、アプリケーションの起動時に次の行を含める必要があります:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **25.3 以降、Linux aarch64 (ARM64) など .NET をサポートするプラットフォームでもこのパッケージを使用できます。**

#### **Linux Alpine 用の追加パッケージ**

Alpine Linux コンテナ内で Aspose.Slides for .NET を実行する場合、`libgdiplus` のみのインストールでは不十分なことがあります。Alpine コンテナはデフォルトでフォントを含まないことが多く、フォントが無い場合はレンダリングや変換処理が次のようなエラーで失敗することがあります:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine で Aspose.Slides を使用するには、`libgdiplus` と少なくとも 1 つのフォントパッケージを一緒にインストールしてください。

**オプション 1: DejaVu フォント**

推奨オプションは `ttf-dejavu` パッケージをインストールすることです:

{{26d2772b-6b9d-4cef-b9bf-9333ed266a}}

`ttf-dejavu` パッケージは `fontconfig`、`encodings`、`mkfontscale`、`mkfontdir` などの必要なフォント関連依存関係も自動的にインストールします。ほとんどのユースケースで追加のフォントパッケージは不要です。

**オプション 2: Microsoft Core フォント**

プレゼンテーションで Arial、Times New Roman、Courier New、Verdana などの Microsoft 固有フォントを使用している場合は、代わりに Microsoft Core フォントをインストールしてください:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

このオプションは、処理対象のプレゼンテーションが Microsoft フォントを必要とする場合にのみ使用してください。ほとんどのシナリオでは `ttf-dejavu` のインストールがシンプルで信頼性があります。

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

これは Aspose.Slides チームが開発したカスタムクロスプラットフォームグラフィックエンジンを使用したバージョンです。非 Windows プラットフォームでは `fontconfig` ライブラリが必要になることがあります。

**サポートされているプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**サポートされていないプラットフォーム**
- *Windows 11 ARM* (ARM64) — *現在は検討対象外*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 では GLIBC 2.23 以上、Linux ARM64 では GLIBC 2.39 以上が必要です。CentOS 7 (GLIBC 2.14) などはサポートされていません。CentOS 7 やその他の非互換システム（例: Alpine）で Aspose.Slides を実行する必要がある場合は、標準パッケージ [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET) を使用してください。  
{{% /alert %}} 

## **よくある質問**

**Microsoft PowerPoint をインストールしておく必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は [作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および [レンダリング](/slides/ja/net/convert-powerpoint-to-png/) 用のスタンドアロンエンジンです。

**正しくレンダリングするために必要なフォントは何ですか？**

プレゼンテーションで使用されているフォント、または適切な代替フォントが OS にインストールされている必要があります。Linux や macOS では、一般的なフォントパッケージをインストールして一貫したレンダリングを確保してください。

Alpine Linux コンテナの場合、`libgdiplus` に加えて少なくとも 1 つのフォントパッケージをインストールする必要があります。推奨の最小構成は `libgdiplus` と `ttf-dejavu` の組み合わせです。Arial、Times New Roman、Courier New、Verdana などの Microsoft フォントが必要な場合は、`msttcorefonts-installer` と `fontconfig` を併用してください。

**Linux でカスタムフォントがフォールバックまたは欠損テキストとして表示されるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。name テーブルが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすることで問題は解消します。