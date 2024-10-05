---
title: スライドセクション
type: docs
weight: 90
url: /php-java/slide-section/
---

Aspose.Slides for PHP via Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次の状況でスライドを論理的な部分に整理または分割するためにセクションを作成したい場合があります。

- 大きなプレゼンテーションを他の人やチームと共同で作成している場合—特定のスライドを同僚またはチームメンバーに割り当てる必要があります。
- 多くのスライドを含むプレゼンテーションに取り組んでいる場合—その内容を一度に管理または編集するのに苦労しています。

理想的には、類似のスライドを保持するセクションを作成し—スライドが共通点を持つか、ルールに基づいてグループ内に存在できる—その中のスライドを説明する名前をセクションに付けるべきです。

## プレゼンテーションにセクションを作成する

プレゼンテーションにスライドを収容するセクションを追加するには、Aspose.Slides for PHP via Java が提供する [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) メソッドを使用します。このメソッドでは、作成する予定のセクションの名前と、そのセクションが開始するスライドを指定できます。

このサンプルコードは、プレゼンテーションにセクションを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("セクション 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("セクション 2", $newSlide3);// section1はnewSlide2で終了し、その後section2が始まります

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("最後の空のセクション");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## セクションの名前を変更する

PowerPoint プレゼンテーションにセクションを作成した後、その名前を変更することを決める場合があります。

このサンプルコードは、Aspose.Slidesを使用してプレゼンテーション内のセクションの名前を変更する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("私のセクション");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```