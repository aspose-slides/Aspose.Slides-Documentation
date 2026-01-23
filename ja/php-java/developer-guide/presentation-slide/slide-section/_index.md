---
title: PHP を使用したプレゼンテーションのスライド セクション管理
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/php-java/slide-section/
keywords:
- セクション作成
- セクション追加
- セクション編集
- セクション変更
- セクション名
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint と OpenDocument のスライド セクションを効率化します。セクションの分割、名前変更、並び替えにより PPTX および ODP のワークフローを最適化します。"
---

Aspose.Slides for PHP via Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況で、プレゼンテーション内のスライドを論理的なパートに整理または分割するために、セクションを作成して使用したくなることがあります:

- 大規模なプレゼンテーションを他の人やチームと共同で作業しており、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。
- 多数のスライドを含むプレゼンテーションを扱っており、内容を一度に管理・編集するのが困難な場合。

理想的には、類似したスライドをまとめるセクションを作成し（スライド同士に共通点がある、またはある規則に基づいてグループ化できる）、そのセクションにスライドの内容を示す名前を付けるべきです。

## **プレゼンテーションでセクションを作成する**

プレゼンテーション内のスライドをまとめるセクションを追加するために、Aspose.Slides for PHP via Java は [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) メソッドを提供します。このメソッドを使用すると、作成するセクションの名前と、セクションの開始スライドを指定できます。

このサンプルコードは、プレゼンテーションでセクションを作成する方法を示しています :
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 は newSlide2 で終了し、その後 section2 が開始されます

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **セクションの名前を変更する**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用してプレゼンテーション内のセクション名を変更する方法を示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションのメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化情報は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。個々のスライドだけが非表示にできます。セクション自体には「非表示」状態はありません。

**スライドからセクションをすぐに特定したり、逆にセクションの最初のスライドを取得したりできますか？**

はい。セクションは開始スライドによって一意に定義されます。スライドが与えられれば、そのスライドが属するセクションを判定でき、セクションが与えられればその最初のスライドにアクセスできます。