---
title: C++ を使用したプレゼンテーションでのスライド セクションの管理
linktitle: スライド セクション
type: docs
weight: 100
url: /ja/cpp/slide-section/
keywords:
- セクションの作成
- セクションの追加
- セクションの編集
- セクションの変更
- セクション名
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint と OpenDocument のスライド セクションを効率化します — 分割、名前変更、並び替えで PPTX と ODP のワークフローを最適化します。"
---

Aspose.Slides for C++ を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

プレゼンテーション内のスライドを論理的な部分に整理または分割するために、次のような状況でセクションを作成して使用したい場合があります。

- 大規模なプレゼンテーションを他の人やチームと共同で作業していて、特定のスライドを同僚やチームメンバーに割り当てる必要があるとき。  
- スライドが多数含まれるプレゼンテーションを扱っており、内容を一度に管理または編集するのが困難なとき。

理想的には、共通点がある、またはある規則に基づいてグループ化できる類似スライドをまとめるセクションを作成し、そのセクションにスライドの内容を表す名前を付けます。

## **Create Sections in Presentations**

プレゼンテーション内のスライドを格納するセクションを追加するために、Aspose.Slides for C++ は AddSection メソッドを提供します。このメソッドでは、作成するセクションの名前とセクションが開始するスライドを指定できます。

以下のサンプルコードは、C++ でプレゼンテーションにセクションを作成する方法を示しています：
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 は newSlide2 で終了し、その後 section2 が開始されます   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **Change the Names of Sections**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

以下のサンプルコードは、Aspose.Slides を使用して C++ でプレゼンテーション内のセクション名を変更する方法を示しています：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化情報は失われます。

**Can an entire section be "hidden"?**

いいえ。個々のスライドのみが非表示にできます。セクション全体として「非表示」状態は持ちません。

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**

はい。セクションは開始スライドによって一意に定義されます。スライドが与えられれば、そのスライドが属するセクションを特定でき、セクションが与えられればその最初のスライドにアクセスできます。