---
title: Android でプレゼンテーションを複数フォーマットに変換する
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Android via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument プレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシー PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下の専用記事で各ケースの実装詳細を確認できます。

## **変換シナリオを選択**

以下の記事で完全な Java サンプルと形式固有のオプションを確認してください。

| シナリオ | 必要な場合 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルを最新の PPTX に変換したり、既存の PPTX ファイルを正規化したり、OpenDocument プレゼンテーションを PowerPoint PPTX に変換する場合。 | [PPTをPPTXに変換](/slides/ja/androidjava/convert-ppt-to-pptx/), [ODPをPPTXに変換](/slides/ja/androidjava/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/androidjava/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、従来のワークフローとの互換性を保つ場合。 | [PPTXをPPTに変換](/slides/ja/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウトドキュメントを作成する場合。 | [PowerPointをPDFに変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライド コンテンツとともにスピーカー ノートもエクスポートする場合。 | [PowerPointをPDF（ノート付き）に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御する場合。 | [PowerPointをHTMLに変換](/slides/ja/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | フォーマットとインタラクティビティを保持したまま、ブラウザで表示できる HTML5 にスライドをエクスポートする場合。 | [プレゼンテーションをHTML5にエクスポート](/slides/ja/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像としてレンダリングする場合。 | [PowerPointをPNGに変換](/slides/ja/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御する場合。 | [PowerPointをJPGに変換](/slides/ja/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個々のスライドをスケーラブル ベクタ 画像としてエクスポートする場合。 | [スライドをSVGとしてレンダリング](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS ドキュメントを生成する場合。 | [PowerPointをXPSに変換](/slides/ja/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、アーカイブ用にマルチページ TIFF ファイルとしてプレゼンテーションを保存する場合。 | [PowerPointをTIFFに変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スライドとスピーカー ノートを TIFF に保存する場合。 | [PowerPointをTIFF（ノート付き）に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | ドキュメント形式の出力が必要なときに、スライドを Word 文書に変換する場合。 | [PowerPointをWordに変換](/slides/ja/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメントやテキストベースのワークフロー用に、プレゼンテーション内容を Markdown に抽出する場合。 | [PowerPointをMarkdownに変換](/slides/ja/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 検査、比較、トラブルシューティング、または XML ベースのワークフロー用に、テキストベースの PowerPoint XML プレゼンテーションを作成する場合。 | [PowerPointをXMLに変換](/slides/ja/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成する場合。 | [PowerPointをアニメーション GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築する場合。 | [PowerPointをビデオに変換](/slides/ja/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Android または Java UI シナリオ向けにスライドを XAML にエクスポートする場合。 | [プレゼンテーションをXAMLにエクスポート](/slides/ja/androidjava/export-to-xaml/) |

より広範な入力および出力形式の一覧については、[サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Android via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument ファイルは同一の変換 API を使用するため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトおよび書式設定機能を同一にサポートしているわけではないことに注意してください。LibreOffice または OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションを変換](/slides/ja/androidjava/convert-openoffice-odp/)で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Android via Java は、マスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら高忠実度の PPT から PPTX への変換をサポートします。

詳細は[PowerPointをPPTXに変換](/slides/ja/androidjava/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/androidjava/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に表示され、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産にする必要がある場合に有用です。PNG、JPG、SVG 記事で形式固有のレンダリングガイダンスを確認してください。

## **よくある質問**

**プレゼンテーションの変換に Microsoft PowerPoint が必要ですか？**

いいえ。Aspose.Slides for Android via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理が必要な場合は、プレゼンテーション インスタンスを分離し、[マルチスレッド](/slides/ja/androidjava/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。形式に応じてスライド インデックスを指定したり、個々のスライドをレンダリングしたりできるエクスポート メソッドが用意されています。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/) の変換記事に記載されている非表示スライド設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートにはコンプライアンス設定が用意されています。詳細は[PowerPointをPDFに変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。[埋め込みフォント](/slides/ja/androidjava/embedded-font/)、[フォールバック フォント](/slides/ja/androidjava/fallback-font/)、[フォント置換](/slides/ja/androidjava/font-substitution/) を参照してください。