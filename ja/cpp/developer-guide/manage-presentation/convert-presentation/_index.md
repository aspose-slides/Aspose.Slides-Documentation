---
title: C++ でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for C++ は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、PDF や XPS といった固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローです。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。下記の個別記事で各ケースの実装詳細を確認できます。

## **変換シナリオの選択**

以下の記事では、完全な C++ サンプルと形式固有のオプションが示されています。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX へ | レガシー PPT を最新化、既存 PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換する場合。 | [PPT を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/)、[ODP を PPTX に変換](/slides/ja/cpp/convert-odp-to-pptx/)、[プレゼンテーションの保存](/slides/ja/cpp/save-presentation/) |
| PPTX から PPT へ | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、従来のワークフローとの互換性を保つ場合。 | [PPTX を PPT に変換](/slides/ja/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF へ | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウト文書を作成する場合。 | [PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き）へ | スライド コンテンツとともにスピーカーノートもエクスポートする場合。 | [PowerPoint をノート付き PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML へ | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御する場合。 | [PowerPoint を HTML に変換](/slides/ja/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 へ | 形式とインタラクティブ性を保持したまま、ブラウザでの閲覧用にスライドを HTML5 にエクスポートする場合。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/cpp/export-to-html5/) |
| PPT/PPTX/ODP から PNG へ | プレビュー、サムネイル、ウェブ出力用に各スライドを PNG 画像としてレンダリングする場合。 | [PowerPoint を PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG へ | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御する場合。 | [PowerPoint を JPG に変換](/slides/ja/cpp/convert-powerpoint-to-jpg/) |
| スライドから SVG へ | 個々のスライドをスケーラブルベクタ グラフィックスとしてエクスポートする場合。 | [スライドを SVG としてレンダリング](/slides/ja/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS へ | 固定レイアウトの XPS 文書を生成する場合。 | [PowerPoint を XPS に変換](/slides/ja/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF へ | 印刷、スキャン、FAX、またはアーカイブ ワークフロー向けに、マルチページ TIFF ファイルとしてプレゼンテーションを保存する場合。 | [PowerPoint を TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き）へ | スピーカーノート付きのスライドを TIFF として保存する場合。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Word へ | 文書スタイルの出力が必要なときに、スライドを Word 文書に変換する場合。 | [PowerPoint を Word に変換](/slides/ja/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX から Markdown へ | ドキュメント化やテキストベースのワークフロー向けに、プレゼンテーション コンテンツを Markdown に抽出する場合。 | [PowerPoint を Markdown に変換](/slides/ja/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP から XML へ | 検査、比較、トラブルシューティング、または XML ベースのワークフロー向けに、テキストベースの PowerPoint XML プレゼンテーションを作成する場合。 | [PowerPoint を XML に変換](/slides/ja/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX から アニメーション GIF へ | スライドからアニメーション GIF を作成する場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX から ビデオへ | プレゼンテーション スライドからビデオをエクスポートするワークフローを構築する場合。 | [PowerPoint をビデオに変換](/slides/ja/cpp/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML へ | C++ UI シナリオ向けにスライドを XAML にエクスポートする場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/cpp/export-to-xaml/) |

入力および出力形式の全一覧については、[サポートされているファイル形式](/slides/ja/cpp/supported-file-formats/)をご覧ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for C++ は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同一の変換 API で扱われるため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同一にサポートしているわけではないことに注意してください。LibreOffice や OpenOffice Impress で作成された ODP ファイルの場合は、出力を確認し、[OpenDocument プレゼンテーションの変換](/slides/ja/cpp/convert-openoffice-odp/)で説明されているオプションを必要に応じて使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint、PPTX は最新の Office Open XML 形式です。Aspose.Slides for C++ は、マスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持した高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/)をご参照ください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、デバイス間で出力が同一に見えることが求められ、プレゼンテーションとして編集されない場合に便利です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル フォーマット、出力サイズの制御方法を解説しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザでの閲覧、ウェブ公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に便利です。PNG、JPG、SVG の記事で形式固有のレンダリング手順を確認してください。

## **FAQ**

**プレゼンテーションを変換するのに Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for C++ はスタンドアロン ライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、プレゼンテーション インスタンスを個別に作成し、[マルチスレッド化](/slides/ja/cpp/multithreading/)のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライド インデックスを指定したり、個別スライドをレンダリングしたりできるエクスポート メソッドがあります。対象形式の専用記事をご確認ください。

**PDF や XPS にエクスポートする際、非表示スライドを含められますか？**

はい。非表示スライドのエクスポート設定は、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/cpp/convert-powerpoint-to-xps/) の変換記事で説明されています。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用にコンプライアンス設定が用意されています。詳細は [PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) を参照してください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。詳細は [埋め込みフォント](/slides/ja/cpp/embedded-font/)、[フォールバック フォント](/slides/ja/cpp/fallback-font/)、[フォント置換](/slides/ja/cpp/font-substitution/) をご覧ください。