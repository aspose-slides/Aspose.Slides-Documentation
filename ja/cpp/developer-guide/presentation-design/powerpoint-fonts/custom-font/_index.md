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
- フォント読み込み
- フォント管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してPowerPointスライドのフォントをカスタマイズし、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のあるものに保ちます。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティング システムにインストールせずにプレゼンテーションでカスタム フォントを使用できます。カスタム フォルダーからフォントを読み込んだり、ドキュメント レベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントを読み込んだりできます。

読み込まれたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際（たとえば PDF、画像、その他のサポートされている形式）に使用されます。これにより、異なる環境間でプレゼンテーションの出力が一貫したものになります。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明しています。

レンダリング用にカスタム フォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に保存する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="primary" %}} 
Aspose Slides では、次のメソッドを使用してこれらのフォントを読み込むことができます [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/)：

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **カスタム フォントの読み込み**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF、画像、その他のサポートされている形式などのエクスポート出力に影響し、生成されたドキュメントが環境間で一貫した外観になります。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。
2. 静的メソッド [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) を呼び出して、これらのフォルダーからフォントを読み込みます。
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。
4. フォント キャッシュをクリアするために [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/clearcache/) を呼び出します。

以下のコード例はフォント読み込みプロセスを示しています：

```cpp
// カスタムフォントファイルが含まれるフォルダーを定義します。
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 指定されたフォルダーからカスタムフォントを読み込みます。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加フォルダーを追加しますが、フォントの初期化順序は変更しません。  
フォントは以下の順序で初期化されます：

1. デフォルトのオペレーティング システム フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/) を介してロードされたパス。
{{%/alert %}}

## **カスタム フォント フォルダーの取得**
Aspose.Slides は [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/) を提供し、フォント フォルダーを取得できます。このメソッドは `LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

以下の C++ コードは [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/) メソッドの使用方法を示しています：

``` cpp
// この行はフォントファイルがチェックされるフォルダーを出力します。
// これらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**
Aspose.Slides は [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

以下の C++ コードは [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティの使用方法を示しています：

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //プレゼンテーションで作業する
    //CustomFont1、CustomFont2 および assets\fonts と global\fonts フォルダーとそのサブフォルダー内のフォントはプレゼンテーションで使用可能です
}
```

## **外部でフォントを管理する**
Aspose.Slides は [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfont/) メソッドを提供し、外部フォントをバイト配列に読み込むことができます。

以下の C++ コードはバイト配列へのフォント読み込みプロセスを示しています：

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
はい。接続されたフォントは、すべてのエクスポート形式でレンダラに使用されます。

**カスタム フォントは生成された PPTX に自動的に埋め込まれますか？**  
いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション ファイル内に保持する必要がある場合は、明示的な [embedding features](/slides/ja/cpp/embedded-font/) を使用してください。

**カスタム フォントに特定のグリフがない場合のフォールバック動作を制御できますか？**  
はい。要求されたグリフが欠如している場合に使用されるフォントを正確に定義するために、[font substitution](/slides/ja/cpp/font-substitution/)、[replacement rules](/slides/ja/cpp/font-replacement/)、および [fallback sets](/slides/ja/cpp/fallback-font/) を構成します。

**Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？**  
はい。独自のフォント フォルダーを指定するか、バイト配列からフォントを読み込むことで可能です。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存性がなくなります。

**ライセンスはどうですか—制限なく任意のカスタム フォントを埋め込めますか？**  
フォントのライセンス遵守は利用者の責任です。条件はフォントごとに異なり、埋め込みや商用利用を禁止するライセンスもあります。出力物を配布する前に必ずフォントの EULA を確認してください。