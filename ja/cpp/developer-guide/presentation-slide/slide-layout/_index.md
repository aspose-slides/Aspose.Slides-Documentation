---
title: C++でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/cpp/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッターの可視性
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 コンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加し、未使用レイアウトを削除し、フッターの可視性を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドに一貫した構造が与えられ、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトル スライド**: タイトルとサブタイトルのプレースホルダーを含みます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツのプレースホルダーを含みます。
- **空白**: コンテンツプレースホルダーがなく、すべてのシェイプを手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の3つの関連レベルがあります：

1. A [master slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) は、テーマ、共有書式、背景、および共通オブジェクトを定義します。
2. A [layout slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/) はマスターに属し、プレースホルダーの特定の配置を定義します。
3. A [normal slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) は 1 つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

ノーマルスライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。ノーマルスライド上で直接設定された値は、そのレベルで継承された値を上書きします。ノーマルスライドが作成されると、プレースホルダーシェイプは選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツはノーマルスライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存のノーマルスライドに自動的に対応するプレースホルダーシェイプは追加されません。

この関係には 2 つの重要な結果があります：

- レイアウト上の継承された書式や既存のプレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新される可能性があります。使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドでまだ使用されているレイアウトは削除できません。先に依存スライドを別のレイアウトに割り当てるか、未使用のレイアウトだけを削除してください。

この階層の最上位についての詳細は、[スライドマスター](/slides/ja/cpp/slide-master/)をご参照ください。

1 枚のスライドまたは共有レイアウト上で継承されたロゴや装飾的なマスターシェイプを非表示にするには、[マスターグラフィックの表示制御](/slides/ja/cpp/slide-master/)をご覧ください。この例は同じマスターを使用した 2 つのスライドを比較しています。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスターで **タイトルとコンテンツ** を探します。そのレイアウトが利用できない場合は、意図的に **空白** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトしか含まれない可能性があるために必要です。選択されたレイアウトは、[ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/set_layoutslide/) メソッドを介して最初のノーマルスライドに適用されます。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

スライドのレイアウトを変更しても、スライドに直接追加された普通のシェイプは削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新レイアウト間の対応は変わる可能性があるため、実質的に異なるレイアウト間を切り替える際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しているだけで、作成は行っていません。レイアウトを作成するには、対象マスターのレイアウトコレクション上で [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterlayoutslidecollection/add/) メソッドを呼び出します。

次の例は常に **タイトルとコンテンツ** レイアウトを `Report Title and Content` という名前で新規追加し、それに基づくノーマルスライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドにプレースホルダーを追加**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) メソッドは、レイアウトにプレースホルダーシェイプを追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `ILayoutPlaceholderManager` Method |
| -------------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

次の例は **空白** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、変更されたレイアウトを使用するノーマルスライドを作成します。順序は意図的で、プレースホルダーはノーマルスライド作成前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダーシェイプを生成できます。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存のノーマルスライドには自動的に反映されません。レイアウトの変更はプレゼンテーションのコピー上でテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを使用して、ノーマルスライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

特定のレイアウトを削除するには、まずその [get_HasDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) メソッドまたは [GetDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/getdependingslides/) メソッドで依存スライドの有無を確認します。依存スライドを別のレイアウトに再割り当ててから [ILayoutSlide::Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/remove/) を呼び出してください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでフッターの可視性を制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーを 1 つのレイアウトだけで制御するには、[ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) メソッドを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないといったシナリオに便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **マスターとその子レイアウトでフッターの可視性を制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/get_headerfootermanager/) メソッドを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドはマスターとその依存レイアウトスライド、ノーマルスライドに対して作用し、単一のノーマルスライドだけを対象にするものではありません。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を定義します。ノーマルスライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに対して [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igloballayoutslidecollection/addclone/) メソッドでコピーを追加します。プレゼンテーション間でコピーする場合は、ソースレイアウトで使用されているフォント、テーマ、画像、その他のリソースも確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します。ただし、ローカルで書式やオブジェクトを上書きしている場合は例外です。プレースホルダーのジオメトリや継承されたスタイルは多くのスライドで同時に変化する可能性があります。レイアウトを編集する前に [GetDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/getdependingslides/) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てるか、[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) を使用して未参照レイアウトだけを削除してください。