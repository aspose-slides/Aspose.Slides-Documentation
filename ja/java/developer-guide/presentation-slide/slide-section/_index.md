---
title: Java を使用したプレゼンテーションのスライド セクションの管理
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/java/slide-section/
keywords:
- セクションを作成
- セクションを追加
- セクションを編集
- セクションを変更
- セクション名
- セクションスライドを取得
- セクションスライドを処理
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してスライド セクションを管理します。PPTX プレゼンテーションでセクション スライドの作成、名前の変更、並び替え、取得、処理が可能です。"
---
## **導入**

セクションは、スライドの内容を変更せずに、連続するスライドを名前付きのグループに整理します。Aspose.Slides for Java を使用すると、[Presentation.getSections](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSections--) メソッドを使用して、セクションの作成、並び替え、名前変更、検査、削除が行えます。

セクションは、特に次の場合に有用です:
- 大規模なプレゼンテーションを論理的なトピックや章に分割したいとき
- スライドの異なるグループを別々の共同作業者に割り当てるとき
- スライドをグループとして処理、移動、または結合する必要があるとき

グループ化されたスライドの目的を説明する簡潔なセクション名を選んでください。セクションはプレゼンテーション構造の一部であるため、スライド位置から推測せずにセクション API を使用して所属を判定してください。

## **セクションの作成と管理**

[ISectionCollection.addSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) を使用して、セクション名と開始スライドを指定してセクションを作成します。Aspose.Slides は現在のセクション構造に基づいて、どのスライドがそのセクションに属するかを決定します。

同じ [ISectionCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/) では次の操作も可能です:
- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) を使用して、スライドと共にセクションを移動する
- [ISectionCollection.removeSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) でセクション定義のみを削除し、スライドは保持する
- [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) でセクションとそのスライドを同時に削除する
- [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) で末尾に空のセクションを追加する

以下の例は 2 つのセクションを作成し、そのうちの 1 つを移動し、スライドと共に削除し、空のセクションを追加します:

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

これらの操作の結果、プレゼンテーションには `Introduction` セクションとそのスライド、空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前の変更**

セクションの名前を変更するには、[ISection.setName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#setName-java.lang.String-) メソッドを呼び出します。セクションのスライドや位置は変更されません。

以下の例はセクションを作成し、名前を変更します:

```java
import com.aspose.slides.ISection;
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

## **セクションからスライドを取得**

[Presentation.getSections](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSections--) メソッドは、反復処理できる [ISectionCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectioncollection/) を返します。各 [ISection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/) について、[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSlidesListOfSection--) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは、スライド数、インデックスアクセス、反復処理を提供する [ISectionSlideCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectionslidecollection/) を返します。

以下の例は 2 つの内容があるセクションと 1 つの空セクションを作成し、各セクションの [name](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getName--)、[identifier](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSectionId--)、[starting slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getStartedFromSlide--)、スライド数、スライド番号を出力します。最初のスライドを読むために [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) を使用し、拡張 `for` 文で全スライドを処理します。空セクションの場合、返されるコレクションのサイズは 0 で、メソッドは呼び出されず、反復処理は何も行いません。

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

セクションの所属はプレゼンテーションのセクション構造によって決まります。[ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getStartedFromSlide--) やスライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造上の編集は、セクションに対して返されるスライドとそのスライド番号の両方を変更する可能性があります。これにはスライドの並び替え、スライドのセクションへのクローン作成、セクションとそのスライドの移動、スライドの削除、セクションの削除が含まれます。次の例では、[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSlidesListOfSection--) を各変更後に呼び出し、以前の境界に関する仮定を保持しません。

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

スライドやセクションが並び替え、クローン作成、移動、削除されるたびに、[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSlidesListOfSection--) を再度呼び出してください。これにより、以降の処理が現在のプレゼンテーション構造と一致します。

PPT (PowerPoint 97–2003) 形式はセクションメタデータを保持しません。セクションをサポートする形式（例: PPTX）でこのワークフローを使用してください。PPT に変換すると、後続の反復処理に必要なセクション構造が失われます。

## **よくある質問**

**PPT (PowerPoint 97–2003) 形式で保存するとセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクション自体に表示状態はありません。セクション内の各スライドを非表示にするには、[ISlide.setHidden](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#setHidden-boolean-) を呼び出してください。

**スライドが含まれるセクションをどのように見つけますか？**

[Presentation.getSections](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSections--) が返すコレクションを反復し、各セクションで [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getSlidesListOfSection--) を呼び出して返されたスライドと対象スライドを比較します。空でないセクションの場合、[ISection.getStartedFromSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isection/#getStartedFromSlide--) は最初のスライドを返し、空のセクションの場合は `null` を返します。