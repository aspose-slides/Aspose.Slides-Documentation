---
title: サポートされているファイル形式
type: docs
weight: 20
url: /ja/jasperreports/supported-file-formats/
description: "Aspose.Slides for JasperReports が入力として受け付けるものと、レポートをエクスポートするファイル形式を確認してください。"
---
## **入力**

Aspose.Slides for JasperReports はレポートをエクスポートします; 既存のプレゼンテーションは変換しません。そのエクスポーターは、埋め込まれた JasperReports レポート（`JasperPrint`）を受け取ります。たとえば、`JasperFillManager` の結果や *.jrprint* ファイルから読み込まれた埋め込みレポートです。

## **出力形式**

以下の表は、Aspose.Slides for JasperReports がレポートをエクスポートできる形式と、それぞれを書き出すエクスポータークラスを示しています。

|**形式**|**説明**|**エクスポーター**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 プレゼンテーション; レポートページごとに1スライド|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint プレゼンテーション (Office Open XML); レポートページごとに1スライド|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; レポートページごとに1 PDF ページ|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|単一の HTML ファイルで、レポートページごとに1つの SVG 画像を含む|`ASHtmlExporter`|

PPS および PPSX スライドショー形式のエクスポーターはありません。*.ppsx* のファイル名を付けて PPTX エクスポートを行っても、スライドショーではなく PPTX プレゼンテーションが生成されます。各エクスポーターの使用方法を見るには、[PPT, PPTX, PDF and HTML Export](/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/) を参照してください。