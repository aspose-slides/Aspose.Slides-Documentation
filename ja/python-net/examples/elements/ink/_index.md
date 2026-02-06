---
title: インク
type: docs
weight: 180
url: /ja/python-net/examples/elements/ink/
keywords:
- インク
- インクにアクセス
- インクの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でスライド上のデジタルインクを処理します：ペンストロークの追加、パスの編集、色と幅の設定、そして PowerPoint と OpenDocument 用に結果をエクスポートします。"
---
Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for Python via .NET**.

> ❗ **注:** インク シェイプは、特殊なデバイスからのユーザー入力を表します。Aspose.Slides ではプログラムで新しいインク ストロークを作成できませんが、既存のインクを読み取って変更することは可能です。

## **インクにアクセス**

スライドから最初のインク シェイプを取得します。

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **インクを削除**

スライドからインク シェイプを削除します。

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが Ink オブジェクトであると仮定します。

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```