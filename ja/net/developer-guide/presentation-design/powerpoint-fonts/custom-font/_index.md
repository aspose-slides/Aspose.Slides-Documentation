---
title: .NET で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントの読み込み
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮やかで一貫性のあるものにします。"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを使用してこれらのフォントをロードできます。

* TrueType（.ttf）およびTrueType Collection（.ttc）フォント。詳しくは[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType（.otf）フォント。詳しくは[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slidesでは、フォントをシステムにインストールせずにプレゼンテーションで使用できるように、カスタムディレクトリからフォントをロードできます。

1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)クラスのインスタンスを作成し、[LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを呼び出します。
2. レンダリング対象のプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)クラスでキャッシュをクリアします。

このC#コードはフォントのロード手順を示しています:
``` csharp
// ドキュメント ディレクトリへのパス
string dataDir = "C:\\";

// フォントを検索するフォルダー
String[] folders = new String[] { dataDir };

// カスタム フォント ディレクトリのフォントをロード
FontsLoader.LoadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドのレンダリングを実行
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// フォント キャッシュをクリア
FontsLoader.ClearCache();
```


## **カスタムフォント フォルダーの取得**
Aspose.Slidesは、[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)メソッドを提供し、フォントフォルダーを検索できます。このメソッドは、`LoadExternalFonts`メソッドで追加したフォルダーとシステムフォントフォルダーを返します。

このC#コードは[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)の使用例を示しています:
```c#
 // この行はフォントファイルがチェックされるフォルダーを出力します。
 // これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **プレゼンテーションで使用されるカスタムフォントの指定**
Aspose.Slidesは、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/)プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

このC#コードは[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/)プロパティの使用例を示しています:
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダーのフォントはプレゼンテーションで使用可能です
}
```


## **外部フォントの管理**

Aspose.Slidesは、バイナリデータから外部フォントをロードできる[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)メソッドを提供します。

このC#コードはバイト配列によるフォントロードの手順を示しています: 
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

はい。接続されたフォントは、すべてのエクスポート形式でレンダラによって使用されます。

**カスタムフォントは自動的に生成されるPPTXに埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTXに埋め込むこととは異なります。プレゼンテーションファイル内にフォントを含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/net/embedded-font/)を使用してください。

**カスタムフォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)および[フォールバックセット](/slides/ja/net/fallback-font/)を構成して、要求されたグリフが欠落している場合に使用するフォントを正確に定義できます。

**Linux/Docker コンテナ内でフォントをシステム全体にインストールせずに使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

**ライセンスはどうですか — カスタムフォントを制限なく埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件は異なり、埋め込みや商用利用を禁止するものもあります。出力を配布する前に必ずフォントのEULAを確認してください。