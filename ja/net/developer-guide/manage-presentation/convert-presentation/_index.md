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

Aspose.Slides for .NET は PowerPoint と OpenDocument のプレゼンテーションを読み込み、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに多数の他の形式へ保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用の画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクトル画像として保存されます。以下のリンクされた記事で各ケースの実装詳細を確認できます。

## **変換シナリオを選択**

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルを最新化し、既存の PPTX ファイルを正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/net/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/net/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/net/save-presentation/) |
| PPTX to PPT | 現代的な PowerPoint プレゼンテーションを古いバイナリ PPT 形式に保存し、古いワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用のポータブルで検索可能な固定レイアウトドキュメントを作成します。 | [PowerPoint を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライド内容とともにスピーカーノートをエクスポートします。 | [PowerPoint を ノート付き PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 書式とインタラクティブ性を保持したまま、ブラウザで閲覧できる HTML5 にスライドをエクスポートします。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | プレビュー、サムネイル、または Web 出力用に各スライドを PNG 画像としてレンダリングします。 | [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像としてレンダリングし、画像のサイズや品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個別スライドをスケーラブルベクターグラフィックとしてエクスポートします。 | [スライドを SVG にレンダリング](/slides/ja/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウト XPS ドキュメントを生成します。 | [PowerPoint を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、またはアーカイブ用にプレゼンテーションをマルチページ TIFF ファイルとして保存します。 | [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スピーカーノート付きのスライドを TIFF として保存します。 | [PowerPoint を ノート付き TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | ドキュメント形式の出力が必要な場合にスライドを Word 文書に変換します。 | [PowerPoint を Word に変換](/slides/ja/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメント化やテキストベースのワークフロー向けにプレゼンテーション内容を Markdown に抽出します。 | [PowerPoint を Markdown に変換](/slides/ja/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint を アニメーション GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーションスライドからビデオをエクスポートするワークフローを構築します。 | [PowerPoint を ビデオに変換](/slides/ja/net/convert-powerpoint-to-video/) |
| Presentation to XAML | .NET UI シナリオ向けにスライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/net/export-to-xaml/) |

入力および出力形式の詳細な一覧については、[サポートされているファイル形式](/slides/ja/net/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for .NET は PPT、PPTX、PPS、PPSX、POT、POTX、ODP など、一般的に使用されるプレゼンテーション形式からの変換をサポートします。同一の変換 API が PowerPoint と OpenDocument の両方のファイルで使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同一にサポートしているわけではないことに留意してください。LibreOffice や OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、[Convert OpenDocument Presentations](/slides/ja/net/convert-openoffice-odp/) に記載されたオプションを使用して形式固有のガイダンスを得てください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint、PPTX は最新の Office Open XML 形式です。Aspose.Slides for .NET は、マスタ、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像フィルなど、複雑なプレゼンテーション構造を保持した高忠実度の PPT から PPTX への変換をサポートします。

詳細は [Convert PPT to PPTX](/slides/ja/net/convert-ppt-to-pptx/) と [PPT vs PPTX](/slides/ja/net/ppt-vs-pptx/) を参照してください。

## **固定レイアウトエクスポート**

PDF、XPS、TIFF は、デバイス間で同一の外観を保ち、プレゼンテーションとして編集されないことが求められる場合に有用です。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) を使用して、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズなどを制御できます。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に役立ちます。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG の各記事を参照してください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for .NET はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションをロードし、必要な形式で保存した後、`Presentation` オブジェクトを破棄します。並列処理を行う場合は、プレゼンテーションインスタンスを分割し、[multithreading](/slides/ja/net/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり、個別スライドをレンダリングしたりできるエクスポートメソッドがあります。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) または [XpsOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/) の `ShowHiddenSlides` プロパティを使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF コンプライアンス設定は [PdfOptions.Compliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/compliance/) と [PdfCompliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfcompliance/) で利用可能です。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[Embedded Font](/slides/ja/net/embedded-font/)、[Fallback Font](/slides/ja/net/fallback-font/)、[Font Substitution](/slides/ja/net/font-substitution/) を参照してください。