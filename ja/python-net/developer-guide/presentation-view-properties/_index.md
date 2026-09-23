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
- バーの状態
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズします。レイアウト、ズーム レベル、表示設定を調整できます。"
---
## **概要**

通常ビューはスライド本体、サイドコンテンツ領域、ボトムコンテンツ領域の 3 つのコンテンツ領域で構成されます。各コンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

プロパティ [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/normal_view_properties/) が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/normalviewrestoredproperties/) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

## **INormalViewProperties について**

通常ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、通常ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際にアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが標準の 3 つのコンテンツ領域を持つ通常ビューではなく、ウィンドウ全体で単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーの表示状態を指定します。水平スプリッタ バーはスライドとその下のコンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分割します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** が **SplitterBarStateType.Restored** の場合に、通常ビューの上部または側面スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）であるときの、通常ビューのスライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて自動調整されるかどうかを指定します。

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

## **デフォルトのズーム値を設定する**

Aspose.Slides for Python via .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの [view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) を設定することで行えます。スライド ビュー プロパティおよび [notes_view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/notes_view_properties/) はプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成する
2. プレゼンテーションの [view properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/) を設定する
3. プレゼンテーションを PPTX ファイルとして保存する

以下の例では、スライド ビューとノート ビューの両方のズーム値を設定しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュー プロパティを設定する
    presentation.view_properties.slide_view_properties.scale = 100 # スライド ビューのズーム値（パーセンテージ）
    presentation.view_properties.notes_view_properties.scale = 100 # ノート ビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **グリッド間隔を設定する**

[Presentation.view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.grid_spacing](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/grid_spacing/) プロパティは、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイント単位で指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件に従い、正の値を使用してください。

次の例は既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

グリッドは [drawing guides](/slides/ja/python-net/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御し、描画ガイドは個別に配置された水平または垂直の位置合わせラインです。描画ガイドの追加、移動、削除はグリッド間隔を変更しません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてレンダリングされることはなく、グリッド間隔を保存してもエディタが必ず表示するわけではありません。表示はビューアやエディタの設定に依存します。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[Presentation.view_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[ViewProperties.show_comments](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/show_comments/) を読み取るか変更して、PowerPoint やその他の対応エディタでプレゼンテーションを開く際にコメントを表示するかどうかの設定を保存します。

この設定は保存されたビューの優先設定のみを制御し、コメントそのものを追加、削除、編集、解決するものではありません。コメントを非表示にしても、内容、作成者、位置、返信、ステータスは保持されます。コメントそのものを操作する方法は [Presentation Comments](/slides/ja/python-net/presentation-comments/) を参照してください。

以下の例は、コメントを含む既存の `comments.pptx` を使用し、現在の表示設定を出力した後、コメントを非表示にし、新しい PPTX を保存します。また、[ViewProperties.last_view](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/last_view/) を [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewtype/) に設定して、コメントの可視性とともに初期編集ビューを構成しています。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

この設定は、PDF、HTML、画像、ノート、配布資料へのエクスポート時にコメントが含まれるかどうかを決定しません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示・非表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドをクリアしても保存されたグリッド間隔は変更されません。

**プレゼンテーションのセクションごとに異なるビュー設定を持たせられますか？**

[View settings](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション レベルで定義されるため（[Normal View](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/slide_view_properties/)）、セクションごとに別々のパラメータを設定することはできません。開くときはドキュメント全体に同一のビュー設定が適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーション側でユーザー固有の設定を尊重することはありますが、ファイル自体は 1 つのビュー プロパティしか保持しません。

**テンプレートに事前定義されたビュー プロパティを埋め込んで、新規プレゼンテーションを同じビューで開くことはできますか？**

可能です。[view properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込めば新規ドキュメントも同じ初期ビュー構成で作成できます。