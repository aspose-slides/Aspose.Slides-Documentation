---
title: C++ でプレゼンテーションのスライド セクションを管理
linktitle: スライド セクション
type: docs
weight: 100
url: /ja/cpp/slide-section/
keywords:
- セクションを作成
- セクションを追加
- セクションを編集
- セクションを変更
- セクション名
- セクション スライドを取得
- セクション スライドを処理
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してスライド セクションを管理します：PPTX プレゼンテーションでセクション スライドの作成、名前変更、並べ替え、取得、処理を行います。"
---
## **イントロダクション**

セクションは、連続したスライドを名前付きのグループに整理し、スライドの内容は変更しません。Aspose.Slides for C++ を使用すると、[Presentation::get_Sections](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sections/) メソッドを介してセクションの作成、並べ替え、名前変更、検査、削除ができます。

セクションは、特に次の場合に便利です：

- 大規模なプレゼンテーションを論理的なトピックや章に分割したいとき；
- スライドの異なるグループを異なる共同作業者に割り当てるとき；
- スライドをグループとして処理、移動、または結合する必要があるとき。

グループ化されたスライドの目的を表す簡潔なセクション名を選んでください。セクションはプレゼンテーション構造の一部であるため、スライド位置から導き出すのではなく、セクション API を使用してメンバーシップを判断してください。

## **セクションの作成と管理**

[ISectionCollection::AddSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/addsection/) を使用して、名前と開始スライドを指定してセクションを作成します。Aspose.Slides は、現在のセクション構造に基づいてそのセクションに属するスライドを決定します。

同じ[ISectionCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/) で以下も行えます：

- [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) を使用して、スライドとともにセクションを移動する；
- スライドは保持したままセクション定義だけを削除するには[ISectionCollection::RemoveSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/removesection/) を使用する；
- セクションとそのスライドを同時に削除するには[ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/removesectionwithslides/) を使用する；
- 末尾に空のセクションを追加するには[ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/appendemptysection/) を使用する。

次の例は 2 つのセクションを作成し、1 つを移動し、スライドとともに削除し、空のセクションを追加します：

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

これらの操作の後、プレゼンテーションには `Introduction` セクションとそのスライド、そして空の `Appendix` セクションが残ります。`Results` セクションとそのスライドは削除されました。

## **セクションの名前変更**

セクションの名前を変更するには、[ISection::set_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/set_name/) を呼び出します。セクションのスライドと位置は変更されません。

次の例はセクションを作成し、名前を変更します：

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **セクションからスライドを取得**

[Presentation::get_Sections](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sections/) メソッドは、列挙可能な[ISectionCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectioncollection/) を返します。各[ISection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/) に対して[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/getslideslistofsection/) を呼び出すと、現在そのセクションに属するスライドを取得できます。このメソッドは[ISectionSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectionslidecollection/) を返し、スライド数、インデックスアクセス、列挙が可能です。

次の例は 2 つのスライドが入ったセクションと 1 つの空セクションを作成し、各セクションの[name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/get_name/)、[identifier](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/get_sectionid/)、[starting slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/get_startedfromslide/)、スライド数、スライド番号を出力します。最初のスライドはインデックスアクセスで取得し、すべてのスライドは範囲ベースの `for` ループで処理します。空セクションの場合、返されるコレクションのカウントは 0 で、インデックスアクセスは使用せず、列挙は実行されません。

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

セクションのメンバーシップはプレゼンテーションのセクション構造によって決まります。[ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/get_startedfromslide/) 、スライドインデックス、次のセクションの開始スライドから手動で範囲を計算しないでください。

構造的な編集は、セクションが返すスライドとスライド番号の両方を変更する可能性があります。スライドの並べ替え、スライドのクローン作成、セクションとスライドの同時移動、スライドの削除、セクションの削除が該当します。次の例では、これらの変更が発生するたびに[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/getslideslistofsection/) を呼び出し、以前の境界に関する仮定を保持しません。

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

スライドやセクションが並べ替え、クローン、移動、または削除された場合は、[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/getslideslistofsection/) を再度呼び出してください。これにより、後続の処理が現在のプレゼンテーション構造と一致します。

PPT（PowerPoint 97–2003）形式はセクションメタデータを保持しません。セクションをサポートする PPTX などの形式でこのワークフローを使用してください。PPT に変換すると、後で列挙するために必要なセクション構造が失われます。

## **FAQ**

**プレゼンテーションを PPT（PowerPoint 97–2003）形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**セクション全体を「非表示」にできますか？**

いいえ。セクション自体に可視性状態はありません。内容を非表示にするには、セクション内の各スライドに対して[ISlide::set_Hidden](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/set_hidden/) を呼び出してください。

**スライドが属するセクションをどうやって見つけますか？**

[Presentation::get_Sections](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_sections/) を列挙し、各セクションに対して[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/getslideslistofsection/) を呼び出して返されたスライドと対象スライドを比較します。空でないセクションの場合、[ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isection/get_startedfromslide/) は最初のスライドを返します。空のセクションの場合は `nullptr` を返します。