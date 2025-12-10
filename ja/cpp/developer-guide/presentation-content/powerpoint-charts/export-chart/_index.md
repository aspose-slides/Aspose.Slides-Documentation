---
title: C++でプレゼンテーションチャートをエクスポート
linktitle: チャートをエクスポート
type: docs
weight: 90
url: /ja/cpp/export-chart/
keywords:
- チャート
- チャートから画像へ
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT と PPTX 形式をサポートし、あらゆるワークフローでのレポート作成を効率化します。"
---

## **チャート画像の取得**
Aspose.Slides for C++ は特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **よくある質問**

**ラスタ画像ではなくベクタ (SVG) としてチャートをエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)を使用して SVG に保存できます。

**エクスポートされたチャートのピクセル単位の正確なサイズを設定するにはどうすればよいですか？**

サイズやスケールを指定できる image-rendering のオーバーロードを使用してください。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートします。

**エクスポート後にラベルや凡例のフォントが崩れている場合、どうすればよいですか？**

[必要なフォントを読み込む](/slides/ja/cpp/custom-font/) を[FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)で使用すると、チャートのレンダリングがメトリックとテキストの外観を保持します。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力ターゲット（[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/) など）および関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[ドキュメント](/slides/ja/cpp/convert-powerpoint/) のエクスポートセクションをご参照ください。