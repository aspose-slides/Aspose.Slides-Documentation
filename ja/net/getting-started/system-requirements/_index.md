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
- Aspose.Slides
description: "Aspose.Slides for .NET のシステム要件を確認してください。Windows、Linux、macOS で PowerPoint と OpenDocument のシームレスなサポートを実現します。"
---

## **概要**
Aspose.Slides for .NET は、Aspose.Slides が独立した Microsoft PowerPoint ドキュメント作成、変換、ページレイアウト、レンダリングエンジンであるため、Microsoft PowerPoint をインストールする必要がありません。

## **サポートされているオペレーティングシステム**
Aspose.Slides for .NET は、.NET または Mono フレームワークがインストールされている任意の 32 ビットまたは 64 ビットオペレーティングシステムをサポートします（ただしこれに限られません）。

### **Windows**
- Microsoft Windows 2000 Server（ x64, x86）
- Microsoft Windows 2003 Server（ x64, x86）
- Microsoft Windows 2022 Server
- Microsoft Windows Vista（ x64, x86）
- Microsoft Windows XP（ x64, x86）
- Microsoft Windows 7（ x64, x86）
- Microsoft Windows 8, 8.1（ x64, x86）
- Microsoft Windows 10（ x64, x86）
- Microsoft Windows 11（ x64, x86）
- Microsoft Azure

### **Linux**
- Linux（Ubuntu、OpenSUSE、CentOS、Alpine、その他）

{{%  alert  title="Notes"  color="primary"  %}} 
CentOS 7 は GLIBC 2.14 を搭載していますが、Aspose.Slides for .NET 6 および .NET 7（クロスプラットフォーム ビルドを含む）は GLIBC 2.23 以上の Linux x86_64 を必要とするため、そのようなシステムでは Aspose.Slides for .NET Standard を使用できます。 
{{% /alert %}} 

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
- MAC と Linux プラットフォームでの MONO サポート

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
現在、Aspose.Slides には 2 つの主要ビルドがあります — Aspose.Slides.NET と Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
これは製品のメインバージョンです。標準の .NET グラフィックスエンジンを使用します。
- 非 Windows プラットフォームでは、`libgdiplus` ライブラリとその依存関係をインストールする必要があります。
- Aspose.Slides 25.3 以前のバージョンでは、非 Windows プラットフォーム向けに Aspose.Slides ZIP パッケージの .NET Standard 2.0 DLL を使用する必要がありました。
- Aspose.Slides 25.3 以降では、NuGet パッケージを非 Windows システムでも直接使用できます。
- 非 Windows システムで実行する場合、アプリケーションは起動時に次の行を含める必要があります：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **バージョン 25.3 以降、このパッケージは Linux aarch64（ARM64）など .NET をサポートするプラットフォームで使用できます。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
これは Aspose.Slides チームが開発したカスタム クロスプラットフォーム グラフィックスエンジンを使用する Aspose.Slides のバージョンです。  
非 Windows プラットフォームでは、`fontconfig` ライブラリが必要になる場合があります。

**サポートされているプラットフォーム**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**将来的にサポート予定**
- *Linux*: aarch64（ARM64） — *予定時期: 2025 年末*  

**未計画**
- *Windows 11 ARM*（ARM64） — *現在検討されていません*

## **FAQ**

**変換やレンダリングに Microsoft PowerPoint のインストールは必要ですか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は、プレゼンテーションの[作成](/slides/ja/net/create-presentation/)、変更、[変換](/slides/ja/net/convert-presentation/)、および[レンダリング](/slides/ja/net/convert-powerpoint-to-png/) のためのスタンドアロン エンジンです。

**正しいレンダリングのために必要なフォントは何ですか？**

実際には、プレゼンテーションで使用されているフォントまたは適切な[代替フォント](/slides/ja/net/font-substitution/)が利用可能である必要があります。Linux/macOS で一貫したレンダリングを確保するために、一般的なフォントパッケージをインストールすることを推奨します。