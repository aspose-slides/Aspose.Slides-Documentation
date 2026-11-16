---
title: Python でプレゼンテーションの表示プロパティを取得および更新する
linktitle: 表示プロパティ
type: docs
weight: 80
url: /ja/python-net/presentation-view-properties/
keywords:
- 表示プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタをスナップ
- 単一ビュー
- バー状態
- 寸法サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションの標準ビュー レイアウト、スライドおよびノートのズーム、グリッド間隔、コメントの表示設定を構成します。"
---
## **はじめに**

PowerPoint のノーマルビューでは、スライドはサムネイルやアウトライン用のサイドペインと、下部のノートペインの間に表示されます。Aspose.Slides for Python via .NET は、[Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) を通じてプレゼンテーションの保存された編集設定を公開します。これらには、ペインレイアウト、ズームレベル、グリッド間隔、コメントの表示が含まれます。

## **NormalViewProperties について**

[normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) を使用して [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) オブジェクトにアクセスします。[show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) はアウトラインでスライドタイトルの横にアイコンを表示するかどうかを制御します。[snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) はユーザーがサイドペインを狭めたときに最小化状態にスナップさせます。[prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) は全画面で1つのペインを表示することを優先するかどうかを示します。

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) はサイドペインとスライドの間の区切り線を制御します。[horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) はノートペイン上部の区切り線を制御します。どちらも [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) の `MINIMIZED`、`MAXIMIZED`、または `RESTORED` のいずれかの値を受け取ります。

<!-- visual-explanation:presentation-view-properties:start -->
[![概念的なエディタがサイドパネル、スライド領域、下部領域を、ラベル付きの垂直および水平スプリッタで区切っています。](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*ノーマルビューでは、垂直の区切り線がサイドペインの幅を制御し、水平の区切り線がノートペイン上部のスペースを制御します。*
<!-- visual-explanation:presentation-view-properties:end -->

## **NormalViewProperties の復元について**

区切り線が復元されると、[restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) はサイドペインの保存されたサイズを提供し、[restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) は上部スライド領域の保存されたサイズを提供します。両方とも [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) を公開します。その [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) プロパティは 0 から 100 のパーセンテージを受け取り、[auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) はウィンドウがリサイズされたときにエディタがサイズを調整するかどうかを制御します。

この例は既存のプレゼンテーションを更新します。水平の区切り線を復元し、[restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) を自動調整を有効にした状態で 80% に設定し、垂直の区切り線を最大化します。また、アウトラインビューで [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) を有効にします。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **デフォルトのズーム値を設定する**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) と [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) はエディタ用の個別のズーム設定を保持します。これらの設定はスライドのサイズ、スライドショーの再生、または画像エクスポートの解像度には影響しません。

この例は既存のプレゼンテーションを開き、スライドを編集ウィンドウに合わせるために [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) を有効にします。ノートページについては自動スケーリングを無効にし、[scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) を固定の 80% ズームに設定します。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **グリッド間隔を設定する**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) はプレゼンテーション全体の編集グリッド線間の距離を設定します。1インチ＝72ポイントの正の値を取ります。この例は既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

グリッドは固定間隔で繰り返されます。[描画ガイド](/slides/ja/python-net/drawing-guides/) は個別の水平または垂直位置を示します。どちらも編集補助であり、表示するエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポートではそれらは省かれます。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) はプレゼンテーションを開く際に互換性のあるエディタが使用する設定を保存します。コメント付きの既存プレゼンテーションについて、この例は現在の設定を出力し、コメントを非表示にしたコピーを保存します。また、[last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) を [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) に設定してコピーをスライドビューで開くようにします。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

コメントを非表示にすると、テキスト、作者、位置、返信、ステータスは保持されます。コメント自体を変更するには、[プレゼンテーションのコメント](/slides/ja/python-net/presentation-comments/) を参照してください。エクスポート設定は、PDF、HTML、画像、ノート、または配布資料にコメントを表示するかどうかを制御します。

## **よくある質問**

**プレゼンテーションを再度開くときにグリッドが非表示になるのはなぜですか？**

プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。ガイドの追加、移動、または削除を行ってもグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションで異なるビュー設定を持つことはできますか？**

いいえ。[Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション全体に適用されます。

**異なるユーザーごとに異なるビュー設定を保存できますか？**

ファイルはすべてのユーザーに共通のビュー設定の1セットのみを保存します。エディタはユーザーのローカル設定を適用することもあります。

**テンプレートにビュー設定を保存できますか？**

はい。テンプレートから作成されたプレゼンテーションは、テンプレートに保存されたビュー設定を継承します。