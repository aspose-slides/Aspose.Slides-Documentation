---
title: 製品概要
type: docs
weight: 10
url: /ja/jasperreports/product-overview/
description: "Aspose.Slides for JasperReports が何を行うか、対応している JasperReports のバージョンと出力形式、そして 2 つの jar の用途を学びます。"
---
![JasperReports 用 Aspose.Slides](product-overview_1.png)

## **製品の説明**

Aspose.Slides for JasperReports は、Microsoft PowerPoint を使用せずに、JasperReports から PowerPoint プレゼンテーションへレポートをエクスポートします。Java アプリケーションおよび JasperReports Server で使用できます。JasperReports 3.7.2 から 6.16.0 をサポートし、バージョン範囲ごとに別々の jar が用意されています — 詳細は[Installing Aspose.Slides for JasperReports](/slides/ja/jasperreports/installing-aspose-slides-for-jasperreports/)をご覧ください。

埋め込まれたレポートを4つの形式でエクスポートします。レポートの各ページにつき1枚のスライドまたはページが生成されます：

- PPT – PowerPoint 97–2003 プレゼンテーション
- PPTX – PowerPoint プレゼンテーション（Office Open XML）
- PDF – PDF
- HTML – HTML

製品は2つのパーツで構成されています：

- ライブラリ jar は、エクスポーター `ASPptExporter`、`ASPptxExporter`、`ASPdfExporter`、`ASHtmlExporter` を JasperReports Library に追加します。
- サーバー jar は、同じ4つの形式のエクスポート アクションを提供し、JasperReports Server に登録します — 詳細は[Integration with JasperServer](/slides/ja/jasperreports/integration-with-jasperserver/)をご覧ください。

### **出力例**

エクスポーターは JasperReports のエクスポーター クラスを拡張しており、使用方法は同じです。埋め込まれたレポートと出力ファイルを渡し、`exportReport` を呼び出します。レポートを埋め込み PPTX にエクスポートする完全なプログラムについては[Your first export](/slides/ja/jasperreports/#your-first-export)をご覧ください。4つの形式すべてについては[PPT, PPTX, PDF and HTML Export](/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/)をご参照ください。

![ライセンスなしでプレゼンテーションにエクスポートされたレポート（スライド中央に評価ウォーターマークあり）](product-overview_2.png)