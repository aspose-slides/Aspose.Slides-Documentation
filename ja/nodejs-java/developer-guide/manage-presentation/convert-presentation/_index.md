---
title: JavaScript でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument プレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。下記の専用記事で各ケースの実装詳細を確認できます。

## **変換シナリオの選択**

以下の記事で完全な JavaScript サンプルと形式固有のオプションを確認してください。

| シナリオ | 必要なときに使用する | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX へ | レガシー PPT ファイルを最新化、既存 PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換 | [PPT を PPTX に変換](/slides/ja/nodejs-java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/nodejs-java/convert-odp-to-pptx/), [プレゼンテーションの保存](/slides/ja/nodejs-java/save-presentation/) |
| PPTX から PPT へ | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を確保 | [PPTX を PPT に変換](/slides/ja/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF へ | 共有、印刷、アーカイブ用に携帯性が高く検索可能な固定レイアウト文書を作成 | [PowerPoint を PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き）へ | スライド コンテンツとともにスピーカーノートをエクスポート | [PowerPoint をノート付き PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML へ | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御 | [PowerPoint を HTML に変換](/slides/ja/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 へ | 書式とインタラクティブ性を保持したまま、ブラウザベースで閲覧できる HTML5 にエクスポート | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP から PNG へ | 各スライドを PNG 画像にレンダリングし、プレビュー、サムネイル、Web 出力に利用 | [PowerPoint を PNG に変換](/slides/ja/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG へ | スライドを JPG 画像にレンダリングし、画像サイズと品質を制御 | [PowerPoint を JPG に変換](/slides/ja/nodejs-java/convert-powerpoint-to-jpg/) |
| スライドを SVG へ | 個々のスライドをスケーラブル ベクタ グラフィックスとしてエクスポート | [スライドを SVG としてレンダリング](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS へ | 固定レイアウトの XPS 文書を生成 | [PowerPoint を XPS に変換](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF へ | 印刷、スキャン、FAX、アーカイブ ワークフロー向けにマルチページ TIFF ファイルとして保存 | [PowerPoint を TIFF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き）へ | スピーカーノート付きスライドを TIFF に保存 | [PowerPoint をノート付き TIFF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Markdown へ | ドキュメント化やテキストベースのワークフロー向けにプレゼンテーション内容を Markdown に抽出 | [PowerPoint を Markdown に変換](/slides/ja/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX からアニメーション GIF へ | スライドからアニメーション GIF を作成 | [PowerPoint をアニメーション GIF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX から動画へ | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築 | [PowerPoint を動画に変換](/slides/ja/nodejs-java/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML へ | JavaScript または Java UI シナリオ向けにスライドを XAML にエクスポート | [プレゼンテーションを XAML にエクスポート](/slides/ja/nodejs-java/export-to-xaml/) |

入力および出力形式の詳細リストについては、[サポートされているファイル形式](/slides/ja/nodejs-java/supported-file-formats/)をご覧ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Node.js via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument ファイルは同じ変換 API を使用するため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同じようにサポートしているわけではないことに留意してください。LibreOffice や OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、必要に応じて[OpenDocument プレゼンテーションの変換](/slides/ja/nodejs-java/convert-openoffice-odp/)で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Node.js via Java は、マスター、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持した高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/nodejs-java/convert-ppt-to-pptx/) および [PPT と PPTX の比較](/slides/ja/nodejs-java/ppt-vs-pptx/)をご参照ください。

## **固定レイアウト エクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル フォーマット、出力サイズの制御方法を解説しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に便利です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご覧ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Node.js via Java は単体のライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、プレゼンテーション インスタンスを分け、[マルチスレッド](/slides/ja/nodejs-java/multithreading/)のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライド インデックスを指定したり、個別スライドをレンダリングしたりできるエクスポート メソッドがあります。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用にコンプライアンス設定があります。詳細は [PowerPoint を PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。[埋め込みフォント](/slides/ja/nodejs-java/embedded-font/)、[フォールバック フォント](/slides/ja/nodejs-java/fallback-font/)、および [フォント置換](/slides/ja/nodejs-java/font-substitution/) を参照してください。