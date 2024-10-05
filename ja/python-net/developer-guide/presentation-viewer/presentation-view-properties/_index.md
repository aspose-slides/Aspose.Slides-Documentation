---
title: プレゼンテーション ビュー プロパティ
type: docs
url: /python-net/presentation-view-properties/
keywords: "PowerPoint ビューア, ビューア プロパティ, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Python における PowerPoint プレゼンテーション ビューア プロパティ"
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、サイドコンテンツ領域、および下部コンテンツ領域の 3 つのコンテンツ領域で構成されています。異なるコンテンツ領域の位置に関するプロパティ。 この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにビューが最後にプレゼンテーションを保存したときと同じ状態になります。

プロパティ [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) が追加され、プレゼンテーションの通常のビュー プロパティにアクセスできるようになりました。

[**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) インターフェイスおよびその子孫、[**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 列挙型が追加されました。

{{% /alert %}} 



## **INormalViewProperties について** 

通常のビュー プロパティを表します。

プロパティ **ShowOutlineIcons** は、通常の表示モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッタを最小化された状態にスナップすべきかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが通常のビューと 3 つのコンテンツ領域の標準ビューの代わりに、フルウィンドウの単一コンテンツ領域を表示することを好むかどうかを指定します。 有効にすると、アプリケーションはウィンドウ全体に内容を表示することができます。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直のスプリッターバーが表示される状態を指定します。 水平スプリッターバーはスライドを下のコンテンツ領域から分離し、垂直スプリッターバーはスライドをサイドコンテンツ領域から分離します。 可能な値は、**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** および **SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、通常のビューの上部または側面のスライド領域のサイズを指定します。**SplitterBarStateType.Restored** 値が **VerticalBarState** および **HorizontalBarState** に適用されます。



## **INormalViewRestoredProperties について** 

通常のビューのスライド領域 ((RestoredTop の子の場合の幅、RestoredLeft の子の場合の高さ) のサイズを指定します、領域が変動サイズに戻されたとき (最小化でも最大化でもない)。

プロパティ **DimensionSize** は、スライド領域のサイズを指定します (RestoredTop の子の場合の幅、RestoredLeft の子の場合の高さ)。

プロパティ **AutoAdjust** は、アプリケーション内でビューを含むウィンドウのサイズを変更するときに、サイドコンテンツ領域のサイズが新しいサイズに補正されるべきかどうかを指定します。

以下に、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示す例を示します。

```py
import aspose.slides as slides

#プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **デフォルトズーム値の設定**
Aspose.Slides for Python via .NET は、プレゼンテーションが開かれたときにズームが既に設定されるようにデフォルトのズーム値を設定することをサポートしています。これは、プレゼンテーションの [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) を設定することで行うことができます。スライド ビュー プロパティと [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) はプログラムで設定できます。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションの [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) を設定します。
1. プレゼンテーションを PPTX ファイルとして書き込みます。

以下に示す例では、スライド ビューとノート ビューの両方のズーム値を設定しています。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュープロパティを設定
    presentation.view_properties.slide_view_properties.scale = 100 # スライドビューのズーム値（パーセント）
    presentation.view_properties.notes_view_properties.scale = 100 # ノートビューのズーム値（パーセント）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **ビュー プロパティの設定**
ビュー プロパティを設定するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. プレゼンテーションのビュープロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして書き込みます。

以下に示す例では、スライド ビューおよびノート ビューのズーム値を設定しています。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # プレゼンテーションのビュープロパティを設定
    presentation.view_properties.slide_view_properties.scale = 100 # スライドビューのズーム値（パーセント）
    presentation.view_properties.notes_view_properties.scale = 100 # ノートビューのズーム値（パーセント）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```