---
title: チャート
type: docs
weight: 60
url: /ja/cpp/examples/elements/chart/
keywords:
- コード例
- チャート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でチャートをマスター: 作成、書式設定、データバインド、そして PPT、PPTX、ODP 形式でチャートをエクスポートする C++ のサンプル"
---
**Aspose.Slides for C++** を使用したさまざまなチャートタイプの追加、アクセス、削除、更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 最初のスライドにシンプルなエリアチャートを追加します。
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **チャートへのアクセス**

チャートを作成した後、シェイプコレクションから取得できます。

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // スライド上の最初のチャートにアクセスします。
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **チャートの削除**

以下のコードはスライドからチャートを削除します。

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // チャートを削除します。
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **チャート データの更新**

タイトルなど、チャートのプロパティを変更できます。

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // チャートのタイトルを変更します。
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```