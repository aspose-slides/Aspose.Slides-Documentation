---
title: Aspose.Slides for .NET 6 クロスプラットフォーム
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, クロスプラットフォーム
description: Aspose.Slides for .NET 6 クロスプラットフォーム
---

1. クロスプラットフォームのAspose.Slides for .NET 6は、.NET 7や今後の.NETリリースでも使用できます。

2. **前提条件**: クロスプラットフォーム版のAspose.Slides for .NET 6を使用するには、製品の[リリースページ](https://releases.aspose.com/slides/net/)からAspose.Slidesパッケージをダウンロードする必要があります。Aspose.Slides NuGetパッケージは.NET Standardのみにクロスプラットフォームサポートを提供しているため、適していません。

3. **必要条件**: [システム要件](https://docs.aspose.com/slides/net/system-requirements/)。Aspose.Slides for .NET 6および.NET 7は、GLIBC 2.23以上のLinux x86_x64を必要とします。**CentOS** 7（GLIBCバージョン2.14）はサポートされていません。要件を満たさないCentOS 7や他のシステム（例: Alpine）でSlidesを使用したい場合は、Aspose.Slides for .NET Standardを入手してください。

## **クロスプラットフォームのAspose.Slidesを取得して使用する**

1. 最新のAspose.SlidesのZIPパッケージを[リリースページ](https://releases.aspose.com/slides/net/)からダウンロードします。 

2. *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* からファイルを解凍し、プロジェクトで依存関係に使用されるフォルダに置きます。

3. Aspose.Slides.dllへの参照を追加します。

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   下の例では、ライブラリはプロジェクトフォルダ内のこのパスにあります: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 残りのファイル（Aspose.Slidesが依存するもの）を出力ディレクトリに配置するために、csprojプロジェクトファイルにこのように指示を追加します：
```
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. TargetPathに注意してください。 

   デフォルトでは、`<CopyToOutputDirectory>`はファイルを相対パスを保ちながらコピーしますが、依存ライブラリは出力が生成されるのと同じフォルダ（Aspose.Slides.dllの場所）に配置する必要があります。

## 注意事項

### **System.Drawing.CommonはWindows専用サポート**

.NET 6から、System.Drawing.Common（GDI+サポートを提供）へのサポートは[Windows専用](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)となります。Aspose.Slides for .NETはGDI+に依存しています。また、Aspose.Slidesの公開APIにはSystem.Drawing.Commonパッケージからの型（Bitmap、Metafile、Graphicsなど）が含まれています。

### **独自のグラフィックスサブシステム**

System.Drawing.Commonのクロスプラットフォームサポートを打ち消す破壊的変更の問題を解決するために、Aspose.Slidesはバージョン23.6から独自のグラフィックスサブシステムの実装を使用します。

サポートされるシステムは次のとおりです: **Windows**, **Linux**, **macOS**。

Aspose.Slidesのクロスプラットフォームはライブラリのコレクションです：

| Aspose.Slides.dll                                          | Aspose.Slidesのロジック全般を担当するメイン.NETアセンブリ    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | 依存関係: Win x64用のグラフィックスサブシステム実装    |
| aspose.slides.drawing.capi_vc14x86.dll                     | 依存関係: Win x64用のグラフィックスサブシステム実装    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 依存関係: Linux用のグラフィックスサブシステム実装 (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | 依存関係: macOS用のグラフィックスサブシステム実装      |

Aspose.Slides.dllは、実行されているシステムが要求するライブラリを使用します。ライブラリは通常、ファイルシステム内のAspose.Slides.dllと同じ場所にあります。

### **Aspose.Slidesの公開APIとSystem.Drawing.Commonからの型。名前の競合の問題への解決策**

Aspose.Slidesの公開APIは、System.Drawing.Commonからの型（Bitmap、Metafile、Graphicsなど）を使用しています。新しいAspose.Slidesクロスプラットフォーム製品への円滑な移行を図り、Slidesの公開APIに多くの破壊的変更を導入しないために、独自のグラフィックスサブシステムの実装はSystem.Drawing.Commonからの型と名前空間を**複製**します。

したがって、Linux環境で開発または作業を行う場合、Aspose.Slidesを依存関係として使用するだけで済み、API全体はそのままです。

**潜在的な問題**: 記述されたセットアップには欠点があります。例えば、Windowsで開発を行い、元のSystem.Drawing.Commonを使用するプロジェクトがある場合、Aspose.Slidesの型との競合が発生する可能性があります。

**解決策**: extern aliasを使用して問題を解決できます。[**System.Drawing.CommonパッケージとSlides for .NET6クラスの使用（CS0433: 型がSlidesとSystem.Drawing.Commonの両方に存在しますエラー）**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error)を参照してください。

Slidesチームは、簡素化された統一公開APIに至るタスクを進行中です。

### **NuGetとZIPパッケージ**

* NuGet Aspose.Slides for .NETは現在、クロスプラットフォームのAspose.Slides for .NET 6のサポートがありません。

* NuGet Aspose.Slides for .NETパッケージは、.NET Standard用のクロスプラットフォームをサポートしていますが、.NET 6には対応していません。

* Aspose.Slidesのクロスプラットフォーム版は、[リリースページ](https://releases.aspose.com/slides/net/)で提供されるZIPパッケージとして入手できます。

* ZIPパッケージには次のフォルダ構造が含まれています：

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* 各フォルダには、それぞれの.NETバージョンに対応するアセンブリが含まれています。.net6.0には2つのバージョンがあります: winとcrossplatform。後者には、クロスプラットフォームのAspose.Slides.dllとその全ての依存関係が含まれています。このフォルダの解凍された内容は、クロスプラットフォーム開発やその他のAspose.Slidesの使用インスタンスにおける依存関係として使用できます。