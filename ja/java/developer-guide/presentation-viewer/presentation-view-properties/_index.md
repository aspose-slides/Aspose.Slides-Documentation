---
title: プレゼンテーションビューのプロパティ
type: docs
url: /java/presentation-view-properties/
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、サイドコンテンツ領域、および下部コンテンツ領域の3つのコンテンツ領域で構成されています。異なるコンテンツ領域の位置に関連するプロパティ。この情報により、アプリケーションはビュー状態をファイルに保存でき、再オープンした際に表示が最後に保存された状態と同じになります。

メソッド [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) が追加され、プレゼンテーションの通常のビューのプロパティにアクセスできるようになりました。

[**INormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) インターフェイスとその子孫、[**SplitterBarStateType**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) 列挙型が追加されました。

{{% /alert %}} 


## **INormalViewPropertiesについて** #
通常のビューのプロパティを表します。

メソッド [**getShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [**setShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、通常のビュー モードのいずれかのコンテンツ領域でアウトラインコンテンツを表示する場合、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ [**getPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) と [**setPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが通常のビューの3つのコンテンツ領域よりもフルウィンドウの単一コンテンツ領域を表示することを好むかどうかを指定します。もし有効にすると、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択するかもしれません。

メソッド [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) と [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直のスプリッターバーが表示される状態を指定します。水平スプリッターバーはスライドをその下のコンテンツ領域から分離し、垂直スプリッターバーはスライドをサイドコンテンツ領域から分離します。可能な値は、[**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized)、[**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) および [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) です。

メソッド [**getRestoredLeft**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) と [**getRestoredTop**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) は、通常のビューの上部または側面スライド領域のサイズを指定します。[**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) 値が [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) および [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用される場合、これに従ってサイズを適用します。 


## **INormalViewPropertiesの復元について** 
通常のビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) の子としての幅、[getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) の子としての高さ）のサイズを指定します。この領域は可変の復元サイズ（最小化でも最大化でもない）の場合です。

メソッド [**getDimensionSize**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（復元された上部の子としての幅、復元された左の子としての高さ）を指定します。

メソッド [**getAutoAdjust**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内のビューを含むウィンドウをサイズ変更する際に、サイドコンテンツ領域のサイズが新しいサイズに補うべきかどうかを指定します。

以下に示す例では、[**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) のプロパティにアクセスする方法を示しています。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
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
{{% alert color="primary" %}} 

Aspose.Slides for Java では、プレゼンテーションを開いたときにズームが設定されるように、プレゼンテーションのデフォルトズーム値を設定することがサポートされるようになりました。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定することによって行うことができます。[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) は、プログラム的に設定することができます。このトピックでは、[Aspose.Slides](/slides/) の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定する方法を例を使って見ていきます。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX ](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。
   以下の例では、スライドビューとノートビューのズーム値を設定しました。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
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