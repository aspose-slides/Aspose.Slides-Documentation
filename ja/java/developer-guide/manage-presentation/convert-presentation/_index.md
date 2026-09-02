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

Aspose.Slides for Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS といった固定レイアウトのドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用の画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドが個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下の個別記事で各ケースの実装詳細が説明されています。

## **変換シナリオの選択**

下記の記事では完全な Java のサンプルと形式固有のオプションが提供されています。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシーな PPT ファイルを最新化したり、既存の PPTX ファイルを正規化したり、OpenDocument のプレゼンテーションを PowerPoint PPTX に変換したりする場合。 | [PPT を PPTX に変換](/slides/ja/java/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/java/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/java/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを旧バイナリ PPT 形式で保存し、古いワークフローとの互換性を保ちたい場合。 | [PPTX を PPT に変換](/slides/ja/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウト ドキュメントを作成したい場合。 | [PowerPoint を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライド コンテンツとともにスピーカー ノートもエクスポートしたい場合。 | [PowerPoint をノート付き PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウト オプションを制御したい場合。 | [PowerPoint を HTML に変換](/slides/ja/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | フォーマットとインタラクティブ性を保持したまま、ブラウザーで閲覧できる HTML5 にエクスポートしたい場合。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像にレンダリングしたい場合。 | [PowerPoint を PNG に変換](/slides/ja/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像にレンダリングし、画像サイズと品質を制御したい場合。 | [PowerPoint を JPG に変換](/slides/ja/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個別スライドを拡張可能ベクタ グラフィックスとしてエクスポートしたい場合。 | [スライドを SVG としてレンダリング](/slides/ja/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS ドキュメントを生成したい場合。 | [PowerPoint を XPS に変換](/slides/ja/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、またはアーカイブ ワークフロー用にマルチページ TIFF ファイルとして保存したい場合。 | [PowerPoint を TIFF に変換](/slides/ja/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スライドとスピーカー ノートを TIFF に保存したい場合。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | ドキュメント形式の出力が必要なときに、スライドを Word 文書に変換したい場合。 | [PowerPoint を Word に変換](/slides/ja/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメント作成やテキストベースのワークフローのために、プレゼンテーション内容を Markdown に抽出したい場合。 | [PowerPoint を Markdown に変換](/slides/ja/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 検査、比較、トラブルシューティング、または XML ベースのワークフロー用にテキストベースの PowerPoint XML プレゼンテーションを作成したい場合。 | [PowerPoint を XML に変換](/slides/ja/java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成したい場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーション スライドからビデオ エクスポート ワークフローを構築したい場合。 | [PowerPoint をビデオに変換](/slides/ja/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Java UI シナリオ向けにスライドを XAML にエクスポートしたい場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/java/export-to-xaml/) |

より広範な入力および出力形式の一覧については、[サポートされているファイル形式](/slides/ja/java/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。同一の変換 API が PowerPoint と OpenDocument の両方に使用されるため、PPTX を PDF に保存するワークフローは、入力ファイルを ODP に変更するだけでほぼそのまま適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトおよび書式設定機能を完全に同じ方式でサポートしているわけではないことに注意してください。LibreOffice や OpenOffice Impress で作成された ODP ファイルの場合は、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/java/convert-openoffice-odp/)で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Java は、マスタ、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら高忠実度の PPT から PPTX への変換をサポートします。

詳細は[PowerPoint を PPTX に変換](/slides/ja/java/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/java/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されるべきでない場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法が説明されています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザーでの閲覧、Web 公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産に変換する必要があるときに便利です。PNG、JPG、SVG に関する記事で形式固有のレンダリング ガイダンスを確認してください。

## **FAQ**

**Microsoft PowerPoint がなくてもプレゼンテーションを変換できますか？**

いいえ。Aspose.Slides for Java はスタンドアロン ライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理が必要な場合は、プレゼンテーション インスタンスを分割して使用し、[マルチスレッド](/slides/ja/java/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライド インデックスを指定したり個別スライドをレンダリングしたりできるエクスポート メソッドが用意されています。対象形式の専用記事をご参照ください。

**PDF または XPS にエクスポートする際に非表示スライドを含められますか？**

はい。非表示スライドのエクスポート設定は、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/java/convert-powerpoint-to-xps/) の変換記事で説明されています。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートではコンプライアンス設定が利用可能です。詳細は[PowerPoint を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/) を参照してください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。[埋め込みフォント](/slides/ja/java/embedded-font/)、[フォールバック フォント](/slides/ja/java/fallback-font/)、[フォント置換](/slides/ja/java/font-substitution/) をご確認ください。