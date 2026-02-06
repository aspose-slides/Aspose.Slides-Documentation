---
title: SmartArt
type: docs
weight: 140
url: /ja/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt の追加
- SmartArt へのアクセス
- SmartArt の削除
- SmartArt レイアウト
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で SmartArt を作成および編集します。ノードの追加、レイアウトやスタイルの変更、正確なシェイプへの変換、PPT、PPTX、ODP へのエクスポートが可能です。"
---
**Aspose.Slides for Python via .NET** を使用して、SmartArt グラフィックの追加、アクセス、削除、レイアウトの変更方法を示します。

## **SmartArt の追加**

組み込みのレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt へのアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初の SmartArt シェイプにアクセスします。
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **SmartArt の削除**

スライドから SmartArt シェイプを削除します。

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが SmartArt オブジェクトであると想定しています。
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt レイアウトの変更**

既存の SmartArt グラフィックのレイアウト タイプを更新します。

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが SmartArt オブジェクトであると想定しています。
        smart_art = slide.shapes[0]

        # SmartArt のレイアウトを変更します。
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```