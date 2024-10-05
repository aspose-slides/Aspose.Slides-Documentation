---
title: スライドセクション
type: docs
weight: 100
url: /cpp/slide-section/
---

Aspose.Slides for C++を使用すると、PowerPointプレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況で、セクションを作成し、それを使用してプレゼンテーションのスライドを論理的な部分に整理または分割したい場合があります：

- 大規模なプレゼンテーションに他の人やチームと一緒に取り組んでいるときで、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。
- 多くのスライドを含むプレゼンテーションを扱っているときで、一度にその内容を管理または編集するのに苦労している場合。

理想的には、類似のスライドを収容するセクションを作成すべきです。スライドは何か共通の特性を持っているか、ルールに基づいてグループとして存在できます。そして、そのセクションには中にあるスライドを説明する名前を付けます。

## プレゼンテーションでのセクション作成

プレゼンテーションにスライドを収容するセクションを追加するために、Aspose.Slides for C++は、作成する予定のセクションの名前とセクションが開始するスライドを指定できるAddSectionメソッドを提供します。

このサンプルコードは、C++でプレゼンテーションにセクションを作成する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"セクション 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"セクション 2", newSlide3);
// section1はnewSlide2で終了し、その後section2が開始します  

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"最後の空のセクション");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## セクションの名前変更

PowerPointプレゼンテーションにセクションを作成した後、その名前を変更したいと思うかもしれません。

このサンプルコードは、Aspose.Slidesを使用してC++でプレゼンテーションにおけるセクションの名前を変更する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"私のセクション");
```