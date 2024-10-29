---
title: JavaでのカスタムPowerPointフォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/androidjava/custom-font/
keywords: "フォント, カスタムフォント, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaにおけるPowerPointカスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slidesでは、[loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)メソッドを使用して、これらのフォントを読み込むことができます:

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType)を参照してください。

* OpenType (.otf) フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType)を参照してください。

{{% /alert %}}

## **カスタムフォントの読み込み**

Aspose.Slidesは、フォントをインストールすることなく、プレゼンテーションにレンダリングされたフォントを読み込むことを可能にします。 フォントはカスタムディレクトリから読み込まれます。 

1. [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/)クラスのインスタンスを作成し、[loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader)クラスで[キャッシュをクリア](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--)します。

このJavaコードはフォントの読み込みプロセスを示します:

```java
// フォントを検索するフォルダ
String[] folders = new String[] { externalFontsDir };

// カスタムフォントディレクトリのフォントを読み込み
FontsLoader.loadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドのレンダリングを実行
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // フォントキャッシュをクリア
    FontsLoader.clearCache();
}
```

## **カスタムフォントフォルダの取得**
Aspose.Slidesは、フォントフォルダを見つけるために[getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)メソッドを提供します。このメソッドは、`LoadExternalFonts`メソッドを介して追加されたフォルダとシステムフォントフォルダを返します。

このJavaコードは[getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)の使い方を示します:

```java
// この行はフォントファイルが検索されるフォルダを出力します。
// これらはLoadExternalFontsメソッドを介して追加されたフォルダとシステムフォントフォルダです。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントの指定**
Aspose.Slidesは、プレゼンテーションで使用される外部フォントを指定するために[setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)プロパティを提供します。

このJavaコードは[setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)プロパティの使い方を示します:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // プレゼンテーションで作業を行う
    // CustomFont1、CustomFont2、および assets\fonts & global\fonts フォルダとそのサブフォルダのフォントがプレゼンテーションで使用可能
} finally {
    if (pres != null) pres.dispose();
}
```

## **外部でのフォント管理**

Aspose.Slidesは、バイナリデータから外部フォントを読み込むために[loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)メソッドを提供します。

このJavaコードはバイト配列のフォント読み込みプロセスを示します:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // プレゼンテーションのライフタイム中に読み込まれた外部フォント
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```