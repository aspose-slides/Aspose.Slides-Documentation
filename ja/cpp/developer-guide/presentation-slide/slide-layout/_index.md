---
title: C++ でスライドレイアウトを適用または変更
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
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 つのコンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦書きテキスト
- 縦書きタイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドは一貫した構造となり、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトルスライド**：タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**：タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **空白**：コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、3つの関連レベルがあります。

1. [マスタースライド](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) は、テーマ、共有書式、背景、共通オブジェクトを定義します。
2. [レイアウトスライド](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/) はマスターに属し、プレースホルダーの特定の配置を定義します。
3. [通常スライド](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) はレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

通常スライドはレイアウトからテーマと書式設定を継承し、レイアウトはマスターから継承します。通常スライドに直接設定された値は、そのレベルで継承された値を上書きします。通常スライドが作成されると、プレースホルダーのシェイプは選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツは通常スライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに対応するプレースホルダーシェイプは自動的に追加されません。

この関係には2つの重要な結果があります：

- レイアウト上の継承された書式や既存のプレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。既に使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。まず依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層のトップレベルに関する詳細は、[スライドマスター](/slides/ja/cpp/slide-master/)をご覧ください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスターで **タイトルとコンテンツ** を探します。そのレイアウトが利用できない場合は、意図的に **空白** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択されたレイアウトは、[ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/set_layoutslide/) メソッドを介して最初の通常スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された通常のシェイプは削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウトとの対応が変わる可能性があるため、レイアウトを大幅に変更する際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しており、作成は行っていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterlayoutslidecollection/add/) メソッドを呼び出します。

次の例は、常に `Report Title and Content` という名前の新しい **タイトルとコンテンツ** レイアウトを追加し、それに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが本当に別の再利用可能な構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドにプレースホルダーを追加**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) メソッドは、レイアウトにプレースホルダーシェイプを追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `ILayoutPlaceholderManager` メソッド |
| --------------------------- | ------------------------------------ |
| ![コンテンツ](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![コンテンツ (縦向き)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![テキスト](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![テキスト (縦向き)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![画像](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![チャート](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![テーブル](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![メディア](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![オンライン画像](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

次の例は、**空白** レイアウトが存在することを確認し、4 つのプレースホルダーを追加し、変更されたレイアウトを使用する通常スライドを作成します。順序は意図的で、プレースホルダーは通常スライドが作成される前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダーシェイプを生成できます。

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

結果:

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の通常スライドには自動的に適用されません。プレゼンテーションのコピーでレイアウト変更をテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを使用して、通常スライドが参照していないレイアウトを削除します。このメソッドは、使用中のレイアウトはそのまま残します。

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

特定のレイアウトを削除するには、まずその [get_HasDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) メソッドまたは [GetDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/getdependingslides/) メソッドを使用します。[ILayoutSlide::Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/remove/) を呼び出す前に、依存しているスライドを再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドのフッター表示制御**

レイアウトには独自のフッター、スライド番号、日時プレースホルダーがあります。これらのプレースホルダーを1つのレイアウトで制御するには、[ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) メソッドを使用します。例えば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは表示しないようにしたい場合に便利です。

次の例は、レイアウトを安全に選択し、フッター要素を表示可能にします。

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

## **マスターと子レイアウトのフッター表示制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/get_headerfootermanager/) メソッドを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよび通常スライドに対して動作し、単一の通常スライドだけを対象としません。

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

## **よくある質問**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を1つ定義します。通常スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションにコピーできますか？**

はい。目的地のコレクションに [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igloballayoutslidecollection/addclone/) メソッドでコピーを追加します。プレゼンテーション間でコピーする際は、ソースレイアウトで使用されているフォント、テーマ、画像、その他のリソースも確認してください。

**既に使用中のレイアウトを変更するとどうなりますか？**

依存スライドは、ローカルで変更された書式やオブジェクトがない限り、レイアウトの変更を継承します。そのため、プレースホルダーのジオメトリや継承されたスタイルが多数のスライドで同時に変わる可能性があります。レイアウトを編集する前に、[GetDependingSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/getdependingslides/) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除するとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てするか、[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) を使用して参照されていないレイアウトのみを削除してください。