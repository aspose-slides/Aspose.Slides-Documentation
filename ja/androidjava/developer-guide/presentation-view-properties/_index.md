---
title: Androidでプレゼンテーションの表示プロパティを取得および更新する
linktitle: 表示プロパティ
type: docs
weight: 80
url: /ja/androidjava/presentation-view-properties/
keywords:
- 表示プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バー状態
- ディメンションサイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java の表示プロパティを活用し、PPT、PPTX、ODP スライドのフォーマットをカスタマイズ—レイアウト、ズームレベル、表示設定を調整します。"
---

{{% alert color="primary" %}} 

通常ビューは3つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。これらのコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにビューが最後に保存された状態と同じになります。

メソッド[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。  

[INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) 列挙型が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

通常ビューのプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードのコンテンツ領域のいずれかでアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さいときに垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが 3 つのコンテンツ領域を持つ標準の通常ビューよりも、ウィンドウ全体で単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域の一つをウィンドウ全体に表示することを選択できる場合があります。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタバーが表示される状態を指定します。水平スプリッタバーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタバーはスライドとサイドコンテンツ領域を分離します。可能な値は、[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)、および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用されたときの、通常ビューの上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合は高さ）のサイズを、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内でビューを含むウィンドウのサイズを変更したときに、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるべきかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)プロパティにアクセスする方法を示しています。
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


## **デフォルトのズーム値を設定する**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、プレゼンテーションを開いたときにすでにズームが設定された状態になるように、デフォルトズーム値の設定をサポートするようになりました。これはプレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) と [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムで設定可能です。このトピックでは、例を用いて[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) を[Aspose.Slides](/slides/ja/)で設定する方法を見ていきます。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) の[View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) を設定します。
1. [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとしてプレゼンテーションを書き出します。以下の例では、スライドビューとノートビューのズーム値を設定しています。
```java
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


## **よくある質問**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベルで定義されており（[Normal View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))、セクションごとではありません。したがって、開くときには単一のパラメータセットが文書全体に適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存され、共有されます。ビューアアプリはユーザーの設定を尊重する場合がありますが、ファイル自体は単一のビュー プロパティセットを含んでいます。

**事前に定義された View Properties を持つテンプレートを作成し、新しいプレゼンテーションを同じ設定で開くことはできますか？**

はい。[view properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。