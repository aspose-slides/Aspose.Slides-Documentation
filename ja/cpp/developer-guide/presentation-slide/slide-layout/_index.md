---
title: C++ でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/cpp/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーション設計
- スライドデザイン
- 未使用レイアウト
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2コンテンツ
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
description: "Aspose.Slides for C++ でスライドレイアウトを管理・カスタマイズします。レイアウトの種類、プレースホルダーの制御、フッター表示を C++ のコード例を通じて学びます。"
---

## **概要**

スライド レイアウトは、プレースホルダー ボックスの配置とスライド上のコンテンツの書式設定を定義します。利用可能なプレースホルダーとその表示位置を制御します。スライド レイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPoint で最も一般的なスライド レイアウトには次のようなものがあります。

**タイトル スライド レイアウト** – タイトル用のテキスト プレースホルダー 1 つとサブタイトル用のテキスト プレースホルダー 1 つの計 2 つが含まれます。

**タイトルとコンテンツ レイアウト** – 上部に小さなタイトル プレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメイン コンテンツ用の大きなプレースホルダーが配置されています。

**ブランク レイアウト** – プレースホルダーがなく、スライドをゼロからデザインできる完全な自由度があります。

スライド レイアウトはスライド マスターの一部であり、スライド マスターはプレゼンテーション全体のレイアウト スタイルを定義する最上位のスライドです。レイアウト スライドはスライド マスターを介して、タイプ、名前、または一意の ID でアクセスおよび変更できます。あるいは、プレゼンテーション内で特定のレイアウト スライドを直接編集することも可能です。

Aspose.Slides for Android でスライド レイアウトを操作するには、次のものを使用できます。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスの下にある [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) や [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) などのメソッド
- [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/)、[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作方法の詳細については、[Slide Master](/slides/ja/cpp/slide-master/) 記事をご覧ください。
{{% /alert %}}

## **プレゼンテーションへのスライド レイアウトの追加**

スライドの外観と構造をカスタマイズするために、プレゼンテーションに新しいレイアウト スライドを追加する必要がある場合があります。Aspose.Slides for Android を使用すると、特定のレイアウトが既に存在するかどうかを確認し、必要に応じて新しいレイアウトを追加し、そのレイアウトに基づいてスライドを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/) にアクセスします。
1. 希望するレイアウト スライドがコレクションに既に存在するか確認します。存在しない場合は必要なレイアウト スライドを追加します。
1. 新しいレイアウト スライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

以下の C++ コードは、PowerPoint プレゼンテーションにスライド レイアウトを追加する方法を示しています。
```cpp
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // プレゼンテーションにすべてのレイアウトタイプが含まれていない状況です。
    // プレゼンテーション ファイルには Blank と Custom のレイアウト タイプのみが含まれています。
    // ただし、カスタムタイプのレイアウトスライドは認識可能な名前を持つ場合があります、
    // 例えば "Title"、"Title and Content" などで、レイアウトスライドの選択に使用できます。
    // プレースホルダー シェイプ タイプのセットに頼ることもできます。
    // 例えば、Title スライドは Title プレースホルダー タイプだけを持つべきです、など。
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// 追加したレイアウトスライドを使用して空のスライドを追加します。
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **未使用のレイアウト スライドの削除**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) クラスの [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを提供し、不要な未使用レイアウト スライドを削除できます。

以下の C++ コードは、PowerPoint プレゼンテーションからレイアウト スライドを削除する方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **スライド レイアウトへのプレースホルダーの追加**

Aspose.Slides は、[ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) メソッドを提供し、レイアウト スライドに新しいプレースホルダーを追加できます。

このマネージャーには、次のプレースホルダー タイプ用のメソッドが含まれています。

| PowerPoint プレースホルダー              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![コンテンツ](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![コンテンツ (縦向き)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![テキスト](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![テキスト (縦向き)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![画像](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![チャート](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![表](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![メディア](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![オンライン画像](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

以下の C++ コードは、ブランク レイアウト スライドに新しいプレースホルダー シェイプを追加する方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>();

// Blank レイアウトスライドを取得します。
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// レイアウトスライドのプレースホルダーマネージャーを取得します。
auto placeholderManager = layout->get_PlaceholderManager();

// Blank レイアウトスライドにさまざまなプレースホルダーを追加します。
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


結果:

![The placeholders on the layout slide](add_placeholders.png)

## **レイアウト スライドのフッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタム テキストなどのフッター要素は、スライド レイアウトに応じて表示・非表示を切り替えることができます。Aspose.Slides for Android を使用すると、これらのフッター プレースホルダーの表示状態を制御できます。特定のレイアウトでフッター情報を表示し、他のレイアウトではシンプルに保ちたい場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでレイアウト スライドの参照を取得します。
1. スライド フッター プレースホルダーを表示に設定します。
1. スライド 番号 プレースホルダーを表示に設定します。
1. 日付/時刻 プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の C++ コードは、スライド フッターの表示状態を設定し、関連タスクを実行する方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **スライドの子フッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタム テキストなどのフッター要素はマスタースライド レベルで制御でき、すべてのレイアウト スライドに一貫した表示を確保できます。Aspose.Slides for Android は、マスタースライド上でこれらフッター プレースホルダーの表示状態と内容を設定し、その設定をすべての子レイアウト スライドに伝播させることができます。このアプローチにより、プレゼンテーション全体で統一されたフッター情報が保たれます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでマスタースライドの参照を取得します。
1. マスターとすべての子フッター プレースホルダーを表示に設定します。
1. マスターとすべての子スライド番号 プレースホルダーを表示に設定します。
1. マスターとすべての子日付/時刻 プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の C++ コードは、この操作を実演しています。
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**マスタースライドとレイアウト スライドの違いは何ですか？**

マスタースライドは全体のテーマと既定の書式設定を定義し、レイアウト スライドは異なるコンテンツ タイプ向けにプレースホルダーの具体的な配置を定義します。

**レイアウト スライドを別のプレゼンテーションへコピーできますか？**

はい、[get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) メソッドで取得できるレイアウト スライド コレクションからレイアウト スライドをクローンし、`AddClone` メソッドを使用して別のプレゼンテーションに挿入できます。

**使用中のスライドが参照しているレイアウト スライドを削除するとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドが参照しているレイアウト スライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) をスローします。この問題を回避するには、使用されていないレイアウト スライドのみを安全に削除できる [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) を使用してください。