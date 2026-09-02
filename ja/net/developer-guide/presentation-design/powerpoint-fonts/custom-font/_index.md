---
title: .NET で PowerPoint のフォントをカスタマイズ
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords:
- フォント
- カスタム フォント
- 外部フォント
- フォントの読み込み
- フォント管理
- フォント フォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのフォントをカスタマイズし、どのデバイスでもプレゼンテーションを鮮明かつ一貫した状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにフォントをインストールせずに、プレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントを読み込む、ドキュメントレベルのフォント ソースで特定のプレゼンテーションにフォントを提供する、またはバイナリ データから直接外部フォントを読み込むことができます。

読み込まれたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます（たとえば PDF、画像、およびその他のサポートされている形式）。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に保存する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーション テーマは、個々の文字体系ごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を保存しますが、フォント ファイルをインストールまたは読み込むわけではありません。マッピングの管理については [Script-Specific Theme Fonts](/slides/ja/net/script-specific-font-mappings/) を参照し、下記の読み込みオプションで参照されたフォントを利用可能にして一貫したレンダリングを実現してください。

{{% alert color="info" title="Note" %}}
Aspose Slides は次のメソッドを使用してこれらのフォントを読み込むことができます: [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/)。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照。
* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照。
{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用するフォントを読み込むことができます。これは PDF や画像などのエクスポート結果に影響し、環境間でドキュメントの外観が一貫します。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。  
2. 静的メソッド [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) を呼び出して、これらのフォルダーからフォントを読み込みます。  
3. プレゼンテーションを読み込み、レンダリング／エクスポートします。  
4. フォント キャッシュをクリアするために [FontsLoader.ClearCache](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/clearcache/) を呼び出します。

以下のコード例はフォントの読み込み手順を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// カスタムフォントファイルが含まれるフォルダーを定義します。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 指定したフォルダーからカスタムフォントをロードします。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます。

1. デフォルトのオペレーティング システム フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/) によって読み込まれたパス。  
{{%/alert %}}

## **カスタム フォント フォルダーの取得**
Aspose.Slides は [GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供し、フォント フォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

以下の C# コードは [GetFontFolders](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/getfontfolders/) の使用例です。

```c#
using Aspose.Slides;

// この行はフォントファイルがチェックされるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は [DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供し、プレゼンテーションに使用する外部フォントを指定できます。

以下の C# コードは [DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用例です。

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションで作業します
    // CustomFont1、CustomFont2、assets\fonts と global\fonts フォルダーおよびそのサブフォルダー内のフォントはプレゼンテーションで使用可能です
}
```

## **外部フォントの管理**

Aspose.Slides は [LoadExternalFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供し、バイナリ データから外部フォントを読み込むことができます。

以下の C# コードはバイト配列によるフォント読み込みプロセスを示しています。

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションのライフタイム中に外部フォントがロードされています
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラによって使用されます。

**カスタム フォントは自動的に生成される PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイルにフォントを保持する必要がある場合は、明示的な [埋め込み機能](/slides/ja/net/embedded-font/) を使用してください。

**カスタム フォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)、および [フォールバックセット](/slides/ja/net/fallback-font/) を構成して、要求されたグリフが存在しないときに使用するフォントを正確に指定できます。

**Linux/Docker コンテナ内でシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントを読み込むことで、コンテナイメージ内のシステム フォント ディレクトリへの依存を排除できます。

> **Note for Linux/Docker**: When calling `FontsLoader.LoadExternalFonts`, ensure that every entry in the `directories` array contains a non-empty path to an existing directory. If an environment variable used to construct a font path is undefined or empty, Aspose.Slides may attempt to resolve the empty value as a full path, resulting in `System.ArgumentException`.

**ライセンスに関して—カスタム フォントを制限なく埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件はフォントごとに異なり、埋め込みや商用利用を禁止するものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。