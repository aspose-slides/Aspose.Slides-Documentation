---
title: C++ で PowerPoint フォントをカスタマイズ
linktitle: カスタム フォント
type: docs
weight: 20
url: /ja/cpp/custom-font/
keywords:
- フォント
- カスタム フォント
- 外部フォント
- フォントをロード
- フォントを管理
- フォント フォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドのフォントをカスタマイズし、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、OS にインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントを読み込んだり、ドキュメントレベルのフォント ソースで特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントを読み込んだりできます。

読み込まれたフォントは、プレゼンテーションが PDF や画像、その他のサポートされている形式にレンダリングまたはエクスポートされる際に使用されます。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション自体に保存する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

{{% alert color="info" %}} 

Aspose Slides は、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) を使用して次のフォントを読み込むことができます。

* TrueType (.ttf) および TrueType Collection (.ttc) フォント。詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType (.otf) フォント。詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタムフォントのロード**

Aspose.Slides を使用すると、システムにインストールせずにプレゼンテーションで使用するフォントをロードできます。これにより、PDF、画像、その他のサポート形式へのエクスポート出力が環境間で一貫した見た目になります。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが格納されているフォルダーを 1 つ以上指定します。  
2. 静的メソッド [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) を呼び出して、これらのフォルダーからフォントをロードします。  
3. プレゼンテーションをロードし、レンダリング/エクスポートします。  
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例は、フォントのロード手順を示しています。

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// カスタムフォントファイルが格納されているフォルダーを定義します。
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ロードされたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、またはその他の形式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader::ClearCache();
```

{{% alert color="info" title="注" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) はフォント検索パスに追加フォルダーを設定しますが、フォントの初期化順序は変更しません。  
フォントは次の順序で初期化されます。

1. デフォルトの OS フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/) でロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は、[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/) を提供して、フォント フォルダーを取得できるようにします。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステムのフォント フォルダーを返します。

この C++ コードは、[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/) メソッドの使用方法を示しています。

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// この行はフォントファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォントフォルダーです。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

この C++ コードは、[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) プロパティの使用例を示しています。

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // プレゼンテーションを操作します
    // CustomFont1、CustomFont2 と assets\fonts および global\fonts フォルダーとそのサブフォルダー内のフォントがプレゼンテーションで利用可能です
}
```

## **フォントの外部管理**

Aspose.Slides は、[FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfont/) メソッドを提供し、外部フォントをバイト配列としてロードできます。

この C++ コードは、バイト配列でフォントをロードする手順を示しています。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

### カスタムフォントは自動的に生成された PPTX に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。フォントをプレゼンテーション文件内に保持したい場合は、明示的な [埋め込み機能](/slides/ja/cpp/embedded-font/) を使用してください。

### カスタムフォントに特定のグリフがない場合のフォールバック 動作を制御できますか？

はい。[フォント置換](/slides/ja/cpp/font-substitution/)、[置換ルール](/slides/ja/cpp/font-replacement/)、[フォールバック セット](/slides/ja/cpp/fallback-font/) を構成して、要求されたグリフが欠落しているときに使用するフォントを正確に定義できます。

### Linux/Docker コンテナーでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードします。これにより、コンテナー イメージ内のシステム フォント ディレクトリへの依存がなくなります。

### ライセンスについて—制限なしに任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。ライセンス条件は製品によって異なり、埋め込みや商用利用を禁止しているものもあります。出力を配布する前に必ずフォントの EULA を確認してください。