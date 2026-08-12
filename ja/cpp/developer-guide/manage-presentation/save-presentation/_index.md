---
title: C++ でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/cpp/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進捗
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---
## **概要**

[C++でプレゼンテーションを開く](/slides/ja/cpp/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロから作成する場合でも既存のものを変更する場合でも、終了時に保存したいでしょう。Aspose.Slides for C++ を使用すると、**ファイル**または**ストリーム**に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存**

[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// ここで何らかの処理を行います...

// プレゼンテーションをファイルに保存します。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ストリームにプレゼンテーションを保存**

[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides では、生成されたプレゼンテーションを開くときに PowerPoint が使用する初期ビューを、[ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) クラスで設定できます。[set_LastView](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/set_lastview/) メソッドに [ViewType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewtype/) 列挙体の値を渡して使用します。

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides では、Strict Office Open XML 形式でプレゼンテーションを保存できます。[PptxOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/) クラスを使用し、保存時にその `Conformance` プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// プレゼンテーションを Strict Office Open XML 形式で保存します。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブで、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限があり、ファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限が 2^64 に引き上げられます。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは次のモードで使用できます。

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。デフォルトのモードです。
- `Never` は ZIP64 形式拡張を使用しません。
- `Always` は常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **圧縮レベル付きで Office Open XML 形式でプレゼンテーションを保存**

大きなプレゼンテーションを扱う場合、圧縮レベルを調整してファイルサイズと処理時間のバランスを取ることができます。要件に応じて、処理速度が速い方がよいか、出力ファイルを小さくしたいかを選択できます。

Aspose.Slides は、[PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) メソッドを提供しており、Office Open XML 形式で保存する際に使用する圧縮レベルを指定できます。

利用可能な圧縮レベルは次のとおりです。

- **None**: 圧縮なし。ファイルはそのまま保存されます。
- **Level1**: 圧縮率が最も低く、最速の圧縮。
- **Level2**: **Level1** より少し高い圧縮率で、やや速い圧縮。
- **Level3**: **Level2** より高い圧縮率で、処理時間への影響は中程度。
- **Level4**: **Level3** より高い圧縮率。
- **Level5**: **Level4** より高い圧縮率で、追加の処理時間が必要。
- **Level6**: 標準圧縮で、処理速度とファイルサイズのバランスが良好です。これは *デフォルトの圧縮レベル* です。
- **Level7**: **Level6** より高い圧縮率で、処理は遅くなります。
- **Level8**: **Level7** より高い圧縮率。
- **Level9**: 最大圧縮。最小のファイルサイズになりますが、最も長い処理時間がかかります。

以下の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

この例は、最大圧縮で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) メソッドは、PPTX 形式で保存するときのサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。これはデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX 形式でプレゼンテーションを保存する例です。

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
このオプションを使用すると、PPTX 形式での保存にかかる時間を短縮できます。
{{% /alert %}}

## **保存進捗をパーセンテージで取得**

[IProgressCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isaveoptions/) インターフェイスが公開する `set_ProgressCallback` メソッドと、抽象クラス [SaveOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveoptions/) を介して使用されます。`set_ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprogresscallback/) 実装を割り当てることで、保存進捗をパーセンテージで受け取ることができます。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // ここで進捗のパーセンテージ値を使用します。
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 上記で定義された進捗コールバック クラスです。
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose は、独自 API を使用した無料の PowerPoint 分割アプリ ([PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter)) を提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（増分保存）はサポートされていますか？変更部分だけが書き込まれるようにできますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。増分「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/cpp/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部参照ファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/cpp/manage-hyperlinks/) は保持されます。外部参照ファイル（例: 相対パスでリンクされた動画）は自動的にはコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントメタデータ（作成者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の [ドキュメントプロパティ](/slides/ja/cpp/presentation-properties/) がサポートされており、保存時にファイルへ書き込まれます。