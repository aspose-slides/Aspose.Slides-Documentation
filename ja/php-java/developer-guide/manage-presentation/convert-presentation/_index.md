---
title: PHPでプレゼンテーションを複数フォーマットに変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに、Aspose.Slides for PHP via Java を使用して変換します。"
---
## **概要**

Aspose.Slides for PHP via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument プレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用の画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタ画像またはベクトル画像として保存されます。以下のリンクされた専用記事で各ケースの実装詳細を確認できます。

## **変換シナリオの選択**

以下の記事で完全な PHP のサンプルと形式固有のオプションを確認できます。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP を PPTX に変換 | レガシーな PPT ファイルを最新化し、既存の PPTX ファイルを正規化し、または OpenDocument プレゼンテーションを PowerPoint の PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/php-java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/php-java/save-presentation/) |
| PPTX を PPT に変換 | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP を PDF に変換 | 共有、印刷、アーカイブ用にポータブルで検索可能な固定レイアウトドキュメントを作成します。 | [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP を ノート付き PDF に変換 | スライドコンテンツとともにスピーカーノートをエクスポートします。 | [PowerPoint を ノート付き PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP を HTML に変換 | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP を HTML5 に変換 | フォーマットとインタラクティブ性を保持したまま、ブラウザでの閲覧用に HTML5 へエクスポートします。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/php-java/export-to-html5/) |
| PPT/PPTX/ODP を PNG に変換 | プレビュー、サムネイル、またはウェブ出力用に各スライドを PNG 画像としてレンダリングします。 | [PowerPoint を PNG に変換](/slides/ja/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP を JPG に変換 | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/php-java/convert-powerpoint-to-jpg/) |
| スライドを SVG に変換 | 個々のスライドをスケーラブルベクターグラフィックとしてエクスポートします。 | [スライドを SVG 画像としてレンダリング](/slides/ja/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP を XPS に変換 | 固定レイアウトの XPS ドキュメントを生成します。 | [PowerPoint を XPS に変換](/slides/ja/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP を TIFF に変換 | 印刷、スキャン、FAX、またはアーカイブワークフロー用にマルチページ TIFF ファイルとしてプレゼンテーションを保存します。 | [PowerPoint を TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP を ノート付き TIFF に変換 | スピーカーノート付きスライドを TIFF として保存します。 | [PowerPoint を ノート付き TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX を Markdown に変換 | プレゼンテーションの内容を Markdown に抽出し、文書化やテキストベースのワークフローに利用します。 | [PowerPoint を Markdown に変換](/slides/ja/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP を XML に変換 | 解析、比較、トラブルシューティング、または XML ベースのワークフロー向けにテキストベースの PowerPoint XML プレゼンテーションを作成します。 | [PowerPoint を XML に変換](/slides/ja/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX を アニメーション GIF に変換 | スライドからアニメーション GIF を作成します。 | [PowerPoint を アニメーション GIF に変換](/slides/ja/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX を ビデオに変換 | プレゼンテーションスライドからビデオエクスポートワークフローを構築します。 | [PowerPoint を ビデオに変換](/slides/ja/php-java/convert-powerpoint-to-video/) |
| プレゼンテーションを XAML に変換 | PHP または Java の UI シナリオ向けにスライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/php-java/export-to-xaml/) |

入力および出力形式の包括的な一覧については、[対応ファイル形式](/slides/ja/php-java/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for PHP via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同じ変換 API を使用するため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがレイアウトや書式設定のすべての機能を全く同じようにサポートしているわけではないことに注意してください。ODP ファイルが LibreOffice または OpenOffice Impress で作成された場合、出力を確認し、[OpenDocument プレゼンテーションの変換](/slides/ja/php-java/convert-openoffice-odp/) で説明されているオプションを使用して形式固有のガイダンスを参照してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for PHP via Java は、マスタ、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなどの複雑なプレゼンテーション構造を保持しながら、高忠実度の PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/) および [PPT と PPTX の比較](/slides/ja/php-java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見える必要があり、プレゼンテーションとして編集されるべきでない場合に便利です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザでの閲覧、ウェブ公開、軽量な共有に便利です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスは、PNG、JPG、SVG 記事をご参照ください。

## **よくある質問**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for PHP via Java は単体のライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーションオブジェクトを破棄します。並列処理を行う場合は、プレゼンテーションインスタンスを個別に使用し、[マルチスレッド](/slides/ja/php-java/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定してエクスポートしたり、個別のスライドをレンダリングしたりできるエクスポートメソッドが用意されています。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/php-java/convert-powerpoint-to-xps/) 変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用に PDF コンプライアンス設定が利用可能です。詳細は [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/php-java/embedded-font/)、[フォールバックフォント](/slides/ja/php-java/fallback-font/)、[フォント置換](/slides/ja/php-java/font-substitution/) を参照してください。