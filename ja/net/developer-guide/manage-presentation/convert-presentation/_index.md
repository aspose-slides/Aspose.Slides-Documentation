---
title: .NET でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/net/convert-presentation/
keywords:
- プレゼンテーションを変換
- プレゼンテーションをエクスポート
- PPT から PPTX
- PPTX から PPT
- ODP から PPTX
- PPT から PDF
- PPTX から PDF
- ODP から PDF
- PPT から HTML
- PPTX から HTML
- ODP から HTML
- PPT から PNG
- PPTX から PNG
- ODP から PNG
- PPTX から JPG
- ODP から JPG
- PPT から XPS
- PPTX から XPS
- ODP から XPS
- PPT から TIFF
- PPTX から TIFF
- ODP から TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for .NET は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、他の多数の形式へ保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用の画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクター画像として保存されます。下記の各記事で実装の詳細を確認できます。

## **変換シナリオの選択**

以下の記事で完全な C# のサンプルと形式固有のオプションを確認できます。

| シナリオ | 必要な場合 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルを最新化し、既存の PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/net/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/net/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/net/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを旧バイナリ PPT 形式で保存し、従来のワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウト文書を作成します。 | [PowerPoint を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライドコンテンツとともにスピーカーノートをエクスポートします。 | [PowerPoint を PDF ノート付きに変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | ブラウザーでの閲覧用にスライドを HTML5 にエクスポートし、書式やインタラクティブ性を保持します。 | [プレゼンテーションを HTML5 に変換](/slides/ja/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 各スライドを PNG 画像にレンダリングし、プレビュー、サムネイル、Web 出力に利用します。 | [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像にレンダリングし、画像サイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | 各スライドをスケーラブルベクターグラフィック（SVG）としてエクスポートします。 | [スライドを SVG としてレンダリング](/slides/ja/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS 文書を生成します。 | [PowerPoint を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、アーカイブ用にマルチページ TIFF ファイルとしてプレゼンテーションを保存します。 | [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スピーカーノート付きのスライドを TIFF として保存します。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 文書形式の出力が必要な場合に、スライドを Word 文書に変換します。 | [PowerPoint を Word に変換](/slides/ja/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメント作成やテキストベースのワークフロー向けに、プレゼンテーションの内容を Markdown に抽出します。 | [PowerPoint を Markdown に変換](/slides/ja/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーションスライドからビデオエクスポートのワークフローを構築します。 | [PowerPoint をビデオに変換](/slides/ja/net/convert-powerpoint-to-video/) |
| Presentation to XAML | .NET UI シナリオ向けにスライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/net/export-to-xaml/) |

入力および出力形式の詳細な一覧は、[対応ファイル形式](/slides/ja/net/supported-file-formats/)をご参照ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for .NET は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同じ変換 API を使用するため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同一にサポートしているわけではないことに注意してください。ODP ファイルが LibreOffice または OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは [OpenDocument プレゼンテーションの変換](/slides/ja/net/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for .NET は、マスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持したまま、高精度な PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/net/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/net/ppt-vs-pptx/) をご参照ください。

## **固定レイアウトエクスポート**

PDF、XPS、TIFF は、デバイス間で出力が同一に見え、プレゼンテーションとして編集されないことが求められる場合に有用です。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/)、[TiffOptions]​(https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) を使用して、準拠性、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズなどを制御できます。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に便利です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に便利です。PNG、JPG、SVG に関する記事で形式固有のレンダリングガイダンスをご確認ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for .NET はスタンドアロンのライブラリで、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後に `Presentation` オブジェクトを破棄します。並列処理を行う場合は、個別のプレゼンテーション インスタンスを使用し、[multithreading](/slides/ja/net/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり個別のスライドをレンダリングしたりできるエクスポート メソッドがいくつかあります。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) または [XpsOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/) の `ShowHiddenSlides` プロパティを使用してください。

**PDF/A 出力を作成できますか？**

はい。[PdfOptions.Compliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/compliance/) および [PdfCompliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfcompliance/) で PDF のコンプライアンス設定が利用できます。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォールバックフォント、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/net/embedded-font/)、[フォールバックフォント](/slides/ja/net/fallback-font/)、[フォント置換](/slides/ja/net/font-substitution/) をご参照ください。