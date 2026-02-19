---
title: マスタースライド
type: docs
weight: 30
url: /ja/cpp/examples/elements/master-slide/
keywords:
- コード例
- マスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のマスタースライド例を確認しましょう。PPT、PPTX、ODP でマスター、プレースホルダー、テーマを作成、編集、スタイル設定する方法を、分かりやすい C++ コードで紹介します。"
---
マスタースライドは PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド**は背景、ロゴ、テキストの書式設定などの共通デザイン要素を定義します。**レイアウトスライド**はマスタースライドから継承し、**ノーマルスライド**はレイアウトスライドから継承します。

この記事では、Aspose.Slides for C++ を使用してマスタースライドの作成、変更、管理方法を示します。

## **マスタースライドの追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。その後、レイアウトの継承を通じてすべてのスライドに会社名バナーを追加します。

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // デフォルトのマスタースライドをクローンします。
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // マスタースライドの上部に会社名バナーを追加します。
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // 新しいマスタースライドをレイアウトスライドに割り当てます。
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // プレゼンテーションの最初のスライドにレイアウトスライドを割り当てます。
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **注 1:** マスタースライドは、すべてのスライドに対して一貫したブランディングや共有デザイン要素を適用する方法を提供します。マスターに加えた変更は、依存するレイアウトスライドやノーマルスライドに自動的に反映されます。  
> 
> 💡 **注 2:** マスタースライドに追加された図形や書式設定はレイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべてのノーマルスライドにも継承されます。  
>  以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的にレンダリングされる様子を示しています。

![マスター継承例](master-slide-banner.png)

## **マスタースライドへのアクセス**

プレゼンテーションのマスターコレクションを使用してマスタースライドにアクセスできます。以下に取得方法と操作方法を示します。

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // 背景のタイプを変更します。
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **マスタースライドの削除**

マスタースライドはインデックスまたは参照によって削除できます。

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // インデックスでマスタースライドを削除します。
    presentation->get_Masters()->RemoveAt(0);

    // 参照でマスタースライドを削除します。
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **未使用マスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 未使用のマスタースライドをすべて削除します（保持としてマークされたものも含む）。
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```