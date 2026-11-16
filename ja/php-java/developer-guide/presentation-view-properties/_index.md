---
title: PHPでプレゼンテーションのビュー プロパティを取得および更新する
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
- サイズの次元
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションの標準ビュー レイアウト、スライドとノートのズーム、グリッド間隔、コメントの表示を構成します。"
---
## **概要**

PowerPoint の標準ビューでは、スライドはサムネイルまたはアウトライン用のサイドペインと、下部のノートペインの間に表示されます。Aspose.Slides for PHP via Java は、[Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) を通じてプレゼンテーションの保存された編集設定を公開します。これにはペインのレイアウト、ズームレベル、グリッド間隔、コメントの表示状態が含まれます。

## **NormalViewPropertiesについて**

[getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) を使用して [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) クラスにアクセスします。[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) はアウトラインでスライドタイトルの横にアイコンを表示するかどうかを制御します。[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) はユーザーがサイドペインを狭めたときに最小化状態にスナップさせます。[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) は全ウィンドウで 1 つのペインを表示することを優先します。

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) はサイドペインとスライドの間の区切りバーを制御し、[setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) はノートペイン上部の区切りバーを制御します。両方とも `Minimized`、`Maximized`、または `Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **NormalViewPropertiesの復元について**

区切りバーが復元されると、[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) はサイドペインの保存されたサイズを、[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) は上部スライド領域の保存されたサイズを提供します。両方とも [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) を公開します。その [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) メソッドは 0 から 100 のパーセンテージを受け取り、[setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) はウィンドウのサイズ変更時にエディタがサイズを自動調整するかどうかを制御します。

この例は既存のプレゼンテーションを更新します。水平区切りバーを復元し、[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) が返すサイズを自動調整有効で 80% に設定し、垂直区切りバーを最大化します。また、[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) を呼び出してアウトラインビューにアイコンを表示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **デフォルトのズーム値を設定する**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) と [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) はエディタ用に個別のズーム設定を保存します。これらの設定はスライドサイズ、スライドショーの再生、画像エクスポートの解像度には影響しません。

この例は既存のプレゼンテーションを開き、[setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) を呼び出してスライドを編集ウィンドウに合わせます。ノートページについては自動スケーリングを無効にし、[setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) で固定の 80% ズームを設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **グリッド間隔を設定する**

[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) の `setGridSpacing` メソッドは、プレゼンテーション全体の編集グリッド線間の距離を設定します。単位はポイントで、1 インチあたり 72 ポイントです。この例は既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

グリッドは固定間隔で繰り返されます。[描画ガイド](/slides/ja/php-java/drawing-guides/) は個別の水平または垂直位置を示します。両方とも編集支援機能であり、表示できるエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポートには含まれません。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) は、互換性のあるエディタがプレゼンテーションを開く際に使用する設定を保存します。コメント付きの既存プレゼンテーションについて、この例は現在の設定を出力し、コメントを非表示にしたコピーを保存します。また、[setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) に [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) を指定して、コピーがスライドビューで開くようにします。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

コメントを非表示にしても、テキスト、作者、位置、返信、ステータスは保持されます。コメント自体を変更するには、[Presentation Comments](/slides/ja/php-java/presentation-comments/) を参照してください。エクスポート設定で PDF、HTML、画像、ノート、配布資料にコメントを含めるかどうかを制御できます。

## **よくある質問**

**プレゼンテーションを再度開くときにグリッドが非表示になるのはなぜですか？**

プレゼンテーションはグリッド間隔を保存しています。グリッドを表示させるには、エディタでグリッドの表示を有効にしてください。

**描画ガイドをクリアするとグリッド間隔が変わりますか？**

いいえ。ガイドを追加、移動、またはクリアしてもグリッド間隔は変更されません。

**プレゼンテーションの異なるセクションで異なるビュー設定を持たせることはできますか？**

できません。[Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション全体に適用されます。

**異なるユーザーごとに別々のビュー設定を保存できますか？**

ファイルは全ユーザー共通のビュー設定を 1 つだけ保存します。エディタ側でユーザーのローカル設定を適用することはあります。

**テンプレートにビュー設定を保存できますか？**

はい。テンプレートから作成されたプレゼンテーションは、テンプレートに保存されたビュー設定を継承します。