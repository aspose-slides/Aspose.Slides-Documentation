---
title: スライド
type: docs
weight: 10
url: /ja/cpp/examples/elements/slide/
keywords:
- コード例
- スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドを制御します：作成、クローン、順序変更、サイズ変更、背景設定、そして PPT、PPTX、ODP プレゼンテーション向けに C++ でトランジションを適用します。"
---
本稿では、**Aspose.Slides for C++** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使ってスライドの追加、取得、クローン作成、順序変更、削除方法を学びます。

以下の各例は簡潔な説明と、C++ のコードスニペットで構成されています。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **注:** 各スライドレイアウトはマスタースライドから派生しており、全体のデザインとプレースホルダー構造を定義します。以下の画像は、PowerPoint でマスタースライドとそれに関連付けられたレイアウトがどのように整理されているかを示しています。

![Master and Layout Relationship](master-layout-slide.png)

## **インデックスでスライドにアクセス**

スライドはインデックスでアクセスでき、また参照からスライドのインデックスを取得することもできます。これは特定のスライドを反復処理したり変更したりする際に便利です。

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 別の空のスライドを追加します。
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // インデックスでスライドにアクセスします。
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // 参照からスライドのインデックスを取得し、インデックスでアクセスします。
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **スライドのクローン作成**

この例では既存のスライドをクローンする方法を示します。クローンされたスライドはスライドコレクションの末尾に自動的に追加されます。

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **スライドの順序変更**

スライドの順序は、スライドを新しいインデックスへ移動させることで変更できます。この例では、クローンしたスライドを最初の位置に移動します。

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **スライドの削除**

スライドを削除するには、対象を参照して `Remove` を呼び出すだけです。この例では、2 番目のスライドを追加した後、元のスライドを削除し、新しいスライドだけが残ります。

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```