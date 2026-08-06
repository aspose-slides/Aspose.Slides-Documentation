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
- フォントのロード
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint スライドのフォントをカスタマイズし、どのデバイスでもプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides は、OS にインストールせずにプレゼンテーションでカスタムフォントを使用できるようにします。 カスタムフォルダーからフォントをロードしたり、ドキュメントレベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます（例: PDF、画像、その他のサポート形式）。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォントフォルダーの確認方法と、外部フォントの使用後にフォントキャッシュをクリアする方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション内部に保存する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="primary" %}} 
Aspose Slides は、次のメソッドを使用してこれらのフォントをロードできます。[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) 方法:

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポート形式などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタムディレクトリからロードされます。

1. フォントファイルが含まれるフォルダーを 1 つ以上指定します。
2. 静的メソッド [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) を呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. フォントキャッシュをクリアするために [FontsLoader.ClearCache](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/clearcache/) を呼び出します。

以下のコード例は、フォントのロード手順を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// カスタムフォントファイルが含まれるフォルダーを定義します。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式へ）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます：

1. デフォルトの OS フォントパス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/) を介してロードされたパス。

{{%/alert %}}

## **カスタムフォントフォルダーの取得**
Aspose.Slides は、フォントフォルダーを取得できるように [GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォントフォルダーを返します。

以下の C# コードは、[GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています。

```c#
using Aspose.Slides;

// この行はフォントファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるように [DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供します。

以下の C# コードは、[DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用例です。

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダーのフォントはプレゼンテーションで利用可能です
}
```

## **フォントを外部で管理する**

Aspose.Slides は、バイナリ データから外部フォントをロードできるように [LoadExternalFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供します。

以下の C# コードは、バイト配列によるフォントロードの手順を示しています。 

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

## **よくある質問**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタムフォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的な [embedding features](/slides/ja/net/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。[font substitution](/slides/ja/net/font-substitution/)、[replacement rules](/slides/ja/net/font-replacement/)、および [fallback sets](/slides/ja/net/fallback-font/) を構成して、要求されたグリフが存在しない場合に使用されるフォントを正確に定義できます。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

> **Linux/Docker 用の注意**: `FontsLoader.LoadExternalFonts` を呼び出す際は、`directories` 配列の各エントリが存在するディレクトリへの空でないパスであることを確認してください。フォントパスの構築に使用された環境変数が未定義または空の場合、Aspose.Slides は空の値を完全なパスとして解決しようとし、`System.ArgumentException` が発生する可能性があります。

**ライセンスはどうなりますか — カスタムフォントを制限なく埋め込むことはできますか？**

フォントのライセンス遵守はユーザーの責任です。条件はフォントによって異なり、一部のライセンスでは埋め込みや商用利用を禁止しています。出力を配布する前に必ずフォントの EULA を確認してください。