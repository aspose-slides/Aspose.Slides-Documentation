---
title: スライドセクション
type: docs
weight: 100
url: /ja/python-net/slide-section/
keywords: "セクションの作成, セクションの追加, セクション名の編集, PowerPointプレゼンテーション, Python, Aspose.Slides"
description: "PythonでPowerPointプレゼンテーションにセクションを追加して編集する"
---

Aspose.Slides for Python via .NETを使用すると、PowerPointプレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況では、セクションを作成し、それを使用してプレゼンテーション内のスライドを論理的な部分に整理または分割したい場合があります。

- 大規模なプレゼンテーションを他の人やチームと一緒に作業しているとき—and特定のスライドを同僚や一部のチームメンバーに割り当てる必要がある場合。
- 多くのスライドを含むプレゼンテーションを扱っており—andその内容を一度に管理または編集するのに苦労しているとき。

理想的には、類似のスライドを収容するセクションを作成するべきです—スライドは何か共通のものを持っているか、ルールに基づいてグループに存在できます—andその中のスライドを説明する名前をセクションに付けます。

## プレゼンテーション内のセクションの作成

プレゼンテーション内にスライドを収容するセクションを追加するには、Aspose.Slides for Python via .NETが提供するAddSectionメソッドを使用して、作成するセクションの名前とセクションが始まるスライドを指定できます。

このサンプルコードは、Pythonでプレゼンテーションにセクションを作成する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("セクション 1", newSlide1)
    # section1はnewSlide2で終了し、その後section2が始まります
    section2 = pres.sections.add_section("セクション 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("最後の空のセクション")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## セクション名の変更

PowerPointプレゼンテーションにセクションを作成した後、その名前を変更することを決定する場合があります。

このサンプルコードは、Aspose.Slidesを使用してPythonでプレゼンテーションのセクション名を変更する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "私のセクション"
```