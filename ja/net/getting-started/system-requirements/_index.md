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
description: "Aspose.Slides for .NET のシステム要件を確認してください。Windows、Linux、macOS での PowerPoint と OpenDocument のシームレスなサポートを実現します。"
---
## **概要**
Aspose.Slides for .NET は Microsoft PowerPoint のインストールを必要としません。なぜなら、Aspose.Slides は独立した Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングエンジンだからです。

## **サポートされているオペレーティングシステム**
Aspose.Slides for .NET は .NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステムであれば、（以下に限らず）サポートします。

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
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**
- MAC と Linux プラットフォームでの MONO のサポート

## **開発環境**
Aspose.Slides for .NET は .NET プラットフォームを対象とする任意の開発環境でアプリケーションの開発に使用できますが、以下の環境は明示的にサポートされています。

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides メインビルド**
現在、Aspose.Slides には Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform の 2 つの主要ビルドがあります。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
これは製品のメインバージョンです。標準の .NET グラフィックスエンジンを使用します。
- 非 Windows プラットフォームでは、`libgdiplus` ライブラリとその依存関係をインストールする必要がある場合があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム向けに Aspose.Slides ZIP パッケージ内の .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、NuGet パッケージを直接非 Windows システムでも使用できます。
- 非 Windows システムで実行する場合、アプリケーションは起動時に次の行を含める必要があります:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **バージョン 25.3 以降、Linux aarch64 (ARM64) など .NET をサポートするプラットフォームでこのパッケージを使用できます。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
これは Aspose.Slides チームが開発したカスタムクロスプラットフォームグラフィックスエンジンを使用するバージョンです。  
非 Windows プラットフォームでは `fontconfig` ライブラリが必要になる場合があります。

**サポートプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**未サポートプラットフォーム**
- *Windows 11 ARM* (ARM64) — *現在検討中ではありません*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 では GLIBC 2.23+ が必要です。Linux ARM64 では GLIBC 2.39+ が必要です。CentOS 7（GLIBC 2.14）などのシステムはサポートされていません。CentOS 7 やその他の非互換システム（例：Alpine）で Aspose.Slides を実行する必要がある場合は、標準パッケージ [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET) を使用してください。  
{{% /alert %}} 

## **FAQ**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides はスタンドアロンエンジンであり、[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および [レンダリング](/slides/ja/net/convert-powerpoint-to-png/) を行います。

**正しいレンダリングのために必要なフォントは何ですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/net/font-substitution/) が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることをお勧めします。

**Linux でカスタムフォントがフォールバックや文字欠損として表示されるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損している場合、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決されません。name テーブルレコードが修正されたバージョンのフォントを使用するか、一貫した代替フォントをインストールすることで問題が解消します。