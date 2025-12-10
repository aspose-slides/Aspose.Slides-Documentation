---
title: Javaでプレゼンテーションのビュー プロパティを取得および更新
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
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のビュー プロパティを使用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整します。"
---

{{% alert color="primary" %}} 

通常ビューは 3 つのコンテンツ領域から構成されます: スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。これらのコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開くとプレゼンテーションが最後に保存された時と同じ状態でビューが表示されます。

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビュー プロパティへのアクセスを提供します。 

インターフェイス [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) とその派生、列挙型 [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

通常ビューのプロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 コンテンツ領域による通常ビューよりも、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分離します。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) および [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用された場合の、通常ビューの上部またはサイド スライド領域のサイズを指定します。

## **INormalViewProperties の復元について** 

通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合は高さ）のサイズを、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。 

Method [getDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（復元Top の子の場合は幅、復元Left の子の場合は高さ）を指定します。

Method [getAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウのサイズ変更時にビューを含むウィンドウの新しいサイズに合わせてサイド コンテンツ領域のサイズが補正されるべきかどうかを指定します。

以下の例では、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティへのアクセス方法を示しています。
```java
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

{{% alert color="primary" %}} 

Aspose.Slides for Java は、プレゼンテーションを開いたときにズームが既に設定されているように、デフォルト ズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムから設定可能です。このトピックでは、[Aspose.Slides](/slides/ja/) における [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。以下の例では、スライドビューとノートビューのズーム値の両方を設定しています。
```java
Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライドビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノートビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **よくある質問**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [Slide View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)）、セクション単位ではありません。そのため、開くときにドキュメント全体に単一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存され共有されます。ビューア アプリケーションはユーザーの好みを尊重できる場合がありますが、ファイル自体には 1 つのビュー プロパティ セットしか含まれません。

**事前定義された View Properties を持つテンプレートを用意すれば、新しいプレゼンテーションが同じ方法で開くようにできますか？**

はい。[view properties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。