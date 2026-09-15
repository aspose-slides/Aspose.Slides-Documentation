---
title: Python via Java でプレゼンテーション ビュー プロパティを取得・更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/python-java/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バー状態
- 寸法サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のビュー プロパティを活用して、PPT、PPTX、ODP スライドをカスタマイズし、レイアウト、ズームレベル、表示設定を調整できます。"
---
## **はじめに**

標準ビューは、スライド自体、サイド コンテンツ領域、そして下部コンテンツ領域の 3 つのコンテンツ領域で構成されます。標準ビュー プロパティは、これらのコンテンツ領域の位置を記述します。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

プレゼンテーションの標準ビュー プロパティにアクセスできるよう、[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties) メソッドが追加されました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/) と [NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/) クラス、および [SplitterBarStateType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

## **NormalViewProperties について**

標準ビュー プロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) は、標準ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さくなったときに垂直スプリッターを最小化状態にスナップすべきかどうかを指定します。

メソッド [getPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) は、ユーザーが 3 つのコンテンツ領域を持つ標準ビューではなく、ウィンドウ全体で単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できます。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) は、水平または垂直スプリッターバーの表示状態を指定します。水平スプリッターバーはスライドとスライド下部のコンテンツ領域を分割し、垂直スプリッターバーはスライドとサイド コンテンツ領域を分割します。可能な値は、[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored) の値がそれぞれ [getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) に適用された場合の、標準ビューの上部または側面スライド領域のサイズを指定します。

## **NormalViewProperties の復元について**

標準ビューのスライド領域（[getRestoredTop] の子の場合は幅、[getRestoredLeft] の子の場合は高さ）のサイズを、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) は、スライド領域のサイズ（[getRestoredTop] の子の場合は幅、[getRestoredLeft] の子の場合は高さ）を指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) は、アプリケーション内でビューを含むウィンドウのサイズ変更時に、サイド コンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションに対して [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties) にアクセスする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # プレゼンテーションのビュー プロパティを復元します。
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **デフォルトのズーム値の設定**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は、プレゼンテーションが開かれたときに既に適用されるデフォルトのズーム値の設定をサポートしています。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定することで行えます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNotesViewProperties) はプログラムで構成可能です。このトピックでは、例を用いて [Aspose.Slides](/slides/ja/) における [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の [View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) の設定方法を示します。
{{% /alert %}}

ビュー プロパティを設定するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の [View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # プレゼンテーションのビュー プロパティを設定します。
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # スライドビューのズーム パーセンテージ。
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # ノートビューのズーム パーセンテージ。

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getSlideViewProperties)）、セクションごとではありません。そのため、開く際には単一のパラメータ セットが文書全体に適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存されて共有されます。ビューア アプリケーションはユーザーの設定を尊重できる場合がありますが、ファイル自体には 1 つのビュー プロパティ セットしか含まれません。

**事前に View Properties を設定したテンプレートを用意し、新しいプレゼンテーションを同じ方法で開くことはできますか？**

はい。[view properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおくことで、同じ初期ビュー構成で新しい文書を作成できます。