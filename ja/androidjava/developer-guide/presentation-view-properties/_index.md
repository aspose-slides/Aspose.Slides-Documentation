---
title: Android でプレゼンテーション ビュー プロパティを取得および更新
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
- 単一ビュー
- バー状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java の Aspose.Slides でビュー プロパティを活用し、PPT、PPTX、ODP スライドのフォーマットをカスタマイズします—レイアウト、ズーム レベル、表示設定を調整できます。"
---
## **概要**

標準ビューは、スライド自体、サイドコンテンツ領域、下部コンテンツ領域の3つのコンテンツ領域で構成されています。  
各コンテンツ領域の配置に関するプロパティです。  
この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態で表示されます。

メソッド[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの標準ビュー プロパティへのアクセスが提供されました。  

[INormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとそれらの派生型、および列挙型[SplitterBarStateType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType) が追加されました。

## **INormalViewProperties について**

標準ビューのプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、標準ビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが 3 つのコンテンツ領域を持つ標準ビューではなく、全画面の単一コンテンツ領域を希望するかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のうちの一つをウィンドウ全体に表示することを選択できる場合があります。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーの表示状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に対して [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored) が適用されたときの、標準ビューの上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビューにおいて、領域が可変の復元サイズ（最小化でも最大化でもない）である場合、スライド領域（[getRestoredTop] の子の場合は幅、[getRestoredLeft] の子の場合は高さ）のサイズを指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内でビューを含むウィンドウのサイズ変更時に、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)プロパティにアクセスする方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // プレゼンテーションのビュー プロパティを復元
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **デフォルトズーム値の設定**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java は、プレゼンテーションを開いたときに既にズームが設定された状態になるよう、デフォルトズーム値の設定をサポートするようになりました。これは、プレゼンテーションの[ViewProperties]を設定することで実現できます。[getSlideViewProperties] および [getNotesViewProperties] はプログラムから設定可能です。このトピックでは、Aspose.Slides で[Presentation]の[View Properties]を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation] クラスのインスタンスを作成します。
2. [Presentation] の[View Properties] を設定します。
3. プレゼンテーションを [PPTX] ファイルとして保存します。  
以下の例では、スライドビューとノートビューのズーム値を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライド ビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノート ビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。  
[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) と [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。  
この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。  
グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。  
API ドキュメントの要件に従い、正の値を使用してください。

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

グリッドは[drawing guides](/slides/ja/androidjava/drawing-guides/)とは異なります。グリッド間隔は一定の間隔を制御し、描画ガイドは個別に位置付けられた水平または垂直のガイドラインです。描画ガイドを追加、移動、削除してもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーではスライドコンテンツとしてレンダリングされません。グリッド間隔を保存しても、エディタがグリッドを表示することが保証されるわけではなく、表示はビューアやエディタの設定に依存します。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。  
[IViewProperties.getShowComments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) と [IViewProperties.setShowComments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) を使用して、PowerPoint やその他の互換エディタでプレゼンテーションを開いたときにコメントを表示するかどうかの保存された設定を読み取ったり変更したりします。

この設定は保存されたビュー設定のみを制御し、コメントの追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作成者、位置、返信、ステータスは保持されます。コメント自体を変更する操作については [Presentation Comments](/slides/ja/androidjava/presentation-comments/) を参照してください。

以下の例は、コメントが含まれた既存の `comments.pptx` が必要です。現在の表示設定を出力し、コメントを非表示に設定し、コメントを削除せずに新しい PPTX を保存します。また、[IViewProperties.setLastView] と [ViewType.SlideView] を使用して、コメント表示と合わせて初期編集ビューを設定します。

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

この設定は、コメントが PDF、HTML、画像、ノート、配布資料のエクスポートに含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**なぜプレゼンテーションを再度開くとグリッドが表示されないのですか？**  
ファイルにはグリッド間隔が保存されていますが、表示はエディタ側で制御されます。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**  
いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても、保存されたグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションに異なるビュー設定を設定できますか？**  
[View settings] はプレゼンテーションレベル（[Normal View] / [Slide View]）で定義され、セクションごとには設定できません。そのため、ドキュメントが開かれる際には単一のパラメータセットが全体に適用されます。

**異なるユーザー向けに事前に異なるビュー状態を定義できますか？**  
いいえ。設定はファイルに保存されて共有されます。ビューアアプリケーションはユーザー設定を尊重する場合がありますが、ファイル自体には単一のビュー プロパティしか含まれていません。

**事前に View Properties を設定したテンプレートを用意すれば、新しいプレゼンテーションが同じ設定で開きますか？**  
はい。[view properties] がプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。