---
title: Python でプレゼンテーションのスライドセクションを管理
linktitle: スライドセクション
type: docs
weight: 100
url: /ja/python-net/slide-section/
keywords:
- セクションの作成
- セクションの追加
- セクションの編集
- セクションの変更
- セクション名
- セクションスライドの取得
- セクションスライドの処理
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してスライドセクションを管理します：セクションスライドの作成、名前変更、並べ替え、取得、および処理を PPTX プレゼンテーションで実行します。"
---
## **概要**

セクションは、スライドの連続を名前付きグループに整理し、スライドの内容を変更しません。Aspose.Slides for Python via .NET を使用すると、[Presentation.sections](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sections/) プロパティを介してセクションの作成、並べ替え、名前変更、検査、および削除ができます。

セクションは特に次の場合に便利です：

- 大規模なプレゼンテーションを論理的なトピックや章に分割する必要がある場合。
- 異なるスライドのグループが異なる共同作業者に割り当てられる場合。
- スライドをグループとして処理、移動、または結合する必要がある場合。

グループ化されたスライドの目的を示す簡潔なセクション名を選択してください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導き出すのではなく、セクション API を使用してメンバーシップを判定してください。

## **セクションの作成と管理**

[SectionCollection.add_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/add_section/) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides は、プレゼンテーションの現在のセクション構造から、そのセクションに属するスライドを判定します。

同じ [SectionCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/) でも次の操作が可能です：

- [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) を使用して、スライドと共にセクションを移動します;
- [SectionCollection.remove_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/remove_section/) でセクション定義のみを削除し、スライドは保持します;
- [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) でセクションとそのスライドを削除します;
- [SectionCollection.append_empty_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/append_empty_section/) を使用して、末尾に空のセクションを追加します。

次の例では、2 つのセクションを作成し、そのうちの 1 つを移動し、スライドと共に削除し、空のセクションを追加します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

これらの操作の後、プレゼンテーションにはスライドを含む `Introduction` セクションと空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前変更**

セクションの名前を変更するには、[Section.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/name/) プロパティを設定します。セクションのスライドと位置は変更されません。

次の例では、セクションを作成し、その名前を変更します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **セクションからスライドを取得する**

[Presentation.sections](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sections/) プロパティは、反復処理可能な [SectionCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/) を返します。各 [Section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/) について、[Section.get_slides_list_of_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/get_slides_list_of_section/) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは、スライド数、インデックスアクセス、反復処理を提供する [SectionSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectionslidecollection/) を返します。

次の例では、2 つのスライドが含まれたセクションと 1 つの空セクションを作成し、各セクションの [name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/name/)、[identifier](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/section_id/)、[starting slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/started_from_slide/)、スライド数、スライド番号を出力します。インデックスアクセスで最初のスライドを読み取り、`for` ループで全スライドを処理します。空のセクションについては、返されるコレクションのカウントが 0 で、インデックスはアクセスされず、反復は実行されません。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

セクションのメンバーシップはプレゼンテーションのセクション構造によって決定されます。[Section.started_from_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/started_from_slide/) 、スライドインデックス、次のセクションの開始スライドから手動でセクションの範囲を計算しないでください。

構造的な編集により、セクションに返されるスライドやスライド番号が変わることがあります。これにはスライドの並べ替え、スライドのセクションへのクローン、セクションとそのスライドの移動、スライドの削除、セクションの削除が含まれます。次の例では、各変更後に [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/get_slides_list_of_section/) を呼び出し、セクションの以前の境界に関する仮定を保持しません。

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

スライドやセクションが並べ替え、クローン、移動、または削除されるたびに、[Section.get_slides_list_of_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/get_slides_list_of_section/) を再度呼び出してください。これにより、後続の処理が現在のプレゼンテーション構造と一致します。

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。PPTX など、セクションをサポートする形式でこのワークフローを使用してください。PPT に変換すると、後で反復に必要なセクション構造が失われます。

## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存すると、セクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクションには表示状態がありません。内容を非表示にするには、セクション内の各スライドの [Slide.hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/hidden/) プロパティを設定してください。

**スライドが属するセクションをどうやって見つけますか？**

[Presentation.sections](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sections/) を反復し、各セクションで [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/get_slides_list_of_section/) を呼び出して返されたスライドを対象のスライドと比較します。空でないセクションの場合、[Section.started_from_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/started_from_slide/) は最初のスライドを返し、空のセクションの場合は `None` を返します。