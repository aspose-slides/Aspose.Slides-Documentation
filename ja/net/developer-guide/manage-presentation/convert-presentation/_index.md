---
title: .NET でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーション変換
type: docs
weight: 70
url: /ja/net/convert-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for .NET は PowerPoint と OpenDocument のプレゼンテーションを読み込み、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに多数の他形式へ保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します：ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下のリンク先記事でそれぞれの実装詳細を確認できます。

## **変換シナリオの選択**

以下の記事で完全な C# サンプルと形式固有のオプションを確認してください。

| シナリオ | 必要な場合 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT を最新化、既存 PPTX を正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換。 | [PPT を PPTX に変換](/slides/ja/net/convert-ppt-to-pptx/)、[ODP を PPTX に変換](/slides/ja/net/convert-odp-to-pptx/)、[プレゼンテーションの保存](/slides/ja/net/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを旧バイナリ PPT 形式で保存し、古いワークフローとの互換性を保つ。 | [PPTX を PPT に変換](/slides/ja/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用にポータブルで検索可能な固定レイアウトドキュメントを作成。 | [PowerPoint を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から PDF（ノート付き） | スライド コンテンツとともにスピーカーノートをエクスポート。 | [PowerPoint をノート付き PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウトを制御。 | [PowerPoint を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | フォーマットとインタラクティブ性を保持したまま、ブラウザーで閲覧できる HTML5 にエクスポート。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/net/export-to-html5/) |
| PPT/PPTX/ODP から PNG | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像としてレンダリング。 | [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御。 | [PowerPoint を JPG に変換](/slides/ja/net/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドを拡張可能ベクタ画像としてエクスポート。 | [スライドを SVG としてレンダリング](/slides/ja/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成。 | [PowerPoint を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、FAX、アーカイブ用にマルチページ TIFF ファイルとして保存。 | [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から TIFF（ノート付き） | スピーカーノート付きスライドを TIFF に保存。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Word | 文書形式の出力が必要なときにスライドを Word 文書に変換。 | [PowerPoint を Word に変換](/slides/ja/net/convert-powerpoint-to-word/) |
| PPT/PPTX から Markdown | ドキュメント化やテキストベースのワークフロー向けにプレゼンテーション内容を Markdown に抽出。 | [PowerPoint を Markdown に変換](/slides/ja/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP から XML | 検査、比較、トラブルシューティング、XML ベースのワークフロー向けにテキストベースの PowerPoint XML プレゼンテーションを作成。 | [PowerPoint を XML に変換](/slides/ja/net/convert-powerpoint-to-xml/) |
| PPT/PPTX からアニメーション GIF | スライドからアニメーション GIF を作成。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX からビデオ | プレゼンテーション スライドからビデオエクスポート ワークフローを構築。 | [PowerPoint をビデオに変換](/slides/ja/net/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | .NET UI シナリオ向けにスライドを XAML にエクスポート。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/net/export-to-xaml/) |

入力および出力形式の詳細一覧は、[サポートされているファイル形式](/slides/ja/net/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for .NET は PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同じ変換 API で扱われるため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトおよび書式設定機能を同一にサポートしているわけではないことに留意してください。LibreOffice または OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、[OpenDocument プレゼンテーションの変換](/slides/ja/net/convert-openoffice-odp/) に記載されたオプションを使用して形式固有のガイダンスを得てください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式、PPTX は最新の Office Open XML 形式です。Aspose.Slides for .NET は、マスター、レイアウト、スライド、チャート、グループ化図形、プレースホルダー、テキスト フレーム、テクスチャ、画像フィルなどの複雑なプレゼンテーション構造を保持した高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/net/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/net/ppt-vs-pptx/) を参照してください。

## **固定レイアウトエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されないことが求められる場合に有用です。`PdfOptions`、`XpsOptions`、`TiffOptions` を使用して、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズなどを制御します。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に適しています。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に便利です。PNG、JPG、SVG に関する記事で形式固有のレンダリング手順を確認してください。

## **よくある質問**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for .NET は単体のライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後に `Presentation` オブジェクトを破棄してください。並列処理を行う場合は、プレゼンテーション インスタンスを分割し、[マルチスレッド](/slides/ja/net/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。いくつかのエクスポート メソッドはスライド インデックスを受け取ったり、個別スライドをレンダリングしたりできるため、対象形式の専用記事をご参照ください。

**PDF や XPS に非表示スライドを含めることはできますか？**

はい。`ShowHiddenSlides` プロパティを `PdfOptions` または `XpsOptions` で使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF のコンプライアンス設定は `PdfOptions.Compliance` および `PdfCompliance` で指定できます。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定をサポートします。詳しくは [埋め込みフォント](/slides/ja/net/embedded-font/)、[フォールバック フォント](/slides/ja/net/fallback-font/)、[フォント置換](/slides/ja/net/font-substitution/) をご覧ください。