---
title: PowerPoint のフォントを .NET でカスタマイズする
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
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明で一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides では、これらのフォントを[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを使用してロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。 詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType（.otf）フォント。 詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides では、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポート対象フォーマットなどのエクスポート出力に影響し、環境間で文書の外観が一貫します。フォントはカスタムディレクトリからロードされます。

1. フォントファイルが格納されたフォルダーを1つ以上指定します。
2. 静的な[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを呼び出し、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/)を呼び出してフォントキャッシュをクリアします。

以下のコード例はフォントのロードプロセスを示しています:
```cs
// カスタムフォントファイルが含まれるフォルダーを定義します。
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// 指定したフォルダーからカスタムフォントをロードします。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader.ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます：

1. デフォルトの OS フォントパス。
1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) でロードされたパス。

{{%/alert %}}

## **カスタムフォントフォルダーの取得**
Aspose.Slides は [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) メソッドを提供し、フォントフォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステムフォントフォルダーを返します。

この C# コードは [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています:
```c#
// この行はフォントファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides はプレゼンテーションで使用する外部フォントを指定できるように、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティを提供します。

この C# コードは [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) プロパティの使用方法を示しています:
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダー内のフォントはプレゼンテーションで使用可能です。
}
```


## **外部からフォントを管理する**

Aspose.Slides はバイナリデータから外部フォントをロードできるように、[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) メソッドを提供します。

この C# コードはバイト配列フォントのロードプロセスを示しています: 
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

はい。接続されたフォントはレンダラーによってすべてのエクスポート形式で使用されます。

**カスタムフォントは生成された PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーションファイル内にフォントを含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/net/embedded-font/)を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。要求されたグリフが欠落している場合に使用するフォントを正確に定義するために、[フォント置換](/slides/ja/net/font-substitution/)、[置換ルール](/slides/ja/net/font-replacement/)、および[フォールバックセット](/slides/ja/net/fallback-font/)を構成します。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントをロードできます。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

**ライセンスはどうですか—制限なく任意のカスタムフォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。