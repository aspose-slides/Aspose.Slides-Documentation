---
title: C++ でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/cpp/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速なインサイトとスマートなコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容をロードして処理するかどうかを決定する前にプロパティを検査したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/) と [IPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/) を使用した軽量検査、および [IDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーション形式の確認**

ファイルを検査するには、[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成せずに行います。 [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_loadformat/) メソッドは、PPTX、PPT、ODP など検出された形式を報告します。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **軽量プレゼンテーションインベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム用のコンパクトなインベントリが必要になることがあります。このシナリオでは、[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用して [IPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/) オブジェクトを取得し、次に [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出してドキュメント メタデータを読み取ります。この方法では、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクト モデルを走査したりする必要はありません。

[IDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/) が公開する拡張プロパティは、以下のインベントリ値を提供します。

| メソッド | インベントリ値 |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_slides/) | スライドの総数。 |
| [get_HiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | 非表示スライドの数。 |
| [get_Notes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_notes/) | ノートを含むスライドの数。 |
| [get_Paragraphs](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | 利用可能な場合の段落総数。 |
| [get_Words](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_words/) | 単語の総数。 |
| [get_MultimediaClips](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | オーディオ および ビデオ クリップの総数。 |

以下の例は、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_headingpairs/) と [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

各 [IHeadingPair](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iheadingpair/) は、[IHeadingPair::get_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iheadingpair/get_name/) によってグループ名を提供し、[IHeadingPair::get_Count](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iheadingpair/get_count/) によってそのグループ内の項目数を提供します。[IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) はフラットで順序付けされた配列を返すため、各ヘッディング ペアで指定された連続したタイトル数を消費します。

### **保存されたメタデータと形式の制限**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) が返すインベントリ プロパティは、ソース ドキュメントで利用可能なメタデータを反映しています。Aspose.Slides は、この呼び出しのためにプレゼンテーション オブジェクト モデルをロードおよび走査してこれらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなる可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディア数、およびヘッディング ペアとパート タイトルの拡張ドキュメント プロパティを提供します。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は、対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、またはドキュメント作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument のメタデータは、ページ、段落、単語数などの一般的なドキュメント統計を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティにマッピングされません。非表示スライド、ノートスライド、マルチメディア、ヘッディング ペア、パート タイトルのメタデータは利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値や空の配列を、対応するコンテンツが存在しないという権威ある証拠として扱わないでください。

インベントリや事前チェックには軽量メタデータアプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査します。

## **プレゼンテーション プロパティの更新**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成せずに変更することもできます。[IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) で変更を適用し、次に [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

以下の例では、タイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

以下の画像は変更後ドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの変更後ドキュメント プロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、以下の記事をご覧ください。

- [プレゼンテーションのパスワード保護](/slides/ja/cpp/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/cpp/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation::get_FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_fontsmanager/) を使用します。[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getembeddedfonts/) を呼び出して埋め込まれたフォントを取得し、[FontsManager::GetFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getfonts/) を呼び出してプレゼンテーションで使用されているフォントを取得します。これら二つの結果を比較して、レンダリングに必要だが埋め込まれていないフォントを見つけます。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認するには？**

保存されたドキュメント メタデータが十分である場合、[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) と [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) を通じて [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ内で変更されている場合、保存されたメタデータが欠落または古くなることがあり、ライブ値を確認する必要がある場合は、[Presentation::get_Slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slides/) を反復し、各スライドの [Slide::get_Hidden](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/get_hidden/) メソッドを検査してください。

**カスタム スライド サイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation::get_SlideSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slidesize/) を読み取ります。[ISlideSize::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidesize/get_type/)、[ISlideSize::get_Size](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidesize/get_size/)、[ISlideSize::get_Orientation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidesize/get_orientation/) を確認して、現在の設定を期待されるプリセットや寸法と比較します。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/) を見つけ、[ChartData::get_DataSourceType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) を検査します。外部のワークブックの場合は、[ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) を読み取ります。データ ソースのタイプとパスは外部参照を示しますが、対象が利用可能かどうかを確認するには別途リソースチェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

単一の複雑度プロパティは存在しません。[Presentation::get_Slides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slides/) と各スライドの [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_shapes/) コレクションを走査します。形状の数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング指標として使用し、スライドを確実なパフォーマンスボトルネックとみなす前に、代表的なレンダリングまたはエクスポートを測定してください。