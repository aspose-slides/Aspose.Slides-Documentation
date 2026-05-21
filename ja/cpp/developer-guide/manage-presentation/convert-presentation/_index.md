---
title: C++ でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーションを読み込み、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに多数の他の形式に保存またはレンダリングできます。レガシー PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します: ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下にリンクされた専用記事で各ケースの実装詳細を確認してください。

## **変換シナリオを選択する**

以下の記事で完全な C++ サンプルと形式固有のオプションをご確認ください。

| シナリオ | 次の場合に使用 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT ファイルを最新化したり、既存の PPTX ファイルを正規化したり、OpenDocument プレゼンテーションを PowerPoint PPTX に変換したりする場合。 | [PPT を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/cpp/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/cpp/save-presentation/) |
| PPTX から PPT | 互換性のために最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存する場合。 | [PPTX を PPT に変換](/slides/ja/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用にポータブルで検索可能な固定レイアウトドキュメントを作成する場合。 | [PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライド コンテンツとともに発表者ノートをエクスポートする場合。 | [PowerPoint をノート付き PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御する場合。 | [PowerPoint を HTML に変換](/slides/ja/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | 書式とインタラクティブ性を保持したまま、ブラウザで閲覧できる HTML5 にスライドをエクスポートする場合。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/cpp/export-to-html5/) |
| PPT/PPTX/ODP から PNG | プレビュー、サムネイル、または Web 出力用に各スライドを PNG 画像としてレンダリングする場合。 | [PowerPoint を PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御する場合。 | [PowerPoint を JPG に変換](/slides/ja/cpp/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブル ベクタ グラフィックとしてエクスポートする場合。 | [スライドを SVG としてレンダリング](/slides/ja/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成する場合。 | [PowerPoint を XPS に変換](/slides/ja/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、FAX、またはアーカイブ ワークフロー用にマルチページ TIFF ファイルとしてプレゼンテーションを保存する場合。 | [PowerPoint を TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | 発表者ノート付きのスライドを TIFF に保存する場合。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Word | 文書形式の出力が必要なときにスライドを Word 文書に変換する場合。 | [PowerPoint を Word に変換](/slides/ja/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX から Markdown | ドキュメント作成やテキストベースのワークフロー用にプレゼンテーション内容を Markdown に抽出する場合。 | [PowerPoint を Markdown に変換](/slides/ja/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX からアニメーション GIF | スライドからアニメーション GIF を作成する場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX からビデオ | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築する場合。 | [PowerPoint をビデオに変換](/slides/ja/cpp/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | C++ UI シナリオ用にスライドを XAML にエクスポートする場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/cpp/export-to-xaml/) |

入力および出力形式の包括的なリストについては、[サポートされているファイル形式](/slides/ja/cpp/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for C++ は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。同じ変換 API が PowerPoint と OpenDocument のファイルに対して使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常は ODP ファイルにも適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を同じようにサポートしているわけではないことに注意してください。LibreOffice または OpenOffice Impress で ODP ファイルが作成された場合は、出力を確認し、形式固有のガイダンスが必要なときは [OpenDocument プレゼンテーションを変換](/slides/ja/cpp/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for C++ は、マスター、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら高忠実度の PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に便利です。専用の PDF、XPS、TIFF 記事では、準拠性、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法について説明しています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に便利です。画像エクスポートは、各スライドを別々のプレビュー、サムネイル、ラスタ アセットに変換する必要がある場合に便利です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご確認ください。

## **よくある質問**

**プレゼンテーションを変換するのに Microsoft PowerPoint が必要ですか？**

いいえ。Aspose.Slides for C++ はスタンドアロン ライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理の場合は、個別のプレゼンテーション インスタンスを使用し、[マルチスレッド](/slides/ja/cpp/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。複数のエクスポート方法でスライド インデックスを渡すか、個々のスライドをレンダリングすることができます。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。 [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/cpp/convert-powerpoint-to-xps/) の変換記事に記載された非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用にコンプライアンス設定が用意されています。詳細は [PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) をご覧ください。

**変換中のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。 [埋め込みフォント](/slides/ja/cpp/embedded-font/)、[フォールバック フォント](/slides/ja/cpp/fallback-font/)、[フォント置換](/slides/ja/cpp/font-substitution/) を参照してください。