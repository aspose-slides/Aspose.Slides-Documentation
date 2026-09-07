---
title: Python でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/python-java/convert-presentation/
keywords:
- プレゼンテーションを変換
- プレゼンテーションをエクスポート
- PPT から PPTX へ
- PPTX から PPT へ
- ODP から PPTX へ
- PPT から PDF へ
- PPTX から PDF へ
- ODP から PDF へ
- PPT から HTML へ
- PPTX から HTML へ
- ODP から HTML へ
- PPT から PNG へ
- PPTX から PNG へ
- ODP から PNG へ
- PPTX から JPG へ
- ODP から JPG へ
- PPT から XPS へ
- PPTX から XPS へ
- ODP から XPS へ
- PPT から TIFF へ
- PPTX から TIFF へ
- ODP から TIFF へ
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Python via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice なしで PowerPoint と OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシー PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下の専用記事は、各ケースの実装詳細を提供します。

## **変換シナリオを選択**

以下の記事で完全な Python の例と形式固有のオプションをご確認ください。

| シナリオ | 必要なときは | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP を PPTX に変換 | レガシー PPT ファイルを最新化し、既存の PPTX ファイルを正規化し、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [Convert PPT to PPTX](/slides/ja/python-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/ja/python-java/convert-odp-to-pptx/), [Save Presentations](/slides/ja/python-java/save-presentation/) |
| PPTX を PPT に変換 | 最新の PowerPoint プレゼンテーションを旧バイナリ PPT 形式で保存し、古いワークフローとの互換性を保ちます。 | [Convert PPTX to PPT](/slides/ja/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP を PDF に変換 | 共有、印刷、アーカイブ用に、携帯性が高く検索可能な固定レイアウト文書を作成します。 | [Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP を PDF（ノート付き）に変換 | スライド コンテンツとともにスピーカーノートをエクスポートします。 | [Convert PowerPoint to PDF with Notes](/slides/ja/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP を HTML に変換 | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御します。 | [Convert PowerPoint to HTML](/slides/ja/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP を HTML5 に変換 | フォーマットとインタラクティブ性を保持したまま、ブラウザーでの表示用にスライドを HTML5 にエクスポートします。 | [Convert Presentations to HTML5](/slides/ja/python-java/export-to-html5/) |
| PPT/PPTX/ODP を PNG に変換 | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像としてレンダリングします。 | [Convert PowerPoint to PNG](/slides/ja/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP を JPG に変換 | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御します。 | [Convert PowerPoint to JPG](/slides/ja/python-java/convert-powerpoint-to-jpg/) |
| スライドを SVG に変換 | 個々のスライドをスケーラブル ベクター グラフィックスとしてエクスポートします。 | [Render Slide as SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP を XPS に変換 | 固定レイアウト XPS 文書を生成します。 | [Convert PowerPoint to XPS](/slides/ja/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP を TIFF に変換 | 印刷、スキャン、FAX、アーカイブ ワークフロー用にプレゼンテーションをマルチページ TIFF ファイルとして保存します。 | [Convert PowerPoint to TIFF](/slides/ja/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP を TIFF（ノート付き）に変換 | スライドとスピーカーノートを TIFF に保存します。 | [Convert PowerPoint to TIFF with Notes](/slides/ja/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX を Word に変換 | ドキュメント形式の出力が必要なときに、スライドを Word 文書に変換します。 | [Convert PowerPoint to Word](/slides/ja/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX を Markdown に変換 | プレゼンテーション コンテンツを Markdown に抽出し、ドキュメントやテキストベースのワークフローに利用します。 | [Convert PowerPoint to Markdown](/slides/ja/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP を XML に変換 | 検査、比較、トラブルシューティング、XML ベースのワークフロー用にテキストベースの PowerPoint XML プレゼンテーションを作成します。 | [Convert PowerPoint to XML](/slides/ja/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX を アニメーション GIF に変換 | スライドからアニメーション GIF を作成します。 | [Convert PowerPoint to Animated GIF](/slides/ja/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX を ビデオに変換 | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築します。 | [Convert PowerPoint to Video](/slides/ja/python-java/convert-powerpoint-to-video/) |
| プレゼンテーションを XAML に変換 | スライドを XAML にエクスポートし、WPF アプリケーションで使用します。 | [Export Presentations to XAML](/slides/ja/python-java/export-to-xaml/) |

入力および出力形式の詳細一覧については、[Supported File Formats](/slides/ja/python-java/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Python via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。同じ変換 API が PowerPoint と OpenDocument ファイルの両方で使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同じようにサポートしているわけではないことに留意してください。ODP ファイルが LibreOffice または OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは [Convert OpenDocument Presentations](/slides/ja/python-java/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Python via Java は、マスター、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持した高精度の PPT から PPTX への変換をサポートします。

詳細については、[Convert PPT to PPTX](/slides/ja/python-java/convert-ppt-to-pptx/) と [PPT vs PPTX](/slides/ja/python-java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を解説しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザーでの閲覧、ウェブ公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Python via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、個別のプレゼンテーション インスタンスを使用し、[multithreading](/slides/ja/python-java/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり個別スライドをレンダリングしたりできるエクスポート メソッドがいくつか用意されています。対象形式の専用記事をご参照ください。

**PDF または XPS にエクスポートする際に非表示スライドを含めることができますか？**

はい。[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/python-java/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートには PDF コンプライアンス設定が利用可能です。詳細は [Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は、埋め込みフォント、フォント フォールバック、フォント置換設定を使用できます。詳細は [Embedded Font](/slides/ja/python-java/embedded-font/)、[Fallback Font](/slides/ja/python-java/fallback-font/)、[Font Substitution](/slides/ja/python-java/font-substitution/) を参照してください。