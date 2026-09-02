---
title: ".NET でのプレゼンテーションにおけるスライド セクションの管理"
linktitle: "スライド セクション"
type: docs
weight: 100
url: /ja/net/slide-section/
keywords:
- "セクションの作成"
- "セクションの追加"
- "セクションの編集"
- "セクションの変更"
- "セクション名"
- "セクション スライドの取得"
- "セクション スライドの処理"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用してスライド セクションを管理します。PPTX プレゼンテーションでセクション スライドの作成、名前変更、並び替え、取得、処理が可能です。"
---
## **概要**

セクションは、スライドの内容を変更せずに、連続したスライドを名前付きのグループに整理します。Aspose.Slides for .NET を使用すると、[Presentation.Sections](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sections/) プロパティを介して、セクションの作成、順序変更、名前変更、検査、削除が行えます。

セクションは特に次の場合に有用です。

- 大規模なプレゼンテーションを論理的なトピックや章に分割する必要がある場合；
- 異なるスライドのグループを異なる共同作業者に割り当てる場合；
- スライドをグループとして処理、移動、結合する必要がある場合。

グループ化されたスライドの目的を示す簡潔なセクション名を選択してください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導出するのではなく、セクション API を使用してメンバーシップを判定してください。

## **セクションの作成と管理**

[ISectionCollection.AddSection](https://reference.aspose.com/slides/ja/net/aspose.slides/sectioncollection/addsection/) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides は、プレゼンテーションの現在のセクション構造から、どのスライドがセクションに属するかを判定します。

同じ [ISectionCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/isectioncollection/) でも次の操作が可能です：

- [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/sectioncollection/reordersectionwithslides/) を使用して、セクションとそのスライドをまとめて移動する；
- [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/ja/net/aspose.slides/sectioncollection/removesection/) でセクション定義のみを削除し、スライドは保持する；
- [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/sectioncollection/removesectionwithslides/) でセクションとそのスライドを削除する；
- [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/ja/net/aspose.slides/sectioncollection/appendemptysection/) で末尾に空のセクションを追加する。

次の例は、2 つのセクションを作成し、そのうちの 1 つを移動し、スライドと共に削除し、空のセクションを追加します：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

これらの操作の後、プレゼンテーションにはスライドを含む `Introduction` セクションと空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前変更**

セクションの名前を変更するには、[ISection.Name](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/name/) プロパティを設定します。セクションのスライドや位置は変更されません。

次の例は、セクションを作成し、その名前を変更します：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **セクションからスライドを取得する**

[Presentation.Sections](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sections/) プロパティは列挙可能な [ISectionCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/isectioncollection/) を返します。各 [ISection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/) について、[ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/getslideslistofsection/) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは [ISectionSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/isectionslidecollection/) を返し、スライド数の取得、インデックスによるアクセス、列挙が可能です。

次の例は、2 つの充実したセクションと 1 つの空セクションを作成し、各セクションの [name](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/name/)、[identifier](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/sectionid/)、[starting slide](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/startedfromslide/)、スライド数、スライド番号を出力します。コレクションインデクサーを使用して最初のスライドを読み取り、`foreach` で全スライドを処理します。空セクションの場合、返されるコレクションのカウントは 0 で、インデクサーはアクセスされず、列挙は実行されません。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

セクションのメンバーシップはプレゼンテーションのセクション構造によって決まります。[ISection.StartedFromSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/startedfromslide/) やスライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造的な編集により、セクションに対して返されるスライドやスライド番号が変わることがあります。これにはスライドの順序変更、スライドのセクションへのクローン作成、セクションとそのスライドの移動、スライドの削除、セクションの削除が含まれます。次の例では、これらの変更が行われるたびに [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/getslideslistofsection/) を呼び出し、以前の境界に関する仮定を保持しません。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

スライドやセクションが順序変更、クローン作成、移動、削除されるたびに [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/getslideslistofsection/) を再度呼び出してください。これにより、以降の処理が現在のプレゼンテーション構造と一致します。

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。PPTX など、セクションをサポートする形式でこのワークフローを使用してください。PPT に変換すると、後続の列挙に必要なセクション構造が失われます。

## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存するときにセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt で保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクションには表示状態がありません。その内容を非表示にするには、セクション内の各スライドに対して [ISlide.Hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/hidden/) プロパティを設定します。

**スライドが所属するセクションをどのように見つけますか？**

[Presentation.Sections](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/sections/) を列挙し、各セクションに対して [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/getslideslistofsection/) を呼び出して返されたスライドを対象スライドと比較します。非空セクションの場合、[ISection.StartedFromSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/isection/startedfromslide/) は最初のスライドを返し、空セクションの場合は `null` を返します。