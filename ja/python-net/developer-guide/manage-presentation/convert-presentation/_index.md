---
title: Python でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint、OpenOffice、LibreOffice がなくても、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてスライドをレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクター画像として保存されます。以下の個別記事で各ケースの実装詳細をご確認ください。

## **変換シナリオの選択**

以下の記事で完全な Python サンプルと形式固有のオプションを確認できます。

| シナリオ | 必要なときに使用 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT ファイルをモダン化、既存 PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換 | [PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/python-net/convert-odp-to-pptx/), [プレゼンテーションの保存](/slides/ja/python-net/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を確保 | [PPTX を PPT に変換](/slides/ja/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用にポータブルで検索可能な固定レイアウトドキュメントを作成 | [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライド コンテンツとともにスピーカーノートをエクスポート | [PowerPoint をノート付き PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウト オプションを制御 | [PowerPoint を HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | 書式とインタラクティブ性を保持したまま、ブラウザーで閲覧できる HTML5 にエクスポート | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/python-net/export-to-html5/) |
| PPT/PPTX/ODP から PNG | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像としてレンダリング | [PowerPoint を PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像のサイズと品質を制御 | [PowerPoint を JPG に変換](/slides/ja/python-net/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブル ベクター グラフィックとしてエクスポート | [スライドを SVG としてレンダリング](/slides/ja/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成 | [PowerPoint を XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、FAX、アーカイブ ワークフロー用にマルチページ TIFF ファイルとして保存 | [PowerPoint を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スピーカーノート付きでスライドを TIFF に保存 | [PowerPoint をノート付き TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP から Word | ドキュメント形式の出力が必要なときにスライドを Word 文書に変換 | [PowerPoint を Word に変換](/slides/ja/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP から Markdown | ドキュメント作成やテキストベースのワークフロー用にプレゼンテーション内容を Markdown に抽出 | [PowerPoint を Markdown に変換](/slides/ja/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP から XML | 検査、比較、トラブルシューティング、XML ベースのワークフロー用にテキストベースの PowerPoint XML プレゼンテーションを作成 | [PowerPoint を XML に変換](/slides/ja/python-net/convert-powerpoint-to-xml/) |
| PPT/PPTX/ODP からアニメーション GIF | スライドからアニメーション GIF を作成 | [PowerPoint をアニメーション GIF に変換](/slides/ja/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP から video | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築 | [PowerPoint をビデオに変換](/slides/ja/python-net/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | Python または .NET UI シナリオ向けにスライドを XAML にエクスポート | [プレゼンテーションを XAML にエクスポート](/slides/ja/python-net/export-to-xaml/) |

入力および出力形式のより広範なリストについては、[対応ファイル形式](/slides/ja/python-net/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Python via .NET は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同じ変換 API を使用するため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同じようにサポートしているわけではないことに留意してください。LibreOffice や OpenOffice Impress で ODP が作成された場合は、出力を確認し、[OpenDocument プレゼンテーションの変換](/slides/ja/python-net/convert-openoffice-odp/) に記載されたオプションを使用して形式固有のガイダンスを得てください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Python via .NET は、マスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなどの複雑なプレゼンテーション構造を保持しながら、高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/python-net/ppt-vs-pptx/) を参照してください。

## **固定レイアウト エクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に便利です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を解説しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスター資産にする必要がある場合に有用です。形式固有のレンダリング手順は、PNG、JPG、SVG 記事をご覧ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Python via .NET はスタンドアロンのライブラリで、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、プレゼンテーション インスタンスを分け、[マルチスレッド](/slides/ja/python-net/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。いくつかのエクスポート メソッドはスライド インデックスを受け取ったり、出力形式に応じて個別スライドをレンダリングしたりできます。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/python-net/convert-powerpoint-to-xps/) の変換記事に記載された非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートにはコンプライアンス設定が用意されています。詳細は [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) を参照してください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。詳細は [埋め込みフォント](/slides/ja/python-net/embedded-font/)、[フォールバック フォント](/slides/ja/python-net/fallback-font/)、[フォント置換](/slides/ja/python-net/font-substitution/) を参照してください。