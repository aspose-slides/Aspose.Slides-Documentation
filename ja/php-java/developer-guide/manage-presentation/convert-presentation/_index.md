---
title: PHPでプレゼンテーションを複数フォーマットに変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/php-java/convert-presentation/
keywords:
- プレゼンテーションを変換
- プレゼンテーションをエクスポート
- PPTからPPTXへ
- PPTXからPPTへ
- ODPからPPTXへ
- PPTからPDFへ
- PPTXからPDFへ
- ODPからPDFへ
- PPTからHTMLへ
- PPTXからHTMLへ
- ODPからHTMLへ
- PPTからPNGへ
- PPTXからPNGへ
- ODPからPNGへ
- PPTXからJPGへ
- ODPからJPGへ
- PPTからXPSへ
- PPTXからXPSへ
- ODPからXPSへ
- PPTからTIFFへ
- PPTXからTIFFへ
- ODPからTIFFへ
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for PHP via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice がなくても PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、その後ラスタまたはベクタ画像として保存されます。以下のリンクされた記事で各ケースの実装詳細が提供されています。

## **変換シナリオの選択**

以下の記事で完全な PHP のサンプルと形式固有のオプションを確認できます。

| シナリオ | 必要なときは | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルを最新化し、既存の PPTX ファイルを正規化し、OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/php-java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/php-java/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを、古いバイナリ PPT 形式に保存して、古いワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用の、携帯性があり検索可能な固定レイアウト文書を作成します。 | [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライドの内容とともにスピーカーノートをエクスポートします。 | [PowerPoint をノート付き PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトのオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | スライドを HTML5 にエクスポートし、ブラウザベースの閲覧で書式とインタラクティブ性を保持します。 | [プレゼンテーションを HTML5 に変換](/slides/ja/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 各スライドを PNG 画像にレンダリングし、プレビュー、サムネイル、Web 出力に使用します。 | [PowerPoint を PNG に変換](/slides/ja/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像にレンダリングし、画像のサイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個々のスライドをスケーラブルベクタ画像（SVG）としてエクスポートします。 | [スライドを SVG としてレンダリング](/slides/ja/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS 文書を生成します。 | [PowerPoint を XPS に変換](/slides/ja/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、アーカイブ ワークフロー用に、プレゼンテーションを多ページ TIFF ファイルとして保存します。 | [PowerPoint を TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スライドとスピーカーノートを TIFF に保存します。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | ドキュメント作成やテキストベースのワークフロー向けに、プレゼンテーション内容を Markdown に抽出します。 | [PowerPoint を Markdown に変換](/slides/ja/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーション スライドからビデオ エクスポートのワークフローを構築します。 | [PowerPoint をビデオに変換](/slides/ja/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | PHP または Java の UI シナリオ向けに、スライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/php-java/export-to-xaml/) |

入力および出力形式の詳細一覧については、[サポートされているファイル形式](/slides/ja/php-java/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for PHP via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。同じ変換 API が PowerPoint と OpenDocument のファイルに使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常は適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同じようにサポートしているわけではないことに注意してください。ODP ファイルが LibreOffice または OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは [OpenDocument プレゼンテーションを変換](/slides/ja/php-java/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for PHP via Java は、マスター、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなどの複雑なプレゼンテーション構造を保持しながら、高忠実度の PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/php-java/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/php-java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法が説明されています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産として扱う必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **よくある質問**

**プレゼンテーションを変換するのに Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for PHP via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーションオブジェクトを破棄します。並列処理を行う場合は、個別のプレゼンテーションインスタンスを使用し、[マルチスレッド](/slides/ja/php-java/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを渡したり個別のスライドをレンダリングしたりできるエクスポートメソッドがいくつかあります。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/php-java/convert-powerpoint-to-xps/) の変換記事に記載されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートでは PDF コンプライアンス設定が利用可能です。詳細は [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/php-java/embedded-font/)、[フォントフォールバック](/slides/ja/php-java/fallback-font/)、および [フォント置換](/slides/ja/php-java/font-substitution/) を参照してください。