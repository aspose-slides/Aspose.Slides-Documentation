---
title: レイアウトスライド
type: docs
weight: 20
url: /ja/cpp/examples/elements/layout-slide/
keywords:
- コード例
- レイアウトスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のマスターレイアウトスライド: スライドレイアウト、プレースホルダー、マスターを選択、適用、カスタマイズし、PPT、PPTX、ODP プレゼンテーション向けの C++ サンプルを提供します。"
---
この記事では、Aspose.Slides for C++ の **Layout Slides** の使い方を示します。レイアウトスライドは、通常のスライドが継承するデザインと書式を定義します。レイアウトスライドを追加、アクセス、クローン作成、削除でき、未使用のスライドをクリーンアップしてプレゼンテーションのサイズを削減することもできます。

## **レイアウトスライドの追加**

カスタムレイアウトスライドを作成して、再利用可能な書式を定義できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキストボックスを追加することができます。

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // 空白のレイアウトタイプとカスタム名でレイアウトスライドを作成します。
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // レイアウトスライドにテキストボックスを追加します。
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // このレイアウトを使用してスライドを2枚追加します。両方ともレイアウトからテキストを継承します。
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡**Note 1:** レイアウトスライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡**Note 2:** レイアウトスライドに図形やテキストを追加すると、そのレイアウトに基づくすべてのスライドが自動的にこの共有コンテンツを表示します。下のスクリーンショットは、同じレイアウトスライドからテキストボックスを継承した2枚のスライドを示しています。

![レイアウトコンテンツを継承するスライド](layout-slide-result.png)

## **レイアウトスライドへのアクセス**

レイアウトスライドはインデックスまたはレイアウトタイプ（例: `Blank`、`Title`、`SectionHeader` など）でアクセスできます。

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // インデックスでレイアウトスライドにアクセスします。
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // タイプでレイアウトスライドにアクセスします。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **レイアウトスライドの削除**

不要になった特定のレイアウトスライドを削除できます。

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // タイプでレイアウトスライドを取得し、削除します。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **未使用のレイアウトスライドの削除**

プレゼンテーションのサイズを削減するために、通常のスライドで使用されていないレイアウトスライドを削除したい場合があります。

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 参照されていないすべてのレイアウトスライドを自動的に削除します。
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **レイアウトスライドのクローン作成**

`AddClone` メソッドを使用してレイアウトスライドを複製できます。

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // タイプで既存のレイアウトスライドを取得します。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // レイアウトスライドをコレクションの末尾にクローンします。
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅**Summary:** レイアウトスライドは、スライド全体の一貫した書式設定を管理する強力なツールです。Aspose.Slides は、レイアウトスライドの作成、管理、最適化を完全にコントロールできます。