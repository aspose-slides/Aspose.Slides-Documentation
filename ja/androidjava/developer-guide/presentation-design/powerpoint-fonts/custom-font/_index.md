---
title: Android で PowerPoint フォントをカスタマイズ
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
description: "Aspose.Slides for Android を Java で使用し、PowerPoint スライドのフォントをカスタマイズして、プレゼンテーションをどのデバイスでも鮮明で一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントを読み込むこと、ドキュメントレベルのフォントソースを介して特定のプレゼンテーションにフォントを提供すること、またはバイナリ データから外部フォントを直接読み込むことができます。

読み込まれたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます。たとえば PDF や画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォントフォルダーの確認方法と、外部フォントを使用した後にフォントキャッシュをクリアする方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="info" %}} 
Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントを読み込むことができます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType（.otf）フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF や画像、その他のサポート形式へのエクスポート出力が環境間で一貫した外観になります。フォントはカスタムディレクトリから読み込まれます。

1. フォント ファイルを含むフォルダーを 1 つ以上指定します。
2. 静的な [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出して、これらのフォルダーからフォントを読み込みます。
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsLoader#clearCache--) を呼び出してフォントキャッシュをクリアします。

以下のコード例はフォント読み込みプロセスを示しています：

```java
import com.aspose.slides.*;

// カスタムフォントファイルを含むフォルダーを定義します。
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、またはその他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了した後にフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="注" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスに追加のフォルダーを加えますが、フォントの初期化順序は変更しません。

フォントは以下の順序で初期化されます：

1. デフォルトのオペレーティングシステム フォント パス。

1. [FontsLoader](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/) を介してロードされたパス。

{{%/alert %}}

## **カスタムフォント フォルダーの取得**

Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォント フォルダーを取得できます。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

この Java コードは [getFontFolders](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています：

```java
import com.aspose.slides.*;

// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドによって追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用されるカスタムフォントの指定**

Aspose.Slides は、[setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) の使用方法を示しています：

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
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントは、プレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントの外部管理**

Aspose.Slides は、[loadExternalFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供し、バイナリ データから外部フォントを読み込むことができます。

この Java コードはバイト配列によるフォント読み込みプロセスを示しています：

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
        // プレゼンテーションの実行中に外部フォントがロードされます
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

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

### カスタムフォントは結果の PPTX に自動的に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは同じではありません。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的に [埋め込み機能](/slides/ja/androidjava/embedded-font/) を使用してください。

### カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？

はい。[フォント置換](/slides/ja/androidjava/font-substitution/)、[置換ルール](/slides/ja/androidjava/font-replacement/)、および [フォールバックセット](/slides/ja/androidjava/fallback-font/) を構成して、要求されたグリフが欠如しているときに使用するフォントを正確に定義できます。

### Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントを読み込んでください。これにより、コンテナ イメージ内のシステムフォント ディレクトリへの依存がなくなります。

### ライセンスはどうですか—制限なしで任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。