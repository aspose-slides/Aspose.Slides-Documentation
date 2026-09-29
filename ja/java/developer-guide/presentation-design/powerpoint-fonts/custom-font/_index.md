---
title: Java で PowerPoint のフォントをカスタマイズする
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/java/custom-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをあらゆるデバイスで鮮明かつ一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides は、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できるようにします。カスタムフォルダーからフォントをロードしたり、ドキュメントレベルのフォントソースを通じて特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされるときに使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。また、この記事では Aspose.Slides が使用するフォントフォルダーの確認方法と、外部フォントの使用後にフォントキャッシュをクリアする方法についても説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の文字体系ごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を保存しますが、フォントファイルをインストールまたはロードするわけではありません。マッピングの管理については [Script-Specific Theme Fonts](/slides/ja/java/script-specific-font-mappings/) を参照し、以下のロード オプションを使用して参照されたフォントを一貫したレンダリングのために利用可能にしてください。

{{% alert color="info" title="Note" %}}
Aspose Slides は、これらのフォントを [loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してロードできます:

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。
{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポート形式へのエクスポート出力が環境間で一貫した外観になります。フォントはカスタムディレクトリからロードされます。

1. フォント ファイルが格納されているフォルダーを 1 つ以上指定します。
2. 静的な [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#clearCache--) を呼び出してフォントキャッシュをクリアします。

```java
import com.aspose.slides.*;

// カスタムフォント ファイルが含まれるフォルダーを定義します。
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ロードされたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了した後にフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。
フォントは次の順序で初期化されます：

1. デフォルトのオペレーティングシステムのフォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/) を通じてロードされたパス。
{{%/alert %}}

## **カスタムフォント フォルダーの取得**

Aspose.Slides は、フォント フォルダーを検索できるようにするために [getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供しています。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

```java
import com.aspose.slides.*;

// この行はフォント ファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォント フォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定できるようにするために [setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供しています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーおよびそれらのサブフォルダーのフォントはプレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントをロードできるようにするために [loadExternalFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供しています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

### カスタムフォントは結果の PPTX に自動的に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは同じではありません。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的な [embedding features](/slides/ja/java/embedded-font/) を使用する必要があります。

### カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？

はい。[font substitution](/slides/ja/java/font-substitution/)、[replacement rules](/slides/ja/java/font-replacement/)、および [fallback sets](/slides/ja/java/fallback-font/) を構成して、要求されたグリフが存在しない場合に使用するフォントを正確に定義できます。

### Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？

部分的に可能です。Aspose.Slides は、独自のフォルダーやバイト配列からフォントを使用でき、システム全体にインストールする必要はありませんが、Java のフォントサポートにはイメージ内に少なくとも 1 つのインストールされたフォントが必要です。これがない場合、フォントのロードは "Fontconfig head is null, check your fonts or fonts configuration" というエラーで失敗します。詳細は [Deploy Fonts](/slides/ja/java/deploy-fonts/) を参照してください。

### ライセンスについて—制限なく任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。