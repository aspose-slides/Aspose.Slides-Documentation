---
title: プレゼンテーションのスライドにアクセス
type: docs
weight: 20
url: /python-net/access-slide-in-presentation/
keywords: "PowerPoint プレゼンテーションにアクセス, スライドにアクセス, スライドのプロパティを編集, スライドの位置を変更, スライド番号、インデックス、ID、位置を設定 Python, Aspose.Slides"
description: "Python でインデックス、ID、または位置によって PowerPoint スライドにアクセスします。スライドのプロパティを編集します"
---

Aspose.Slides では、スライドに対してインデックスまたは ID の2つの方法でアクセスできます。

## **インデックスによるスライドへのアクセス**

プレゼンテーション内のすべてのスライドは、0 から始まるスライドの位置に基づいて数値的に配置されています。最初のスライドにはインデックス 0 でアクセスでき、2 番目のスライドにはインデックス 1 でアクセスできます。

プレゼンテーションファイルを表す Presentation クラスは、すべてのスライドを [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) コレクション（[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) オブジェクトのコレクション）として公開します。この Python コードは、スライドにそのインデックスを通してアクセスする方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # インデックスを通してスライドの参照を取得します
    slide = presentation.slides[0]
```

## **IDによるスライドへのアクセス**

プレゼンテーション内の各スライドには、関連付けられた一意の ID があります。`get_slide_by_id(id)` メソッド（[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスによって公開される）を使用して、その ID をターゲットにできます。この Python コードは、有効なスライド ID を提供して `get_slide_by_id(id)` メソッドを通じてそのスライドにアクセスする方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # スライド ID を取得します
    id = presentation.slides[0].slide_id
    # ID を通してスライドにアクセスします
    slide = presentation.get_slide_by_id(id)
```

## **スライドの位置を変更**

Aspose.Slides では、スライドの位置を変更することができます。たとえば、最初のスライドを2 番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置を変更したいスライドのインデックスを通して参照を取得します。
1. `slide_number` プロパティを通してスライドの新しい位置を設定します。 
1. 修正したプレゼンテーションを保存します。

この Python コードは、位置 1 のスライドを位置 2 に移動する操作を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # 位置が変更されるスライドを取得します
    sld = pres.slides[0]
    # スライドの新しい位置を設定します
    sld.slide_number = 2
    # 修正したプレゼンテーションを保存します
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドが2 番目になり、2 番目のスライドが最初になります。スライドの位置を変更すると、他のスライドが自動的に調整されます。

## **スライド番号を設定**

`first_slide_number` プロパティ（[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスによって公開される）を使用すると、プレゼンテーション内の最初のスライドの新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 修正したプレゼンテーションを保存します。

この Python コードは、最初のスライド番号を 10 に設定する操作を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # スライド番号を取得します
    firstSlideNumber = presentation.first_slide_number
    # スライド番号を設定します
    presentation.first_slide_number = 10
    # 修正したプレゼンテーションを保存します
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドをスキップしたい場合は、次のスライドから番号を開始することができます（最初のスライドの番号は非表示にするかもしれません）：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # 最初のプレゼンテーションスライドの番号を設定します
    presentation.first_slide_number = 0

    # すべてのスライドのスライド番号の表示可否を設定します
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 最初のスライドのスライド番号の表示を非表示にします
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 修正したプレゼンテーションを保存します
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```