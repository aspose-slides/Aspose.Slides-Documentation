---
title: C++ でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/cpp/save-presentation/
keywords:
- PowerPoint の保存
- OpenDocument の保存
- プレゼンテーションの保存
- スライドの保存
- PPT の保存
- PPTX の保存
- ODP の保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュー タイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進捗
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX の出力と進捗レポートを構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/cpp/open-presentation/) と、結果を書き込むために [Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドを使用します。Aspose.Slides for C++ は、PowerPoint、OpenDocument、PDF などの形式で、プレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **ファイルへのプレゼンテーション保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) の値を [Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドに渡します。format の値は、Aspose.Slides が作成するファイルの種類を決定します。

次のサンプルは、プレゼンテーションを作成し、PPTX ファイルとして保存します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// プレゼンテーションの内容を追加または変更してください。

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **元の形式でプレゼンテーションを保存**

ファイルやストリームの検出例、新規作成プレゼンテーションの挙動、ソース形式と出力形式の区別については、[Determine the Original Presentation Format](/slides/ja/cpp/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sourceformat/) で元の形式を取得します。取得した [SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sourceformat/) の値を [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/tosaveformat/) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を取得し、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) で変更後のプレゼンテーションを書き出します。

次の完全なサンプルは、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新して、ロード時の形式のまま出力ディレクトリに保存します。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/tosaveformat/) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれ対応するプレゼンテーション保存形式にマップします。これはプレゼンテーションのソース形式のみを対象とし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sourceformat/) の値を渡すと、[ArgumentException](https://reference.aspose.com/slides/ja/cpp/system/argumentexception/) がスローされます。

レガシー PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。拡張子が付いていないストリームからこのようなプレゼンテーションをロードすると、PPS または POT が PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名または形式メタデータを別途保持し、出力ファイル名と形式を決定する際に使用してください。

## **ストリームへのプレゼンテーション保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能な [Stream](https://reference.aspose.com/slides/ja/cpp/system.io/stream/) と [SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) の値を [Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、またはメモリ上で処理する場合に便利です。

次のサンプルは、新しいプレゼンテーションをファイルストリームに保存します。

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **事前定義されたビュー タイプでプレゼンテーションを保存**

PowerPoint が保存されたプレゼンテーションを開く際の初期ビューを指定できます。保存前に [ViewProperties::set_LastView](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/set_lastview/) に [ViewType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewtype/) の値を設定してください。

次のサンプルは、スライドマスタ ビューを初期ビューとして構成します。

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

Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/) のインスタンスを作成し、`Conformance::Iso29500_2008_Strict` を指定して [PptxOptions::set_Conformance](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_conformance/) を呼び出します。そのオプションを [Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドに渡します。

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

標準的な ZIP アーカイブは、各エントリの圧縮・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX は ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張は、適用可能なサイズとエントリ数の制限を引き上げます。

[**PptxOptions::set_Zip64Mode**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) を使用して、Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します。

- `IfNecessary` は、プレゼンテーションが標準 ZIP の制限を超えたときだけ ZIP64 を使用します。既定のモードです。
- `Never` は ZIP64 拡張を書き込みません。
- `Always` は常に ZIP64 拡張を書き込みます。

次のサンプルは、出力プレゼンテーションに対して常に ZIP64 拡張を有効にします。

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode` が `Never` に設定されていて、プレゼンテーションが標準 ZIP の制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを使用して Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) を呼び出すことで、保存速度とファイルサイズのバランスを調整できます。[CompressionLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/compressionlevel/) 列挙体は以下の値を提供します。

- `None` は圧縮せずにデータを保存します。
- `Level1` は最速の圧縮で、圧縮後のサイズが最大になります。
- `Level2` から `Level5` は、保存速度よりも小さい出力を徐々に優先します。
- `Level6` は保存速度とファイルサイズのバランスを取ります。既定のレベルです。
- `Level7` と `Level8` は、さらに小さい出力を優先します。
- `Level9` は最強の圧縮を行い、最も多くの処理時間が必要です。

次のサンプルは、圧縮なしでプレゼンテーションを保存します。

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

次のサンプルは、最大圧縮レベルを使用します。

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **サムネイルを更新せずにプレゼンテーションを保存**

プレゼンテーションを PPTX として保存する際、[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) でドキュメントサムネイルの更新可否を制御します。

- `true` は保存時にサムネイルを再生成します。既定値です。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は新たに生成しません。

次のサンプルは、サムネイルを更新せずにプレゼンテーションを保存します。

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存に要する時間を短縮できます。
{{% /alert %}}

## **保存時の進行状況をパーセンテージで取得**

保存操作の進行状況を監視するには、[IProgressCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprogresscallback/) インターフェイスを実装し、その実装を [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) に渡します。Aspose.Slides はエクスポート中に [IProgressCallback::Reporting](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprogresscallback/reporting/) を呼び出して進捗値を通知します。

次のサンプルは、PDF エクスポートの進行状況をコンソールに出力します。

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose は、Aspose.Slides API で構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これを使用すると、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存（“高速保存”）をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドが同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスは **スレッドセーフではありません** (/slides/ja/cpp/multithreading/)。各インスタンスへのアクセスと保存は、同時に 1 つのスレッドからのみ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/cpp/manage-hyperlinks/) はプレゼンテーション内に残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションは引き続きそれらの場所にアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な [ドキュメント プロパティ](/slides/ja/cpp/presentation-properties/) を設定すれば、Aspose.Slides はそれらを出力ファイルに書き込みます。