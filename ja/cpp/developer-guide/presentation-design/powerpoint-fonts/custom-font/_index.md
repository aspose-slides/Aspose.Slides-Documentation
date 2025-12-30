---
title: C++ で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/cpp/custom-font/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをシャープでデバイス間でも一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}} 
Aspose Slides は、次のフォントを [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) を使用してロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳しくは [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。
* OpenType (.otf) フォント。詳しくは [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF や画像などのエクスポート出力が環境間で一貫した外観になります。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。
2. 静的な [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出して、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードし、レンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例は、フォントのロード プロセスを示しています:
```cpp
// カスタムフォントファイルが含まれるフォルダーを定義します。
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、または他の形式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader::ClearCache();
```


{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加のフォルダーを設定しますが、フォントの初期化順序は変更しません。フォントは以下の順序で初期化されます。

1. デフォルトの OS フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) を介してロードされたパス。

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides は、フォント フォルダーを検索できるように [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) を提供します。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この C++ コードは、[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) の使用方法を示しています:
``` cpp
// この行はフォントファイルがチェックされるフォルダーを出力します。
// それらはLoadExternalFontsメソッドで追加されたフォルダーとシステムのフォントフォルダーです。
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides は、プレゼンテーションで使用する外部フォントを指定できるように [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを提供します。

この C++ コードは、[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティの使用方法を示しています:
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //プレゼンテーションで作業します
    //CustomFont1、CustomFont2 および assets\fonts と global\fonts フォルダーおよびそのサブフォルダー内のフォントはすべてプレゼンテーションで使用可能です
}
```


## **Manage Fonts Externally**
Aspose.Slides は、外部フォントをバイト配列にロードできるように [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) メソッドを提供します。

この C++ コードは、バイト配列フォントのロード プロセスを示しています:
```cpp
// ドキュメントディレクトリへのパス
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```


## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**Are custom fonts automatically embedded into the resulting PPTX?**

いいえ。レンダリング用にフォントを登録することと、PPTX に埋め込むことは同じではありません。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的な [embedding features](/slides/ja/cpp/embedded-font/) を使用してください。

**Can I control fallback behavior when a custom font lacks certain glyphs?**

はい。[font substitution](/slides/ja/cpp/font-substitution/)、[replacement rules](/slides/ja/cpp/font-replacement/)、[fallback sets](/slides/ja/cpp/fallback-font/) を構成して、要求されたグリフが欠落している場合に使用されるフォントを正確に定義できます。

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナ イメージ内でシステム フォント ディレクトリへの依存がなくなります。

**What about licensing—can I embed any custom font without restrictions?**

フォントのライセンス遵守はご利用者の責任です。ライセンス条件はさまざまで、埋め込みや商用利用を禁止するものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。