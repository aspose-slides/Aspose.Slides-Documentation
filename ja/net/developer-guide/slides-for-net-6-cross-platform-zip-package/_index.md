---
title: Aspose.Slides for .NET 6 クロスプラットフォーム (ZIP パッケージ)
type: docs
weight: 237
url: /ja/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- クロスプラットフォーム
- .NET 6
- GLIBC
- csproj
- ターゲット パス
- 依存ライブラリ
- Aspose.Slides.dll
- System.Drawing.Common
- 名前の競合
- extern エイリアス
- CS0433
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6 を使用して、Windows、Linux、macOS 上でクロスプラットフォームの C# アプリを構築し、PowerPoint の PPT、PPTX および ODP ファイルを作成、編集、変換できます。"
---

{{% alert title="注意" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform は、[NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)からも入手できます。

{{% /alert %}}

## **ZIP パッケージから Cross-Platform Aspose.Slides を使用する**

1. 最新の Aspose.Slides の ZIP パッケージを[Release Page](https://releases.aspose.com/slides/net/)からダウンロードします。

2. ファイルを *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* から解凍し、プロジェクトで依存関係として使用するフォルダーに配置します。

3. Aspose.Slides.dll への参照を追加します。

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   以下の例では、ライブラリはプロジェクト フォルダーの次のパスにあります: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 残りのファイル（Aspose.Slides が依存するもの）を出力ディレクトリに配置するため、csproj プロジェクト ファイルに次のように指示を追加します:
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

   デフォルトでは、`<CopyToOutputDirectory>` は相対パスを保持したままファイルをコピーしますが、依存ライブラリを出力が生成されるフォルダー（Aspose.Slides.dll の場所）に配置する必要があります。

## **Notes**

### **独自のグラフィックス サブシステム**

Aspose.Slides cross-platform はライブラリのコレクションです：

| Aspose.Slides.dll                                          | Aspose.Slides のすべてのロジックを担当する主な .NET アセンブリ                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dependency: Win x64 用グラフィックス サブシステム実装                    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dependency: Win x64 用グラフィックス サブシステム実装                    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dependency: Linux (x86/x64) 用グラフィックス サブシステム実装          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dependency: macOS AMD64 (x86-64/x64) 用グラフィックス サブシステム実装 |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dependency: macOS ARM64 (AArch64) 用グラフィックス サブシステム実装    |

Aspose.Slides.dll は、実行中のシステムが必要とするライブラリを使用します。これらのライブラリは通常、任意のファイルシステム内で Aspose.Slides.dll と同じ場所に配置されています。

### **ZIP パッケージ構造**

ZIP パッケージには以下のフォルダー構造が含まれています：

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* 各フォルダーには、対応する .NET バージョン用のアセンブリが含まれています。net6.0 には default と crossplatform の 2 つのバージョンがあります。後者には cross-platform Aspose.Slides.dll とそのすべての依存関係が含まれます。このフォルダーの展開済み内容は、cross-platform 開発やその他の Aspose.Slides の使用例において、プロジェクトへの依存関係追加として使用できます。

## **See Also**

- [システム要件](/slides/ja/net/system-requirements/)