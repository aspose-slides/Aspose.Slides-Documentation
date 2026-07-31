---
title: Aspose.Slides for .NET 6 クロスプラットフォーム（ZIP パッケージ）
type: docs
weight: 237
url: /ja/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- クロスプラットフォーム
- .NET 6
- GLIBC
- csproj
- ターゲット パス
- 依存ライブラリ
- Aspose.Slides.dll
- System.Drawing.Common
- 名前 の衝突
- extern エイリアス
- CS0433
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6 を使用して、Windows、Linux、macOS 上でクロスプラットフォーム C# アプリを構築し、PowerPoint の PPT、PPTX および ODP ファイルの作成、編集、変換を行います。"
---
## **概要**

このガイドでは、ZIP パッケージから Aspose.Slides for .NET 6 Cross-Platform を使用する方法を説明します。パッケージのダウンロード方法、`net6.0/crossplatform` フォルダーからファイルを展開する手順、`Aspose.Slides.dll` への参照の追加、必要な依存ライブラリがアプリケーションの出力ディレクトリにコピーされるようにプロジェクト ファイルを構成する方法を解説します。

また、クロスプラットフォーム パッケージの内容についても説明します。これには、メインの Aspose.Slides .NET アセンブリと、Windows、Linux、macOS 用のプラットフォーム固有のグラフィックス サブシステム ライブラリが含まれます。

{{% alert title="Note" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform は、[NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) でも入手できます。
{{% /alert %}}

## **ZIP パッケージからクロスプラットフォーム Aspose.Slides を使用する方法**

1. 最新の Aspose.Slides の ZIP パッケージを [リリース ページ](https://releases.aspose.com/slides/ja/net/) からダウンロードします。

2. *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* からファイルを展開し、プロジェクトで依存関係として使用するフォルダーに配置します。

3. Aspose.Slides.dll への参照を追加します。

   ![プロジェクト参照を追加（Visual Studio）](add-project-reference-visual-studio.png)

   以下の例では、ライブラリがプロジェクト フォルダー内の次のパスにあります: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![コンソール アプリの参照先を参照](browse-console-app.jpg)

4. csproj プロジェクト ファイルに次のように指示を追加して、残りのファイル（Aspose.Slides が依存するファイル）を出力ディレクトリに配置します。

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. `TargetPath` に注意してください。

   デフォルトでは、`<CopyToOutputDirectory>` は相対パスを保持したままファイルをコピーしますが、依存ライブラリは出力が生成されるフォルダー（Aspose.Slides.dll の場所）に配置する必要があります。

## **注記**

### **プロプライエタリ グラフィックス サブシステム**

Aspose.Slides クロスプラットフォームは次のライブラリの集合です。

| Aspose.Slides.dll                                          | すべての Aspose.Slides ロジックを担当するメイン .NET アセンブリ |
| ---------------------------------------------------------- | ---------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | 依存関係: Win x64 用グラフィックス サブシステム実装                |
| aspose.slides.drawing.capi_vc14x86.dll                     | 依存関係: Win x64 用グラフィックス サブシステム実装                |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 依存関係: Linux 用グラフィックス サブシステム実装 (x86/x64)       |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 依存関係: macOS AMD64 (x86-64/x64) 用グラフィックス サブシステム実装 |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 依存関係: macOS ARM64 (AArch64) 用グラフィックス サブシステム実装   |

Aspose.Slides.dll は、実行中のシステムが必要とするライブラリを使用します。これらのライブラリは通常、ファイルシステム上の Aspose.Slides.dll と同じ場所に配置されています。

### **ZIP パッケージの構成**

ZIP パッケージには次のフォルダー構造が含まれています。

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* 各フォルダーには対応する .NET バージョン用のアセンブリが含まれます。net6.0 には default と crossplatform の 2 つのバージョンがあります。後者にはクロスプラットフォーム 用の Aspose.Slides.dll とそのすべての依存関係が含まれます。このフォルダーの展開内容は、クロスプラットフォーム 開発やその他の Aspose.Slides の使用シナリオでプロジェクトに依存関係として追加できます。

## **関連項目**

- [システム要件](/slides/ja/net/system-requirements/)