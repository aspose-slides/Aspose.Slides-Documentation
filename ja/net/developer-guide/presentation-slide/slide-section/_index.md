---
title: スライド セクション
type: docs
weight: 100
url: /ja/net/slide-section/
keywords: "セクションの作成, セクションの追加, セクション名の編集, PowerPoint プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint プレゼンテーションでセクションを追加および編集する（C# または .NET）"
---

Aspose.Slides for .NET を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

以下のような状況で、セクションを作成してプレゼンテーション内のスライドを論理的なパートに整理または分割したくなることがあります。

- 大規模なプレゼンテーションで他の人やチームと共同作業を行い、特定のスライドを同僚やチームメンバーに割り当てる必要があるとき。  
- スライドが多数含まれるプレゼンテーションを扱っており、内容を一度に管理・編集するのが困難なとき。

理想的には、共通点があるスライドや、ある規則に基づいてグループ化できるスライドをまとめたセクションを作成し、そのセクションにスライドの内容を表す名前を付けるべきです。

## **プレゼンテーションでのセクションの作成**

プレゼンテーションにスライドを収めるセクションを追加するには、Aspose.Slides for .NET が提供する AddSection メソッドを使用します。このメソッドでは、作成するセクションの名前とセクションの開始スライドを指定できます。

このサンプルコードは、C# でプレゼンテーションにセクションを作成する方法を示しています。  
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


## **セクション名の変更**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用して C# でプレゼンテーション内のセクション名を変更する方法を示しています。  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **よくある質問**

**PPT（PowerPoint 97–2003）形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションのメタデータをサポートしていないため、.ppt で保存するとセクションのグルーピングは失われます。

**セクション全体を「非表示」にできますか？**

いいえ。個々のスライドのみが非表示にできます。セクションという単位には「非表示」状態がありません。

**スライドからセクションをすぐに特定したり、逆にセクションの最初のスライドを取得したりできますか？**

はい。セクションは開始スライドで一意に定義されます。あるスライドからそのスライドが属するセクションを判別でき、セクションからは最初のスライドにアクセスできます。