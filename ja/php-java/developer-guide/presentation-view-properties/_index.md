---
title: PHP でプレゼンテーションのビュー プロパティを取得および更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/php-java/presentation-view-properties/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のビュー プロパティを活用して、PPT、PPTX、ODP スライドのフォーマットをカスタマイズし、レイアウト、ズーム レベル、表示設定を調整できます。"
---

{{% alert color="primary" %}} 

標準ビューは 3 つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態で表示されます。

メソッド [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) は、プレゼンテーションの標準ビュー プロパティにアクセスするために追加されました。

[INormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) インターフェイスとそれらの派生型、[SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) 列挙型が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

標準ビューのプロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) および [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) は、標準ビュー モードのいずれかのコンテンツ領域にアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) および [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) および [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) は、ユーザーが標準の 3 つのコンテンツ領域を持つビューではなく、ウィンドウ全体で単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のうちの 1 つをウィンドウ全体に表示することを選択できる場合があります。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) と [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は、[SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized)、[SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) および [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) と [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) は、[getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) および [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) に対して [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) の値が適用された場合の、標準ビューにおける上部または側面スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビューにおけるスライド領域のサイズ（[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) の子である場合は幅、[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) の子である場合は高さ）を、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) は、スライド領域のサイズ（restoredTop の子である場合は幅、restoredLeft の子である場合は高さ）を指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) は、アプリケーション内でビューを含むウィンドウのサイズ変更時に、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるべきかどうかを指定します。

以下の例では、プレゼンテーションの [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) プロパティにアクセスする方法を示します。
```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # プレゼンテーションのビュー プロパティを復元
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **デフォルト ズーム値の設定**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、プレゼンテーションを開いたときに既にズームが設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) および [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) もプログラムから設定可能です。このトピックでは、例を用いて [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を [Aspose.Slides](/slides/ja/) で設定する方法を説明します。

{{% /alert %}} 

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) の [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。
   以下の例では、スライドビューおよびノートビューのズーム値を設定しています。
```php
  $presentation = new Presentation();
  try {
    # プレゼンテーションのビュー プロパティを設定
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // スライドビューのズーム値（パーセンテージ）
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // ノートビューのズーム値（パーセンテージ）

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)）、セクション単位ではありません。そのため、開く際にはドキュメント全体に単一のパラメータセットが適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存されて共有されます。ビューア アプリケーションはユーザーの好みを考慮することはありますが、ファイル自体には 1 つのビュー プロパティセットしか含まれていません。

**事前定義された View Properties を持つテンプレートを作成し、新しいプレゼンテーションが同じように開くようにできますか？**

はい。[view properties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) はプレゼンテーション レベルに保存されるため、テンプレートに埋め込んでおくことで、同じ初期ビュー構成で新しいドキュメントを作成できます。