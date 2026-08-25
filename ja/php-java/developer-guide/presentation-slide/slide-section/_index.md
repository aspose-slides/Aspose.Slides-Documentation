---
title: PHP でプレゼンテーションのスライドセクションを管理する
linktitle: スライドセクション
type: docs
weight: 90
url: /ja/php-java/slide-section/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してスライドセクションを管理します：作成、名前変更、並び替え、取得、そして PPTX プレゼンテーション内のセクションスライドを処理します。"
---
## **はじめに**

セクションは、スライドの内容を変更せずに連続したスライドを名前付きグループに整理します。Aspose.Slides for PHP via Java を使用すると、[Presentation::getSections](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSections) メソッドを介してセクションを作成、並び替え、名前変更、検査、削除できます。

セクションは特に次のような場合に便利です：
- 大規模なプレゼンテーションを論理的なトピックや章に分割する必要がある場合；
- 異なるスライドのグループを別々の共同作業者に割り当てる場合；
- スライドをグループとして処理、移動、または結合する必要がある場合。

グループ化されたスライドの目的を表す簡潔なセクション名を選択してください。セクションはプレゼンテーション構造の一部であるため、スライドの位置から算出するのではなく、セクション API を使用して所属を判定してください。

## **セクションの作成と管理**

[SectionCollection::addSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#addSection) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides は、プレゼンテーションの現在のセクション構造からそのセクションに属するスライドを判断します。

同じ [SectionCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/) でも次の操作が可能です：
- [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) を使用して、スライドとともにセクションを移動します；
- [SectionCollection::removeSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#removeSection) でセクション定義のみを削除し、スライドは保持します；
- [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides) を使用して、セクションとそのスライドを削除します；
- [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#appendEmptySection) で末尾に空のセクションを追加します。

次の例では、2 つのセクションを作成し、そのうちの 1 つを移動し、スライドとともに削除し、空のセクションを追加します：

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

これらの操作の後、プレゼンテーションにはスライドを含む `Introduction` セクションと空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前変更**

セクションの名前を変更するには、[Section::setName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#setName) メソッドを呼び出します。セクションのスライドと位置は変更されません。

次の例では、セクションを作成し、名前を変更します：

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **セクションからスライドを取得**

[Presentation::getSections](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSections) メソッドは、インデックスで処理できる [SectionCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/) を返します。各 [Section](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/) について、現在そのセクションに属するスライドを取得するために [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSlidesListOfSection) を呼び出します。このメソッドは、スライド数とインデックスアクセスを提供する [SectionSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionSlideCollection/) を返します。

次の例では、2 つのスライドが含まれるセクションと 1 つの空セクションを作成し、各セクションの [name](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getName)、[identifier](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getStartedFromSlide)、スライド数、スライド番号を出力します。インデックスアクセスには [SectionCollection::get_Item](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionCollection/#get_Item) と [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SectionSlideCollection/#get_Item) を使用します。空のセクションの場合、返されるコレクションのサイズは 0 で、`get_Item` は呼び出されません。

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

セクションの所属はプレゼンテーションのセクション構造によって決定されます。[Section::getStartedFromSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getStartedFromSlide)、スライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造的な編集により、セクションに対して返されるスライドとそのスライド番号の両方が変更される可能性があります。これには、スライドの並べ替え、スライドのセクションへのクローン、セクションとそのスライドの移動、スライドの削除、セクションの削除が含まれます。次の例では、セクションの以前の境界に関する前提を保持せず、変更のたびに [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSlidesListOfSection) を呼び出します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

スライドまたはセクションが並べ替え、クローン、移動、削除されるたびに、[Section::getSlidesListOfSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSlidesListOfSection) を再度呼び出してください。これにより、後続の処理が現在のプレゼンテーション構造と一致します。

PPT (PowerPoint 97–2003) 形式はセクションメタデータを保持しません。セクションをサポートする形式 (例: PPTX) でこのワークフローを使用してください。PPT に変換すると、後続の反復に必要なセクション構造が失われます。

## **よくある質問**

**PPT (PowerPoint 97–2003) 形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt として保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクション自体に可視状態はありません。その内容を非表示にするには、セクション内の各スライドに対して [Slide::setHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Slide/#setHidden) を呼び出してください。

**スライドを含むセクションをどのように見つけますか？**

[Presentation::getSections](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSections) が返すコレクションをループし、各セクションに対して [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getSlidesListOfSection) を呼び出し、返されたスライドと対象スライドを比較します。空でないセクションの場合、[Section::getStartedFromSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Section/#getStartedFromSlide) は最初のスライドを返します。空のセクションの場合は `null` を返します。