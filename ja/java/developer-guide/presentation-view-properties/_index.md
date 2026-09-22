---
title: Javaでプレゼンテーションのビュー プロパティを取得・更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/java/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタ スナップ
- 単一ビュー
- バー 状態
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のビュー プロパティを活用して、PPT、PPTX、ODP 形式のスライドをカスタマイズし、レイアウト、ズームレベル、表示設定を調整できます。"
---
## **導入**

標準ビューは3つのコンテンツ領域で構成されます：スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。異なるコンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態で表示されます。

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの標準ビュー プロパティにアクセスできるようになりました。  

[INormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType) 列挙体が追加されました。

## **INormalViewProperties について**

標準ビュー プロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、標準ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 コンテンツ領域ビューではなく、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは1つのコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) および [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用された場合の、標準ビュー の上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビュー のスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合は高さ）が、可変の復元サイズ（最小化でも最大化でもない）である場合のサイズを指定します。

Method [getDimensionSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、復元された Top の子の場合は幅、復元された Left の子の場合は高さとして、スライド領域のサイズを指定します。

Method [getAutoAdjust](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

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

Aspose.Slides for Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトズーム値の設定をサポートするようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定することで実現できます。 [getSlideViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) はプログラムから設定可能です。このトピックでは、Aspose.Slides で [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定する方法を例で確認します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。下の例では、スライドビューとノートビューのズーム値を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライド ビューのズーム 値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノート ビューのズーム 値（パーセンテージ）

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#getGridSpacing--) と [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件に従い、正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、1/4 インチの間隔に設定して結果を保存します。

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

グリッドは [drawing guides](/slides/ja/java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御し、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。ガイドの追加、移動、削除はグリッド間隔を変更しません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、またはスライドショーとしてスライド コンテンツにレンダリングされることはありません。グリッド間隔を保存しても、エディタが必ずグリッドを表示するとは限りません。その表示可否はビューアやエディタの設定にも依存します。

## **よくある質問**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**  
ファイルはグリッド間隔を保存していますが、表示するかどうかはエディタが制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除するとグリッド間隔が変わりますか？**  
いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても、保存されたグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションごとに別々のビュー設定を設定できますか？**  
[View settings](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベル（[Normal View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)）で定義され、セクション単位ではありません。そのため、ドキュメント全体に対して単一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**  
できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションはユーザーの好みを考慮することがありますが、ファイル自体には 1 つのビュー プロパティしか含まれません。

**View Properties が事前定義されたテンプレートを作成し、新しいプレゼンテーションを同じ設定で開くことは可能ですか？**  
可能です。[view properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、そこから作成した新規ドキュメントは同じ初期ビュー構成で開かれます。