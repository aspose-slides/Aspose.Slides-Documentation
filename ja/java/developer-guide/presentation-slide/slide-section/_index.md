---
title: Java を使用してプレゼンテーションのスライド セクションを管理
linktitle: スライド セクション
type: docs
weight: 90
url: /ja/java/slide-section/
keywords:
- セクション作成
- セクション追加
- セクション編集
- セクション変更
- セクション名
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のスライド セクションを効率化 — 分割、名前変更、再配置で PPTX と ODP のワークフローを最適化します。"
---

Aspose.Slides for Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

プレゼンテーションを論理的な部分に整理または分割するために、以下のような状況でセクションを作成して使用したい場合があります。

- 大規模なプレゼンテーションを他の人やチームと共同で作業しており、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。
- スライドが多数含まれるプレゼンテーションを扱っていて、内容を一度に管理または編集するのが困難な場合。

理想的には、類似したスライドをまとめたセクションを作成します。スライドに共通点があるか、あるルールに基づいてグループ化できる場合にセクションを作り、セクション名で内部のスライドを説明できるようにします。

## **Create Sections in Presentations**

プレゼンテーション内のスライドを格納するセクションを追加するには、Aspose.Slides for Java が [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) メソッドを提供しています。このメソッドを使用すると、作成するセクションの名前とセクション開始スライドを指定できます。

このサンプルコードは、Java でプレゼンテーションにセクションを作成する方法を示しています:
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

このサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーション内のセクション名を変更する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**PPT（PowerPoint 97–2003）形式で保存するとセクションは保持されますか？**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグループ化は失われます。

**セクション全体を「非表示」にできますか？**

できません。非表示にできるのは個々のスライドだけです。セクションという単位には「非表示」状態はありません。

**スライドからセクションをすぐに特定したり、逆にセクションの最初のスライドを取得したりできますか？**

はい。セクションは開始スライドで一意に定義されます。あるスライドからそのスライドが属するセクションを判定でき、セクションからは最初のスライドにアクセスできます。