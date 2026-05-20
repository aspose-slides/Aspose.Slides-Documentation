---
title: Python でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションの変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式で保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS といった固定レイアウトのドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します：ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下のリンクされた専用記事で、各ケースの実装詳細が提供されています。

## **変換シナリオの選択**

以下の記事で、完全な Python のサンプルと形式固有のオプションをご確認ください。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシーな PPT ファイルを最新化し、既存の PPTX ファイルを正規化し、または OpenDocument プレゼンテーションを PowerPoint の PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/python-net/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/python-net/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを、古いバイナリ PPT 形式で保存し、従来のワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用に、携帯性が高く、検索可能で、固定レイアウトのドキュメントを作成します。 | [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライドの内容とともに発表者ノートをエクスポートします。 | [PowerPoint をノート付き PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | スライドを HTML5 にエクスポートし、ブラウザベースの閲覧でフォーマットとインタラクティブ性を保持します。 | [プレゼンテーションを HTML5 に変換](/slides/ja/python-net/export-to-html5/) |
| PPT/PPTX/ODP から PNG | プレビュー、サムネイル、Web 出力向けに各スライドを PNG 画像としてレンダリングします。 | [PowerPoint を PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像のサイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/python-net/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブルベクターグラフィックとしてエクスポートします。 | [スライドを SVG としてレンダリング](/slides/ja/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成します。 | [PowerPoint を XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、FAX、アーカイブ向けに、プレゼンテーションをマルチページ TIFF ファイルとして保存します。 | [PowerPoint を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スライドと発表者ノートを TIFF に保存します。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP から Word | 文書スタイルの出力が必要なときに、スライドを Word 文書に変換します。 | [PowerPoint を Word に変換](/slides/ja/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP から Markdown | プレゼンテーション内容を Markdown に抽出し、ドキュメントやテキストベースのワークフローに利用します。 | [PowerPoint を Markdown に変換](/slides/ja/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP から アニメーション GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP から ビデオ | プレゼンテーション スライドからビデオエクスポートのワークフローを構築します。 | [PowerPoint をビデオに変換](/slides/ja/python-net/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | Python または .NET UI シナリオ向けにスライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/python-net/export-to-xaml/) |

入力および出力形式の一覧は、[サポートされているファイル形式](/slides/ja/python-net/supported-file-formats/) を参照してください。

## **PowerPoint および OpenDocument の変換**

Aspose.Slides for Python via .NET は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。同一の変換 API が PowerPoint と OpenDocument の両方のファイルに使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能をまったく同じようにサポートしているわけではないことに注意してください。ODP ファイルが LibreOffice や OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/python-net/convert-openoffice-odp/)で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は従来のバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Python via .NET は、マスター、レイアウト、スライド、チャート、グループ化された図形、プレースホルダー、テキスト フレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら、高忠実度の PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/) および [PPT と PPTX の比較](/slides/ja/python-net/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同じ外観を保ち、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザでの閲覧、ウェブ公開、軽量な共有に役立ちます。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **よくある質問**

**プレゼンテーションを変換するために Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Python via .NET は単独のライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理の場合は、個別のプレゼンテーション インスタンスを使用し、[マルチスレッド](/slides/ja/python-net/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり個々のスライドをレンダリングしたりできるエクスポート メソッドがいくつかあります。対象フォーマットの専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/python-net/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用に PDF コンプライアンス設定が利用可能です。詳細は[PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/)をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/python-net/embedded-font/)、[フォントフォールバック](/slides/ja/python-net/fallback-font/)、[フォント置換](/slides/ja/python-net/font-substitution/) を参照してください。