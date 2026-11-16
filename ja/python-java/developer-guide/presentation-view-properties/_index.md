---
title: Python（Java 経由）でプレゼンテーションの表示プロパティを取得および更新する
linktitle: 表示プロパティ
type: docs
weight: 80
url: /ja/python-java/presentation-view-properties/
keywords:
- 表示プロパティ
- 標準ビュー
- アウトラインコンテンツ
- アウトラインアイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バー状態
- 次元サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションの標準ビューのレイアウト、スライドおよびノートのズーム、グリッド間隔、コメントの表示を構成します。"
---
## **概要**

PowerPoint の標準ビューでは、スライドはサムネイルまたはアウトライン用のサイドペインと下部のノートペインの間に表示されます。Aspose.Slides for Python via Java は、[Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) を介してプレゼンテーションの保存された編集設定を公開します。これらには、ペインのレイアウト、ズームレベル、グリッド間隔、コメントの表示が含まれます。

## **NormalViewProperties について**

[getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) を使用して [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) クラスにアクセスします。[setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) はアウトラインでスライドタイトルの横にアイコンを表示するか制御します。[setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) はユーザーがサイドペインを狭めたときに最小化状態にスナップさせます。[setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) はウィンドウ全体で 1 つのペインを表示することを優先するか示します。

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) はサイドペインとスライドの間の区切りバーを制御します。[setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) はノートペイン上部の区切りバーを制御します。どちらも `Minimized`、`Maximized`、`Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **NormalViewProperties の復元について**

区切りバーが復元されると、[getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) はサイドペインの保存されたサイズを、[getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) は上部スライド領域の保存されたサイズを提供します。どちらも [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) のインスタンスを返します。その [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) メソッドは 0〜100 の割合を受け取り、[setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) はウィンドウサイズ変更時にエディタがサイズを自動調整するかを制御します。

この例は既存のプレゼンテーションを更新します。水平区切りバーを復元し、[getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) が返すサイズを自動調整有効で 80% に設定し、垂直区切りバーを最大化します。また、[setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) を呼び出してアウトラインビューにアイコンを表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **デフォルトのズーム値を設定する**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) と [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) はエディタ用に個別のズーム設定を保存します。これらの設定はスライドのサイズ、スライドショーの再生、画像エクスポートの解像度には影響しません。

この例は既存のプレゼンテーションを開き、[setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) を呼び出してスライドを編集ウィンドウに合わせます。ノートページについては自動スケーリングを無効にし、[setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) を呼び出して固定の 80% ズームを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **グリッド間隔の設定**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) はプレゼンテーション全体の編集グリッド線間の距離を設定します。単位はポイントで、1 インチは 72 ポイントです。この例は既存のプレゼンテーションで現在の間隔を表示し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

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

グリッドは固定間隔で繰り返されます。[描画ガイド](/slides/ja/python-java/drawing-guides/) は個々の水平または垂直位置をマークします。どちらも編集支援機能で、表示できるエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポートでは除外されます。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) は、対応するエディタがプレゼンテーションを開く際に使用する設定を保存します。コメント付きの既存プレゼンテーションについて、この例は現在の設定を表示し、コメントを非表示にしたコピーを保存します。また、[setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) を [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) と共に呼び出すことで、コピーがスライドビューで開かれるようにします。

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

コメントを非表示にしても、テキスト、作者、位置、返信、ステータスは保持されます。コメントそのものを変更するには、[プレゼンテーションのコメント](/slides/ja/python-java/presentation-comments/) を参照してください。エクスポート設定は、PDF、HTML、画像、ノート、ハンドアウトでコメントが表示されるかどうかを制御します。

## **FAQ**

**プレゼンテーションを再度開くとグリッドが非表示になるのはなぜですか？**

プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**

いいえ。ガイドを追加、移動、削除してもグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションでビュー設定を変えることはできますか？**

いいえ。[Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) はプレゼンテーション全体に適用されます。

**ユーザーごとに異なるビュー設定を保存できますか？**

ファイルは全員に対して 1 つのビュー設定セットしか保存しません。エディタはユーザーのローカル設定を適用することがあります。

**テンプレートにビュー設定を保存できますか？**

はい。テンプレートから作成されたプレゼンテーションは、テンプレートに保存されたビュー設定を継承します。