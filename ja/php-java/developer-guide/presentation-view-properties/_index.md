---
title: PHPでプレゼンテーション ビュー プロパティを取得および更新する
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
- 単一ビュー
- バーの状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のビュー プロパティを活用し、PPT、PPTX、ODP スライドのフォーマットをカスタマイズ—レイアウト、ズームレベル、表示設定を調整します。"
---
## **概要**

標準ビューは 3 つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。さまざまなコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) が追加され、プレゼンテーションの標準ビュー プロパティへのアクセスが可能になりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties) クラスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType) 列挙体が追加されました。

## **INormalViewProperties について**

標準ビューのプロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) は、標準ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する場合にアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さいときに垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) は、ユーザーが標準の 3 つのコンテンツ領域ビューよりも、ウィンドウ全体で単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することがあります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドをスライド下のコンテンツ領域から分離し、垂直スプリッタ バーはスライドをサイドコンテンツ領域から分離します。可能な値は、[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Maximized) および [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties#getRestoredTop) は、[SplitterBarStateType::Restored](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Restored) の値が [getVerticalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) および [getHorizontalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) にそれぞれ適用されたときの、標準ビューの上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）であるときの、標準ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) の子としては幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) の子としては高さ）のサイズを指定します。

Method [getDimensionSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) は、スライド領域のサイズ（復元Top の子としては幅、復元Left の子としては高さ）を指定します。

Method [getAutoAdjust](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) は、ウィンドウ内のビューのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションの [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) プロパティにアクセスする方法を示しています。

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

## **デフォルト ズーム 値の設定**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるように、デフォルトのズーム値を設定する機能をサポートしています。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定することで行えます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) もプログラムから設定可能です。このトピックでは、Aspose.Slides で [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX ](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

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

## **グリッド間隔の設定**

[Presentation::getViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getViewProperties) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#getGridSpacing) と [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#setGridSpacing) メソッドは、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件に従い、正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、1/4 インチ間隔に設定し、結果を保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

グリッドは [drawing guides](/slides/ja/php-java/drawing-guides/) とは異なります。グリッド間隔は一定の間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。描画ガイドを追加、移動、またはクリアしてもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、またはスライドショーとしてレンダリングされるスライド コンテンツには含まれません。グリッド間隔を保存しても、エディタがグリッドを表示することが保証されるわけではなく、表示の有無はビューアやエディタの設定に依存します。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタがグリッドを表示するかどうかはエディタ側の設定で制御されます。エディタのグリッド表示設定を確認してください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドをクリアしても保存されたグリッド間隔は変更されません。

**プレゼンテーションの異なるセクションごとに別々のビュー設定を持たせられますか？**

[View settings](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション レベルで定義され（[Normal View](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/getslideviewproperties/)）、セクションごとではありません。そのため、ドキュメントが開かれる際には単一のパラメータセットが全体に適用されます。

**ユーザーごとに異なるビュー状態を事前定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションがユーザー設定を尊重することはありますが、ファイル自体には 1 つのビュー プロパティ セットしか含まれません。

**テンプレートに事前定義された View Properties を埋め込めば、新規プレゼンテーションが同じ方法で開くようにできますか？**

はい。ビュー プロパティはプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントを作成したときに同じ初期ビュー構成が適用されます。