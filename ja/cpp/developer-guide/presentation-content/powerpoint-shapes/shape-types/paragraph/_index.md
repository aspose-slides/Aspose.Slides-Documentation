---
title: 段落
type: docs
weight: 60
url: /ja/cpp/paragraph/
---

## **TextFrame内の段落およびポーションの座標を取得する**
Aspose.Slides for C++を使用することで、開発者はTextFrameの段落コレクション内の段落の矩形座標を取得できるようになりました。また、段落内のポーションのコレクション内の座標を取得することも可能です。本トピックでは、段落の矩形座標と段落内のポーションの位置を取得する方法を示す例を用いて説明します。

## **段落の矩形座標を取得する**
新しいメソッド**GetRect()**が追加されました。このメソッドを使用すると、段落の境界矩形を取得できます。

``` cpp
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **テーブルセルテキストフレーム内の段落およびポーションのサイズを取得する** ##

テーブルセルのテキストフレーム内で[ポーション](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)または[段落](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph)のサイズと座標を取得するには、[IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9)および[IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t)メソッドを使用できます。

このサンプルコードは、説明された操作を示しています：

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