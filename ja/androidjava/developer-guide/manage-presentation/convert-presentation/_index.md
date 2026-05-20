---
title: Android 上でプレゼンテーションを複数の形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、HTML、画像、XPS、TIFF などに変換します。"
---
## **概要**

Aspose.Slides for Android via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument のプレゼンテーションを読み込み、さまざまな形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、PDF や XPS などの固定レイアウト文書にエクスポートしたり、スライドを HTML として公開したり、プレビューやサムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します。ソースファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、ラスタ画像またはベクター画像として保存されます。下記の各記事でそれぞれのケースに関する実装の詳細を提供しています。

## **変換シナリオの選択**

以下の記事で完全な Java のサンプルと形式固有のオプションを確認できます。

| シナリオ | 必要な場合 | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | レガシー PPT ファイルを最新化し、既存の PPTX ファイルを正規化、または OpenDocument プレゼンテーションを PowerPoint PPTX に変換する場合。 | [PPT を PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/androidjava/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/androidjava/save-presentation/) |
| PPTX to PPT | 最新の PowerPoint プレゼンテーションを、古いバイナリ PPT 形式で保存し、旧ワークフローとの互換性を保つ場合。 | [PPTX を PPT に変換](/slides/ja/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 共有、印刷、アーカイブ用に、携帯性があり検索可能な固定レイアウト文書を作成する場合。 | [PowerPoint を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | スライドコンテンツとともにスピーカーノートをエクスポートする場合。 | [PowerPoint を PDF（ノート付き）に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブレイアウトオプションを制御する場合。 | [PowerPoint を HTML に変換](/slides/ja/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | フォーマットとインタラクティブ性を保持したまま、ブラウザで閲覧できる HTML5 にスライドをエクスポートする場合。 | [プレゼンテーションを HTML5 に変換](/slides/ja/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | プレビュー、サムネイル、Web 出力用に各スライドを PNG 画像にレンダリングする場合。 | [PowerPoint を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | スライドを JPG 画像にレンダリングし、画像サイズと品質を制御する場合。 | [PowerPoint を JPG に変換](/slides/ja/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | 個々のスライドをスケーラブルベクターグラフィックとしてエクスポートする場合。 | [スライドを SVG にレンダリング](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 固定レイアウトの XPS 文書を生成する場合。 | [PowerPoint を XPS に変換](/slides/ja/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 印刷、スキャン、FAX、アーカイブ用に、プレゼンテーションを多ページ TIFF ファイルとして保存する場合。 | [PowerPoint を TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | スライドとスピーカーノートを TIFF に保存する場合。 | [PowerPoint を TIFF（ノート付き）に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 文書形式の出力が必要な場合に、スライドを Word 文書に変換する。 | [PowerPoint を Word に変換](/slides/ja/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | ドキュメント作成やテキストベースのワークフローのために、プレゼンテーション内容を Markdown に抽出する場合。 | [PowerPoint を Markdown に変換](/slides/ja/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | スライドからアニメーション GIF を作成する場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | プレゼンテーションスライドから動画エクスポートのワークフローを構築する場合。 | [PowerPoint を動画に変換](/slides/ja/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Android や Java の UI シナリオ向けにスライドを XAML にエクスポートする場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/androidjava/export-to-xaml/) |

入力および出力形式の詳細な一覧については、[サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/)をご覧ください。

## **PowerPoint および OpenDocument の変換**

Aspose.Slides for Android via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP などの一般的に使用されるプレゼンテーション形式からの変換をサポートします。PowerPoint と OpenDocument のファイルは同じ変換 API を使用するため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常は ODP ファイルにも適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同じようにサポートしているわけではないことに留意してください。ODP ファイルが LibreOffice または OpenOffice Impress で作成された場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/androidjava/convert-openoffice-odp/)に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ形式の PowerPoint で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Android via Java は、マスタ、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキストフレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持しながら高忠実度の PPT から PPTX への変換をサポートします。

詳細は、[PPT を PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/androidjava/ppt-vs-pptx/) をご覧ください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に表示され、プレゼンテーションとして編集されないことが求められる場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセルフォーマット、出力サイズの制御方法が説明されています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザーでの表示、Web 公開、軽量な共有に有用です。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **FAQ**

**プレゼンテーションを変換するのに Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Android via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は不要です。

**多数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーションオブジェクトを破棄します。並列処理を行う場合は、プレゼンテーションインスタンスを個別に使用し、[マルチスレッド](/slides/ja/androidjava/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり、個々のスライドをレンダリングしたりできるエクスポートメソッドがいくつか用意されています。対象形式の専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含めることができますか？**

はい。[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) および [XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/) の変換記事に記載されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポートでは PDF コンプライアンス設定が利用可能です。詳細は [PowerPoint を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように扱われますか？**

Aspose.Slides は埋め込みフォント、フォールバックフォント、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/androidjava/embedded-font/)、[フォールバックフォント](/slides/ja/androidjava/fallback-font/)、[フォント置換](/slides/ja/androidjava/font-substitution/) をご覧ください。