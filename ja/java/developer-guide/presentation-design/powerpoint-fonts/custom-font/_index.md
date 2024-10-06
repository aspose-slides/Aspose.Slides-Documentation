---
title: Java におけるカスタム PowerPoint フォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/java/custom-font/
keywords: "フォント, カスタムフォント, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "Java における PowerPoint カスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slides は、[loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを使用してこれらのフォントをロードできます：

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides は、フォントをインストールすることなく、プレゼンテーションで描画されるフォントをロードできます。フォントはカスタムディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) メソッドを呼び出します。
2. 描画されるプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) クラスで [キャッシュをクリア](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) します。

この Java コードはフォントのロードプロセスを示しています：

```java
// フォントを探すフォルダ
String[] folders = new String[] { externalFontsDir };

// カスタムフォントディレクトリのフォントをロード
FontsLoader.loadExternalFonts(folders);

// いくつかの作業を行い、プレゼンテーション/スライドをレンダリングします
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // フォントキャッシュをクリア
    FontsLoader.clearCache();
}
```

## **カスタムフォントフォルダーを取得**

Aspose.Slides は、フォントフォルダーを見つけるための [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) メソッドを提供します。このメソッドは、`LoadExternalFonts` メソッドを通じて追加されたフォルダーとシステムフォントフォルダーを返します。

この Java コードは、[getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) の使用方法を示しています：

```java
// この行はフォントファイルが検索されるフォルダを出力します。
// これは LoadExternalFonts メソッドおよびシステムフォントフォルダーを通じて追加されたフォルダーです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントを指定する**

Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定するための [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティを提供します。

この Java コードは、[setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) プロパティの使用方法を示しています：

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業します
    // CustomFont1、CustomFont2、assets\fonts および global\fonts フォルダーとそのサブフォルダーからのフォントがプレゼンテーションで利用可能です
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォントを外部で管理する**

Aspose.Slides は、バイナリデータから外部フォントをロードするための [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) メソッドを提供します。

この Java コードは、バイト配列フォントのロードプロセスを示しています：

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // プレゼンテーションのライフタイム中にロードされた外部フォント
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```