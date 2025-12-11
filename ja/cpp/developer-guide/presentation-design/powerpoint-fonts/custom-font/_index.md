---
title: C++でPowerPointフォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/cpp/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォントのロード
- フォントの管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションを鮮明かつデバイス間で一貫性のあるものに保ちます。"
---

{{% alert color="primary" %}}

Aspose Slides は、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) を使用して以下のフォントをロードできます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。

* OpenType (.otf) フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。

{{% /alert %}}

## **カスタム フォントのロード**

Aspose.Slides を使用すると、プレゼンテーションで使用されるフォントをインストールせずにロードできます。フォントはカスタム ディレクトリからロードされます。

1. [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) クラスのインスタンスを作成し、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) メソッドを呼び出します。
2. レンダリングするプレゼンテーションをロードします。
3. [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) クラスのキャッシュをクリアします。

この C++ コードはフォントのロードプロセスを示しています:
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// フォントパスを設定します
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// カスタムフォントディレクトリのフォントをロードします
FontsLoader::LoadExternalFonts(folders);

// 作業を行い、プレゼンテーション/スライドのレンダリングを実行します
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// フォントキャッシュをクリアします
FontsLoader::ClearCache();
```


## **カスタム フォント フォルダーの取得**
Aspose.Slides は [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) を提供し、フォント フォルダーを検索できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この C++ コードは [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) メソッドの使用方法を示しています:
``` cpp
// この行はフォントファイルがチェックされるフォルダーを出力します。
// これらは Load外部フォント メソッドで追加されたフォルダーとシステムフォントフォルダーです。
auto fontFolders = FontsLoader::GetFontFolders();
```


## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この C++ コードは [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティの使用方法を示しています:
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // プレゼンテーションを操作する
    // CustomFont1、CustomFont2 と assets\fonts および global\fonts フォルダーとそのサブフォルダー内のフォントがプレゼンテーションで使用可能です
}
```


## **フォントを外部で管理する**
Aspose.Slides は [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) メソッドを提供し、外部フォントをバイト配列にロードできます。

この C++ コードはバイト配列へのフォントロードプロセスを示しています:
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


## **よくある質問**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、レンダラーによってすべてのエクスポート形式で使用されます。

**カスタム フォントは生成された PPTX に自動的に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイルに含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/cpp/embedded-font/)を使用する必要があります。

**カスタム フォントに特定の字形がない場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/cpp/font-substitution/)、[置換ルール](/slides/ja/cpp/font-replacement/)、および[フォールバック セット](/slides/ja/cpp/fallback-font/)を構成して、要求された字形が見つからないときに使用するフォントを正確に指定できます。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォントフォルダーを指すか、バイト配列からフォントを読み込むことができます。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存がなくなります。

**ライセンスはどうですか—制限なしで任意のカスタム フォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。