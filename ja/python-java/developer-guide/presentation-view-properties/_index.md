---
title: Python via Java でプレゼンテーションのビュー プロパティを取得および更新
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
- シングル ビュー
- バーの状態
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のビュー プロパティを発見し、PPT、PPTX、ODP スライドをカスタマイズ—レイアウト、ズーム レベル、表示設定を調整します。"
---
## **はじめに**

標準ビューは、スライド自体、サイドコンテンツ領域、下部コンテンツ領域の3つのコンテンツ領域で構成されます。標準ビュー プロパティは、これらのコンテンツ領域の配置を記述します。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態でビューが表示されます。

メソッド[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties)が追加され、プレゼンテーションの標準ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/) と [NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/) クラス、および [SplitterBarStateType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

## **NormalViewProperties について**

標準ビュー プロパティを表します。

メソッド[getShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) と [setShowOutlineIcons](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) は、標準ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

メソッド[getSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) と [setSnapVerticalSplitter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) は、サイド領域が十分に小さいときに垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

メソッド[getPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) と [setPreferSingleView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) は、ユーザーが3つのコンテンツ領域を持つ標準ビューではなく、ウィンドウ全体に単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択できる場合があります。

メソッド[getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分割します。可能な値は[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Minimized)、[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Maximized)、および[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored)です。

メソッド[getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) と [getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) は、[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ja/python-java/aspose.slides/splitterbarstatetype/#Restored) が [getVerticalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) と [getHorizontalBarState](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) に適用されているときの、標準ビューの左側または上側スライド領域のサイズを指定します。

## **NormalViewProperties の復元について**

変数サイズ (最小化でも最大化でもない) の領域が適用されているときに、標準ビューのスライド領域 (幅は[getRestoredTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredTop) の子要素、 高さは[getRestoredLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) の子要素) のサイズを指定します。

メソッド[getDimensionSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) は、スライド領域のサイズ (幅は[getRestoredTop] の子要素、 高さは[getRestoredLeft] の子要素) を指定します。

メソッド[getAutoAdjust](https://reference.aspose.com/slides/ja/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションに対して[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNormalViewProperties) にアクセスする方法を示しています。

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

## **デフォルトズーム 値の設定**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は、プレゼンテーションを開いたときにすでに適用されるデフォルトズーム値の設定をサポートしています。これは、プレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定することで行えます。[getSlideViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getNotesViewProperties) はプログラムから構成可能です。このトピックでは、Aspose.Slides で[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の[View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定する方法を例とともに説明します。
{{% /alert %}}

ビュー プロパティを設定するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の[View Properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) を設定します。
1. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

以下の例では、スライド ビューとノート ビューの両方のズーム値を設定しています。

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

## **グリッド間隔の設定**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getGridSpacing) と [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setGridSpacing) メソッドは、基礎となる編集グリッドの間隔を読み取ったり変更したりします。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API のドキュメントで要求されているように、正の値を使用してください。

以下の例では、既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチ間隔に設定してから結果を保存します。

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

グリッドは[drawing guides](/slides/ja/python-java/drawing-guides/) とは異なります。グリッド間隔は一定の間隔を制御し、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。描画ガイドを追加、移動、または削除してもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてスライド コンテンツにレンダリングされることはありません。グリッド間隔を保存しても、エディタがグリッドを表示するかどうかは保証されません。表示はビューアまたはエディタの設定に依存します。

## **プレゼンテーションを開く際のコメントの表示/非表示**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.getShowComments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#getShowComments) と [ViewProperties.setShowComments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setShowComments) を使用して、PowerPoint やその他の互換エディタでプレゼンテーションを開いたときにコメントを表示するかどうかの保存された設定を読み取ったり変更したりします。

この設定は保存されたビューの設定のみを制御します。コメントの追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作者、位置、返信、ステータスは保持されます。コメント自体を変更する操作については、[Presentation Comments](/slides/ja/python-java/presentation-comments/) を参照してください。

以下の例では、コメントが含まれる既存の `comments.pptx` を使用します。現在の表示設定を出力し、コメントを非表示に要求してから、新しい PPTX を保存します。また、[ViewProperties.setLastView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setLastView) と [ViewType.SlideView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewtype/#SlideView) を組み合わせて、コメントの表示設定とともに初期編集ビューを構成しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この設定は、PDF、HTML、画像、ノート、ハンドアウトへのエクスポート時にコメントが含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示可否を制御します。エディタのグリッド表示設定を確認してください。

**Does clearing drawing guides change the grid spacing?**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても、保存されたグリッド間隔は変更されません。

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーションレベル (Normal View / Slide View) で定義され、セクションごとには設定できません。そのため、ドキュメント全体に同一のパラメータが適用されます。

**Can I predefine different view states for different users?**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションがユーザー固有の設定を尊重することはありますが、ファイル自体には 1 つのビュー プロパティセットしか含まれません。

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

はい。[view properties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントを作成したときに同じ初期ビュー構成で開くことができます。