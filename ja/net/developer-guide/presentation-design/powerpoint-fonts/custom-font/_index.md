---
title: .NETでPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントのロード
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのフォントをカスタマイズし、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを使用して次のフォントを読み込むことができます。

* TrueType（.ttf）および TrueType コレクション（.ttc）フォント。 詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType（.otf）フォント。 詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides を使用すると、プレゼンテーションで使用されるフォントをインストールせずに読み込むことができます。フォントはカスタムディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出します。  
2. 表示するプレゼンテーションをロードします。  
3. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスでキャッシュをクリアします。

この C# コードはフォント読み込みプロセスを示しています:
``` csharp
// ドキュメントディレクトリへのパス
string dataDir = "C:\\";

// フォントを検索するフォルダー
String[] folders = new String[] { dataDir };

// カスタムフォントディレクトリのフォントをロード
FontsLoader.LoadExternalFonts(folders);

// いくつかの作業を行い、プレゼンテーション/スライドのレンダリングを実行
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// フォントキャッシュをクリア
FontsLoader.ClearCache();
```


## **カスタムフォントフォルダーの取得**
Aspose.Slides は、[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供し、フォントフォルダーを取得できるようにします。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムフォントフォルダーを返します。

この C# コードは [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています:
```c#
// この行はフォントファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるように、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供します。

この C# コードは [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用方法を示しています:
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションで作業します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで利用可能です
}
```


## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントを読み込むために、[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供します。

この C# コードはバイト配列によるフォント読み込みプロセスを示しています:
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションの存続期間中に外部フォントがロードされます
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラによって使用されます。

**カスタムフォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイルにフォントを含める必要がある場合は、明示的な [埋め込み機能](/slides/ja/net/embedded-font/) を使用してください。

**カスタムフォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)、および [フォールバックセット](/slides/ja/net/fallback-font/) を構成して、要求されたグリフが欠如しているときに使用するフォントを正確に定義できます。

**Linux/Docker コンテナー内でフォントをシステム全体にインストールせずに使用できますか？**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントを読み込むことで、コンテナー イメージ内のシステム フォント ディレクトリへの依存を取り除くことができます。

**ライセンスについて—カスタムフォントを制限なく埋め込むことはできますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件は様々で、埋め込みや商用利用を禁止しているものもあります。出力を配布する前に、必ずフォントの EULA を確認してください。