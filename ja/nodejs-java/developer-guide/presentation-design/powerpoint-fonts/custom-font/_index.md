---
title: JavaScriptでのカスタムPowerPointフォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/nodejs-java/custom-font/
keywords: "フォント, カスタムフォント, PowerPointプレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScriptでのPowerPointカスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、これらのフォントを[loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)メソッドを使用してロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType（.otf）フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slidesでは、フォントをインストールせずにプレゼンテーションで使用されるフォントをロードできます。フォントはカスタムディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/)クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)メソッドを呼び出します。
2. レンダリングするプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader)クラスで[Clear the cache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--)を実行します。

```javascript
// フォントを検索するフォルダー
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// カスタムフォントディレクトリのフォントをロードします
aspose.slides.FontsLoader.loadExternalFonts(folders);
// 作業を実行し、プレゼンテーション/スライドのレンダリングを行います
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // フォントキャッシュをクリアします
    aspose.slides.FontsLoader.clearCache();
}
```


## **カスタムフォント フォルダーを取得**

Aspose.Slidesは、フォントフォルダーを検索できるように[getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)メソッドを提供します。このメソッドは、`LoadExternalFonts`メソッドで追加されたフォルダーとシステムフォントフォルダーを返します。

```javascript
// この行はフォントファイルが検索されるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slidesは、プレゼンテーションで使用する外部フォントを指定できるように[setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)プロパティを提供します。

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業します
    // CustomFont1、CustomFont2、assets\fonts と global\fonts フォルダーおよびそれらのサブフォルダー内のフォントがプレゼンテーションで使用可能です
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **フォントを外部で管理する**

Aspose.Slidesは、バイナリデータから外部フォントをロードできるように[loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)メソッドを提供します。

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


## **よくある質問**

**カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタムフォントは自動的に結果の PPTX に埋め込まれますか？**

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーションファイル内に含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/nodejs-java/embedded-font/)を使用する必要があります。

**カスタムフォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/nodejs-java/font-substitution/)、[置換ルール](/slides/ja/nodejs-java/font-replacement/)、および[フォールバックセット](/slides/ja/nodejs-java/fallback-font/)を構成して、要求されたグリフが欠落している場合に使用するフォントを正確に定義できます。

**Linux/Docker コンテナでフォントをシステム全体にインストールせずに使用できますか？**

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントをロードできます。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

**ライセンスについて—制限なくカスタムフォントを埋め込めますか？**

フォントのライセンスコンプライアンスは利用者の責任です。ライセンスにより、埋め込みや商用利用が禁止されている場合があります。配布する出力物を使用する前に必ずフォントのEULAを確認してください。