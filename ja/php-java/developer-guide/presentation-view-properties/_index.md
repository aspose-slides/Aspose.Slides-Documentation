---
title: PHP でプレゼンテーション ビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/php-java/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- シングルビュー
- バーの状態
- 寸法サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のビュー プロパティを活用して、PPT、PPTX、ODP 形式のスライドをカスタマイズし、レイアウト、ズーム レベル、表示設定を調整できます。"
---

{{% alert color="primary" %}} 

通常ビューは 3 つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された状態と同じビューになるようにします。

メソッド [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) が追加され、プレゼンテーションの通常ビュー プロパティへのアクセスを提供します。

[NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) 列挙体が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

通常ビューのプロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) は、通常ビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さい場合に垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) は、ユーザーが標準の 3 つのコンテンツ領域による通常ビューではなく、ウィンドウ全体で単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは任意のコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分離します。可能な値は [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) および [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) は、[SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) および [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) に適用された場合の、通常ビューの上部または側面のスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、通常ビューにおけるスライド領域（[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) の子の場合は高さ）のサイズを指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) は、復元されたトップの子であれば幅、復元されたレフトの子であれば高さとして、スライド領域のサイズを指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて補正されるべきかどうかを指定します。

以下の例は、プレゼンテーションに対して [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) プロパティにアクセスする方法を示しています。
```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # プレゼンテーションのビュー プロパティを復元する
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **デフォルト ズーム値の設定**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム値の設定をサポートします。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) をプログラムで設定できます。このトピックでは、[Aspose.Slides](/slides/ja/) で [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定する例を示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX ](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。下の例では、スライド ビューとノート ビューのズーム値を設定しています。
```php
  $presentation = new Presentation();
  try {
    # プレゼンテーションのビュー プロパティを設定する
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // スライドビューのズーム値（パーセンテージ）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // ノートビューのズーム値（パーセンテージ）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？**

ビュー設定はプレゼンテーション レベルで定義され（[Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)）、セクション単位ではなく、開くときにドキュメント全体に単一のパラメータセットが適用されます。

**異なるユーザー向けに異なるビュー状態を事前定義できますか？**

いいえ。設定はファイルに保存され、共有されます。ビューアー アプリケーションはユーザーの設定を考慮できる場合がありますが、ファイル自体は 1 つのビュー プロパティ セットしか保持しません。

**テンプレートに事前定義された View Properties を埋め込み、新しいプレゼンテーションを同じ方法で開くようにできますか？**

はい。ビュー プロパティはプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。