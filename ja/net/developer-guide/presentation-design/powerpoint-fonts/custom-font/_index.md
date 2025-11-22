---
title: C#でのカスタムPowerPointフォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords: "フォント, カスタムフォント, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#でのPowerPointカスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを使用してこれらのフォントをロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType（.otf）フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slidesでは、フォントをインストールせずにプレゼンテーションでレンダリングされるフォントをロードできます。フォントはカスタムディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出します。
2. レンダリングするプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスのキャッシュをクリアします。

``` csharp
// ドキュメントディレクトリへのパス
string dataDir = "C:\\";

// フォントを検索するフォルダ
String[] folders = new String[] { dataDir };

// カスタムフォントディレクトリのフォントをロードします
FontsLoader.LoadExternalFonts(folders);

// いくつかの作業を行い、プレゼンテーション/スライドのレンダリングを実行します
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// フォントキャッシュをクリアします
FontsLoader.ClearCache();
```


## **カスタムフォントフォルダーの取得**

Aspose.Slidesは、フォントフォルダーを検索できるように [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムフォントフォルダーを返します。

```c#
 // この行はフォントファイルがチェックされるフォルダーを出力します。
 // それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
 string[] fontFolders = FontsLoader.GetFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slidesは、プレゼンテーションで使用される外部フォントを指定できるように [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供します。

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションの操作
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで利用可能です
}
```


## **外部からフォントを管理する**

Aspose.Slidesは、バイナリ データから外部フォントをロードできるように [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供します。

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションの実行中にロードされた外部フォント
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタムフォントは結果の PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーションファイルにフォントを含める必要がある場合は、明示的な [embedding features](/slides/ja/net/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。[font substitution](/slides/ja/net/font-substitution/)、[replacement rules](/slides/ja/net/font-replacement/)、および [fallback sets](/slides/ja/net/fallback-font/) を構成して、要求されたグリフが存在しない場合に使用されるフォントを正確に定義できます。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントをロードします。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

**ライセンスについてはどうですか—制限なく任意のカスタムフォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はさまざまで、埋め込みや商用利用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。