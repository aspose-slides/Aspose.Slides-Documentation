---
title: "JavaScript でプレゼンテーションのビュー プロパティを取得および更新する"
linktitle: "ビュー プロパティ"
type: docs
weight: 80
url: /ja/nodejs-java/presentation-view-properties/
keywords:
  - "ビュー プロパティ"
  - "標準ビュー"
  - "アウトライン コンテンツ"
  - "アウトライン アイコン"
  - "垂直スプリッタのスナップ"
  - "シングルビュー"
  - "バーの状態"
  - "寸法 サイズ"
  - "自動調整"
  - "デフォルト ズーム"
  - "PowerPoint"
  - "OpenDocument"
  - "プレゼンテーション"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションの標準ビュー レイアウト、スライドとノートのズーム、グリッド間隔、コメントの表示設定を構成します。"
---
## **はじめに**

PowerPoint の標準ビューでは、スライドはサムネイルやアウトライン用のサイドペインと、下部のノートペインの間に表示されます。Aspose.Slides for Node.js via Java は、プレゼンテーションの保存された編集設定を [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) で提供します。これらの設定には、ペインのレイアウト、ズームレベル、グリッド間隔、コメントの表示状態が含まれます。

## **NormalViewProperties について**

[getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) を使用して [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) クラスにアクセスします。[setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) は、アウトラインでスライドタイトルの横にアイコンを表示するかどうかを制御します。[setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) は、ユーザーがサイドペインを狭めたときにペインを最小化状態にスナップさせます。[setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) は、ウィンドウ全体で 1 つのペインを表示することを優先するかどうかを示します。

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) はサイドペインとスライド間の区切りバーを制御します。[setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) はノートペイン上部の区切りバーを制御します。両方とも `Minimized`、`Maximized`、`Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **NormalViewProperties の復元について**

区切りバーが復元されると、[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) はサイドペインの保存されたサイズを返し、[getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) は上部スライド領域の保存されたサイズを返します。両方とも [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) を公開します。その [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) メソッドは 0 から 100 のパーセンテージを受け取り、[setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) はウィンドウのサイズ変更時にエディタがサイズを自動調整するかどうかを制御します。

この例は既存のプレゼンテーションを更新します。水平区切りバーを復元し、[getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) が返すサイズを自動調整を有効にした状態で 80% に設定し、垂直区切りバーを最大化します。また、[setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) を呼び出してアウトラインビューにアイコンを表示します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルトのズーム値を設定する**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) はエディタ用に個別のズーム設定を保存します。これらの設定はスライドのサイズ、スライドショーの再生、画像エクスポートの解像度には影響しません。

この例では既存のプレゼンテーションを開き、[setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) を呼び出してスライドを編集ウィンドウに合わせます。ノートページについては自動スケーリングを無効にし、[setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) を呼び出して固定の 80% ズームを設定します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔を設定する**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) はプレゼンテーション全体の編集グリッド線間の距離を設定します。単位はポイントで、1 インチは 72 ポイントです。この例では既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

グリッドは固定間隔で繰り返されます。[描画ガイド](/slides/ja/nodejs-java/drawing-guides/) は個々の水平または垂直の位置を示します。どちらも編集支援機能で、表示できるエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポートではそれらは除外されます。

## **プレゼンテーションを開くときのコメントの表示/非表示**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) は、対応するエディタがプレゼンテーションを開く際に使用する設定を保存します。コメントが含まれる既存のプレゼンテーションに対して、この例は現在の設定を表示し、コメントを非表示にしたコピーを保存します。また、[setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) を [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) と共に呼び出すことで、コピーがスライドビューで開かれるようにします。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

コメントを非表示にしても、テキスト、作成者、位置、返信、ステータスは保持されます。コメント自体を変更するには、[プレゼンテーションのコメント](/slides/ja/nodejs-java/presentation-comments/) を参照してください。エクスポート設定により、コメントが PDF、HTML、画像、ノート、配布資料に表示されるかが決まります。

## **よくある質問**

**プレゼンテーションを再度開いたときにグリッドが非表示になるのはなぜですか？**  
プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**  
いいえ。ガイドを追加、移動、または削除しても、グリッド間隔は変わりません。

**プレゼンテーションの異なるセクションで異なるビュー設定を持つことはできますか？**  
いいえ。[Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーション全体に適用されます。

**異なるユーザーごとに別々のビュー設定を保存できますか？**  
ファイルには全ユーザー共通のビュー設定が 1 つだけ保存されます。エディタはユーザーのローカル設定を適用することがあります。

**テンプレートにビュー設定を保存できますか？**  
はい。テンプレートから作成されたプレゼンテーションは、そのテンプレートに保存されたビュー設定を継承します。