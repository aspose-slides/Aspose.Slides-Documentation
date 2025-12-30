---
title: JavaでPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/java/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントをロード
- フォントを管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 

Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用して次のフォントを読み込むことができます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType (.otf) フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF、画像、その他のサポート形式などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタムディレクトリから読み込まれます。

1. フォントファイルを含むフォルダーを 1 つ以上指定します。  
2. 静的な [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出して、これらのフォルダーからフォントを読み込みます。  
3. プレゼンテーションをロードし、レンダリング/エクスポートします。  
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) を呼び出してフォントキャッシュをクリアします。

以下のコード例はフォント読み込みの手順を示しています:
```java
// カスタムフォントファイルを含むフォルダーを定義します。
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 指定されたフォルダーからカスタムフォントを読み込みます。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、または他の形式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 作業が完了した後にフォントキャッシュをクリアします。
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます。

1. デフォルトのオペレーティングシステムのフォントパス。  
1. [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) でロードされたパス。

{{%/alert %}}

## **カスタムフォントフォルダーの取得**
Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供し、フォントフォルダーの取得を可能にします。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォントフォルダーを返します。

以下の Java コードは [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています:
```java
// この行はフォントファイルが検索されるフォルダーを出力します。
// それらは LoadExternalFonts メソッドを通じて追加されたフォルダーとシステムフォントフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できる [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

以下の Java コードは [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) の使用例です:
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です
} finally {
    if (pres != null) pres.dispose();
}
```


## **フォントを外部で管理する**

Aspose.Slides は、バイナリ データから外部フォントを読み込むための [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

以下の Java コードはバイト配列によるフォント読み込みの手順を示しています:
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


## **よくある質問**

**カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラーによって使用されます。

**カスタムフォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。フォントをレンダリング用に登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に保持したい場合は、明示的な[埋め込み機能](/slides/ja/java/embedded-font/) を使用する必要があります。

**カスタムフォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/java/font-substitution/)、[置換ルール](/slides/ja/java/font-replacement/)、および[フォールバックセット](/slides/ja/java/fallback-font/) を設定して、要求されたグリフが欠落している場合に使用されるフォントを正確に定義できます。

**Linux/Docker コンテナー内でフォントをインストールせずに使用できますか？**

はい。独自のフォントフォルダーを指定するか、バイト配列からフォントをロードしてください。これにより、コンテナー イメージ内のシステムフォント ディレクトリへの依存がなくなります。

**ライセンスに関して—カスタムフォントを制限なく埋め込むことは可能ですか？**

フォントのライセンス遵守はユーザーの責任です。ライセンス条件は異なり、埋め込みや商用利用を禁じているものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。