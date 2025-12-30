---
title: Android で PowerPoint フォントをカスタマイズ
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/androidjava/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントのロード
- フォントの管理
- フォント フォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides の Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをあらゆるデバイスで鮮明かつ一貫性のある状態に保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は次のフォントを [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドで読み込むことができます:

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。 詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。この機能は PDF や画像などのエクスポート出力に影響し、環境間でドキュメントの外観を一貫させます。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。
2. 静的メソッド [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) を呼び出し、これらのフォルダーからフォントを読み込みます。
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) を呼び出してフォント キャッシュをクリアします。

フォント 読み込みプロセスを示すコード例:
```java
// カスタムフォントファイルが含まれるフォルダーを定義します。
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 指定したフォルダーからカスタムフォントをロードします。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例：PDF、画像、その他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) は検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます:

1. デフォルトのオペレーティング システム フォント パス。
2. [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) で読み込まれたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**
Aspose.Slides は [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォント フォルダーを検索できるようにします。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この Java コードは [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています:
```java
// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティの使用例を示しています:
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダおよびそのサブフォルダのフォントがプレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```


## **フォントの外部管理**

Aspose.Slides はバイト データから外部フォントを読み込むために [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この Java コードはバイト配列によるフォント読み込みプロセスを示しています:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // プレゼンテーションのライフタイム中に外部フォントがロードされました
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**カスタム フォントはすべての形式 (PDF、PNG、SVG、HTML) のエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラによって使用されます。

**カスタム フォントは結果の PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを含める必要がある場合は、明示的な [埋め込み機能](/slides/ja/androidjava/embedded-font/) を使用してください。

**カスタム フォントに特定のグリフがない場合のフォールバック 動作を制御できますか？**

はい。[フォント置換](/slides/ja/androidjava/font-substitution/)、[置換ルール](/slides/ja/androidjava/font-replacement/) および [フォールバック セット](/slides/ja/androidjava/fallback-font/) を構成して、要求されたグリフが欠けているときに使用するフォントを正確に定義できます。

**Linux/Docker コンテナー内でフォントをインストールせずに使用できますか？**

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントを読み込むことで、コンテナー イメージ内のシステム フォント ディレクトリへの依存を排除できます。

**ライセンスに関して—制限なしでカスタム フォントを埋め込めますか？**

フォントのライセンス遵守はユーザーの責任です。ライセンスにより埋め込みや商用利用が禁止されている場合があります。出力を配布する前に必ずフォントの EULA を確認してください。