---
title: Python でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/python-net/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バー状態
- ディメンションサイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズームレベル、表示設定を調整します。"
---
## **導入**

標準ビューは 3 つのコンテンツ領域で構成されています：スライド自体、サイド コンテンツ領域、そして下部コンテンツ領域です。これらの領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

プロパティ [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/normal_view_properties/) が追加され、プレゼンテーションの標準ビュー プロパティにアクセスできるようになりました。

クラス [NormalViewProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/normalviewrestoredproperties/) とその子孫クラス、enum [SplitterBarStateType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/splitterbarstatetype/) が追加されました。

## **INormalViewProperties について** 

標準ビュー プロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが 3 つのコンテンツ領域を持つ標準ビューではなく、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体に 1 つのコンテンツ領域を表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーがどの状態で表示されるべきかを指定します。水平スプリッタ バーはスライドと下部コンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分割します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** が **SplitterBarStateType.Restored** に設定された場合に、標準ビューのサイド領域または上部領域のサイズを指定します。

## **Restoring INormalViewProperties について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、標準ビューのスライド領域（RestoredTop の子は幅、RestoredLeft の子は高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（RestoredTop の子は幅、RestoredLeft の子は高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # プレゼンテーションのビュー プロパティを復元する
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **デフォルトズーム値の設定**

Aspose.Slides for Python via .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム 値を設定できるようになりました。これはプレゼンテーションの [view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) を設定することで実現できます。スライド ビュー プロパティだけでなく、[notes_view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/notes_view_properties/) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. クラス [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成する
1. プレゼンテーションの [view properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/) を設定する
1. プレゼンテーションを PPTX ファイルとして保存する

以下の例では、スライド ビューとノート ビューのズーム値を設定しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュー プロパティを設定する
    presentation.view_properties.slide_view_properties.scale = 100 # スライド ビューのズーム値（パーセンテージ）
    presentation.view_properties.notes_view_properties.scale = 100 # ノート ビューのズーム値（パーセンテージ）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **グリッド間隔の設定**

[Presentation.view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。プロパティ [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/grid_spacing/) は、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API ドキュメントで要求されているように正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

グリッドは [描画ガイド](/slides/ja/python-net/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御し、描画ガイドは個別に配置された水平または垂直の位置合わせ線です。描画ガイドの追加、移動、削除はグリッド間隔を変更しません。

グリッドも描画ガイドも編集支援機能です。PDF、画像、SVG、スライドショーとしてレンダリングされるスライド コンテンツの一部にはなりません。グリッド間隔を保存しても、エディタがグリッドを表示するかはエディタまたはビューアの設定次第です。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示可否を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を持たせることはできますか？**

[ビュー設定](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション レベルで定義され（[標準ビュー](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/normal_view_properties/)/[スライドビュー](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/slide_view_properties/) ）、セクション単位ではありません。そのため、ドキュメント全体に同一のパラメータが適用されます。

**ユーザーごとに異なるビュー状態を事前定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションはユーザー設定を尊重することがありますが、ファイル自体は単一のビュー プロパティしか保持しません。

**テンプレートに事前定義されたビュー プロパティを埋め込み、新規プレゼンテーションが同じ設定で開くようにできますか？**

できます。[ビュー プロパティ](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントは同じ初期ビュー構成で作成されます。