---
title: C++ でプレゼンテーションのチャートをエクスポート
linktitle: チャートのエクスポート
type: docs
weight: 90
url: /ja/cpp/export-chart/
keywords:
- チャート
- チャートを画像に変換
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT および PPTX 形式をサポートし、任意のワークフローへのレポート作成を効率化します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション内のチャートを画像としてエクスポートできます。この記事では、チャートから画像を取得して保存する方法を示します。PowerPoint プレゼンテーションの外部でチャートのビジュアルを再利用する必要がある場合に便利です。

## **チャート画像の取得**
Aspose.Slides for C++ は、特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**チャートをラスタ画像ではなくベクタ (SVG) としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/writeassvg/) を使用して SVG に保存できます。

**エクスポートされたチャートのサイズをピクセル単位で正確に設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image-rendering のオーバーロードを使用します。ライブラリは指定された寸法／スケールでオブジェクトをレンダリングすることをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

[必要なフォントを読み込む](/slides/ja/cpp/custom-font/) を [FontsLoader](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/) で行い、チャートのレンダリングがメトリックとテキスト外観を保持するようにします。

**エクスポートは PowerPoint のテーマ、スタイル、効果を尊重しますか？**

はい。Aspose.Slides のレンダラはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、効果）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力先（[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/) など）や関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/)/[documentation](/slides/ja/cpp/convert-powerpoint/) のエクスポートセクションをご覧ください。