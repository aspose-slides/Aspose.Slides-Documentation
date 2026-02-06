---
title: セクション
type: docs
weight: 90
url: /ja/python-net/examples/elements/section/
keywords:
- セクション
- スライド セクション
- セクションの追加
- セクションへのアクセス
- セクションの削除
- セクションの名前変更
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でスライド セクションを管理します。セクションの作成、名前変更、簡単な並べ替え、セクション間のスライド移動、そして PPT、PPTX、ODP の表示制御が可能です。"
---
プレゼンテーションのセクションを管理する例 — 追加、アクセス、削除、名前変更を **Aspose.Slides for Python via .NET** を使用してプログラム的に行う方法。

## **セクションの追加**

特定のスライドから開始するセクションを作成します。

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新しいセクションを追加し、そのセクションの開始を示すスライドを指定します。
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **セクションへのアクセス**

プレゼンテーションからセクションを取得します。

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # インデックスでセクションにアクセスします。
        section = presentation.sections[0]
```

## **セクションの削除**

以前に追加したセクションを削除します。

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # セクションを削除します。
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # セクションの名前を変更します。
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```