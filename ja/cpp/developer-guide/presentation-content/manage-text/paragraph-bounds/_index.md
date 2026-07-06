---
title: C++ のプレゼンテーションから段落の境界を取得
linktitle: 段落の境界
type: docs
weight: 43
url: /ja/cpp/paragraph-bounds/
keywords:
- 段落の境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で段落の境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides で段落の境界、サイズ、座標を取得する方法を説明します。[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) から [IParagraph::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getrect/) を使用して段落の矩形を取得する方法、テーブルセルの TextFrame 内の段落座標を取得する方法、そして測定単位、テキスト折り返しが境界に与える影響、ピクセルへの変換、effective な段落書式設定値などの重要な詳細を示します。

## **段落の矩形座標を取得**

[IParagraph::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getrect/) を使用して、段落のバウンディング矩形を取得します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **テーブルセルのTextFrame内の段落のサイズを取得**

テーブルセルの TextFrame 内の [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) のサイズと座標を取得するには、[IParagraph::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getrect/) を使用します。返される矩形はテーブルセルの TextFrame に対して相対的であるため、スライドレベルの座標が必要な場合はテーブルの位置とセルのオフセットを加算してください。

次の例は、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を可視化します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **よくある質問**

**段落の座標はどの単位で測定されますか？**

ポイントで測定されます。1インチは 72 ポイントに相当します。この単位はスライド上のすべての座標と寸法に適用されます。

**単語の折り返しは段落の境界に影響しますか？**

はい。[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) の [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_wraptext/) が有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変化します。

**エクスポートされた画像で段落の座標をピクセルに確実に変換できますか？**

はい。ポイントをピクセルに変換するには、次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「effective」な段落書式設定パラメータを取得するにはどうすればよいですか？**

[effective paragraph formatting data structure](/slides/ja/cpp/shape-effective-properties/) を使用してください。インデント、間隔、折り返し、RTL などの最終的な統合値を返します。