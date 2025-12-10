---
title: C++ を使用したプレゼンテーションでのチャート データテーブルのカスタマイズ
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
description: "Aspose.Slides を使用して C++ で PPT および PPTX のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォント プロパティを設定する**
Aspose.Slides for C++ では、チャート データテーブルのフォント プロパティを変更できます。

1. [プレゼンテーション](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。  
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

はい。データテーブルは[凡例キー](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/)をサポートしており、オンまたはオフにできます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするときにデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)/[画像](/slides/ja/cpp/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードされたすべてのチャートについて、チャートのプロパティを使用してデータテーブルが[表示](/slides/ja/cpp/convert-powerpoint-to-png/)されているかを確認および変更できます。

**ファイル内でデータテーブルが有効になっているチャートを素早く見つけるにはどうすればよいですか？**

データテーブルが[表示](/slides/ja/cpp/convert-powerpoint-to-png/)されているかを示す各チャートのプロパティを確認し、スライドを順に走査して、有効になっているチャートを特定します。