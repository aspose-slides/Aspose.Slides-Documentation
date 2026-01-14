---
title: Python でプレゼンテーションのビュー プロパティを取得・更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/python-net/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタをスナップ
- 単一ビュー
- バーの状態
- 寸法サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズーム レベル、表示設定を調整しましょう。"
---

{{% alert color="primary" %}} 

標準ビューは、スライド自体、サイド コンテンツ領域、下部コンテンツ領域の 3 つのコンテンツ領域で構成されます。これらのコンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) が追加され、プレゼンテーションの標準ビュー プロパティにアクセスできるようになりました。

[NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/)、[NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) クラスとその派生クラス、[SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

{{% /alert %}} 

## **INormalViewProperties について** 

標準ビューのプロパティを表します。

Property **ShowOutlineIcons** は、標準ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示するかどうかを指定します。

Property **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに、垂直スプリッタが最小化状態にスナップするかどうかを指定します。

Property **PreferSingleView** は、ユーザーが 3 つのコンテンツ領域を持つ標準ビューではなく、ウィンドウ全体に単一のコンテンツ領域を表示するフルウィンドウ表示を好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できる場合があります。

Property **VerticalBarState** と **HorizontalBarState** は、水平または垂直のスプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored** です。

Property **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** にそれぞれ **SplitterBarStateType.Restored** が適用されたときの、標準ビューにおける上部または側面スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、標準ビューにおけるスライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

Property **DimensionSize** は、RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さとして、スライド領域のサイズを指定します。

Property **AutoAdjust** は、ウィンドウのサイズを変更したときに、サイド コンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例では、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # プレゼンテーションのビュー プロパティを復元する
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **デフォルト ズーム値の設定** 

Aspose.Slides for Python via .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム値を設定できるようになりました。これは、プレゼンテーションの [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) を設定することで実現できます。スライド ビュー プロパティだけでなく、[notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) もプログラムで設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します
2. プレゼンテーションの [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) を設定します
3. プレゼンテーションを PPTX ファイルとして保存します

以下の例では、スライド ビューとノート ビューの両方のズーム値を設定しています。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュー プロパティを設定する
    presentation.view_properties.slide_view_properties.scale = 100 # スライドビューのズーム値（パーセンテージ）
    presentation.view_properties.notes_view_properties.scale = 100 # ノートビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ** 

**プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？**  

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーション レベル（[Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)）で定義されており、セクションごとではありません。そのため、ドキュメント全体に対して 1 つのパラメータセットが適用され、開くときに同じ設定が使用されます。

**異なるユーザー向けに異なるビュー状態を事前定義できますか？**  

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションはユーザーの好みを考慮できる場合がありますが、ファイル自体には 1 つのビュー プロパティ セットしか含まれません。

**事前定義されたビュー プロパティを含むテンプレートを作成し、新しいプレゼンテーションを同じ設定で開くことができますか？**  

はい。[view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) がプレゼンテーション レベルに保存されるため、テンプレートに埋め込んでおけば、そのテンプレートから作成した新しいドキュメントは同じ初期ビュー構成で開きます。