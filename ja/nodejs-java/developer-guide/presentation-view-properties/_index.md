---
title: JavaScript でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/nodejs-java/presentation-view-properties/
keywords:
- ビュー プロパティ
- ノーマル ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- シングル ビュー
- バー状態
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java のビュー プロパティを使用して、PPT、PPTX、ODP スライドの形式をカスタマイズします — レイアウト、ズーム レベル、表示設定を調整します。"
---
## **概要**

ノーマルビューは3つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。これらのコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態でビューが表示されます。

メソッド [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションのノーマルビュー プロパティへアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType) 列挙型が追加されました。

## **NormalViewProperties について**

ノーマルビューのプロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) は、ノーマルビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さいときに垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 つのコンテンツ領域を持つノーマルビューよりも、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) に適用されたときの、ノーマルビューの上部または側面スライド領域のサイズを指定します。

## **NormalViewProperties の復元について**

ノーマルビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) の子の場合は高さ）が、可変の復元サイズ（最小化でも最大化でもない）であるときのサイズを指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) は、復元された top の子であれば幅、復元された left の子であれば高さとして、スライド領域のサイズを指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて補正されるかどうかを指定します。

以下の例は、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // プレゼンテーションのビュー プロパティを復元
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **デフォルトズーム値の設定**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java は、プレゼンテーションを開くとすでにズームが設定された状態になるように、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) はプログラムから設定可能です。このトピックでは、Aspose.Slides で [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定する方法を例とともに説明します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。  
   以下の例では、スライドビューとノートビューのズーム値を設定しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライド ビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノート ビューのズーム値（パーセンテージ）
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) と [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API のドキュメントで要求されているように正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、4 分の 1 インチの間隔に設定して結果を保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

グリッドは [drawing guides](/slides/ja/nodejs-java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。ガイドを追加、移動、または削除してもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてスライド コンテンツにレンダリングされることはありません。グリッド間隔を保存しても、エディタがグリッドを表示することを保証するものではなく、表示はビューアやエディタの設定に依存します。

## **FAQ**

**プレゼンテーションを再び開いたときにグリッドが表示されないのはなぜですか？**  
ファイルにはグリッド間隔が保存されていますが、エディタがグリッドを表示するかどうかはエディタ側で制御されます。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**  
いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションごとに異なるビュー設定を付けられますか？**  
[View settings](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション レベルで定義されており、セクション単位ではありません。そのため、ドキュメント全体に対して単一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**  
できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションはユーザー設定を尊重することがありますが、ファイル自体には 1 つのビュー プロパティしか含まれません。

**テンプレートに事前定義された View Properties を埋め込んで、新しいプレゼンテーションが同じ設定で開くようにできますか？**  
はい。[view properties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込めば新規作成時に同じ初期ビュー構成で開くことができます。