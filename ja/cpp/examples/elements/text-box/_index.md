---
title: テキストボックス
type: docs
weight: 40
url: /ja/cpp/examples/elements/text-box/
keywords:
- コード例
- テキストボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でテキストボックスを操作します：テキストの追加、書式設定、配置、折り返し、自動サイズ調整、スタイル設定を行い、PPT、PPTX、ODP プレゼンテーションで C++ を使用します。"
---
Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべての図形にテキストを含めることができますが、典型的なテキスト ボックスは塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、アクセス、削除する方法を説明します。

## **テキスト ボックスの追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストを持つ `AutoShape` にすぎません。作成方法は次のとおりです：

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 矩形シェイプを作成します（デフォルトで塗りつぶしと枠線があり、テキストはありません）。
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // 塗りつぶしと枠線を削除し、典型的なテキストボックスのように見せます。
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // テキストの書式設定を行います。
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // 実際のテキストコンテンツを割り当てます。
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **注:** 非空の `TextFrame` を含む `AutoShape` はすべてテキスト ボックスとして機能します。

## **内容でテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、図形を反復処理し、そのテキストを確認します：

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // 編集可能なテキストを含めることができるのは AutoShape のみです。
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // 一致するテキストボックスで何らかの処理を行います。
            }
        }
    }

    presentation->Dispose();
}
```

## **内容でテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索し、削除します：

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **ヒント:** 反復処理中に変更によるエラーを防ぐため、必ず図形コレクションのコピーを作成してから変更してください。