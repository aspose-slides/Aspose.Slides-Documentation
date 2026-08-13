---
title: Java で PowerPoint フォントをカスタマイズ
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
description: "Aspose.Slides for Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントをロードしたり、ドキュメント レベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます（例: PDF、画像、その他のサポートされている形式）。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明しています。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="info" %}} 
Aspose Slides は、次のメソッドを使用してこれらのフォントをロードできます：[loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)。

* TrueType (.ttf) と TrueType Collection (.ttc) フォント。TrueType については[TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。OpenType については[OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。
{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF や画像などのエクスポート出力が環境間で一貫したものになります。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが含まれるフォルダーを1つ以上指定します。
2. 静的メソッド [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) を呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader#clearCache--) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントのロード プロセスを示しています：

```java
import com.aspose.slides.*;

// カスタムフォント ファイルが含まれるフォルダーを定義します。
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了したらフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます：

1. デフォルトのオペレーティングシステム フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/) を介してロードされたパス。
{{%/alert %}}

## **カスタムフォント フォルダーの取得**
Aspose.Slides は、フォント フォルダーを取得できるように [getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この Java コードは [getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています：

```java
import com.aspose.slides.*;

// この行はフォントファイルが検索されるフォルダーを出力します。
// これは LoadExternalFonts メソッドで追加されたフォルダーとシステム フォント フォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定できるように [setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

この Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) の使用方法を示しています：

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
    // プレゼンテーションで作業します
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントは、プレゼンテーションで使用できます
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントの外部管理**

Aspose.Slides は、バイナリ データから外部フォントをロードできるように [loadExternalFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この Java コードはバイト配列フォントのロード プロセスを示しています：

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
        // 外部フォントはプレゼンテーションのライフタイム中にロードされます
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### カスタムフォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

### カスタムフォントは自動的に結果の PPTX に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に保持する必要がある場合は、明示的な[埋め込み機能](/slides/ja/java/embedded-font/)を使用する必要があります。

### カスタムフォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？

はい。[フォント置換](/slides/ja/java/font-substitution/)、[置換ルール](/slides/ja/java/font-replacement/)、および[フォールバックセット](/slides/ja/java/fallback-font/)を構成して、要求されたグリフが存在しない場合に使用されるフォントを正確に定義できます。

### Linux/Docker コンテナーでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依頼がなくなります。

### ライセンスはどうなりますか—制限なく任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。