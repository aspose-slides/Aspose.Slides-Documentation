---
title: C++ におけるカスタムフォント
type: docs
weight: 20
url: /ja/cpp/custom-font/
keywords: "フォント, カスタムフォント, PowerPoint プレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++ における PowerPoint カスタムフォント"
---

{{% alert color="primary" %}} 

Aspose Slides では、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) を使用してこれらのフォントを読み込むことができます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。 [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。 [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントを読み込む**

Aspose.Slides を使用すると、インストールすることなくプレゼンテーションでレンダリングされるフォントを読み込むことができます。フォントはカスタムディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出します。
2. レンダリングされるプレゼンテーションを読み込みます。
3. [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) クラスのキャッシュをクリアします。

この C++ コードはフォント読み込みプロセスを示しています：

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// フォントパスを設定
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// カスタムフォントディレクトリのフォントを読み込む
FontsLoader::LoadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドをレンダリング
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// フォントキャッシュをクリア
FontsLoader::ClearCache();
```

## **カスタムフォントフォルダを取得する**
Aspose.Slides では、フォントフォルダを見つけるために [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) を提供しています。このメソッドは、`LoadExternalFonts` メソッドを介して追加されたフォルダとシステムフォントフォルダを返します。

この C++ コードは [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) メソッドを使用する方法を示しています：

``` cpp
// この行はフォントファイルが検索されるフォルダを出力します。
// これらは LoadExternalFonts メソッドを介して追加されたフォルダとシステムフォントフォルダです。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **プレゼンテーションで使用するカスタムフォントを指定する**
Aspose.Slides では、プレゼンテーションに使用される外部フォントを指定するために [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを提供しています。

この C++ コードは [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを使用する方法を示しています：

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2 および assets\fonts & global\fonts フォルダおよびそのサブフォルダのフォントがプレゼンテーションで使用可能
}
```

## **フォントを外部で管理する**
Aspose.Slides は、バイト配列に外部フォントを読み込むことを可能にする [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) メソッドを提供しています。

この C++ コードはバイト配列フォント読み込みプロセスを示しています：

```cpp
// ドキュメントディレクトリのパス
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```