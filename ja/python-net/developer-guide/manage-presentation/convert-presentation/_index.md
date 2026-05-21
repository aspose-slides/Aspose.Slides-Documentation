---
title: Python でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーション変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、他の多くの形式に保存またはレンダリングできます。レガシー PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタまたはベクタ画像として保存されます。以下の関連記事では、各ケースの実装詳細が提供されています。

## **変換シナリオの選択**

以下の記事で完全な Python のサンプルと形式固有のオプションを確認してください。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルをモダン化し、既存の PPTX ファイルを正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換します。 | [PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/python-net/convert-odp-to-pptx/), [プレゼンテーションの保存](/slides/ja/python-net/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を保ちます。 | [PPTX を PPT に変換](/slides/ja/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウトドキュメントを作成します。 | [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スピーカーノートとスライドの内容を同時にエクスポートします。 | [PowerPoint をノート付き PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御します。 | [PowerPoint を HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | スライドを HTML5 にエクスポートし、ブラウザでの閲覧時に書式とインタラクティブ性を保持します。 | [プレゼンテーションを HTML5 に変換](/slides/ja/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | プレビュー、サムネイル、ウェブ出力用に各スライドを PNG 画像としてレンダリングします。 | [PowerPoint を PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御します。 | [PowerPoint を JPG に変換](/slides/ja/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個別のスライドをスケーラブルベクターグラフィック (SVG) としてエクスポートします。 | [スライドを SVG としてレンダリング](/slides/ja/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS ドキュメントを生成します。 | [PowerPoint を XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、ファックス、アーカイブワークフロー用に、プレゼンテーションを複数ページの TIFF ファイルとして保存します。 | [PowerPoint を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スピーカーノート付きスライドを TIFF として保存します。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | 文書形式の出力が必要なときに、スライドを Word 文書に変換します。 | [PowerPoint を Word に変換](/slides/ja/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | ドキュメント作成やテキストベースのワークフローのために、プレゼンテーション内容を Markdown に抽出します。 | [PowerPoint を Markdown に変換](/slides/ja/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | スライドからアニメーション GIF を作成します。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | プレゼンテーションスライドからビデオエクスポートのワークフローを構築します。 | [PowerPoint をビデオに変換](/slides/ja/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Python または .NET UI シナリオ向けにスライドを XAML にエクスポートします。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/python-net/export-to-xaml/) |

入力および出力形式の詳細一覧については、[対応ファイル形式](/slides/ja/python-net/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Python via .NET は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートしています。同一の変換 API が PowerPoint と OpenDocument の両方で使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常は適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を全く同じようにサポートしているわけではないことに注意してください。ODP ファイルが LibreOffice や OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/python-net/convert-openoffice-odp/)で説明されているオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Python via .NET は、マスター、レイアウト、スライド、チャート、グループ化シェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像塗りつぶしなどの複雑なプレゼンテーション構造を保持しながら、PPT から PPTX への高忠実度変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/) および[PPT と PPTX の比較](/slides/ja/python-net/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に表示され、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法が説明されています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザーでの閲覧、ウェブ公開、軽量な共有に便利です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に有用です。PNG、JPG、SVG 記事で形式固有のレンダリングガイダンスをご確認ください。

## **よくある質問**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Python via .NET は単独のライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションを一括変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理が必要な場合は、プレゼンテーション インスタンスを分けて使用し、[マルチスレッド処理](/slides/ja/python-net/multithreading/) のガイダンスに従ってください。

**特定のスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライド インデックスを指定したり個別スライドをレンダリングしたりできるエクスポート メソッドが用意されています。対象形式の記事をご参照ください。

**PDF または XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。非表示スライドのエクスポート設定は、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/python-net/convert-powerpoint-to-xps/) の変換記事で説明されています。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート向けに PDF コンプライアンス設定が用意されています。詳細は [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォント フォールバック、フォント 置換設定を使用できます。詳細は [埋め込みフォント](/slides/ja/python-net/embedded-font/)、[フォント フォールバック](/slides/ja/python-net/fallback-font/)、および [フォント 置換](/slides/ja/python-net/font-substitution/) を参照してください。