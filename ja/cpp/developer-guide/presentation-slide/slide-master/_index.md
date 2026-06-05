---
title: C++ でプレゼンテーション スライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 80
url: /ja/cpp/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPTマスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドマスターを管理: PowerPoint および OpenDocument プレゼンテーションでマスタースライドのアクセス、編集、クローン、比較、削除を行う"
---
## **概要**

**スライドマスター**は、スライドのグループに対して共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することが、各スライドで同じ書式設定を繰り返さずにプレゼンテーションの一貫性を保つ標準的な方法です。

Aspose.Slides for C++ も同じモデルをサポートしています。プレゼンテーションは 1 つ以上のマスタースライドを含めることができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常のスライドはマスタースライドを直接参照することはありません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドはマスタースライドに所属します。

階層は次のとおりです。

1. **スライドマスター** – 共有デザインとテーマを定義します。  
1. **レイアウトスライド** – プレースホルダーとレイアウトレベルの書式設定の特定の配置を定義します。  
1. **標準スライド** – 実際のプレゼンテーション コンテンツを含み、1 つのレイアウトスライドを使用します。

![マスター スライド、レイアウト スライド、標準スライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation::get_Masters](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_masters/) コレクションを通じて取得でき、これは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/) を実装しています。

{{% alert color="info" title="継承" %}}

同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方が背景を定義している場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[スライドレイアウトの適用または変更](/slides/ja/cpp/slide-layout/) を参照してください。

{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスター ビューを開くことができます。

![PowerPoint の「表示」タブにあるスライドマスタ コマンド](slide-master_3.jpg)

Aspose.Slides では、`get_Masters()` コレクションを使用してマスタースライドにアクセスします:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

通常のスライドが使用しているマスタースライドは、そのレイアウトから取得できます:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。`[IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/)` を実装しているため、通常のスライドやレイアウトスライドと同様の多数のスライド プロパティを公開します。マスター固有のメンバーは [IMasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/) API ページに一覧されています。

一般的に使用されるマスタースライド メンバーは次のとおりです:

| メンバー | 目的 |
| --- | --- |
| `get_Background()` | マスター レベルのスライド背景を設定します。 |
| `get_Shapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `get_LayoutSlides()` | マスターに属するレイアウトスライドを格納します。 |
| `get_ThemeManager()` | マスター テーマ API へのアクセスを提供します。 |
| `get_HeaderFooterManager()` | マスターおよびその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `GetDependingSlides()` | レイアウトを介してマスターに依存する標準スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用するビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します:

```cpp
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

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、プレースホルダー コマンドはスライドマスター ビューで利用できます。

![PowerPoint スライドマスター ビューの「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します:

```cpp
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

既にマスタースライド上に存在するプレースホルダー図形の書式設定も可能です。次の例はタイトル プレースホルダーを検索し、線形グラデーション塗りつぶしを適用します:

```cpp
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

![標準スライドが継承する書式設定済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーやテキストの書式設定オプションの詳細は、[Set Prompt Text in Placeholder](/slides/ja/cpp/manage-placeholder/) と [Text Formatting](/slides/ja/cpp/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターの背景は、レイアウトやそれを上書きしないスライドに継承されます。次の例は最初のマスタースライドに単色背景色を設定します:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

関連トピックは、[Presentation Background](/slides/ja/cpp/presentation-background/) と [Presentation Theme](/slides/ja/cpp/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

`[IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/addclone/)` を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

マスターとともに標準スライドをクローンする必要がある場合は、[Clone Slides](/slides/ja/cpp/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができ、異なるセクションで異なるブランディング、ページ構造、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理に関する PowerPoint コマンド](slide-master_9.jpg)

次の例は既定のマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加します:

```cpp
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

## **スライドマスターの比較**

マスタースライドは `[IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/)` から継承された `Equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他スライド設定）をチェックします。スライド ID のような固有識別子や、現在の日付などの動的プレースホルダー値は比較対象になりません。

```cpp
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

詳細は [Compare Presentation Slides](/slides/ja/cpp/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルトビューに設定する**

`[ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/)` の `set_LastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例はプレゼンテーションをスライドマスタービューで開きます:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

その他のビュー設定については、[Save Presentation](/slides/ja/cpp/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや標準スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイル サイズが削減され、テンプレートの保守が簡素化されます。

`[MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ja/cpp/aspose.slides/masterslidecollection/removeunused/)` を使用して、`get_Masters()` コレクションから未使用のマスターを削除します:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

低コードの `[Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)` メソッドも利用できます:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキスト スタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。標準スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることはできますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有ビジュアル要素や共有書式はマスタースライドに配置し、コンテンツ用プレースホルダーは標準スライドが使用するレイアウトに置きます。

**使用中のマスタースライドを削除できますか？**

いいえ。依存するスライドがあるマスタースライドは直接削除できません。まず、そのスライドを別のマスターのレイアウトへ移動するか、未使用マスターのみを削除するクリーンアップ手法を使用してください。