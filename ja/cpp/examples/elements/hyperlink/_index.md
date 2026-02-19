---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/cpp/examples/elements/hyperlink/
keywords:
- コード例
- ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides でハイパーリンクを追加および管理します：テキスト、図形、画像へのリンク、PPT、PPTX、ODP のターゲットとアクションを設定し、C++ のサンプルを示します。"
---
この記事では、**Aspose.Slides for C++** を使用して、図形上のハイパーリンクの追加、アクセス、削除、更新方法を示します。

## **ハイパーリンクの追加**

外部ウェブサイトへリンクするハイパーリンクを持つ矩形シェイプを作成します。

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **ハイパーリンクへのアクセス**

シェイプのテキスト部分からハイパーリンク情報を読み取ります。

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **ハイパーリンクの削除**

シェイプのテキストからハイパーリンクをクリアします。

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **ハイパーリンクの更新**

既存のハイパーリンクのターゲットを変更します。`HyperlinkManager` を使用して、すでにハイパーリンクが含まれているテキストを安全に変更し、PowerPoint がハイパーリンクを更新する方法を模倣します。

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // 既存のテキスト内のハイパーリンクを変更する場合は、 
    // プロパティを直接設定するのではなく、HyperlinkManager を使用すべきです。 
    // これは、PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。 
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```