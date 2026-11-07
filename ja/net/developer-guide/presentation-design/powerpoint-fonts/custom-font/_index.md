---
title: PowerPoint のフォントを .NET でカスタマイズ
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
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明で一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントをロードしたり、ドキュメントレベルのフォントソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから外部フォントを直接ロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明します。

カスタムフォントをレンダリング用に登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーション テーマは、個々の文字体系ごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を保存しますが、フォント ファイルをインストールまたはロードしません。[スクリプト固有のテーマフォント](/slides/ja/net/script-specific-font-mappings/) を参照してマッピングを管理し、以下のロード オプションを使用して参照されたフォントを一貫したレンダリングに利用できるようにします。

{{% alert color="info" title="Note" %}}
Aspose Slides では、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを使用してこれらのフォントをロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。
* OpenType (.otf) フント。 詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。
{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポートされている形式などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが含まれるフォルダーを1つ以上指定します。
2. static [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントのロード プロセスを示しています：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// カスタムフォントファイルを含むフォルダーを定義します。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、またはその他の形式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます:

1. デフォルトのオペレーティングシステム フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) を介してロードされたパス。
{{%/alert %}}

## **カスタムフォント フォルダーの取得**
Aspose.Slides は、[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供し、フォント フォルダーを検索できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この C# コードは、[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています：

```c#
using Aspose.Slides;

// この行はフォント ファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォント フォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この C# コードは、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用方法を示しています：

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションを処理します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントは、プレゼンテーションで使用可能です
}
```

## **フォントの外部管理**
Aspose.Slides は、[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供し、バイナリ データから外部フォントをロードできます。

この C# コードはバイト配列によるフォントのロード プロセスを示しています：

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションのライフタイム中に外部フォントがロードされました
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

エクスポート時に埋め込みフォントを削除せず、マッチする登録済みフォントに優先順位を付けるには、[埋め込みフォントよりも登録済みフォントを優先する](/slides/ja/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 以降) を参照してください。

## **よくある質問**

**カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタムフォントは結果の PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むことと同じではありません。フォントをプレゼンテーション ファイル内に保持する必要がある場合は、明示的な [埋め込み機能](/slides/ja/net/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフがない場合、フォールバック動作を制御できますか？**

はい。リクエストされたグリフが存在しない場合に使用するフォントを正確に定義するため、[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)、および [フォールバックセット](/slides/ja/net/fallback-font/) を構成します。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードします。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

> **Linux/Docker への注意**: `FontsLoader.LoadExternalFonts` を呼び出す際、`directories` 配列の各エントリが既存ディレクトリへの空でないパスを含んでいることを確認してください。フォントパスの構築に使用された環境変数が未定義または空の場合、Aspose.Slides は空の値をフルパスとして解決しようとし、`System.ArgumentException` が発生する可能性があります。

**ライセンスについて—制限なく任意のカスタムフォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。