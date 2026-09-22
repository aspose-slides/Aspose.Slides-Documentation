---
title: Android でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/androidjava/presentation-view-properties/
keywords:
- ビュー プロパティ
- ノーマルビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- シングルビュー
- バーの状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズします—レイアウト、ズーム レベル、表示設定を調整できます。"
---
## **イントロダクション**

通常ビューはスライド自体、サイドコンテンツ領域、ボトムコンテンツ領域の 3 つのコンテンツ領域で構成されます。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

Method[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビュー プロパティへのアクセスが提供されました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType) 列挙型が追加されました。

## **INormalViewProperties について**

通常ビュー プロパティを表します。

Methods[getShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と[setShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際にアイコンを表示するかどうかを指定します。

Methods[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と[setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

Property[getPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と[setPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 つのコンテンツ領域を持つ通常ビューではなく、ウィンドウ全体で単一コンテンツ領域を表示したいかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することができます。

Methods[getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と[getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーがどの状態で表示されるべきかを指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) および[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored)です。

Methods[getRestoredLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と[getRestoredTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と[getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) が[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored) に設定されたときの、通常ビューにおけるスライド領域の上下または左右のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）であるときに、通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合は高さ）のサイズを指定します。

Method[getDimensionSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、復元された top の子の場合は幅、復元された left の子の場合は高さとして、スライド領域のサイズを指定します。

Method[getAutoAdjust](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // プレゼンテーションのビュー プロパティを復元する
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **デフォルト ズーム値の設定**

{{% alert color="info" %}} 
Aspose.Slides for Android via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) および[getNotesViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) はプログラムから設定可能です。このトピックでは、Aspose.Slides で[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties) を設定する方法を例で示します。
{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。下の例では、スライドビューとノートビューのズーム値の両方を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定する
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライド ビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノート ビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) と[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイント単位で指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件どおり、正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、4 分の 1 インチの間隔に設定して結果を保存します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

グリッドは[描画ガイド](/slides/ja/androidjava/drawing-guides/)とは異なります。グリッド間隔は一定の間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の整列ラインです。描画ガイドを追加、移動、または削除してもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、またはスライドショーとしてレンダリングされることはなく、格納されたグリッド間隔がエディタで表示されるかどうかは、ビューアやエディタの設定に依存します。

## **よくある質問**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタがグリッドの表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても、保存されたグリッド間隔はそのままです。

**プレゼンテーションの異なるセクションに対して別々のビュー設定を行うことはできますか？**

[View settings](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベル（[Normal View](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)）で定義され、セクションごとではありません。そのため、ドキュメント全体に対して単一のパラメーターセットが適用されます。

**異なるユーザー向けに事前に異なるビュー状態を定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューアアプリケーションはユーザー設定を考慮する場合がありますが、ファイル自体は 1 つのビュー プロパティしか持ちません。

**テンプレートに事前定義された View Properties を埋め込み、新規プレゼンテーションを同じビュー構成で開くことは可能ですか？**

可能です。[view properties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込めば新規ドキュメントは同じ初期ビュー設定で開かれます。