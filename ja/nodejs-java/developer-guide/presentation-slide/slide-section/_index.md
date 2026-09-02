---
title: JavaScript を使用したプレゼンテーションのスライド セクションの管理
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使ってスライド セクションを管理します：作成、名前の変更、並べ替え、取得、および PPTX プレゼンテーション内のセクション スライドの処理を行います。"
---
## **概要**

セクションはスライドの内容を変更せずに、連続したスライドを名前付きのグループに整理します。Aspose.Slides for Node.js via Java を使用すると、[Presentation.getSections](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSections) メソッドを通じて、セクションの作成、並べ替え、名前変更、検査、削除が可能です。

セクションは特に以下の場合に便利です：
- 大規模なプレゼンテーションを論理的なトピックや章に分割する必要がある場合;
- 異なるスライドのグループが異なる共同作業者に割り当てられる場合;
- スライドをグループとして処理、移動、結合する必要がある場合;

グループ化されたスライドの目的を示す簡潔なセクション名を選択してください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導出するのではなく、セクション API を使用して所属を判断してください。

## **セクションの作成と管理**

[SectionCollection.addSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/#addSection) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides はプレゼンテーションの現在のセクション構造から、どのスライドがそのセクションに属するかを判断します。

同じ[SectionCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/)でも次の操作が可能です：
- [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) を使用して、セクションとそのスライドを一緒に移動します;
- [SectionCollection.removeSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/#removeSection) でセクション定義だけを削除し、スライドは保持します;
- [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) でセクションとそのスライドを同時に削除します;
- [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) で末尾に空のセクションを追加します。

以下の例は 2 つのセクションを作成し、そのうちの 1 つを移動し、スライドとともに削除し、空のセクションを追加します：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

これらの操作後、プレゼンテーションには `Introduction` セクションとそのスライド、および空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前変更**

セクションの名前を変更するには、[Section.setName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#setName) メソッドを呼び出します。セクションのスライドや位置は変更されません。

以下の例はセクションを作成し、名前を変更します：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **セクションからスライドを取得**

[Presentation.getSections](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSections) メソッドは、インデックスでアクセスできる[SectionCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectioncollection/) を返します。各[Section](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/)について、[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSlidesListOfSection) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは[SectionSlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectionslidecollection/) を返し、スライド数とインデックスアクセスを提供します。

以下の例は 2 つのスライドが入ったセクションと 1 つの空セクションを作成し、各セクションの[name](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getName)、[identifier](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getStartedFromSlide)、スライド数、スライド番号を出力します。[SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) を使用して最初のスライドとコレクション内のすべてのスライドを読み取ります。空セクションの場合、返されたコレクションのサイズは 0 で、インデックスアクセスはスキップされ、ループは何も実行しません。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

セクションの所属はプレゼンテーションのセクション構造によって決まります。[Section.getStartedFromSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getStartedFromSlide)、スライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造的な編集は、セクションに対して返されるスライドやスライド番号を変更する可能性があります。これにはスライドの並べ替え、スライドのクローン作成、セクションとそのスライドの移動、スライドの削除、セクションの削除が含まれます。次の例では、各変更後に[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSlidesListOfSection) を呼び出し、以前の境界に関する仮定を保持しません。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

スライドやセクションが並べ替え、クローン、移動、削除されるたびに[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSlidesListOfSection) を再度呼び出してください。これにより、以降の処理が現在のプレゼンテーション構造と整合します。

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。セクションをサポートする形式（例: PPTX）でこのワークフローを使用してください。PPT に変換すると、後続の反復に必要なセクション構造が失われます。

## **よくある質問**

**PPT（PowerPoint 97–2003）形式で保存するときにセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt で保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクションには表示状態がありません。内容を非表示にするには、セクション内の各スライドに対して[Slide.setHidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#setHidden) を呼び出してください。

**スライドが含まれるセクションをどうやって見つけますか？**

[Presentation.getSections](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSections) が返すコレクションの各セクションにアクセスし、各セクションで[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getSlidesListOfSection) を呼び出して返されたスライドを対象スライドと比較します。非空セクションの場合、[Section.getStartedFromSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/section/#getStartedFromSlide) は最初のスライドを返し、空セクションの場合は `null` を返します。