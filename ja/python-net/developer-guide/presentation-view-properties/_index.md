---
title: Python でプレゼンテーションのビュー プロパティを取得および更新
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
- バー の状態
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズします—レイアウト、ズームレベル、表示設定を調整できます。"
---

{{% alert color="primary" %}} 

標準ビューは3つのコンテンツ領域で構成されます：スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態でビューが復元されます。

プロパティ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) が追加され、プレゼンテーションの標準ビュー プロパティへのアクセスが可能になりました。

[INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) インターフェイスとその子孫である [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

{{% /alert %}} 

## **INormalViewProperties について** 

標準ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが標準の3領域ビューではなく、全画面の単一コンテンツ領域を好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタバーが表示される状態を指定します。水平スプリッタバーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタバーはスライドとサイドコンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合の、標準ビューにおける上部またはサイドのスライド領域のサイズを指定します。

## **INormalViewProperties の復元について** 

標準ビューにおけるスライド領域のサイズ（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）を、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、アプリケーション内でビューを含むウィンドウのサイズを変更した際に、サイドコンテンツ領域のサイズが新しいサイズに合わせて補正されるべきかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

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


## **デフォルトのズーム値を設定** 

Aspose.Slides for Python via .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値を設定する機能をサポートしました。これはプレゼンテーションの [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) を設定することで実現できます。スライド ビュー プロパティおよび [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成する
1. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) を設定する
1. プレゼンテーションを PPTX ファイルとして保存する

以下の例では、スライド ビューとノート ビューのズーム値を設定しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュー プロパティを設定する
    presentation.view_properties.slide_view_properties.scale = 100 # スライドビューのズーム値（パーセンテージ）
    presentation.view_properties.notes_view_properties.scale = 100 # ノートビューのズーム値（パーセンテージ） 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ** 

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**  

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーションレベルで定義されており（[Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)）、セクション単位ではありません。そのため、開く際にはドキュメント全体に単一のパラメータセットが適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**  

いいえ。設定はファイルに保存されて共有されます。ビューアー アプリケーションはユーザーの設定を尊重することがありますが、ファイル自体は 1 つのビュー プロパティのセットしか含みません。

**事前にビュー プロパティが設定されたテンプレートを用意すれば、新しいプレゼンテーションが同じ方式で開くようにできますか？**  

はい。[view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。