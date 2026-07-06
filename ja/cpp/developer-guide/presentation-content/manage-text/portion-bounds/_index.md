---
title: C++ のプレゼンテーションからテキスト部分の境界を取得する
linktitle: 部分の境界
type: docs
weight: 47
url: /ja/cpp/portion-bounds/
keywords:
- テキスト部分の境界
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides を使用して、PowerPoint プレゼンテーション内のテキスト部分の境界を取得する方法を学びます。"
---
## **概要**

テキスト部分は段落内の特定のテキスト断片を表し、その断片を周囲のコンテンツとは独立して操作できるようにします。Aspose.Slidesでは、テキスト断片の境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより詳細に制御したりする必要がある場合に、部分を使用できます。

この記事では、[IPortion::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/getrect/) を使用して部分の境界矩形を取得する方法を示します。また、[IPortion::GetCoordinates](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/getcoordinates/) を使用して部分の開始位置の座標を取得する方法も示します。さらに、単一のテキスト断片にハイパーリンクを適用する、部分・段落・テキストフレーム・テーマの継承を通じた書式設定の解決方法を理解する、指定されたフォントが利用できない場合の対処など、一般的な部分関連シナリオについてもハイライトしています。

## **テキスト部分の境界を取得**

テキスト部分の境界矩形を取得するには、[IPortion::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/getrect/) を使用します:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **テキスト部分の座標を取得**

テキスト部分の開始位置の座標を取得するには、[IPortion::GetCoordinates](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/getcoordinates/) を使用します:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の部分に[ハイパーリンクを割り当てる](/slides/ja/cpp/manage-hyperlinks/)ことができます。その断片だけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: 部分は何を上書きし、段落またはテキストフレームからは何が取得されますか？**

部分レベルのプロパティが最も高い優先順位を持ちます。プロパティが[IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/)で設定されていない場合、Aspose.Slidesは[IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/)から取得します。そこでも設定されていなければ、Aspose.Slidesは[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/)または[theme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/theme/)のスタイルを使用します。

**部分に指定されたフォントが対象のマシンやサーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/cpp/font-selection-sequence/)が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、および幅が変わるため、正確な位置決めに影響します。

**段落の他の部分とは独立して、部分固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/)レベルでテキストの色、塗りつぶし、透明度を設定でき、隣接する断片とは異なる設定にできます。