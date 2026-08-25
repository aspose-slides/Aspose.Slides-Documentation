---
title: JavaScript で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Java と Node.js 用 Aspose.Slides を使用し、JavaScript で PowerPoint スライドのフォントをカスタマイズして、どのデバイスでもプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントを読み込むこと、ドキュメントレベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供すること、またはバイナリ データから直接外部フォントを読み込むことができます。

読み込まれたフォントは、プレゼンテーションをレンダリングまたはエクスポートする際に使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、さまざまな環境間でプレゼンテーションの出力が一貫します。また、本記事では Aspose.Slides が使用するフォントフォルダーの確認方法と、外部フォント使用後にフォントキャッシュをクリアする方法についても説明しています。

レンダリング用にカスタムフォントを登録することは、PPTX ファイルにフォントを埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の書字システムごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を保持しますが、フォントファイルをインストールしたり読み込んだりはしません。マッピングを管理するには[Script-Specific Theme Fonts](/slides/ja/nodejs-java/script-specific-font-mappings/)をご覧ください。また、以下の読み込みオプションを使用して、参照されたフォントを一貫したレンダリングのために利用できるようにします。

{{% alert color="info" title="注意" %}}
Aspose Slides では、[loadExternalFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントを読み込むことができます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType（.otf）フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。
{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF、画像、その他のサポート形式などのエクスポート出力が環境間で一貫した見た目になります。フォントはカスタムディレクトリから読み込まれます。

1. フォント ファイルが格納されているフォルダーを1つ以上指定します。
2. 静的な[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)メソッドを呼び出し、これらのフォルダーからフォントを読み込みます。
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/clearcache/) を呼び出してフォントキャッシュをクリアします。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// カスタムフォントファイルを含むフォルダーを定義します。
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 指定されたフォルダーからカスタムフォントを読み込みます。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 読み込んだフォントを使用してプレゼンテーションをレンダー/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="注意" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます。

1. デフォルトの OS フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/) を介してロードされたパス。
{{%/alert %}}

## **カスタムフォント フォルダーの取得**

Aspose.Slides は、フォント フォルダーを検索できるように[getFontFolders](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)メソッドを提供しています。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定できるように[setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)プロパティを提供しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダーにあるフォントは、プレゼンテーションで使用可能です
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントを読み込むために[loadExternalFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)メソッドを提供しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // プレゼンテーションのライフタイム中に外部フォントがロードされます
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **よくある質問**

### カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラによって使用されます。

### カスタムフォントは自動的に結果の PPTX に埋め込まれますか？

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むことと同じではありません。プレゼンテーション ファイルにフォントを含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/nodejs-java/embedded-font/) を使用する必要があります。

### カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？

はい。要求されたグリフが存在しない場合に使用されるフォントを正確に定義できるよう、[font substitution](/slides/ja/nodejs-java/font-substitution/)、[replacement rules](/slides/ja/nodejs-java/font-replacement/)、および[fallback sets](/slides/ja/nodejs-java/fallback-font/) を構成します。

### Linux/Docker コンテナでフォントをシステム全体にインストールせずに使用できますか？

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントを読み込んでください。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

### ライセンスはどうですか—制限なくカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止しているライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。