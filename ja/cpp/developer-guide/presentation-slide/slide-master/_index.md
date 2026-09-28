---
title: "C++ でプレゼンテーション スライドマスターを管理する"
linktitle: "スライドマスター"
type: docs
weight: 80
url: /ja/cpp/slide-master/
keywords:
- "スライドマスター"
- "マスタースライド"
- "PPT マスタースライド"
- "複数のマスタースライド"
- "マスタースライドの比較"
- "背景"
- "プレースホルダー"
- "マスタースライドのクローン"
- "マスタースライドのコピー"
- "マスタースライドの複製"
- "未使用のマスタースライド"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ でスライドマスターを管理します：PowerPoint および OpenDocument のプレゼンテーションで、マスタースライドのアクセス、編集、クローン、比較、削除を行います。"
---
## **概要**

**スライドマスター** は、スライドのグループに対する共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、**View** > **Slide Master** を編集することが、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つ一般的な方法です。

Aspose.Slides for C++ は同じモデルをサポートしています。プレゼンテーションには 1 つ以上のマスタースライドを含めることができ、各マスタースライドは複数のレイアウトスライドを含むことができます。通常、ノーマルスライドはマスタースライドを直接参照しません。代わりに、ノーマルスライドはレイアウトスライドを使用し、そのレイアウトスライドはマスタースライドに属しています。

階層は次のとおりです:

1. **スライドマスター** - 共有デザインとテーマを定義します。
1. **レイアウトスライド** - プレースホルダーとレイアウトレベルの書式設定の特定の配置を定義します。
1. **ノーマルスライド** - 実際のプレゼンテーションコンテンツを含み、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、ノーマルスライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは[IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/)インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation::get_Masters](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_masters/)コレクションで取得でき、これは[IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/)を実装しています。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/cpp/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**View** > **Slide Master** からスライドマスタービューを開くことができます。

![PowerPoint の表示タブのスライドマスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`get_Masters()` コレクションを使用してマスタースライドにアクセスします：

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

ノーマルスライドが使用しているマスタースライドは、そのレイアウトを介して取得することもできます。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/) を実装しているため、ノーマルスライドやレイアウトスライドで使用される多くのスライドプロパティを提供します。マスター固有のメンバーは [IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) API ページに記載されています。

一般的に使用されるマスタースライドのメンバーは次のとおりです。

| メンバー | 目的 |
| --- | --- |
| `get_Background()` | マスターレベルのスライド背景を設定します。 |
| `get_Shapes()` | ロゴ、画像フレーム、共有テキストなど、マスターに配置された図形を保持します。 |
| `get_LayoutSlides()` | マスターに属するレイアウトスライドを保持します。 |
| `get_ThemeManager()` | マスターのテーマ API へのアクセスを提供します。 |
| `get_HeaderFooterManager()` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `GetDependingSlides()` | レイアウトを介してマスターに依存しているノーマルスライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドに表示されます。ロゴ、透かし、装飾帯、その他繰り返し使用されるビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

画像フレームの詳細については、[Picture Frame](/slides/ja/cpp/picture-frame/) を参照してください。

## **マスターグラフィックの表示を制御する**

[IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/set_showmastershapes/) を使用して、ロゴや装飾形状などの継承されたマスターグラフィックをマスターから削除せずに非表示にできます。これらのグラフィックを除外すべきスライドには `false` を、表示すべきスライドには `true` を [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/set_showmastershapes/) に渡します。

次の自己完結型の例は、マスターに青い装飾帯を作成し、同じ空白レイアウトを使用する 2 つのスライドを生成します。帯は最初のスライドで表示され、2 番目のスライドで非表示になります。入力プレゼンテーションや画像は必要ありません。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

この例では、新しいプレゼンテーションに付属する **Blank** レイアウトを使用し、最初のスライドの独自プレースホルダーを削除します。

### **設定の適用範囲を選択する**

ノーマルスライドは [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/get_layoutslide/) と [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_masterslide/) を介してマスターを使用します。個々のスライドでプロパティを設定すると、そのスライドだけに影響します。`false` を [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/layoutslide/set_showmastershapes/) に渡すと、その共有レイアウトを使用するスライドのマスターグラフィックが非表示になります（自スライドの設定が `true` でも）。1 つのスライドだけでグラフィックを非表示にしたい場合は、スライドのプロパティを変更し、共有レイアウトは変更しないでください。

この設定はマスタースライド自体の表示制御としてはサポートされていません。マスターでは常に `false` が返され、`true` を設定すると `System::NotSupportedException` がスローされます。代わりにノーマルスライドまたはレイアウトに適用してください。

### **グラフィックと背景を区別する**

| 操作 | 効果 |
| --- | --- |
| マスターグラフィックを非表示にする | 継承されたマスター図形の表示を削除せずに制御します（スライド独自の図形は変更しません）。 |
| スライドの背景塗りつぶしを変更する | 背景色、グラデーション、画像を変更します。マスターグラフィックは別個の図形なので、背景上に表示されたままにできます。[Presentation Background](/slides/ja/cpp/presentation-background/) を参照してください。 |
| マスターから図形を削除する | 共有ソースの図形を削除し、そのマスターを使用するスライドから利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドは、これらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライドマスタービューでプレースホルダーコマンドを使用できます。

![PowerPoint スライドマスター ビューの[プレースホルダーの挿入]コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します：

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

既にマスタースライドに存在するプレースホルダー形状をフォーマットすることもできます。次の例はタイトルプレースホルダーを検索し、線形グラデーション塗りつぶしを適用します。

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![ノーマルスライドが継承するフォーマット済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーとテキストのフォーマットオプションの詳細については、[Set Prompt Text in Placeholder](/slides/ja/cpp/manage-placeholder/) と [Text Formatting](/slides/ja/cpp/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターベースの背景は、上書きしないレイアウトやスライドに継承されます。次の例は、最初のマスタースライドに単色背景色を設定します。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

関連トピックについては、[Presentation Background](/slides/ja/cpp/presentation-background/) と [Presentation Theme](/slides/ja/cpp/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションへクローンする**

[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/) を使用して、マスタースライドを別のプレゼンテーションにコピーします。コピーされたマスターは、宛先プレゼンテーション内のレイアウトやスライドで使用できます。

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

ノーマルスライドとそのマスターを一緒にクローンする必要がある場合は、[Clone Slides](/slides/ja/cpp/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。これは、異なるセクションで異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトのマスターをクローンし、クローンに別の背景を設定し、そのクローンされたマスターの下にレイアウトを作成し、そしてそのレイアウトに基づく新しいスライドを追加します。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **スライドマスターを比較する**

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/) から継承された `Equals` メソッドを使用して比較できます。比較は構造や静的コンテンツ（図形、テキスト、書式、アニメーション、その他のスライド設定）をチェックします。スライド ID のような固有識別子や、現在の日付のような動的プレースホルダーの値は比較しません。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

詳細については、[Compare Presentation Slides](/slides/ja/cpp/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) の `set_LastView` メソッドを使用して、PowerPoint が最初に開くビューを制御します。次の例はプレゼンテーションをスライドマスタービューで開きます。

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ビュー設定の詳細については、[Save Presentation](/slides/ja/cpp/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはやノーマルスライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズを削減し、テンプレートのメンテナンスを簡素化できます。

`get_Masters()` コレクションから未使用マスターを削除するには、[MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ja/cpp/aspose.slides/masterslidecollection/removeunused/) を使用します：

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

また、ローコードの [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドを使用することもできます：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターは、テーマ、背景、共通の図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの特定の配置を定義します。ノーマルスライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることができますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や書式設定はマスタースライドに配置し、コンテンツ用のプレースホルダーはノーマルスライドが使用するレイアウトに置きます。

**使用中のマスタースライドを削除できますか？**

いいえ。依存するスライドがあるマスタースライドは直接安全に削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、使用されていないマスターのみを削除するクリーンアップ方法を使用してください。