---
title: ".NET でプレゼンテーションのスライド セクションを管理する"
linktitle: "スライド セクション"
type: docs
weight: 100
url: /ja/net/slide-section/
keywords:
- "セクションを作成する"
- "セクションを追加する"
- "セクションを編集する"
- "セクションを変更する"
- "セクション名"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint と OpenDocument のスライド セクションを効率化します — 分割、名前変更、並び替えにより PPTX と ODP のワークフローを最適化します。"
---

Aspose.Slides for .NET を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況で、セクションを作成してプレゼンテーション内のスライドを論理的なパートに整理または分割したい場合があります：

- 大規模なプレゼンテーションを他の人やチームと共同で作業しており、特定のスライドを同僚やチームメンバーに割り当てる必要があるとき。  
- スライドが多数含まれるプレゼンテーションを扱っており、内容を一度に管理または編集するのが困難なとき。

理想的には、類似したスライド（共通点がある、またはルールに基づいてグループ化できる）をまとめるセクションを作成し、セクション内のスライドを説明する名前を付けます。

## **プレゼンテーションでセクションを作成する**

プレゼンテーション内のスライドを格納するセクションを追加するには、Aspose.Slides for .NET の AddSection メソッドを使用します。このメソッドでは、作成するセクションの名前と、セクションの開始スライドを指定できます。

このサンプルコードは、C# でプレゼンテーションにセクションを作成する方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 は newSlide2 で終了し、その後 section2 が開始されます

    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **セクションの名前を変更する**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用して C# でプレゼンテーションのセクション名を変更する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **よくある質問**

**セクションは PPT（PowerPoint 97–2003）形式で保存すると保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**セクション全体を「非表示」にできますか？**

できません。個々のスライドだけが非表示にできます。セクションという単位には「非表示」状態はありません。

**スライドからセクションをすばやく見つけることはできますか？また、セクションの最初のスライドを取得できますか？**

はい。セクションは開始スライドによって一意に定義されます。スライドが与えられれば、どのセクションに属しているかを判断でき、セクションが与えられればその最初のスライドにアクセスできます。