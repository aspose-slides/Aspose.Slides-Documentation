---
title: Python via Java でプレゼンテーションのビュー プロパティを取得および更新する
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
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のビュー プロパティを活用して、PPT、PPTX、ODP スライドをカスタマイズし、レイアウト、ズームレベル、表示設定を調整します。"
---
## **はじめに**

通常ビューは、スライド自体、サイドコンテンツ領域、下部コンテンツ領域の 3 つのコンテンツ領域で構成されます。通常ビューのプロパティは、これらのコンテンツ領域の配置を記述します。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

メソッド [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties) が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/) と [NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/) クラス、および [SplitterBarStateType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/) 列挙型が追加されました。

## **NormalViewProperties について**

通常ビュー プロパティを表します。

メソッド [getShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際にアイコンを表示するかどうかを指定します。

メソッド [getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

メソッド [getPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) は、ユーザーが 3 つのコンテンツ領域を持つ標準の通常ビューではなく、単一のコンテンツ領域を全画面で表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することができます。

メソッド [getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) は、水平または垂直スプリッタバーが表示される状態を指定します。水平スプリッタバーはスライドとスライド下部のコンテンツ領域を分け、垂直スプリッタバーはスライドとサイドコンテンツ領域を分けます。可能な値は [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Maximized) および [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored) です。

メソッド [getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) は、[getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) が [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored) に設定されたときに、通常ビューのサイドまたは上部スライド領域のサイズをそれぞれ指定します。

## **NormalViewProperties の復元について**

通常ビューのスライド領域（[getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) の子としては幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) の子としては高さ）が可変の復元サイズ（最小化でも最大化でもない）であるときのサイズを指定します。

メソッド [getDimensionSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) は、スライド領域のサイズ（[getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) の子としては幅、[getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) の子としては高さ）を指定します。

メソッド [getAutoAdjust](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて補正されるかどうかを指定します。

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

## **デフォルトのズーム値を設定する**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java は、プレゼンテーションが開かれたときに既に適用された状態になるよう、デフォルトのズーム値の設定をサポートしています。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定することで実現できます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNotesViewProperties) はプログラムから構成可能です。このトピックでは、Aspose.Slides で [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の [View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定する方法をサンプルで示します。

{{% /alert %}}

ビュー プロパティを設定する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の [View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定します。
1. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。

以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
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

## **グリッド間隔を設定する**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getGridSpacing) と [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setGridSpacing) メソッドは、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API のドキュメントで要求されているように、正の値を使用してください。

以下の例は、既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

グリッドは [drawing guides](/slides/ja/python-java/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御するのに対し、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。描画ガイドを追加、移動、削除してもグリッド間隔は変わりません。

グリッドと描画ガイドはどちらも編集支援ツールです。PDF、画像、SVG、スライドショーとしてスライド コンテンツにレンダリングされることはありません。グリッド間隔をファイルに保存しても、エディタが必ず表示するわけではなく、表示の有無はビューアまたはエディタの設定に依存します。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルにはグリッド間隔が保存されていますが、エディタがグリッドの表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除するとグリッド間隔が変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を行うことはできますか？**

[View settings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーション レベルで定義され（[Normal View](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getSlideViewProperties)）、セクション単位ではありません。そのため、ドキュメント全体に同一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、共有されます。ビューア アプリケーションはユーザーの好みを考慮できる場合がありますが、ファイル自体には 1 つのビュー プロパティしか含まれません。

**テンプレートに事前定義された View Properties を埋め込んで、新しいプレゼンテーションが同じ方法で開くようにできますか？**

できます。ビュー プロパティはプレゼンテーション レベルで保存されるため、テンプレートに埋め込めば、新規ドキュメントを作成したときに同じ初期ビュー構成が適用されます。