---
title: AndroidでPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用した Java による PowerPoint スライドのフォントをカスタマイズし、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントを読み込むことができます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォントです。詳しくは [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォントです。詳しくは [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides は、プレゼンテーションで使用されるフォントをインストールせずに読み込むことができます。フォントはカスタムディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出します。
2. レンダリング対象のプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader) クラスで [Clear the cache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) を実行します。

この Java コードはフォント読み込みプロセスを示しています:
```java
// フォントを探すフォルダー
String[] folders = new String[] { externalFontsDir };

// カスタムフォントディレクトリのフォントをロード
FontsLoader.loadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドのレンダリングを実行
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // フォントキャッシュをクリア
    FontsLoader.clearCache();
}
```


## **カスタムフォントフォルダーの取得**

Aspose.Slides は、フォントフォルダーを検索できるようにするために [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォントフォルダーを返します。

この Java コードは [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています:
```java
// この行はフォントファイルが検索されるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるようにするために [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

この Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティの使用方法を示しています:
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です。
} finally {
    if (pres != null) pres.dispose();
}
```


## **フォントを外部で管理する**

Aspose.Slides は、バイナリ データから外部フォントを読み込むための [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この Java コードはバイト配列によるフォント読み込みプロセスを示しています:
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

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、レンダラーによってすべてのエクスポート形式で使用されます。

**カスタムフォントは生成された PPTX に自動的に埋め込まれますか？**

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイルにフォントを含める必要がある場合は、明示的な [embedding features](/slides/ja/androidjava/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。リクエストされたグリフが欠落している場合に使用するフォントを正確に定義するために、[font substitution](/slides/ja/androidjava/font-substitution/)、[replacement rules](/slides/ja/androidjava/font-replacement/)、および [fallback sets](/slides/ja/androidjava/fallback-font/) を設定します。

**Linux/Docker コンテナ内でフォントをシステム全体にインストールせずに使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントを読み込むことができます。これにより、コンテナ イメージ内のシステムフォント ディレクトリへの依存がなくなります。

**ライセンスはどうなりますか—制限なく任意のカスタムフォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。