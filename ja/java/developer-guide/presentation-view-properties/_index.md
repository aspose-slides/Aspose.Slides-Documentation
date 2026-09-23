---
title: Java でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/java/presentation-view-properties/
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
- Java
- Aspose.Slides
description: Aspose.Slides for Java のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整します。
---
## **はじめに**

ノーマルビューは、スライド自体、サイドコンテンツ領域、ボトムコンテンツ領域の 3 つのコンテンツ領域で構成されます。これらのコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

Method[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションのノーマルビューのプロパティにアクセスできるようになりました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType) 列挙型が追加されました。

## **INormalViewProperties について**

ノーマルビューのプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、ノーマルビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが 3 つのコンテンツ領域を持つ標準的なノーマルビューよりも、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することが選択肢に入ります。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) および [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) にそれぞれ適用されたときの、ノーマルビューの上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

ノーマルビューの領域（`getRestoredTop` の子の場合は幅、`getRestoredLeft` の子の場合は高さ）が可変の復元サイズ（最小化でも最大化でもない）であるときのスライド領域のサイズを指定します。

Method[getDimensionSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、復元トップの子であれば幅、復元レフトの子であれば高さとして、スライド領域のサイズを指定します。

Method[getAutoAdjust](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

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

## **デフォルトのズーム値の設定**

{{% alert color="info" %}} 

Aspose.Slides for Java は、プレゼンテーションを開いたときに既にズームが設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定することで行えます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムで設定可能です。この項目では、Aspose.Slides で[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定します。  
1. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。  
   以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定する
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライドビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノートビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#getGridSpacing--) および [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API ドキュメントで要求されているように正の値を使用してください。

以下の例は、既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

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

グリッドは [drawing guides](/slides/ja/java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御し、描画ガイドは個別に配置された横方向または縦方向の整列線です。描画ガイドの追加、移動、削除はグリッド間隔を変更しません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、またはスライドショーとしてスライド コンテンツにレンダリングされません。グリッド間隔を保存しても、エディタがグリッドを表示することが保証されるわけではありません。表示はビューアやエディタの設定にも依存します。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [IViewProperties.getShowComments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#getShowComments--) と [IViewProperties.setShowComments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) は、PowerPoint やその他の互換エディタでプレゼンテーションを開く際にコメントを表示するかどうかの保存された設定を読み取ったり変更したりします。

この設定は保存されたビューのプリファレンスのみを制御します。コメントの追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作成者、位置、返信、ステータスは保持されます。コメント自体を変更する操作については、[Presentation Comments](/slides/ja/java/presentation-comments/) を参照してください。

以下の例は、コメントが含まれた既存の `comments.pptx` を前提としています。現在の可視性設定を表示し、コメントを非表示にするよう要求し、コメントを削除せずに新しい PPTX を保存します。また、[IViewProperties.setLastView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#setLastView-int-) と [ViewType.SlideView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewtype/#SlideView) を使用して、コメントの可視性とともに初期編集ビューを構成しています。

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定は、PDF、HTML、画像、ノート、配布資料へのエクスポート時にコメントが含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**  
ファイルはグリッド間隔を保存しますが、エディタ側がグリッドの表示可否を制御します。エディタのグリッド表示設定を確認してください。

**Does clearing drawing guides change the grid spacing?**  
いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔は変更されません。

**Can I set different view settings for different sections of a presentation?**  
[View settings](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベル（[Normal View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [Slide View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)）で定義され、セクションごとに設定できません。そのため、ドキュメントが開かれるときは単一のパラメータセットが全体に適用されます。

**Can I predefine different view states for different users?**  
いいえ。設定はファイルに保存され、すべてのユーザーで共有されます。ビューアアプリはユーザー設定を考慮することがありますが、ファイル自体は 1 つのビュー プロパティしか保持しません。

**Can I prepare a template with predefined View Properties so new presentations open the same way?**  
はい。[view properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、新規作成時に同じ初期ビュー構成で開くことができます。