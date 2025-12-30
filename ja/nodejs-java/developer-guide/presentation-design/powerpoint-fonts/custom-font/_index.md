---
title: JavaScriptでPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/nodejs-java/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントのロード
- フォント管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して、Java 経由で PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は、次のフォントを [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してロードできます：

* TrueType (.ttf) および TrueType Collection (.ttc) フォントです。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォントです。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF や画像などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタムディレクトリからロードされます。

1. フォント ファイルが含まれる 1 つ以上のフォルダーを指定します。
2. static [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出し、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードしてレンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントのロード手順を示しています：
```js
// カスタムフォントファイルが含まれるフォルダーを定義します。
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 指定されたフォルダーからカスタムフォントをロードします。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、またはその他の形式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます：

1. デフォルトの OS フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) を介してロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**
Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォント フォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この JavaScript コードは [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) の使用方法を示します：
```javascript
// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は、[setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この JavaScript コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) プロパティの使用方法を示します：
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **フォントの外部管理**

Aspose.Slides は、[loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供し、バイナリ データから外部フォントをロードできます。

この JavaScript コードはバイト配列によるフォントのロード手順を示します：
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // プレゼンテーションの実行中に外部フォントがロードされます
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **FAQ**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはレンダラーによってすべてのエクスポート形式で使用されます。

**カスタム フォントは結果の PPTX に自動的に埋め込まれますか？**

いいえ。レンダリングのためにフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に含める必要がある場合は、明示的な [embedding features](/slides/ja/nodejs-java/embedded-font/) を使用する必要があります。

**カスタム フォントに特定のグリフがない場合のフォールバック 動作を制御できますか？**

はい。[font substitution](/slides/ja/nodejs-java/font-substitution/)、[replacement rules](/slides/ja/nodejs-java/font-replacement/)、および [fallback sets](/slides/ja/nodejs-java/fallback-font/) を構成して、要求されたグリフが欠落しているときに使用されるフォントを正確に定義できます。

**フォントを Linux/Docker コンテナ内で、システム全体にインストールせずに使用できますか？**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードします。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

**ライセンスはどうですか—制限なしに任意のカスタム フォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件はさまざまで、埋め込みや商用利用を禁止するものもあります。出力を配布する前に必ずフォントの EULA を確認してください。