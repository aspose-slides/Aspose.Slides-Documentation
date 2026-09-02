---
title: Java で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/java/custom-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドのフォントをカスタマイズし、どのデバイスでもプレゼンテーションを鮮明で一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティング システムにインストールせずにプレゼンテーションでカスタム フォントを使用できます。カスタム フォルダーからフォントを読み込むことも、ドキュメント レベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供することも、バイナリ データから外部フォントを直接読み込むこともできます。

読み込まれたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます（例: PDF、画像、その他のサポートされている形式）。これにより、異なる環境間でプレゼンテーションの出力を一貫させることができます。本記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明しています。

レンダリング用にカスタム フォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の文字体系ごとに異なるフォント ファミリーを参照できます。これらのマッピングはフォント名を保持しますが、フォント ファイルをインストールしたり読み込んだりはしません。マッピングを管理するには[Script-Specific Theme Fonts](/slides/ja/java/script-specific-font-mappings/)をご覧ください。また、以下の読み込みオプションを使用して、参照されたフォントを一貫したレンダリングのために利用できるようにします。

{{% alert color="info" title="Note" %}}
Aspose Slides は、これらのフォントを [loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用して読み込むことができます:

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳しくは[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。
* OpenType（.otf）フォント。詳しくは[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。
{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF、画像、その他のサポートされている形式などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが含まれるフォルダーを1つ以上指定します。
2. 静的な [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出して、これらのフォルダーからフォントを読み込みます。
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader#clearCache--) を呼び出して、フォント キャッシュをクリアします。

以下のコード例はフォント読み込みプロセスを示しています:

```java
import com.aspose.slides.*;

// カスタムフォントファイルが含まれるフォルダーを定義します。
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// 指定されたフォルダーからカスタムフォントを読み込みます。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。  
フォントは以下の順序で初期化されます:

1. デフォルトのオペレーティング システムのフォントパス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/) を介して読み込まれたパス。
{{%/alert %}}

## **カスタムフォントフォルダーの取得**

Aspose.Slides は、フォントフォルダーを検索できるように [getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォントフォルダーを返します。

以下の Java コードは、[getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています:

```java
import com.aspose.slides.*;

// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**

Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるように、[setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。  

以下の Java コードは、[setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティの使用方法を示しています:

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
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2、そして assets\fonts と global\fonts フォルダーおよびそのサブフォルダーのフォントがプレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントを読み込むために [loadExternalFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

以下の Java コードは、バイト配列によるフォント読み込みプロセスを示しています:

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
        // プレゼンテーションのライフタイム中に外部フォントがロードされます
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **よくある質問**

### カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラによって使用されます。

### カスタムフォントは生成された PPTX に自動的に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーションファイル内に含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/java/embedded-font/)を使用してください。

### カスタムフォントに特定のグリフが欠如している場合、フォールバック動作を制御できますか？

はい。[font substitution](/slides/ja/java/font-substitution/)、[replacement rules](/slides/ja/java/font-replacement/)、[fallback sets](/slides/ja/java/fallback-font/) を設定して、要求されたグリフが存在しない場合に使用するフォントを正確に定義できます。

### Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントを読み込むことで可能です。これにより、コンテナイメージ内のシステムフォントディレクトリへの依存がなくなります。

### ライセンスについて—制限なく任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守はご自身の責任です。条件はフォントごとに異なり、埋め込みや商用使用を禁止するライセンスもあります。出力を配布する前に、必ずフォントの EULA を確認してください。