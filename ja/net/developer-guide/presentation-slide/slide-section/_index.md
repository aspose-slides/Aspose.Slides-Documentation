---
title: スライドセクション
type: docs
weight: 100
url: /net/slide-section/
keywords: "セクションを作成, セクションを追加, セクション名を編集, PowerPointプレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointプレゼンテーションにセクションを追加および編集する"
---

Aspose.Slides for .NETを使用すると、PowerPointプレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況では、セクションを作成し、それを使用してプレゼンテーション内のスライドを論理的な部分に整理または分割することができます：

- 大規模なプレゼンテーションで他の人やチームと作業しているとき—特定のスライドを同僚やチームメンバーに割り当てる必要があるとき。
- 多くのスライドを含むプレゼンテーションを扱っているとき—その内容を一度に管理または編集するのに苦労しているとき。

理想的には、似たようなスライドを保持するセクションを作成すべきです—スライドには共通点があるか、あるルールに基づいてグループとして存在することができます—そして、そのセクションに内部のスライドを説明する名前を付けます。

## プレゼンテーションでのセクションの作成

プレゼンテーションにスライドを収容するセクションを追加するには、Aspose.Slides for .NETがAddSectionメソッドを提供しており、作成するセクションの名前とセクションが始まるスライドを指定できます。

このサンプルコードは、C#でプレゼンテーションにセクションを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("セクション 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("セクション 2", newSlide3); // section1はnewSlide2で終了し、その後section2が開始されます   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("最後の空のセクション");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## セクション名の変更

PowerPointプレゼンテーションでセクションを作成した後、その名前を変更することに決める場合があります。

このサンプルコードは、Aspose.Slidesを使用してC#でプレゼンテーション内のセクションの名前を変更する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "私のセクション";
}
```