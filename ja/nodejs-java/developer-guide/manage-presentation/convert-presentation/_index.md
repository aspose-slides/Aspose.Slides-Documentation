---
title: JavaScript でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションの変換
type: docs
weight: 70
url: /ja/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument プレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシー PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用の画像ファイルとしてスライドをレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。下記のリンクされた記事が各ケースの実装詳細を提供しています。

## **変換シナリオの選択**

以下の記事で、完全な JavaScript のサンプルと形式固有のオプションを確認できます。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT ファイルを最新化し、既存の PPTX ファイルを正規化し、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/nodejs-java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/nodejs-java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/nodejs-java/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを、旧バイナリ PPT 形式で保存し、古いワークフローとの互換性を確保します。 | [PPTX を PPT に変換](/slides/ja/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウト文書を作成します。 | [PowerPoint を PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライドの内容とともに発表者ノートをエクスポートします。 | [PowerPoint をノート付き PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | スライドを HTML5 にエクスポートし、ブラウザーでの閲覧時に書式とインタラクティブ性を保持します。 | [プレゼンテーションを HTML5 に変換](/slides/ja/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP から PNG | 各スライドを PNG 画像にレンダリングし、プレビュー、サムネイル、Web 出力に使用します。 | [PowerPoint を PNG に変換](/slides/ja/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像にレンダリングし、画像のサイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/nodejs-java/convert-powerpoint-to-jpg/) |
| スライドを SVG に変換 | 個々のスライドをスケーラブルベクターグラフィック（SVG）としてエクスポートします。 | [スライドを SVG としてレンダリング](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS 文書を生成します。 | [PowerPoint を XPS に変換](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | プレゼンテーションをマルチページ TIFF ファイルとして保存し、印刷、スキャン、FAX、またはアーカイブワークフローに使用します。 | [PowerPoint を TIFF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スライドと発表者ノートを TIFF として保存します。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Markdown | プレゼンテーションの内容を Markdown に抽出し、ドキュメントやテキストベースのワークフローに利用します。 | [PowerPoint を Markdown に変換](/slides/ja/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX から アニメーション GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX から ビデオ | プレゼンテーションスライドからビデオエクスポートのワークフローを構築します。 | [PowerPoint をビデオに変換](/slides/ja/nodejs-java/convert-powerpoint-to-video/) |
| プレゼンテーションを XAML に変換 | スライドを XAML にエクスポートし、JavaScript または Java UI シナリオで使用します。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/nodejs-java/export-to-xaml/) |

入力および出力形式のより広範な一覧については、[サポートされているファイル形式](/slides/ja/nodejs-java/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Node.js via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument ファイルの両方で同じ変換 API が使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同一にサポートしているわけではないことに留意してください。ODP ファイルが LibreOffice や OpenOffice Impress で作成された場合は、出力を確認し、形式固有のガイダンスが必要なときは [OpenDocument プレゼンテーションの変換](/slides/ja/nodejs-java/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Node.js via Java は、マスタ、レイアウト、スライド、チャート、グループ化された図形、プレースホルダー、テキスト フレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら、高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/nodejs-java/convert-ppt-to-pptx/) および [PPT と PPTX の比較](/slides/ja/nodejs-java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないようにしたい場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスター資産にする必要がある場合に便利です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事を参照してください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Node.js via Java はスタンドアロンのライブラリで、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、個別のプレゼンテーション インスタンスを使用し、[マルチスレッド](/slides/ja/nodejs-java/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを渡すか個別のスライドをレンダリングするなど、さまざまなエクスポート方法が利用可能です。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) の変換記事に記載されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートでは PDF コンプライアンス設定が利用可能です。詳細は [PowerPoint を PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) を参照してください。

**変換時のフォントの扱いはどうなりますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/nodejs-java/embedded-font/)、[フォールバックフォント](/slides/ja/nodejs-java/fallback-font/)、[フォント置換](/slides/ja/nodejs-java/font-substitution/) をご覧ください。