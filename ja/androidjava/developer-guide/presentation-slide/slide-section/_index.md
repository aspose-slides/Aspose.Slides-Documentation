---
title: スライドセクション
type: docs
weight: 90
url: /androidjava/slide-section/
---

Aspose.Slides for Android via Javaを使用すると、PowerPointプレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成することができます。

以下のような状況で、セクションを作成し、それを使用してプレゼンテーションのスライドを論理的な部分に整理または分割したい場合があります。

- 他の人やチームと一緒に大きなプレゼンテーションに取り組んでいるとき、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。
- 多くのスライドを含むプレゼンテーションを扱っていて、そのコンテンツを一度に管理または編集するのに苦労している場合。

理想的には、類似のスライドを収容するセクションを作成するべきです。スライドは何か共通の要素を持っているか、ルールに基づいてグループとして存在できるものです。そして、そのセクションにスライドを説明する名前を付けるべきです。

## プレゼンテーションでのセクションの作成

プレゼンテーションにスライドを収容するセクションを追加するために、Aspose.Slides for Android via Javaは、作成しようとしているセクションの名前とセクションが始まるスライドを指定できる[addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-)メソッドを提供します。

このサンプルコードは、Javaでプレゼンテーションにセクションを作成する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("セクション 1", newSlide1);
    ISection section2 = pres.getSections().addSection("セクション 2", newSlide3); // section1はnewSlide2で終了し、その後section2が始まる   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("最後の空のセクション");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## セクションの名前を変更する

PowerPointプレゼンテーションでセクションを作成した後、その名前を変更することを決定する場合があります。

このサンプルコードは、Aspose.Slidesを使用してJavaでプレゼンテーション内のセクションの名前を変更する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("私のセクション");
} finally {
    if (pres != null) pres.dispose();
}
```