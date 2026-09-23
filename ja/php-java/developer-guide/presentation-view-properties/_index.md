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
- 単一ビュー
- バー 状態
- 次元 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整します。"
---
## **イントロダクション**

通常ビューは 3 つのコンテンツ領域で構成されます。スライド自体、サイドコンテンツ領域、ボトムコンテンツ領域です。これらの領域の配置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

メソッド [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties) クラスおよびその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType) 列挙体が追加されました。

## **INormalViewProperties について**

通常ビュー プロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際にアイコンを表示するかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) は、ユーザーが 3 つのコンテンツ領域を持つ標準の通常ビューではなく、ウィンドウ全体に単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することを選択できるようになります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとその下のコンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分割します。可能な値は [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Maximized)、および [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties#getRestoredTop) は、[SplitterBarStateType::Restored](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SplitterBarStateType/#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) に適用されたときの、通常ビューの上部またはサイド スライド領域のサイズを指定します。

## **Restoring INormalViewProperties について**

通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) の子の場合は高さ）が可変の復元サイズ（最小化でも最大化でもない）であるときのサイズを指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) は、復元された top の子の場合は幅、復元された left の子の場合は高さとして、スライド領域のサイズを指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/ja/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

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

## **デフォルト ズーム値の設定**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム値の設定をサポートします。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定することで実現できます。 [getSlideViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) をプログラムから設定できます。このトピックでは、Aspose.Slides で [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定する例を示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ViewProperties) を設定します。  
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。  
   以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

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

[Presentation::getViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getViewProperties) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#getGridSpacing) と [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/#setGridSpacing) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイント単位で指定され、72 ポイントが 1 インチに相当します。API ドキュメントで要求されているように正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、1/4 インチの間隔に設定して結果を保存します。

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

グリッドは [drawing guides](/slides/ja/php-java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御し、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。描画ガイドを追加、移動、クリアしてもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてスライド コンテンツにレンダリングされません。グリッド間隔を保存しても、エディタがグリッドを表示するかどうかは保証されません。表示の可視性はビューアまたはエディタの設定に依存します。

## **プレゼンテーションを開くときのコメントの表示/非表示**

[Presentation::getViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getviewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [ViewProperties::getShowComments](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/getshowcomments/) と [ViewProperties::setShowComments](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/setshowcomments/) を使用して、PowerPoint やその他の互換エディタでプレゼンテーションを開いたときにコメントを表示するかどうかの保存された優先設定を読み取ったり変更したりします。

この設定は保存されたビューの優先設定のみを制御します。コメントの追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作成者、位置、返信、ステータスは保持されます。コメント自体を変更する操作については [Presentation Comments](/slides/ja/php-java/presentation-comments/) を参照してください。

以下の例は、コメントが含まれる既存の `comments.pptx` を使用します。現在の表示設定を出力し、コメントを非表示に設定し、コメントを削除せずに新しい PPTX として保存します。また、[ViewProperties::setLastView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/setlastview/) と [ViewType::SlideView](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewtype/#SlideView) を組み合わせて、コメントの可視性とともに初期編集ビューを構成します。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この設定は、PDF、HTML、画像、ノート、配布資料のエクスポート時にコメントが含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタがグリッドを表示するかどうかはエディタ側で制御されます。エディタのグリッド表示設定をご確認ください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドをクリアしても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーションレベル（[Normal View](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/getslideviewproperties/)）で定義され、セクション単位ではありません。そのため、ドキュメント全体に対して単一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、共有されます。ビューア アプリケーションがユーザー固有の設定を尊重することはありますが、ファイル自体は 1 つのビュー プロパティ セットしか保持しません。

**新しいプレゼンテーションが同じビューで開くように、事前定義された View Properties を持つテンプレートを作成できますか？**

できます。[view properties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントは同じ初期ビュー構成で作成されます。