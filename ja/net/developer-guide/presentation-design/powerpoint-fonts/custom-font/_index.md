---
title: C#でのカスタムPowerPointフォント
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/net/custom-font/
keywords: "フォント, カスタムフォント, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#におけるPowerPointのカスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slidesを使用すると、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを使ってこれらのフォントを読み込むことができます:

* TrueType (.ttf) および TrueType Collection (.ttc)フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType)を参照してください。

* OpenType (.otf)フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType)を参照してください。

{{% /alert %}}

## **カスタムフォントを読み込む**

Aspose.Slidesを使用すると、インストールすることなくプレゼンテーションにレンダリングされるフォントを読み込むことができます。フォントはカスタムディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)クラスのインスタンスを作成し、[LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)クラスのキャッシュをクリアします。

このC#コードはフォント読み込みプロセスを示しています:

``` csharp
// ドキュメントディレクトリへのパス
string dataDir = "C:\\";

// フォントを探すフォルダ
String[] folders = new String[] { dataDir };

// カスタムフォントディレクトリのフォントを読み込み
FontsLoader.LoadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドをレンダリング
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// フォントキャッシュをクリア
FontsLoader.ClearCache();
```

## **カスタムフォントフォルダを取得する**
Aspose.Slidesは[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)メソッドを提供して、フォントフォルダを見つけることができます。このメソッドは、`LoadExternalFonts`メソッドを通じて追加されたフォルダとシステムフォントフォルダを返します。

このC#コードは[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)の使い方を示しています:

```c#
// この行はフォントファイルがチェックされるフォルダを出力します。
// これらはLoadExternalFontsメソッドを介して追加されたフォルダおよびシステムフォントフォルダです。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントを指定する**
Aspose.Slidesは、プレゼンテーションとともに使用する外部フォントを指定するために、[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/)プロパティを提供します。

このC#コードは[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/)プロパティの使い方を示しています:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // プレゼンテーションを操作
    // CustomFont1、CustomFont2、およびassets\fontsおよびglobal\fontsフォルダ及びそのサブフォルダからのフォントがプレゼンテーションに利用可能
}
```

## **外部でフォントを管理する**

Aspose.Slidesは[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)メソッドを提供して、バイナリデータから外部フォントをロードすることを可能にします。

このC#コードはバイト配列のフォントロードプロセスを示しています: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // プレゼンテーションのライフタイム中にロードされた外部フォント
    }
}
finally
{
    FontsLoader.ClearCache();
}
```