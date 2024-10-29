---
title: チャートデータテーブル
type: docs
url: /ja/cpp/chart-data-table/
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for C++では、チャートデータテーブルのフォントプロパティを変更できます。 

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```