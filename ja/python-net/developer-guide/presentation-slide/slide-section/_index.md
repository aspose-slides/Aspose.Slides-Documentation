---
title: Python でプレゼンテーションのスライド セクションを管理する
linktitle: スライド セクション
type: docs
weight: 100
url: /ja/python-net/developer-guide/presentation-slide/slide-section/
keywords:
- セクションの作成
- セクションの追加
- セクションの編集
- セクションの変更
- セクション名
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument のスライド セクションを効率化 — 分割、名前変更、並び替えで PPTX と ODP のワークフローを最適化します。"
---

## **概要**

Aspose.Slides for Python を使用すると、特定のスライドをグループ化するセクションに PowerPoint プレゼンテーションを整理できます。

次のような状況で、プレゼンテーションを論理的なパートに分割するためにセクションを作成したいことがあります。

- 大規模なプレゼンテーションをチームで作業しており、特定のスライドを特定の同僚に割り当てる必要があるとき。
- スライドが多数あるプレゼンテーションを扱っており、全体を一度に管理・編集するのが困難なとき。

理想的には、テーマ・トピック・目的が共通する関連スライドをまとめたセクションを作成し、各セクションに内容を明確に示す名前を付けます。

## **プレゼンテーションでセクションを作成する**

プレゼンテーション内でスライドをグループ化する[セクション](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を追加するには、Aspose.Slides の [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/) メソッドを使用します。セクション名とセクション開始スライドを指定できます。

以下の Python の例は、プレゼンテーションにセクションを作成する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 ends at slide2; Section 2 starts at slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **セクション名の変更**

PowerPoint プレゼンテーションに[セクション](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を作成した後で、名前を変更したくなることがあります。

以下の Python の例は、プレゼンテーション内のセクション名を変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存するとセクションは保持されますか？**

いいえ。PPT 形式はセクション メタデータをサポートしていないため、.ppt に保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。個々のスライドのみが非表示にでき、セクション全体としての「非表示」状態は存在しません。

**スライドからセクションをすばやく検索したり、逆にセクションの最初のスライドを取得したりできますか？**

はい。セクションは開始スライドで一意に定義されます。スライドが与えられればそのスライドが属するセクションを判定でき、セクションが与えられればその最初のスライドにアクセスできます。