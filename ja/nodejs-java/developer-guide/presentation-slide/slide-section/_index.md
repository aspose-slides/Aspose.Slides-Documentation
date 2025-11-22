---
title: スライド セクション
type: docs
weight: 90
url: /ja/nodejs-java/slide-section/
---

Aspose.Slides for Node.js via Java を使用すると、PowerPoint プレゼンテーションをセクションに整理できます。特定のスライドを含むセクションを作成できます。

スライドを論理的なパートに整理または分割するために、次のような状況でセクションを作成したい場合があります。

- 大規模なプレゼンテーションを他の人やチームと共同作業しているときで、特定のスライドを同僚やチームメンバーに割り当てる必要がある場合。  
- スライドが多数含まれているプレゼンテーションを扱っており、一度にその内容を管理または編集するのが困難な場合。

理想的には、類似したスライドをまとめるセクションを作成し（スライド同士に共通点があるか、あるいはルールに基づいてグループ化できる）、そのセクションにスライドの内容を表す名前を付けます。

## **Creating Sections in Presentations**

プレゼンテーション内のスライドを格納するセクションを追加するために、Aspose.Slides for Node.js via Java は、作成したいセクションの名前とセクションの開始スライドを指定できる [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) メソッドを提供します。

このサンプルコードは、JavaScript でプレゼンテーションにセクションを作成する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 は newSlide2 で終了し、その後 section2 が開始されます
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Changing the Names of Sections**

PowerPoint プレゼンテーションでセクションを作成した後、その名前を変更したくなることがあります。

このサンプルコードは、Aspose.Slides を使用して JavaScript でプレゼンテーション内のセクション名を変更する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

いいえ。PPT 形式はセクションメタデータをサポートしていないため、.ppt に保存するとセクションのグルーピングは失われます。

**Can an entire section be "hidden"?**

いいえ。個別のスライドだけが非表示にできます。セクション自体には「非表示」状態はありません。

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**

はい。セクションは開始スライドによって一意に定義されます。スライドが与えられればそれが属するセクションを判定でき、セクションが与えられればその最初のスライドにアクセスできます。