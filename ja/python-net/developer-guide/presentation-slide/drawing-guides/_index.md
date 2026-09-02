---
title: Python でプレゼンテーションの描画ガイドを管理する
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/python-net/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 配置ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- ハンドアウトマスター
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションの水平および垂直の描画ガイドを追加、アクセス、クリアします。"
---
## **概要**

描画ガイドは、調整可能な水平および垂直の線で、PowerPoint でプレゼンテーションを編集する際にユーザーが形状を一貫して配置できるよう支援します。アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に特に有用です。アプリケーションは、コンテンツの追加や移動時に作者が従うべき同じ配置補助を保存できます。

描画ガイドは編集支援ツールであり、スライドのコンテンツではありません。スライドショーやレンダリング出力には表示されません。Aspose.Slides for Python via .NET は、[IDrawingGuidesCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguidescollection/) インターフェイスを通じてこれらを提供します。ガイドは [IDrawingGuide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguide/) によって表され、向き、位置、色を持ちます。

位置は、対象となるスライドまたはマスタの左上隅からのポイント単位で測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライド高さまでの範囲です。

## **スライドビューにガイドを追加する**

[ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) を使用して、通常のスライドを編集中に表示されるガイドを管理します。[IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguidescollection/add/) を、[Orientation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/orientation/) の値とポイント単位の位置で呼び出します。

以下の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **描画ガイドへのアクセス**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguidescollection/count/) プロパティとインデクサーで既存のガイドにアクセスできます。[IDrawingGuide.orientation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.position](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguide/position/)、および [IDrawingGuide.color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguide/color/) プロパティは読み取りまたは変更が可能です。

以下の例は、上記で作成したプレゼンテーションからスライドビューのガイドを読み取ります：

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **マスタースライドとレイアウトスライドにガイドを追加する**

スライドマスタとその各レイアウトスライドは、独自の描画ガイドコレクションを持つことができます。マスタースライドには [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/drawing_guides/) を、レイアウトスライドには [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilayoutslide/drawing_guides/) を使用します。

以下の例は、最初のマスタースライドに垂直ガイドを、最初のレイアウトスライドに水平ガイドを追加します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **ノートマスターとハンドアウトマスターにガイドを追加する**

ノートマスターとハンドアウトマスターも描画ガイドをサポートします。各コレクションへは [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasternotesslide/drawing_guides/) と [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) を使用してアクセスします。プレゼンテーションにこれらのマスターが存在しない場合、[IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) または [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) がデフォルトマスターを作成して返します。

以下の例は、ノートマスターに水平ガイドを、ハンドアウトマスターに垂直ガイドを追加します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **描画ガイドのクリア**

[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides/idrawingguidescollection/clear/) を呼び出すと、特定のコレクションからすべてのガイドを削除できます。1 つのコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

以下の例は、スライドビューのガイドおよびスライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター上のすべてのガイドを、欠落しているマスターを作成せずにクリアします：

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**描画ガイドはスライドショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集用の配置補助であり、プレゼンテーションのコンテンツとしてレンダリングされません。

**通常のスライドに直接描画ガイドを追加できますか？**

通常のスライドの編集ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター用の個別のガイドコレクションも利用可能です。

**ガイドの位置単位は何ですか？**

位置はポイントで指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアするとシェイプやスライド内容が削除されますか？**

`clear` メソッドは選択されたコレクション内のガイドのみを削除します。シェイプやその他のスライドコンテンツはそのまま残ります。