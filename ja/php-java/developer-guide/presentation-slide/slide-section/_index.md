---
title: PHP を使用したプレゼンテーションでのスライドセクションの管理
linktitle: スライドセクション
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint と OpenDocument のスライドセクションを効率化します — 分割、名前変更、順序変更により PPTX と ODP のワークフローを最適化します。"
---

Aspose.Slides for PHP via Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況で、セクションを作成してプレゼンテーション内のスライドを論理的な部分に整理または分割したい場合があります：

- 大規模なプレゼンテーションを他の人やチームと共同で作業しており、特定のスライドを同僚やチームメンバーに割り当てる必要があるとき。 
- スライドが多数含まれるプレゼンテーションを扱っており、内容を一度に管理または編集するのが困難なとき。

理想的には、類似したスライドをまとめるセクションを作成すべきです。スライドに共通点があるか、あるルールに基づいてグループ化できる場合、そのセクションにスライドの内容を表す名前を付けます。 

## **プレゼンテーションへのセクション作成**

プレゼンテーション内のスライドを格納するセクションを追加するには、Aspose.Slides for PHP via Java は、セクションの名前とセクション開始スライドを指定できる [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) メソッドを提供します。

このサンプルコードは、プレゼンテーションにセクションを作成する方法を示しています：
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 は newSlide2 で終了し、その後に section2 が開始されます

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


## **セクション名の変更**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用してプレゼンテーションのセクション名を変更する方法を示しています：
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


## **よくある質問**

**PPT（PowerPoint 97–2003）形式で保存した場合、セクションは保持されますか？**

いいえ。PPT 形式はセクションのメタデータをサポートしていないため、.ppt で保存するとセクションのグループ化情報は失われます。

**セクション全体を「非表示」にできますか？**

いいえ。非表示にできるのは個々のスライドだけです。セクション自体には「非表示」状態はありません。

**スライドからセクションをすばやく取得したり、逆にセクションの最初のスライドを取得したりできますか？**

はい。セクションは開始スライドによって一意に定義されます。スライドからそのスライドが属するセクションを判定でき、セクションからその最初のスライドにアクセスできます。