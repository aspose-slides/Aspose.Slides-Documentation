---
title: Android でプレゼンテーションのスライド セクションを管理する
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/androidjava/slide-section/
keywords:
- セクションの作成
- セクションの追加
- セクションの編集
- セクションの変更
- セクション名
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java の Aspose.Slides で PowerPoint と OpenDocument のスライド セクションを効率化します—分割、名前変更、並べ替えで PPTX および ODP のワークフローを最適化します。"
---

Aspose.Slides for Android via Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

次のような状況で、プレゼンテーション内のスライドを論理的な部分に整理または分割するためにセクションを作成したい場合があります。

- 大規模なプレゼンテーションを他の人やチームと共同で作業していて、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。  
- 多数のスライドを含むプレゼンテーションを扱っていて、一度にその内容を管理または編集するのが困難な場合。

理想的には、類似したスライドをまとめるセクションを作成すべきです。スライドが共通点を持つ、またはルールに基づいてグループ化できる場合、そのセクションにスライドの内容を説明する名前を付けます。

## **プレゼンテーションでセクションを作成する**

プレゼンテーション内のスライドを格納するセクションを追加するには、Aspose.Slides for Android via Java は、作成するセクションの名前とセクションの開始スライドを指定できる [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) メソッドを提供します。

このサンプルコードは、Java でプレゼンテーションにセクションを作成する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 は newSlide2 で終了し、その後 section2 が開始されます   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **セクションの名前を変更する**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーションのセクション名を変更する方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**PPT（PowerPoint 97–2003）形式で保存するときにセクションは保持されますか？**  
いいえ。PPT 形式はセクションのメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化情報は失われます。

**セクション全体を「非表示」にできますか？**  
いいえ。非表示にできるのは個々のスライドだけです。セクションという単位には「非表示」状態はありません。

**スライドからセクションを素早く見つけたり、逆にセクションの最初のスライドを取得したりできますか？**  
はい。セクションは開始スライドによって一意に定義されます。スライドが与えられればそのスライドが属するセクションを判定でき、セクションが与えられればその最初のスライドにアクセスできます。