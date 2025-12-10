---
title: JavaでPowerPointのフォントをカスタマイズする
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/java/custom-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides では、[loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントをロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳しくは [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。詳しくは [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides は、フォントをインストールすることなくプレゼンテーションでレンダリングされるフォントをロードできます。フォントはカスタム ディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出します。
2. レンダリングするプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) クラスで [clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) をクリアします。

```java
// フォントを検索するフォルダー
String[] folders = new String[] { externalFontsDir };

// カスタムフォントディレクトリのフォントをロード
FontsLoader.loadExternalFonts(folders);

// 作業を実行し、プレゼンテーション/スライドのレンダリングを行う
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // フォントキャッシュをクリア
    FontsLoader.clearCache();
}
```


## **カスタム フォント フォルダーの取得**

Aspose.Slides は、フォント フォルダーを取得できるように [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

```java
// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるように [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダーのフォントがプレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```


## **フォントを外部で管理**

Aspose.Slides は、バイナリ データから外部フォントをロードできるように [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // プレゼンテーションの実行中に外部フォントがロードされます
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**カスタム フォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタム フォントは生成された PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイルに含める必要がある場合は、明示的な [embedding features](/slides/ja/java/embedded-font/) を使用する必要があります。

**カスタム フォントに特定のグリフが欠けている場合、フォールバック 動作を制御できますか？**

はい。[font substitution](/slides/ja/java/font-substitution/)、[replacement rules](/slides/ja/java/font-replacement/)、および [fallback sets](/slides/ja/java/fallback-font/) を構成して、要求されたグリフが存在しない場合に使用するフォントを正確に指定できます。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードしてください。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

**ライセンスについて—制限なく任意のカスタム フォントを埋め込めますか？**

フォントのライセンス遵守はご利用者の責任です。条件はさまざまで、埋め込みや商用利用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。