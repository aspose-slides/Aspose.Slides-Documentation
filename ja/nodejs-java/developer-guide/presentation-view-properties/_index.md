---
title: JavaScript でプレゼンテーションのビュー プロパティを取得・更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/nodejs-java/presentation-view-properties/
keywords:
- ビュー プロパティ
- 通常ビュー
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java のビュー プロパティを使って、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整する方法を紹介します。"
---
## **概要**

通常ビューは、スライド本体、サイドコンテンツ領域、ボトムコンテンツ領域の 3 つのコンテンツ領域で構成されます。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

Method [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビューのプロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType) 列挙が追加されました。

## **NormalViewProperties について**

通常ビューのプロパティを表します。

Method [getShowOutlineIcons](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

Method [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

Property [getPreferSingleView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 つのコンテンツ領域を持つ通常ビューではなく、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することがあります。

Method [getVerticalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分け、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分けます。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Restored) です。

Method [getRestoredLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) に適用された場合の、通常ビューの上部またはサイドスライド領域のサイズを指定します。

## **NormalViewProperties の復元について**

通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) の子の場合は高さ）が、可変の復元サイズ（最小化でも最大化でもない）である場合のサイズを指定します。

Method [getDimensionSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) は、復元された top の子であれば幅、復元された left の子であれば高さとして、スライド領域のサイズを指定します。

Method [getAutoAdjust](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // プレゼンテーションのビュー プロパティを復元する
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

Aspose.Slides for Node.js via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値の設定をサポートするようになりました。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) をプログラムで設定できます。このトピックでは、Aspose.Slides において [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ViewProperties) を設定します。  
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。  
   以下の例では、スライドビューとノートビューの両方にズーム値を設定しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定する
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライドビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノートビューのズーム値（パーセンテージ）
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) と [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイント単位で指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件に従い、正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

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

グリッドは [drawing guides](/slides/ja/nodejs-java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の位置合わせラインです。描画ガイドの追加、移動、クリアはグリッド間隔には影響しません。

グリッドも描画ガイドも編集の補助ツールです。PDF、画像、SVG、スライドショーとしてレンダリングされることはありません。グリッド間隔を保存しても、エディタが必ず表示するわけではなく、表示はビューアやエディタの設定に依存します。

## **プレゼンテーションを開くときのコメント表示/非表示**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getShowComments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#getShowComments--) と [ViewProperties.setShowComments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) を使用して、PowerPoint などの互換エディタでプレゼンテーションを開いたときにコメントを表示するかどうかの保存された設定を取得または変更できます。

この設定は保存されたビューの好みを制御するだけで、コメント自体の追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作者、位置、返信、ステータスは保持されます。コメントそのものを変更する操作については [Presentation Comments](/slides/ja/nodejs-java/presentation-comments/) を参照してください。

以下の例はコメントが含まれた既存の `comments.pptx` を対象とし、現在の表示設定を出力し、コメントを非表示に設定して新しい PPTX を保存します。また、[ViewProperties.setLastView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) と [ViewType.SlideView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewtype/#SlideView) を組み合わせて、コメントの表示設定とともに初期編集ビューを構成しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定は PDF、HTML、画像、ノート、配布資料へのエクスポート時にコメントが含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示/非表示を制御します。エディタのグリッド表示設定をご確認ください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドをクリアしても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を持たせられますか？**

[View settings](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション単位で定義され（[Normal View](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)）、セクション単位ではありません。そのため、ドキュメント全体に対して 1 つのパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューアーアプリはユーザーの好みを考慮できることがありますが、ファイル自体は 1 つのビュー プロパティしか保持しません。

**テンプレートに事前定義した View Properties を埋め込んで、新規プレゼンテーションが同じビューで開くようにできますか？**

可能です。ビュー プロパティはプレゼンテーション単位で保存されるため、テンプレートに埋め込めば、新しく作成するドキュメントは同じ初期ビュー設定で開かれます。