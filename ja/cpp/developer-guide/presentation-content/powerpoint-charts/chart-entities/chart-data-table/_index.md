---
title: C++ を使用したプレゼンテーションのチャート データ テーブルのカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/cpp/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PPT および PPTX のチャート データ テーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---
## **概要**

この記事では、Aspose.Slides のチャート データ テーブルの操作方法を説明します。チャートのデータ テーブルを表示し、太字スタイルやフォントの高さなどのフォント プロパティを設定してテキストの書式設定をカスタマイズする方法を示します。この例では、プレゼンテーションの読み込み、チャートの追加、チャート データ テーブルの有効化、フォント設定の適用、そして更新されたプレゼンテーションの保存を行います。

## **チャート データ テーブルのフォント プロパティの設定**
Aspose.Slides for C++ では、チャート データ テーブルのフォント プロパティを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャート テーブルを設定します。
4. フォントの高さを設定します。
5. 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **よくある質問**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは [legend keys](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/datatable/set_showlegendkey/) をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際にデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部として描画するため、エクスポートされた [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)/[image](/slides/ja/cpp/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについては、チャートのプロパティを使用してデータテーブルが [表示されているか](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/set_hasdatatable/) を確認および変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく確認するにはどうすればよいですか？**

各チャートのデータテーブルが [表示されているか](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/get_hasdatatable/) を示すプロパティを確認し、スライドを走査して有効になっているチャートを特定します。