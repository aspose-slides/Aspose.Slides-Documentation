---
title: プレゼンテーション ビュー プロパティ
type: docs
weight: 80
url: /ja/nodejs-java/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バー状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- プレゼンテーション
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "JavaScript で PowerPoint プレゼンテーションのビュー プロパティを管理する"
---

{{% alert color="primary" %}} 

通常ビューは3つのコンテンツ領域で構成されています: スライド自体、側面のコンテンツ領域、そして下部のコンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが復元されます。

メソッド[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType) 列挙体が追加されました。

{{% /alert %}} 

## **NormalViewProperties について**

通常ビューのプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際にアプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) は、側面領域が十分に小さい場合に垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) は、ユーザーが3つのコンテンツ領域を持つ標準の通常ビューではなく、全画面の単一コンテンツ領域を優先して表示したいかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することができます。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタバーが表示される状態を指定します。水平スプリッタバーはスライドとスライド下のコンテンツ領域を分割し、垂直スプリッタバーはスライドと側面のコンテンツ領域を分割します。可能な値は[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored)です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) および [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) に適用されたときの、通常ビューの上部または側面スライド領域のサイズを指定します。

## **NormalViewProperties の復元について** 

通常ビューにおいて、領域が可変の復元サイズ（最小化でも最大化でもない）である場合、スライド領域のサイズ（[getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) の子要素の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) の子要素の場合は高さ）を指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（restoredTop の子要素の場合は幅、restoredLeft の子要素の場合は高さ）を指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内でビューを含むウィンドウのサイズ変更時に側面コンテンツ領域のサイズが新しいサイズに合わせて調整されるべきかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

```javascript

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


## **デフォルトのズーム値を設定する**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java は、プレゼンテーションのデフォルトズーム値を設定できるようになりました。これにより、プレゼンテーションを開いたときにズームがあらかじめ設定された状態になります。これは、プレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) と [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムで設定可能です。このトピックでは、例を示しながら[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) を[Aspose.Slides](/slides/ja/) で設定する方法を見ていきます。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) を設定します。
3. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。以下の例では、スライドビューとノートビューのズーム値を設定しています。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライドビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノートビューのズーム値（パーセンテージ）
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーションレベルで定義されており（[Normal View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)、[Slide View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)）、セクションごとではありません。そのため、開くときは単一のパラメータセットがドキュメント全体に適用されます。

**異なるユーザー向けに異なるビュー状態を事前定義できますか？**

いいえ。設定はファイルに保存され、共有されます。ビューアー アプリケーションはユーザーの好みを尊重することはありますが、ファイル自体は1つのビュー プロパティセットしか持ちません。

**新しいプレゼンテーションが同じ方式で開くように、事前定義された View Properties を持つテンプレートを用意できますか？**

はい。[view properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーションレベルに保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。