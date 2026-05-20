---
title: Android でプレゼンテーションを複数形式に変換
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

Aspose.Slides for Android via Java は、Microsoft PowerPoint、OpenOffice、LibreOffice を使用せずに、PowerPoint および OpenDocument プレゼンテーションを読み込み、他の多数の形式に保存またはレンダリングできます。レガシーな PPT ファイルを最新の PPTX に変換したり、プレゼンテーションを PDF や XPS などの固定レイアウトドキュメントにエクスポートしたり、スライドを HTML として公開したり、プレビュー、サムネイル、アーカイブ用に画像ファイルとしてレンダリングしたりできます。

ほとんどのドキュメント変換は同じ一般的なワークフローを使用します：ソース ファイルを読み込み、必要な出力形式を選択し、必要に応じて形式固有のオプションを適用します。画像形式の場合、各スライドは個別にレンダリングされ、その後ラスタ画像またはベクトル画像として保存されます。以下のリンクされた記事が各ケースの実装詳細を提供しています。

## **変換シナリオの選択**

以下の記事では完全な Java のサンプルと形式固有のオプションを示しています。

| シナリオ | 必要なとき | 記事 |
| --- | --- | --- |
| PPT/PPTX/ODP から PPTX | レガシー PPT ファイルを最新化したり、既存の PPTX ファイルを正規化したり、OpenDocument プレゼンテーションを PowerPoint PPTX に変換したりする場合。 | [PPT を PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/), [ODP を PPTX に変換](/slides/ja/androidjava/convert-odp-to-pptx/), [プレゼンテーションを保存](/slides/ja/androidjava/save-presentation/) |
| PPTX から PPT | 最新の PowerPoint プレゼンテーションを古いバイナリ PPT 形式で保存し、古いワークフローとの互換性を保つ場合。 | [PPTX を PPT に変換](/slides/ja/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP から PDF | 共有、印刷、アーカイブ用に、ポータブルで検索可能な固定レイアウトドキュメントを作成する場合。 | [PowerPoint を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP から ノート付き PDF | スライド コンテンツとともに、スピーカーノートもエクスポートする場合。 | [PowerPoint をノート付き PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP から HTML | プレゼンテーションを HTML ページとして公開し、画像、フォント、ノート、レスポンシブ レイアウトオプションを制御する場合。 | [PowerPoint を HTML に変換](/slides/ja/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP から HTML5 | ブラウザーで閲覧できるように、フォーマットとインタラクティビティを保持したままスライドを HTML5 にエクスポートする場合。 | [プレゼンテーションを HTML5 にエクスポート](/slides/ja/androidjava/export-to-html5/) |
| PPT/PPTX/ODP から PNG | プレビュー、サムネイル、またはウェブ出力のために各スライドを PNG 画像としてレンダリングする場合。 | [PowerPoint を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP から JPG | スライドを JPG 画像としてレンダリングし、画像のサイズと品質を制御する場合。 | [PowerPoint を JPG に変換](/slides/ja/androidjava/convert-powerpoint-to-jpg/) |
| スライドから SVG | 個々のスライドをスケーラブルベクターグラフィックとしてエクスポートする場合。 | [スライドを SVG としてレンダリング](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP から XPS | 固定レイアウトの XPS ドキュメントを生成する場合。 | [PowerPoint を XPS に変換](/slides/ja/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP から TIFF | 印刷、スキャン、ファックス、またはアーカイブワークフローのために、プレゼンテーションをマルチページ TIFF ファイルとして保存する場合。 | [PowerPoint を TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP から ノート付き TIFF | スピーカーノート付きのスライドを TIFF として保存する場合。 | [PowerPoint をノート付き TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX から Word | 文書スタイルの出力が必要なときに、スライドを Word 文書に変換する場合。 | [PowerPoint を Word に変換](/slides/ja/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX から Markdown | ドキュメント作成やテキストベースのワークフローのために、プレゼンテーション内容を Markdown に抽出する場合。 | [PowerPoint を Markdown に変換](/slides/ja/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX から アニメーション GIF | スライドからアニメーション GIF を作成する場合。 | [PowerPoint をアニメーション GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX から 動画 | プレゼンテーションスライドから動画エクスポートのワークフローを構築する場合。 | [PowerPoint を動画に変換](/slides/ja/androidjava/convert-powerpoint-to-video/) |
| プレゼンテーションから XAML | Android や Java の UI シナリオ向けにスライドを XAML にエクスポートする場合。 | [プレゼンテーションを XAML にエクスポート](/slides/ja/androidjava/export-to-xaml/) |

入力および出力形式のより広い一覧については、[サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/) を参照してください。

## **PowerPoint と OpenDocument の変換**

Aspose.Slides for Android via Java は、PPT、PPTX、PPS、PPSX、POT、POTX、ODP など一般的に使用されるプレゼンテーション形式からの変換をサポートします。同じ変換 API が PowerPoint と OpenDocument の両方に使用されるため、PPTX ファイルを PDF に保存するワークフローは、入力ファイルを ODP に変更するだけで通常適用できます。

ODP ファイルを変換する際は、PowerPoint と OpenDocument アプリケーションがすべてのレイアウトや書式設定機能を完全に同じようにサポートしているわけではないことに留意してください。LibreOffice または OpenOffice Impress で作成された ODP ファイルの場合、出力を確認し、形式固有のガイダンスが必要なときは[OpenDocument プレゼンテーションの変換](/slides/ja/androidjava/convert-openoffice-odp/) に記載されたオプションを使用してください。

## **PPT から PPTX への変換**

PPT は古いバイナリ PowerPoint 形式で、PPTX は最新の Office Open XML 形式です。Aspose.Slides for Android via Java は、マスター、レイアウト、スライド、チャート、グループ化されたシェイプ、プレースホルダー、テキスト フレーム、テクスチャ、画像の塗りつぶしなど、複雑なプレゼンテーション構造を保持したまま高精度な PPT から PPTX への変換をサポートします。

詳細については、[PPT を PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/) と [PPT と PPTX の比較](/slides/ja/androidjava/ppt-vs-pptx/) を参照してください。

## **固定レイアウトのエクスポート**

PDF、XPS、TIFF は、出力がデバイス間で同一に見え、プレゼンテーションとして編集されるべきでない場合に有用です。専用の PDF、XPS、TIFF 記事では、コンプライアンス、非表示スライド、ノート、画像品質、圧縮、ピクセル形式、出力サイズの制御方法を説明しています。

## **HTML と画像のエクスポート**

HTML および HTML5 のエクスポートは、ブラウザーでの閲覧、ウェブ公開、軽量な共有に役立ちます。画像エクスポートは、各スライドを個別のプレビュー、サムネイル、ラスタ資産にする必要がある場合に有用です。形式固有のレンダリングガイダンスについては、PNG、JPG、SVG 記事をご利用ください。

## **FAQ**

**プレゼンテーションを変換するのに Microsoft PowerPoint は必要ですか？**

いいえ。Aspose.Slides for Android via Java はスタンドアロンのライブラリであり、Microsoft PowerPoint や Office の自動化は必要ありません。

**複数のプレゼンテーションをバッチ変換できますか？**

はい。各プレゼンテーションを読み込み、必要な形式で保存し、処理後にプレゼンテーション オブジェクトを破棄します。並列処理を行う場合は、個別のプレゼンテーション インスタンスを使用し、[マルチスレッド](/slides/ja/androidjava/multithreading/) のガイダンスに従ってください。

**選択したスライドだけをエクスポートできますか？**

はい。出力形式に応じて、スライドインデックスを指定したり個別のスライドをレンダリングしたりできるエクスポート方法がいくつかあります。対象フォーマットの専用記事をご参照ください。

**PDF や XPS にエクスポートする際に非表示スライドを含められますか？**

はい。[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) と [XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/) の変換記事で説明されている非表示スライドのエクスポート設定を使用してください。

**PDF/A 出力を作成できますか？**

はい。PDF エクスポート用に PDF コンプライアンス設定が利用可能です。詳細は [PowerPoint を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/) をご覧ください。

**変換時のフォントはどのように処理されますか？**

Aspose.Slides は埋め込みフォント、フォントフォールバック、フォント置換設定を使用できます。[埋め込みフォント](/slides/ja/androidjava/embedded-font/)、[フォールバックフォント](/slides/ja/androidjava/fallback-font/)、[フォント置換](/slides/ja/androidjava/font-substitution/) をご参照ください。