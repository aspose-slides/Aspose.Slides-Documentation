---
title: プレゼンテーションビューのプロパティ
type: docs
url: /ja/php-java/presentation-view-properties/
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、サイドコンテンツ領域、ボトムコンテンツ領域の3つのコンテンツ領域で構成されています。さまざまなコンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションは、ファイルにビューステートを保存できるため、再オープンした際に、プレゼンテーションが最後に保存された時と同じ状態で表示されます。

メソッド [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--)が追加され、プレゼンテーションの通常のビューのプロパティにアクセスできるようになりました。 

[**INormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties)インターフェイスとその子孫、[**SplitterBarStateType**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType)列挙型が追加されました。

{{% /alert %}} 


## **INormalViewPropertiesについて** #
通常のビューのプロパティを表します。

メソッド [**getShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) と [**setShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、アプリケーションが通常のビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する場合にアイコンを表示するかどうかを指定します。

メソッド [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) と [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化された状態にスナップするかどうかを指定します。

プロパティ [**getPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) と [**setPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが 3 つのコンテンツ領域のある標準の通常ビューよりもフルウィンドウの単一コンテンツ領域を表示することを好むかどうかを指定します。これが有効になっている場合、アプリケーションはウィンドウ全体でコンテンツ領域のいずれかを表示することを選択できます。

メソッド [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) と [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平分割バーまたは垂直分割バーが表示されるべき状態を指定します。水平スプリッタバーはスライドをその下のコンテンツ領域から、垂直スプリッタバーはスライドをサイドコンテンツ領域から分離します。可能な値は、[**SplitterBarStateType::Minimized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized)、[**SplitterBarStateType::Maximized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized)、および [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored)です。

メソッド [**getRestoredLeft**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) と [**getRestoredTop**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) は、通常のビューの上部またはサイドスライド領域のサイズを指定します。[**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) の値が [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) および [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) に適用されます。

## **INormalViewPropertiesの復元について** 
通常のビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) の子の場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) の子の場合は高さ）のサイズを指定します。領域が変動する復元サイズ（最小化も最大化もされていない）の場合です。 

メソッド [**getDimensionSize**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（復元された上部の子の場合の幅、復元された左の子の場合の高さ）を指定します。

メソッド [**getAutoAdjust**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、ウィンドウサイズを変更する際にサイドコンテンツ領域のサイズが新しいサイズに補正されるべきかどうかを指定します。

以下の例では、[**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) のプロパティにアクセスする方法を示します。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);
    # プレゼンテーションのビュー設定を復元
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **デフォルトズーム値の設定**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、プレゼンテーションを開いた際にズームがすでに設定されるように、プレゼンテーションのデフォルト ズーム値を設定することをサポートしています。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定することで実行できます。[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムで設定できます。このトピックでは、[Aspose.Slides](/slides/ja/) の [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定する方法を例とともに見ていきます。

{{% /alert %}} 

ビューのプロパティを設定するために、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。
   以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $presentation = new Presentation();
  try {
    # プレゼンテーションのビュー設定
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100);// スライドビューのズーム値（パーセンテージ）

    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100);// ノートビューのズーム値（パーセンテージ）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```