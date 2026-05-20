---
title: C++ でプレゼンテーションを複数の形式に変換
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
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などのさまざまな形式に変換します。"
---
## **概要**

Aspose.Slides for C++ は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式へ保存またはレンダリングできます。従来の PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用の画像ファイルとしてスライドをレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタ画像またはベクタ画像として保存されます。以下の個別記事で各ケースの実装詳細が提供されています。

## **変換シナリオの選択**

以下の記事で完全な C++ のサンプルと形式固有のオプションをご確認ください。

| シナリオ | 必要な場面 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルの最新化、既存 PPTX ファイルの正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換する場合。 | [PPT を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/cpp/convert-odp-to-pptx/), [プレゼンテーションの保存](/slides/ja/cpp/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを、旧バイナリ PPT 形式で保存し、従来のワークフローとの互換性を保つ場合。 | [PPTX を PPT に変換](/slides/ja/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、携帯性があり検索可能な固定レイアウトドキュメントを作成する場合。 | [PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライドコンテンツと共にスピーカーノートをエクスポートする場合。 | [PowerPoint をノート付き PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御する場合。 | [PowerPoint を HTML に変換](/slides/ja/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | スライドを HTML5 にエクスポートし、フォーマットとインタラクティブ性を保持したままブラウザで閲覧する場合。 | [プレゼンテーションを HTML5 に変換](/slides/ja/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 各スライドを PNG 画像としてレンダリングし、プレビュー、サムネイル、または Web 出力に使用する場合。 | [PowerPoint を PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像としてレンダリングし、画像サイズと品質を制御する場合。 | [PowerPoint を JPG に変換](/slides/ja/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個別のスライドをスケーラブルベクターグラフィックとしてエクスポートする場合。 | [スライドを SVG としてレンダリング](/slides/ja/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS ドキュメントを生成する場合。 | [PowerPoint を XPS に変換](/slides/ja/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、アーカイブなどのワークフロー向けに、プレゼンテーションを複数ページの TIFF ファイルとして保存する場合。 | [PowerPoint を TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スライドとスピーカーノートを TIFF に保存する場合。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | ドキュメント形式の出力が必要なときに、スライドを Word 文書に変換する場合。 | [PowerPoint を Word に変換](/slides/ja/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメント作成やテキストベースのワークフロー向けに、プレゼンテーション内容を Markdown に抽出する場合。 | [PowerPoint を Markdown に変換](/slides/ja/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成する場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーションスライドからビデオエクスポートのワークフローを構築する場合。 | [PowerPoint をビデオに変換](/slides/ja/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | C++ UI シナリオ向けにスライドを XAML にエクスポートする場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/cpp/export-to-xaml/) |

入力および出力形式の詳細一覧については、[サポートされているファイル形式](/slides/ja/cpp/supported-file-formats/) をご参照ください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for C++ は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的なプレゼンテーション形式からの変換をサポートします。同じ変換 API が PowerPoint と OpenDocument の両方で使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常は適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同一にサポートしているわけではないことに留意してください。LibreOffice や OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/cpp/convert-openoffice-odp/)に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for C++ は、マスター、レイアウト、スライド、チャート、グループ化された図形、プレースホルダー、テキストフレーム、テクスチャ、画像塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら、高精度な PPT から PPTX への変換をサポートします。

詳細は[PowerPoint を PPTX に変換](/slides/ja/cpp/convert-ppt-to-pptx/)をご覧ください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に表示され、プレゼンテーションとして編集されるべきでない場合に有用です。専用の PDF、XPS、TIFF 記事では、準拠性、非表示スライド、ノート、画像品質、圧縮、ピクセルフォーマット、出力サイズの制御方法が説明されています。

## **HTML と画像のエクスポート**

HTML と HTML5 のエクスポートは、ブラウザでの閲覧、Web 公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、またはラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **よくある質問**

**プレゼンテーションの変換に Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for C++ はスタンドアロンのライブラリで、Microsoft PowerPoint や Office の自動化は必要ありません。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーションオブジェクトを破棄します。並列処理の場合は、別々のプレゼンテーションインスタンスを使用し、[マルチスレッド](/slides/ja/cpp/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり個別スライドをレンダリングしたりできるエクスポート方法が複数あります。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/cpp/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用に PDF 準拠設定が利用可能です。詳細は[PowerPoint を PDF に変換](/slides/ja/cpp/convert-powerpoint-to-pdf/)をご覧ください。

**変換時のフォント処理はどうなりますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/cpp/embedded-font/)、[フォントフォールバック](/slides/ja/cpp/fallback-font/)、[フォント置換](/slides/ja/cpp/font-substitution/)をご参照ください。