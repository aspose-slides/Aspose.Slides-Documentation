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
- フォントのロード
- フォント管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明かつ一貫性のあるものにします。"
---
## **概要**

Aspose.Slides は、オペレーティングシステムにインストールせずにプレゼンテーションでカスタム フォントを使用できるようにします。カスタム フォルダーからフォントをロードしたり、ドキュメント レベルのフォント ソースを介して特定のプレゼンテーションにフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォントの使用後にフォント キャッシュをクリアする方法も説明します。

レンダリング用にカスタム フォントを登録することは、PPTX ファイルにフォントを埋め込むこととは別です。フォントをプレゼンテーション自体に格納する必要がある場合は、フォント埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の表記体系ごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を保持しますが、フォント ファイルをインストールまたはロードしません。マッピングを管理するには[Script-Specific Theme Fonts](/slides/ja/cpp/script-specific-font-mappings/)をご覧ください。また、以下のロード オプションを使用して参照されたフォントを利用可能にし、一貫したレンダリングを実現します。

{{% alert color="info" title="Note" %}}
Aspose Slides は、これらのフォントを[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/)を使用してロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご覧ください。
* OpenType（.otf）フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご覧ください。
{{% /alert %}}

## **カスタム フォントのロード**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポートされている形式へのエクスポート出力が影響を受け、生成されたドキュメントが環境間で一貫した外観になります。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルを含むフォルダーを 1 つ以上指定します。
2. 静的メソッド[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/)を呼び出し、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードしてレンダリング/エクスポートします。
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/clearcache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォントのロード プロセスを示します。

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// カスタム フォント ファイルが含まれるフォルダーを定義します。
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 指定されたフォルダーからカスタム フォントをロードします。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ロードされたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、またはその他の形式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 作業が完了したらフォントキャッシュをクリアします。
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/)はフォント検索パスに追加のフォルダーを追加しますが、フォントの初期化順序は変更しません。  
フォントは以下の順序で初期化されます：

1. デフォルトのオペレーティングシステム フォント パス。
1. [FontsLoader](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/) を介してロードされたパス。
{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は、フォント フォルダーを検索できるように[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/)を提供します。このメソッドは、`LoadExternalFonts` メソッドで追加されたフォルダーとシステム フォント フォルダーを返します。

この C++ コードは[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/getfontfolders/)メソッドの使用方法を示しています。

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// この行はフォント ファイルがチェックされるフォルダーを出力します。
// それらは LoadExternalFonts メソッドで追加されたフォルダーとシステムのフォント フォルダーです。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、プレゼンテーションで使用される外部フォントを指定できるように[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)プロパティを提供します。

この C++ コードは[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)プロパティの使用方法を示しています。

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
    // プレゼンテーションで作業する
    // CustomFont1、CustomFont2 および assets\fonts と global\fonts フォルダーとそのサブフォルダーからのフォントはすべてプレゼンテーションで使用可能です
}
```

## **フォントの外部管理**

Aspose.Slides は、外部フォントをバイト配列にロードできるように[FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfont/)メソッドを提供します。

この C++ コードはバイト配列フォントのロード プロセスを示しています。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// ドキュメント ディレクトリへのパス
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

### カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

### カスタム フォントは生成された PPTX に自動的に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むことと同じではありません。フォントをプレゼンテーション ファイル内に保持する必要がある場合は、明示的な[埋め込み機能](/slides/ja/cpp/embedded-font/)を使用する必要があります。

### カスタム フォントに特定のグリフがない場合のフォールバック動作を制御できますか？

はい。[font substitution](/slides/ja/cpp/font-substitution/)、[replacement rules](/slides/ja/cpp/font-replacement/)、および[fallback sets](/slides/ja/cpp/fallback-font/)を構成して、要求されたグリフが存在しない場合に使用されるフォントを正確に定義できます。

### Linux/Docker コンテナでシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依頼がなくなります。

### ライセンスはどうですか—制限なく任意のカスタム フォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。条件はさまざまで、埋め込みや商用使用を禁止するライセンスもあります。出力を配布する前に必ずフォントの EULA を確認してください。