---
title: テーブル
type: docs
weight: 120
url: /ja/python-net/examples/elements/table/
keywords:
- テーブル
- テーブルを追加
- テーブルにアクセス
- テーブルを削除
- セルを結合
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でテーブルを作成および書式設定します。データの挿入、セルの結合、罫線のスタイル設定、コンテンツの配置、そして PPT、PPTX、ODP のインポート/エクスポートが可能です。"
---
**Aspose.Slides for Python via .NET** を使用して、テーブルの追加、アクセス、削除、およびセルの結合を行う例です。

## **テーブルの追加**

2 行 2 列のシンプルなテーブルを作成します。

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 列幅と行高さを定義します。
        widths = [80, 80]
        heights = [30, 30]

        # スライドにテーブル シェイプを追加します。
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルにアクセス**

スライド上の最初のテーブル シェイプを取得します。

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初のテーブルにアクセスします。
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **テーブルの削除**

スライドからテーブルを削除します。

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがテーブルであると想定します。
        table = slide.shapes[0]

        # スライドからテーブルを削除します。
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル セルの結合**

テーブルの隣接するセルを 1 つのセルに結合します。

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがテーブルであると想定します。
        table = slide.shapes[0]

        # セルを結合します。
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```