---
title: .NET で PowerPoint フォントをカスタマイズ
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords:
- フォント
- カスタム フォント
- 外部フォント
- フォントをロード
- フォントを管理
- フォント フォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明で一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントをロードしたり、ドキュメント レベルのフォント ソースを使用して特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます（例: PDF、画像、その他のサポートされている形式）。これにより、異なる環境間でプレゼンテーションの出力を一貫させることができます。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントを使用した後にフォント キャッシュをクリアする方法についても説明しています。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション内に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="info" %}} 
Aspose Slides では、これらのフォントを [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを使用してロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。
* OpenType（.otf）フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントのロード**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポートされている形式などのエクスポート出力に影響し、生成されるドキュメントが環境間で一貫した外観になります。フォントはカスタム ディレクトリからロードされます。

1. フォントファイルを含むフォルダーを 1 つ以上指定します。
2. 静的な [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントのロード プロセスを示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// カスタムフォントファイルを含むフォルダーを定義します。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加のフォルダーを追加しますが、フォントの初期化順序は変更しません。  
フォントは次の順序で初期化されます:

1. デフォルトのオペレーティング システム フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/) でロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は、フォント フォルダーを検索できるようにする [GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

この C# コードは、[GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています。

```c#
using Aspose.Slides;

// この行はフォントファイルがチェックされるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるようにする [DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供します。

この C# コードは、[DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用方法を示しています。

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダーのフォントは、プレゼンテーションで使用できます
}
```

## **外部フォントの管理**

Aspose.Slides は、バイナリ データから外部フォントをロードできる [LoadExternalFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供します。

この C# コードは、バイト配列によるフォントのロード プロセスを示しています。

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションの実行期間中に外部フォントがロードされます
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**  
はい。接続されたフォントは、すべてのエクスポート形式でレンダラによって使用されます。

**カスタム フォントは結果の PPTX に自動的に埋め込まれますか？**  
いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に含める必要がある場合は、明示的な [埋め込み機能](/slides/ja/net/embedded-font/) を使用しなければなりません。

**カスタム フォントに特定のグリフがない場合、フォールバック動作を制御できますか？**  
はい。要求されたグリフが存在しない場合に使用されるフォントを正確に定義するために、[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)、および [フォールバック セット](/slides/ja/net/fallback-font/) を構成します。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**  
はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードします。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

> **Linux/Docker 用の注意**: `FontsLoader.LoadExternalFonts` を呼び出す際は、`directories` 配列の各エントリが既存ディレクトリへの空でないパスであることを確認してください。フォント パスの構築に使用される環境変数が未定義または空の場合、Aspose.Slides は空の値をフルパスとして解決しようとし、`System.ArgumentException` が発生する可能性があります。

**ライセンスについて—制限なく任意のカスタム フォントを埋め込めますか？**  
フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。