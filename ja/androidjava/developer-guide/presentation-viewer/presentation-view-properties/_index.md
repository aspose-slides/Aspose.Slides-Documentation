---
title: プレゼンテーションビューのプロパティ
type: docs
url: /ja/androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、サイドコンテンツ領域、および下部コンテンツ領域の3つのコンテンツ領域で構成されています。さまざまなコンテンツ領域の位置に関するプロパティがあります。この情報により、アプリケーションはビューの状態をファイルに保存できるため、再オープンしたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

メソッド [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常ビューのプロパティにアクセスできるようになりました。 

[**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties)、 [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその 子孫、 [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) 列挙型が追加されました。

{{% /alert %}} 


## **INormalViewProperties について** #
通常のビューのプロパティを表します。

メソッド [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常のビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する場合にアプリケーションがアイコンを表示するかどうかを指定します。

メソッド [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さいときに縦分割線が最小化された状態にスナップするかどうかを指定します。

プロパティ [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが3つのコンテンツ領域を持つ標準の通常のビューよりもフルウィンドウの単一コンテンツ領域を優先して表示するかどうかを指定します。これが有効な場合、アプリケーションはウィンドウ全体にコンテンツ領域の1つを表示することを選択できます。

メソッド [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直の分割線が表示される状態を指定します。水平分割線はスライドを下のコンテンツ領域から分離し、垂直分割線はスライドをサイドコンテンツ領域から分離します。考えられる値は、[**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)、[**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)、および [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、通常ビューのスライド領域の上部または側面のサイズを指定します。[**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 値が [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) および [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用されるときのことです。


## **INormalViewProperties の復元について** 
変数復元サイズ（最小化も最大化もされていない）である場合の通常ビューのスライド領域のサイズ（[getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合の幅、[getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合の高さ）を指定します。 

メソッド [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（復元されたトップの子の場合の幅、復元された左の子の場合の高さ）を指定します。

メソッド [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内のビューを含むウィンドウのサイズを変更するときにサイドコンテンツ領域のサイズが新しいサイズに補正されるべきかどうかを指定します。

以下に例を示します。プレゼンテーションに対する [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示します。

```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
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

## **デフォルトのズーム値を設定する**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、プレゼンテーションが開かれるときにズームがすでに設定されるように、プレゼンテーションのデフォルトのズーム値を設定することをサポートしています。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) を設定することで行うことができます。[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) と [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) は、プログラムで設定できます。このトピックでは、[Aspose.Slides](/slides/ja/) 内の [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) を設定する方法を例を挙げて説明します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。
   以下に示す例では、スライドビューとノートビューのズーム値を設定しています。

```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
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