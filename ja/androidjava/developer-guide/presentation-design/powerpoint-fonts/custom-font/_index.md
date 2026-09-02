---
title: Android で PowerPoint フォントをカスタマイズする
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/androidjava/custom-font/
keywords:
- フォント
- カスタム フォント
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
description: "Aspose.Slides for Android を Java で使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタム フォントを使用できます。カスタム フォルダーからフォントを読み込んだり、ドキュメント レベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから外部フォントを直接読み込んだりできます。

読み込んだフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントを使用した後にフォント キャッシュをクリアする方法も説明します。

レンダリング用にカスタム フォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーション テーマは、個別の文字体系ごとに異なるフォント ファミリーを参照できます。これらのマッピングはフォント名を保存しますが、フォント ファイルをインストールしたり読み込んだりはしません。[Script-Specific Theme Fonts](/slides/ja/androidjava/script-specific-font-mappings/) を参照してマッピングを管理し、以下の読み込みオプションを使用して参照されたフォントを一貫したレンダリングに利用できるようにしてください。

{{% alert color="info" title="Note" %}}

Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントを読み込むことができます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用するフォントを読み込むことができます。これにより、PDF、画像、その他のサポート形式へのエクスポート結果が環境間で一貫した外観になります。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが格納されているフォルダーを 1 つ以上指定します。  
2. 静的メソッド [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) を呼び出して、これらのフォルダーからフォントを読み込みます。  
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。  
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsLoader#clearCache--) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントの読み込み手順を示しています。

```java
import com.aspose.slides.*;

// カスタムフォントファイルが含まれるフォルダーを定義します。
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

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

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます。

1. デフォルトのオペレーティング システム フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/) を介して読み込まれたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォント フォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

以下の Java コードは [getFontFolders](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています。

```java
import com.aspose.slides.*;

// この行はフォントファイルが検索されるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、[setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

以下の Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) の使用方法を示しています。

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
    // プレゼンテーションを操作する
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です。
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントの外部管理**

Aspose.Slides は、バイト配列データから外部フォントを読み込むための [loadExternalFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

以下の Java コードはバイト配列によるフォント読み込み手順を示しています。

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
        //        プレゼンテーションのライフタイム中に外部フォントがロードされました
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？

はい。接続されたフォントはすべてのエクスポート形式でレンダラーに使用されます。

### カスタム フォントは自動的に生成された PPTX に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的な [埋め込み機能](/slides/ja/androidjava/embedded-font/) を使用してください。

### カスタム フォントに特定の字形が欠けている場合のフォールバック動作を制御できますか？

はい。[フォント置換](/slides/ja/androidjava/font-substitution/) や [置換ルール](/slides/ja/androidjava/font-replacement/) 、[フォールバックセット](/slides/ja/androidjava/fallback-font/) を構成して、要求された字形が存在しない場合に使用するフォントを正確に指定できます。

### Linux/Docker コンテナーでフォントをシステム全体にインストールせずに使用できますか？

はい。独自のフォント フォルダーを指すか、バイト配列からフォントを読み込めば、コンテナー イメージ内のシステム フォント ディレクトリへの依存を排除できます。

### ライセンスについて—制限なくカスタム フォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。ライセンス条件は異なり、埋め込みや商用利用を禁止するものもあります。配布前に必ずフォントの EULA を確認してください。