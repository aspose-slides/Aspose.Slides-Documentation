---
title: C++で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/cpp/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してロードされたプレゼンテーションの元の形式を取得し、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、[Presentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sourceformat/) を呼び出して元の形式を判定します。このメソッドは [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_sourceformat/) でも利用できます。現在のインスタンスが読み込まれた形式に依存した後続の処理が必要な場合に使用します。

ソース形式は、出力ファイルに対して選択する [SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変更されません。

## **ファイルのソース形式を取得する**

この例は既存の `sample.pptx` ファイルが必要です。ファイル名ではなく [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sourceformat/) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変えて他の形式を試すことができます。例は選択されたポリシーを出力します。メッセージはご自身のロジックに置き換えてください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **サポートされている値を確認する**

[SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sourceformat/) 列挙体は以下のプレゼンテーション形式を区別します。下記の拡張子は一般的な拡張子であり、元のファイル名の再構築を意味しません。

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `Pptx` | `.pptx` | Office Open XML プレゼンテーション |
| `Pptm` | `.pptm` | マクロ対応 Office Open XML プレゼンテーション |
| `Pps` | `.pps` | PowerPoint 97–2003 スライドショー |
| `Ppsx` | `.ppsx` | Office Open XML スライドショー |
| `Ppsm` | `.ppsm` | マクロ対応 Office Open XML スライドショー |
| `Pot` | `.pot` | PowerPoint 97–2003 テンプレート |
| `Potx` | `.potx` | Office Open XML テンプレート |
| `Potm` | `.potm` | マクロ対応 Office Open XML テンプレート |
| `Odp` | `.odp` | OpenDocument プレゼンテーション |
| `Otp` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `Fodp` | `.fodp` | Flat XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を取得する**

この例は既存の `sample.pps` ファイルが必要です。バイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT、PPS、POT は同一のバイナリ形式を使用します。ファイルパスで読み込む場合、拡張子はスライドショーかテンプレートかを区別する手掛かりになります。ファイル名が無い場合、レガシーな PPS と POT のコンテンツは `SourceFormat::Ppt` と報告されることがあります。上記の PPS の例は `Ppt` を報告します。

アプリケーションがこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保持してください。拡張子はレガシーサブタイプの有用なヒントですが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出結果を比較する**

ファイル全体のプレゼンテーションオブジェクトモデルをロードする前に情報を取得したい場合は、[PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/getpresentationinfo/) と [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_loadformat/) を使用します。インスタンスがすでに存在する場合は、[Presentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sourceformat/) を使用してください。

この例は `sample.pptx` を使用し、両方のチェックで `Pptx` を出力します。実運用では処理段階に応じた API を選択してください。ロード済みのプレゼンテーションに対してソース形式を取得するために二度目の検査を行う必要はありません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

結果の列挙型は異なります: [LoadFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sourceformat/)。数値をキャストして比較したり、すべての形式が同一の検出結果になると想定したりしないでください。PowerPoint XML はロード前は `LoadFormat::Unknown`、ロード後は `SourceFormat::Xml` と報告されることがあります。

## **ソース形式と出力形式は別々に管理する**

この例は `sample.pptx` を読み込み、`converted.odp` に書き出します。元のインスタンスの保存前後で `Pptx` が出力され、ODP に変換して新たにロードしたインスタンスだけが `Odp` を報告します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

`MakeObject<Presentation>()` でゼロから作成したプレゼンテーションは `SourceFormat::Pptx` を報告します。入力ファイルが無いため、この値は新規作成インスタンスのデフォルトであり、PPTX がロードされたことを示すものではありません。作成かロードかの区別が重要な場合は、別途トラッキングしてください。

## **ソース形式から拡張子へマッピングする**

この例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/sourceformat/) 値を、入力ファイル名を解析せずに一般的な拡張子へマッピングします。未認識の値に対しては拡張子を静かに付与しないフォールバックを行います。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

このマッピングはファイルを変換したり、ストリームロード時に失われたレガシー PPS/POT サブタイプを復元したりするものではありません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を明示的に選択するか、[Save Presentations in Their Original Format](/slides/ja/cpp/save-presentation/#save-presentations-in-their-original-format) に示された変換手順を使用してください。

## **保存と再オープンで形式を検証する**

この自己完結型サンプルはプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込みます。同名の既存ファイルは上書きされます。各出力をパスとメモリストリームの両方で再度開きます。PPTX と ODP はどちらのルートでも保存形式を報告しますが、PPS はパスで読み込むと `Pps`、ファイル名なしでバイト列を読み込むと `Ppt` を報告します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

以下の表は拡張子が一致するプレゼンテーションに対するソース形式識別結果をまとめたものです。

| 保存形式 | ファイルパスからの SourceFormat | 名前なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm`（それぞれ） | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm`（それぞれ） | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm`（それぞれ） | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp`（それぞれ） | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

レガシー PPS/POT コンテンツは名前なしストリームの場合 `Ppt` に正規化されます。この表は形式の識別結果を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**ODP に保存すると、PPTX からロードしたプレゼンテーションのソース形式は変わりますか？**

いいえ。既存インスタンスは依然として `Pptx` を報告します。保存された ODP ファイルからロードしたインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを区別できますか？**

できません。PPT、PPS、POT は同一バイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**プレゼンテーションがすでにロードされている場合、どの API を使用すべきですか？**

[Presentation::get_SourceFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sourceformat/) を使用してください。ロード前の検査が必要な場合は [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/getpresentationinfo/) を使用します。