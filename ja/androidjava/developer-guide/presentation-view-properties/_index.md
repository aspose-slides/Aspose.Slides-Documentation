---
title: Android でプレゼンテーションの表示プロパティを取得および更新
linktitle: 表示プロパティ
type: docs
weight: 80
url: /ja/androidjava/presentation-view-properties/
keywords: 
- 表示プロパティ
- 標準ビュー
- アウトラインコンテンツ
- アウトラインアイコン
- 縦スプリッタのスナップ
- 単一ビュー
- バーの状態
- 次元サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java の表示プロパティを活用して、PPT、PPTX、ODP 形式のスライドをカスタマイズ—レイアウト、ズームレベル、表示設定を調整します。"
---
## **概要**

通常ビューは、スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域の3つの領域で構成されます。これらの領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

Method[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその派生、および[SplitterBarStateType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType) 列挙体が追加されました。

## **INormalViewProperties の概要**

通常ビューのプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常ビュー モードのいずれかのコンテンツ領域にアウトラインコンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の3領域による通常ビューではなく、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できる場合があります。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は、[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SplitterBarStateType#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用された場合の、通常ビューにおける上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

通常ビューにおいて、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に、スライド領域（[getRestoredTop] の子の場合は幅、[getRestoredLeft] の子の場合は高さ）のサイズを指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内でビューを含むウィンドウのサイズ変更時に、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整すべきかどうかを指定します。

以下の例は、プレゼンテーションの[ViewProperties.getNormalViewProperties]プロパティにアクセスする方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // プレゼンテーションの表示プロパティを復元する
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

Aspose.Slides for Android via Java は、プレゼンテーションを開いたときにズームが既に設定された状態になるように、デフォルトのズーム値を設定できるようになりました。これは、プレゼンテーションの[ViewProperties]を設定することで実現できます。[getSlideViewProperties] と [getNotesViewProperties] をプログラムから設定できます。このトピックでは、例を用いて[Aspose.Slides](/slides/ja/) で[Presentation]の[View Properties]を設定する方法を示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
1. [Presentation] の[View Properties] を設定します。
1. プレゼンテーションを [PPTX] ファイルとして保存します。以下の例では、スライド ビューとノート ビューのズーム値を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションの表示プロパティを設定する
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライドビューのズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノートビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

### プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？

View settings はプレゼンテーションレベルで定義され、セクションごとではなく、プレゼンテーション全体に対して単一のパラメータセットが適用されます。

### ユーザーごとに異なるビュー状態を事前に定義できますか？

いいえ。設定はファイルに保存され、共有されます。ビューア アプリケーションはユーザー設定を尊重する場合がありますが、ファイル自体には単一のビュー プロパティが含まれます。

### 予め定義された View Properties を持つテンプレートを作成し、新しいプレゼンテーションが同じ設定で開くようにできますか？

はい。[view properties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getViewProperties--) がプレゼンテーションレベルで保存されているため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。