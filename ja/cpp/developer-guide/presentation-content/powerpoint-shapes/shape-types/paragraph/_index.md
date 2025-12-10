---
title: C++ のプレゼンテーションから段落の境界を取得
linktitle: 段落
type: docs
weight: 60
url: /ja/cpp/paragraph/
keywords:
- 段落の境界
- テキストポーションの境界
- 段落座標
- ポーション座標
- 段落サイズ
- テキストポーションサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で段落およびテキストポーションの境界を取得し、PowerPoint プレゼンテーションでのテキスト配置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落とポーションの座標取得**
Aspose.Slides for C++ を使用すると、開発者はテキストフレームの段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内のポーションの座標も取得できます。本トピックでは、例を用いて段落の矩形座標と段落内のポーションの位置を取得する方法を示します。

## **段落の矩形座標を取得**
新しいメソッド **GetRect()** が追加されました。これにより、段落の境界矩形を取得できます。
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **テーブルセルのテキストフレーム内の段落とポーションのサイズを取得**

テーブルセルのテキストフレーム内で[Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)または[Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph)のサイズと座標を取得するには、[IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9)と[IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t)メソッドを使用できます。

このサンプルコードは上記の操作を示しています。
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **FAQ**

**段落およびテキストポーションの座標はどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**ワードラッピングは段落の境界に影響しますか？**

はい。[wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)が[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)で有効になっている場合、テキストは領域幅に合わせて折り返され、段落の実際の境界が変わります。

**エクスポートされた画像で段落の座標をピクセルに正確に変換できますか？**

はい。ポイントをピクセルに変換するには次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータはどのように取得しますか？**

[effective paragraph formatting data structure](/slides/ja/cpp/shape-effective-properties/) を使用します。インデント、間隔、ラップ、RTL などの最終的な統合値が返されます。