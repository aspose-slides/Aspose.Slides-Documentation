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
description: "Aspose.Slides for .NET のシステム要件を確認してください。Windows、Linux、macOS で PowerPoint および OpenDocument のシームレスなサポートを実現します。"
---

## **概要**
Aspose.Slides for .NET は Microsoft PowerPoint のインストールを必要としません。これは、Aspose.Slides が独立した Microsoft PowerPoint ドキュメントの作成、変換、ページレイアウト、レンダリングエンジンであるためです。

## **サポートされているオペレーティングシステム**
Aspose.Slides for .NET は、.NET または Mono フレームワークがインストールされている 32 ビットまたは 64 ビットのオペレーティングシステムであれば、以下を含む（ただしこれに限定されません）すべてをサポートします。

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
- Linux (Ubuntu、OpenSUSE、CentOS、Alpine など)

{{%  alert  title="注記"  color="primary"  %}} 
CentOS 7 は GLIBC 2.14 を搭載していますが、Aspose.Slides for .NET 6 および .NET 7（クロスプラットフォーム ビルドを含む）は GLIBC 2.23 以上の Linux x86_64 を必要とするため、そのようなシステムでは Aspose.Slides for .NET Standard を使用できます。
{{% /alert %}} 

### **Mac**
- Mac OS X

## **サポートされているフレームワーク**
Aspose.Slides for .NET は .NET および Mono フレームワークをサポートします：

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
- COM Interop サポート (COM、C++、VBScript)

### **Mono フレームワーク**
- MAC および Linux プラットフォームでの MONO サポート

## **開発環境**
Aspose.Slides for .NET は .NET プラットフォームを対象とする任意の開発環境でアプリケーション開発に使用できますが、以下の環境は明示的にサポートされています。

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
現在、Aspose.Slides には 2 つの主要ビルドがあります — Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
これは製品の主バージョンです。標準の .NET グラフィックス エンジンを使用します。
- 非 Windows プラットフォームでは、`libgdiplus` ライブラリとその依存関係をインストールする必要がある場合があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム向けに Aspose.Slides ZIP パッケージから .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降は、非 Windows システムでも NuGet パッケージを直接使用できます。
- 非 Windows システムで実行する場合、アプリケーションは起動時に以下の行を含める必要があります：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **バージョン 25.3 以降、このパッケージは .NET をサポートするプラットフォーム（例: Linux aarch64 (ARM64)）で使用できます。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
これは Aspose.Slides チームが開発したカスタム クロスプラットフォーム グラフィックス エンジンを使用する Aspose.Slides のバージョンです。  
非 Windows プラットフォームでは、`fontconfig` ライブラリが必要になる場合があります。

**サポートされているプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**将来のサポート予定**
- *Linux*: aarch64 (ARM64) — *ETA: 2025 年末*  

**計画なし**
- *Windows 11 ARM* (ARM64) — *現在検討されていません*  

## **よくある質問**

**変換やレンダリングのために Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は、[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および[レンダリング](/slides/ja/net/convert-powerpoint-to-png/) プレゼンテーションのためのスタンドアロン エンジンです。

**正しいレンダリングのために必要なフォントは何ですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/net/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するには、一般的なフォントパッケージをインストールすることが推奨されます。