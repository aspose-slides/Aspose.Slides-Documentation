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
description: "Aspose.Slides for .NET のシステム要件を確認してください。Windows、Linux、macOS での PowerPoint および OpenDocument のシームレスなサポートを確保します。"
---
## **概要**
Aspose.Slides for .NET は Microsoft PowerPoint のインストールを必要としません。Aspose.Slides は独立した Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングエンジンです。

## **サポートされているオペレーティングシステム**
Aspose.Slides for .NET は .NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステム全般をサポートします（ただしこれに限られません）。

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
- Linux (Ubuntu、OpenSUSE、CentOS、Alpine など)

{{%  alert  title="Notes"  color="primary"  %}} 
CentOS 7 は GLIBC 2.14 を搭載していますが、Aspose.Slides for .NET 6 および .NET 7（クロスプラットフォーム ビルドを含む）は GLIBC 2.23 以上の Linux x86_64 を必要とします。そのため、該当システムでは Aspose.Slides for .NET Standard を使用できます。
{{% /alert %}} 

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
Aspose.Slides for .NET は .NET プラットフォーム向けの任意の開発環境で使用できますが、以下の環境は明示的にサポートされています。

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
現在、Aspose.Slides には主に 2 つのビルドがあります — Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
このビルドは製品のメインバージョンです。標準の .NET グラフィックエンジンを使用します。
- 非 Windows プラットフォームでは `libgdiplus` ライブラリとその依存関係をインストールする必要がある場合があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム向けに Aspose.Slides ZIP パッケージに含まれる .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、NuGet パッケージを非 Windows システムでも直接使用できます。
- 非 Windows システムで実行する場合、起動時に以下の行をアプリケーションに含める必要があります:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **バージョン 25.3 以降、Linux aarch64 (ARM64) など .NET をサポートするプラットフォームでもこのパッケージを使用できます。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Aspose.Slides チームが開発したカスタム クロスプラットフォーム グラフィックエンジンを使用したビルドです。  
非 Windows プラットフォームでは `fontconfig` ライブラリが必要になる場合があります。

**サポートプラットフォーム**
- *Windows*: x86, x86_64
- *Linux*: x86_64
- *macOS*: x86_64, ARM64

**今後のサポート予定**  
- *Linux*: aarch64 (ARM64) — *ETA: end of 2025*

**未計画**  
- *Windows 11 ARM* (ARM64) — *現在は検討されていません*

## **FAQ**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は不要です。Aspose.Slides は [作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および [レンダリング](/slides/ja/net/convert-powerpoint-to-png/) を行う単体エンジンです。

**正しいレンダリングのために必要なフォントは何ですか？**

実際にはプレゼンテーションで使用されているフォント、もしくは適切な [代替フォント](/slides/ja/net/font-substitution/) が利用可能である必要があります。Linux/macOS での一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることを推奨します。

**Linux でカスタムフォントがフォールバックや欠落テキストとして表示されるのはなぜですか？**

フォントファイルの name-table エントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。名前テーブルが修正されたフォントバージョンを使用するか、一貫した代替フォントをインストールすれば問題は解消します。