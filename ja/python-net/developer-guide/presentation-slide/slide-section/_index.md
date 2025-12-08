---
title: Python でプレゼンテーションのスライド セクションを管理
linktitle: スライド セクション
type: docs
weight: 100
url: /ja/python-net/slide-section/
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
description: "Aspose.Slides for Python を使用して PowerPoint および OpenDocument のスライド セクションを効率化します—分割、名前の変更、並び替えにより PPTX と ODP のワークフローを最適化します。"
---

## **概要**

Aspose.Slides for Python を使用すると、特定のスライドをグループ化するセクションに PowerPoint プレゼンテーションを整理できます。

次のような状況で、プレゼンテーションを論理的な部分に整理または分割するためにセクションを作成したい場合があります。

- 大規模なプレゼンテーションをチームで作業しており、特定のスライドを特定の同僚に割り当てる必要があるとき。
- スライド数が多く、すべてを一度に管理または編集するのが困難なとき。

理想的には、テーマ、トピック、目的が共通する関連スライドをグループ化するセクションを作成し、各セクションに内容を明確に示す名前を付けます。

## **プレゼンテーションでセクションを作成**

プレゼンテーション内のスライドをグループ化する[セクション](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を追加するには、Aspose.Slides が提供する[add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/)メソッドを使用します。このメソッドでは、セクション名とセクションの開始スライドを指定できます。

次の Python の例は、プレゼンテーションにセクションを作成する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 は slide2 で終了し、Section 2 は slide3 で開始します。
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```


## **セクションの名前を変更**

PowerPoint プレゼンテーションで[セクション](https://reference.aspose.com/slides/python-net/aspose.slides/section/)を作成した後、名前を変更したい場合があります。

次の Python の例は、プレゼンテーション内のセクションの名前を変更する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```


## **よくある質問**

**PPT（PowerPoint 97–2003）形式で保存したときにセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションの情報は失われます。

**セクション全体を「非表示」にできますか？**

できません。個々のスライドだけが非表示に設定できます。セクション自体には「非表示」状態はありません。

**スライドからセクションをすばやく見つけることはできますか、またその逆にセクションの最初のスライドを取得できますか？**

できます。セクションは開始スライドで一意に定義されます。スライドが与えられればそのスライドが属するセクションを判定でき、セクションが与えられればその最初のスライドにアクセスできます。