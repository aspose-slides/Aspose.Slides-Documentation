---
title: Javaでプレゼンテーションのビュー プロパティを取得および更新する
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
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のビュー プロパティを使って、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整します。"
---
## **はじめに**

通常表示は 3 つのコンテンツ領域で構成されます: スライド自体、側面のコンテンツ領域、そして下部のコンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

メソッド[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)は、プレゼンテーションの通常表示プロパティへアクセスできるように追加されました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType) 列挙体が追加されました。

## **INormalViewProperties について**

通常表示のプロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常表示モードの任意のコンテンツ領域でアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、側面領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ[getPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [setPreferSingleView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが 3 つのコンテンツ領域を持つ標準的な通常表示ではなく、ウィンドウ全体で単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することができます。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーがどの状態で表示されるべきかを指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドと側面コンテンツ領域を分離します。指定できる値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、[getVerticalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) がそれぞれ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SplitterBarStateType#Restored) の値になる場合の、通常表示における上部または側面スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、通常表示におけるスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子であれば幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子であれば高さ）のサイズを指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、復元された Top の子であれば幅、復元された Left の子であれば高さとして、スライド領域のサイズを指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/ja/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウ内のビューがリサイズされたときに、側面コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるべきかどうかを指定します。

以下の例は、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示しています。

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

Aspose.Slides for Java は、プレゼンテーションを開いたときにズームがすでに設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) はプログラムから設定可能です。このトピックでは、[Aspose.Slides](/slides/ja/) で [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定する方法を例で示します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ViewProperties) を設定します。
3. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。  
   以下の例では、スライド ビューとノート ビューの両方のズーム値を設定しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのビュー プロパティを設定する
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // スライド表示のズーム値（パーセンテージ）
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // ノート表示のズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

### プレゼンテーションの異なるセクションに対して異なる表示設定を設定できますか？

[View settings](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーション レベル（[Normal View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getNormalViewProperties--) / [Slide View](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)）で定義されており、セクションごとに設定できません。そのため、ドキュメント全体に対して単一のパラメータセットが適用されます。

### ユーザーごとに異なるビュー状態を事前に定義できますか？

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションがユーザーの好みを考慮することはありますが、ファイル自体には 1 つのビュー プロパティしか含まれません。

### 新しいプレゼンテーションが同じ方法で開くように、事前定義された View Properties を持つテンプレートを用意できますか？

できます。[view properties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getViewProperties--) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、そのテンプレートから作成した新規ドキュメントは同じ初期ビュー構成で開きます。