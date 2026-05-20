---
title: PHP でプレゼンテーションを複数の形式に変換
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for PHP via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに PowerPoint および OpenDocument プレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下にリンクされた専用の記事で、各ケースの実装詳細をご確認ください。

## **変換シナリオを選択**

以下の記事で完全な PHP サンプルと形式固有のオプションを確認できます。

| シナリオ | 必要なときに使用 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT ファイルを最新化、既存 PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換。 | [PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/php-java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/php-java/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を保つ。 | [PPTX を PPT に変換](/slides/ja/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用のポータブルで検索可能な固定レイアウトドキュメントを作成。 | [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライド内容とともにスピーカーノートをエクスポート。 | [PowerPoint をノート付き PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御。 | [PowerPoint を HTML に変換](/slides/ja/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | フォーマットとインタラクティブ性を保持したまま、ブラウザベースで閲覧できる HTML5 にエクスポート。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/php-java/export-to-html5/) |
| PPT/PPTX/ODP から PNG | 各スライドを PNG 画像としてレンダリングし、プレビュー、サムネイル、Web 出力に利用。 | [PowerPoint を PNG に変換](/slides/ja/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御。 | [PowerPoint を JPG に変換](/slides/ja/php-java/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブルベクタ画像としてエクスポート。 | [スライドを SVG としてレンダリング](/slides/ja/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成。 | [PowerPoint を XPS に変換](/slides/ja/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、FAX、またはアーカイブワークフロー向けに、マルチページ TIFF ファイルとしてプレゼンテーションを保存。 | [PowerPoint を TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スピーカーノート付きでスライドを TIFF に保存。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Markdown | ドキュメント作成やテキストベースのワークフロー向けに、プレゼンテーション内容を Markdown に抽出。 | [PowerPoint を Markdown に変換](/slides/ja/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX からアニメーション GIF | スライドからアニメーション GIF を作成。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX からビデオ | プレゼンテーションスライドからビデオエクスポートワークフローを構築。 | [PowerPoint をビデオに変換](/slides/ja/php-java/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | PHP または Java UI シナリオ向けにスライドを XAML にエクスポート。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/php-java/export-to-xaml/) |

入力および出力形式の完全な一覧については、[サポートされているファイル形式](/slides/ja/php-java/supported-file-formats/)をご覧ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for PHP via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument ファイルの変換 API は同一であるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同じ方法でサポートしているわけではないことに注意してください。LibreOffice または OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、必要に応じて [OpenDocument プレゼンテーションの変換](/slides/ja/php-java/convert-openoffice-odp/) 記事で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint、PPTX は最新の Office Open XML 形式です。Aspose.Slides for PHP via Java は、マスタ、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら高忠実度の PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/php-java/ppt-vs-pptx/)をご参照ください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められるケースで有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産に変換する必要がある場合に有用です。PNG、JPG、SVG 記事で形式固有のレンダリングガイダンスをご確認ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for PHP via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**大量のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーションオブジェクトを破棄します。並列処理を行う場合は、プレゼンテーションインスタンスを分け、[マルチスレッド](/slides/ja/php-java/multithreading/) ガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。いくつかのエクスポートメソッドでは、スライドインデックスを指定したり、個別のスライドをレンダリングしたりできます。対象形式の専用記事をご参照ください。

**PDF または XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/php-java/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用にコンプライアンス設定が用意されています。詳細は [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/php-java/embedded-font/)、[フォールバックフォント](/slides/ja/php-java/fallback-font/)、[フォント置換](/slides/ja/php-java/font-substitution/) をご参照ください。