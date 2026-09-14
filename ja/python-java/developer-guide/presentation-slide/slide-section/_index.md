---
title: Python via Java でプレゼンテーションのスライドセクションを管理する
linktitle: スライドセクション
type: docs
weight: 90
url: /ja/python-java/slide-section/
keywords:
- セクション作成
- セクション追加
- セクション編集
- セクション変更
- セクション名
- セクションスライド取得
- セクションスライド処理
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してスライドセクションを管理します：PPTX プレゼンテーションでセクションの作成、名前変更、並び替え、取得、および処理を行います。"
---
## **導入**

セクションは、スライドの内容を変更せずに、連続したスライドを名前付きのグループに整理します。Aspose.Slides for Python via Java を使用すると、[Presentation.getSections](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSections) メソッドを介してセクションの作成、並び替え、名前変更、検査、削除が行えます。

セクションは特に次の場合に有用です。

- 大規模なプレゼンテーションを論理的なトピックや章に分割したいとき；
- スライドの異なるグループを別々の共同作業者に割り当てるとき；
- スライドをグループとして処理、移動、または結合したいとき。

グループ化されたスライドの目的を示す簡潔なセクション名を選んでください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導き出すのではなく、セクション API を使用して所属を判定してください。

## **セクションの作成と管理**

[SectionCollection.addSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/#addSection) を使用して、セクション名と開始スライドを指定してセクションを作成します。Aspose.Slides は現在のセクション構造から、どのスライドがそのセクションに属するかを判断します。

同じ[SectionCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/)で以下も行えます。

- [reorderSectionWithSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) を使用してスライドと共にセクションを移動する；
- スライドを残したままセクション定義のみを削除するには [removeSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/#removeSection) を使用する；
- スライドと共にセクションを削除するには [removeSectionWithSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) を使用する；
- 最後に空のセクションを追加するには [appendEmptySection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/#appendEmptySection) を使用する。

次の例は 2 つのセクションを作成し、そのうちの 1 つを移動し、スライドと共に削除し、空のセクションを追加します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

これらの操作後、プレゼンテーションには `Introduction` セクションとそのスライド、そして空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されています。

## **セクションの名前変更**

セクションの名前を変更するには、[Section.setName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#setName) メソッドを呼び出します。セクションのスライドや位置は変更されません。

次の例はセクションを作成し、その名前を変更します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **セクションからスライドを取得する**

[Presentation.getSections](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSections) メソッドは、反復処理可能な [SectionCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectioncollection/) を返します。各 [Section](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/) について、[Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getSlidesListOfSection) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは、カウント、インデックスアクセス、反復処理を提供する [SectionSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectionslidecollection/) を返します。

次の例は 2 つのスライドが入ったセクションと 1 つの空セクションを作成し、各セクションの [name](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getName)、[identifier](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getStartedFromSlide)、スライド数、スライド番号を出力します。最初のスライドを読み取るために [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sectionslidecollection/#get_Item) を使用し、`for` 文で全スライドを処理します。空セクションの場合、返されるコレクションのサイズは 0 であり、メソッドは呼び出されず、反復処理は何も行いません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

セクションの所属はプレゼンテーションのセクション構造によって決まります。[Section.getStartedFromSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getStartedFromSlide) やスライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造的な編集は、セクションが返すスライドやスライド番号の両方を変える可能性があります。これにはスライドの並び替え、スライドのクローン作成、セクションとスライドの同時移動、スライドの削除、セクションの削除が含まれます。次の例では、各変更後に [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getSlidesListOfSection) を呼び出し、以前の境界に関する前提を保持しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

スライドやセクションが並び替え、クローン作成、移動、削除されたときは、必ず再度 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getSlidesListOfSection) を呼び出してください。これにより、以降の処理が現在のプレゼンテーション構造と整合します。

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。セクションをサポートする形式（例: PPTX）で作業し、PPT に変換するとセクション構造が失われて以降の反復処理ができなくなる点に注意してください。

## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存するとセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクション自体に可視性状態はありません。内容を非表示にするには、セクション内の各スライドに対して [Slide.setHidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setHidden) を呼び出してください。

**スライドが属するセクションを見つけるにはどうすればよいですか？**

[Presentation.getSections](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSections) が返すコレクションを反復し、各セクションに対して [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getSlidesListOfSection) を呼び出し、取得したスライドと対象スライドを比較します。空でないセクションの場合、[Section.getStartedFromSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/section/#getStartedFromSlide) は最初のスライドを返し、空セクションの場合は `None` を返します。