---
title: Androidでのプレゼンテーションにおけるスライドセクションの管理
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/androidjava/slide-section/
keywords:
- セクションの作成
- セクションの追加
- セクションの編集
- セクションの変更
- セクション名
- セクション スライドの取得
- セクション スライドの処理
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してスライドセクションを管理します：PPTX プレゼンテーションでセクションスライドの作成、名前変更、並び替え、取得、処理を行う。"
---
## **はじめに**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for Android via Java, you can create, reorder, rename, inspect, and remove sections through the [Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--) method.

セクションは、スライドの内容を変更せずに、連続したスライドを名前付きのグループに整理します。Aspose.Slides for Android via Java を使用すると、[Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--) メソッドを使用して、セクションの作成、並び替え、名前の変更、検査、削除ができます。

Sections are especially useful when:

- 大規模なプレゼンテーションを論理的なトピックや章に分割する必要がある場合；
- 異なるスライドのグループが別々の共同作業者に割り当てられる場合；
- スライドをグループ単位で処理、移動、または結合する必要がある場合。

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

グループ化されたスライドの目的を示す、簡潔なセクション名を選択してください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導き出すのではなく、セクション API を使用して所属を判定してください。

## **セクションの作成と管理**

Use [ISectionCollection.addSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

[ISectionCollection.addSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides は、プレゼンテーションの現在のセクション構造から、そのセクションに属するスライドを決定します。

The same [ISectionCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/) also lets you:

- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) を使用して、セクションとそのスライドを一緒に移動します；
- [ISectionCollection.removeSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) でセクション定義だけを削除し、スライドは保持します；
- [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) でセクションとそのスライドを削除します；
- [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) で末尾に空のセクションを追加します。

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

次の例は、2 つのセクションを作成し、そのうちの 1 つを移動し、スライドとともに削除し、空のセクションを追加します。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

これらの操作の後、プレゼンテーションにはスライドを持つ `Introduction` セクションと空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されています。

## **セクションの名前変更**

To rename a section, call its [ISection.setName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) method. The section's slides and position remain unchanged.

セクションの名前を変更するには、その [ISection.setName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) メソッドを呼び出します。セクションのスライドと位置は変更されません。

The following example creates a section and changes its name:

次の例は、セクションを作成し、その名前を変更します。

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **セクションからスライドを取得する**

The [Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--) method returns an [ISectionCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/) that you can iterate over. For each [ISection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/), call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) to obtain the slides that currently belong to it. The method returns an [ISectionSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectionslidecollection/), which provides a count, indexed access, and iteration.

[Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--) メソッドは、列挙可能な [ISectionCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectioncollection/) を返します。各 [ISection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/) について、[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは、数、インデックスアクセス、列挙を提供する [ISectionSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectionslidecollection/) を返します。

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), slide count, and slide numbers. It uses [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) to read the first slide and an enhanced `for` statement to process every slide. For the empty section, the returned collection has a size of zero, the method is not called, and iteration performs no operations.

次の例は、2 つのスライドが含まれるセクションと 1 つの空セクションを作成し、各セクションの[name](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getName--)、[identifier](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSectionId--)、[starting slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)、スライド数、スライド番号を出力します。[ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) を使用して最初のスライドを読み取り、強化された `for` 文で全スライドを処理します。空のセクションについては、返されたコレクションのサイズが 0 であり、メソッドは呼び出されず、列挙は何も実行しません。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), slide indexes, and the next section's starting slide.

セクションの所属はプレゼンテーションのセクション構造によって決定されます。[ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)、スライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) after every such change instead of retaining assumptions about the section's former boundaries.

構造的な編集により、セクションが返すスライドとスライド番号の両方が変わる可能性があります。これにはスライドの並び替え、スライドのセクションへのクローン、セクションとそのスライドの移動、スライドの削除、およびセクションの削除が含まれます。次の例では、セクションの以前の境界に関する仮定を保持せず、変更があるたびに [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) を呼び出しています。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

スライドやセクションが並び替え、クローン、移動、または削除されるたびに、[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) を再度呼び出してください。これにより、以降の処理が現在のプレゼンテーション構造と一致した状態を保ちます。

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。セクションをサポートする PPTX などの形式でこの作業フローを使用してください。PPT に変換すると、後続の列挙に必要なセクション構造が失われます。

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**PPT（PowerPoint 97–2003）形式で保存するとセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**Can an entire section be "hidden"?**

No. A section has no visibility state. To hide its contents, call [ISlide.setHidden](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#setHidden-boolean-) for each slide in the section.

**セクション全体を「非表示」にできますか？**

いいえ。セクション自体に表示状態はありません。内容を非表示にするには、セクション内の各スライドに対して [ISlide.setHidden](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#setHidden-boolean-) を呼び出してください。

**How can I find the section that contains a slide?**

Iterate over the collection returned by [Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--), call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) for each section, and compare the returned slides with the target slide. For a non-empty section, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) returns its first slide; for an empty section, it returns `null`.

**スライドが含まれるセクションをどのように特定できますか？**

[Presentation.getSections](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSections--) が返すコレクションを列挙し、各セクションで [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) を呼び出して取得したスライドを対象スライドと比較してください。空でないセクションの場合、[ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) は最初のスライドを返し、空のセクションの場合は `null` を返します。