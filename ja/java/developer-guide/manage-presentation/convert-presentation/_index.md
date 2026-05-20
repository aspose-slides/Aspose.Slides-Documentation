---
title: Java でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Java は PowerPoint および OpenDocument プレゼンテーションを読み込み、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに多くの他形式に保存またはレンダリングできます。従来の PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します: ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下の専用記事でそれぞれの実装詳細が提供されています。

## **変換シナリオの選択**

以下の記事で完全な Java サンプルと形式固有のオプションをご確認ください。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | 従来の PPT ファイルを最新化、既存の PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換。 | [PPT を PPTX に変換](/slides/ja/java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/java/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、旧ワークフローとの互換性を確保。 | [PPTX を PPT に変換](/slides/ja/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用の携帯性が高く検索可能な固定レイアウト文書を作成。 | [PowerPoint を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライド コンテンツと共にスピーカーノートもエクスポート。 | [PowerPoint をノート付き PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウトオプションを制御。 | [PowerPoint を HTML に変換](/slides/ja/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | 書式とインタラクティビティを保持したまま、ブラウザーで閲覧できる HTML5 にエクスポート。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/java/export-to-html5/) |
| PPT/PPTX/ODP から PNG | 各スライドを PNG 画像としてレンダリングし、プレビュー、サムネイル、Web 出力に利用。 | [PowerPoint を PNG に変換](/slides/ja/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御。 | [PowerPoint を JPG に変換](/slides/ja/java/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブルベクタ画像としてエクスポート。 | [スライドを SVG としてレンダリング](/slides/ja/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウト XPS 文書を生成。 | [PowerPoint を XPS に変換](/slides/ja/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、ファックス、アーカイブ用にマルチページ TIFF ファイルとして保存。 | [PowerPoint を TIFF に変換](/slides/ja/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スライドとスピーカーノートを TIFF に保存。 | [ノート付き TIFF に PowerPoint を変換](/slides/ja/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Word | スライドを文書スタイルの出力が必要な場合に Word 文書に変換。 | [PowerPoint を Word に変換](/slides/ja/java/convert-powerpoint-to-word/) |
| PPT/PPTX から Markdown | ドキュメントやテキストベースのワークフロー向けにプレゼンテーション内容を Markdown に抽出。 | [PowerPoint を Markdown に変換](/slides/ja/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX から アニメーション GIF | スライドからアニメーション GIF を作成。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX から ビデオ | プレゼンテーション スライドからビデオエクスポート ワークフローを構築。 | [PowerPoint をビデオに変換](/slides/ja/java/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | Java UI シナリオ向けにスライドを XAML にエクスポート。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/java/export-to-xaml/) |

入力および出力形式の詳細一覧は、[対応ファイル形式](/slides/ja/java/supported-file-formats/) をご覧ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Java は PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument ファイルは同じ変換 API を使用するため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同じようにサポートしているわけではないことに留意してください。LibreOffice や OpenOffice Impressで作成された ODP ファイルの場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/java/convert-openoffice-odp/) に記載のオプションを使用してください。

## **PPT から PPTX への変換**

PPT は従来のバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Java はマスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持した高忠実度の PPT から PPTX への変換をサポートします。

詳細は[PPT を PPTX に変換](/slides/ja/java/convert-ppt-to-pptx/) と[ PPT と PPTX の違い](/slides/ja/java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に表示され、プレゼンテーションとして編集されるべきでない場合に便利です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に役立ちます。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産に変換する必要がある場合に有用です。PNG、JPG、SVG 記事で形式固有のレンダリングガイダンスをご確認ください。

## **FAQ**

**プレゼンテーションの変換に Microsoft PowerPoint が必要ですか？**

いいえ。Aspose.Slides for Java はスタンドアロン ライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理の場合は、プレゼンテーション インスタンスを個別に使用し、[マルチスレッド](/slides/ja/java/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。複数のエクスポート メソッドでスライド インデックスを指定したり、出力形式に応じて個別のスライドをレンダリングしたりできます。対象形式の専用記事をご覧ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/java/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/java/convert-powerpoint-to-xps/) の変換記事に記載の非表示スライド エクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用にコンプライアンス設定が用意されています。詳細は[PowerPoint を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/java/embedded-font/)、[フォールバックフォント](/slides/ja/java/fallback-font/)、[フォント置換](/slides/ja/java/font-substitution/) を参照してください。