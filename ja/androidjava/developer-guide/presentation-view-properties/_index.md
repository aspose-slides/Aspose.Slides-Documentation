---
title: Android でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/androidjava/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- シングルビュー
- バー状態
- 寸法サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションの標準ビューのレイアウト、スライドとノートのズーム、グリッド間隔、コメントの表示設定を構成します。"
---
## **概要**

PowerPoint の標準ビューでは、スライドはサムネイルまたはアウトライン用のサイドペインと下部のノートペインの間に表示されます。Aspose.Slides for Android via Java は、プレゼンテーションの保存された編集設定を [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) で公開します。これらには、ペインレイアウト、ズームレベル、グリッド間隔、コメントの表示可否が含まれます。

## **INormalViewProperties について**

[getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) を使用して [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) インターフェイスにアクセスします。[setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) はアウトラインでスライドタイトルの横にアイコンを表示するかどうかを制御します。[setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) は、ユーザーがサイドペインを狭めたときに最小化状態にスナップさせます。[setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) は、ウィンドウ全体で 1 つのペインを表示することを優先するかを示します。

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) はサイドペインとスライドの間の区切りバーを制御し、[setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) はノートペイン上部の区切りバーを制御します。どちらも `Minimized`、`Maximized`、`Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **INormalViewProperties の復元について**

区切りバーが復元されると、[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) はサイドペインの保存サイズを、[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) は上部スライド領域の保存サイズを提供します。両方とも [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) を公開します。その [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) メソッドは 0 から 100 のパーセンテージを受け取り、[setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) はウィンドウサイズ変更時にエディタがサイズを自動調整するかどうかを制御します。

この例は既存のプレゼンテーションを更新します。水平区切りバーを復元し、[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) が返すサイズを自動調整有効で 80% に設定し、垂直区切りバーを最大化します。また、[setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) を呼び出してアウトラインビューにアイコンを表示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルトズーム値の設定**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) と [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) はエディタ用に個別のズーム設定を保持します。これらの設定はスライドのサイズ、スライドショーの再生、画像のエクスポート解像度には影響しません。

この例は既存のプレゼンテーションを開き、[setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) を呼び出してスライドを編集ウィンドウに合わせます。ノートページについては自動スケーリングを無効にし、[setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) で固定 80% ズームを設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) はプレゼンテーション全体の編集グリッド線間の距離を設定します。単位はポイントで、1 インチは 72 ポイントです。この例は既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイント（1/4 インチ）に設定してグリッドを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

グリッドは固定間隔で繰り返されます。[Drawing guides](/slides/ja/androidjava/drawing-guides/) は個々の水平または垂直位置を示すガイドです。どちらも編集支援機能であり、表示できるエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポート時には含まれません。

## **プレゼンテーションを開くときのコメントの表示/非表示**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) は、互換性のあるエディタがプレゼンテーションを開く際に使用する設定を保存します。コメント付きの既存プレゼンテーションに対して、この例は現在の設定を出力し、コメントを非表示にしたコピーを保存します。また、[setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) に [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) を指定して、コピーがスライドビューで開くようにします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

コメントを非表示にしても、テキスト、作成者、位置、返信、ステータスは保持されます。コメント自体を変更するには、[Presentation Comments](/slides/ja/androidjava/presentation-comments/) を参照してください。エクスポート設定は、PDF、HTML、画像、ノート、配布資料にコメントが表示されるかどうかを制御します。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが非表示になるのはなぜですか？**

プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**描画ガイドをクリアするとグリッド間隔が変わりますか？**

いいえ。ガイドの追加、移動、クリアはグリッド間隔に影響しません。

**プレゼンテーションのセクションごとに異なるビュー設定を持たせられますか？**

いいえ。[Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーション全体に適用されます。

**ユーザーごとに異なるビュー設定を保存できますか？**

ファイルは全員共通のビュー設定を 1 組だけ保存します。エディタはユーザーのローカル設定を別途適用することがあります。

**テンプレートにビュー設定を保存できますか？**

はい。テンプレートから作成されたプレゼンテーションは、テンプレートに保存されたビュー設定を継承します。