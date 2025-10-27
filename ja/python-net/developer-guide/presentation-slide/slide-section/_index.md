---
title: Python でプレゼンテーションのスライド セクションを管理する
linktitle: スライド セクション
type: docs
weight: 100
url: /ja/python-net/slide-section/
keywords:
- create section
- add section
- edit section
- change section
- section name
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument のスライド セクションを効率化します — 分割、名前変更、並べ替えにより PPTX と ODP のワークフローを最適化します。"
---

## **概要**

Aspose.Slides for Python を使用すると、PowerPoint プレゼンテーションを特定のスライドをグループ化するセクションに整理できます。

以下のような状況で、プレゼンテーションを論理的なパートに整理または分割するためにセクションを作成したくなることがあります。

- チームで大規模なプレゼンテーションを作成しており、特定のスライドを特定の同僚に割り当てる必要があるとき。
- 多数のスライドが含まれるプレゼンテーションを扱っており、一度にすべてを管理または編集するのが難しいと感じるとき。

理想的には、テーマ、トピック、目的が共通する関連スライドをグループ化するセクションを作成し、各セクションに内容を明確に示す名前を付けます。

## **プレゼンテーションでセクションを作成する**

プレゼンテーション内でスライドをグループ化する[Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を追加するには、Aspose.Slides が提供する[add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/)メソッドを使用します。このメソッドでは、セクション名とセクションの開始スライドを指定できます。

次の Python の例は、プレゼンテーションにセクションを作成する方法を示しています。

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

## **セクションの名前を変更する**

PowerPoint プレゼンテーションで[Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を作成した後、その名前を変更したくなることがあります。

次の Python の例は、プレゼンテーション内のセクションの名前を変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。個々のスライドのみ非表示にできます。セクションという単位には「非表示」状態はありません。

**スライドからセクションをすばやく見つけることや、逆にセクションの最初のスライドを取得することはできますか？**

はい。セクションは開始スライドによって一意に定義されます。スライドが与えられれば、そのスライドが属するセクションを判定でき、セクションからは最初のスライドにアクセスできます。